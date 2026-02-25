using System;
using System.Collections.Generic;
using Intercambio.Core;
using Intercambio.Entities;

namespace Intercambio.Levels
{
    /// <summary>
    /// Result state for the L01 Bitflip Patrol scenario.
    /// </summary>
    public enum L01BitflipPatrolStatus
    {
        InProgress,
        Succeeded,
        Failed
    }

    /// <summary>
    /// L01 scenario logic for detecting and patching a single modified bit before commit.
    /// No graphical logic is included in this class.
    /// </summary>
    public sealed class L01BitflipPatrolScenario
    {
        /// <summary>
        /// Expected packet the player is trying to reconstruct.
        /// </summary>
        public BitPacket ExpectedPacket { get; }

        /// <summary>
        /// Current received packet that may have tampered bits.
        /// </summary>
        public BitPacket ReceivedPacket { get; }

        /// <summary>
        /// Current scenario status.
        /// </summary>
        public L01BitflipPatrolStatus Status { get; private set; } = L01BitflipPatrolStatus.InProgress;

        public L01BitflipPatrolScenario(BitPacket expectedPacket, BitPacket receivedPacket)
        {
            if (expectedPacket == null)
            {
                throw new ArgumentNullException(nameof(expectedPacket));
            }

            if (receivedPacket == null)
            {
                throw new ArgumentNullException(nameof(receivedPacket));
            }

            if (expectedPacket.Length != receivedPacket.Length)
            {
                throw new ArgumentException("Expected and received packets must have equal bit lengths.");
            }

            ExpectedPacket = expectedPacket.Clone();
            ReceivedPacket = receivedPacket.Clone();
        }

        /// <summary>
        /// Returns indices where expected and received packets differ.
        /// Corresponds to the XorDiff gameplay verb.
        /// </summary>
        public IReadOnlyList<int> XorDiff()
        {
            return XorIntegrityAnalyzer.FindDifferingBitIndices(ExpectedPacket, ReceivedPacket);
        }

        /// <summary>
        /// Returns the currently received packet bits as a binary string.
        /// Useful for deterministic logs and test assertions.
        /// </summary>
        public string InspectBits()
        {
            return ReceivedPacket.ToBitString();
        }

        /// <summary>
        /// Flips a single bit in the received packet.
        /// Corresponds to the Flip Bit gameplay verb.
        /// </summary>
        public void FlipBit(int index)
        {
            EnsureInProgress();
            ReceivedPacket.FlipBit(index);
        }

        /// <summary>
        /// Attempts to commit the packet.
        /// Commit fails if any tampered bits remain.
        /// </summary>
        public bool CommitPacket()
        {
            EnsureInProgress();

            if (!XorIntegrityAnalyzer.IsExactMatch(ExpectedPacket, ReceivedPacket))
            {
                Status = L01BitflipPatrolStatus.Failed;
                return false;
            }

            Status = L01BitflipPatrolStatus.Succeeded;
            return true;
        }

        private void EnsureInProgress()
        {
            if (Status != L01BitflipPatrolStatus.InProgress)
            {
                throw new InvalidOperationException($"Scenario is no longer active. Current status: {Status}.");
            }
        }
    }
}

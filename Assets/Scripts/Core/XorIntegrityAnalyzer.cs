using System;
using System.Collections.Generic;
using Intercambio.Entities;

namespace Intercambio.Core
{
    /// <summary>
    /// Reusable deterministic XOR integrity operations for bit-level packet validation.
    /// </summary>
    public static class XorIntegrityAnalyzer
    {
        /// <summary>
        /// Returns the indices where two packets differ.
        /// </summary>
        public static IReadOnlyList<int> FindDifferingBitIndices(BitPacket expectedPacket, BitPacket receivedPacket)
        {
            ValidateComparablePackets(expectedPacket, receivedPacket);

            var differingIndices = new List<int>();
            for (var index = 0; index < expectedPacket.Length; index++)
            {
                var xorResult = expectedPacket.GetBit(index) ^ receivedPacket.GetBit(index);
                if (xorResult)
                {
                    differingIndices.Add(index);
                }
            }

            return differingIndices;
        }

        /// <summary>
        /// Returns true when no bit differences exist between the packets.
        /// </summary>
        public static bool IsExactMatch(BitPacket expectedPacket, BitPacket receivedPacket)
        {
            ValidateComparablePackets(expectedPacket, receivedPacket);
            for (var index = 0; index < expectedPacket.Length; index++)
            {
                if (expectedPacket.GetBit(index) != receivedPacket.GetBit(index))
                {
                    return false;
                }
            }

            return true;
        }

        private static void ValidateComparablePackets(BitPacket expectedPacket, BitPacket receivedPacket)
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
                throw new ArgumentException(
                    $"Packets must have the same length. Expected {expectedPacket.Length} bits but received {receivedPacket.Length} bits.");
            }
        }
    }
}

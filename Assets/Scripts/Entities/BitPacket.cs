using System;

namespace Intercambio.Entities
{
    /// <summary>
    /// Represents a deterministic bit-level packet used by cryptographic tutorial scenarios.
    /// </summary>
    public sealed class BitPacket
    {
        private readonly bool[] bits;

        /// <summary>
        /// Stable packet identifier for debugging and replay traces.
        /// </summary>
        public string PacketId { get; }

        /// <summary>
        /// Number of bits contained in this packet.
        /// </summary>
        public int Length => bits.Length;

        /// <summary>
        /// Create a packet from a precomputed bit array.
        /// </summary>
        public BitPacket(string packetId, bool[] bitValues)
        {
            if (string.IsNullOrWhiteSpace(packetId))
            {
                throw new ArgumentException("Packet ID is required.", nameof(packetId));
            }

            if (bitValues == null)
            {
                throw new ArgumentNullException(nameof(bitValues));
            }

            if (bitValues.Length == 0)
            {
                throw new ArgumentException("Packet must contain at least one bit.", nameof(bitValues));
            }

            PacketId = packetId;
            bits = new bool[bitValues.Length];
            Array.Copy(bitValues, bits, bitValues.Length);
        }

        /// <summary>
        /// Create a packet from a binary string like "10100101".
        /// </summary>
        public static BitPacket FromBitString(string packetId, string bitString)
        {
            if (bitString == null)
            {
                throw new ArgumentNullException(nameof(bitString));
            }

            if (bitString.Length == 0)
            {
                throw new ArgumentException("Bit string must contain at least one character.", nameof(bitString));
            }

            var parsedBits = new bool[bitString.Length];
            for (var index = 0; index < bitString.Length; index++)
            {
                var currentCharacter = bitString[index];
                switch (currentCharacter)
                {
                    case '0':
                        parsedBits[index] = false;
                        break;
                    case '1':
                        parsedBits[index] = true;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported bit character '{currentCharacter}' at index {index}.", nameof(bitString));
                }
            }

            return new BitPacket(packetId, parsedBits);
        }

        /// <summary>
        /// Read a bit value at an index.
        /// </summary>
        public bool GetBit(int index)
        {
            ValidateIndex(index);
            return bits[index];
        }

        /// <summary>
        /// Set a bit value at an index.
        /// </summary>
        public void SetBit(int index, bool value)
        {
            ValidateIndex(index);
            bits[index] = value;
        }

        /// <summary>
        /// Flip a single bit at an index.
        /// </summary>
        public void FlipBit(int index)
        {
            ValidateIndex(index);
            bits[index] = !bits[index];
        }

        /// <summary>
        /// Returns a detached copy of packet bits.
        /// </summary>
        public bool[] ToArray()
        {
            var copy = new bool[bits.Length];
            Array.Copy(bits, copy, bits.Length);
            return copy;
        }

        /// <summary>
        /// Serializes packet bits as a binary string.
        /// </summary>
        public string ToBitString()
        {
            var characters = new char[bits.Length];
            for (var index = 0; index < bits.Length; index++)
            {
                characters[index] = bits[index] ? '1' : '0';
            }

            return new string(characters);
        }

        /// <summary>
        /// Creates a deep copy with the same packet identity and bit payload.
        /// </summary>
        public BitPacket Clone()
        {
            return new BitPacket(PacketId, ToArray());
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= bits.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Bit index {index} is outside [0, {bits.Length - 1}].");
            }
        }
    }
}

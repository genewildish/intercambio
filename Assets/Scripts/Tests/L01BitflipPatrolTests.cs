using NUnit.Framework;
using Intercambio.Entities;
using Intercambio.Levels;

namespace Intercambio.Tests
{
    public class L01BitflipPatrolTests
    {
        [Test]
        public void XorDiff_WhenOneBitIsTampered_ReturnsTheTamperedIndex()
        {
            // Arrange
            var scenario = BuildScenario("10110010", 5);

            // Act
            var differingIndices = scenario.XorDiff();

            // Assert
            Assert.That(differingIndices.Count, Is.EqualTo(1), "Exactly one bit should differ.");
            Assert.That(differingIndices[0], Is.EqualTo(5), "The detected bit index should match the tampered index.");
            Assert.That(scenario.Status, Is.EqualTo(L01BitflipPatrolStatus.InProgress));
        }

        [Test]
        public void CommitPacket_WithoutPatchingTamper_FailsScenario()
        {
            // Arrange
            var scenario = BuildScenario("10110010", 2);

            // Act
            var commitResult = scenario.CommitPacket();

            // Assert
            Assert.That(commitResult, Is.False, "Commit should fail while packet is still tampered.");
            Assert.That(scenario.Status, Is.EqualTo(L01BitflipPatrolStatus.Failed));
        }

        [Test]
        public void FlipBit_AtTamperedIndex_ThenCommitPacket_SucceedsScenario()
        {
            // Arrange
            var scenario = BuildScenario("10110010", 2);

            // Act
            scenario.FlipBit(2);
            var differingIndicesAfterPatch = scenario.XorDiff();
            var commitResult = scenario.CommitPacket();

            // Assert
            Assert.That(differingIndicesAfterPatch.Count, Is.EqualTo(0), "No differing bits should remain after patching.");
            Assert.That(commitResult, Is.True, "Commit should succeed after patching all tampered bits.");
            Assert.That(scenario.Status, Is.EqualTo(L01BitflipPatrolStatus.Succeeded));
        }

        [Test]
        public void SameInputPackets_ProduceDeterministicXorDiffOutput()
        {
            // Arrange
            var scenarioA = BuildScenario("11100101", 0);
            var scenarioB = BuildScenario("11100101", 0);

            // Act
            var diffA = scenarioA.XorDiff();
            var diffB = scenarioB.XorDiff();

            // Assert
            Assert.That(diffA.Count, Is.EqualTo(diffB.Count), "Diff count should match between runs.");
            for (var index = 0; index < diffA.Count; index++)
            {
                Assert.That(diffA[index], Is.EqualTo(diffB[index]), $"Diff index mismatch at position {index}.");
            }
        }

        private static L01BitflipPatrolScenario BuildScenario(string bitString, int tamperedIndex)
        {
            var expected = BitPacket.FromBitString("expected", bitString);
            var received = BitPacket.FromBitString("received", bitString);
            received.FlipBit(tamperedIndex);
            return new L01BitflipPatrolScenario(expected, received);
        }
    }
}

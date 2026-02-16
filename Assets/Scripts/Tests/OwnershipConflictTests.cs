using NUnit.Framework;
using System.Linq;

namespace Intercambio.Tests
{
    public class OwnershipConflictTests
    {
        [Test]
        public void TwoNodesClaimingSameCoin_DetectsConflict()
        {
            // Arrange
            var network = new Network();
            var alice = new Node("Alice");
            var bob = new Node("Bob");
            
            network.AddNode(alice);
            network.AddNode(bob);
            
            // Act - Both claim ownership of the same coin
            alice.ClaimOwnership("Coin1");
            bob.ClaimOwnership("Coin1");
            
            // Assert
            var conflicts = network.DetectOwnershipConflicts();
            
            Assert.That(conflicts.Count, Is.EqualTo(1), "Should detect exactly one conflict");
            Assert.That(conflicts.ContainsKey("Coin1"), Is.True, "Should detect conflict for Coin1");
            Assert.That(conflicts["Coin1"].Count, Is.EqualTo(2), "Should show both nodes' claims");
        }
        
        [Test]
        public void SingleNodeOwnership_NoConflict()
        {
            // Arrange
            var network = new Network();
            var alice = new Node("Alice");
            
            network.AddNode(alice);
            
            // Act
            alice.ClaimOwnership("Coin1");
            
            // Assert
            var conflicts = network.DetectOwnershipConflicts();
            
            Assert.That(conflicts.Count, Is.EqualTo(0), "Should not detect any conflicts");
        }
        
        [Test]
        public void NodeCanStoreAndRetrieveState()
        {
            // Arrange
            var node = new Node("TestNode");
            
            // Act
            node.SetState("test_key", "test_value");
            
            // Assert
            Assert.That(node.GetState("test_key"), Is.EqualTo("test_value"));
            Assert.That(node.NodeId, Is.EqualTo("TestNode"));
        }
    }
}
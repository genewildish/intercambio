using UnityEngine;
using System.Collections.Generic;

namespace Intercambio
{
    /// <summary>
    /// The first and most basic puzzle: two nodes both claim ownership of the same coin
    /// This demonstrates why we need consensus mechanisms
    /// </summary>
    public class OwnershipConflictScenario : MonoBehaviour
    {
        [Header("Debug Visualization")]
        public bool showDebugInfo = true;
        
        private Network network;
        private Node alice;
        private Node bob;
        
        void Start()
        {
            SetupScenario();
        }
        
        void SetupScenario()
        {
            // Create the network
            network = new Network();
            
            // Create two nodes
            alice = new Node("Alice");
            bob = new Node("Bob");
            
            // Add them to the network
            network.AddNode(alice);
            network.AddNode(bob);
            
            // THE PROBLEM: Both nodes independently claim ownership of the same coin
            alice.ClaimOwnership("Coin1");
            bob.ClaimOwnership("Coin1");
            
            // Show the conflict
            if (showDebugInfo)
            {
                AnalyzeConflict();
            }
        }
        
        void AnalyzeConflict()
        {
            Debug.Log("=== OWNERSHIP CONFLICT SCENARIO ===");
            
            // Show what each node thinks
            Debug.Log($"Alice thinks: {alice.GetOwner("Coin1")} owns Coin1");
            Debug.Log($"Bob thinks: {bob.GetOwner("Coin1")} owns Coin1");
            
            // Detect conflicts using the network
            var conflicts = network.DetectOwnershipConflicts();
            
            foreach (var conflict in conflicts)
            {
                Debug.Log($"CONFLICT detected for {conflict.Key}:");
                foreach (var claimant in conflict.Value)
                {
                    Debug.Log($"  - {claimant}");
                }
            }
            
            Debug.Log("PROBLEM: How do we resolve this? Who actually owns Coin1?");
            Debug.Log("This is why we need consensus mechanisms!");
        }
        
        // For Unity inspector - you can trigger this manually
        [ContextMenu("Demonstrate Conflict")]
        public void DemonstrateConflict()
        {
            if (network == null) SetupScenario();
            AnalyzeConflict();
        }
        
        // Simple getter for the network (for potential UI integration)
        public Network GetNetwork()
        {
            return network;
        }
    }
}
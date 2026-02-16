using System.Collections.Generic;
using System.Linq;

namespace Intercambio
{
    /// <summary>
    /// A simple network that manages nodes and message passing
    /// </summary>
    public class Network
    {
        private Dictionary<string, Node> nodes;
        private List<Message> messageHistory;
        
        public Network()
        {
            nodes = new Dictionary<string, Node>();
            messageHistory = new List<Message>();
        }
        
        /// <summary>
        /// Add a node to the network
        /// </summary>
        public void AddNode(Node node)
        {
            nodes[node.NodeId] = node;
        }
        
        /// <summary>
        /// Get a node by ID
        /// </summary>
        public Node GetNode(string nodeId)
        {
            return nodes.TryGetValue(nodeId, out Node node) ? node : null;
        }
        
        /// <summary>
        /// Get all nodes in the network
        /// </summary>
        public List<Node> GetAllNodes()
        {
            return nodes.Values.ToList();
        }
        
        /// <summary>
        /// Send a message between nodes (for now, immediate delivery)
        /// </summary>
        public void SendMessage(string fromNodeId, string toNodeId, string messageType, string content, int currentTick = 0)
        {
            var message = new Message(fromNodeId, toNodeId, messageType, content, currentTick);
            messageHistory.Add(message);
            
            // For now, messages are delivered immediately
            // Later we'll add delays, failures, etc.
        }
        
        /// <summary>
        /// Get all message history (for debugging/visualization)
        /// </summary>
        public List<Message> GetMessageHistory()
        {
            return new List<Message>(messageHistory);
        }
        
        /// <summary>
        /// Check for conflicting ownership claims across all nodes
        /// </summary>
        public Dictionary<string, List<string>> DetectOwnershipConflicts()
        {
            var conflicts = new Dictionary<string, List<string>>();
            
            // Get all possible item IDs from all nodes
            var allItemIds = new HashSet<string>();
            foreach (var node in nodes.Values)
            {
                var state = node.GetAllState();
                foreach (var key in state.Keys)
                {
                    if (key.StartsWith("owner_of_"))
                    {
                        var itemId = key.Substring("owner_of_".Length);
                        allItemIds.Add(itemId);
                    }
                }
            }
            
            // Check each item for conflicts
            foreach (var itemId in allItemIds)
            {
                var claimants = new List<string>();
                foreach (var node in nodes.Values)
                {
                    var owner = node.GetOwner(itemId);
                    if (owner != null)
                    {
                        claimants.Add($"{node.NodeId} claims {owner} owns {itemId}");
                    }
                }
                
                // If more than one node has an opinion, or if they disagree, it's a conflict
                if (claimants.Count > 1 || claimants.Any(c => !c.Contains($"claims {claimants[0].Split(' ')[1]} owns")))
                {
                    conflicts[itemId] = claimants;
                }
            }
            
            return conflicts;
        }
    }
}
using System.Collections.Generic;

namespace Intercambio
{
    /// <summary>
    /// A basic node in the distributed system.
    /// Each node maintains local state and can communicate with other nodes.
    /// </summary>
    public class Node
    {
        public string NodeId { get; private set; }
        
        // Local state storage - for now, just a simple dictionary
        private Dictionary<string, string> localState;
        
        public Node(string nodeId)
        {
            NodeId = nodeId;
            localState = new Dictionary<string, string>();
        }
        
        /// <summary>
        /// Store a key-value pair in local state
        /// </summary>
        public void SetState(string key, string value)
        {
            localState[key] = value;
        }
        
        /// <summary>
        /// Read a value from local state
        /// </summary>
        public string GetState(string key)
        {
            return localState.TryGetValue(key, out string value) ? value : null;
        }
        
        /// <summary>
        /// Get all local state (for debugging/visualization)
        /// </summary>
        public Dictionary<string, string> GetAllState()
        {
            return new Dictionary<string, string>(localState);
        }
        
        /// <summary>
        /// Claim ownership of something
        /// </summary>
        public void ClaimOwnership(string itemId)
        {
            SetState($"owner_of_{itemId}", NodeId);
        }
        
        /// <summary>
        /// Check who this node thinks owns an item
        /// </summary>
        public string GetOwner(string itemId)
        {
            return GetState($"owner_of_{itemId}");
        }
    }
}
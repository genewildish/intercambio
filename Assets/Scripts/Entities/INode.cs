using System.Collections.Generic;

namespace Intercambio.Entities
{
    /// <summary>
    /// Interface for distributed system nodes.
    /// Each node maintains local state and can execute player-programmed logic.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Unique identifier for this node
        /// </summary>
        string Id { get; }
        
        /// <summary>
        /// Current local state of the node
        /// </summary>
        INodeState State { get; }
        
        /// <summary>
        /// Queue of incoming messages
        /// </summary>
        IReadOnlyCollection<IMessage> IncomingMessages { get; }
        
        /// <summary>
        /// Queue of outgoing messages
        /// </summary>
        IReadOnlyCollection<IMessage> OutgoingMessages { get; }
        
        /// <summary>
        /// Execute one tick of this node's programmed logic
        /// </summary>
        void ExecuteTick();
        
        /// <summary>
        /// Receive a message from the network
        /// </summary>
        void ReceiveMessage(IMessage message);
        
        /// <summary>
        /// Send a message to another node
        /// </summary>
        void SendMessage(IMessage message);
        
        /// <summary>
        /// Clear all outgoing messages (called after network processing)
        /// </summary>
        void ClearOutgoingMessages();
    }
    
    /// <summary>
    /// Interface for node local state
    /// </summary>
    public interface INodeState
    {
        /// <summary>
        /// Read a value from local storage
        /// </summary>
        object Read(string key);
        
        /// <summary>
        /// Write a value to local storage
        /// </summary>
        void Write(string key, object value);
        
        /// <summary>
        /// Check if a key exists in local storage
        /// </summary>
        bool HasKey(string key);
    }
}
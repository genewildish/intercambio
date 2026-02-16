namespace Intercambio.Entities
{
    /// <summary>
    /// Interface for messages passed between nodes in the distributed system
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Unique identifier for this message
        /// </summary>
        string Id { get; }
        
        /// <summary>
        /// ID of the sender node
        /// </summary>
        string SenderId { get; }
        
        /// <summary>
        /// ID of the recipient node
        /// </summary>
        string RecipientId { get; }
        
        /// <summary>
        /// Message payload data
        /// </summary>
        object Data { get; }
        
        /// <summary>
        /// Tick when this message was sent
        /// </summary>
        long SentTick { get; }
        
        /// <summary>
        /// Tick when this message should be delivered (for simulating latency)
        /// </summary>
        long DeliveryTick { get; }
        
        /// <summary>
        /// Message type/category for routing and processing
        /// </summary>
        MessageType Type { get; }
    }
    
    /// <summary>
    /// Types of messages in the system
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// General data message
        /// </summary>
        Data,
        
        /// <summary>
        /// Request for coordination/consensus
        /// </summary>
        Coordination,
        
        /// <summary>
        /// Heartbeat/keepalive message
        /// </summary>
        Heartbeat,
        
        /// <summary>
        /// Error or failure notification
        /// </summary>
        Error
    }
}
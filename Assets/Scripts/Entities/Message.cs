namespace Intercambio
{
    /// <summary>
    /// A message that can be sent between nodes
    /// </summary>
    public class Message
    {
        public string FromNodeId { get; private set; }
        public string ToNodeId { get; private set; }
        public string MessageType { get; private set; }
        public string Content { get; private set; }
        public int CreatedAtTick { get; private set; }
        
        public Message(string fromNodeId, string toNodeId, string messageType, string content, int createdAtTick = 0)
        {
            FromNodeId = fromNodeId;
            ToNodeId = toNodeId;
            MessageType = messageType;
            Content = content;
            CreatedAtTick = createdAtTick;
        }
        
        public override string ToString()
        {
            return $"[{CreatedAtTick}] {FromNodeId} -> {ToNodeId}: {MessageType} ({Content})";
        }
    }
}
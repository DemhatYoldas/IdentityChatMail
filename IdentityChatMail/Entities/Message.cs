namespace IdentityChatMail.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public bool SenderIsImportant { get; set; } = false;
        public bool ReceiverIsImportant { get; set; } = false;
        public bool SenderIsDeleted { get; set; } = false;
        public bool ReceiverIsDeleted { get; set; } = false;

    }
}

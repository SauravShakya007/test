namespace CodeCheckIn.Core.Dtos.Receiver
{
    public class ReceiverGetDto
    {
        public int Id { get; set; }
        public string SendTo { get; set; }

        public long SenderId { get; set; }
        public string From { get; set; }
    }
}

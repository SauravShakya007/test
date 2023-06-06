namespace CodeCheckIn.Core.Dtos.Receiver
{
    public class ReceiverCreateDto
    {
        public int Id { get; set; }
        public string SendTo { get; set; }
        public long SenderId { get; set; }
    }
}

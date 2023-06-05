namespace CodeCheckIn.Core.Entities
{
    public class Receiver
    {
        public int Id { get; set; }
        public string SendTo { get; set; }
        
        //Relations
        public long SenderId { get; set; }
        public MainPage MainPage { get; set; }
    }
}

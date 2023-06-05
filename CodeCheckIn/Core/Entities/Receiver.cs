using System.ComponentModel.DataAnnotations;

namespace CodeCheckIn.Core.Entities
{
    public class Receiver
    {
        [Key]
        public int Id { get; set; }
        public string SendTo { get; set; }
        
        //Relations
        public long SenderId { get; set; }
        public MainPage MainPage { get; set; }
    }
}

using CodeCheckIn.Core.Enums;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace CodeCheckIn.Core.Entities
{
    public class FilesURL
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public FileType Filetype { get; set; }
        
        //Relations
        public long SenderId { get; set; }
        public MainPage MainPage { get; set; }
    }
}

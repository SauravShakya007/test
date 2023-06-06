using CodeCheckIn.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCheckIn.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<MainPage> MainPages{ get; set; }
        //public object CheckIns { get; internal set; }

        
    }
}

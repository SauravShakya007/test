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
        public DbSet<Receiver> Receivers { get; set; }
        public object CheckIns { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Receiver>()
                .HasOne(receiver => receiver.MainPage)
                .WithMany(mainpage => mainpage.SendTo)
                .HasForeignKey(receiver => receiver.SenderId);

            //modelBuilder.Entity<FilesURL>() //29:00
            //    .HasOne(filesurl=> filesurl.MainPage)
            //    .WithMany(mainpage=> mainpage.SpecificationDoc)
            //    .HasForeignKey(filesurl=> filesurl.MainPage);


        }
    }
}

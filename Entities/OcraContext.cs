using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class OcraContext:DbContext
    {
        public OcraContext(DbContextOptions<OcraContext> options)
            :base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marriage>()
             .HasOne(m => m.Husband)
             .WithMany()
             .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Marriage>()
                .HasOne(m => m.Wife)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            //modelBuilder.ApplyConfiguration(new BirthConfiguration());

        }
        public DbSet<Birth> Births { get; set; }
        public DbSet<Death> Deaths { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
    }
}

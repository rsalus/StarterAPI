using Microsoft.EntityFrameworkCore;

namespace StarterMicroservice.API
{
    public class MyUserContext(DbContextOptions<MyUserContext> options) : DbContext(options)
    {
        public DbSet<MyUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the MyUser entity
            modelBuilder.Entity<MyUser>()
                .ToTable("users")
                .HasIndex(c => new { c.UserId, c.UserName })
                .IsUnique();
        }
    }
}

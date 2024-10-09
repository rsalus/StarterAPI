using Microsoft.EntityFrameworkCore;

namespace StarterMicroservice.API
{
    public class MyUserContext(DbContextOptions<MyUserContext> options) : DbContext(options)
    {
        public DbSet<MyUser> Users { get; set; }
    }
}

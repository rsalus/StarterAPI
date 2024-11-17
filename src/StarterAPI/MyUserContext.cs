using Microsoft.EntityFrameworkCore;

namespace StarterAPI
{
    public class MyUserContext(DbContextOptions<MyUserContext> options) : DbContext(options)
    {
        public required DbSet<MyUser> Users { get; set; }
    }
}

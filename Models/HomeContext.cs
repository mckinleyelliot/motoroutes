using Microsoft.EntityFrameworkCore;

namespace motoroutes.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get;set;}
        public DbSet<ride> rides {get;set;}
        public DbSet<comment> comments {get;set;}
    }
}
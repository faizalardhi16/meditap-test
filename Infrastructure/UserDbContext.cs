using Meditaps.Entities;
using Microsoft.EntityFrameworkCore;



namespace Meditaps.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users {get; set;}
    }
}

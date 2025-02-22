using Microsoft.EntityFrameworkCore;

namespace theParodyJournal.Models
{
    public class UserContext: DbContext
    {
        public DbSet<UserDB> Users  { get; set; }
        
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
            
    }
}

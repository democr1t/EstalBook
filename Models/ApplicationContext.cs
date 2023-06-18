using Microsoft.EntityFrameworkCore;

namespace EstalBook.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}

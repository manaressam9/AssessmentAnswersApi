using Microsoft.EntityFrameworkCore;
namespace AssessmentAnswers.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssesTrueFalse> AssesTrueFalses { get; set; }
        public DbSet<AssesAnswer> AssesAnswer { get; set; }
    }
}

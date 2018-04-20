using Microsoft.EntityFrameworkCore;

namespace PertaminaQuestionnaire.Models
{
    public class PertaminaQADBContext: DbContext 
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public PertaminaQADBContext(DbContextOptions<PertaminaQADBContext> options)
            : base(options)
        {
        }
    }
}

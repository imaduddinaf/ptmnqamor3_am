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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=sql_server_demo;User Id=sa;Password=reallyStrongPwd123;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}

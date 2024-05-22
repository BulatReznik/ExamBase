using Microsoft.EntityFrameworkCore;

namespace C_
{
    public class ExamContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("localhost;Database=ExamDb;User Id=myUsername;Password=myPassword;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }   
    }
}

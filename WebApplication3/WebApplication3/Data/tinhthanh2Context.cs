using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
namespace WebApplication3.Data
{
    public class tinhthanh2Context : DbContext 
    {
        public DbSet<tinhthanh2> tinhthanh2s { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VLONG;Database=Tinhthanh2;Trusted_Connection=True;");
        }       
    }
}

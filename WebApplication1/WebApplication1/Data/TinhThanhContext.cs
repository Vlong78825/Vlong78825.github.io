using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class TinhThanhContext :DbContext
    {
        public DbSet<QuanHuyen> QuanHuyens { get; set; }
        public DbSet<ThanhPho> ThanhPhos { get; set; }
        public DbSet<User> Users { get; set; }

        public TinhThanhContext(DbContextOptions<TinhThanhContext> options) : base(options) { }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using WebApplication1.Models;
namespace WebApplication1.Models
{
    [Index(nameof(TenThanhPho), IsUnique = true)]
    public class ThanhPho
    {
     
        public int Id { get; set; }
        [Required]
        public string TenThanhPho { get; set; }

        public ICollection<QuanHuyen> QuanHuyen { get; set; }
    }
}

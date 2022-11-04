using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;
namespace WebApplication1.Models
{
    [Index("TenQuanHuyen", "ThanhPhoId", IsUnique = true)]
    public class QuanHuyen
    {
        public int Id { get; set; }
       
        public string TenQuanHuyen { get; set; }
        
        public int ThanhPhoId { get; set; }
        public ThanhPho ThanhPho { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Index(nameof(username), IsUnique = true)]
    public class User
    {
        [Key]
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}

using WebApplication1.Models;
using WebApplication1.DTO;
namespace WebApplication1.Interfaces
{
    public interface IThanhPhoRepository
    {
        ICollection<ThanhPho> GetThanhPho();
        ThanhPho GetThanhPho(string tenThanhPho);
        ThanhPho CreateThanhPho(ThanhPhoDTO thanhPho);
        ThanhPho DeleteThanhPho(ThanhPho thanhPho);

    }
}

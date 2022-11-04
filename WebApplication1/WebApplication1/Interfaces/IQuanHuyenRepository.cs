using WebApplication1.Models;
using WebApplication1.DTO;
namespace WebApplication1.Interfaces
{
    public interface IQuanHuyenRepository
    {

        ICollection<QuanHuyen> GetQuanHuyen();
        ICollection<QuanHuyen> GetQuanHuyen(int thanhPhoid);
        QuanHuyen CreateQuanHuyen(QuanHuyenDTO quanHuyen);
        QuanHuyen DeleteQuanHuyen(QuanHuyen quanHuyen);
    
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class QuanHuyenRepository : IQuanHuyenRepository
    {
        private readonly TinhThanhContext _context;
        public QuanHuyenRepository (TinhThanhContext context)
        {
            _context = context;
        }

        public QuanHuyen CreateQuanHuyen(QuanHuyenDTO quanHuyen)
        {
            var data = new QuanHuyen()
            {
                Id = quanHuyen.Id,
                TenQuanHuyen = quanHuyen.TenQuanHuyen,
                ThanhPhoId = quanHuyen.ThanhPhoId,
                ThanhPho = null
            };
            _context.QuanHuyens.Add(data);
            _context.SaveChanges();
            return data;         
        }

        public QuanHuyen DeleteQuanHuyen(QuanHuyen quanHuyen)
        {
            _context.Remove(quanHuyen);
            _context.SaveChanges();        
            return quanHuyen;
        }

        public ICollection<QuanHuyen> GetQuanHuyen(int thanhPhoid)
        {
            return _context.QuanHuyens.Where(p => p.ThanhPhoId == thanhPhoid).ToList();
        }

        public ICollection<QuanHuyen> GetQuanHuyen()
        {
            return _context.QuanHuyens.ToList();
        }
    }
}

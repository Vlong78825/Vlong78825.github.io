using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository
{
    public class ThanhPhoRepository : IThanhPhoRepository
    {
        private readonly TinhThanhContext _context;
        public ThanhPhoRepository(TinhThanhContext context)
        {
            _context = context;
        }

        public ThanhPho CreateThanhPho(ThanhPhoDTO thanhPho)
        {
            var data = new ThanhPho()
            { Id = thanhPho.Id,
                TenThanhPho = thanhPho.TenThanhPho,
                QuanHuyen = null
            };
            _context.ThanhPhos.Add(data);
            _context.SaveChanges();
            return data;
        }

        public ThanhPho DeleteThanhPho(ThanhPho thanhPho)
        {
            _context.Remove(thanhPho);
            _context.SaveChanges();
            return thanhPho;
        }

        public ICollection<ThanhPho> GetThanhPho()
        {
            return _context.ThanhPhos.ToList();
        }

        public ThanhPho GetThanhPho(string tenThanhPho)
        {
            return _context.ThanhPhos.Where(p => p.TenThanhPho == tenThanhPho).FirstOrDefault();
        }
    }
}

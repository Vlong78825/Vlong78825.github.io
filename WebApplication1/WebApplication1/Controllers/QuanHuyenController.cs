using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using WebApplication1.Repository;
using AutoMapper;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanHuyenController : ControllerBase
    {
        private readonly TinhThanhContext _context;
        private readonly IThanhPhoRepository _thanhPhoRepository;
        private readonly IMapper _mapper;
        private readonly IQuanHuyenRepository _quanHuyenRepository;
        public QuanHuyenController(TinhThanhContext context, IThanhPhoRepository thanhPhoRepository, IMapper mapper, IQuanHuyenRepository quanHuyenRepository)
        {
            _context = context;
            _thanhPhoRepository = thanhPhoRepository;
            _mapper = mapper;
            _quanHuyenRepository = quanHuyenRepository;
        }

        // GET: api/TinhThanh
        [HttpGet]
        public IActionResult GetQuanHuyen()
        {

            var data = _mapper.Map<List<QuanHuyenDTO>>(_quanHuyenRepository.GetQuanHuyen());
            return Ok(data);
        }
        [HttpGet("withThanhPho")]
        public IActionResult GetQuanHuyenWithThanhPho()
        {
            var data = (from a in _context.ThanhPhos
                        from b in _context.QuanHuyens 
                        where a.Id== b.ThanhPhoId
                        select new
                        {
                            Id=b.Id,
                            TenQuanHuyen=b.TenQuanHuyen,
                            ThanhPhoId = b.ThanhPhoId,
                            TenThanhPho=a.TenThanhPho,
                        }
                );
           
            return Ok(data);
        }

        // GET: api/QuanHuyen/5
        [HttpGet("{thanhPhoid}")]
        public IActionResult GetQuanHuyenbyThanhPho(int thanhPhoid)
        {
            if (!ThanhPhoExists(thanhPhoid))
            {
                return NotFound();
            }

            var data = _quanHuyenRepository.GetQuanHuyen(thanhPhoid);
            var data2 = _mapper.Map<List<QuanHuyenDTO>>(data);
            return Ok(data2);
        }
        // PUT: api/QuanHuyen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutQuanHuyen(int id, QuanHuyenDTO dTO)
        {
            if (id != dTO.Id)
            {
                return BadRequest();
            }
            if (!ThanhPhoExists(dTO.ThanhPhoId))
            {
                return BadRequest();
            }
            if (_context.QuanHuyens.Any(e => (e.ThanhPhoId == dTO.ThanhPhoId) && (e.TenQuanHuyen == dTO.TenQuanHuyen)))
            {
                return BadRequest();
            }
            _context.Entry(_mapper.Map<QuanHuyen>(dTO)).State = EntityState.Modified;           
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanHuyenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        // POST: api/QuanHuyen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostQuanHuyen(QuanHuyenDTO dTO)
        {
            if (!ThanhPhoExists(dTO.ThanhPhoId))
            {
                return BadRequest();
            }
            if(_context.QuanHuyens.Any(e => (e.ThanhPhoId==dTO.ThanhPhoId ) && (e.TenQuanHuyen== dTO.TenQuanHuyen))) 
            {
                return BadRequest();
            }
            var data = _quanHuyenRepository.CreateQuanHuyen(dTO);
            var data2 = _mapper.Map<QuanHuyen>(data);
            return CreatedAtAction("GetQuanHuyen", new { id = data2.Id }, data2);
        }
        // DELETE: api/QuanHuyen/5
        [HttpDelete("{id}")]
        public IActionResult DeleteQuanHuyen(int id)
        {
            var quanHuyen = _context.QuanHuyens.Find(id);
            if (quanHuyen == null)
            {
                return NotFound();
            }
            var data = _quanHuyenRepository.DeleteQuanHuyen(quanHuyen);
            return Ok(data);
        }
        private bool QuanHuyenExists(int id)
        {
            return _context.QuanHuyens.Any(e => e.Id == id);
        }
        private bool ThanhPhoExists(int id)
        {
            return _context.ThanhPhos.Any(e => e.Id == id);
        }
    }
}

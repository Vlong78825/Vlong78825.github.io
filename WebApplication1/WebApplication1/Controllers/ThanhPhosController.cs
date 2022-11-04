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
    public class ThanhPhosController : ControllerBase
    {
        private readonly TinhThanhContext _context;
        private readonly IThanhPhoRepository _thanhPhoRepository;
        private readonly IMapper _mapper;
        public ThanhPhosController(TinhThanhContext context,IThanhPhoRepository thanhPhoRepository, IMapper mapper)
        {
            _context = context;
            _thanhPhoRepository = thanhPhoRepository;
            _mapper= mapper;
        }

        // GET: api/ThanhPhos
        [HttpGet]
        public IActionResult GetThanhPho()
        {

            var data = _mapper.Map<List<ThanhPhoDTO>>(_thanhPhoRepository.GetThanhPho()); 
            return Ok(data);
        }

        // GET: api/ThanhPhos/5
        [HttpGet("{tenThanhPho}")]
        public IActionResult GetThanhPho(string tenThanhPho)
        {
            var data = _mapper.Map<ThanhPhoDTO>(_thanhPhoRepository.GetThanhPho(tenThanhPho));
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // PUT: api/ThanhPhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutThanhPho(int id, ThanhPhoDTO dTO)
        {
            if (id != dTO.Id)
            {
                return BadRequest();
            }          
            _context.Entry(_mapper.Map<ThanhPho>(dTO)).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhPhoExists(id))
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

        // POST: api/ThanhPhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostThanhPho(ThanhPhoDTO dTO)
        {   if (_context.ThanhPhos.Any(e => e.TenThanhPho == dTO.TenThanhPho)) {
                return NoContent();
            }
            if (dTO.TenThanhPho == null)
            {
                return BadRequest();
            }

            var data =_thanhPhoRepository.CreateThanhPho(dTO);
            var data2 = _mapper.Map<ThanhPho>(data);
            return CreatedAtAction("GetThanhPho", new { id = data2.Id }, data2);
        }

        // DELETE: api/ThanhPhos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteThanhPho(int id)
        {
            var thanhPho = _context.ThanhPhos.Find(id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            var data = _thanhPhoRepository.DeleteThanhPho(thanhPho);


            return Ok(data);
        }

        private bool ThanhPhoExists(int id)
        {
            return _context.ThanhPhos.Any(e => e.Id == id);
        }
    }
}

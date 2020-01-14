using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/menu/[controller]")]
    [ApiController]
    public class RozmiarController : ControllerBase
    {
        private s16788Context _context;

        public RozmiarController(s16788Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSizes() {
            return Ok(_context.Rozmiar.ToList());
        }

        [HttpPost("create")]
        public IActionResult CreateSizes(Rozmiar newSize)
        {
            _context.Rozmiar.Add(newSize);
            _context.SaveChanges();

            return StatusCode(201, newSize);
        }

        [HttpPut("update")]
        public IActionResult UpdateSize(Rozmiar updatedSize)
        {

            if (_context.Rozmiar.Count(e => e.IdRozmiar == updatedSize.IdRozmiar) == 0)
            {
                return NotFound();
            }

            _context.Rozmiar.Attach(updatedSize);
            _context.Entry(updatedSize).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSize);

        }

        [HttpDelete("delete/{idRozmiar:int}")]
        public IActionResult DeleteSize(int idSize)
        {
            var size = _context.Rozmiar.FirstOrDefault(e => e.IdRozmiar == idSize);
            if (size == null)
            {
                return NotFound();
            }
            _context.Rozmiar.Remove(size);
            _context.SaveChanges();

            return Ok(size);
        }
    }
}
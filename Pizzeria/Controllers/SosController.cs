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
    public class SosController : ControllerBase
    {
        private s16788Context _context;

        public SosController(s16788Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSauces()
        {
            return Ok(_context.Sos.ToList());
        }

        [HttpPost("create")]
        public IActionResult CreateSos(Sos newSauce)
        {
            _context.Sos.Add(newSauce);
            _context.SaveChanges();

            return StatusCode(201, newSauce);
        }

        [HttpPut("update")]
        public IActionResult UpdateSauce(Sos updatedSauce)
        {

            if (_context.Sos.Count(e => e.IdSos == updatedSauce.IdSos) == 0)
            {
                return NotFound();
            }

            _context.Sos.Attach(updatedSauce);
            _context.Entry(updatedSauce).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSauce);

        }

        [HttpDelete("delete/{idSos:int}")]
        public IActionResult DeleteSauce(int idSos)
        {
            var sauce = _context.Sos.FirstOrDefault(e => e.IdSos == idSos);
            if (sauce == null)
            {
                return NotFound();
            }
            _context.Sos.Remove(sauce);
            _context.SaveChanges();

            return Ok(sauce);
        }

    }
}
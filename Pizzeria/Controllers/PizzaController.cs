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
    public class PizzaController : ControllerBase
    {
        private s16788Context _context;
        public PizzaController(s16788Context context)
        {

            _context = context;
        }


        /// <summary>
        /// metoda zwraca dane na temat
        /// </summary>
        /// <returns>
        /// zwraca liste studentow
        /// </returns>


        [HttpGet]
        public IActionResult GetPizzas() 
        {
            return Ok(_context.Pizza.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPizza"></param>
        /// <returns></returns>

        [HttpGet("{idPizza:int}")]
        public IActionResult GetPizza(int idPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == idPizza);
            if (pizza == null) {
                return NotFound(); //404
            }

            return Ok(pizza);
        }

        [HttpPost("create")]
        public IActionResult CreatePizza(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        [HttpPut("update")]
        public IActionResult UpdatePizza(Pizza updatedPizza)
        {

            if (_context.Pizza.Count(e => e.IdPizza == updatedPizza.IdPizza) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);

        }

        [HttpDelete("delete/{idPizza:int}")]
        public IActionResult DeletePizza(int idPizza)
        {
            var pizza= _context.Pizza.FirstOrDefault(e => e.IdPizza == idPizza);
            if (pizza == null)
            {
                return NotFound();
            }
            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/menu/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s16788Context _context;
        public PizzaController(s16788Context context) {

            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas() {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{idPizza:int}")]
        public IActionResult GetPizza(int idPizza) {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == idPizza);
            if (pizza == null) {
                return NotFound(); //404
            }

            return Ok(pizza);
        }
    }
}
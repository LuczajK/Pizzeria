using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO1.Models;

namespace PRO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s18185Context _context;
        public PizzaController(s18185Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getPizza()
        {
            return Ok(_context.pizza);
        }
    }
}
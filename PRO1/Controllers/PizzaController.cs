using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly s18185Context _context;
        public PizzaController(s18185Context context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult getPizza()
        {
            return Ok(_context.PizzaWlasna.ToList());
        }
        [HttpGet("idWlasnejPizzy:int")]
        public IActionResult getPizza(int id)
        {
            var pizza = _context.PizzaWlasna.FirstOrDefault(e => e.IdWlasnejPizzy == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
        [HttpPost]
        public IActionResult Create(PizzaWlasna pizza)
        {
            _context.PizzaWlasna.Add(pizza);
            _context.SaveChanges();
            return StatusCode(201, pizza);
        }
        [HttpPut]
 public IActionResult Update(PizzaWlasna pizza)
        {
            if((_context.PizzaWlasna.Count(e => e.IdWlasnejPizzy == pizza.IdWlasnejPizzy))==0){
                return NotFound();

            }
            _context.PizzaWlasna.Attach(pizza);
            _context.Entry(pizza).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(pizza);
        }
    }
}
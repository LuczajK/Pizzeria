﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        s18185Context _context;
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

    }
}
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
    public class ZamówienieController : ControllerBase
    {
        
            s18185Context _context;
            public ZamówienieController(s18185Context context)
            {
                _context = context;

            }
            [HttpGet]
            public IActionResult getZamówienie()
            {
                return Ok(_context.Zamówienie.ToList());
            }
            [HttpGet("idZamowienia:int")]
            public IActionResult getZamówienie(int idZamowienia)
            {
            var zamowienie = _context.ZamowionePizze.Where(e => e.ZamówienieIdZamowienia == idZamowienia);
                if (zamowienie == null)
                {
                return NotFound();
                }
                return Ok(zamowienie);
            }
        public IActionResult Create(Zamówienie zamowienie)
        {
            _context.Zamówienie.Add(zamowienie);
            _context.SaveChanges();
            return StatusCode(201, zamowienie);
        }
        [HttpPut]
        public IActionResult Update(Zamówienie zamowienie)
        {
            if ((_context.Zamówienie.Count(e => e.IdZamowienia == zamowienie.IdZamowienia)) == 0)
            {
                return NotFound();

            }
            _context.Zamówienie.Attach(zamowienie);
            _context.Entry(zamowienie).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(zamowienie);
        }
    }

}
    }
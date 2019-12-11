using System;
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
   
    }
    }
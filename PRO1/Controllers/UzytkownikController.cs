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
    public class UzytkownikController : ControllerBase
    {

        s18185Context _context;
        public UzytkownikController(s18185Context context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult getUzytkownik()
        {
            return Ok(_context.Użytkownik.ToList());
        }
        [HttpGet("IdUżytkownika:int")]
        public IActionResult getZamówienie(int idUżytkownik)
        {
            var zamowienie = _context.Użytkownik.Where(e => e.IdUżytkownika == idUżytkownik);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return Ok(zamowienie);
        }
        public IActionResult Create(Użytkownik user )
        {
            _context.Użytkownik.Add(user);
            _context.SaveChanges();
            return StatusCode(201, user);
        }
        [HttpPut]
        public IActionResult Update(Użytkownik user)
        {
            if ((_context.Użytkownik.Count(e => e.IdUżytkownika == user.IdUżytkownika)) == 0)
            {
                return NotFound();

            }
            _context.Użytkownik.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(user);
        }
    }

    }

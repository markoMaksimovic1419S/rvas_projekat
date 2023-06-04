using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rvas_projekat.Areas.Identity.Data;
using rvas_projekat.Models;

namespace rvas_projekat.Controllers
{
    public class PorukasController : Controller
    {
        private readonly rvas_projekatContext _context;

        public PorukasController(rvas_projekatContext context)
        {
            _context = context;
        }

        [Authorize]
        public JsonResult PorukaSlanje(string poruka_text, int id_sobe)
        {
            var a = HttpContext.User.Identity.Name;
            var the_user = _context.Users.Where(j => j.Email.Contains(a)).ToList()[0];
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Poruka nova_poruka = new Poruka();
            nova_poruka.poruku_poslao = the_user.ToString();
            nova_poruka.id_sobe = id_sobe;
            nova_poruka.text_poruke = poruka_text;
            _context.Add(nova_poruka);
            _context.SaveChanges();
            return Json(new { Status = "ok", za_sobu_id = id_sobe, poruka = poruka_text, poslao = the_user.ToString() });
        }


        // GET: Porukas
        public async Task<IActionResult> Index()
        {
              return _context.Poruka != null ? 
                          View(await _context.Poruka.ToListAsync()) :
                          Problem("Entity set 'rvas_projekatContext.Poruka'  is null.");
        }



        private bool PorukaExists(int id)
        {
          return (_context.Poruka?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

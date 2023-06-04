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
    public class ChatSobasController : Controller
    {
        private readonly rvas_projekatContext _context;
 
        public ChatSobasController(rvas_projekatContext context)
        {
            _context = context;
        }
 
        // GET: ChatSobas
        public async Task<IActionResult> Index()
        {
              return _context.ChatSoba != null ? 
                          View(await _context.ChatSoba.ToListAsync()) :
                          Problem("Entity set 'rvas_projekatContext.ChatSoba'  is null.");
        }
 
        // GET: ChatSobas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatSoba = await _context.ChatSoba
                .FirstOrDefaultAsync(m => m.id == id);
            if (chatSoba == null)
            {
                return NotFound();
            }

            ViewBag.Message = _context.Poruka.Where(j => j.id_sobe == id).OrderByDescending(s => s.id).ToList();
            return View(chatSoba);
        }
 
        // GET: ChatSobas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: ChatSobas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(string naziv_sobe)
        {
            var a = HttpContext.User.Identity.Name;
            var the_user = _context.Users.Where(j => j.Email.Contains(a)).ToList()[0];
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatSoba chatSoba = new ChatSoba();
            chatSoba.mail_kretora = the_user.ToString();
            chatSoba.naziv_sobe = naziv_sobe;
            _context.Add(chatSoba);
            _context.SaveChanges();
 
            //return naziv_sobe + " || " + the_user;
 
            return RedirectToAction("Details", new { id = chatSoba.id });
        }
 
        private bool ChatSobaExists(int id)
        {
          return (_context.ChatSoba?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
 
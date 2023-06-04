using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChatSoba == null)
            {
                return NotFound();
            }

            var chatSoba = await _context.ChatSoba
                .FirstOrDefaultAsync(m => m.id == id);
            if (chatSoba == null)
            {
                return NotFound();
            }

            return View(chatSoba);
        }

        // GET: ChatSobas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatSobas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naziv_sobe,mail_kretora")] ChatSoba chatSoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatSoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatSoba);
        }

        // GET: ChatSobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChatSoba == null)
            {
                return NotFound();
            }

            var chatSoba = await _context.ChatSoba.FindAsync(id);
            if (chatSoba == null)
            {
                return NotFound();
            }
            return View(chatSoba);
        }

        // POST: ChatSobas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naziv_sobe,mail_kretora")] ChatSoba chatSoba)
        {
            if (id != chatSoba.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatSoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatSobaExists(chatSoba.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chatSoba);
        }

        // GET: ChatSobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChatSoba == null)
            {
                return NotFound();
            }

            var chatSoba = await _context.ChatSoba
                .FirstOrDefaultAsync(m => m.id == id);
            if (chatSoba == null)
            {
                return NotFound();
            }

            return View(chatSoba);
        }

        // POST: ChatSobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChatSoba == null)
            {
                return Problem("Entity set 'rvas_projekatContext.ChatSoba'  is null.");
            }
            var chatSoba = await _context.ChatSoba.FindAsync(id);
            if (chatSoba != null)
            {
                _context.ChatSoba.Remove(chatSoba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatSobaExists(int id)
        {
          return (_context.ChatSoba?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

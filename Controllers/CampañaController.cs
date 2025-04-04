using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_parcia2.Data;
using Examen_parcia2.Models;

namespace Examen_parcia2.Controllers
{
    public class CampañaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampañaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campaña
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaña.ToListAsync());
        }

        // GET: Campaña/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaña = await _context.Campaña
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaña == null)
            {
                return NotFound();
            }

            return View(campaña);
        }

        // GET: Campaña/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaña/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInicio")] Campaña campaña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaña);
        }

        // GET: Campaña/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaña = await _context.Campaña.FindAsync(id);
            if (campaña == null)
            {
                return NotFound();
            }
            return View(campaña);
        }

        // POST: Campaña/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInicio")] Campaña campaña)
        {
            if (id != campaña.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampañaExists(campaña.Id))
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
            return View(campaña);
        }

        // GET: Campaña/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaña = await _context.Campaña
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaña == null)
            {
                return NotFound();
            }

            return View(campaña);
        }

        // POST: Campaña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaña = await _context.Campaña.FindAsync(id);
            if (campaña != null)
            {
                _context.Campaña.Remove(campaña);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampañaExists(int id)
        {
            return _context.Campaña.Any(e => e.Id == id);
        }
    }
}

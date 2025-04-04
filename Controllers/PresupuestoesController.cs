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
    public class PresupuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresupuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Presupuestoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Presupuesto.Include(p => p.Campaña);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Presupuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuesto
                .Include(p => p.Campaña)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            return View(presupuesto);
        }

        // GET: Presupuestoes/Create
        public IActionResult Create()
        {
            ViewData["CampañaId"] = new SelectList(_context.Campaña, "Id", "Nombre");
            return View();
        }

        // POST: Presupuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,CampañaId")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presupuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampañaId"] = new SelectList(_context.Campaña, "Id", "Nombre", presupuesto.CampañaId);
            return View(presupuesto);
        }

        // GET: Presupuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuesto.FindAsync(id);
            if (presupuesto == null)
            {
                return NotFound();
            }
            ViewData["CampañaId"] = new SelectList(_context.Campaña, "Id", "Nombre", presupuesto.CampañaId);
            return View(presupuesto);
        }

        // POST: Presupuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Monto,CampañaId")] Presupuesto presupuesto)
        {
            if (id != presupuesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoExists(presupuesto.Id))
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
            ViewData["CampañaId"] = new SelectList(_context.Campaña, "Id", "Nombre", presupuesto.CampañaId);
            return View(presupuesto);
        }

        // GET: Presupuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuesto
                .Include(p => p.Campaña)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            return View(presupuesto);
        }

        // POST: Presupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuesto = await _context.Presupuesto.FindAsync(id);
            if (presupuesto != null)
            {
                _context.Presupuesto.Remove(presupuesto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoExists(int id)
        {
            return _context.Presupuesto.Any(e => e.Id == id);
        }
    }
}

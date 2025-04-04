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
    public class MetricasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetricasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Metricas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Metrica.Include(m => m.Resultado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Metricas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica
                .Include(m => m.Resultado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrica == null)
            {
                return NotFound();
            }

            return View(metrica);
        }

        // GET: Metricas/Create
        public IActionResult Create()
        {
            ViewData["ResultadoId"] = new SelectList(_context.Set<Resultado>(), "Id", "Descripcion");
            return View();
        }

        // POST: Metricas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Valor,ResultadoId")] Metrica metrica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metrica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResultadoId"] = new SelectList(_context.Set<Resultado>(), "Id", "Descripcion", metrica.ResultadoId);
            return View(metrica);
        }

        // GET: Metricas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica.FindAsync(id);
            if (metrica == null)
            {
                return NotFound();
            }
            ViewData["ResultadoId"] = new SelectList(_context.Set<Resultado>(), "Id", "Descripcion", metrica.ResultadoId);
            return View(metrica);
        }

        // POST: Metricas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Valor,ResultadoId")] Metrica metrica)
        {
            if (id != metrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetricaExists(metrica.Id))
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
            ViewData["ResultadoId"] = new SelectList(_context.Set<Resultado>(), "Id", "Descripcion", metrica.ResultadoId);
            return View(metrica);
        }

        // GET: Metricas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrica = await _context.Metrica
                .Include(m => m.Resultado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrica == null)
            {
                return NotFound();
            }

            return View(metrica);
        }

        // POST: Metricas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metrica = await _context.Metrica.FindAsync(id);
            if (metrica != null)
            {
                _context.Metrica.Remove(metrica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetricaExists(int id)
        {
            return _context.Metrica.Any(e => e.Id == id);
        }
    }
}

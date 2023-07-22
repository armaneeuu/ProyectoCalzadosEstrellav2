using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCalzadosEstrella.Data;
using ProyectoCalzadosEstrella.Models;

namespace ProyectoCalzadosEstrella.Controllers
{
    public class InsumoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsumoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insumo
        public async Task<IActionResult> Index()
        {
              return _context.DataInsumos != null ? 
                          View(await _context.DataInsumos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DataInsumos'  is null.");
        }

        // GET: Insumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataInsumos == null)
            {
                return NotFound();
            }

            var insumo = await _context.DataInsumos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumo == null)
            {
                return NotFound();
            }

            return View(insumo);
        }

        // GET: Insumo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,ImagenName,DueDate,Status,Categoria")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insumo);
        }

        // GET: Insumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataInsumos == null)
            {
                return NotFound();
            }

            var insumo = await _context.DataInsumos.FindAsync(id);
            if (insumo == null)
            {
                return NotFound();
            }
            return View(insumo);
        }

        // POST: Insumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,ImagenName,DueDate,Status,Categoria")] Insumo insumo)
        {
            if (id != insumo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumoExists(insumo.Id))
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
            return View(insumo);
        }

        // GET: Insumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataInsumos == null)
            {
                return NotFound();
            }

            var insumo = await _context.DataInsumos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insumo == null)
            {
                return NotFound();
            }

            return View(insumo);
        }

        // POST: Insumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataInsumos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataInsumos'  is null.");
            }
            var insumo = await _context.DataInsumos.FindAsync(id);
            if (insumo != null)
            {
                _context.DataInsumos.Remove(insumo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumoExists(int id)
        {
          return (_context.DataInsumos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

namespace primerparcial.Controllers
{
    public class CarritoComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarritoCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarritosCompras.ToListAsync());
        }

        // GET: CarritoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritosCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoCompras == null)
            {
                return NotFound();
            }

            return View(carritoCompras);
        }

        // GET: CarritoCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarritoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,FechaCreacion,FechaModificacion")] CarritoCompras carritoCompras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carritoCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carritoCompras);
        }

        // GET: CarritoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritosCompras.FindAsync(id);
            if (carritoCompras == null)
            {
                return NotFound();
            }
            return View(carritoCompras);
        }

        // POST: CarritoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,FechaCreacion,FechaModificacion")] CarritoCompras carritoCompras)
        {
            if (id != carritoCompras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoComprasExists(carritoCompras.Id))
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
            return View(carritoCompras);
        }

        // GET: CarritoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritosCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoCompras == null)
            {
                return NotFound();
            }

            return View(carritoCompras);
        }

        // POST: CarritoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carritoCompras = await _context.CarritosCompras.FindAsync(id);
            if (carritoCompras != null)
            {
                _context.CarritosCompras.Remove(carritoCompras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoComprasExists(int id)
        {
            return _context.CarritosCompras.Any(e => e.Id == id);
        }
    }
}

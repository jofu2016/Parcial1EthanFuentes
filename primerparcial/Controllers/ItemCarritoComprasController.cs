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
    public class ItemCarritoComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemCarritoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemCarritoCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemsCarritoCompras.ToListAsync());
        }

        // GET: ItemCarritoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCarritoCompras = await _context.ItemsCarritoCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCarritoCompras == null)
            {
                return NotFound();
            }

            return View(itemCarritoCompras);
        }

        // GET: ItemCarritoCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCarritoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarritoComprasId,ProductoId,Cantidad,FechaCreacion,FechaModificacion")] ItemCarritoCompras itemCarritoCompras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCarritoCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemCarritoCompras);
        }

        // GET: ItemCarritoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCarritoCompras = await _context.ItemsCarritoCompras.FindAsync(id);
            if (itemCarritoCompras == null)
            {
                return NotFound();
            }
            return View(itemCarritoCompras);
        }

        // POST: ItemCarritoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarritoComprasId,ProductoId,Cantidad,FechaCreacion,FechaModificacion")] ItemCarritoCompras itemCarritoCompras)
        {
            if (id != itemCarritoCompras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCarritoCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCarritoComprasExists(itemCarritoCompras.Id))
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
            return View(itemCarritoCompras);
        }

        // GET: ItemCarritoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCarritoCompras = await _context.ItemsCarritoCompras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCarritoCompras == null)
            {
                return NotFound();
            }

            return View(itemCarritoCompras);
        }

        // POST: ItemCarritoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCarritoCompras = await _context.ItemsCarritoCompras.FindAsync(id);
            if (itemCarritoCompras != null)
            {
                _context.ItemsCarritoCompras.Remove(itemCarritoCompras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCarritoComprasExists(int id)
        {
            return _context.ItemsCarritoCompras.Any(e => e.Id == id);
        }
    }
}

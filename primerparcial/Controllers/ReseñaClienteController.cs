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
    public class ReseñaClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReseñaClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReseñaCliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReseñasClientes.ToListAsync());
        }

        // GET: ReseñaCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñasClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }

            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReseñaCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProductoId,ValorClasificacion,Comentario,FechaCreacion,FechaModificacion")] ReseñaCliente reseñaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseñaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñasClientes.FindAsync(id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }
            return View(reseñaCliente);
        }

        // POST: ReseñaCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProductoId,ValorClasificacion,Comentario,FechaCreacion,FechaModificacion")] ReseñaCliente reseñaCliente)
        {
            if (id != reseñaCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseñaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaClienteExists(reseñaCliente.Id))
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
            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñasClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }

            return View(reseñaCliente);
        }

        // POST: ReseñaCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseñaCliente = await _context.ReseñasClientes.FindAsync(id);
            if (reseñaCliente != null)
            {
                _context.ReseñasClientes.Remove(reseñaCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaClienteExists(int id)
        {
            return _context.ReseñasClientes.Any(e => e.Id == id);
        }
    }
}

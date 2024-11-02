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
    public class DireccionClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DireccionClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DireccionClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DireccionesClientes.ToListAsync());
        }

        // GET: DireccionClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            return View(direccionCliente);
        }

        // GET: DireccionClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DireccionClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,DireccionId,PorDefecto,FechaCreacion,FechaModificacion")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesClientes.FindAsync(id);
            if (direccionCliente == null)
            {
                return NotFound();
            }
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,DireccionId,PorDefecto,FechaCreacion,FechaModificacion")] DireccionCliente direccionCliente)
        {
            if (id != direccionCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionClienteExists(direccionCliente.Id))
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
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCliente = await _context.DireccionesClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            return View(direccionCliente);
        }

        // POST: DireccionClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionCliente = await _context.DireccionesClientes.FindAsync(id);
            if (direccionCliente != null)
            {
                _context.DireccionesClientes.Remove(direccionCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionClienteExists(int id)
        {
            return _context.DireccionesClientes.Any(e => e.Id == id);
        }
    }
}

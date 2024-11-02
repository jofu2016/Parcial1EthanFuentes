using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class DireccionsApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DireccionsApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Direccion>>> GetDirecciones() => await _context.Direcciones.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Direccion>> GetDireccion(int id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion == null) return NotFound();
        return direccion;
    }

    [HttpPost]
    public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
    {
        _context.Direcciones.Add(direccion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDireccion), new { id = direccion.Id }, direccion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDireccion(int id, Direccion direccion)
    {
        if (id != direccion.Id) return BadRequest();
        _context.Entry(direccion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDireccion(int id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion == null) return NotFound();

        _context.Direcciones.Remove(direccion);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Direccion>>> SearchDirecciones(string direccionExacta = "", string codigoPostal = "")
    {
        var query = _context.Direcciones.AsQueryable();

        if (!string.IsNullOrEmpty(direccionExacta))
            query = query.Where(d => d.DireccionExacta.Contains(direccionExacta));
        if (!string.IsNullOrEmpty(codigoPostal))
            query = query.Where(d => d.CodigoPostal.Contains(codigoPostal));

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

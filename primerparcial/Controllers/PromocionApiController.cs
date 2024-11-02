using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class PromocionApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PromocionApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Promocion>>> GetPromociones() => await _context.Promociones.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Promocion>> GetPromocion(int id)
    {
        var promocion = await _context.Promociones.FindAsync(id);
        if (promocion == null) return NotFound();
        return promocion;
    }

    [HttpPost]
    public async Task<ActionResult<Promocion>> PostPromocion(Promocion promocion)
    {
        _context.Promociones.Add(promocion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPromocion), new { id = promocion.Id }, promocion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPromocion(int id, Promocion promocion)
    {
        if (id != promocion.Id) return BadRequest();
        _context.Entry(promocion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePromocion(int id)
    {
        var promocion = await _context.Promociones.FindAsync(id);
        if (promocion == null) return NotFound();

        _context.Promociones.Remove(promocion);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Promocion>>> SearchPromociones(string descripcion = "", decimal? porcentajeDescuento = null, DateTime? fechaInicia = null)
    {
        var query = _context.Promociones.AsQueryable();

        if (!string.IsNullOrEmpty(descripcion))
            query = query.Where(p => p.Descripcion.Contains(descripcion));
        if (porcentajeDescuento.HasValue)
            query = query.Where(p => p.PorcentajeDescuento == porcentajeDescuento);
        if (fechaInicia.HasValue)
            query = query.Where(p => p.FechaInicia >= fechaInicia);

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

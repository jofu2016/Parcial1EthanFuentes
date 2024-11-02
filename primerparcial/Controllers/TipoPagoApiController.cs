using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class TipoPagoApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TipoPagoApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoPago>>> GetTiposPago() => await _context.TiposPago.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoPago>> GetTipoPago(int id)
    {
        var tipoPago = await _context.TiposPago.FindAsync(id);
        if (tipoPago == null) return NotFound();
        return tipoPago;
    }

    [HttpPost]
    public async Task<ActionResult<TipoPago>> PostTipoPago(TipoPago tipoPago)
    {
        _context.TiposPago.Add(tipoPago);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTipoPago), new { id = tipoPago.Id }, tipoPago);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTipoPago(int id, TipoPago tipoPago)
    {
        if (id != tipoPago.Id) return BadRequest();
        _context.Entry(tipoPago).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTipoPago(int id)
    {
        var tipoPago = await _context.TiposPago.FindAsync(id);
        if (tipoPago == null) return NotFound();

        _context.TiposPago.Remove(tipoPago);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<TipoPago>>> SearchTiposPago(string descripcion = "")
    {
        var query = _context.TiposPago.AsQueryable();
        if (!string.IsNullOrEmpty(descripcion))
            query = query.Where(t => t.Descripcion.Contains(descripcion));

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

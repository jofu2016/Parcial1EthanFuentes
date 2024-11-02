using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class ReseñaClienteApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReseñaClienteApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReseñaCliente>>> GetReseñas() => await _context.ReseñasClientes.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ReseñaCliente>> GetReseña(int id)
    {
        var reseña = await _context.ReseñasClientes.FindAsync(id);
        if (reseña == null) return NotFound();
        return reseña;
    }

    [HttpPost]
    public async Task<ActionResult<ReseñaCliente>> PostReseña(ReseñaCliente reseña)
    {
        _context.ReseñasClientes.Add(reseña);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReseña), new { id = reseña.Id }, reseña);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReseña(int id, ReseñaCliente reseña)
    {
        if (id != reseña.Id) return BadRequest();
        _context.Entry(reseña).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReseña(int id)
    {
        var reseña = await _context.ReseñasClientes.FindAsync(id);
        if (reseña == null) return NotFound();

        _context.ReseñasClientes.Remove(reseña);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ReseñaCliente>>> SearchReseñas(int valorClasificacion = -1)
    {
        var query = _context.ReseñasClientes.AsQueryable();
        if (valorClasificacion >= 0)
            query = query.Where(r => r.ValorClasificacion == valorClasificacion);

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

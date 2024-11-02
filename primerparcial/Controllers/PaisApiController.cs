using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class PaisApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaisApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pais>>> GetPaises() => await _context.Paises.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Pais>> GetPais(int id)
    {
        var pais = await _context.Paises.FindAsync(id);
        if (pais == null) return NotFound();
        return pais;
    }

    [HttpPost]
    public async Task<ActionResult<Pais>> PostPais(Pais pais)
    {
        _context.Paises.Add(pais);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPais(int id, Pais pais)
    {
        if (id != pais.Id) return BadRequest();
        _context.Entry(pais).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePais(int id)
    {
        var pais = await _context.Paises.FindAsync(id);
        if (pais == null) return NotFound();

        _context.Paises.Remove(pais);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Pais>>> SearchPaises(string nombre = "")
    {
        var query = _context.Paises.AsQueryable();
        if (!string.IsNullOrEmpty(nombre))
            query = query.Where(p => p.Nombre.Contains(nombre));

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

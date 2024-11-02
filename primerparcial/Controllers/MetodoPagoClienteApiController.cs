using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class MetodoPagoClienteApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MetodoPagoClienteApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MetodoPagoCliente>>> GetMetodosPago() => await _context.MetodosPagoClientes.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<MetodoPagoCliente>> GetMetodoPago(int id)
    {
        var metodoPago = await _context.MetodosPagoClientes.FindAsync(id);
        if (metodoPago == null) return NotFound();
        return metodoPago;
    }

    [HttpPost]
    public async Task<ActionResult<MetodoPagoCliente>> PostMetodoPago(MetodoPagoCliente metodoPago)
    {
        _context.MetodosPagoClientes.Add(metodoPago);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMetodoPago), new { id = metodoPago.Id }, metodoPago);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMetodoPago(int id, MetodoPagoCliente metodoPago)
    {
        if (id != metodoPago.Id) return BadRequest();
        _context.Entry(metodoPago).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMetodoPago(int id)
    {
        var metodoPago = await _context.MetodosPagoClientes.FindAsync(id);
        if (metodoPago == null) return NotFound();

        _context.MetodosPagoClientes.Remove(metodoPago);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<MetodoPagoCliente>>> SearchMetodosPago(string nombreProveedor = "", string cuenta = "", DateTime? fechaExpira = null)
    {
        var query = _context.MetodosPagoClientes.AsQueryable();

        if (!string.IsNullOrEmpty(nombreProveedor))
            query = query.Where(m => m.NombreProveedor.Contains(nombreProveedor));
        if (!string.IsNullOrEmpty(cuenta))
            query = query.Where(m => m.Cuenta.Contains(cuenta));
        if (fechaExpira.HasValue)
            query = query.Where(m => m.FechaExpira == fechaExpira);

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

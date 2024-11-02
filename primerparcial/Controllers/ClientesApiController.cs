using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerparcial.Data;
using primerparcial.Models;

[Route("api/[controller]")]
[ApiController]
public class ClientesApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClientesApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Métodos CRUD para Cliente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes() => await _context.Clientes.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();
        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id || !ModelState.IsValid) return BadRequest();

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Endpoint de búsqueda
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Cliente>>> SearchClientes(string nombre = "", string correo = "")
    {
        var query = _context.Clientes.AsQueryable();

        if (!string.IsNullOrEmpty(nombre)) query = query.Where(c => c.Nombre.Contains(nombre));
        if (!string.IsNullOrEmpty(correo)) query = query.Where(c => c.Correo.Contains(correo));

        var results = await query.ToListAsync();
        return results.Any() ? Ok(results) : NotFound();
    }
}

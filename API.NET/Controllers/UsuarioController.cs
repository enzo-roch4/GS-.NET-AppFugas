using API.NET.Data;
using API.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/usuario/buscar/{id}
    [HttpGet("buscar/{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        return Ok(usuario);
    }

    // POST: api/usuario/cadastrar
    [HttpPost("cadastrar")]
    public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
    {
        if (usuario == null)
            return BadRequest(new { message = "Dados inválidos" });

        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = usuario.id }, usuario);
    }
    // PUT: api/usuario/atualizar/{id}
    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
    {
        if (id != usuario.id)
            return BadRequest(new { message = "ID inconsistente" });

        var usuarioExistente = await _context.Usuario.FindAsync(id);
        if (usuarioExistente == null)
            return NotFound(new { message = "Usuário não encontrado" });

        usuarioExistente.nome = usuario.nome;
        usuarioExistente.cpf = usuario.cpf;
        usuarioExistente.email = usuario.email;
        usuarioExistente.senha = usuario.senha;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/usuario/apagar/{id}
    [HttpDelete("apagar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        _context.Usuario.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário removido com sucesso" });
    }
}

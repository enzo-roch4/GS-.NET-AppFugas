using API.NET.Data;
using API.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PontoRotaController : ControllerBase
{
    private readonly AppDbContext _context;

    public PontoRotaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/PontoRota/buscar
    [HttpGet("buscar")]
    public async Task<ActionResult<IEnumerable<PontoRota>>> Get()
    {
        return await _context.PontoRota.ToListAsync();
    }

    // POST: api/PontoRota/cadastrar
    [HttpPost("cadastrar")]
    public async Task<ActionResult<PontoRota>> Post([FromBody] PontoRota ponto)
    {
        _context.PontoRota.Add(ponto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = ponto.Id }, ponto);
    }

    // PUT: api/PontoRota/atualizar/{id}
    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PontoRota ponto)
    {
        if (id != ponto.Id)
            return BadRequest();

        var pontoExistente = await _context.PontoRota.FindAsync(id);
        if (pontoExistente == null)
            return NotFound();

        pontoExistente.LatitudeA = ponto.LatitudeA;
        pontoExistente.LongitudeA = ponto.LongitudeA;
        pontoExistente.LatitudeB = ponto.LatitudeB;
        pontoExistente.LongitudeB = ponto.LongitudeB;
        pontoExistente.Descricao = ponto.Descricao;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/PontoRota/apagar/{id}
    [HttpDelete("apagar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ponto = await _context.PontoRota.FindAsync(id);
        if (ponto == null)
            return NotFound();

        _context.PontoRota.Remove(ponto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PontoRota>>> Get()
    {
        return await _context.PontoRota.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<PontoRota>> Post([FromBody] PontoRota ponto)
    {
        _context.PontoRota.Add(ponto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = ponto.Id }, ponto);
    }

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
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

using api_rte_technical_evaluation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_rte_technical_evaluation.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> GetusuarioList()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios == null ? NotFound() : Ok(usuarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            var usuarioDb = await _context.Usuarios.FindAsync(id);
            if (usuarioDb == null) return NotFound();

            usuarioDb.Senha = usuario.Senha;
            usuarioDb.Ativo = usuario.Ativo;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
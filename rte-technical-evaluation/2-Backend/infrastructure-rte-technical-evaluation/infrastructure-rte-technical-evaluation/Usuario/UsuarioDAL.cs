using infrastructure_rte_technical_evaluation.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infrastructure_rte_technical_evaluation.Usuario;

public class UsuarioDAL : IUsuarioDAL
{
    #region [ PROPERTIES ]
    private readonly AppDbContext _context;
    #endregion

    #region [ CTOR ]
    public UsuarioDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetUsuario ]
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        return usuario;
    }
    #endregion

    #region [ GetUsuarioList ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetUsuarioList()
    {
        var usuarios = await _context.Usuarios.ToListAsync();

        return usuarios;
    }
    #endregion

    #region [ CreateUsuario ]
    public async Task<bool> CreateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ UpdateUsuario ]
    public async Task<bool> UpdateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var usuarioDb = await _context.Usuarios.FindAsync(usuario.Id);

        if (usuarioDb == null) 
            return false;

        usuarioDb.Senha = usuario.Senha;
        usuarioDb.Ativo = usuario.Ativo;

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion
}
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
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {

        }

        return usuario;
    }
    #endregion

    #region [ GetUsuarioList ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario>> GetUsuarioList()
    {
        var usuarios = await _context.Usuarios.ToListAsync();

        if (usuarios == null)
        {

        }

        return usuarios;
    }
    #endregion
}
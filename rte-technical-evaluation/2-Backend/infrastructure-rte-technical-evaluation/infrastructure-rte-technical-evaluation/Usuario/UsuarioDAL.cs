using infrastructure_rte_technical_evaluation.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shared_rte_technical_evaluation.Models.Authentication;

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

    #region [ GetById ]
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetById(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        return usuario;
    }
    #endregion

    #region [ Authenticate ]
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> Authenticate(AuthenticationModel authenticationModel)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == authenticationModel.Login && u.Senha == authenticationModel.Senha && u.Ativo.Equals(true));

        return usuario;
    }
    #endregion

    #region [ GetAll ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetAll()
    {
        var usuarios = await _context.Usuarios.ToListAsync();

        return usuarios;
    }
    #endregion

    #region [ Create ]
    public async Task<bool> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ Update ]
    public async Task<bool> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var usuarioDb = await _context.Usuarios.FindAsync(usuario.id);

        if (usuarioDb == null) 
            return false;

        usuarioDb.Senha = usuario.Senha;
        usuarioDb.Ativo = usuario.Ativo;

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion
}
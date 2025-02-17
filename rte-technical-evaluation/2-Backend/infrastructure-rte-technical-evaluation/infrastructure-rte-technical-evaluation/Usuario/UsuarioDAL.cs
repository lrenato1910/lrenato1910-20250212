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
    /// <summary>
    /// Inicializa uma nova instância do <see cref="UsuarioDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="context">Contexto do banco de dados.</param>
    public UsuarioDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/> se encontrado, ou null.</returns>
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetById(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        return usuario;
    }
    #endregion

    #region [ Authenticate ]
    /// <summary>
    /// Autentica um usuário com base nas credenciais fornecidas.
    /// </summary>
    /// <param name="authenticationModel">Modelo contendo as informações de autenticação.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/> se a autenticação for bem-sucedida, ou null.</returns>
    public async Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> Authenticate(AuthenticationModel authenticationModel)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Login == authenticationModel.Login && u.Senha == authenticationModel.Senha && u.Ativo);

        return usuario;
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/>.</returns>
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetAll()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return usuarios;
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuario">Dados do usuário a ser criado.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    public async Task<bool> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="usuario">Dados atualizados do usuário.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
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

    #region [ Delete ]
    /// <summary>
    /// Exclui um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser excluído.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    public async Task<bool> Delete(int id)
    {
        var usuarioDb = await _context.Usuarios.FindAsync(id);

        if (usuarioDb == null)
            return false;

        _context.Usuarios.Remove(usuarioDb);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion
}
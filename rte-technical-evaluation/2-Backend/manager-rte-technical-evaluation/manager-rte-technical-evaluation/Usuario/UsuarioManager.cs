using infrastructure_rte_technical_evaluation.Usuario;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Usuario;

public class UsuarioManager : BaseManager, IUsuarioManager
{
    #region [ PROPERTIES ]
    private readonly IUsuarioDAL _usuarioDAL;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="UsuarioManager"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="usuarioDAL">Interface de acesso a dados de usuários.</param>
    public UsuarioManager(IHttpContextAccessor httpContextAccessor, IUsuarioDAL usuarioDAL)
        : base(httpContextAccessor)
    {
        _usuarioDAL = usuarioDAL;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados do usuário encontrado.</returns>
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _usuarioDAL.GetById(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com a lista de usuários.</returns>
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _usuarioDAL.GetAll();
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuario">Dados do usuário a ser criado.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    public async Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.Create(usuario);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="usuario">Dados atualizados do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.Update(usuario);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Delete ]
    /// <summary>
    /// Exclui um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser excluído.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _usuarioDAL.Delete(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
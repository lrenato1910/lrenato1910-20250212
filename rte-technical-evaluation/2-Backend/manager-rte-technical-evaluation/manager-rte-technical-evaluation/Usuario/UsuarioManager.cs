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
    public UsuarioManager(IHttpContextAccessor httpContextAccessor, IUsuarioDAL usuarioDAL)
        : base(httpContextAccessor)
    {
        _usuarioDAL = usuarioDAL;
    }
    #endregion

    #region [ GetUsuario ]
    public async Task<ApiResultModel> GetUsuario(int id)
    {
        var result = await _usuarioDAL.GetUsuario(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetUsuarioList ]
    public async Task<ApiResultModel> GetUsuarioList()
    {
        var result = await _usuarioDAL.GetUsuarioList();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ CreateUsuario ]
    public async Task<ApiResultModel> CreateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.CreateUsuario(usuario);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ UpdateUsuario ]
    public async Task<ApiResultModel> UpdateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.UpdateUsuario(usuario);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
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

    #region [ GetById ]
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _usuarioDAL.GetById(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _usuarioDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Create ]
    public async Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.Create(usuario);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario)
    {
        var result = await _usuarioDAL.Update(usuario);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
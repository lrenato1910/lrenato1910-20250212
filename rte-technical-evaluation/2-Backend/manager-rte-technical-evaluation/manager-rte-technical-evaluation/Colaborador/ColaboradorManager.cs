using infrastructure_rte_technical_evaluation.Colaborador;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public class ColaboradorManager : BaseManager, IColaboradorManager
{
    #region [ PROPERTIES ]
    private readonly IColaboradorDAL _colaboradorDAL;
    #endregion

    #region [ CTOR ]
    public ColaboradorManager(IHttpContextAccessor httpContextAccessor, IColaboradorDAL ColaboradorDAL)
        : base(httpContextAccessor)
    {
        _colaboradorDAL = ColaboradorDAL;
    }
    #endregion

    #region [ GetById ]
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _colaboradorDAL.GetById(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _colaboradorDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Crete ]
    public async Task<ApiResultModel> Crete(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _colaboradorDAL.Crete(colaborador);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _colaboradorDAL.Update(colaborador);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Delete ]
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _colaboradorDAL.Delete(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
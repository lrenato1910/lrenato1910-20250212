using infrastructure_rte_technical_evaluation.Unidade;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Unidade;

public class UnidadeManager : BaseManager, IUnidadeManager
{
    #region [ PROPERTIES ]
    private readonly IUnidadeDAL _UnidadeDAL;
    #endregion

    #region [ CTOR ]
    public UnidadeManager(IHttpContextAccessor httpContextAccessor, IUnidadeDAL UnidadeDAL)
        : base(httpContextAccessor)
    {
        _UnidadeDAL = UnidadeDAL;
    }
    #endregion

    #region [ GetById ]
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _UnidadeDAL.GetById(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _UnidadeDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Crete ]
    public async Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        var result = await _UnidadeDAL.Crete(unidade);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        var result = await _UnidadeDAL.Update(unidade);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Delete ]
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _UnidadeDAL.Delete(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
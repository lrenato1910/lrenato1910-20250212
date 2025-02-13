using infrastructure_rte_technical_evaluation.Colaborador;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public class ColaboradorManager : BaseManager, IColaboradorManager
{
    #region [ PROPERTIES ]
    private readonly IColaboradorDAL _ColaboradorDAL;
    #endregion

    #region [ CTOR ]
    public ColaboradorManager(IHttpContextAccessor httpContextAccessor, IColaboradorDAL ColaboradorDAL)
        : base(httpContextAccessor)
    {
        _ColaboradorDAL = ColaboradorDAL;
    }
    #endregion

    #region [ GetColaborador ]
    public async Task<ApiResultModel> GetColaborador(int id)
    {
        var result = await _ColaboradorDAL.GetColaborador(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetColaboradorList ]
    public async Task<ApiResultModel> GetColaboradorList()
    {
        var result = await _ColaboradorDAL.GetColaboradorList();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ CreateColaborador ]
    public async Task<ApiResultModel> CreateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _ColaboradorDAL.CreateColaborador(colaborador);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ UpdateColaborador ]
    public async Task<ApiResultModel> UpdateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _ColaboradorDAL.UpdateColaborador(colaborador);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
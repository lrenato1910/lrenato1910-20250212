using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public interface IColaboradorManager
{
    Task<ApiResultModel> GetById(int id);
    Task<ApiResultModel> GetAll();
    Task<ApiResultModel> Crete(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<ApiResultModel> Delete(int id);
}
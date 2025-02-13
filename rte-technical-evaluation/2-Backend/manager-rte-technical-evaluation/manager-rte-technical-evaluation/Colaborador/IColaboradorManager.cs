using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public interface IColaboradorManager
{
    Task<ApiResultModel> GetColaborador(int id);
    Task<ApiResultModel> GetColaboradorList();
    Task<ApiResultModel> CreateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<ApiResultModel> UpdateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
}
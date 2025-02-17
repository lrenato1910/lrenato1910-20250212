using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Unidade;

public interface IUnidadeManager
{
    Task<ApiResultModel> GetById(int id);
    Task<ApiResultModel> GetAll();
    Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);
    Task<ApiResultModel> Delete(int id);
}
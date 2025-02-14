using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Usuario;

public interface IUsuarioManager
{
    Task<ApiResultModel> GetById(int id);
    Task<ApiResultModel> GetAll();
    Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<ApiResultModel> Delete(int id);
}
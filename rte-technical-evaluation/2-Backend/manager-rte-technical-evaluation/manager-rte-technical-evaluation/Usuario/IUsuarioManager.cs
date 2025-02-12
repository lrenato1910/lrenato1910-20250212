using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Usuario;

public interface IUsuarioManager
{
    Task<ApiResultModel> GetUsuario(int id);
    Task<ApiResultModel> GetUsuarioList();
    Task<ApiResultModel> CreateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<ApiResultModel> UpdateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
}
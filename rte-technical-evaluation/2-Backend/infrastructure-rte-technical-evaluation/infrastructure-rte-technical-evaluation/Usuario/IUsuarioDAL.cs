using shared_rte_technical_evaluation.Models.System;

namespace infrastructure_rte_technical_evaluation.Usuario;

public interface IUsuarioDAL
{
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetUsuario(int id);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetUsuarioList();
    Task<bool> CreateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<bool> UpdateUsuario(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
}
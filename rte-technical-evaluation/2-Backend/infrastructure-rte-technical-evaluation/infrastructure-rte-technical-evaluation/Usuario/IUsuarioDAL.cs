using shared_rte_technical_evaluation.Models.Authentication;
using shared_rte_technical_evaluation.Models.System;

namespace infrastructure_rte_technical_evaluation.Usuario;

public interface IUsuarioDAL
{
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetById(int id);
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> Authenticate(AuthenticationModel authenticationModel);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetAll();
    Task<bool> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<bool> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);
    Task<bool> Delete(int id);
}
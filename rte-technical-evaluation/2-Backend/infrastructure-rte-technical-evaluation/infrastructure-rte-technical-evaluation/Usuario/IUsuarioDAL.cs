namespace infrastructure_rte_technical_evaluation.Usuario;

public interface IUsuarioDAL
{
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario> GetUsuario(int id);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario>> GetUsuarioList();
}
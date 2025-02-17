using shared_rte_technical_evaluation.Models.Authentication;

namespace infrastructure_rte_technical_evaluation.Usuario;

public interface IUsuarioDAL
{
    /// <summary>
    /// Obtém um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/> se encontrado, ou null.</returns>
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> GetById(int id);

    /// <summary>
    /// Autentica um usuário com base nas credenciais fornecidas.
    /// </summary>
    /// <param name="authenticationModel">Modelo contendo as informações de autenticação.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/> se a autenticação for bem-sucedida, ou null.</returns>
    Task<shared_rte_technical_evaluation.Models.Usuario.Usuario?> Authenticate(AuthenticationModel authenticationModel);

    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Usuario.Usuario"/>.</returns>
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Usuario.Usuario?>> GetAll();

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuario">Dados do usuário a ser criado.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    Task<bool> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);

    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="usuario">Dados atualizados do usuário.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
    Task<bool> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);

    /// <summary>
    /// Exclui um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser excluído.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    Task<bool> Delete(int id);
}
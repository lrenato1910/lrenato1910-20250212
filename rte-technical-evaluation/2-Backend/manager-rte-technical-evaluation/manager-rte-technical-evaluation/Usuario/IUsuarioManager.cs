using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Usuario;

public interface IUsuarioManager
{
    /// <summary>
    /// Obtém um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados do usuário encontrado.</returns>
    Task<ApiResultModel> GetById(int id);

    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com a lista de usuários.</returns>
    Task<ApiResultModel> GetAll();

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuario">Dados do usuário a ser criado.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);

    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="usuario">Dados atualizados do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Usuario.Usuario usuario);

    /// <summary>
    /// Exclui um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser excluído.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    Task<ApiResultModel> Delete(int id);
}
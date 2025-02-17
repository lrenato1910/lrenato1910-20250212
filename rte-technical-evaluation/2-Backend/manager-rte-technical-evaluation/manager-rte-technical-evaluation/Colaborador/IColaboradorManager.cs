using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public interface IColaboradorManager
{
    /// <summary>
    /// Obtém um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados do colaborador encontrado.</returns>
    Task<ApiResultModel> GetById(int id);

    /// <summary>
    /// Obtém todos os colaboradores.
    /// </summary>
    /// <returns>Uma lista de colaboradores encapsulada em um objeto <see cref="ApiResultModel"/>.</returns>
    Task<ApiResultModel> GetAll();

    /// <summary>
    /// Cria um novo colaborador.
    /// </summary>
    /// <param name="colaborador">Dados do colaborador a ser criado.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);

    /// <summary>
    /// Atualiza os dados de um colaborador existente.
    /// </summary>
    /// <param name="colaborador">Dados atualizados do colaborador.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);

    /// <summary>
    /// Exclui um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador a ser excluído.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    Task<ApiResultModel> Delete(int id);
}
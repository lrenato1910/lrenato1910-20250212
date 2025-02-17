using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Unidade;

public interface IUnidadeManager
{
    /// <summary>
    /// Obtém uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados da unidade encontrada.</returns>
    Task<ApiResultModel> GetById(int id);

    /// <summary>
    /// Obtém todas as unidades.
    /// </summary>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com a lista de unidades.</returns>
    Task<ApiResultModel> GetAll();

    /// <summary>
    /// Cria uma nova unidade.
    /// </summary>
    /// <param name="unidade">Dados da unidade a ser criada.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);

    /// <summary>
    /// Atualiza os dados de uma unidade existente.
    /// </summary>
    /// <param name="unidade">Dados atualizados da unidade.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);

    /// <summary>
    /// Exclui uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade a ser excluída.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    Task<ApiResultModel> Delete(int id);
}
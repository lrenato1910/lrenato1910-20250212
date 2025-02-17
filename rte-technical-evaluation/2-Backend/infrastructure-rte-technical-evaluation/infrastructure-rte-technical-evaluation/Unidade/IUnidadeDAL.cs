namespace infrastructure_rte_technical_evaluation.Unidade;

public interface IUnidadeDAL
{
    /// <summary>
    /// Obtém uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Unidade.Unidade"/> se encontrado, ou null.</returns>
    Task<shared_rte_technical_evaluation.Models.Unidade.Unidade?> GetById(int id);

    /// <summary>
    /// Obtém todas as unidades.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Unidade.Unidade"/>.</returns>
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Unidade.Unidade?>> GetAll();

    /// <summary>
    /// Cria uma nova unidade.
    /// </summary>
    /// <param name="unidade">Dados da unidade a ser criada.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    Task<bool> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);

    /// <summary>
    /// Atualiza os dados de uma unidade existente.
    /// </summary>
    /// <param name="unidade">Dados atualizados da unidade.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
    Task<bool> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade);

    /// <summary>
    /// Exclui uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade a ser excluída.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    Task<bool> Delete(int id);
}
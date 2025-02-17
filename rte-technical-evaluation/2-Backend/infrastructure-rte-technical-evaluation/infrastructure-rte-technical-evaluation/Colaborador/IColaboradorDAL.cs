namespace infrastructure_rte_technical_evaluation.Colaborador;

public interface IColaboradorDAL
{
    /// <summary>
    /// Obtém um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Colaborador.Colaborador"/> se encontrado, ou null.</returns>
    Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetById(int id);

    /// <summary>
    /// Obtém todos os colaboradores.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Colaborador.Colaborador"/>.</returns>
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetAll();

    /// <summary>
    /// Cria um novo colaborador.
    /// </summary>
    /// <param name="colaborador">Dados do colaborador a ser criado.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    Task<bool> Create(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);

    /// <summary>
    /// Atualiza os dados de um colaborador existente.
    /// </summary>
    /// <param name="colaborador">Dados atualizados do colaborador.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
    Task<bool> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);

    /// <summary>
    /// Exclui um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador a ser excluído.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    Task<bool> Delete(int id);
}
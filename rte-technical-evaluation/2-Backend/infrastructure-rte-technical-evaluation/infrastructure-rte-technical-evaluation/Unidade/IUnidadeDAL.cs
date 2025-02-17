namespace infrastructure_rte_technical_evaluation.Unidade;

public interface IUnidadeDAL
{
    Task<shared_rte_technical_evaluation.Models.Unidade.Unidade?> GetById(int id);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Unidade.Unidade?>> GetAll();
    Task<bool> Crete(shared_rte_technical_evaluation.Models.Unidade.Unidade Unidade);
    Task<bool> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade Unidade);
    Task<bool> Delete(int id);
}
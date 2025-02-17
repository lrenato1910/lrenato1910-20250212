namespace infrastructure_rte_technical_evaluation.Colaborador;

public interface IColaboradorDAL
{
    Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetById(int id);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetAll();
    Task<bool> Crete(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<bool> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<bool> Delete(int id);
}
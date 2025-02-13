namespace infrastructure_rte_technical_evaluation.Colaborador;

public interface IColaboradorDAL
{
    Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetColaborador(int id);
    Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetColaboradorList();
    Task<bool> CreateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
    Task<bool> UpdateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador);
}
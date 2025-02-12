
namespace shared_rte_technical_evaluation.Models.Colaborador;

public class Colaborador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int UnidadeId { get; set; }
    public Unidade.Unidade Unidade { get; set; }
    public int UsuarioId { get; set; }
    public Usuario.Usuario Usuario { get; set; }
}

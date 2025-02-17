using infrastructure_rte_technical_evaluation.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infrastructure_rte_technical_evaluation.Colaborador;

public class ColaboradorDAL : IColaboradorDAL
{
    #region [ PROPERTIES ]
    private readonly AppDbContext _context;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="ColaboradorDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="context">Contexto do banco de dados.</param>
    public ColaboradorDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Colaborador.Colaborador"/> se encontrado, ou null.</returns>
    public async Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetById(int id)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        return colaborador;
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todos os colaboradores.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Colaborador.Colaborador"/>.</returns>
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetAll()
    {
        var colaboradores = await _context.Colaboradores.ToListAsync();
        return colaboradores;
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria um novo colaborador.
    /// </summary>
    /// <param name="colaborador">Dados do colaborador a ser criado.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    public async Task<bool> Create(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de um colaborador existente.
    /// </summary>
    /// <param name="colaborador">Dados atualizados do colaborador.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
    public async Task<bool> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var colaboradorDb = await _context.Colaboradores.FindAsync(colaborador.Id);

        if (colaboradorDb == null)
            return false;

        colaboradorDb.Nome = colaborador.Nome;
        colaboradorDb.UnidadeId = colaborador.UnidadeId;

        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region [ Delete ]
    /// <summary>
    /// Exclui um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador a ser excluído.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    public async Task<bool> Delete(int id)
    {
        var entityData = await _context.Colaboradores.FindAsync(id);

        if (entityData == null)
            return false;

        _context.Colaboradores.Remove(entityData);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion
}
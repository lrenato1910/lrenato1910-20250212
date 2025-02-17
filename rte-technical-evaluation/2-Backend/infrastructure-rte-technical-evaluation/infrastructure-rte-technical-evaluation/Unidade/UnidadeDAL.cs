using infrastructure_rte_technical_evaluation.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infrastructure_rte_technical_evaluation.Unidade;

public class UnidadeDAL : IUnidadeDAL
{
    #region [ PROPERTIES ]
    private readonly AppDbContext _context;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="UnidadeDAL"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="context">Contexto do banco de dados.</param>
    public UnidadeDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade.</param>
    /// <returns>Um objeto <see cref="shared_rte_technical_evaluation.Models.Unidade.Unidade"/> se encontrado, ou null.</returns>
    public async Task<shared_rte_technical_evaluation.Models.Unidade.Unidade?> GetById(int id)
    {
        var unidade = await _context.Unidades.FindAsync(id);
        return unidade;
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todas as unidades.
    /// </summary>
    /// <returns>Uma coleção de objetos <see cref="shared_rte_technical_evaluation.Models.Unidade.Unidade"/>.</returns>
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Unidade.Unidade?>> GetAll()
    {
        var unidades = await _context.Unidades.ToListAsync();
        return unidades;
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria uma nova unidade.
    /// </summary>
    /// <param name="unidade">Dados da unidade a ser criada.</param>
    /// <returns>Um valor booleano indicando se a operação de criação foi bem-sucedida.</returns>
    public async Task<bool> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        _context.Unidades.Add(unidade);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de uma unidade existente.
    /// </summary>
    /// <param name="unidade">Dados atualizados da unidade.</param>
    /// <returns>Um valor booleano indicando se a operação de atualização foi bem-sucedida.</returns>
    public async Task<bool> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        var unidadeDb = await _context.Unidades.FindAsync(unidade.Id);

        if (unidadeDb == null)
            return false;

        unidadeDb.Nome = unidade.Nome;

        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region [ Delete ]
    /// <summary>
    /// Exclui uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade a ser excluída.</param>
    /// <returns>Um valor booleano indicando se a operação de exclusão foi bem-sucedida.</returns>
    public async Task<bool> Delete(int id)
    {
        var entityData = await _context.Unidades.FindAsync(id);

        if (entityData == null)
            return false;

        _context.Unidades.Remove(entityData);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion
}
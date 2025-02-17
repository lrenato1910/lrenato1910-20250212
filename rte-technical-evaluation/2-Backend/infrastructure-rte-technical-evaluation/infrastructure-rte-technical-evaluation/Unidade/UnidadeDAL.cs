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
    public UnidadeDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetById ]
    public async Task<shared_rte_technical_evaluation.Models.Unidade.Unidade?> GetById(int id)
    {
        var Unidade = await _context.Unidades.FindAsync(id);

        return Unidade;
    }
    #endregion

    #region [ GetAll ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Unidade.Unidade?>> GetAll()
    {
        var Unidadees = await _context.Unidades.ToListAsync();

        return Unidadees;
    }
    #endregion

    #region [ Crete ]
    public async Task<bool> Crete(shared_rte_technical_evaluation.Models.Unidade.Unidade Unidade)
    {
        _context.Unidades.Add(Unidade);

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ Update ]
    public async Task<bool> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade Unidade)
    {
        var UnidadeDb = await _context.Unidades.FindAsync(Unidade.Id);

        if (UnidadeDb == null)
            return false;

        UnidadeDb.Nome = Unidade.Nome;

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ Delete ]
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
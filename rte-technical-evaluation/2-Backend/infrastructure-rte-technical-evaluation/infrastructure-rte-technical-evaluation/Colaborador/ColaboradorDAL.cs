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
    public ColaboradorDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region [ GetById ]
    public async Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetById(int id)
    {
        var Colaborador = await _context.Colaboradores.FindAsync(id);

        return Colaborador;
    }
    #endregion

    #region [ GetAll ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetAll()
    {
        var Colaboradores = await _context.Colaboradores.ToListAsync();

        return Colaboradores;
    }
    #endregion

    #region [ Crete ]
    public async Task<bool> Crete(shared_rte_technical_evaluation.Models.Colaborador.Colaborador Colaborador)
    {
        _context.Colaboradores.Add(Colaborador);

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ Update ]
    public async Task<bool> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador Colaborador)
    {
        var ColaboradorDb = await _context.Colaboradores.FindAsync(Colaborador.Id);

        if (ColaboradorDb == null)
            return false;

        ColaboradorDb.Nome = Colaborador.Nome;
        ColaboradorDb.UnidadeId = Colaborador.UnidadeId;

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ Delete ]
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
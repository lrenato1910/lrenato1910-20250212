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

    #region [ GetColaborador ]
    public async Task<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?> GetColaborador(int id)
    {
        var Colaborador = await _context.Colaboradores.FindAsync(id);

        return Colaborador;
    }
    #endregion

    #region [ GetColaboradorList ]
    public async Task<IEnumerable<shared_rte_technical_evaluation.Models.Colaborador.Colaborador?>> GetColaboradorList()
    {
        var Colaboradores = await _context.Colaboradores.ToListAsync();

        return Colaboradores;
    }
    #endregion

    #region [ CreateColaborador ]
    public async Task<bool> CreateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador Colaborador)
    {
        _context.Colaboradores.Add(Colaborador);

        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region [ UpdateColaborador ]
    public async Task<bool> UpdateColaborador(shared_rte_technical_evaluation.Models.Colaborador.Colaborador Colaborador)
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
}
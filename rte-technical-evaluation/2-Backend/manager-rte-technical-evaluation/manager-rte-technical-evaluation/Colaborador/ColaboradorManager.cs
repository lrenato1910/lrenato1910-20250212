using infrastructure_rte_technical_evaluation.Colaborador;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Colaborador;

public class ColaboradorManager : BaseManager, IColaboradorManager
{
    #region [ PROPERTIES ]
    private readonly IColaboradorDAL _colaboradorDAL;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="ColaboradorManager"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="colaboradorDAL">Interface de acesso a dados de colaboradores.</param>
    public ColaboradorManager(IHttpContextAccessor httpContextAccessor, IColaboradorDAL colaboradorDAL)
        : base(httpContextAccessor)
    {
        _colaboradorDAL = colaboradorDAL;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados do colaborador encontrado.</returns>
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _colaboradorDAL.GetById(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todos os colaboradores.
    /// </summary>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com a lista de colaboradores.</returns>
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _colaboradorDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria um novo colaborador.
    /// </summary>
    /// <param name="colaborador">Dados do colaborador a ser criado.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    public async Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _colaboradorDAL.Create(colaborador);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de um colaborador existente.
    /// </summary>
    /// <param name="colaborador">Dados atualizados do colaborador.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Colaborador.Colaborador colaborador)
    {
        var result = await _colaboradorDAL.Update(colaborador);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Delete ]
    /// <summary>
    /// Exclui um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador a ser excluído.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _colaboradorDAL.Delete(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
using infrastructure_rte_technical_evaluation.Unidade;
using manager_rte_technical_evaluation.Base;
using Microsoft.AspNetCore.Http;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Unidade;

public class UnidadeManager : BaseManager, IUnidadeManager
{
    #region [ PROPERTIES ]
    private readonly IUnidadeDAL _unidadeDAL;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="UnidadeManager"/>.
    /// </summary>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="unidadeDAL">Interface de acesso a dados de unidades.</param>
    public UnidadeManager(IHttpContextAccessor httpContextAccessor, IUnidadeDAL unidadeDAL)
        : base(httpContextAccessor)
    {
        _unidadeDAL = unidadeDAL;
    }
    #endregion

    #region [ GetById ]
    /// <summary>
    /// Obtém uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> contendo os dados da unidade encontrada.</returns>
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _unidadeDAL.GetById(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GetAll ]
    /// <summary>
    /// Obtém todas as unidades.
    /// </summary>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com a lista de unidades.</returns>
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _unidadeDAL.GetAll();
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Cria uma nova unidade.
    /// </summary>
    /// <param name="unidade">Dados da unidade a ser criada.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de criação.</returns>
    public async Task<ApiResultModel> Create(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        var result = await _unidadeDAL.Create(unidade);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Update ]
    /// <summary>
    /// Atualiza os dados de uma unidade existente.
    /// </summary>
    /// <param name="unidade">Dados atualizados da unidade.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de atualização.</returns>
    public async Task<ApiResultModel> Update(shared_rte_technical_evaluation.Models.Unidade.Unidade unidade)
    {
        var result = await _unidadeDAL.Update(unidade);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Delete ]
    /// <summary>
    /// Exclui uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade a ser excluída.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de exclusão.</returns>
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _unidadeDAL.Delete(id);
        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}
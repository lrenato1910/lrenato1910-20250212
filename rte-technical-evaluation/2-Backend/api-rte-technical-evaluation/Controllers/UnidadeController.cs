using manager_rte_technical_evaluation.Unidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Unidade;

namespace api_rte_technical_evaluation.Controllers;

/// <summary>
/// Controlador responsável por gerenciar operações relacionadas a unidades.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UnidadeController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IUnidadeManager _unidadeManager;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do controlador <see cref="UnidadeController"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="environment">Ambiente de hospedagem da aplicação.</param>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="unidadeManager">Serviço de gerenciamento de unidades.</param>
    public UnidadeController([FromServices] IConfiguration configuration,
                             [FromServices] IWebHostEnvironment environment,
                             [FromServices] IHttpContextAccessor httpContextAccessor,
                             [FromServices] IUnidadeManager unidadeManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _unidadeManager = unidadeManager;
    }
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria uma nova unidade.
    /// </summary>
    /// <param name="unidade">Dados da unidade a ser criada.</param>
    /// <returns>Resultado da operação de criação.</returns>
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Unidade unidade)
        => Ok(await _unidadeManager.Create(unidade));
    #endregion

    #region [ GET BY ID ]
    /// <summary>
    /// Obtém uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade.</param>
    /// <returns>Dados da unidade encontrada.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _unidadeManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Obtém todas as unidades.
    /// </summary>
    /// <returns>Lista de unidades.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _unidadeManager.GetAll());
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// Atualiza os dados de uma unidade existente.
    /// </summary>
    /// <param name="unidade">Dados atualizados da unidade.</param>
    /// <returns>Resultado da operação de atualização.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Unidade unidade)
        => Ok(await _unidadeManager.Update(unidade));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Exclui uma unidade pelo seu ID.
    /// </summary>
    /// <param name="id">ID da unidade a ser excluída.</param>
    /// <returns>Resultado da operação de exclusão.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _unidadeManager.Delete(id));
    #endregion
}
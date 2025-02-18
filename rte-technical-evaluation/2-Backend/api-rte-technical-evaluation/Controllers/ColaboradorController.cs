using manager_rte_technical_evaluation.Colaborador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Colaborador;

namespace api_rte_technical_evaluation.Controllers;

/// <summary>
/// Controlador responsável por gerenciar operações relacionadas a colaboradores.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ColaboradorController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IColaboradorManager _colaboradorManager;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do controlador <see cref="ColaboradorController"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="environment">Ambiente de hospedagem da aplicação.</param>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="colaboradorManager">Serviço de gerenciamento de colaboradores.</param>
    public ColaboradorController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IColaboradorManager colaboradorManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _colaboradorManager = colaboradorManager;
    }
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria um novo colaborador.
    /// </summary>
    /// <param name="colaborador">Dados do colaborador a ser criado.</param>
    /// <returns>Resultado da operação de criação.</returns>
    [HttpPost]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Colaborador colaborador)
        => Ok(await _colaboradorManager.Create(colaborador));
    #endregion

    #region [ GETBYID ]
    /// <summary>
    /// Obtém um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador.</param>
    /// <returns>Dados do colaborador encontrado.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _colaboradorManager.GetById(id));
    #endregion

    #region [ GETALL ]
    /// <summary>
    /// Obtém todos os colaboradores.
    /// </summary>
    /// <returns>Lista de colaboradores.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _colaboradorManager.GetAll());
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// Atualiza os dados de um colaborador existente.
    /// </summary>
    /// <param name="colaborador">Dados atualizados do colaborador.</param>
    /// <returns>Resultado da operação de atualização.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Colaborador colaborador)
        => Ok(await _colaboradorManager.Update(colaborador));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Exclui um colaborador pelo seu ID.
    /// </summary>
    /// <param name="id">ID do colaborador a ser excluído.</param>
    /// <returns>Resultado da operação de exclusão.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _colaboradorManager.Delete(id)); 
    #endregion
}
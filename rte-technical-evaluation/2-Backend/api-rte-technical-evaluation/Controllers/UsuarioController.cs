using manager_rte_technical_evaluation.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Usuario;

namespace api_rte_technical_evaluation.Controllers;

/// <summary>
/// Controlador responsável por gerenciar operações relacionadas a usuários.
/// </summary>
[ApiController]
[Route("api/usuarios")]
[Authorize]
public class UsuarioController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IUsuarioManager _usuarioManager;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do controlador <see cref="UsuarioController"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="environment">Ambiente de hospedagem da aplicação.</param>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="usuarioManager">Serviço de gerenciamento de usuários.</param>
    public UsuarioController([FromServices] IConfiguration configuration,
                             [FromServices] IWebHostEnvironment environment,
                             [FromServices] IHttpContextAccessor httpContextAccessor,
                             [FromServices] IUsuarioManager usuarioManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _usuarioManager = usuarioManager;
    }
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="usuario">Dados do usuário a ser criado.</param>
    /// <returns>Resultado da operação de criação.</returns>
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.Create(usuario));
    #endregion

    #region [ GET BY ID ]
    /// <summary>
    /// Obtém um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Dados do usuário encontrado.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _usuarioManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Obtém todos os usuários.
    /// </summary>
    /// <returns>Lista de usuários.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _usuarioManager.GetAll());
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="usuario">Dados atualizados do usuário.</param>
    /// <returns>Resultado da operação de atualização.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.Update(usuario));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Exclui um usuário pelo seu ID.
    /// </summary>
    /// <param name="id">ID do usuário a ser excluído.</param>
    /// <returns>Resultado da operação de exclusão.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _usuarioManager.Delete(id));
    #endregion
}
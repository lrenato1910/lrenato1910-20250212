using manager_rte_technical_evaluation.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Authentication;

namespace api_rte_technical_evaluation.Controllers;

/// <summary>
/// Controlador responsável por lidar com operações de autenticação de usuários.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthenticateController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IAuthenticationService _authenticationService;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do controlador <see cref="AuthenticateController"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="environment">Ambiente de hospedagem da aplicação.</param>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    /// <param name="authenticationService">Serviço de autenticação.</param>
    public AuthenticateController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IAuthenticationService authenticationService)
        : base(configuration, environment, httpContextAccessor)
    {
        _authenticationService = authenticationService;
    }
    #endregion

    #region [ AUTHENTICATE ]
    /// <summary>
    /// Autentica um usuário com base nas credenciais fornecidas.
    /// </summary>
    /// <param name="authenticationModel">Modelo contendo as credenciais do usuário.</param>
    /// <returns>Resultado da autenticação.</returns>
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationModel authenticationModel)
        => Ok(await _authenticationService.Authenticate(authenticationModel));
    #endregion
}
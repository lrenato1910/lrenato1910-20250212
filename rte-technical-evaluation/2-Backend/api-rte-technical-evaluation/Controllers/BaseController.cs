using Microsoft.AspNetCore.Mvc;

namespace api_rte_technical_evaluation.Controllers;

/// <summary>
/// Classe base para controladores, fornecendo propriedades e funcionalidades comuns.
/// </summary>
public class BaseController : ControllerBase
{
    #region [ PROPERTIES ]
    /// <summary>
    /// Obtém as configurações da aplicação.
    /// </summary>
    public readonly IConfiguration _configuration;

    /// <summary>
    /// Obtém o ambiente de hospedagem da aplicação.
    /// </summary>
    public readonly IWebHostEnvironment _environment;

    /// <summary>
    /// Obtém o acesso ao contexto HTTP atual.
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="BaseController"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="environment">Ambiente de hospedagem da aplicação.</param>
    /// <param name="httpContextAccessor">Acesso ao contexto HTTP.</param>
    public BaseController([FromServices] IConfiguration configuration,
                          [FromServices] IWebHostEnvironment environment,
                          [FromServices] IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _environment = environment;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}
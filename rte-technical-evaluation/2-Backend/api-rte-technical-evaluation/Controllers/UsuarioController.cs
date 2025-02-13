using manager_rte_technical_evaluation.Usuario;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Usuario;

namespace api_rte_technical_evaluation.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IUsuarioManager _usuarioManager;
    #endregion

    #region [ CTOR ]
    public UsuarioController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IUsuarioManager usuarioManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _usuarioManager = usuarioManager;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.CreateUsuario(usuario));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(int id)
        => Ok(await _usuarioManager.GetUsuario(id));

    [HttpGet]
    public async Task<IActionResult> GetUsuarioList()
        => Ok(await _usuarioManager.GetUsuarioList());

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.UpdateUsuario(usuario));
}
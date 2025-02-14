using manager_rte_technical_evaluation.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Usuario;

namespace api_rte_technical_evaluation.Controllers;

[ApiController]
[Route("api/usuarios")]
[Authorize]
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

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.Create(usuario));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _usuarioManager.GetById(id));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _usuarioManager.GetAll());

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Usuario usuario)
        => Ok(await _usuarioManager.Update(usuario));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _usuarioManager.Delete(id));
}
using manager_rte_technical_evaluation.Colaborador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Colaborador;

namespace api_rte_technical_evaluation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ColaboradorController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IColaboradorManager _colaboradorManager;
    #endregion

    #region [ CTOR ]
    public ColaboradorController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IColaboradorManager ColaboradorManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _colaboradorManager = ColaboradorManager;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Colaborador Colaborador)
        => Ok(await _colaboradorManager.Crete(Colaborador));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _colaboradorManager.GetById(id));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _colaboradorManager.GetAll());

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Colaborador Colaborador)
        => Ok(await _colaboradorManager.Update(Colaborador));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _colaboradorManager.Delete(id));
}
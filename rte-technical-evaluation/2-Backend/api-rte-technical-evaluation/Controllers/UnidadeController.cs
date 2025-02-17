using manager_rte_technical_evaluation.Unidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Unidade;

namespace api_rte_technical_evaluation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UnidadeController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IUnidadeManager _unidadeManager;
    #endregion

    #region [ CTOR ]
    public UnidadeController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IUnidadeManager unidadeManager)
        : base(configuration, environment, httpContextAccessor)
    {
        _unidadeManager = unidadeManager;
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Unidade Unidade)
        => Ok(await _unidadeManager.Create(Unidade));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _unidadeManager.GetById(id));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _unidadeManager.GetAll());

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Unidade Unidade)
        => Ok(await _unidadeManager.Update(Unidade));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _unidadeManager.Delete(id));
}
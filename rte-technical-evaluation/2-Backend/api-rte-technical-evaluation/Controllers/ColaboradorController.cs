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
    public async Task<IActionResult> CreateColaborador([FromBody] Colaborador Colaborador)
        => Ok(await _colaboradorManager.CreateColaborador(Colaborador));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetColaborador(int id)
        => Ok(await _colaboradorManager.GetColaborador(id));

    [HttpGet]
    public async Task<IActionResult> GetColaboradorList()
        => Ok(await _colaboradorManager.GetColaboradorList());

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateColaborador([FromBody] Colaborador Colaborador)
        => Ok(await _colaboradorManager.UpdateColaborador(Colaborador));
}
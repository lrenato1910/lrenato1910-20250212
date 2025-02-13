using manager_rte_technical_evaluation.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shared_rte_technical_evaluation.Models.Authentication;

namespace api_rte_technical_evaluation.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthenticateController : BaseController
{
    #region [ PROPERTIES ]
    private readonly IAuthenticationService _authenticationService;
    #endregion

    #region [ CTOR ]
    public AuthenticateController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IAuthenticationService authenticationService)
        : base(configuration, environment, httpContextAccessor)
    {
        _authenticationService = authenticationService;
    }
    #endregion

    #region [ METHODS ]
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationModel authenticationModel)
        => Ok(await _authenticationService.Authenticate(authenticationModel));
    #endregion
}
﻿using Microsoft.AspNetCore.Mvc;

namespace api_rte_technical_evaluation.Controllers;

public class BaseController : ControllerBase
{
    #region Properties
    public readonly IConfiguration _configuration;
    public readonly IWebHostEnvironment _environment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Contructor
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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace manager_rte_technical_evaluation.Base;

public class BaseManager
{
    #region Properties
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Claims
    public int? UserId { get; set; }
    #endregion

    #region Contructor
    public BaseManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        ClaimsIdentity identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null && identity.Claims.Count() > 0)
            UserId = identity.FindFirst("UserId") != null ? int.Parse(identity.FindFirst("UserId").Value) : (int?)null;
    }
    #endregion
}
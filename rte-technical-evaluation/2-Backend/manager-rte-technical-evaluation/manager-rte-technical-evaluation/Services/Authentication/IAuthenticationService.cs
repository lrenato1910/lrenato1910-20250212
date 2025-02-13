using shared_rte_technical_evaluation.Models.Authentication;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Services.Authentication;

public interface IAuthenticationService
{
    Task<ApiResultModel> Authenticate(AuthenticationModel authenticationModel);
}
using shared_rte_technical_evaluation.Models.Authentication;
using shared_rte_technical_evaluation.Models.System;

namespace manager_rte_technical_evaluation.Services.Authentication;

public interface IAuthenticationService
{
    /// <summary>
    /// Autentica um usuário com base no modelo de autenticação fornecido.
    /// </summary>
    /// <param name="authenticationModel">Modelo contendo as credenciais do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de autenticação.</returns>
    Task<ApiResultModel> Authenticate(AuthenticationModel authenticationModel);
}
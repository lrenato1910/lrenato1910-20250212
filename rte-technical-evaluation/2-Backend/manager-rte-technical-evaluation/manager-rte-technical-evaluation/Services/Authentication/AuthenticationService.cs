using infrastructure_rte_technical_evaluation.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shared_rte_technical_evaluation.Models.Authentication;
using shared_rte_technical_evaluation.Models.System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace manager_rte_technical_evaluation.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    #region [ PROPERTIES ]
    private readonly IConfiguration _configuration;
    private readonly IUsuarioDAL _usuarioDAL;
    #endregion

    #region [ CTOR ]
    /// <summary>
    /// Inicializa uma nova instância do <see cref="AuthenticationService"/>.
    /// </summary>
    /// <param name="configuration">Configurações da aplicação.</param>
    /// <param name="usuarioDAL">Interface de acesso a dados de usuários.</param>
    public AuthenticationService(IConfiguration configuration, IUsuarioDAL usuarioDAL)
    {
        _configuration = configuration;
        _usuarioDAL = usuarioDAL;
    }
    #endregion

    #region [ Authenticate ]
    /// <summary>
    /// Autentica um usuário com base no modelo de autenticação fornecido.
    /// </summary>
    /// <param name="authenticationModel">Modelo contendo as credenciais do usuário.</param>
    /// <returns>Um objeto <see cref="ApiResultModel"/> com o resultado da operação de autenticação.</returns>
    public async Task<ApiResultModel> Authenticate(AuthenticationModel authenticationModel)
    {
        var isValidUser = await _usuarioDAL.Authenticate(authenticationModel);
        if (isValidUser != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticationModel.Login),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new ApiResultModel().WithSuccess(tokenHandler.WriteToken(token));
        }

        return new ApiResultModel().WithError(new UnauthorizedAccessException("Login/senha inválidos").ToString());
    }
    #endregion
}
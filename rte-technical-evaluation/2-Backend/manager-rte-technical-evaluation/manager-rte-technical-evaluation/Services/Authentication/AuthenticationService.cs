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

    public AuthenticationService(IConfiguration configuration, IUsuarioDAL usuarioDAL)
    {
        _configuration = configuration;
        _usuarioDAL = usuarioDAL;
    }

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
}
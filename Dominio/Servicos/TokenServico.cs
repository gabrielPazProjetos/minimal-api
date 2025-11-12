using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Dominio.ModelViews;

namespace MinimalApi.Dominio.Servicos;

public class TokenServico
{
    private readonly IConfiguration _config;

    public TokenServico(IConfiguration config)
    {
        _config = config;
    }

    public string GerarToken(AdministradorLogado administrador)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, administrador.Email),
            new Claim(ClaimTypes.Role, administrador.Perfil)
        };

        var chave = _config["Jwt:Key"];
        var emissor = _config["Jwt:Issuer"];
        var audiencia = _config["Jwt:Audience"];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: emissor,
            audience: audiencia,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credenciais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

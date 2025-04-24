using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CashFlow.Transaction.Infrastructure.Authentication
{
    public class AuthDecrypt
    {
        public static dynamic DecryptJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                if (tokenHandler.CanReadToken(token))
                {
                    var jwtToken = tokenHandler.ReadJwtToken(token);
                    return JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(jwtToken.Payload));
                }
                throw new SecurityTokenException("Erro ao validar o token.");
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Erro ao validar o token.", ex);
            }
        }
    }
}

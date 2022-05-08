using Microsoft.IdentityModel.Tokens;
using My.Simple.Web.API.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace My.Simple.Web.API.Repository
{
    public class JWTManager : IJWTManager
    {
        private readonly string key;

        public JWTManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string userId, string password)
        {
            //In Real time application user detail should be validate from database
            if (userId != "chakri" && password != "testPwd")
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}

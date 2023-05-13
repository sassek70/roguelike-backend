

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DuckGame.Models.PlayerInfo;
using Microsoft.IdentityModel.Tokens;

namespace DuckGame.Services
{
    public class UserTokenHandler 
    {

        private readonly IConfiguration _config;

        public UserTokenHandler(IConfiguration config)
        {
            _config = config;
        }


        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
                {
                    // new Claim(ClaimTypes.Name, user.UserName)    
                    {new Claim("UserName", user.UserName)}
                };

            // key used to create & verify the JWT
            //  "SystemSecurityKey" is from: dotnet add package Microsoft.IdentityModel.Tokens
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("JwtSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: cred,
                issuer: _config.GetSection("JwtSettings:Issuer").Value!,
                audience: _config.GetSection("JwtSettings:Audience").Value!
            );

            //Create the JWT to be sent back.
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string? ValidateToken(string token)
        {
            if (token == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetSection("JwtSettings:Token").Value!);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var tokenUser = jwtToken.Claims.First(claim => claim.Type == "UserName").Value;

                return tokenUser;
            }
            catch
            {
                string expired = "Token expired, please log in again";
                return expired;
            }
        }
    }
}
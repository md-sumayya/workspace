using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnetCommonUtils.Helpers
{
    public static class TokenHelper
    {
        private static string secret = "this_secret_key_encrypts_the_token_string";
        public static string GenerateToken(string userName,string email,string role){
            byte[] byteKey = Encoding.UTF8.GetBytes(secret);
            var securityKey = new SymmetricSecurityKey(byteKey);
            var signingCreds = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
            var descriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Role, role)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCreds,
                Issuer = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io",
                Audience = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io"
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
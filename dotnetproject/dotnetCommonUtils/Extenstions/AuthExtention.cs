using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace dotnetCommonUtils.Extenstions
{
    public static class AuthExtention
    {
        public static void AddCustomAuthentication(this IServiceCollection services){
            services.AddAuthentication(option=>{
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>{
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_secret_key_encrypts_the_token_string")),
                    ValidIssuer = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io",
                    ValidAudience = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io"
                };
            });
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using dotnetapiapp.Models;
using System.Text;
using dotnetapiapp.Domain;
using dotnetapiapp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            }
        },
        new List<string>()
        }
    });
});
builder.Services.AddDbContext<OrderDeliveryDbContext>(options =>
    {
    var connectionString = builder.Configuration.GetConnectionString("OrderDB");
    options.UseSqlServer(connectionString);
    });

builder.Services.AddAuthentication(option=>{
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

builder.Services.AddScoped<IAccountProcessor,AccountProcessor>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using DuckGame.Data;
using DuckGame.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac;
using DuckGame.Services;

var builder = WebApplication.CreateBuilder(args);
var containerBuilder = new ContainerBuilder();

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors((options) => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins, (corsBuilder) => 
        {
            /* 
                Setting CORS policy for development

                default localhost ports:
                    Angular.JS - 4200
                    React.JS - 3000
                    Vue.JS - 8000
            */ 
            corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000", "http://localhost:").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });

        options.AddPolicy(name: MyAllowSpecificOrigins, (corsBuilder) => 
            {
                /* 
                    Setting CORS policy for product, this gets modified to match production url & needs.

                    default localhost ports:
                        Angular.JS - 4200
                        React.JS - 3000
                        Vue.JS - 8000
                */ 
                corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
});

var tokenCreation = new UserTokenHandler();
containerBuilder.RegisterInstance(tokenCreation).As<UserTokenHandler>();

// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
// enables JWT use.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => 
        {
            // TokenValidationParamter class comes from: using Microsoft.IdentityModel.Tokens
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("JwtSettings:Token").Value!))
            };
        });



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContextEntity>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     SeedData.Initialize(services);
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

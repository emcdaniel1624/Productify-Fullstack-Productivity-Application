using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Productify.API.Data.Provider;
using Productify.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

var connectionString = builder.Configuration.GetValue<string>("Database:ConnectionString");
var databaseName = builder.Configuration.GetValue<string>("Database:DatabaseName");

builder.Services.AddNoSqlProviderFactory<ProductifyProvider>(
    (builder) => builder.UseMongo(connectionString, databaseName), 
    ServiceLifetime.Transient
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductifyAPI", Version = "v1" });
    x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "OAuth2.0 Auth Code",
        Name = "oauth2",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["Swagger:AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["Swagger:TokenUrl"]),
                Scopes = new Dictionary<string, string>
                {
                    { builder.Configuration["Swagger:Scope"], "read the api" }
                }
            }
        }
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme, 
                    Id = "oauth2" 
                },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
            },
            new[] { builder.Configuration["Swagger:Scope"] }
        }
    });
});

var app = builder.Build();
    
app.UseSwagger();
app.UseSwaggerUI(x => 
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "YouAPI v1");
    x.OAuthClientId(builder.Configuration["Swagger:ClientId"]);
    x.OAuthUseBasicAuthenticationWithAccessCodeGrant();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

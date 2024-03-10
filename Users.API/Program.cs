using Common.Middleware;
using Common.PolicyExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Users.API.Helpers;
using Users.API.Models.Database;
using Users.API.Models.Entities;
using Users.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.GetPolicyForCors(5001);
                      });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddLogging();

builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

var authSettingsSection = builder.Configuration.GetSection("Authentication");
builder.Services.Configure<AuthSettings>(authSettingsSection);
var authSettings = authSettingsSection.Get<AuthSettings>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = "Bearer";
    x.DefaultScheme = "Bearer";
    x.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(config =>
{
    config.SaveToken = true;
    config.RequireHttpsMetadata = false;
    config.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = authSettings.JwtIssuer,
        ValidAudience = authSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtKey))
    };
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FitFrontier API",
        Version = "v1",
    });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter your token in the text input below.
                      Example: '12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
            new List<string>()
        }
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();

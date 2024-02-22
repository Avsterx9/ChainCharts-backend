using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Users.API.Models.Database;
using Users.API.Models.Entities;
using Users.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gymapp API",
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

app.UseAuthorization();

app.MapControllers();

app.Run();

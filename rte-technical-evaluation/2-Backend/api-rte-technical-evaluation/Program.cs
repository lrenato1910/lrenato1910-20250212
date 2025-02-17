using api_rte_technical_evaluation.Middleware;
using infrastructure_rte_technical_evaluation.Colaborador;
using infrastructure_rte_technical_evaluation.Context;
using infrastructure_rte_technical_evaluation.Unidade;
using infrastructure_rte_technical_evaluation.Usuario;
using manager_rte_technical_evaluation.Colaborador;
using manager_rte_technical_evaluation.Services.Authentication;
using manager_rte_technical_evaluation.Unidade;
using manager_rte_technical_evaluation.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api-rte-technical-evaluation", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato **Bearer {token}**"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddTransient<IUsuarioManager, UsuarioManager>();

builder.Services.AddTransient<IColaboradorManager, ColaboradorManager>();

builder.Services.AddTransient<IUnidadeManager, UnidadeManager>();

builder.Services.AddTransient<IUsuarioDAL, UsuarioDAL>();

builder.Services.AddTransient<IColaboradorDAL, ColaboradorDAL>();

builder.Services.AddTransient<IUnidadeDAL, UnidadeDAL>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});


var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("AllowAllOrigins");

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
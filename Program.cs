using ExoApi.Contexts;
using ExoApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.C
builder.Services.AddScoped<ExoApiContext, ExoApiContext>();  // config servico contexto
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>(); // config servico repository
builder.Services.AddTransient<AtividadeRepository, AtividadeRepository>();
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionado serviço de JWT para autenticação.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme    = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         // Valida quem esta solicitando o acesso. Valida o usuário que está tentando acesso.
         ValidateIssuer = true,
         // Valida quem está recebendo o acesso. 
         ValidateAudience = true,
         // Define se o tempo de expiração será validado.
         ValidateLifetime = true,
         // Forma de criptografia e ainda valida a chave de autenticacao.
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-key-raf113312")),
         // Forma e valor de expiração do Token.
         ClockSkew = TimeSpan.FromMinutes(10),
         // Nome do Issuer de onde está vindo.
         ValidIssuer = "ExoApi",
         // Nome do Audience para onde está indo.
         ValidAudience = "ExoApi"
     };
 });

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

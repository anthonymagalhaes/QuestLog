using QuestLog.Data;
using QuestLog.Mapping;
using QuestLog.Model;
using QuestLog.Repository;
using QuestLog.Services;
using QuestLog.Services.Noticia;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AuthDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
builder.Services.AddAuthorization();
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<NoticiaMapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<INoticiaService, NoticiaService>();
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
    
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
    policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();

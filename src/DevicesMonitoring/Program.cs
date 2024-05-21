using DevicesMonitoring.Contracts;
using DevicesMonitoring.filters;
using DevicesMonitoring.Repositories;
using DevicesMonitoring.Repositories.dataAccess;
using DevicesMonitoring.Services.jwtToken;
using DevicesMonitoring.Services.LoggedUser;
using DevicesMonitoring.useCases.CreateDevice;
using DevicesMonitoring.useCases.CreateUser;
using DevicesMonitoring.useCases.Loggin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IloggedUser, LoggedUser>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<CreateDeviceUseCase>();
builder.Services.AddScoped<ListDeviceUseCase>();
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<DevicesMonitoring.Services.jwtToken.JwtSettings>();
builder.Services.AddSingleton<JwtToken>(new JwtToken(jwtSettings.SecretKey, jwtSettings.Issuer, jwtSettings.Audience));
builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey))
        };
    });
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddScoped<LogginUseCase>();
builder.Services.AddScoped<Database>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<Database>();
    database.main(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using DevicesMonitoring.Contracts;
using DevicesMonitoring.Infra.database;
using DevicesMonitoring.Repositories;
using DevicesMonitoring.Repositories.dataAccess;
using DevicesMonitoring.useCases.CreateUser;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<CreateUserUseCase>();

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

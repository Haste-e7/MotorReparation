using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotorReparation.Application.Contracts;
using MotorReparation.Application.Persistence;
using MotorReparation.Application.Services;
using MotorReparation.Domain;
using MotorReparation.Infrastructure;
using MotorReparation.Infrastructure.Persistence;
using MotorReparation.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MotorReparationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddDbContext<MotorReparationDbContext>(options =>
{
    string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connStr);
});

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

//repo
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//service
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IBasketService, BasketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<MotorReparationDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var logger = services.GetRequiredService<ILogger<Program>>();
    await context.Database.MigrateAsync();
    await SeedDb.SeedData(context, userManager, roleManager);
    logger.LogInformation("=================> Seeding completed");
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "===========> An error occured during migration");
}

app.Run();

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sessionTen.App.Application;
using sessionTen.App.Infrastructure.Data;
using sessionTen.App.Infrastructure.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
builder.Services.AddScoped<IBus, RabbitmqBus>();
builder.Services.AddScoped<IDatabase, MssqlDatabase>();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        var connectionStr = builder.Configuration.GetConnectionString("dbConnection");
        options.UseSqlServer(connectionStr);
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPut("/users/{id}", async ([FromRoute] int id,
        [FromBody] ChangeUserEmailRequest request,
        [FromServices] IUserService service) =>
    {
        request.Id = id;
        await service.ChangeEmail(request);
        return Results.NoContent();
    })
    .WithName("change-user-email")
    .WithOpenApi();

await app.RunAsync();
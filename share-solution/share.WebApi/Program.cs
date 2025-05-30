using Microsoft.EntityFrameworkCore;
using share.Application.Interfaces;
using share.Infrastructure;
using share.Infrastructure.EFCore.DBContext;
using share.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);


// add dbconfig
builder.Services.AddShareDbContext(builder.Configuration);
// Add services to the container.

builder.Services.AddScoped<ILogQueue, LogQueue>();
builder.Services.AddHostedService<LogBackgroundService>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply pending migrations and update database automatic
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ShareDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using template_service;
using template_service.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
var context = serviceScope!.ServiceProvider.GetRequiredService<TemplateDbContext>();
await context.Database.MigrateAsync();

app.Run();

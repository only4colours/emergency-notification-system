using Microsoft.EntityFrameworkCore;
using notification_service;
using notification_service.Database;
using notification_service.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("notifications").MapNotifications();

using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
var context = serviceScope!.ServiceProvider.GetRequiredService<NotificationDbContext>();
await context.Database.MigrateAsync();

app.Run();
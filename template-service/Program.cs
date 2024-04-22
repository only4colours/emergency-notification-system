using template_service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();

app.Run();

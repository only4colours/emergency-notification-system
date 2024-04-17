using Microsoft.AspNetCore.Mvc;
using notification_service;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
var app = builder.Build();

app.MapPost("/send", ([FromBody] string text) =>
{
    var messageOptions = new CreateMessageOptions(
        new PhoneNumber("+380674200517"))
    {
        From = new PhoneNumber("+12096617773"),
        Body = text
    };

    var message = MessageResource.Create(messageOptions);
    Console.WriteLine(message.Status);
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
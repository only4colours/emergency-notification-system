using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace notification_service.Endpoints;

public static class NotificationsEndpoint
{
    public static void MapNotifications(this RouteGroupBuilder app)
    {
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
    }
}
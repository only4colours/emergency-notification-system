using Microsoft.AspNetCore.Mvc;
using recipient_service.Database.Entities;
using recipient_service.Database.Repositories;

namespace recipient_service.Endpoints;

public static class RecipientsEndpoint
{
    public static void MapRecipients(this RouteGroupBuilder app)
    {
        app.MapPost("/", async (
            [FromServices] IRecipientsRepository recipientsRepository,
            [FromBody] Recipient recipient) =>
        {
            await recipientsRepository.AddAsync(recipient);
        });

        app.MapGet("/{id:guid}", async (
            [FromServices] IRecipientsRepository recipientsRepository,
            [FromRoute] Guid id) =>
        {
            var recipient = await recipientsRepository.GetByIdAsync(id);

            return recipient is null ? Results.NotFound("Recipient wasn't found") : Results.Ok(recipient);
        });

        app.MapPut("/{id:guid}", async ( //TODO: If edited field is only one, request will cause unnecessary calls to db to change fields that haven't been changed in request's body
            [FromServices] IRecipientsRepository recipientsRepository,
            [FromRoute] Guid id,
            [FromBody] Recipient recipient) =>
        {
            var editedRecipient = await recipientsRepository.EditByIdAsync(id, recipient.PhoneNumber); //TODO: Don't like variable name
            
            return editedRecipient is null ? Results.NotFound("Recipient wasn't found") : Results.Ok(editedRecipient);
        });

        app.MapDelete("/{id:guid}", async (
            [FromServices] IRecipientsRepository recipientsRepository,
            [FromRoute] Guid id) =>
        {
            var recipient = await recipientsRepository.DeleteByIdAsync(id);

            return recipient is null ? Results.NotFound("Recipient wasn't found") : Results.Ok(recipient);
        });
    }
}
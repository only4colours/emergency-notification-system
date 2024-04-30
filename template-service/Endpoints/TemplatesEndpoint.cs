using Microsoft.AspNetCore.Mvc;
using template_service.Database.Entities;
using template_service.Database.Repositories;

namespace template_service.Endpoints;

public static class TemplatesEndpoint
{
    public static void MapTemplates(this RouteGroupBuilder app)
    {
        app.MapPost("/", async (
            [FromServices] ITemplatesRepository templatesRepository, 
            [FromBody] Template template) =>
        {
            await templatesRepository.AddAsync(template);
        });

        app.MapGet("/{id:guid}", async (
            [FromServices] ITemplatesRepository templatesRepository,
            [FromRoute] Guid id) =>
        {
            var template = await templatesRepository.GetByIdAsync(id);
            
            return template is null ? Results.NotFound("Template wasn't found") : Results.Ok(template);
        });

        app.MapPut("/{id:guid}", async ( //TODO: If edited field is only one, request will cause unnecessary calls to db to change fields that haven't been changed in request's body
            [FromServices] ITemplatesRepository templatesRepository,
            [FromRoute] Guid id,
            [FromBody] Template template) =>
        {
            var editedTemplate = await templatesRepository.EditByIdAsync(id, template.Title, template.Content); //TODO: Don't like variable name
            
            return editedTemplate is null ? Results.NotFound("Template wasn't found") : Results.Ok(editedTemplate);
        });
        
        app.MapDelete("/{id:guid}", async (
            [FromServices] ITemplatesRepository templatesRepository,
            [FromRoute] Guid id) =>
        {
            var template = await templatesRepository.DeleteByIdAsync(id);
            
            return template is null ? Results.NotFound("Template wasn't found") : Results.Ok(template);
        });
    }
}
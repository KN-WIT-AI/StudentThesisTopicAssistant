using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme.Contract;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme;

internal record GenerateThemeRequest(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes);

internal record GenerateThemeResponse(
    List<PhraseQuality> Themes);

internal static class GenerateThemeEndpoint
{
    public static void MapGenerateThemeEndpoint(this WebApplication app)
    {
        app.MapPost("/api/theme/generate", async (
            [FromServices] IMediator mediator,
            [FromBody] GenerateThemeRequest request) =>
        {
            var result = await mediator.Send(new GenerateThemeQuery(
                request.FieldOfStudy,
                request.Degree,
                request.AlreadySelectedThemes));

            var response = new GenerateThemeResponse(result);

            return Results.Ok(response);
        });
    }
}

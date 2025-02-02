using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;

internal record GenerateThemesRequest(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes);

internal record GenerateThemesResponse(
    List<PhraseQuality> Themes);

internal static class GenerateThemesEndpoint
{
    public static void MapGenerateThemesEndpoint(this WebApplication app)
    {
        app.MapPost("/api/themes/generate", async (
            [FromServices] IMediator mediator,
            [FromBody] GenerateThemesRequest request) =>
        {
            var result = await mediator.Send(new GenerateThemesQuery(
                request.FieldOfStudy,
                request.Degree,
                request.AlreadySelectedThemes));

            var response = new GenerateThemesResponse(result);

            return Results.Ok(response);
        });
    }
}

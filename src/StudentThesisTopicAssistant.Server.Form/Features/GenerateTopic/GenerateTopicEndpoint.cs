using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic.Contract;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic;

internal record GenerateTopicRequest(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes);

internal record GenerateTopicResponse(
    List<PhraseQuality> Themes);

internal static class GenerateTopicEndpoint
{
    public static void MapGenerateTopicEndpoint(this WebApplication app)
    {
        app.MapPost("/api/topic/generate", async (
            [FromServices] IMediator mediator,
            [FromBody] GenerateTopicRequest request) =>
        {
            var result = await mediator.Send(new GenerateTopicQuery(
                request.FieldOfStudy,
                request.Degree,
                request.AlreadySelectedThemes));

            var response = new GenerateTopicResponse(result);

            return Results.Ok(response);
        });
    }
}
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;

internal record GenerateTopicsRequest(
    string FieldOfStudy,
    string Degree,
    List<string> SelectedThemes);

internal record GenerateTopicsResponse(
    List<Topic> Topics);

internal static class GenerateTopicsEndpoint
{
    public static void MapGenerateTopicsEndpoint(this WebApplication app)
    {
        app.MapPost("/api/topics/generate", async (
            [FromServices] IMediator mediator,
            [FromBody] GenerateTopicsRequest request) =>
        {
            var result = await mediator.Send(new GenerateTopicsQuery(
                request.FieldOfStudy,
                request.Degree,
                request.SelectedThemes));

            var response = new GenerateTopicsResponse(result);

            return Results.Ok(response);
        });
    }
}
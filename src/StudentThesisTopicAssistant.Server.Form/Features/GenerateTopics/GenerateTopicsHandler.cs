using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;

internal class GenerateTopicsHandler(ITopicGenerator topicGenerator) : IRequestHandler<GenerateTopicsQuery, List<Topic>>
{
    public async Task<List<Topic>> Handle(GenerateTopicsQuery request, CancellationToken cancellationToken)
    {
        var result = await topicGenerator.Generate(
            request.Degree,
            request.FieldOfStudy,
            request.AlreadySelectedThemes);

        return result
            .OrderByDescending(x => x.Quality)
            .Take(8)
            .ToList();
    }
}

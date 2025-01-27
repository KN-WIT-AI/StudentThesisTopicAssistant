using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic.Contract;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic;

internal class GenerateTopicHandler(ITopicGenerator topicGenerator) : IRequestHandler<GenerateTopicQuery, List<PhraseQuality>>
{
    public async Task<List<PhraseQuality>> Handle(GenerateTopicQuery request, CancellationToken cancellationToken)
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

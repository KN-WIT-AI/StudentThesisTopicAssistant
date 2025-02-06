using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;

internal class GenerateTopicsHandler(ITopicGenerator topicGenerator) : IRequestHandler<GenerateTopicsQuery, List<Topic>>
{
    public async Task<List<Topic>> Handle(GenerateTopicsQuery request, CancellationToken cancellationToken)
    {
        return await topicGenerator.Generate(
            request.Degree,
            request.FieldOfStudy,
            request.AlreadySelectedThemes);
    }
}

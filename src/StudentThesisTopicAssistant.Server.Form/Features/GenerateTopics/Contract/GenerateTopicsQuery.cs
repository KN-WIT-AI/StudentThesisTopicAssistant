using MediatR;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

public record GenerateTopicsQuery(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes) : IRequest<List<Topic>>;

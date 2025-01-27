using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic.Contract;

public record GenerateTopicQuery(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes) : IRequest<List<PhraseQuality>>;

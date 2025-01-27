using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme.Contract;

public record GenerateThemeQuery(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes) : IRequest<List<PhraseQuality>>;

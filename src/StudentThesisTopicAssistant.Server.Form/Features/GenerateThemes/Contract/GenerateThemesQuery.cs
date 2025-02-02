using MediatR;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

public record GenerateThemesQuery(
    string FieldOfStudy,
    string Degree,
    List<string> AlreadySelectedThemes) : IRequest<List<PhraseQuality>>;

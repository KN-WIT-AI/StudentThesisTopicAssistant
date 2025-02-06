using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;

internal class GenerateThemesHandler(IThemeGenerator themeGenerator) : IRequestHandler<GenerateThemesQuery, List<PhraseQuality>>
{
    public async Task<List<PhraseQuality>> Handle(GenerateThemesQuery request, CancellationToken cancellationToken)
    {
        return await themeGenerator.Generate(
            request.Degree,
            request.FieldOfStudy,
            request.AlreadySelectedThemes);
    }
}

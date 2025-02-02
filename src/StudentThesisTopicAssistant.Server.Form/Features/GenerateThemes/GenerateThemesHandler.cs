using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;

internal class GenerateThemesHandler(IThemeGenerator themeGenerator) : IRequestHandler<GenerateThemesQuery, List<PhraseQuality>>
{
    public async Task<List<PhraseQuality>> Handle(GenerateThemesQuery request, CancellationToken cancellationToken)
    {
        var result = await themeGenerator.Generate(
            request.Degree,
            request.FieldOfStudy,
            request.AlreadySelectedThemes);

        return result
            .OrderByDescending(x => x.Quality)
            .Take(8)
            .ToList();
    }
}

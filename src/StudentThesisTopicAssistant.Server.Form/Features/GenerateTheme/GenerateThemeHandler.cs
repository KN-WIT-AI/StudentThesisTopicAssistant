using MediatR;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme.Contract;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme;

internal class GenerateThemeHandler(IThemeGenerator themeGenerator) : IRequestHandler<GenerateThemeQuery, List<PhraseQuality>>
{
    public async Task<List<PhraseQuality>> Handle(GenerateThemeQuery request, CancellationToken cancellationToken)
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

using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme;

public interface IThemeGenerator
{
    Task<List<PhraseQuality>> Generate(string fieldOfStudy, string degree, List<string> alreadySelectedThemes);
}

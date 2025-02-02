using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;

public interface IThemeGenerator
{
    Task<List<PhraseQuality>> Generate(string fieldOfStudy, string degree, List<string> alreadySelectedThemes);
}

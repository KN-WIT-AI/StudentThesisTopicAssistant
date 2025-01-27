using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic;

public interface ITopicGenerator
{
    Task<List<PhraseQuality>> Generate(string degree, string fieldOfStudy, List<string> alreadySelectedThemes);
}

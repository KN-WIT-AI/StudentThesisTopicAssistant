using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;

public interface ITopicGenerator
{
    Task<List<Topic>> Generate(string degree, string fieldOfStudy, List<string> selectedThemes);
}

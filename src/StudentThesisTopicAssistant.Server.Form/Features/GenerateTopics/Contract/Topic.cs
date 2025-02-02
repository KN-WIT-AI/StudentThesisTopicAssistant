namespace StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

public record Topic(string Title, int Quality, string Description, List<string> Sections);

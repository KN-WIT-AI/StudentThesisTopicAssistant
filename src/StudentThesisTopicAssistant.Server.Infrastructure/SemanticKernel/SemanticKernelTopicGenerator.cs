using Microsoft.SemanticKernel.ChatCompletion;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic;
using StudentThesisTopicAssistant.Server.Form.Features.Shared;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal class SemanticKernelTopicGenerator(ILLMChat llmChat) : ITopicGenerator
{
    public async Task<List<PhraseQuality>> Generate(string degree, string fieldOfStudy, List<string> alreadySelectedThemes)
    {
        const string prompt =
            """
            Zaproponuj prosze listę tematów pracy dyplomowej wraz z poziomem dopasowania od 0 do 100 na podstawie nazwy kierunku, stopnia oraz listy zainteresowań studenta.
            Unikaj powtażania słów podanych na wejściu.
            Zwróć listę tematów w formacie JSON!!! np:
            [
                {
                    "Phrase": "słowo1",
                    "Quality": 10
                },
                {
                    "Phrase": "słowo2",
                    "Quality": 20
                },
                {
                    "Phrase": "słowo2",
                    "Quality": 30
                }
            ].
            Proszę nie zwracaj Markdown.
            """;

        var chatHistory = new ChatHistory();
        chatHistory.AddSystemMessage(prompt);
        chatHistory.AddUserMessage($"Kierunek: {fieldOfStudy}");
        chatHistory.AddUserMessage($"Poziom studiów: {degree}");
        chatHistory.AddUserMessage($"Wybrane obszary użytkownika: [{string.Join(", ", alreadySelectedThemes)}]");

        return await llmChat.Complete<List<PhraseQuality>>(chatHistory);
    }
}

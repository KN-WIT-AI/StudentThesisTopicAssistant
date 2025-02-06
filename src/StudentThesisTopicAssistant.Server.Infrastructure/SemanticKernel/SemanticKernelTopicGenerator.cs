using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal class SemanticKernelTopicGenerator(ILLMTextCompletion llmTextCompletion) : ITopicGenerator
{
    public Task<List<Topic>> Generate(string degree, string fieldOfStudy, List<string> selectedThemes)
    {
        var themes = string.Join(", ", selectedThemes);
        var prompt =
            $$"""
            Zaproponuj prosze listę trzech tematów pracy dyplomowej na podstawie nazwy kierunku, stopnia oraz listy zainteresowań studenta.
            Wymyśl opisy tematów pracy dyplomowych wraz z rozdziałami.
            Dodaj emotkę do tytułu pracy związaną z tematyką pracy.
            Zwróć temat w formacie JSON tak jak poniżej:
            [
                {
                    "Title": "tytuł",
                    "Description": "projekt polega na zrobieniu 1",
                    "Sections": ["1. sekcja1", "2. sekcja 2"]
                }
            ].
            Zwóć to jako czysty string jsonowy bez markdowna.

            Kierunek: {{fieldOfStudy}}
            Poziom studiów: {{degree}}
            Wybrane obszary użytkownika: [{{themes}}]
            """;

        return llmTextCompletion.Complete<List<Topic>>(prompt);
    }
}

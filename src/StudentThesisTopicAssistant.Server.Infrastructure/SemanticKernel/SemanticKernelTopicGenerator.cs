using Microsoft.SemanticKernel.ChatCompletion;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics.Contract;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal class SemanticKernelTopicGenerator(ILLMChat llmChat) : ITopicGenerator
{
    public async Task<List<Topic>> Generate(string degree, string fieldOfStudy, List<string> selectedThemes)
    {
        const string prompt =
            """
            Zaproponuj prosze listę tematów pracy dyplomowej wraz z poziomem dopasowania od 0 do 100 na podstawie nazwy kierunku, stopnia oraz listy zainteresowań studenta.
            Dodatkowo wymyśl opis tematu oraz dodaj rozdziały i podrodziały, które mogą być w nim zawarte. Staraj się wygenerować podrozdziały. Istnieje możliwość niższycho poziomów podrozdziałów.
            Unikaj powtażania słów podanych na wejściu.
            Dodaj emotkę do tytułu pracy związaną z tematyką pracy.
            Zwróć listę tematów w formacie JSON!!! np:
            [
                {
                    "Title": "słowo1",
                    "Quality": 10,
                    "Description": "projekt polega na zrobieniu 1",
                    "Sections": ["1. sekcja1", "1.1. podsekcja sekcja1.1", "2. sekcja 2"]
                },
                {
                    "Phrase": "słowo2",
                    "Quality": 20,
                    "Description": "projekt polega na zrobieniu 2",
                    "Sections": ["1. sekcja1", "1.1. podsekcja sekcja1.1", "2. sekcja 2"]
                },
                {
                    "Phrase": "słowo2",
                    "Quality": 30,
                    "Description": "projekt polega na zrobieniu 3",
                    "Sections": ["1. sekcja1", "1.1. podsekcja sekcja1.1", "2. sekcja 2"]
                }
            ].
            Proszę nie zwracaj Markdown.
            """;

        var chatHistory = new ChatHistory();
        chatHistory.AddSystemMessage(prompt);
        chatHistory.AddUserMessage($"Kierunek: {fieldOfStudy}");
        chatHistory.AddUserMessage($"Poziom studiów: {degree}");
        chatHistory.AddUserMessage($"Wybrane obszary użytkownika: [{string.Join(", ", selectedThemes)}]");

        return await llmChat.Complete<List<Topic>>(chatHistory);
    }
}

using Microsoft.SemanticKernel.ChatCompletion;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal class SemanticKernelThemeGenerator(ILLMChat llmChat) : IThemeGenerator
{
    public async Task<List<PhraseQuality>> Generate(string fieldOfStudy, string degree, List<string> alreadySelectedThemes)
    {
        const string prompt =
            """
            Twoim zadaniem jest pomóc studentowi wybrać temat pracy dyplomowej.
            Twoje zadanie polega na wygenerowaniu listy prostych słów kluczowych(obszarów) związanych z podanym kierunkiem i obszarami wraz z poziomem dopasowania od 0 do 100.
            DO frazy dodaj jakąś emotkę utf8
            Unikaj powtażania słów podanych na wejściu.
            Zwróć listę w formacie JSON!!! np:
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

            Zwóć to jako czysty string jsonowy bez markdowna
            """;

        var chatHistory = new ChatHistory();
        chatHistory.AddSystemMessage(prompt);
        chatHistory.AddUserMessage($"Kierunek: {fieldOfStudy}");
        chatHistory.AddUserMessage($"Poziom studiów: {degree}");
        chatHistory.AddUserMessage($"Wybrane obszary użytkownika: [{string.Join(", ", alreadySelectedThemes)}]");

        return await llmChat.Complete<List<PhraseQuality>>(chatHistory);
    }
}

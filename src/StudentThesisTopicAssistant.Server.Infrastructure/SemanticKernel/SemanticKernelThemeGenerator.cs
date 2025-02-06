using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes.Contract;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal class SemanticKernelThemeGenerator(ILLMTextCompletion llmTextCompletion) : IThemeGenerator
{
    public Task<List<PhraseQuality>> Generate(string fieldOfStudy, string degree, List<string> alreadySelectedThemes)
    {
        var themes = string.Join(", ", alreadySelectedThemes);
        var prompt =
            $$"""
            Twoim zadaniem jest pomóc studentowi wybrać temat pracy dyplomowej.
            Twoje zadanie polega na wygenerowaniu listy prostych słów kluczowych(obszarów) związanych z podanym kierunkiem i obszarami.
            Do frazy dodaj jakąś emotkę utf8. Unikaj powtażania słów podanych na wejściu.
            Zwróć listę w formacie JSON!!! np:
            [{"Phrase": "słowo1"}].
            Zwóć to jako czysty string jsonowy bez markdowna. Ogranicz się do maksymalnie 8 fraz.
            
            Kierunek: {{fieldOfStudy}}
            Poziom studiów: {{degree}}
            Wybrane obszary użytkownika: [{{themes}}]
            """;

        return llmTextCompletion.Complete<List<PhraseQuality>>(prompt);
    }
}

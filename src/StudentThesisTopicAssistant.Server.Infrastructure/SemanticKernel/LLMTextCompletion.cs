using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextGeneration;
using System.Text.Json;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal interface ILLMTextCompletion
{
    Task<T> Complete<T>(string prompt);
}

internal class LLMTextCompletion(Kernel kernel) : ILLMTextCompletion
{
    public async Task<T> Complete<T>(string prompt)
    {
        var textGeneration = kernel.GetRequiredService<ITextGenerationService>();

        var result = await textGeneration.GetTextContentAsync(prompt);

        var content = result.Text;
        ArgumentException.ThrowIfNullOrEmpty(content);

        var deserializedResult = JsonSerializer.Deserialize<T>(content);
        ArgumentNullException.ThrowIfNull(deserializedResult);

        return deserializedResult;
    }
}

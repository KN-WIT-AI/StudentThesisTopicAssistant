using Microsoft.SemanticKernel.ChatCompletion;
using System.Text.Json;

namespace StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

internal interface ILLMChat
{
    Task<T> Complete<T>(ChatHistory chatHistory);
}

internal class LLMChat(IChatCompletionService chatCompletionService) : ILLMChat
{
    public async Task<T> Complete<T>(ChatHistory chatHistory)
    {
        var completion = await chatCompletionService.GetChatMessageContentsAsync(chatHistory);
        var contents = completion
            .Select(x => x.Content)
            .Where(x => !string.IsNullOrEmpty(x));

        var result = string.Join(Environment.NewLine, contents);

        return JsonSerializer.Deserialize<T>(result)
            ?? throw new ArgumentNullException();
    }
}
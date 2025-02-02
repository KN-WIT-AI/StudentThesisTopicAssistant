using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;
using Microsoft.Extensions.Configuration;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;

namespace StudentThesisTopicAssistant.Server.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddTransient<IThemeGenerator, SemanticKernelThemeGenerator>();
        services.AddTransient<ITopicGenerator, SemanticKernelTopicGenerator>();

        services.AddSingleton(p =>
        {
            var config = p.GetRequiredService<IConfiguration>();

            var key = config["OpenAI:ApiKey"];
            var model = config["OpenAI:Model"];

            ArgumentException.ThrowIfNullOrEmpty(key, nameof(key));
            ArgumentException.ThrowIfNullOrEmpty(model, nameof(model));

            return Kernel.CreateBuilder()
                    .AddOpenAIChatCompletion(model, key)
                    .Build();
        });
        services.AddTransient(p =>
        {
            var kernel = p.GetRequiredService<Kernel>();
            return kernel.GetRequiredService<IChatCompletionService>();
        });
        services.AddTransient<ILLMChat, LLMChat>();
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;
using StudentThesisTopicAssistant.Server.Infrastructure.SemanticKernel;

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

        services.AddTransient<ILLMTextCompletion, LLMTextCompletion>();
    }
}

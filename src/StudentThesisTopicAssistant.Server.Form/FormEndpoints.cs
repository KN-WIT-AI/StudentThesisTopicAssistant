using Microsoft.AspNetCore.Builder;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateThemes;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopics;

namespace StudentThesisTopicAssistant.Server.Form;

public static class FormEndpoints
{
    public static void MapFormEndpoints(this WebApplication app)
    {
        app.MapGenerateThemesEndpoint();
        app.MapGenerateTopicsEndpoint();
    }
}

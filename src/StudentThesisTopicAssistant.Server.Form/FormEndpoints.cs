using Microsoft.AspNetCore.Builder;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTheme;
using StudentThesisTopicAssistant.Server.Form.Features.GenerateTopic;

namespace StudentThesisTopicAssistant.Server.Form;

public static class FormEndpoints
{
    public static void MapFormEndpoints(this WebApplication app)
    {
        app.MapGenerateThemeEndpoint();
        app.MapGenerateTopicEndpoint();
    }
}

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY ./bin/Release/net8.0/publish .

ENTRYPOINT ["dotnet", "StudentThesisTopicAssistant.Server.dll"]
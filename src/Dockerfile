FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN mkdir -p /app/DOTNET_CLI_HOME

COPY [".", "/app"]

ENV DOTNET_CLI_HOME="/app/DOTNET_CLI_HOME"

RUN adduser --disabled-password --system --uid 1000 --home /app --gecos "" dotnetuser && chown -R dotnetuser /app

USER dotnetuser

WORKDIR /app/RomanAparin.ApiTests

ENTRYPOINT ["dotnet","test", "--logger:ReportPortal"]
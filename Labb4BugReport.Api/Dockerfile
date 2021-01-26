FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Labb4BugReport.Api/Labb4BugReport.Api.csproj", "Labb4BugReport.Api/"]
RUN dotnet restore "Labb4BugReport.Api/Labb4BugReport.Api.csproj"
COPY . .
WORKDIR "/src/Labb4BugReport.Api"
RUN dotnet build "Labb4BugReport.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Labb4BugReport.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labb4BugReport.Api.dll"]
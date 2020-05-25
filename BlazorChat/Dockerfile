FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlazorChat/BlazorChat.csproj", "BlazorChat/"]

RUN dotnet restore "BlazorChat/BlazorChat.csproj"
COPY . .
WORKDIR "/src/BlazorChat"
RUN dotnet build "BlazorChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorChat.dll"]

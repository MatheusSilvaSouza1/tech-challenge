FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7296

ENV ASPNETCORE_URLS=http://+:7296
ENV ASPNETCORE_ENVIRONMENT=Production

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

COPY ["./API/API.csproj"                , "src/API/"]
COPY ["./Application/Application.csproj", "src/Application/"]
COPY ["./Domain/Domain.csproj"          , "src/Domain/"]
COPY ["./Infra/Infra.csproj"            , "src/Infra/"]

RUN dotnet restore "src/API/API.csproj"

COPY . .

WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

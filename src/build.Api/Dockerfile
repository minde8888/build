FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["build.Api/build.Api.csproj", "build.Api/"]
COPY ["build.Api/build.Data.csproj", "build.Data/"]
COPY ["build.Api/build.Domain.csproj", "build.Domain/"]
COPY ["build.Api/build.Services.csproj", "build.Services/"]
RUN dotnet restore "build.Api/build.Api.csproj"
COPY . .
WORKDIR "/src/build.Api"
RUN dotnet build "build.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "build.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "build.Api.dll"]
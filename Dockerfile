#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DotNet5_API_Showcase/DotNet5_API_Showcase.csproj", "DotNet5_API_Showcase/"]
RUN dotnet restore "DotNet5_API_Showcase/DotNet5_API_Showcase.csproj"
COPY . .
WORKDIR "/src/DotNet5_API_Showcase"
RUN dotnet build "DotNet5_API_Showcase.csproj" -c Release -o /app/build
RUN dotnet publish "DotNet5_API_Showcase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotNet5_API_Showcase.dll"]
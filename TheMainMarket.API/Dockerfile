#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TheMainMarket.API/TheMainMarket.API.csproj", "TheMainMarket.API/"]
RUN dotnet restore "TheMainMarket.API/TheMainMarket.API.csproj"
COPY . .
WORKDIR "/src/TheMainMarket.API"
RUN dotnet build "TheMainMarket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheMainMarket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheMainMarket.API.dll"]
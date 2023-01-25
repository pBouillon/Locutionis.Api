FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Locutionis.Api/Locutionis.Api.csproj", "Locutionis.Api/"]
RUN dotnet restore "Locutionis.Api/Locutionis.Api.csproj"
COPY . .
WORKDIR "/src/Locutionis.Api"
RUN dotnet build "Locutionis.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locutionis.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locutionis.Api.dll"]

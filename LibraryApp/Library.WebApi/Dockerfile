FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./", "Library.WebApi/"]
RUN dotnet restore "Library.WebApi/Library.WebApi.csproj" 
COPY . .
WORKDIR "/src/Library.WebApi"
RUN dotnet build "Library.WebApi.csproj" -c Release -o /app/build

FROM build AS publish 
RUN dotnet publish "Library.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.WebApi.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/KapitalMedya.WebAPI/KapitalMedya.WebAPI.csproj", "Presentation/KapitalMedya.WebAPI/"]
COPY ["Core/KapitalMedya.Application/KapitalMedya.Application.csproj", "Core/KapitalMedya.Application/"]
COPY ["Core/KapitalMedya.Domain/KapitalMedya.Domain.csproj", "Core/KapitalMedya.Domain/"]
COPY ["Infrastructure/KapitalMedya.Infrastructure/KapitalMedya.Infrastructure.csproj", "Infrastructure/KapitalMedya.Infrastructure/"]
COPY ["Infrastructure/KapitalMedya.Persistence/KapitalMedya.Persistence.csproj", "Infrastructure/KapitalMedya.Persistence/"]
RUN dotnet restore "Presentation/KapitalMedya.WebAPI/KapitalMedya.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/KapitalMedya.WebAPI"
RUN dotnet build "KapitalMedya.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KapitalMedya.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "KapitalMedya.WebAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet KapitalMedya.WebAPI.dll
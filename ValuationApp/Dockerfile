#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ValuationApp/ValuationApp.csproj", "ValuationApp/"]
COPY ["ValuationApp.DataAccess/ValuationApp.DataAccess.csproj", "ValuationApp.DataAccess/"]
COPY ["ValuationApp.Entities/ValuationApp.Entities.csproj", "ValuationApp.Entities/"]
COPY ["ValuationApp.Services.Contract/ValuationApp.Services.Contract.csproj", "ValuationApp.Services.Contract/"]
COPY ["ValuationApp.ValuationDto/ValuationApp.ValuationDto.csproj", "ValuationApp.ValuationDto/"]
COPY ["ValuationApp.Services/ValuationApp.Services.csproj", "ValuationApp.Services/"]
RUN dotnet restore "./ValuationApp/./ValuationApp.csproj"
COPY . .
WORKDIR "/src/ValuationApp"
RUN dotnet build "./ValuationApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ValuationApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ValuationApp.dll"]
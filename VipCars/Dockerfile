FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VipCars/VipCars.csproj", "VipCars/"]
COPY ["VipCars.Application/VipCars.Application.csproj", "VipCars.Application/"]
COPY ["VipCars.Domain/VipCars.Domain.csproj", "VipCars.Domain/"]
COPY ["VipCars.Infrastructure/VipCars.Infrastructure.csproj", "VipCars.Infrastructure/"]
RUN dotnet restore "VipCars/VipCars.csproj"
COPY . .
WORKDIR "/src/VipCars"
RUN dotnet build "VipCars.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VipCars.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VipCars.dll"]

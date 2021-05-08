FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["Client/SMA.Angular/SMA.Angular.csproj", "SMA.Angular/"]
RUN dotnet restore "Client/SMA.Angular/SMA.Angular.csproj"
COPY . .
WORKDIR "/src/SMA.Angular"
RUN dotnet build "SMA.Angular.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SMA.Angular.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SMA.Angular.dll"]

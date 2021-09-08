FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Tilia/Tilia.csproj", "Tilia/"]
RUN dotnet restore "Tilia/Tilia.csproj"
COPY /src .
WORKDIR "/src/Tilia"
RUN dotnet build "Tilia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tilia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tilia.dll"]

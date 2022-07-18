#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BonosBackend/BonosBackend.csproj", "BonosBackend/"]
RUN dotnet restore "BonosBackend/BonosBackend.csproj"
COPY . .
WORKDIR "/src/BonosBackend"
RUN dotnet build "BonosBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BonosBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BonosBackend.dll

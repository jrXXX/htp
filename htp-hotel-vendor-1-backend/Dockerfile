#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV DOCKER_REGISTRY htphoteldockercontainerregistry.azurecr.io
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Akros.Htp.Vendor.Backend.Startup/Vendor.Backend.Startup.csproj", "src/Akros.Htp.Vendor.Backend.Startup/"]
RUN dotnet restore "src/Akros.Htp.Vendor.Backend.Startup/Vendor.Backend.Startup.csproj"
COPY . .

WORKDIR "/src/src/Akros.Htp.Vendor.Backend.Startup"
RUN dotnet build "Vendor.Backend.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vendor.Backend.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Akros.Htp.Vendor.Backend.Startup.dll"]

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Logistics.Management.WebApi/Logistics.Management.WebApi.csproj", "src/Logistics.Management.WebApi/"]
RUN dotnet restore "src/Logistics.Management.WebApi/Logistics.Management.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Logistics.Management.WebApi"
RUN dotnet build "Logistics.Management.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logistics.Management.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Logistics.Management.WebApi.dll"]
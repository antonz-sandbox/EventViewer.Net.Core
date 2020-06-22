#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservices.Salary/Microservices.Salary.csproj", "Microservices.Salary/"]
COPY ["Microservices.Common/Microservices.Common.csproj", "Microservices.Common/"]
RUN dotnet restore "Microservices.Salary/Microservices.Salary.csproj"
COPY . .
WORKDIR "/src/Microservices.Salary"
RUN dotnet build "Microservices.Salary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Salary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Salary.dll"]
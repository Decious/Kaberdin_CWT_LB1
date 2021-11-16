#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Kaberdin_LB1/Kaberdin_LB1.csproj", "Kaberdin_LB1/"]
RUN dotnet restore "Kaberdin_LB1/Kaberdin_LB1.csproj"
COPY . .
WORKDIR "/src/Kaberdin_LB1"
RUN dotnet build "Kaberdin_LB1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kaberdin_LB1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kaberdin_LB1.dll"]
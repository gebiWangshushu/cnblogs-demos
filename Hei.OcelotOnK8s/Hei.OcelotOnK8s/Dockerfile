#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# WORKDIR /app
# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# WORKDIR /src
# COPY ["Hei.OcelotOnK8s/Hei.OcelotOnK8s.csproj", "Hei.OcelotOnK8s/"]
# RUN dotnet restore "Hei.OcelotOnK8s/Hei.OcelotOnK8s.csproj"
# COPY . .
# WORKDIR "/src/Hei.OcelotOnK8s"
# RUN dotnet build "Hei.OcelotOnK8s.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Hei.OcelotOnK8s.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Hei.OcelotOnK8s.dll"]


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY . /app
ENTRYPOINT  ["dotnet", "Hei.OcelotOnK8s.dll"]


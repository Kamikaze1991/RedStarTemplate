#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Comstroke.Clientes.Rest/Comstroke.Clientes.Rest.csproj", "Comstroke.Clientes.Rest/"]
COPY ["Comstroke.Clientes.Model/Comstroke.Clientes.Model.csproj", "Comstroke.Clientes.Model/"]
COPY ["Comstroke.Clientes.BusinessEngine/Comstroke.Clientes.BusinessEngine.csproj", "Comstroke.Clientes.BusinessEngine/"]
COPY ["Comstroke.Clientes.DataEngine/Comstroke.Clientes.DataEngine.csproj", "Comstroke.Clientes.DataEngine/"]
RUN dotnet restore "Comstroke.Clientes.Rest/Comstroke.Clientes.Rest.csproj"
COPY . .
WORKDIR "/src/Comstroke.Clientes.Rest"
RUN dotnet build "Comstroke.Clientes.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Comstroke.Clientes.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comstroke.Clientes.Rest.dll"]
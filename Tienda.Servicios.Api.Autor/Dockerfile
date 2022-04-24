#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Tienda.Servicios.Api.Autor/Tienda.Servicios.Api.Autor.csproj", "Tienda.Servicios.Api.Autor/"]
RUN dotnet restore "Tienda.Servicios.Api.Autor/Tienda.Servicios.Api.Autor.csproj"
COPY . .
WORKDIR "/src/Tienda.Servicios.Api.Autor"
RUN dotnet build "Tienda.Servicios.Api.Autor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tienda.Servicios.Api.Autor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tienda.Servicios.Api.Autor.dll"]

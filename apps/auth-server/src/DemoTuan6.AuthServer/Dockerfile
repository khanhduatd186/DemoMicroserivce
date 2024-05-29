FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mycompanyname/demotuan6-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/apps/auth-server/src/DemoTuan6.AuthServer"
RUN dotnet publish -c Release -o /app
RUN dotnet dev-certs https -v -ep /app/openiddict.pfx -p d25c4a4c-2c41-46e6-be7b-4d33ed569376

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DemoTuan6.AuthServer.dll"]
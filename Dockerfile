#Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /WebApi
COPY ./WebApi .
RUN dotnet restore "./WebApi.csproj"
RUN dotnet publish "./WebApi.csproj" -c release -o /api

#Serve
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal 
WORKDIR /api
COPY --from=build /api ./
EXPOSE 5000

ENTRYPOINT ["dotnet", "WebApi.dll"]
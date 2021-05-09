FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build
 
## Setup NodeJs
#RUN apk update && apk add --update --no-cache nodejs-current nodejs-npm python make g++ \
#	&& npm install -g npm \
#	&& npm install -g node-sass --force --unsafe-perm=true --allow-root \
#	&& npm install -g @angular/cli
## End setup

WORKDIR /app
EXPOSE 80

COPY Stocky.Core/Stocky.Core.csproj Stocky.Core/
COPY Stocky.Data/Stocky.Data.csproj Stocky.Data/
COPY Stocky.DataAccess/Stocky.DataAccess.csproj Stocky.DataAccess/
COPY Stocky.Web/Stocky.Web.csproj Stocky.Web/ 

RUN dotnet restore Stocky.Web/Stocky.Web.csproj 

COPY . .
WORKDIR /app/Stocky.Web
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /app
COPY --from=build /app/Stocky.Web/out ./
#ENTRYPOINT ["dotnet", "Stocky.Web.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Stocky.Web.dll
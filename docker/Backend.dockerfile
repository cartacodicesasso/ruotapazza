FROM node:16 AS build-frontend
WORKDIR /app
COPY ./RuotaPazza.Frontend .
RUN npm i
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-backend
WORKDIR /app
COPY ./RuotaPazza.Backend .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-backend /app/out .
COPY --from=build-frontend /app/build ./wwwroot
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "RuotaPazza.Backend.dll"]
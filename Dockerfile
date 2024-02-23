FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.sln .
COPY ./src/src.csproj ./src/
COPY ./test/test.csproj ./test/

RUN dotnet restore 

COPY  . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

ENTRYPOINT [ "dotnet", "src.dll" ]
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /SpartanClash

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /SpartanClash
COPY --from=build-env /SpartanClash/out .
ENTRYPOINT ["dotnet", "SpartanClash.dll"]
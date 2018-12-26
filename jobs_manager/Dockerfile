FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app
COPY . /app
RUN dotnet restore
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENV ASPNETCORE_URLS=http://+:9090
EXPOSE 9090
ENTRYPOINT ["dotnet", "jobs_manager.dll"]

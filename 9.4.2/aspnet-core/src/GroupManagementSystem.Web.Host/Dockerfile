FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/GroupManagementSystem.Web.Host/GroupManagementSystem.Web.Host.csproj", "src/GroupManagementSystem.Web.Host/"]
COPY ["src/GroupManagementSystem.Web.Core/GroupManagementSystem.Web.Core.csproj", "src/GroupManagementSystem.Web.Core/"]
COPY ["src/GroupManagementSystem.Application/GroupManagementSystem.Application.csproj", "src/GroupManagementSystem.Application/"]
COPY ["src/GroupManagementSystem.Core/GroupManagementSystem.Core.csproj", "src/GroupManagementSystem.Core/"]
COPY ["src/GroupManagementSystem.EntityFrameworkCore/GroupManagementSystem.EntityFrameworkCore.csproj", "src/GroupManagementSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/GroupManagementSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/GroupManagementSystem.Web.Host", "src/GroupManagementSystem.Web.Host"]
COPY ["src/GroupManagementSystem.Web.Core", "src/GroupManagementSystem.Web.Core"]
COPY ["src/GroupManagementSystem.Application", "src/GroupManagementSystem.Application"]
COPY ["src/GroupManagementSystem.Core", "src/GroupManagementSystem.Core"]
COPY ["src/GroupManagementSystem.EntityFrameworkCore", "src/GroupManagementSystem.EntityFrameworkCore"]
WORKDIR "/src/src/GroupManagementSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "GroupManagementSystem.Web.Host.dll"]

# ��. ������ �� ������ https://aka.ms/customizecontainer, ����� ������ ��� ��������� ��������� ������� � ��� Visual Studio ���������� ���� Dockerfile ��� �������� ������� ��� ��������� �������.

# � ����������� �� ������������ ������� ����-�����������, ������� ����� ��������� ������ ����������� ��� ��������� ��, ����� ������������� �������� �����, ��������� � ���������� FROM.
# �������������� �������� ��. �� �������� https://aka.ms/containercompat

# ���� ���� ������������ ��� ������� �� VS � ������� ������ (�� ��������� ��� ������������ �������)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# ���� ���� ������������ ��� ������ ������� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["studytaskmanager.webapi/studytaskmanager.webapi.Server/StudyTaskManager.WebAPI.csproj", "studytaskmanager.webapi/studytaskmanager.webapi.Server/"]
COPY ["StudyTaskManager.Application/StudyTaskManager.Application.csproj", "StudyTaskManager.Application/"]
COPY ["StudyTaskManager.Domain/StudyTaskManager.Domain.csproj", "StudyTaskManager.Domain/"]
COPY ["StudyTaskManager.Infrastructure/StudyTaskManager.Infrastructure.csproj", "StudyTaskManager.Infrastructure/"]
COPY ["StudyTaskManager.Persistence/StudyTaskManager.Persistence.csproj", "StudyTaskManager.Persistence/"]
COPY ["studytaskmanager.webapi/studytaskmanager.webapi.client/StudyTaskManager.Presentation.esproj", "studytaskmanager.webapi/studytaskmanager.webapi.client/"]
RUN dotnet restore "./studytaskmanager.webapi/studytaskmanager.webapi.Server/StudyTaskManager.WebAPI.csproj"
COPY . .
WORKDIR "/src/studytaskmanager.webapi/studytaskmanager.webapi.Server"
RUN dotnet build "./StudyTaskManager.WebAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# ���� ���� ������������ ��� ���������� ������� ������, ������� ����� ���������� �� ��������� ����
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StudyTaskManager.WebAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# ���� ���� ������������ � ������� ����� ��� ��� ������� �� VS � ������� ������ (�� ���������, ����� ������������ ������� �� ������������)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyTaskManager.WebAPI.dll"]
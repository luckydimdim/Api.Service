set project_name=Web
set configuration=Release
set nuget_source=http://cm-ylng-msk-04/nuget/nuget

for /f %%G in ('dir %UserProfile%\.nuget\packages\cmas.* /a:d /b') do @(
   rd /s /q %UserProfile%\.nuget\packages\%%G
)

dotnet clean %project_name%\%project_name%.csproj --configuration %configuration%
dotnet restore %project_name%\%project_name%.csproj --source %nuget_source% --no-cache

cd /D %project_name%
dotnet run --project %project_name%.csproj --configuration %configuration%

pause
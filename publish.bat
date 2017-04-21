set project_name=Web
set output_directory=publish
set configuration=Release
set nuget_source=http://cm-ylng-msk-04/nuget/nuget

for /f %%G in ('dir %UserProfile%\.nuget\packages\cmas.* /a:d /b') do @(
   rd /s /q %UserProfile%\.nuget\packages\%%G
)

dotnet clean %project_name%\%project_name%.csproj --configuration %configuration%
dotnet restore %project_name%\%project_name%.csproj --source %nuget_source% --no-cache
dotnet publish %project_name% --output %output_directory% --configuration %configuration%

pause
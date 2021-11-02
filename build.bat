dotnet restore
dotnet build --no-restore .\src\EmmaSharper\ --configuration Release
XCopy .\src\EmmaSharper\bin\release\* .\dist\ /S
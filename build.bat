dotnet restore
dotnet build --no-restore .\src\EmmaSharp\ --configuration Release
XCopy .\src\EmmaSharp\bin\release\* .\dist\ /S
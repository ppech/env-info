dotnet pack "$PSScriptRoot/../src/EnvInfo.Core/EnvInfo.Core.csproj" -c PackRelease
dotnet pack "$PSScriptRoot/../src/EnvInfo.Mvc/EnvInfo.Mvc.csproj" -c PackRelease
dotnet pack "$PSScriptRoot/../src/EnvInfo.DotVVM/EnvInfo.DotVVM.csproj" -c PackRelease
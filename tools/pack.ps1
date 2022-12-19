dotnet pack "$PSScriptRoot/../src/EnvInfo.Core/EnvInfo.Core.csproj" -o "$PSScriptRoot/../publish" -c PackRelease
dotnet pack "$PSScriptRoot/../src/EnvInfo.Mvc/EnvInfo.Mvc.csproj" -o "$PSScriptRoot/../publish" -c PackRelease
dotnet pack "$PSScriptRoot/../src/EnvInfo.DotVVM/EnvInfo.DotVVM.csproj" -o "$PSScriptRoot/../publish" -c PackRelease
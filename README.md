# EnvInfo

Enviroment info controls for Mvc/RazorPages and DotVVM

## Usage

Install nuget package for each UI framework you use in your project. Then register required services in `Program.cs` or `Startup.cs` file
```
builder.Services.AddEnvInfo();
```

### MVC / Razor Pages
[![Latest version](https://img.shields.io/nuget/v/EnvInfo.MVC.svg)](https://www.nuget.org/packages/EnvInfo.MVC)

Add tag helpers import to `_ViewImports.cshtml` file
```
@addTagHelper *, EnvInfo.Mvc
```

The add code below before `</body>` element in your `.cshtml` file
```
<env-info>
    <env-name />
</env-info>
```

### DotVVM
[![Latest version](https://img.shields.io/nuget/v/EnvInfo.DotVVM.svg)](https://www.nuget.org/packages/EnvInfo.DotVVM)

Add control registration to Configure method in DotvvmStartup file.
```
config.AddEnvInfoConfiguration();
```

Then add code below before `</body>` element in your `.dotmaster` or `.dothtml` file
```
<dot:EnvInfo>
    <dot:EnvName />
</dot:EnvInfo>
```
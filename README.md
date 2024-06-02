# EnvInfo

[![License](https://img.shields.io/github/license/ppech/dotnet-hostsctl)](LICENSE)

EnvInfo is a collection of Mvc/RazorPages tag helpers and DotVVM controls that provides environment information 
for your application. It is useful for identifing between different environments like Development, Staging, and Production.

## Features
* display environment name (e.g., DEV, STAG, PROD) based on the current environment
* ability to change environment name or visility using configuration
* display Bootstrap breakpoint name (e.g., xs, sm, md, lg, xl) based on the current screen width
* ability to change predefined styles using custom css

## Usage

Install nuget package for each UI framework you use in your project. Then register required service in `Program.cs` or `Startup.cs` file

```csharp
builder.Services.AddEnvInfo();
```

By default, the Name is derived from the environment name and Visible is set to true 
for the development environment. Then tries to load the configuration section `EnvInfo`
and set the values.

```json
"EnvInfo": {
    "Name": "ALPHA",
    "Visible": true
}
```

You can provide custom configuration section.

```csharp
services.AddEnvInfo(Configuration.GetSection("App.EnvInfo"));
```

Or you can override Name directly in code
```csharp
builder.Services.AddEnvInfo("APLHA");
```

Or simply provide custom configuration object

```csharp
services.AddEnvInfo(new EnvInfoOptions
{
    Name = "CUSTOM",
    Visible = true
});
```

### MVC / Razor Pages
[![Latest version](https://img.shields.io/nuget/v/EnvInfo.MVC.svg)](https://www.nuget.org/packages/EnvInfo.MVC)

Add tag helpers import to `_ViewImports.cshtml` file
```razor
@addTagHelper *, EnvInfo.Mvc
```

Below is basic usage snippet that displays environment name. Place it before `</body>` element in your `.cshtml` file
```html
<env-info>
    <env-name />
</env-info>
```

Inside `env-info` tag you can use any html element or any of predefined tag helpers:
* `<env-name />` - displays environment name
* `<bs4-breakpoints />` - displays Bootstrap 4 breakpoint name
* `<bs5-breakpoints />` - displays Bootstrap 5 breakpoint name
* `<bs-breakpoints breakpoints="xxs xs sm md lg xl xxl 3xl" />` - displays custom Bootstrap breakpoint name

Below is an example of usage with custom html and predefined tag helper
```html
<env-info>
    <env-name />
    <span>|</span>
    <bs4-breakpoints />
</env-info>
```



### DotVVM
[![Latest version](https://img.shields.io/nuget/v/EnvInfo.DotVVM.svg)](https://www.nuget.org/packages/EnvInfo.DotVVM)

Add control registration to Configure method in DotvvmStartup file.
```csharp
config.AddEnvInfoConfiguration();
```

Below is basic usage snippet that displays environment name. Place it  before `</body>` element in your `.dotmaster` or `.dothtml` file
```html
<dot:EnvInfo>
    <dot:EnvName />
</dot:EnvInfo>
```

Inside `env-info` tag you can use any html element or any of predefined controls:
* `<dot:EnvName />` - displays environment name
* `<dot:Bootstrap4Breakpoints />` - displays Bootstrap 4 breakpoint name
* `<dot:Bootstrap5Breakpoints />` - displays Bootstrap 5 breakpoint name
* `<dot:BootstrapBreakpoints Breakpoints="xxs xs sm md lg xl xxl 3xl" />` - displays custom Bootstrap breakpoint name

Below is an example of usage with custom html and predefined control
```html
<dot:EnvInfo>
    <dot:EnvName />
    <span>|</span>
    <dot:Bootstrap4Breakpoints />
</dot:EnvInfo>
```

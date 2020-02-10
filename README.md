Configuration.AppConfig
============

[![NuGet][main-nuget-badge]][main-nuget] [![NuGet][nuget-dl-badge]][main-nuget]

[main-nuget]: https://www.nuget.org/packages/Configuration.AppConfig/
[main-nuget-badge]: https://img.shields.io/nuget/v/Configuration.AppConfig.svg?style=flat-square&label=nuget
[nuget-dl-badge]: https://img.shields.io/nuget/dt/Configuration.AppConfig.svg?style=flat-square

## Overview

The .NET Core configuration supports variety of configuration sources, like JSON file, XML file, Ini file, environment variables, command line.

It might happen, that there is no time to convert the legacy app.config file to a different type of source which is supported by 
Microsoft. Or there might be a possible preference of the app.config over the recommended and supported configuration sources.

It is to consider the general XML file provider (referenced as the [Microsoft.Extensions.Configuration.Xml](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Xml) NuGet package.
However this simple provider might be handy to use in case of having only need to read just the appSettings or connectionStrings section.

## Installation

Install the [NuGet package][nuget] into your project.

```
PM> Install-Package Configuration.AppConfig
```
```
$ dotnet add package Configuration.AppConfig
```

## Basics of Usage

1) Register the provider in the ConfigurationBuilder a similar way as for the other provider types would be.


```csharp
	var builder = new ConfigurationBuilder();			
	builder.AddAppConfig();								
```

2) Build the configuration (an object implementing the [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration) interface)

```csharp
	var config = builder.Build();
```

3) Use the configuration the standard way to read the appSettings or the connectionStrings
   (Please reference the [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/) NuGet package in order to use the GetValue\<T\>() method)
```csharp
	var tmpDirectory = config["appSettings:tmpDir"];
	var dbConnStr = config["connectionStrings:DbConn"];
	
	var threshold = config.GetValue<double>("appSettings:threshold");
```

### Provider Parameters

It can be specified, how the appSettings and connectionString sections will be named when getting the value.
Then e.g. used together with the JSON file configuration source with the same naming.
(Please reference the [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) NuGet package in order to use the AddJsonFile() method).

```csharp
	var builder = new ConfigurationBuilder()			
		.AddAppConfig("AppSettings", "ConnectionStrings")
		.AddJsonFile("appsettings.json", optional: true);
```

```csharp
	// reads either from the legacy app.config (appSettings, connectionStrings sections) or from JSON with AppSettings, ConnectionStrings sections
	var tmpDirectory = config["appSettings:tmpDir"];
	var dbConnStr = config["connectionStrings:DbConn"];
	...
```


## Useful Links

* [Official documentation about Microsoft Configuration (ASP.NET Core)](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration)

* [Microsoft.Extensions.Configuration source code](https://github.com/dotnet/extensions/tree/master/src/Configuration)

* [Deep Dive into Microsoft Configuration Blog article](https://www.paraesthesia.com/archive/2018/06/20/microsoft-extensions-configuration-deep-dive/)

* [Using .NET Core Configuration with legacy projects Blog article](https://benfoster.io/blog/net-core-configuration-legacy-projects)
 (this provider is inspired by that)

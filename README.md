# EmmaSharp

A .NET wrapper for the [Emma API](http://api.myemma.com/).

Targeting Frameworks

- `netcoreapp3.1`
- `net5.0`

## Sample Usage

The examples below show how to have your application pull all account fields on the Emma API. An optional parameter is included to show all fields, included those that were deleted:

```C#
    using EmmaSharp;

    ServiceCollection.AddEmmaApiProviders(options => {
        AccountId = "Your Account ID";
        PublicKey = "Your Public Key";
        SecretKey = "Your Secret Key";
        BaseUrl = "API URL"; // This is optional and defaults to https://api.e2ma.net
    });
```

## Getting Started

This version of EmmaSharp is available on NuGet under [EmmaSharpCore](https://www.nuget.org/packages/EmmaSharpCore)

```
Install-Package EmmaSharpCore
```

## Status of the Project

The original project created by [kylegregory](https://github.com/kylegregory/EmmaSharp) appears to be abandoned. This new project is a living fork from the original work. Feel free to contribute. Most API endpoints have methods in the library. If you have any questions, feel free to submit an issue for a particular entity or endpoint. Emma API documentation can be found at https://api.myemma.com.

### Making contributions

This project is not affiliated with [Emma](http://myemma.com/meet-us). All contributors to this project are unpaid average folks (just like you!) who choose to volunteer their time. If you like Emma and want to contribute, we would appreciate your help! To get started, just [fork the repo](https://help.github.com/articles/fork-a-repo), make your changes and submit a pull request.

# MdIcons.Blazor
Wraps Material design icons in blazor without pain!

## Getting Started

In your WebAssembly (client) project, add the package from Nuget

> ```bash
> dotnet add package MdIcons.Blazor
> ```

In your Program.cs file, register the required dependencies: 

````csharp
using MdIcons.Blazor; //<---------- Add this
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMdiIcons(); //<---------- Add this

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

````



Add the required namespace in your _Imports.razor file

```csharp
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.AspNetCore.Components.WebAssembly.Http
@using Microsoft.JSInterop
@using MdIcons.Blazor
```

To add an icon, in any .razor file, simply add a <MdiIcon/>  component:

````csharp
 <MdiIcon Icon="MdIcons.Emoticon.Cool" Size=48></MdiIcon>
````



For a list of icons you can check the [Official list](https://materialdesignicons.com/) or the [MdIcons.Blazor Helper page](https://davidnajar.github.io/MdIcons.Blazor/)


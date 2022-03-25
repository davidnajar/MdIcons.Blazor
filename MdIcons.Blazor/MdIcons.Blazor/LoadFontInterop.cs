using Microsoft.JSInterop;

namespace MdIcons.Blazor
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class LoadFontInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        bool isLoaded = false;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public LoadFontInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/MdIcons.Blazor/MdiIcons.Blazor.js").AsTask());
        }

        public async ValueTask Init()
        {
            var module = await moduleTask.Value;
            if (!isLoaded)
            {
                await _semaphore.WaitAsync();
                try
                {
                    if (!isLoaded)
                    {
                        await module.InvokeVoidAsync("loadIconFont");
                        isLoaded = true;
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
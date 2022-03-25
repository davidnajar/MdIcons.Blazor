using Microsoft.Extensions.DependencyInjection;

namespace MdIcons.Blazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMdiIcons(this IServiceCollection services)
        {
            services.AddSingleton<LoadFontInterop>();
            return services;
        }
    }
}

using Login.Core;
using Login.Gmail;
using Microsoft.Extensions.DependencyInjection;
using Uploader.Core.Contracts;
using Uploader.Playwright.Youtube;

namespace Uploader.StartUp;

public static class RegisterServices
{
    public static IServiceCollection AddUploadFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ILoginManager, LoginManager>();
        serviceCollection.AddSingleton<IUploader, PlaywrightUploader>();
        serviceCollection.AddSingleton<PlaywrightUploader>();

        return serviceCollection;
    }
}
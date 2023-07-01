using Downloader.Core;
using Downloader.TikTok;
using Downloader.Twitter;
using History.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Downloader.StartUp;

public static class RegisterServices
{
    public static IServiceCollection AddDownloadFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<TikTokDownloader>();
        serviceCollection.AddSingleton<TwitterDownloader>();
        serviceCollection.AddSingleton<HistoryPool>();
        serviceCollection.AddSingleton<DownloaderManager>(x =>
            new DownloaderManager(x.GetRequiredService<TikTokDownloader>(),
                x.GetRequiredService<TwitterDownloader>(),
                x.GetRequiredService<HistoryPool>()));

        return serviceCollection;
    }
}
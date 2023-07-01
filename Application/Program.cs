using System;
using System.IO;
using Application.App;
using Application.Pages;
using Application.Pages.VideoEditor;
using Application.Pages.VideoEditor.Contracts;
using Application.Windows.Main;
using Application.Windows.Main.Contracts;
using ConnectionPool.Core.Contracts;
using ConnectionPool.Playwright;
using ConnectionPool.StartUp;
using Downloader.Core;
using Downloader.StartUp;
using Downloader.TikTok;
using Downloader.Twitter;
using History.Core;
using Login.Core;
using Login.Gmail;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uploader.Core;
using Uploader.Core.Contracts;
using Uploader.Playwright.Youtube;
using Uploader.StartUp;
using User.Core.Contracts;
using User.Json;
using User.StartUp;

namespace Application;

public class Program : System.Windows.Application
{
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                #region Windows And Pages

                services.AddSingleton<AppMain>();
                services.AddSingleton<MainWindowView>();
                services.AddSingleton<MainWindowModel>();
                services.AddSingleton<IMainWindowSignalBus>(s => s.GetRequiredService<MainWindowModel>());
                services.AddSingleton<IMainWindowModel>(s => s.GetRequiredService<MainWindowModel>());
                services.AddSingleton<MainWindowPresenter>();

                services.AddSingleton<VideoEditorView>();
                services.AddSingleton<VideoEditorModel>();
                services.AddSingleton<IVideoEditorModel>(s => s.GetRequiredService<VideoEditorModel>());
                services.AddSingleton<IVideoEditorSignalBus>(s => s.GetRequiredService<VideoEditorModel>());
                services.AddSingleton<VideoEditorPresenter>();

                #endregion

                #region Features

                services.AddDownloadFeature();
                services.AddConnectionPoolFeature();
                services.AddUploadFeature();
                services.AddUserFeature();

                #endregion


            });

        #region FileController

        if (!File.Exists($"{Directory.GetCurrentDirectory()}/downloadedvideos.json"))
            File.Create($"{Directory.GetCurrentDirectory()}/downloadedvideos.json");
        if (!File.Exists($"{Directory.GetCurrentDirectory()}/settings.json"))
            File.Create($"{Directory.GetCurrentDirectory()}/settings.json");
        if (!File.Exists($"{Directory.GetCurrentDirectory()}/clientsecret.json"))
            File.Create($"{Directory.GetCurrentDirectory()}/clientsecret.json");

        #endregion

        var build = host.Build();
        var app = build.Services.GetService<AppMain>();

        #region Non Lazy Injection

        var mainWindowPresenter = build.Services.GetService<MainWindowPresenter>();
        var videoEditorPresenter = build.Services.GetService<VideoEditorPresenter>();

        #endregion

        app?.Run();
    }
}
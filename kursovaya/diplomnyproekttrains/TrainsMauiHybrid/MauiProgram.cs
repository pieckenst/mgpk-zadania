
using CommunityToolkit.Maui;
using CustomShellMaui;
using DevExpress.Maui;
using EntityFrameworkCore.UseRowNumberForPaging;
using Material.Components.Maui.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Radzen;
using TrainsMauiHybrid.Helpers;


namespace TrainsMauiHybrid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseCustomShellMaui()
                .UseDevExpress()
                .UseMaterialComponents()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddScoped<TrainsMauiHybrid.Services.DiplomnyProektService>();
            builder.Services.AddDbContext<TrainsMauiHybrid.Data.DiplomnyProektContext>(options =>
            {
                options.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Persist Security Info=False;TrustServerCertificate=True; Encrypt=false;User ID=rsncra_DiplomnyProekt;Password=ctrt55xx;Initial Catalog=rsncra_DiplomnyProekt",
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();; // retry 6 times on fail
                        sqlOptions.UseRowNumberForPaging();
                    });
            });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMasaBlazor();
            builder.Services.AddRadzenComponents();
            
            builder.Services.AddSingleton<EventHandleHelper>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

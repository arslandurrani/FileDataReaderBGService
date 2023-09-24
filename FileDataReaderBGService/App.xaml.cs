using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Windows;
using FileDataReaderBGService.Services;
using FileDataReaderBGService.DBContext;

namespace FileDataReaderBGService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDI.BuildHostService();

            var ELDEventsService = (ELDEventsBGService)AppDI.GetRequiredService<IHostedService>();
            var eLDEventsServerService = AppDI.GetRequiredService<ELDEventsServerService>();

            ELDEventsService.OnELDEventsInserted += eLDEventsServerService.OnELDEventsInserted;

            // Run migration on ensure the DB is /created/updated
            var db = AppDI.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppDI.StopHostedService();
            
            base.OnExit(e);
        }
    }
}

using FileDataReaderBGService.Common;
using FileDataReaderBGService.Repositories;
using FileDataReaderBGService.Utilities;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileDataReaderBGService.Services;

public class ELDEventsBGService : BackgroundService
{
    public bool IsRunning { get; private set; } = false;

    // add event here
    public event EventHandler OnELDEventsInserted;

    private readonly ILogger<BackgroundService> _logger;
    private readonly ELDEventsRepository _eLDEventsRepository;

    public ELDEventsBGService(ILogger<BackgroundService> logger, ELDEventsRepository eLDEventsRepository)
    {
        _logger = logger;
        _eLDEventsRepository = eLDEventsRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IsRunning = true;

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Background service is running at: " + DateTime.Now);

            await BackgroundTask();

            // Wait for 5 seconds before running the task again
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private async Task BackgroundTask()
    {
        var filePath = FileHelper.GetFirstFileFromDirectory(Constants.DIRECTORY_PATH_IN_PROCESS);

        if (filePath == null)
            return;

        var extractedData = new ELDEventsProcessor().ProcessFile(filePath);

        if (extractedData == null || extractedData.Count == 0)
            return;

        // insert the processed record into the DB
        await _eLDEventsRepository.InsertRecordsAsync(extractedData);

        // move the processed file to COMPLETED folder
        var filename = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{Path.GetFileName(filePath)}";
        var destinationPath = Path.Combine(Constants.DIRECTORY_PATH_COMPLETED, filename);

        FileHelper.MoveFile(filePath, destinationPath);

        /*         
         * NOTE: we can directly send the extractedData in the event, but to show that
         * we are transferring the data using the database form one table to another.
         * I am only triggering the event only and not passing any data inside it.
        */

        //invoke event to trigger sync operation with other table
        OnELDEventsInsertCompleted(EventArgs.Empty);
    }

    private void OnELDEventsInsertCompleted(EventArgs e)
    {
        OnELDEventsInserted?.Invoke(this, e);
    }
}

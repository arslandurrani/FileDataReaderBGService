using AutoMapper;

using FileDataReaderBGService.Entities;
using FileDataReaderBGService.Repositories;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;

namespace FileDataReaderBGService.Services;

public class ELDEventsServerService
{
    private readonly ILogger<BackgroundService> _logger;
    private readonly ELDEventsRepository _eLDEventsRepository;
    private readonly ELDEventsServerRepository _eLDEventsServerRepository;
    private readonly IMapper _mapper;

    public ELDEventsServerService(ILogger<BackgroundService> logger,
        ELDEventsRepository eLDEventsRepository,
        ELDEventsServerRepository eLDEventsServerRepository,
        IMapper mapper)
    {
        _logger = logger;
        _eLDEventsRepository = eLDEventsRepository;
        _eLDEventsServerRepository = eLDEventsServerRepository;
        _mapper = mapper;
    }

    public async void OnELDEventsInserted(object? sender, EventArgs e)
    {
        // get data form the database
        var ELDEventsSyncData = await _eLDEventsRepository.GetNonProcessedRecords();

        if (ELDEventsSyncData == null || ELDEventsSyncData.Count == 0)
            return; // nothing to sync

        var ELDEventsServerData = new List<ELDEventsServer>();

        // Map data from ELDEvents to ELDEventsServer
        _mapper.Map(ELDEventsSyncData, ELDEventsServerData);

        foreach (var item in ELDEventsSyncData)
        {
            item.IsProcessed = true;
        }

        await _eLDEventsRepository.UpdateProcessedRecords(ELDEventsSyncData);
        await _eLDEventsServerRepository.InsertRecordsAsync(ELDEventsServerData);
    }
}

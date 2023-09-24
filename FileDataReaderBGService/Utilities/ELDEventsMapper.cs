using AutoMapper;

using FileDataReaderBGService.Entities;

namespace FileDataReaderBGService.Utilities;

public class ELDEventsMapper : Profile
{
    public ELDEventsMapper()
    {
        CreateMap<ELDEvents, ELDEventsServer>();
    }
}

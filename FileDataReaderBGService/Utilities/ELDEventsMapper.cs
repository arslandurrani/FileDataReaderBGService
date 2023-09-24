using AutoMapper;

using FileDataReaderBGService.Entities;

namespace FileDataReaderBGService.Utilities;

public class ELDEventsMapper : Profile
{
    public ELDEventsMapper()
    {
        CreateMap<ELDEvents, ELDEventsServer>();
        //.ForMember(dest => dest.Id, opt => opt.Ignore()) // Exclude Id property
        //.ForMember(dest => dest.Unique_Id, opt => opt.Ignore()); // Exclude Unique_Id property
    }
}

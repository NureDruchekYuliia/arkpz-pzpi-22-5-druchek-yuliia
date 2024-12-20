using AutoMapper;
using SleepMonitor.Application.SleepRecords.Commands.AddSleepRecord;
using SleepMonitor.Application.SleepRecords.Commands.UpdateSleepRecord;
using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Application.SleepRecords.Dtos;

public class SleepRecordProfile : Profile
{
    public SleepRecordProfile() 
    {
        CreateMap<UpdateSleepRecordCommand, SleepRecord>();

        CreateMap<AddSleepRecordCommand, SleepRecord>();

        CreateMap<SleepRecord, SleepRecordDto>()
            .ForMember(d => d.Recommendations, opt => opt.MapFrom(src => src.SleepRecordRecommendations.Select(srr => srr.Recommendation)));
    }
}

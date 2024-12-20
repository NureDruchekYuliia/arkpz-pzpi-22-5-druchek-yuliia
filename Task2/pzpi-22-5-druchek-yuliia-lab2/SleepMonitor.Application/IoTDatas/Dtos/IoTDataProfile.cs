using AutoMapper;
using SleepMonitor.Application.IoTDatas.Commands.AddIoTData;
using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Application.IoTDatas.Dtos;

public class IoTDataProfile : Profile
{
    public IoTDataProfile()
    {
        CreateMap<AddIoTDataCommand, IoTData>();

        CreateMap<IoTData, IoTDataDto>();
    }
    
}

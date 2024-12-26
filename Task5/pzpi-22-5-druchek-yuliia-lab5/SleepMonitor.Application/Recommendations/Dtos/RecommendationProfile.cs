using AutoMapper;
using SleepMonitor.Application.Recommendations.Commands.AddRecommendation;
using SleepMonitor.Application.Recommendations.Commands.UpdateRecommendation;
using SleepMonitor.Domain.Entities;

namespace SleepMonitor.Application.Recommendations.Dtos;

public class RecommendationProfile : Profile
{
    public RecommendationProfile()
    {
        CreateMap<UpdateRecommendationCommand, Recommendation>();

        CreateMap<AddRecommendationCommand, Recommendation>();

        CreateMap<Recommendation, RecommendationDto>();
    }
}

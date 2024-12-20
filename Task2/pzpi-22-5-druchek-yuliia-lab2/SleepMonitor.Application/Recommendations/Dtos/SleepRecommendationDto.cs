using SleepMonitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepMonitor.Application.Recommendations.Dtos;

public class SleepRecommendationDto
{
    public Guid RecommendationId { get; set; }
    public RecommendationDto Recommendation { get; set; } = default!; 
    public DateTime DateCreated { get; set; } 

}

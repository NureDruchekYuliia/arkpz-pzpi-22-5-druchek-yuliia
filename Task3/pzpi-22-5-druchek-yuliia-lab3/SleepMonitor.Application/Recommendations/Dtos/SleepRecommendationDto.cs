using SleepMonitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepMonitor.Application.Recommendations.Dtos;

public class SleepRecommendationDto
{
    public Guid SleepRecordId { get; set; }
    public SleepRecord SleepRecord { get; set; } = default!;
    public Guid RecommendationId { get; set; }
    public Recommendation Recommendation { get; set; } = default!;

}

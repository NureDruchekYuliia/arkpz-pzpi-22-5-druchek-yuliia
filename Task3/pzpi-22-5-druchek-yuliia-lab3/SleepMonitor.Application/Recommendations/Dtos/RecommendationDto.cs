using SleepMonitor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepMonitor.Application.Recommendations.Dtos
{
    public class RecommendationDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SleepMonitor.Domain.Constants;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepMonitor.Infrastructure.Seeders;

internal class RecommendationSeeder(SleepMonitorDbContext dbContext) : IRecommendationSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Recommendations.Any())
            {
                var recommendations = GetRecommendations();
                dbContext.Recommendations.AddRange(recommendations);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private static IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new (UserRoles.User)
                {
                    NormalizedName = UserRoles.User.ToUpper(),
                },
                new (UserRoles.Admin)
                {
                    NormalizedName = UserRoles.Admin.ToUpper(),
                }

            ];
        return roles;
    }

    private static IEnumerable<Recommendation> GetRecommendations()
    {
        List<Recommendation> recommendations = [
            new()
            {
                Name = "High Noise Level",
                Description = "Noise levels during your sleep were higher than recommended. Consider using earplugs or a white noise machine to block out disruptive sounds."
            },
            new()
            {
                Name = "High Light Exposure",
                Description = "Excessive light exposure was detected during your sleep. Use blackout curtains or a sleep mask to block light and create a dark sleep environment."
            },
            new()
            {
                Name = "Short Sleep Duration",
                Description = "Your sleep duration was too short. Aim for at least 7-9 hours of sleep to allow your body and mind to fully recover."
            },
            new()
            {
                Name = "Long Sleep Duration",
                Description = "Your sleep duration exceeded 9 hours. Oversleeping can make you feel groggy and disrupt your natural sleep rhythm. Try maintaining a consistent sleep schedule."
            },
            new()
            {
                Name = "Low Sleep Quality",
                Description = "Your sleep quality was rated low. Try establishing a consistent bedtime routine, avoiding caffeine before bed, and reducing screen time in the evening."
            }
        ];

        return recommendations;
    }
}

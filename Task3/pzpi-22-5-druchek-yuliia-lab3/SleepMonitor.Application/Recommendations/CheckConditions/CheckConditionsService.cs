using MediatR;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Enums;
using SleepMonitor.Domain.Exceptions;
using SleepMonitor.Domain.Repositories;

namespace SleepMonitor.Application.Recommendations.CheckConditions;

internal class CheckConditionsService(ISleepRecordRepository sleepRecordRepository,
    IRecommendationRepository recommendationRepository) : ICheckConditionsService
{
    private static bool CheckConditions(SleepRecord sleepRecord, Recommendation recommendation)
    {
        var propertyName = recommendation.Property.ToString();
        var property = typeof(SleepRecord).GetProperty(propertyName)!;

        var actualValue = property.GetValue(sleepRecord);
        double comparisonValue;

        if (actualValue is double)
        {
            comparisonValue = (double)actualValue;
        }
        else if (actualValue is TimeSpan)
        {
            comparisonValue = ((TimeSpan)actualValue).TotalMinutes;
        }
        else if (actualValue is int)
        {
            comparisonValue = (int)actualValue;
        }
        else
        {
            return false;
        }

        if (recommendation.Comparison == ComparisonType.GreaterThan)
        {
            return comparisonValue >= recommendation.Value;
        }
        else if (recommendation.Comparison == ComparisonType.LessThan)
        {
            return comparisonValue <= recommendation.Value;
        }

        return false;
    }

    public async Task GenerateRecommendations(Guid id)
    {
        var sleepRecord = await sleepRecordRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(SleepRecord), id.ToString());

        var recommendations = await recommendationRepository.GetAllAsync();

        foreach (var rec in recommendations)
        {
            if (CheckConditions(sleepRecord, rec))
            {
                await recommendationRepository.AddToSleepRecord(rec, sleepRecord);
            }
        }

        await recommendationRepository.SaveChanges();
    }
}
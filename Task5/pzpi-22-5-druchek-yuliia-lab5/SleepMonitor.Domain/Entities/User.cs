using Microsoft.AspNetCore.Identity;
namespace SleepMonitor.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }

    public ICollection<SleepRecord>? SleepRecords { get; set; }
    public ICollection<IoTData>? IoTData { get; set; }
}

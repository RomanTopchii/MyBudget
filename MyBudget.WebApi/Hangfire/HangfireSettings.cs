namespace MyBudget.WebApi.Hangfire;

public record HangfireSettings
{
    public List<JobTiming> JobTimings { get; set; } = new();
};

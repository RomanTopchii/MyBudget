using Hangfire;
using MyBudget.WebApi.Jobs;

namespace MyBudget.WebApi.Hangfire;

public static class JobList
{
    public static void AddOrUpdate(List<JobTiming> timings)
    {
        RecurringJob.AddOrUpdate<ApplyApprovedTransactionsJob>(
            "Apply Approved Transactions",
            x => x.ExecuteAsync(),
            GetSchedule(timings, nameof(ApplyApprovedTransactionsJob)));
    }

    private static string GetSchedule(List<JobTiming> timings, string jobName) =>
        timings.Single(x => x.Name == jobName).Schedule;
}

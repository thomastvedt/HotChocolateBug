using System.Collections.ObjectModel;

namespace Server.GraphQL;

public class TimeZoneByIdDataloader : BatchDataLoader<int, Domain.TimeZone>
{
    public TimeZoneByIdDataloader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
    }

    protected override Task<IReadOnlyDictionary<int, Domain.TimeZone>> LoadBatchAsync(IReadOnlyList<int> timezoneIds, CancellationToken cancellationToken)
    {
        var result = new Dictionary<int, Domain.TimeZone>
            { { 1, new Domain.TimeZone() { Id = 1, Name = "Number one", KeyLinux = "asf", KeyWindows = "asdf" } } };
        IReadOnlyDictionary<int, Domain.TimeZone> temp = new ReadOnlyDictionary<int, Domain.TimeZone>(result);
        return Task.FromResult(temp);
    }
}
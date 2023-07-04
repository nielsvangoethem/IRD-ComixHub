using ComixHub.Core.Filters;
using ComixHub.Core.Models;
using ComixHub.Core.Services;
using ComixHub.Core.Settings;
using ComixHub.Infrastructure.Utils.FilterBuilders;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ComixHub.Infrastructure.Services
{
    public class ComicsService : IComicsService
    {
        private readonly IMongoCollection<Issue> _issues;

        public ComicsService(IOptions<ComixHubDatabaseSettings> ComixHubDataBaseSettings)
        {
            var mongoClient = new MongoClient(ComixHubDataBaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(ComixHubDataBaseSettings.Value.DatabaseName);
            _issues = mongoDb.GetCollection<Issue>(ComixHubDataBaseSettings.Value.IssuesCollectionName);
        }

        public async Task<(IEnumerable<Issue>, long total)> GetIssuesAsync(QueryParameters<IssueFilters> queryParameters)
        {
            var filter = new IssueFilterBuilder()
                                .WithTitle(queryParameters.Filters.Title)
                                .WithIssueNumber(queryParameters.Filters.IssueNumber)
                                .Build();

            var sortBuilder = Builders<Issue>.Sort;
            string sortBy = string.IsNullOrWhiteSpace(queryParameters.SortBy) ? "PublishDate" : queryParameters.SortBy;

            var sort = sortBy == "PublishDate" || queryParameters.SortDescending
                ? sortBuilder.Descending(sortBy)
                : sortBuilder.Ascending(sortBy);

            sort.Ascending("Title");

            var result = _issues.Find(filter)
                            .Sort(sort);

            return (await result
                            .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                            .Limit(queryParameters.PageSize)
                            .ToListAsync(), await result.CountDocumentsAsync());
        }

        public async Task<Issue> GetIssueAsync(string issueId)
        {
            return await _issues.Find(x => x.Id == issueId).FirstOrDefaultAsync();
        }
    }
}

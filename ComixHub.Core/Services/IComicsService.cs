using ComixHub.Core.Filters;
using ComixHub.Core.Models;

namespace ComixHub.Core.Services
{
    public interface IComicsService
    {
        public Task<(IEnumerable<Issue>, long total)> GetIssuesAsync(QueryParameters<IssueFilters> queryParameters);
        public Task<Issue> GetIssueAsync(string issueId);
    }
}

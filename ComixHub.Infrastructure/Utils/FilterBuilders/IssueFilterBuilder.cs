using ComixHub.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ComixHub.Infrastructure.Utils.FilterBuilders
{
    public class IssueFilterBuilder
    {
        private FilterDefinition<Issue> _filter;

        public IssueFilterBuilder()
        {
            _filter = Builders<Issue>.Filter.Empty;
        }

        public IssueFilterBuilder WithTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _filter &= Builders<Issue>.Filter.Regex(issue => issue.Title, new BsonRegularExpression(title, "i"));
            }

            return this;
        }

        public IssueFilterBuilder WithIssueNumber(int? issueNumber)
        {
            if (issueNumber.HasValue)
            {
                _filter &= Builders<Issue>.Filter.Eq("IssueNumber", issueNumber.Value);
            }

            return this;
        }

        public FilterDefinition<Issue> Build()
        {
            return _filter;
        }
    }

}

using ComixHub.Application.Issues.DTOs;
using ComixHub.Application.Issues.Queries.GetIssueById;
using ComixHub.Application.Issues.Queries.GetIssues;
using MediatR;

namespace ComixHub.Blazor.Data
{
    public class IssuesService
    {
        private readonly IMediator _mediator;

        public IssuesService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<(IEnumerable<IssueListItem>, long)> GetIssues(string title = null)
        {
            var result = await _mediator.Send(new GetIssuesQuery()
            {
                PageNumber = 1,
                PageSize = 25,
                Title = title
            });
            return (result.Items, result.Total);
        }

        public async Task<IssueDetailItem> GetIssue(string id)
        {
            return await _mediator.Send(new GetIssueByIdQuery() { Id = id });
        }
    }
}

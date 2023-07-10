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

        public async Task<(IEnumerable<IssueListItem>, int)> GetIssues(int pageNumber, int pageSize, string title = null)
        {
            var result = await _mediator.Send(new GetIssuesQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Title = title
            });
            return (result.Items, (int)result.Total);
        }

        public async Task<IssueDetailItem> GetIssue(string id)
        {
            return await _mediator.Send(new GetIssueByIdQuery() { Id = id });
        }
    }
}

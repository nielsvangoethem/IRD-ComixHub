using ComixHub.Blazor.Data;
using ComixHub.Application.Issues.DTOs;

namespace ComixHub.Blazor.Pages.Comics.Issues
{
    public partial class Issues
    {
        private IEnumerable<IssueListItem>? issues;

        protected override async Task OnInitializedAsync()
        {
            (issues, var total) = await IssuesService.GetIssues();
        }
    }
}
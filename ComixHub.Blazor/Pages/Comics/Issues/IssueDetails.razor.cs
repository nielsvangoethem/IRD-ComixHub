using ComixHub.Application.Issues.DTOs;
using ComixHub.Blazor.Data;
using Microsoft.AspNetCore.Components;

namespace ComixHub.Blazor.Pages.Comics.Issues
{
    public partial class IssueDetails
    {
        private IssueDetailItem? issue;

        [Parameter]
        public string Id { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            issue = await IssuesService.GetIssue(Id);
        }

        public void GoBack()
        {
            NavigationService.NavigateBack();
        }
    }
}
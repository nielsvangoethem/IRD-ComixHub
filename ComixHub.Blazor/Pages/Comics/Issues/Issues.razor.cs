using ComixHub.Blazor.Data;
using ComixHub.Application.Issues.DTOs;
using Microsoft.JSInterop;

namespace ComixHub.Blazor.Pages.Comics.Issues
{
    public partial class Issues
    {
        private IEnumerable<IssueListItem>? issues;
        private string? _titleFilter;
        public string? TitleFilter
        {
            get => _titleFilter;
            set
            {
                _titleFilter = value;
                _ = FetchIssues();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await FetchIssues();
        }

        private async Task FetchIssues()
        {
            (issues, var total) = await IssuesService.GetIssues(TitleFilter);
            StateHasChanged(); // Notify the component to re-render.
        }

        public async Task GoToTop()
        {
            await JSRuntime.InvokeVoidAsync("scrollToTop");
        }
    }
}
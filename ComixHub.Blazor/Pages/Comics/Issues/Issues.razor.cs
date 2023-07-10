using ComixHub.Blazor.Data;
using ComixHub.Application.Issues.DTOs;
using Microsoft.JSInterop;
using Radzen;

namespace ComixHub.Blazor.Pages.Comics.Issues
{
    public partial class Issues
    {
        private int _pageSize = 8;
        private int _currentPageNumber = 0;

        private IEnumerable<IssueListItem>? issues;
        private int? total;
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
            (issues, total) = await IssuesService.GetIssues(_currentPageNumber, _pageSize, _titleFilter);
            StateHasChanged(); // Notify the component to re-render.
        }

        private async Task PageChanged(PagerEventArgs args)
        {
            _currentPageNumber = args.PageIndex;
            await FetchIssues();
        }

        private void TitleFilterChanged(string value)
        {
            TitleFilter = value;
            StateHasChanged();
        }

        public async Task GoToTop()
        {
            await JSRuntime.InvokeVoidAsync("scrollToTop");
        }
        public void Dispose()
        {
            DebounceService.Dispose();
        }
    }
}
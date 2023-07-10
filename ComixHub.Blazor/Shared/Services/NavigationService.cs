using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;

namespace ComixHub.Blazor.Shared.Services
{
    public class NavigationService
    {
        private readonly NavigationManager _navigationManager;
        private string _previousUri;
        private string _currentUri;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _currentUri = _navigationManager.Uri;

            _navigationManager.LocationChanged += HandleLocationChanged;
        }

        public void NavigateTo(string uri)
        {
            _previousUri = _currentUri;
            _navigationManager.NavigateTo(uri);
        }

        public void NavigateBack()
        {
            _navigationManager.NavigateTo(_previousUri);
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            _previousUri = _currentUri;
            _currentUri = e.Location;
        }
    }

}

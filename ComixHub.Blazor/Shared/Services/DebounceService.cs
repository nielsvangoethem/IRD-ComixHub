namespace ComixHub.Blazor.Shared.Services
{
    public class DebounceService
    {
        private CancellationTokenSource _debounceCts = new CancellationTokenSource();

        public async Task Debounce(Action action, int delay = 300)
        {
            _debounceCts.Cancel(); // Cancel any previous ongoing debounce
            _debounceCts = new CancellationTokenSource();

            try
            {
                await Task.Delay(delay, _debounceCts.Token); // Wait for the specified delay
                action(); // Execute the function if the delay completes without being cancelled
            }
            catch (TaskCanceledException)
            {
                // A new debounce was started so we can safely ignore this exception
            }
        }

        public void Dispose()
        {
            _debounceCts.Dispose();
        }
    }
}

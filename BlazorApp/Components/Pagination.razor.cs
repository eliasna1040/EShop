using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public partial class Pagination
    {
        [Parameter]
        public int TotalPages { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }
        [Parameter]
        public int CurrentPage { get; set; }

        private async Task OnSelectedPage(int page)
        {
            await SelectedPage.InvokeAsync(page);
        }
    }
}

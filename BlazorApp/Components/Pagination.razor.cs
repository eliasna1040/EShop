using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public partial class Pagination
    {
        [Parameter]
        public Parameters Parameters { get; set; }
        [Parameter]
        public EventCallback<int[]> SelectedPage { get; set; }
        private List<Link> _links;
        private Link currentLink;

        protected override void OnParametersSet()
        {
            CreatePages();
        }

        private void CreatePages()
        {
            _links = new List<Link>() { new Link { PageText = "Forrige", PageValue = Parameters.CurrentPage-1, IsDisabled = Parameters.CurrentPage == 1} };

            for (int i = 1; i <= Parameters.TotalPages; i++)
            {
                _links.Add(new Link { PageValue = i, PageText = i.ToString(), IsActive = Parameters.CurrentPage == i });
            }

            _links.Add(new Link { PageText = "Næste", PageValue = Parameters.CurrentPage + 1, IsDisabled = Parameters.CurrentPage == Parameters.TotalPages });
        }

        private async Task OnSelectedPage(Link link, int pageSize)
        {
            if (link.IsActive || link.IsDisabled)
            {
                return;
            }
            currentLink = link;
            Parameters.CurrentPage = link.PageValue;
            await SelectedPage.InvokeAsync(new int[] { link.PageValue, link.PageValue });
        }

        private async Task OnChanged(int value)
        {
            Parameters.PageSize = value;
        }
    }
}

using Blazor.Corona.View.ViewModels;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazor.Corona.View.Home
{
    public class PagerComponent : ComponentBase
    {
        [Parameter]
        public PaginationModel Pagination { get; set; }

        [Parameter]
        public Action<int> PageChanged { get; set; }

        protected void PagerButtonClicked(int page)
        {
            PageChanged?.Invoke(page);
        }
    }
}

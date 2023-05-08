using BlazorApp.Components;
using BlazorApp.Models;
using Blazored.Modal;
using System.Net.Http.Json;

namespace BlazorApp.Pages.Admin
{
    public partial class Index
    {
        private Page<ProductModel> Products = new();
        private Parameters Parameters = new();

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int[] page)
        {
            Parameters.CurrentPage = page[0];
            Parameters.PageSize = page[1];
            await GetProducts();
        }

        private async Task GetProducts()
        {
            Products = (await client.GetFromJsonAsync<Page<ProductModel>>($"api/products?page={Parameters.CurrentPage}")) ?? new Page<ProductModel>();
            Parameters = new Parameters { CurrentPage = Products.CurrentPage, TotalPages = Products.PageCount };
        }

        private async Task AddShowModal()
        {
            var modalReference = modal.Show<AddProduct>("Tilføj produkt");
            var result = await modalReference.Result;

            if (result.Confirmed)
            {
                await OnInitializedAsync();
            }
        }

        private async Task EditShowModal(ProductModel product)
        {
            var modalReference = modal.Show<EditProduct>("Rediger produkt", new ModalParameters().Add(nameof(EditProduct.Product), product));
            var result = await modalReference.Result;

            if (result.Confirmed)
            {
                await OnInitializedAsync();
            }
        }

        private async Task DisableProduct(int id)
        {
            await client.PutAsync($"api/products/{id}", null);
            await OnInitializedAsync();
        }
    }
}

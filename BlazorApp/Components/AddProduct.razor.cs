using BlazorApp.Models;
using Blazored.Modal.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp.Components
{
    public partial class AddProduct
    {
        private AddProductModel product = new();
        private IBrowserFile? image = default;
        private List<CategoryModel>? categories = new();
        private List<ManufacturerModel>? manufacturers = new();
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;

        private void FileSelect(InputFileChangeEventArgs e)
        {
            image = e.File;
        }

        protected async override Task OnInitializedAsync()
        {
            categories = await client.GetFromJsonAsync<List<CategoryModel>>("api/categories");
            manufacturers = await client.GetFromJsonAsync<List<ManufacturerModel>>("api/manufacturers");
        }

        private async Task HandleSubmit()
        {
            if (image != null)
            {
                byte[] bytes = new byte[image.Size];
                await image.OpenReadStream().ReadAsync(bytes);
                product.Image = bytes;
            }

            await client.PostAsJsonAsync("api/Products", product);
            await BlazoredModal.CloseAsync(ModalResult.Ok(product));
        }
    }
}

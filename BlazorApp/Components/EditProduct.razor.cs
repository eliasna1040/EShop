using BlazorApp.Models;
using Blazored.Modal.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace BlazorApp.Components
{
    public partial class EditProduct
    {
        [Parameter]
        public ProductModel Product { get; set; }
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
            product = new(Product);
            categories = await client.GetFromJsonAsync<List<CategoryModel>>("api/categories");
            manufacturers = await client.GetFromJsonAsync<List<ManufacturerModel>>("api/manufacturers");
        }

        private async Task HandleSubmit()
        {
            JsonPatchDocument<AddProductModel> patchDocument = new JsonPatchDocument<AddProductModel>();

            if (image != null)
            {
                byte[] bytes = new byte[image.Size];
                await image.OpenReadStream().ReadAsync(bytes);
                product.Image = bytes;
                patchDocument.Replace(x => x.Image, product.Image);
            }

            if (Product.Name != product.Name)
            {
                patchDocument.Replace(x => x.Name, product.Name);
            }

            if (Product.Description != product.Description)
            {
                patchDocument.Replace(x => x.Description, product.Description);
            }

            if (Product.Price != product.Price)
            {
                patchDocument.Replace(x => x.Price, product.Price);
            }

            if (Product.CategoryId != product.CategoryId)
            {
                patchDocument.Replace(x => x.CategoryId, product.CategoryId);
            }

            if (Product.ManufacturerId != product.ManufacturerId)
            {
                patchDocument.Replace(x => x.ManufacturerId, product.ManufacturerId);
            }

            if (Product.Disabled != product.Disabled)
            {
                patchDocument.Replace(x => x.Disabled, product.Disabled);
            }

            await client.PatchAsJsonAsync($"api/products/{Product.ProductId}", patchDocument.Operations);
            await BlazoredModal.CloseAsync(ModalResult.Ok(product));
        }
    }
}

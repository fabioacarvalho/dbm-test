using System.Net.Http;
using System.Net.Http.Json;
using frontend.Models.ProductModels;
namespace frontend.Services.ProductServices;

public class ProductApiClient : IProductApiClient
{
    private readonly HttpClient _httpClient;

    public ProductApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://backend:5000/");
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");
        return product ?? new ProductDto();
    }

    public async Task<bool> AddProductAsync(ProductDto product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> UpdateProductAsync(int id, ProductDto product)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", product);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CreateProductAsync(CreateProductDto product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", product);
        return response.IsSuccessStatusCode;
    }
}
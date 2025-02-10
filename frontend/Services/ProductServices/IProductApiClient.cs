using frontend.Models.ProductModels;

namespace frontend.Services.ProductServices;

public interface IProductApiClient
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> UpdateProductAsync(int id, ProductDto product);
    Task<bool> CreateProductAsync(CreateProductDto product);
}
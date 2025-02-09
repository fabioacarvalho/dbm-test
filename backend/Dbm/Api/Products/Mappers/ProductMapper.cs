using Dbm.Api.Products.Dtos;
using Dbm.Core.Models;

namespace Dbm.Api.Products.Mappers;

public class ProductMapper : IProductMapper
{
    public ProductDetailResponse ToDetailResponse(Product product)
    {
        return new ProductDetailResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt
        };
    }

    public Product ToModel(ProductRequest request)
    {
        return new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };
    }

    public ProductSummaryResponse ToSummaryResponse(Product product)
    {
        return new ProductSummaryResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}
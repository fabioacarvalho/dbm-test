using Dbm.Api.Products.Dtos;
using Dbm.Core.Models;

namespace Dbm.Api.Products.Mappers;

public interface IProductMapper
{
    ProductSummaryResponse ToSummaryResponse(Product product);
    ProductDetailResponse ToDetailResponse(Product product);
    Product ToModel(ProductRequest request);
}
using Dbm.Api.Products.Dtos;

namespace Dbm.Api.Products.Services;
public interface IProductService
{
    ICollection<ProductSummaryResponse> FindAll();
    ProductDetailResponse FindById(int id);
    ProductDetailResponse Create(ProductRequest product);
    ProductDetailResponse Update(int id, ProductRequest product);
    void DeleteById(int id);
}

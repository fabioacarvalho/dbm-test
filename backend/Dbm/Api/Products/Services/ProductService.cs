using Dbm.Api.Products.Dtos;
using Dbm.Api.Products.Mappers;
using Dbm.Core.Repositories.Products;
using FluentValidation;

namespace Dbm.Api.Products.Services;

class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductMapper _productMapper;
    private readonly IValidator<ProductRequest> _productRequestValidator;

    public ProductService(
        IProductRepository productRepository, 
        IProductMapper productMapper, 
        IValidator<ProductRequest> productRequestValidator)
    {
        _productRepository = productRepository;
        _productMapper = productMapper;
        _productRequestValidator = productRequestValidator;
    }

    public ICollection<ProductSummaryResponse> FindAll()
    {
        return _productRepository.FindAll()
            .Select(product => _productMapper.ToSummaryResponse(product))
            .ToList();
    }

    public ProductDetailResponse FindById(int id)
    {
        var product = _productRepository.FindById(id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return _productMapper.ToDetailResponse(product);
    }

    public ProductDetailResponse Create(ProductRequest product)
    {
        _productRequestValidator.ValidateAndThrow(product);

        var productToCreate = _productMapper.ToModel(product);
        var createdProduct = _productRepository.Create(productToCreate);
        return _productMapper.ToDetailResponse(createdProduct);
    }

    public ProductDetailResponse Update(int id, ProductRequest product)
    {
        _productRequestValidator.ValidateAndThrow(product);
        if (!_productRepository.ExistsById(id))
        {
            throw new Exception("Product not found");
        }
        var productToUpdate = _productMapper.ToModel(product);
        productToUpdate.Id = id;
        var updatedProduct = _productRepository.Update(productToUpdate);
        return _productMapper.ToDetailResponse(updatedProduct);
    }

    public void DeleteById(int id)
    {
        if (!_productRepository.ExistsById(id))
        {
            throw new Exception("Product not found");
        }
        _productRepository.DeleteById(id);
    }
}
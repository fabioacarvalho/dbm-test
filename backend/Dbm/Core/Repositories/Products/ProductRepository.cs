using Dbm.Core.Data.Contexts;
using Dbm.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dbm.Core.Repositories.Products;

class ProductRepository : IProductRepository
{
    private readonly DbmDbContext _context;

    public ProductRepository(DbmDbContext context)
    {
        _context = context;
    }

    Product ICrudRepository<Product, int>.Create(Product model)
    {
        _context.Products.Add(model);
        _context.SaveChanges();
        return model;
    }
    Product ICrudRepository<Product, int>.Update(Product model)
    {
        _context.Products.Update(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Products.Any(p => p.Id == id);
    }

    ICollection<Product> ICrudRepository<Product, int>.FindAll()
    {
        return _context.Products.AsNoTracking().ToList();
    }

    Product? ICrudRepository<Product, int>.FindById(int id)
    {
        return _context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }
}
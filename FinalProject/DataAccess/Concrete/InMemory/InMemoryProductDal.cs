using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal
{
    private List<Product> _products;

    public InMemoryProductDal()
    {
        _products = new List<Product>()
        {
            new Product() { CategoryId = 1, ProductId = 1, ProductName = "Bardak", UnitPrice = 14, UnitsInStock = 55 },
            new Product()
                { CategoryId = 1, ProductId = 2, ProductName = "telefon", UnitPrice = 1400, UnitsInStock = 15 },
            new Product() { CategoryId = 2, ProductId = 3, ProductName = "Klavye", UnitPrice = 350, UnitsInStock = 5 },
            new Product() { CategoryId = 2, ProductId = 4, ProductName = "fare", UnitPrice = 45, UnitsInStock = 3 },
            new Product() { CategoryId = 2, ProductId = 5, ProductName = "Monitor", UnitPrice = 450, UnitsInStock = 1 },
        };
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(p => p.CategoryId == categoryId).ToList();
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Delete(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        _products.Remove(productToDelete);
    }

    public void Update(Product product)
    {
        Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitsInStock = product.UnitsInStock;
    }

    public List<ProductDetailDto> GetProductDetail()
    {
        throw new NotImplementedException();
    }
}
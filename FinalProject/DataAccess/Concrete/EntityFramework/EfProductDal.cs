using System.Linq.Expressions;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetail()
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var result = from p in context.Products
                         join c in context.Categories on p.ProductId equals c.CategoryId
                         select new ProductDetailDto()
                         {
                             CategoryName = c.CategoryName,
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             UnitInStock = p.UnitsInStock
                         };
            return result.ToList();
        }
    }
}
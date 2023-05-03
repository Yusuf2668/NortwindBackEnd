using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<Product> GetById(int productId);
    IDataResult<List<Product>> GetAll();
    IDataResult<List<ProductDetailDto>> GetProductDetail();
    IResult Add(Product product);
    IResult AddTransactionalTest(Product product);
    IResult Update(Product product);
    IDataResult<List<Product>> GetByCategoryId(int categoryId);
}
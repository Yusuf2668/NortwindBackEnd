using System.Diagnostics;
using System.Reflection;
using Business.Abstract;
using Business.BusinessAspect.AutoFact;
using Business.Constans;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Chaching;
using Core.Aspect.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    private ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }

    [CacheAspect()]
    public IDataResult<Product> GetById(int ProductId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == ProductId));
    }

    [CacheAspect()]
    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll());
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetail()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
        var result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
              CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckCategoryLimitExceded());

        if (result != null) return new Result(result.Success, result.Message);

        _productDal.Add(product);
        return new Result(true, Messages.ProductAdded);

    }

    public IResult AddTransactionalTest(Product product)
    {
        throw new NotImplementedException();
    }

    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Product>> GetByCategoryId(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId).ToList());
    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
        if (result >= 10)
        {
            return new ErrorResult("Aynı kategoriye ait iki tane ürün eklenemez");
        }
        return new SuccessResult();
    }

    private IResult CheckIfProductNameExist(string produtName)
    {
        var result = _productDal.GetAll(p => p.ProductName == produtName).Any();
        if (result)
        {
            return new SuccessResult(Messages.ProductNameAlreadyExists);
        }

        return new ErrorResult();
    }

    private IResult CheckCategoryLimitExceded()
    {
        var result = _categoryService.GetAll();
        if (result.Data.Count > 15)
        {
            return new ErrorResult(Messages.CategoryLimitedExceded);
        }

        return new SuccessResult();
    }
}
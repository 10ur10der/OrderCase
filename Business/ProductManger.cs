using Core.Utilities.Results;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductManger : IProductService
    {

        private IProductDal _productDal;

        public ProductManger(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception ex)
            {
                return new SuccessResult(ex.Message);
            }
            
        }
  
        public IDataResult<Product> GetById(string productode)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductCode == productode));
        }
    }
}

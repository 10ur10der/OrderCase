using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductService
    {
        //IDataResult GetStock(int productID);

        IDataResult<Product> GetById(string productCode);
        IResult Add(Product product);

    }
}

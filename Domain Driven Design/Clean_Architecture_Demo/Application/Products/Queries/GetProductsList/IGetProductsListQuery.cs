using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
        List<ProductModel> Execute();
    }
}

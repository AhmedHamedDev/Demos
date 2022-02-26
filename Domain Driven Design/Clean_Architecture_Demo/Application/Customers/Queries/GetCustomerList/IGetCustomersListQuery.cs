using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomerList
{
    public interface IGetCustomersListQuery
    {
        List<CustomerModel> Execute();
    }
}

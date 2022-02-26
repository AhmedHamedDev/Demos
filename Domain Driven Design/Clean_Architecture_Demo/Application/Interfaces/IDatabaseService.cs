using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Sale> Sales { get; set; }

        void Save();
    }
}

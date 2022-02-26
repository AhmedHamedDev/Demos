﻿using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
    }
}

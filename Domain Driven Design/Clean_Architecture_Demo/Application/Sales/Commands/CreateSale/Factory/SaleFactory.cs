using Domain.Customers;
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
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new Sale();

            sale.Date = date;

            sale.Customer = customer;

            sale.Employee = employee;

            sale.Product = product;

            sale.UnitPrice = sale.Product.Price;

            sale.Quantity = quantity;

            // Note: Total price is calculated in domain logic

            return sale;
        }
    }
}

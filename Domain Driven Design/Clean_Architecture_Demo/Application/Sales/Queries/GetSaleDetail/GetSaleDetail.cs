using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Queries.GetSaleDetail
{
    public class SaleDetailModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

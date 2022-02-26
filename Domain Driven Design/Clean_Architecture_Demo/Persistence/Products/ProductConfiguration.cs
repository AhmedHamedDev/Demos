using Domain.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);
        }
    }
}

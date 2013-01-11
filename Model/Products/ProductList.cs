using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Products
{
    public class ProductList
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public string QuantityPerUnit { set; get; }
        public decimal? UnitPrice { set; get; }
        public short? UnitsInStock { set; get; }
    }
}

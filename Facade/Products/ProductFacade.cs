using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Facade.Base;
using IService.IProducts;
using Model.Products;

namespace Facade.Products
{
    public class ProductFacade : FacadeBase
    {
        private readonly IProductService _productService;
        public ProductFacade()
        {
            _productService = GetApplicationContext().GetObject("ProductService") as IProductService;

        }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns>是否成功</returns>
        public List<ProductList> GetAllProducts()
        {
            List<ProductList> productList=new List<ProductList>();
            List<Product> products = new List<Product>();
            try
            {
                products = _productService.GetAllProducts();
            }
            catch (Exception e)
            {
                //LogHelper.WriteLog("ArticleServiceImpl.AddArticle()异常", e);
                return productList;
            }
            foreach (var product in products)
            {
                ProductList productlist=new ProductList();
                productlist.Id = product.Id;
                productlist.ProductName = product.ProductName;
                productlist.QuantityPerUnit = product.QuantityPerUnit;
                productlist.UnitPrice = product.UnitPrice;
                productlist.UnitsInStock = product.UnitsInStock;
                productList.Add(productlist);
            }
            return productList;
        }
    }
}

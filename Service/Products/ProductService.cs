using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.common;
using IDAO;
using Domain.Entity;
using IService.IProducts;

namespace Service.Products
{
    public class ProductService : IProductService
    {
        private IProductDao ProductDao { get; set; }
        private ILogHelper LogHelper { get; set; }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns>是否成功</returns>
        public List<Product> GetAllProducts()
        {
            List<Product> productlist=new List<Product>();
            try
            {
                productlist=ProductDao.GetAllProduct();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("ProductService.GetAllProducts()异常", e);
                return productlist;
            }
            return productlist;
        }
    }
}

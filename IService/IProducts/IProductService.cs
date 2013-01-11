using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace IService.IProducts
{
    public interface IProductService
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns>是否成功</returns>
        List<Product> GetAllProducts();
    }
}

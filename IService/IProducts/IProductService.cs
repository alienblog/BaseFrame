using System.Collections.Generic;
using Domain.Entity;

namespace IService.IProducts
{
    public interface IProductService 
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();
    }
}

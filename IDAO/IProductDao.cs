using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Entity;
 

namespace IDAO
{
    public interface IProductDao
    {
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProduct();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Entity;
 

namespace IDAO
{
    public interface IProductDao
    {
        /// <summary>
        /// ��ȡ���в�Ʒ
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProduct();
    }
}

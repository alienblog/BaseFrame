using System.Collections.Generic;
using Model.Products;

namespace ISegregate.IProducts
{
    public interface IProductSeg
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        List<ProductList> GetAllProducts();
    }
}

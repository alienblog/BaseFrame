using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.common;
using IDAO;
using Domain.Entity;
using DAO.Hibernate.common;
using Spring.Data.NHibernate.Generic;


namespace DAO.Hibernate
{
    public class ProductDao : IProductDao
    {
        private ILogHelper LogHelper { get; set; }
        private IDaoHelp<Product, int> HibernateDaoHelp { get; set; }
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {
            List<Product> products=new List<Product>();
            try
            {
                products = HibernateDaoHelp.Find("from Product");
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("ProductDao.GetAllProducts()异常", e);
            }
            return products;
        } 
    }
}

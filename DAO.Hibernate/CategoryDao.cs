using System;
using System.Collections;
using System.Collections.Generic;
using IDAO;
using Domain.Entity;
using Domain.common;
using DAO.Hibernate.common;

 

namespace DAO.Hibernate
{
    public class CategoryDao :ICategoryDao
    {
        private ILogHelper LogHelper { get; set; }
        private IDaoHelp< Category, int> HibernateDaoHelp { get; set; }
    }
}

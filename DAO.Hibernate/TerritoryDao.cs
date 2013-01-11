using System;
using System.Collections;
using System.Collections.Generic;
using IDAO;
using Domain.Entity;
using Domain.common;
using DAO.Hibernate.common;

 

namespace DAO.Hibernate
{
    public class TerritoryDao :ITerritoryDao
    {
        private ILogHelper LogHelper { get; set; }
        private IDaoHelp< Territory, int> HibernateDaoHelp { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using IDAO;
using Domain.Entity;
using Domain.common;
using DAO.Hibernate.common;

 

namespace DAO.Hibernate
{
    public class CustomerDao :ICustomerDao
    {
        private ILogHelper LogHelper { get; set; }
        private IDaoHelp< Customer, int> HibernateDaoHelp { get; set; }
    }
}

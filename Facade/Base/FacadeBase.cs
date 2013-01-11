using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Domain.common;
using Domain.common;
using Spring.Context;
using Spring.Context.Support;

namespace Facade.Base
{
    public  class FacadeBase
   {
       private static IApplicationContext _applicationContext;

       public static IApplicationContext GetApplicationContext()
       {
           try
           {
               if (_applicationContext == null)
               {
                   //log4net.Config.XmlConfigurator.Configure();
                   _applicationContext = ContextRegistry.GetContext();
               }
           }
           catch (Exception ex)
           {
               //LogHelper.WriteLog("GetApplicationContext异常：", ex);
               throw;
           }
           return _applicationContext;
       }
    }
}

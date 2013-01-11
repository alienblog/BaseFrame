using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facade.Base;
using IService.ICommon;
using IService.IProducts;

namespace Facade.Common
{
    public class LogFacade: FacadeBase
    {
        private readonly ILogService _logService;
        public LogFacade()
        {
            _logService = GetApplicationContext().GetObject("LogService") as ILogService;

        }
        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(string info)
        {
            _logService.WriteLog(info);
        }
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public void WriteLog(string info, Exception se)
        {
            _logService.WriteLog(info, se);
        }
    }
}

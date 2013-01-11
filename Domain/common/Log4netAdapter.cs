using System;
using System.IO;

namespace Domain.common
{
    /**/
    /// <summary>  
    /// LogHelper的摘要说明。   
    /// </summary>   
    public class Log4netAdapter : ILogHelper
    {
        private Log4netAdapter()
        {
            SetConfig(new FileInfo("~/Config/log4net_local.config"));
        }

        /// <summary>
        /// 静态只读实体对象info信息
        /// </summary>
        public static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("loginfo");
        /// <summary>
        ///  静态只读实体对象error信息
        /// </summary>
        public static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("logerror");
        /// <summary>
        /// 默认加载配置文件信息
        /// </summary>
        public void SetConfig()
        {

            log4net.Config.XmlConfigurator.Configure();

        }
        /// <summary>
        /// 根据文件加载配置信息
        /// </summary>
        /// <param name="configFile"></param>
        public void SetConfig(FileInfo configFile)
        {

            log4net.Config.XmlConfigurator.Configure(configFile);

        }

        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        public void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }

        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public void WriteLog(string info, Exception se)
        {
            if (Logerror.IsErrorEnabled)
            {
                Logerror.Error(info, se);
            }
        }
    }
}
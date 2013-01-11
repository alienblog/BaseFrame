using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain.common
{
    public interface ILogHelper
    {
        /// <summary>
        /// 默认加载配置文件信息
        /// </summary>
        void SetConfig();
        /// <summary>
        /// 根据文件加载配置信息
        /// </summary>
        /// <param name="configFile"></param>
        void SetConfig(FileInfo configFile);
        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        void WriteLog(string info);
        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        void WriteLog(string info, Exception se);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataGridViewSamples
{
    class ConfigReader
    {
        private ConfigReader()
        {
        }

        /// <summary>
        /// 读取默认配置文件的指定节点
        /// 这里只处理字符串类型的节点
        /// </summary>
        /// <param name="key">要读取的配置节点key</param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return Properties.Settings.Default[key].ToString();
        }

        public static void SetConfig(string key, object value)
        {
            // TODO:
            Properties.Settings.Default[key] = value;
        }
    }
}

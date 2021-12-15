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
        /// ��ȡĬ�������ļ���ָ���ڵ�
        /// ����ֻ�����ַ������͵Ľڵ�
        /// </summary>
        /// <param name="key">Ҫ��ȡ�����ýڵ�key</param>
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

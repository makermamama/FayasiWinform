using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace WpfSlovo.db
{
    //数据库帮助类
    class AccessDbHelp
    {
        private static string ConServerStr  = null;
        //获取连接字符串
        private static String ConnectString()
        {
            String Path = AppDomain.CurrentDomain.BaseDirectory + "sql.txt";
            String ConServerStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\";
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            string content;
            while ((content = sr.ReadLine()) != null)
            {
                ConServerStr += content.ToString();
            }
            return ConServerStr;
        }

        public static String GetConnectString()
        {
            if (ConServerStr == null)
                ConServerStr = ConnectString();
            return ConServerStr;
        }
    }
}

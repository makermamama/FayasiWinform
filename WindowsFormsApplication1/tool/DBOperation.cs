using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public class DBOperation
    {
        public static OleDbConnection sqlCon;  //用于连接数据库 

        static string ConServerStr = "";

        private const String BoxStatusOne = "未上传";

        private const String BoxStatusTwo = "已上传";

        ///构造函数
        public DBOperation()
        {
            if (sqlCon == null)
            {
                ConServerStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\";
                ReadTxtContent(AppDomain.CurrentDomain.BaseDirectory + "sql.txt");
                sqlCon = new OleDbConnection();
                sqlCon.ConnectionString = @ConServerStr;
                sqlCon.Open();
            }
            else if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.ConnectionString = @ConServerStr;
                sqlCon.Open();
            }
        }

        ///构造函数
        public String  TestCreatTable(String  msg)
        {
            String result = "";
            try
            {
                OleDbCommand command = new OleDbCommand(msg, sqlCon);

                result = command.ExecuteNonQuery().ToString();

                if (result == "1")
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 增加一个箱号
        /// </summary>
        /// <param name="boxId">号</param>
        /// <returns></returns>
        public Boolean AddBoxs(Guid Id)
        {
            String result = "";
            OleDbCommand command = new OleDbCommand();
            command.Connection = sqlCon;

            try
            {
                String sql = String.Format("INSERT INTO [Box] ([FGuid],[FStatus]) Values('{0}','{1}')", Id, BoxStatusOne);
                command.CommandText = sql;

                result = command.ExecuteNonQuery().ToString();

                if (result == "-1")
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        /// <summary>
        /// 插入30条采集数据
        /// </summary>
        /// <returns></returns>
        public void CreatBoxOrder(Guid BoxGUID,HashSet<String> CapData)
        {
            OleDbCommand command = new OleDbCommand();

            command.Connection = sqlCon;
            
            try
            {
                foreach (String bean in CapData)
                {
                    String sqlCase = String.Format("INSERT INTO [Case] ([FGuid],[FCapData],[FBoxId],[Captime]) Values('{0}','{1}','{2}','{3}')", Guid.NewGuid().ToString(),bean, BoxGUID.ToString(), DateTime.Now.ToString());

                    command.CommandText = sqlCase;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查询未上传的箱号
        /// </summary>
        /// <returns></returns>
        public DataSet QueryNoUplaodBox()
        {

            try
            {
                DataSet ds = new DataSet();
                try
                {
                    String sql_box = String.Format("select [ID],[FGuid] from [Box] where [FStatus] = '{0}'", BoxStatusOne);

                    OleDbDataAdapter da = new OleDbDataAdapter(sql_box, sqlCon);

                    da.Fill(ds);

                    return ds;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                //myTrans.Rollback();
                throw ex;
            }
        }
        /// <summary>
        /// 更新上传箱号状态
        /// </summary>
        /// <returns></returns>
        public Boolean UploadBoxTStatus(String BoxId)
        {
            try
            {
                String sql_box = String.Format("Update [Box] set  [FStatus] = '{0}' where [FGuid]  = '{1}'", BoxStatusTwo, BoxId);

                OleDbCommand command = new OleDbCommand(sql_box, sqlCon);

                String result = command.ExecuteNonQuery().ToString();

                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 获取需要上传的采集数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetUploadCase(String BoxId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                String sql_box = String.Format("select [FCapData] from [Case] where [FBoxId] = '{0}'",  BoxId);

                OleDbDataAdapter da = new OleDbDataAdapter(sql_box, sqlCon);

                da.Fill(dataSet);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private void ReadTxtContent(string Path)
        {
            StreamReader sr = new StreamReader(Path, Encoding.Default);

            string content;

            while ((content = sr.ReadLine()) != null)
            {
                ConServerStr += content.ToString();
            }
        }

        ///析构函数 
        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}
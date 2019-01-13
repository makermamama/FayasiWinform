using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using TestForms.Http;
using WindowsFormsApplication1.http.bean;
using WindowsFormsApplication1.tool;
using WpfSlovo;
using WpfSlovo.db;


namespace LZ.WpfSlovo.db.Access
{
    class AccessDB
    {
        private static String BoxStatusNoUp = "未上传";
        private static String BoxStatusHaveUp = "已上传";
        private static OleDbConnection cn;
        private static OleDbConnection cnOne;

        /// <summary>
        /// 生成一张箱单
        /// </summary>
        /// <param name="boxId">箱号</param>
        /// <returns></returns>
        public static void  CreatBoxOrder(HashSet<String> data,String Id)
        {
            OleDbConnection connection = GetConnection(AccessDbHelp.GetConnectString());
            OleDbTransaction transaction = connection.BeginTransaction();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                String sqlBox = String.Format("INSERT INTO [Box] ([FGuid],[FStatus]) Values('{0}','{1}')", Id, BoxStatusNoUp);
                cmd.CommandText = sqlBox;
                cmd.ExecuteNonQuery();

                foreach (String bean in data)
                {
                    String sqlCase = String.Format("INSERT INTO [Case] ([FGuid],[FCapData],[FBoxId],[Captime]) Values('{0}','{1}','{2}','{3}')", Guid.NewGuid().ToString(), bean, Id, DateTime.Now.ToString());
                    cmd.CommandText = sqlCase;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public static DataSet QueryNoUplaodBox()
        {
            OleDbConnection connection = GetConnection(AccessDbHelp.GetConnectString());
            try
            {
                DataSet ds = new DataSet();
                String sql_box = String.Format("select [ID],[FGuid] from [Box] where [FStatus] = '{0}'", BoxStatusNoUp);
                OleDbDataAdapter da = new OleDbDataAdapter(sql_box, connection);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// 上传一个箱号
        /// </summary>
        /// <param name="boxId">箱号</param>
        /// <returns></returns>
        public static String UpDataOne(String  BoxNum)
        {
            QRBean  BoxNumber = QRanalyze.QRDecod(BoxNum.Substring(BoxNum.Length - 35,35));
            OleDbConnection connection = GetConnectionOne(AccessDbHelp.GetConnectString());
            OleDbTransaction transaction = connection.BeginTransaction();
            try
            {
                //找出最小未装箱的最小箱号
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                String sqlBox = String.Format("SELECT FGuid from BOX where ID = (select min(ID) from BOX Where FStatus = '{0}')",BoxStatusNoUp);
                cmd.CommandText = sqlBox;
                Object boxGuid = cmd.ExecuteScalar();
                String BoxGuid;
                if (boxGuid == null)
                {
                    throw new Exception("没有可以使用箱");
                }
                else
                {
                    BoxGuid = boxGuid.ToString();
                }
                
                //生成装箱上传数据 
                DataSet dataSet = new DataSet(); 
                String sql_box = String.Format("select [FCapData] from [Case] where [FBoxId] = '{0}'", BoxGuid);
                OleDbDataAdapter da = new OleDbDataAdapter(sql_box, connection);
                da.SelectCommand.Transaction = transaction;
                da.Fill(dataSet);

                UploadData uploadData = new UploadData();
                uploadData.tempDelId = BaseData.TempId;
                uploadData.parentCode = BoxNumber;

                foreach (DataRow Row in dataSet.Tables[0].Rows)
                {
                     String msg  = Row["FCapData"].ToString();
                     uploadData.childCodes.Add(QRanalyze.QRDecod(msg.Substring(msg.Length-35,35)));
                }

                RelationResult result = JsonConvert.DeserializeObject<RelationResult>(HttpRequest.UploadCapData(uploadData, Session.Id));
                //RelationResult result = new RelationResult();
                //result.success = true;
                if (result.success)
                {
                    String sqlUp = String.Format("Update [Box] set [FStatus] = '{0}',[FBoxNumber] = '{1}' where [FGuid]  = '{2}'", BoxStatusHaveUp, BoxNum, BoxGuid);
                    cmd.CommandText = sqlUp;
                    cmd.ExecuteNonQuery();
                }
                else {
                    throw new Exception(result.message);
                }
                transaction.Commit();
                return BoxGuid;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNowTime()
        {
            try
            {
                DateTime dt = DateTime.Now;

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="ConnectionToString"></param>
        /// <returns></returns>
        private static OleDbConnection GetConnection(String ConnectionToString)
        {
            if (cn == null)
                cn = new OleDbConnection(ConnectionToString);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();

            }
            return cn;
        }


        private static OleDbConnection GetConnectionOne(String ConnectionToString)
        {
            if (cnOne == null)
                cnOne = new OleDbConnection(ConnectionToString);

            if (cnOne.State == ConnectionState.Closed)
            {
                cnOne.Open();

            }
            return cnOne;
        }


    }
}

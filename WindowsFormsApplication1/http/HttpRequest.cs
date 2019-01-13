using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using TestForms.Http;
using WindowsFormsApplication1.http.bean;

namespace WpfSlovo
{
    class HttpRequest
    {
        const String baseUri = "http://e3.sun-tech.cn/fayasi";

        public static Boolean Login(String name, String password)
        {
            try
            {
                Login login = new Login();

                login.userName = name;

                login.passWord = password;

                string serviceAddress = baseUri +"/a/login";

                String result = PostRequst(serviceAddress, JsonConvert.SerializeObject(login));

                JObject jObject = JObject.Parse(result);

                //解析josn
                String Result = jObject["success"].ToString();

                if (Convert.ToBoolean(Result))
                {
                    String sessionid = jObject["data"]["sessionid"].ToString();

                    Session.Id = sessionid;

                    return true;
                }
                else
                {
                    LoginErrorReslut errorReslut =  JsonConvert.DeserializeObject<LoginErrorReslut>(result);

                    throw new Exception(errorReslut.message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LoginOut(String name, String password)
        {
            try
            {
                string serviceAddress = baseUri + "/a/logout";

                GetRequst(serviceAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取关联模板集合
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="cookId"></param>
        /// <returns></returns>
        public static String GetTemplates(QRBean bean,String cookId)
        {
            try
            {
                string serviceAddress = baseUri + "/a/unit/template/unitTemp/vctp";

                serviceAddress += String.Format("?vid={0}&cid={1}&tid={2}&pid={3}", bean.vid, bean.cid, bean.tid, bean.pid);

                return GetRequst(serviceAddress, cookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取模板明细
        /// </summary>
        /// <param name="tempDelId"></param>
        /// <param name="cookId"></param>
        /// <returns></returns>
        public static String GetTemplateInfo(String tempDelId, String cookId)
        {
            try
            {
                string serviceAddress = baseUri + "/a/unit/template/unitTempDel/detail";

                serviceAddress += @"/" + tempDelId;

                return GetRequst(serviceAddress, cookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 验证下级码值是否符合关联
        /// </summary>
        /// <param name="tempDelId"></param>
        /// <param name="cookId"></param>
        /// <returns></returns>
        public static String ConfirmLowerCodeRelation(QRBean bean, String cookId)
        {
            try
            {
                string serviceAddress = baseUri + "/a/erp/related/manual/validate/child";

                serviceAddress += String.Format("?vid={0}&cid={1}&tid={2}&pid={3}", bean.vid, bean.cid, bean.tid, bean.pid); ;

                return GetRequst(serviceAddress, cookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 验证上级码值是否符合关联
        /// </summary>
        /// <param name="tempDelId"></param>
        /// <param name="cookId"></param>
        /// <returns></returns>
        public static String ConfirmSuperCodeRelation(QRBean bean, String cookId)
        {
            try
            {
                string serviceAddress = baseUri + "/a/erp/related/manual/validate/parent";

                serviceAddress += String.Format("?vid={0}&cid={1}&tid={2}&pid={3}", bean.vid, bean.cid, bean.tid, bean.pid); ;

                return GetRequst(serviceAddress, cookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 上传采集数据
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="cookId"></param>
        /// <returns></returns>
        public static String UploadCapData(UploadData data, String cookId)
        {
            try
            {
                string serviceAddress = baseUri + "/a/erp/related/manual";

                return PostRequst(serviceAddress, JsonConvert.SerializeObject(data), cookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// post请求,无授权
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <param name="strContent"></param>
        private static String PostRequst(String serviceAddress, String strContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";

            request.ContentType = "application/json";

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string encoding = response.ContentEncoding;

            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            return reader.ReadToEnd();
        }



        /// <summary>
        /// post请求,需要授权
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <param name="strContent"></param>
        private static String PostRequst(String serviceAddress, String strContent, String cookieId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";

            request.ContentType = "application/json";

            request.Headers.Add("X-Api-Version", "1");

            request.Headers.Add("Device-Type", "PDA");

            CookieContainer cookie = new CookieContainer();

            cookie.Add(new Uri(baseUri), new Cookie("suntech.session.id", cookieId));

            request.CookieContainer = cookie;

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);

                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;

            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            return reader.ReadToEnd();
        }

        /// <summary>
        /// GET请求,无需授权
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        private static String GetRequst(String serviceAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "GET";

            request.ContentType = "application/json";

            request.Headers.Add("X-Api-Version", "1");

            request.Headers.Add("Device-Type", "PDA");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string encoding = response.ContentEncoding;

            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            return reader.ReadToEnd();
        }



        /// <summary>
        /// get请求,需要授权
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <param name="cookieId"></param>
        /// <returns></returns>
        private static String GetRequst(String serviceAddress, String cookieId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "GET";

            request.ContentType = "application/json";

            request.Headers.Add("X-Api-Version", "1");

            request.Headers.Add("Device-Type", "PDA");

            CookieContainer cookie = new CookieContainer();

            cookie.Add(new Uri(baseUri), new Cookie("suntech.session.id", cookieId));

            request.CookieContainer = cookie;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string encoding = response.ContentEncoding;

            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            return reader.ReadToEnd();
        }

    }
}

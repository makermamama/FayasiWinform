using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TestForms.Http
{

    class QRBean
    {
        public  String vid;

        public String  cid;

        public String tid;

        public String pid;
    }

    class QRanalyze
    {
        [DllImport("lzym_2dbc_decrypt.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int suntech_2d_code_string_decrypt(byte* input_str, byte* output_str);

        public static String QRConvert(String msg)
        {

            byte[] intput = System.Text.Encoding.Default.GetBytes(msg);

            byte[] output = new byte[128];

            unsafe
            {
                byte* cptr = stackalloc byte[intput.Length + 1];

                for (int i = 0; i < intput.Length; i++)
                {
                    cptr[i] = (byte)intput[i];
                }

                cptr[35] = (byte)0;

                byte* output_str = stackalloc byte[intput.Length];

                int result = suntech_2d_code_string_decrypt(cptr, output_str);

                int j = 0;

                while (*output_str != 0)
                {
                    output[j++] = *output_str++;
                }
            }
            return Encoding.Default.GetString(output).TrimEnd('\0');
        }

        public static QRBean QRDecod(String QRmsg)
        {

            string[] data = QRConvert(QRmsg).Split('=');

            string[] QRBeandata = data[1].Split('-');

            QRBean bean = new QRBean();

            bean.vid = QRBeandata[0];
            bean.cid = QRBeandata[1];
            bean.tid = QRBeandata[2];
            bean.pid = QRBeandata[3];

            return bean;
        }

        public static String QRDecod16(String QRmsg)
        {

            string[] data = QRConvert(QRmsg).Split('=');

            string[] QRBeandata = data[1].Split('1');

            QRBean bean = new QRBean();

            String vid = QRBeandata[0];
            String cid = QRBeandata[1];
            String tid = QRBeandata[2];
            String pid = QRBeandata[3];
            return vid + cid + tid + pid;
        }

        public static String QRDecod_Pid(String QRmsg)
        {
            string[] data = QRConvert(QRmsg).Split(' ');

            String msg = data[2].Substring(4, data[2].Length - 4);

            msg += Convert.ToInt32(data[3].Substring(4, data[3].Length - 4)).ToString();

            return msg;
        }
    }
}

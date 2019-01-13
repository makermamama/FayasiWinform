using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.http.bean
{

    class Session
    {
        public static String Id;
    }

    class Login
    {
        public String userName;

        public String passWord;
    }

    class LoginErrorReslut
    {
        public String success;

        public String resultCode;

        public String message;

        public String data;

        public String timestamp;
    }





}

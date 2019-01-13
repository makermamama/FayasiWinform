using System;
using System.Collections.Generic;


namespace WindowsFormsApplication1.http.bean
{


    class TemplateInfoResult
    {
        public Boolean success;
        public String resultCode;
        public String message;
        public TemplateInfoResult.Data data;
        public String timestamp;


        public class Data
        {
            public SupperGoods supperGoods;
            public List<SupperCode> supperCodes;
            public LowerGoods lowerGoods;
            public List<LowerCode> lowerCodes;
        }
    }

    public class SupperGoods
    {
        public String id;
        public String goodsName;
        public String unit;
    }


    public class SupperCode
    {
        public String id;
        public String unitLevel;
        public String lowerQuantity;
        public String goodsName;
        public String lowerGoodsName;
        public String unit;
        public String lowerUnit;
    }

    public class LowerGoods
    {
        public String id;
        public String goodsName;
        public String unit;
    }

    public class LowerCode
    {
        public String id;
        public String vid;
        public String cid;
        public String tid;
        public String minimumPid;
        public String maximumPid;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.http.bean
{


    class TemplateResult
    {
        public Boolean success;
        public String resultCode;
        public String message;
        public TemplateResult.Data data;
        public String timestamp;

        public class Data
        {
            public List<UnitTemp> unitTemps;
            public String goodsName;
        }
    }

    public class UnitTemp
    {
        public String id;
        public String name;
        public Boolean status;
        public List<TempDel> tempDels;
    }

    public class TempDel
    {
        public String id;
        public int unitLevel;
        public int lowerQuantity;
        public String goodsName;
        public String lowerGoodsName;
        public String unit;
        public String lowerUnit;
    }
}

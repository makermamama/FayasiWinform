using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForms.Http;

namespace WindowsFormsApplication1.http.bean
{
    class UploadData
    {
        public String tempDelId;

        public QRBean parentCode;

        public List<QRBean> childCodes = new List<QRBean>();
    }
}

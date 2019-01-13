using LZ.WpfSlovo.db.Access;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestForms.Http;
using WebApplication1;
using WindowsFormsApplication1.http.bean;
using WindowsFormsApplication1.tool;
using WpfSlovo;

namespace WindowsFormsApplication1
{
    public partial class Upload : Form
    {
        private String boxGUID = "";
       　
        public Upload()
        {
            InitializeComponent();
         
            DBOperation dBOperation = new DBOperation();

            dgBox.DataSource = dBOperation.QueryNoUplaodBox().Tables[0];
            
            dgBox.Columns["ID"].HeaderText = "未上传箱号ID";
            dgBox.Columns["ID"].Width = 300;
            dgBox.Columns["FGuid"].HeaderText = "GUID编码";
            dgBox.Columns["FGuid"].Width = 300;

            dBOperation.Dispose();

        }

        private void UpData(String boxGUID, QRBean boxBean)
        {
            DBOperation dBOperation = new DBOperation();
            try
            {
                if (tbBoxID.Text == "")
                {
                    throw new Exception("请先选择未上传的箱子的ID");
                }

                DataSet dataSet = dBOperation.GetUploadCase(boxGUID);

                UploadData uploadData = new UploadData();
                uploadData.tempDelId = BaseData.TempId;
                uploadData.parentCode = boxBean;

                foreach (DataRow Row in dataSet.Tables[0].Rows)
                {
                    uploadData.childCodes.Add(QRanalyze.QRDecod(Row["FCapData"].ToString()));
                }

                String result = HttpRequest.UploadCapData(uploadData, Session.Id);

                RelationResult Result = JsonConvert.DeserializeObject<RelationResult>(result);
                if (Result.success)
                {
                    dBOperation.UploadBoxTStatus(boxGUID);

                    tbBoxID.Text = "";
                    tbBoxTag.Text = "";
                    boxGUID = "";

                    dgBox.DataSource = dBOperation.QueryNoUplaodBox().Tables[0];

                    dgBox.Columns["ID"].HeaderText = "未上传箱号ID";
                    dgBox.Columns["ID"].Width = 300;
                    dgBox.Columns["FGuid"].HeaderText = "GUID编码";
                    dgBox.Columns["FGuid"].Width = 300;
                }else
                {
                    throw new Exception(Result.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                dBOperation.Dispose();
            }

            

        }

        private void dgBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBox.SelectedCells[0].Value != null && dgBox.SelectedCells[1].Value != null)
            {
                tbBoxID.Text = dgBox.SelectedCells[0].Value.ToString();
                boxGUID = dgBox.SelectedCells[1].Value.ToString();
                tbBoxTag.Focus();
            }
        }

        private void tbBoxTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) {
                    String result = HttpRequest.ConfirmSuperCodeRelation(QRanalyze.QRDecod(tbBoxTag.Text.Substring(tbBoxTag.Text.Length-35,35)), Session.Id);
                    RelationResult Result = JsonConvert.DeserializeObject<RelationResult>(result);
                    if (Result.success)
                    {
                       AccessDB.UpDataOne(tbBoxTag.Text);
                    }
                    else {
                        throw new Exception(Result.message);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

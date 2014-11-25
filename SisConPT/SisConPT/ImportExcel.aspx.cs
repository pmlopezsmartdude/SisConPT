using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;

namespace SisConPT.SisConPT
{
    public partial class ImportExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
                System.Configuration.ConnectionStringSettings connStringmain;
                connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

                string path = string.Concat((Server.MapPath("~/temp/" + FileUpload1.FileName)));
                FileUpload1.PostedFile.SaveAs(path);

                string cn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "\"" + path + "\"" + ";Extended Properties=\"Excel 8.0;\"";
               // OleDbConnection OleBdCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");
                OleDbConnection OleBdCon = new OleDbConnection(cn);
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", OleBdCon);

                OleBdCon.Open();
                DbDataReader dr = cmd.ExecuteReader();
                SqlBulkCopy bulkInsert = new SqlBulkCopy(connStringmain.ToString());
                bulkInsert.DestinationTableName = "prueba_2";
                bulkInsert.WriteToServer(dr);
                OleBdCon.Close();
                Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
                Label1.ForeColor = Color.Green;
                Label1.Text = "Successfully inserted";
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "please select the File";
            }
        }


       
    }
}
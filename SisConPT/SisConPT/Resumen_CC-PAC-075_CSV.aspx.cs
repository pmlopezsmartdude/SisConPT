using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace SisConPT.SisConPT
{
    public partial class Resumen_CC_PAC_075_CSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"] != null)
            {
                connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
                string PlantaNombre = Session["PlantaName"].ToString();
                string comando = "SELECT convert(varchar(10),placodigo) as placodigo FROM planta WHERE pladescri ='" + PlantaNombre + "'";
                SqlConnection conexion = new SqlConnection(connStringmain.ToString());
                conexion.Open();
                SqlCommand sql = new SqlCommand(comando, conexion);
                lbl_planta.Text = PlantaNombre;
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    reader.Read();
                    lbl_codpla.Text = reader.GetString(0);
                }
                conexion.Close();

            }
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];

            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];

            }
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection conexion_2 = new SqlConnection(connStringmain.ToString());
            conexion_2.Open();
            SqlCommand cmd_proc = new SqlCommand("select Ctrl_id as [ID] FROM CC_PAC_075 WHERE Ctrl_CodPlan ='" + lbl_codpla.Text + "'", conexion_2);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);
                conexion_2.Close();
                if (ds_proc.Tables[0].Rows.Count.ToString() == "0")
                {
                    string error = "Sin informacion para mostrar";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");
                    Exportar_075.Enabled = false;
                }

            }
            catch { }




        }
    
        protected void Exportar_click(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            string sql = "select Ctrl_id as [ID],Ctrl_CodProc as [PROCESO],Ctrl_CodPlan as [PLANTA],Ctrl_Lin as [LINEA],Ctrl_Usuario as [USUARIO]," +
                " Ctrl_Turno as [TURNO],Ctrl_Lote as [LOTE],Ctrl_RefAjuste as [REFERENCIA AJUSTE],Ctrl_CAT as [TIPO CAT],Ctrl_CAT_valor as [% CAT]," +
                " Ctrl_desacrte as [% EXPORTABLE DESCARTE MANUAL],Ctrl_global_valor as [GLOBAL VALOR],Ctrl_global_porc as [GLOBAL %]," +
                " Ctrl_global_prueba as [GLOBAL % EXP],Ctrl_puntual_valor as [PUNTUAL VALOR],Ctrl_puntual_porc as [PUNTUAL %]," +
                " Ctrl_puntual_prueba as [PUNTUAL % EXP],Ctrl_externo_valor as [EXTERNO VALOR],Ctrl_externo_porc as [EXTERNO %]," +
                " Ctrl_externo_prueba as [EXTERNO % EXP],Ctrl_ptonegro_valor as [PUNTO NEGRO VALOR],Ctrl_ptonegro_porc as [PUNTO NEGRO %]," +
                " Ctrl_ptonegro_prueba as [PUNTO NEGRO % EXP],Ctrl_ptomarron_valor as [PUNTO MARRON VALOR],Ctrl_ptomarron_porc as [PUNTO MARRON %]," +
                " Ctrl_ptomarron_prueba as [PUNTO MARRON % EXP],Ctrl_marchablanca_valor as [MANCHABLANCA VALOR],Ctrl_marchablanca_porc as [MANCHA BLANCA %]," +
                " Ctrl_marchablanca_prueba as [MANCHA BLANCA % EXP],Ctrl_KilosLote as [KILOS LOTE],Ctrl_NumTotes as [NUMERO TOTES],Ctrl_PorcExp as [% EXP]," +
                " Ctrl_FecHora as [FECHA / HORA], Ctrl_obs as [OBSERVACIONES] FROM CC_PAC_075 WHERE Ctrl_CodPlan ='" + lbl_codpla.Text + "'";
            SqlCommand command = new SqlCommand(sql, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "CC_PAC_075.xls");

        }

        public void ExportToExcel(DataTable dt, string filename)
        {
            if (dt.Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
                Response.Redirect("~/SisConPT/Resumen_CC-PAC-075_CSV.aspx");
            }
        }

    }
}
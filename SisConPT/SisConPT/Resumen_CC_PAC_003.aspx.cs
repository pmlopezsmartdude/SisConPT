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
    public partial class Resumen_CC_PAC_003 : System.Web.UI.Page
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
                string comando = "SELECT * FROM planta WHERE pladescri ='" + PlantaNombre + "'";
                SqlConnection conexion = new SqlConnection(connStringmain.ToString());
                conexion.Open();
                SqlCommand sql = new SqlCommand(comando, conexion);

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    reader.Read();
                    txt_cod_plan.Text = reader.GetString(0);
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
            SqlCommand cmd_proc = new SqlCommand("select ctrl_codproc from cc_PAC_003 where Ctrl_CodPlan='" + txt_cod_plan.Text + "'group by ctrl_codproc", conexion_2);
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
                    Exportar_005.Enabled = false;
                }

            }
            catch { }





            if (!IsPostBack)
            {

                DropLinea();

            }


        }

        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

            BuscaTurno(linea);

        }

        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

            GvProcesos_Llenar(turno, linea_2);

        }

        private void InitializeEditPopUp()
        {


        }

        protected void Procesos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string proceso_id = Convert.ToString(gvProcesos.DataKeys[e.NewSelectedIndex].Value);

            InitializeEditPopUp();
            PopUpDetalle(proceso_id);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

            // GvProcesos_Llenar( linea_2);
            //GvProcesos_Llenar();

        }

        private void PopUpDetalle(string proceso_id)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand("select top 1 * from [VistaResumen003] where Ctrl_CodProc = '" + proceso_id + "'", con);
            try
            {

                using (SqlDataReader reader = cmd_proc.ExecuteReader())
                {
                    reader.Read();
                                       
                   
                    txt_precalibre.Text = reader.GetString(5);
                    txt_trips.Text = reader.GetString(6);
                    txt_adhesion.Text = reader.GetString(7);
                    txt_deshid_frutos.Text = reader.GetString(8);
                    txt_escama.Text = reader.GetString(9);
                    txt_frudeformes.Text = reader.GetString(10);
                    txt_deshid_ped.Text = reader.GetString(11);
                    txt_blandos.Text = reader.GetString(12);
                    txt_dobles.Text = reader.GetString(13);
                    txt_guatablanca.Text = reader.GetString(14);
                    txt_heri_abiertas.Text = reader.GetString(15);
                    txt_machucon.Text = reader.GetString(16);
                    txt_heri_cica.Text = reader.GetString(17);
                    txt_manchas.Text = reader.GetString(18);
                    txt_part_cica.Text = reader.GetString(19);
                    txt_pitting.Text = reader.GetString(20);
                    txt_medluna.Text = reader.GetString(21);
                    txt_lagarto.Text = reader.GetString(22);
                    txt_pudricion.Text = reader.GetString(23);
                    txt_part_agua.Text = reader.GetString(24);
                    txt_russet.Text = reader.GetString(25);
                    txt_sutura.Text = reader.GetString(26);
                    txt_pardas.Text = reader.GetString(27);
                    txt_pajaro.Text = reader.GetString(28);
                    txt_faltocolor.Text = reader.GetString(29);
                    txt_ramaleo.Text = reader.GetString(30);
                    txt_desgarros.Text = reader.GetString(31);
                    txt_sierras.Text = reader.GetString(32);
                    txt_defcalidad.Text = reader.GetString(49);
                    txt_defcondicion.Text = reader.GetString(50);
                    txt_qc_pudricion.Text = reader.GetString(35);
                    txt_comp_pudricion.Text = reader.GetString(36);
                    txt_qc_deshechos.Text = reader.GetString(37);
                    txt_comp_deshechos.Text = reader.GetString(38);
                    txt_qc_exportable.Text = reader.GetString(39);
                    txt_comp_exportable.Text = reader.GetString(40);
                    txt_qc_deshecho_com.Text = reader.GetString(41);
                    txt_comp_deshecho_com.Text = reader.GetString(42);
                    txt_num_frutos.Text = reader.GetString(43);
                    txt_exportable_2.Text = reader.GetString(44);
                    txt_comercial_5.Text = reader.GetString(45);
                    
                    lbl_productor.Text = reader.GetString(46);
                    lbl_variedad.Text = reader.GetString(47);

                    txt_pedicelo.Text = reader.GetString(48);



                }

                con.Close();

            }
            catch (Exception e)
            {
                string error = "";
                Response.Write("<script language=javascript > alert('" + error + e + "'); </script>");
            }


        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            mpeEditOrder.Hide();
        }

        private void DropLinea()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            //try
            //{
            con.Open();
            //linea
            SqlCommand cmd_linea = new SqlCommand("select ctrl_lin from cc_PAC_003 where Ctrl_CodPlan='" + txt_cod_plan.Text + "'group by ctrl_lin", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            drop_linea_d.DataSourceID = "";
            drop_linea_d.DataSource = ds_linea;
            drop_linea_d.DataBind();

            if (drop_linea_d.Items.Count != 0)
            {
                int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

                BuscaTurno(linea);

            }
            if (drop_linea_d.Items.Count == 0)
            {

                BuscaTurno(0);

            }
            con.Close();

        }

        private void BuscaTurno(int linea)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            SqlCommand cmd_linea = new SqlCommand("select distinct Ctrl_Turno from cc_PAC_003 where ctrl_lin ='" + linea + "' and Ctrl_CodPlan = " + txt_cod_plan.Text + "", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            try
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = ds_linea;
                drop_turno_d.DataBind();

                if (drop_turno_d.Items.Count != 0)
                {
                    string turno = Convert.ToString(drop_turno_d.SelectedValue);
                    int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

                    GvProcesos_Llenar(turno, linea_2);

                }
                con.Close();
            }
            catch (Exception e)
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = "";
                drop_turno_d.DataBind();

            }


        }

        private void GvProcesos_Llenar(string turno, int linea_2)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select distinct Ctrl_CodProc  from VistaResumen003 where Ctrl_Turno='" + turno + "' and Ctrl_Lin=" + linea_2 + " and Ctrl_CodPlan = '" + txt_cod_plan.Text + "'", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);
                gvProcesos.DataSource = ds_proc;
                gvProcesos.DataBind();


                con.Close();

            }
            catch (Exception e)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + e + "');</script>");
            }
        }

        protected void Exportar_click(object sender, EventArgs e)
        {
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());


            string sql = "select *  from VistaResumen003 where Ctrl_Turno='" + turno + "' and Ctrl_Lin=" + linea_2 + " and Ctrl_CodPlan = '" + txt_cod_plan.Text + "'";

            SqlCommand command = new SqlCommand(sql, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "Resultado.xls");

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
                Response.Redirect("~/SisConPT/Resumen_CC_PAC_003.aspx");
            }
        }

    }
}
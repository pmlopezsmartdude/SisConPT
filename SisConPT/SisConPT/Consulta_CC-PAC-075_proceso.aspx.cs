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
    public partial class Consulta_CC_PAC_075_proceso : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                DDLProcesos();
            }

        }

        protected void proc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            //GvProcesos_Llenar(proceso);

        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            GvProcesos_Llenar(proceso);
            //GvProcesos_Llenar();

        }


        protected void Procesos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string proceso_id = Convert.ToString(gvProcesos.DataKeys[e.NewSelectedIndex].Value);

            InitializeEditPopUp();
            PopUpDetalle(proceso_id);

            mpeEditOrder.Show();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);
            GvProcesos_Llenar(proceso);
        }


        private void PopUpDetalle(string proceso_id)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand("select Ctrl_CodProc,Ctrl_Lote,Ctrl_ExpDesc,Ctrl_CatII from CtrlDescarteCom where Ctrl_id='" + proceso_id + "'", con);

            using (SqlDataReader reader = cmd_proc.ExecuteReader())
            {
                reader.Read();
                txtProceso.Text = reader.GetString(0);
                txtLote.Text = reader.GetString(1);
                txtDescarte.Text = reader.GetString(2);
                txtCATII.Text = reader.GetString(3);

            }

            con.Close();


        }



        private void GvProcesos_Llenar(int proceso)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select Ctrl_id,Ctrl_CodProc,Ctrl_CodPlan,Ctrl_Lin,Ctrl_Usuario,Ctrl_Turno,Ctrl_Lote,Ctrl_ExpDesc,Ctrl_CatII,Ctrl_CatIII from CtrlDescarteCom where Ctrl_CodProc=" + proceso + "", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);
            gvProcesos.DataSource = ds_proc;
            gvProcesos.DataBind();

            con.Close();


        }

        private void InitializeEditPopUp()
        {


        }

        private void DDLProcesos()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select distinct Ctrl_CodProc from CtrlDescarteCom as ctrl inner join planta as pl on ctrl.Ctrl_CodPlan=pl.placodigo where pl.pladescri='" + PlantaNombre + "'", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            drop_proc_d.DataSourceID = "";
            drop_proc_d.DataSource = ds_proc;
            drop_proc_d.DataBind();

            //if (drop_proc_d.Items.Count != 0)
            //{
            //    int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            //    GvProcesos_Llenar(proceso);
            //}
            con.Close();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            mpeEditOrder.Hide();
        }
    }
}
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
    public partial class Resumen_CC_PAC_005_CODCAJ : System.Web.UI.Page
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
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            SqlCommand cmd_proc = new SqlCommand("select top 1 vis.cptproces,cptnompre,cptnulote,lincodigo,turcodigo,convert(varchar(8),defprecal) as defprecal,convert(varchar(8),defdanotr) as defdanotr,convert(varchar(8),defescama) as defescama,convert(varchar(8),deffrutode) as deffrutode,convert(varchar(8),deffrutodo) as deffrutodo,convert(varchar(8),defguatab) as defguatab,convert(varchar(8),defherida) as defherida,convert(varchar(8),defmancha) as defmancha,convert(varchar(8),defmedial) as defmedial,convert(varchar(8),defpiella) as defpiella,convert(varchar(8),defrusset) as defrusset,convert(varchar(8),defsutura) as defsutura,convert(varchar(8),deffaltoc) as deffaltoc,convert(varchar(8),deframole) as deframole,convert(varchar(8),defsinped) as defsinped,convert(varchar(8),defadhesi) as defadhesi,convert(varchar(8),defdesfru) as defdesfru,convert(varchar(8),defdesped) as defdesped,convert(varchar(8),defblando) as defblando,convert(varchar(8),defherabi) as defherabi,convert(varchar(8),defmachuc) as defmachuc,convert(varchar(8),defpartid) as defpartid,convert(varchar(8),defparagu) as defparagu,convert(varchar(8),defparcic) as defparcic,convert(varchar(8),defpittin) as defpittin,convert(varchar(8),defpudric) as defpudric,convert(varchar(8),defmanpar) as defmanpar,convert(varchar(8),defdanopa) as defdanopa,convert(varchar(8),defdesgar) as defdesgar,convert(varchar(8),defcorsie) as defcorsie,convert(varchar(8),promedio) as  promedio , cptvardes from VistaResumen005 as vis inner join (select distinct cptproces, cptvardes from controlpt) as cl on vis.cptproces=cl.cptproces where vis.cptproces='" + proceso_id + "' order by promedio desc ", con);

            using (SqlDataReader reader = cmd_proc.ExecuteReader())
            {
                reader.Read();
                NroProceso.Text = reader.GetString(0);
                ProdReal.Text = reader.GetString(1);
                Lote.Text = reader.GetString(2);
                txtprecalibre.Text = reader.GetString(5);
                txtdanotrip.Text = reader.GetString(6);
                txtescama.Text = reader.GetString(7);
                txtfrutosdeformes.Text = reader.GetString(8);
                txtfrutosdobles.Text = reader.GetString(9);
                txtguatablanca.Text = reader.GetString(10);
                txtherida.Text = reader.GetString(11);
                txtmanchas.Text = reader.GetString(12);
                txtmedialuna.Text = reader.GetString(13);
                txtpiellagarto.Text = reader.GetString(14);
                txtrusset.Text = reader.GetString(15);
                txtsutura.Text = reader.GetString(16);
                txtfaltocolor.Text = reader.GetString(17);
                txtramaleo.Text = reader.GetString(18);
                txtsinpedicelo.Text = reader.GetString(19);
                txtadhesion.Text = reader.GetString(20);
                txtdeshid.Text = reader.GetString(21);
                txtdeshidpedi.Text = reader.GetString(22);
                txtblandos.Text = reader.GetString(23);
                txtheridasabiertas.Text = reader.GetString(24);
                txtmachucon.Text = reader.GetString(25);
                txtpartiduras.Text = reader.GetString(26);
                txtpartidurasagua.Text = reader.GetString(27);
                txtpartiduracicatrizada.Text = reader.GetString(28);
                txtpitting.Text = reader.GetString(29);
                txtpudricion.Text = reader.GetString(30);
                txtmanchaspardas.Text = reader.GetString(31);
                txtdanopajaro.Text = reader.GetString(32);
                txtdesgarro.Text = reader.GetString(33);
                txtcortesierra.Text = reader.GetString(34);
                txt_soluble.Text = reader.GetString(35);
                txtVariedad.Text = reader.GetString(36);



            }

            con.Close();


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
            con.Open();
            //linea
            SqlCommand cmd_linea = new SqlCommand("select distinct lincodigo from controlpt where placodigo = " + txt_cod_plan.Text + "", con);
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
            SqlCommand cmd_linea = new SqlCommand("select distinct turcodigo from controlpt where lincodigo ='" + linea + "' and placodigo = " + txt_cod_plan.Text + "", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);

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



        private void GvProcesos_Llenar(string turno, int linea_2)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select distinct cptproces  from VistaResumen005 where turcodigo='" + turno + "' and lincodigo=" + linea_2 + " and placodigo = '" + txt_cod_plan.Text + "'", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);
            gvProcesos.DataSource = ds_proc;
            gvProcesos.DataBind();

            con.Close();


        }



    }
}
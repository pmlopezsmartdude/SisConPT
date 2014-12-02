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
using System.Configuration;

namespace SisConPT.SisConPT
{
    public partial class Editar_CC_PAC_005 : System.Web.UI.Page
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


        }

        private void InitializeEditPopUp()
        {


        }

        protected void Procesos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvProcesos.Rows[e.NewSelectedIndex];

            string proceso = row.Cells[1].Text;
            string lote = row.Cells[2].Text;
            string destino = row.Cells[3].Text;
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);


            InitializeEditPopUp();
            PopUpDetalle(proceso, lote, destino);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
        }

        private void PopUpDetalle(string proceso, string lote, string destino)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            int planta = Convert.ToInt32(txt_cod_plan.Text);

            if (destino == "&nbsp;") { destino = ""; }
            string cadena_consulta = "[resumen_005_prueba] '" + inicio + "','" + fin + "', '" + turno + "'," + linea_2 + "," + planta + "; " +
            " select * from ##a where cptproces='" + proceso + "' and cptnulote='" + lote + "' and cptdestino='" + destino + "';";
            SqlCommand cmd_proc = new SqlCommand(cadena_consulta, con);
            try
            {

                using (SqlDataReader reader = cmd_proc.ExecuteReader())
                {
                    reader.Read();
                    lbl_caja.Text = "";
                    lbl_proceso.Text = "";
                    lbl_linea.Text = "";
                    lbl_turno.Text = "";

                    txtbajo.Text = "";
                    txtcalibreok.Text = "";
                    txtsobre.Text = "";
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
                    txt_peso_neto.Text = "";
                    txt_destino.Text = reader.GetString(37);
                    txt_cajasvaciadas.Text = reader.GetString(38);
                    txt_f1.Text = "";
                    txt_f2.Text = "";
                    txt_f3.Text = "";
                    txt_f4.Text = "";
                    txt_f5.Text = "";
                    TextBox1obs.Text = "";
                }

                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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

            SqlCommand cmd_linea = new SqlCommand("select distinct lincodigo from controlpt where placodigo = '" + txt_cod_plan.Text + "'", con);
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

            SqlCommand cmd_linea = new SqlCommand("select distinct turcodigo from controlpt where lincodigo ='" + linea + "' and placodigo = '" + txt_cod_plan.Text + "'", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            try
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = ds_linea;
                drop_turno_d.DataBind();

                con.Close();
            }
            catch (Exception e)
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = "";
                drop_turno_d.DataBind();

            }


        }

        private void GvProcesos_Llenar(string turno, int linea_2, string inicio, string fin)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string comando_cadena = "select cl.cptnumero as cptnumero,cl.placodigo as placodigo,cl.turcodigo as turcodigo,cl.cptfechor as cptfechor,cl.usurutusu as usurutusu," +
            " cl.lincodigo as lincodigo,cl.cptproces as cptproces,cl.cptnulote as cptnulote,cl.cptrutprr as cptrutprr,cl.cptnompre as cptnompre," +
            " cl.cptrutpet as cptrutpet,cl.cptnompet as cptnompet,cl.cptespcod as cptespcod,cl.cptespdes as cptespdes,cl.cptvarcod as cptvarcod," +
            " cl.cptvardes as cptvardes,cl.cptcalibr as cptcalibr,cl.cptmarcod as cptmarcod,cl.cptmardes as cptmardes,cl.cptembcod as cptembcod," +
            " cl.cptembdes as cptembdes,cl.cptenvcod as cptenvcod,cl.cptenvdes as cptenvdes,cl.cptpesone as cptpesone,cl.cptsalida as cptsalida," +
            " cl.cptcodcja as cptcodcja,cl.cptclasificacion as cptclasificacion,cl.cptdestino as cptdestino,cl.cptcajasvaciadas as cptcajasvaciadas," +
            " def.defcalbaj as defcalbaj,def.defcalnor as defcalnor,def.defcalsob as defcalsob,def.defprecal as defprecal,def.defdanotr as defdanotr," +
            " def.defescama as defescama,def.deffrutode as deffrutode,def.deffrutodo as deffrutodo,def.defguatab as defguatab,def.defherida as defherida," +
            " def.defmancha as defmancha,def.defmedial as defmedial,def.defpiella as defpiella,def.defrusset as defrusset,def.defsutura as defsutura," +
            " def.deffaltoc as deffaltoc,def.deframole as deframole,def.defsinped as defsinped,def.defadhesi as defadhesi,def.defdesfru as defdesfru," +
            " def.defdesped as defdesped,def.defblando as defblando,def.defherabi as defherabi,def.defmachuc as defmachuc,def.defpartid as defpartid," +
            " def.defparagu as defparagu,def.defparcic as defparcic,def.defpittin as defpittin,def.defpudric as defpudric,def.defmanpar as defmanpar," +
            " def.defdanopa as defdanopa,def.defdesgar as defdesgar,def.defcorsie as defcorsie,def.solsolub as solsolub,def.observac as observac," +
            " def.pesoneto as pesoneto,sol.calibresoluble as calibresoluble,sol.f1 as f1,sol.f2 as f2,sol.f3 as f3,sol.f4 as f4,sol.f5 as f5,sol.nrolinea as nrolinea " +
            " from controlpt as cl  inner join defecto as def on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptcodcja=sol.codcaja " +
            " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.lincodigo='" + linea_2 + "' and cl.placodigo= " + planta + "";

            SqlCommand cmd_proc = new SqlCommand(comando_cadena, con);
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

        protected void Filtrar(object sender, EventArgs e)
        {
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);

        }

    }
}
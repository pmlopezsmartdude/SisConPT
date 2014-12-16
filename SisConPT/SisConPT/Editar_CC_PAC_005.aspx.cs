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
                string comando = "SELECT convert(varchar(10),placodigo) as placodigo FROM planta WHERE pladescri ='" + PlantaNombre + "'";
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
            string caja = Convert.ToString(gvProcesos.DataKeys[e.NewSelectedIndex].Value);
            
          

            InitializeEditPopUp();
            PopUpDetalle(caja);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
        }

        private void PopUpDetalle(string caja)
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

            string cadena_consulta = "select  top 1 convert(varchar(255),cl.cptcodcja) as cptcodcja, turcodigo, convert(varchar(255),lincodigo) as lincodigo, " +
            " convert(varchar(255),cptproces) as cptproces, " +
            " convert(varchar(15),defcalbaj) as [defcalbaj],convert(varchar(15),defcalnor) as [defcalnor], convert(varchar(15),defcalsob) as [delcalsob], "+
            " convert(varchar(15),defprecal) as [defprecal],convert(varchar(15),defdanotr) as [defdanotr], " +
            " convert(varchar(15),defescama) as [defescama],convert(varchar(15),deffrutode) as [deffrutode]," +
            " convert(varchar(15),deffrutodo) as [deffrutodo],convert(varchar(15),defguatab) as [defguatab]," +
            " convert(varchar(15),defherida) as [defherida],convert(varchar(15),defmancha) as [defmancha]," +
            " convert(varchar(15),defmedial) as [defmedial],convert(varchar(15),defpiella) as [defpiella]," +
            " convert(varchar(15),defrusset) as [defrusset],convert(varchar(15),defsutura) as [defsutura]," +
            " convert(varchar(15),deffaltoc) as [deffaltoc],convert(varchar(15),deframole) as [deframole]," +
            " convert(varchar(15),defsinped) as [defsinped],convert(varchar(15),defadhesi) as [defadhesi]," +
            " convert(varchar(15),defdesfru) as [defdesfru],convert(varchar(15),defdesped) as [defdesped]," +
            " convert(varchar(15),defblando) as [defblando],convert(varchar(15),defherabi) as [defherabi]," +
            " convert(varchar(15),defmachuc) as [defmachuc],convert(varchar(15),defpartid) as [defpartid]," +
            " convert(varchar(15),defparagu) as [defparagu],convert(varchar(15),defparcic) as [defparcic]," +
            " convert(varchar(15),defpittin) as [defpittin],convert(varchar(15),defpudric) as [defpudric]," +
            " convert(varchar(15),defmanpar) as [defmanpar],convert(varchar(15),defdanopa) as [defdanopa]," +
            " convert(varchar(15),defdesgar) as [defdesgar],convert(varchar(15),defcorsie) as [defcorsie]," +
            " convert(varchar(15),solsolub) as solsolub,convert(varchar(15),defcalbaj)as defcalbaj ," +
            " convert(varchar(15),defcalnor) as defcalnor,convert(varchar(15),defcalsob) as defcalsob, observac, " +
            " cptdestino,convert(varchar(4),cptcajasvaciadas) as cptcajasvaciadas, convert(varchar(15),pesoneto) as pesoneto" +
            " , convert(varchar(15),f1) as f1,convert(varchar(15),f2) as f2,convert(varchar(15),f3) as f3," +
            " convert(varchar(15),f4) as f4,convert(varchar(15),f5) as f5, sol.calibresoluble, convert(varchar(15),defsutura_exp) as defsutura_exp," +
            " convert(varchar(50),cl.cptnumero) as cptnumero from defecto as def inner join controlpt as cl on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptnumero=sol.cptnumero where cl.cptnumero='" + caja + "'";
            SqlCommand cmd_proc = new SqlCommand(cadena_consulta, con);
            try
            {

                using (SqlDataReader reader = cmd_proc.ExecuteReader())
                {
                    reader.Read();
                    lbl_caja.Text = reader.GetString(0);
                    lbl_proceso.Text = reader.GetString(3);
                    lbl_linea.Text = reader.GetString(2);
                    lbl_turno.Text = reader.GetString(1);
                    txtbajo.Text = reader.GetString(4);
                    txtcalibreok.Text = reader.GetString(5);
                    txtsobre.Text = reader.GetString(6);
                    txtprecalibre.Text = reader.GetString(7);
                    txtdanotrip.Text = reader.GetString(8);
                    txtescama.Text = reader.GetString(9);
                    txtfrutosdeformes.Text = reader.GetString(10);
                    txtfrutosdobles.Text = reader.GetString(11);
                    txtguatablanca.Text = reader.GetString(12);
                    txtherida.Text = reader.GetString(13);
                    txtmanchas.Text = reader.GetString(14);
                    txtmedialuna.Text = reader.GetString(15);
                    txtpiellagarto.Text = reader.GetString(16);
                    txtrusset.Text = reader.GetString(17);
                    txtsutura.Text = reader.GetString(18);
                    txtfaltocolor.Text = reader.GetString(19);
                    txtramaleo.Text = reader.GetString(20);
                    txtsinpedicelo.Text = reader.GetString(21);
                    txtadhesion.Text = reader.GetString(22);
                    txtdeshid.Text = reader.GetString(23);
                    txtdeshidpedi.Text = reader.GetString(24);
                    txtblandos.Text = reader.GetString(25);
                    txtheridasabiertas.Text = reader.GetString(26);
                    txtmachucon.Text = reader.GetString(27);
                    txtpartiduras.Text = reader.GetString(28);
                    txtpartidurasagua.Text = reader.GetString(29);
                    txtpartiduracicatrizada.Text = reader.GetString(30);
                    txtpitting.Text = reader.GetString(31);
                    txtpudricion.Text = reader.GetString(32);
                    txtmanchaspardas.Text = reader.GetString(33);
                    txtdanopajaro.Text = reader.GetString(34);
                    txtdesgarro.Text = reader.GetString(35);
                    txtcortesierra.Text = reader.GetString(36);
                    txt_peso_neto.Text = reader.GetString(44);
                    txt_destino.Text = reader.GetString(42);
                    txt_cajasvaciadas.Text = reader.GetString(43);
                    txt_f1.Text = reader.GetString(45);
                    txt_f2.Text = reader.GetString(46);
                    txt_f3.Text = reader.GetString(47);
                    txt_f4.Text = reader.GetString(48);
                    txt_f5.Text = reader.GetString(49);
                    TextBox1obs.Text = reader.GetString(41);
                    lbl_calibre.Text = reader.GetString(50);
                    txt_sut_exp.Text = reader.GetString(51);
                    lbl_cptnumero.Text = reader.GetString(52);

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
            catch 
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
            string comando_cadena = "select cl.cptfechor as cptfechor,cl.cptproces as cptproces,cl.cptnulote as cptnulote," +
            " cl.cptvardes as cptvardes, cl.cptcodcja as cptcodcja, cl.cptdestino as cptdestino, sol.calibresoluble as calibresoluble, cl.cptnumero" +
            " from controlpt as cl  inner join defecto as def on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptnumero=sol.cptnumero " +
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

        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            if (txtbajo.Text == "") { txtbajo.Text = "0"; }
            if (txtprecalibre.Text == "") { txtprecalibre.Text = "0"; }
            if (txtsobre.Text == "") { txtsobre.Text = "0"; }
            if (txtbajo.Text == "") { txtbajo.Text = "0"; }
            if (txtprecalibre.Text == "") { txtprecalibre.Text = "0"; }
            if (txtrusset.Text == "") { txtrusset.Text = "0"; }
            if (txtadhesion.Text == "") { txtadhesion.Text = "0"; }
            if (txtpudricion.Text == "") { txtpudricion.Text = "0"; }
            if (txtcalibreok.Text == "") { txtcalibreok.Text = "0"; }
            if (txtdanotrip.Text == "") { txtdanotrip.Text = "0"; }
            if (txtsutura.Text == "") { txtsutura.Text = "0"; }
            if (txtdeshid.Text == "") { txtdeshid.Text = "0"; }
            if (txtmanchaspardas.Text == "") { txtmanchaspardas.Text = "0"; }
            if (txtsobre.Text == "") { txtsobre.Text = "0"; }
            if (txtescama.Text == "") { txtescama.Text = "0"; }
            if (txtfaltocolor.Text == "") { txtfaltocolor.Text = "0"; }
            if (txtdeshidpedi.Text == "") { txtdeshidpedi.Text = "0"; }
            if (txtdanopajaro.Text == "") { txtdanopajaro.Text = "0"; }
            if (txtfrutosdeformes.Text == "") { txtfrutosdeformes.Text = "0"; }
            if (txtramaleo.Text == "") { txtramaleo.Text = "0"; }
            if (txtblandos.Text == "") { txtblandos.Text = "0"; }
            if (txtdesgarro.Text == "") { txtdesgarro.Text = "0"; }
            if (txtfrutosdobles.Text == "") { txtfrutosdobles.Text = "0"; }
            if (txtsinpedicelo.Text == "") { txtsinpedicelo.Text = "0"; }
            if (txtheridasabiertas.Text == "") { txtheridasabiertas.Text = "0"; }
            if (txtcortesierra.Text == "") { txtcortesierra.Text = "0"; }
            if (txtguatablanca.Text == "") { txtguatablanca.Text = "0"; }
            if (txtmachucon.Text == "") { txtmachucon.Text = "0"; }
            if (txtherida.Text == "") { txtherida.Text = "0"; }
            if (txtpartiduras.Text == "") { txtpartiduras.Text = "0"; }
            if (txtmanchas.Text == "") { txtmanchas.Text = "0"; }
            if (txtpartidurasagua.Text == "") { txtpartidurasagua.Text = "0"; }
            if (txtmedialuna.Text == "") { txtmedialuna.Text = "0"; }
            if (txtpartiduracicatrizada.Text == "") { txtpartiduracicatrizada.Text = "0"; }
            if (txtpiellagarto.Text == "") { txtpiellagarto.Text = "0"; }
            if (txtpitting.Text == "") { txtpitting.Text = "0"; }
            if (txt_cajasvaciadas.Text == "") { txt_cajasvaciadas.Text = "0"; }
            if (txt_peso_neto.Text == "") { txt_peso_neto.Text = "0"; }
            if (txt_f1.Text == "") { txt_f1.Text = "0"; }
            if (txt_f2.Text == "") { txt_f2.Text = "0"; }
            if (txt_f3.Text == "") { txt_f3.Text = "0"; }
            if (txt_f4.Text == "") { txt_f4.Text = "0"; }
            if (txt_f5.Text == "") { txt_f5.Text = "0"; }
            if (TextBox1obs.Text == "") { TextBox1obs.Text = "0"; }
            if (txt_sut_exp.Text == "") { txt_sut_exp.Text = "0"; }

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection conexion = new SqlConnection(connStringmain.ToString());

            string update_controlpt = "update controlpt set cptdestino = '" + txt_destino.Text + "', cptcajasvaciadas= '" + txt_cajasvaciadas.Text + "' where cptnumero = '" + lbl_cptnumero.Text + "';";

            string update_defecto = "update defecto set" +
                " defcalbaj = '" + txtbajo.Text + "'," +
                " defcalnor = '" + txtcalibreok.Text + "'," +
                " defcalsob = '" + txtsobre.Text + "'," +
                " defprecal = '" + txtprecalibre.Text + "'," +
                " defdanotr = '" + txtdanotrip.Text + "'," +
                " defescama = '" + txtescama.Text + "'," +
                " deffrutode = '" + txtfrutosdeformes.Text + "'," +
                " deffrutodo = '" + txtfrutosdobles.Text + "'," +
                " defguatab = '" + txtguatablanca.Text + "'," +
                " defherida = '" + txtherida.Text + "'," +
                " defmancha = '" + txtmanchas.Text + "'," +
                " defmedial = '" + txtmedialuna.Text + "'," +
                " defpiella = '" + txtpiellagarto.Text + "'," +
                " defrusset = '" + txtrusset.Text + "'," +
                " defsutura = '" + txtsutura.Text + "'," +
                " deffaltoc = '" + txtfaltocolor.Text + "'," +
                " deframole = '" + txtramaleo.Text + "'," +
                " defsinped = '" + txtsinpedicelo.Text + "'," +
                " defadhesi = '" + txtadhesion.Text + "'," +
                " defdesfru = '" + txtdeshid.Text + "'," +
                " defdesped = '" + txtdeshidpedi.Text + "'," +
                " defblando = '" + txtblandos.Text + "'," +
                " defherabi = '" + txtheridasabiertas.Text + "'," +
                " defmachuc = '" + txtmachucon.Text + "'," +
                " defpartid = '" + txtpartiduras.Text + "'," +
                " defparagu = '" + txtpartidurasagua.Text + "'," +
                " defparcic = '" + txtpartiduracicatrizada.Text + "'," +
                " defpittin = '" + txtpitting.Text + "'," +
                " defpudric = '" + txtpudricion.Text + "'," +
                " defmanpar = '" + txtmanchaspardas.Text + "'," +
                " defdanopa = '" + txtdanopajaro.Text + "'," +
                " defdesgar = '" + txtdesgarro.Text + "'," +
                " defcorsie = '" + txtcortesierra.Text + "'," +
                " observac = '" + TextBox1obs.Text + "'," +
                " defsutura_exp = '" + txt_sut_exp.Text + "'," +
                " pesoneto = '" + txt_peso_neto.Text + "'" +
                " from defecto as def inner join controlpt as cl on def.cptnumero=cl.cptnumero where cl.cptnumero='" + lbl_cptnumero.Text + "'";

            string update_solidos = "update solidossolubles set" +
                " f1 = '" + txt_f1.Text + "'," +
                " f2 = '" + txt_f2.Text + "'," +
                " f3 = '" + txt_f3.Text + "'," +
                " f4 = '" + txt_f4.Text + "'," +
                " f5 = '" + txt_f5.Text + "'" +
                " where cptnumero='" + lbl_cptnumero.Text + "'";
            try
            {

                conexion.Open();
                using (SqlCommand sql = new SqlCommand(update_controlpt, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();

                }

                conexion.Open();
                using (SqlCommand sql = new SqlCommand(update_defecto, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();

                }

                conexion.Open();
                using (SqlCommand sql = new SqlCommand(update_solidos, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();

                }
                string error = "Guardado ok";
                Response.Write("<script language=javascript > alert('" + error + "'); </script>");
            }
            catch { 

            
            }

        }

    }
}
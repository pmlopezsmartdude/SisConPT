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

            //txt_fechafin.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            //txt_fechainicio.Text = "2011-01-01T00:00:00.0000000000";

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
            SqlCommand cmd_proc = new SqlCommand("select * from controlpt where placodigo ='" + txt_cod_plan.Text + "'", conexion_2);
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
            //string turno = Convert.ToString(drop_turno_d.SelectedValue);
            //int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
            //string fecha_inicio = txt_fechainicio.Text.Replace("/", "-");
            //string fecha_fin = txt_fechafin.Text.Replace("/", "-");

           // GvProcesos_Llenar(turno, linea_2, fecha_inicio, fecha_fin);



        }
     
        private void InitializeEditPopUp()
        {


        }

        protected void Procesos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = Convert.ToString(gvProcesos.DataKeys[e.NewSelectedIndex].Value);



            InitializeEditPopUp();
            PopUpDetalle(id);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

           // GvProcesos_Llenar( linea_2);
            //GvProcesos_Llenar();

        }
        
        private void PopUpDetalle(string id)
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
            SqlCommand cmd_proc = new SqlCommand("resumen_005_detalle '" + inicio + "','" + fin + "', '" + turno + "'," + linea_2 + "," + planta + ",'" + id + "'", con);
            try
            {

            using (SqlDataReader reader = cmd_proc.ExecuteReader())
            {
                reader.Read();
                NroProceso.Text  = reader.GetString(1);
                ProdReal.Text  = reader.GetString(2);
                Lote.Text  = reader.GetString(3);


                txtprecalibre.Text  = reader.GetString(6);
                txtdanotrip.Text  = reader.GetString(7);
                txtescama.Text  = reader.GetString(8);
                txtfrutosdeformes.Text  = reader.GetString(9);
                txtfrutosdobles.Text  = reader.GetString(10);
                txtguatablanca.Text  = reader.GetString(11);
                txtherida.Text  = reader.GetString(12);
                txtmanchas.Text  = reader.GetString(13);
                txtmedialuna.Text  = reader.GetString(14);
                txtpiellagarto.Text  = reader.GetString(15);
                txtrusset.Text  = reader.GetString(16);
                txtsutura.Text  = reader.GetString(17);
                txtfaltocolor.Text  = reader.GetString(18);
                txtramaleo.Text  = reader.GetString(19);
                txtsinpedicelo.Text  = reader.GetString(20);
                txtadhesion.Text  = reader.GetString(21);
                txtdeshid.Text  = reader.GetString(22);
                txtdeshidpedi.Text  = reader.GetString(23);
                txtblandos.Text  = reader.GetString(24);
                txtheridasabiertas.Text  = reader.GetString(25);
                txtmachucon.Text  = reader.GetString(26);
                txtpartiduras.Text  = reader.GetString(27);
                txtpartidurasagua.Text  = reader.GetString(28);
                txtpartiduracicatrizada.Text  = reader.GetString(29);
                txtpitting.Text  = reader.GetString(30);
                txtpudricion.Text  = reader.GetString(31);
                txtmanchaspardas.Text  = reader.GetString(32);
                txtdanopajaro.Text  = reader.GetString(33);
                txtdesgarro.Text  = reader.GetString(34);
                txtcortesierra.Text  = reader.GetString(35);
                txt_soluble.Text = "--";
                txtVariedad.Text = "--";
                txt_tipo_sol.Text = "--";
                txt_clasi.Text  = reader.GetString(37);
                txt_destino.Text  = reader.GetString(38);
                txt_vaciadas.Text  = reader.GetString(39);


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

            SqlCommand cmd_linea = new SqlCommand("select distinct turcodigo from controlpt where lincodigo ='" + linea + "' and placodigo = " + txt_cod_plan.Text + "", con);
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
                //string fecha_inicio = txt_fechainicio.Text;
                //string fecha_fin = txt_fechafin.Text;

                //GvProcesos_Llenar(turno, linea_2,fecha_inicio, fecha_fin);

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

        private void GvProcesos_Llenar(string turno, int linea_2, string inicio, string fin)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string comando_cadena = "resumen_005 '" + inicio + "','" + fin + "', '" + turno + "'," + linea_2 + "," + planta + "";

            SqlCommand cmd_proc = new SqlCommand(comando_cadena, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try {
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

            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;


            string sql = "resumen_005 '" + inicio + "','" + fin + "', '" + turno + "'," + linea_2 + "," + planta + "";

            SqlCommand command = new SqlCommand(sql, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.ExportToExcel(dt, "Resultado.xls");

        }

        protected void Filtrar(object sender, EventArgs e)
        {
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
  
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);

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
                Response.Redirect("~/SisConPT/Resumen_CC-PAC-005_CODCAJ.aspx");
            }
        }


    }
}
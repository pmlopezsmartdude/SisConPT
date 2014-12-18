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
    public partial class Resumen_CC_PAC_005_III : System.Web.UI.Page
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

                BuscaTurno(); 

            }

                 
        }

        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string linea = Convert.ToString(drop_linea_d.SelectedValue);

           // BuscaTurno(linea);

        }

        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            DropLinea(turno);

        }
     
        private void InitializeEditPopUp()
        {


        }

        protected void Procesos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvProcesos.Rows[e.NewSelectedIndex];

            string proceso = row.Cells[1].Text;
            string lote = row.Cells[2].Text;
            string marca = row.Cells[3].Text;
            string linea = row.Cells[4].Text;
            string turno = Convert.ToString(drop_turno_d.SelectedValue);


            InitializeEditPopUp();
            PopUpDetalle(proceso, lote, marca, linea);
            gv_solubles(proceso, lote, marca, linea);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
        }

        private void PopUpDetalle(string proceso, string lote, string marca, string linea)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            int planta = Convert.ToInt32(txt_cod_plan.Text);

            
            string cadena_consulta = "select  cptproces, cptnulote, cptmardes,lincodigo," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defprecal*1.0))) as [defprecal]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanotr*1.0))) as [defdanotr]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defescama*1.0))) as [defescama]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutode*1.0))) as [deffrutode]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutodo*1.0))) as [deffrutodo]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defguatab*1.0))) as [defguatab]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherida*1.0))) as [defherida]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmancha*1.0))) as [defmancha]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmedial*1.0))) as [defmedial]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpiella*1.0))) as [defpiella]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defrusset*1.0))) as [defrusset]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura*1.0))) as [defsutura]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffaltoc*1.0))) as [deffaltoc]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deframole*1.0))) as [deframole]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsinped*1.0))) as [defsinped]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))) as [promedio_final]," +
            " (case when (avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))>=2 then 'Sobre el promedio'" +
            " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos" +
            " from controlpt as cl " +
            " inner join defecto as def on cl.cptnumero=def.cptnumero";

            string continuacion = "";

            if (linea_2 == "Todas")
            {
                continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                    " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='"+ marca +"'" +
                    " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo order by cptproces;";
            }
            else
            {
                continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                    " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='" + marca + "'" +
                    " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo order by cptproces;";
            }

            string consulta_completa = cadena_consulta + continuacion;
            SqlCommand cmd_proc = new SqlCommand(consulta_completa, con);
            try
            {

            using (SqlDataReader reader = cmd_proc.ExecuteReader())
            {
                reader.Read();

                lbl_desde.Text = inicio;
                lbl_hasta.Text = fin;
                lbl_proceso.Text = reader.GetString(0);
                lbl_lote.Text = reader.GetString(1);
                lbl_marca.Text = reader.GetString(2);
                lbl_linea_popup.Text = reader.GetString(3);
                txtprecalibre.Text = reader.GetString(4);
                txtdanotrip.Text = reader.GetString(5);
                txtescama.Text = reader.GetString(6);
                txtfrutosdeformes.Text = reader.GetString(7);
                txtfrutosdobles.Text = reader.GetString(8);
                txtguatablanca.Text = reader.GetString(9);
                txtherida.Text = reader.GetString(10);
                txtmanchas.Text = reader.GetString(11);
                txtmedialuna.Text = reader.GetString(12);
                txtpiellagarto.Text = reader.GetString(13);
                txtrusset.Text = reader.GetString(14);
                txtsutura.Text = reader.GetString(15);
                txtfaltocolor.Text = reader.GetString(16);
                txtramaleo.Text = reader.GetString(17);
                txtsinpedicelo.Text = reader.GetString(18);
                lbl_calidad.Text = reader.GetString(19);
                lbl_casos.Text = reader.GetString(22);


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

        private void DropLinea(string turno)
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

            SqlCommand cmd_linea = new SqlCommand("select 'Todas' as lincodigo union select distinct lincodigo from controlpt where turcodigo='" + turno + "' and placodigo = '" + txt_cod_plan.Text + "'", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            drop_linea_d.DataSourceID = "";
            drop_linea_d.DataSource = ds_linea;
            drop_linea_d.DataBind();

            con.Close();
        
        }

        private void BuscaTurno()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //linea
            
            SqlCommand cmd_linea = new SqlCommand("select distinct turcodigo from controlpt where placodigo = '" + txt_cod_plan.Text + "'", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);

            try
            { 
            drop_turno_d.DataSourceID = "";
            drop_turno_d.DataSource = ds_linea;
            drop_turno_d.DataBind();

            string turno = "";
                if (drop_turno_d.Items.Count != 0)
                {
                    turno = Convert.ToString(drop_turno_d.SelectedValue);

                    DropLinea(turno);

                }
                if (drop_turno_d.Items.Count == 0)
                {

                    DropLinea(turno);

                }


            con.Close();
            }
            catch 
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = "";
                drop_turno_d.DataBind();

            }

            
        }

        private void GvProcesos_Llenar(string turno, string linea_2, string inicio, string fin)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string comando_cadena = "";
            if (linea_2 == "Todas")
            {
                comando_cadena = "select  cptproces, cptnulote, cptmardes,lincodigo," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defprecal*1.0))) as [defprecal]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanotr*1.0))) as [defdanotr]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defescama*1.0))) as [defescama]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutode*1.0))) as [deffrutode]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutodo*1.0))) as [deffrutodo]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defguatab*1.0))) as [defguatab]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherida*1.0))) as [defherida]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmancha*1.0))) as [defmancha]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmedial*1.0))) as [defmedial]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpiella*1.0))) as [defpiella]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defrusset*1.0))) as [defrusset]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura*1.0))) as [defsutura]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffaltoc*1.0))) as [deffaltoc]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(deframole*1.0))) as [deframole]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsinped*1.0))) as [defsinped]," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))) as [promedio_final]," +
             " (case when (avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))>=2 then 'Sobre el promedio'" +
             " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos" +
             " from controlpt as cl " +
             " inner join defecto as def on cl.cptnumero=def.cptnumero" +
             " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
             " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo order by cptproces;";
            }
            else
            {
                comando_cadena = "select  cptproces, cptnulote, cptmardes,lincodigo," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defprecal*1.0))) as [defprecal]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanotr*1.0))) as [defdanotr]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defescama*1.0))) as [defescama]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutode*1.0))) as [deffrutode]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutodo*1.0))) as [deffrutodo]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defguatab*1.0))) as [defguatab]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherida*1.0))) as [defherida]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmancha*1.0))) as [defmancha]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmedial*1.0))) as [defmedial]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpiella*1.0))) as [defpiella]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defrusset*1.0))) as [defrusset]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura*1.0))) as [defsutura]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffaltoc*1.0))) as [deffaltoc]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(deframole*1.0))) as [deframole]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsinped*1.0))) as [defsinped]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))) as [promedio_final]," +
            " (case when (avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))>=2 then 'Sobre el promedio'" +
            " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos" +
            " from controlpt as cl " +
            " inner join defecto as def on cl.cptnumero=def.cptnumero" +
            " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
            " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo order by cptproces;";
            }
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

        private void gv_solubles(string proceso, string lote, string turno, string linea_2)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string filtro = "";
            if (linea_2 == "Todas")
            {
                filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "' and turno='" + turno + "' and placodigo= '" + txt_cod_plan.Text + "'";
            }
            else
            {
                filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "' and turno='" + turno + "' and nrolinea='" + linea_2 + "' and placodigo= '" + txt_cod_plan.Text + "'";
            }

            string comando_cadena = "select codcaja, calibresoluble,convert(varchar (255),f1) as f1,convert(varchar (255),f2) as f2," +
            " convert(varchar (255),f3) as f3,convert(varchar (255),f4) as f4,convert(varchar (255),f5) as f5, convert(varchar(255)," +
            " (CONVERT(decimal(18, 2),(f1+f2+f3+f4+f5)/5.0))) as promedio from solidossolubles " +
            " as sol inner join controlpt as cl on sol.codcaja=cl.cptcodcja" + filtro;

            SqlCommand cmd_proc = new SqlCommand(comando_cadena, con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);
                gv_solubles_datos.DataSource = ds_proc;
                gv_solubles_datos.DataBind();


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
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());

            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            string sql = "";

            if (linea_2 == "Todas")
            {
                sql = "[RESUMEN_CC_PAC_005_todas] '" + inicio + "','" + fin + "', '" + turno + "'," + planta + "; select * from ##a;";
            }
            else
            {
                sql = "[RESUMEN_CC_PAC_005] '" + inicio + "','" + fin + "', '" + turno + "'," + linea_2 + "," + planta + "; select * from ##a;";
            }

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
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);
  
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
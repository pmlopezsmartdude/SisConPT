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
using Microsoft.VisualBasic;
using System.Web.UI.WebControls.WebParts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Web.Security;
using System.Xml;
using System.Net;
using iTextSharp.text.html.simpleparser; 
using System.Web.UI.WebControls.Adapters;

namespace SisConPT.SisConPT
{
    public partial class Resumen_CC_PAC_005_III_PDF : System.Web.UI.Page
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
                    Filtrar_fecha.Enabled = false;
                    btn_resumen.Enabled = false;
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
            string productor = row.Cells[6].Text;
            string turno = Convert.ToString(drop_turno_d.SelectedValue);


            InitializeEditPopUp();
            PopUpDetalle(proceso, lote, marca, linea, productor);
            gv_solubles(proceso, lote, marca, linea, turno, productor);

            mpeEditOrder.Show();
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcesos.PageIndex = e.NewPageIndex;
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);
        }

        protected void Todos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridTodos.Rows[e.NewSelectedIndex];

            string linea = row.Cells[1].Text;
            string turno = row.Cells[2].Text;
            string productor = row.Cells[3].Text;
            string tipo = "";
            InitializeEditPopUp();
            PopUpDetalle_Todos(linea, turno, tipo, productor);
            

            mpeEditOrder_todos.Show();
        }

        protected void Todos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTodos.PageIndex = e.NewPageIndex;
            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);
        }

        private void PopUpDetalle_Todos(string linea, string turno, string tipo, string productor)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;
            int planta = Convert.ToInt32(txt_cod_plan.Text);
            string inicio_consulta = "";
            string fin_consulta = "";
            if (tipo=="todos")
            {
                inicio_consulta = "select  '' as proceso, '' as lote, '' as marca , '' as lincodigo,";
                fin_consulta = ",'' as cptnompre from controlpt as cl " +
            " inner join defecto as def on cl.cptnumero=def.cptnumero" + 
            " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "'" +
             " group by  placodigo;";

                lbl_tit_turno.Text = "";
                lbl_turno_t.Text = "";
                lbl_tit_linea.Text = "";
                lbl_linea_t.Text = "";
                lbl_tit_productor.Text = "";
                lbl_productor_t.Text = "";
               // btn_resumen.Visible = false;
            }
            else
            {
                lbl_tit_turno.Text = "Turno : ";
                lbl_turno_t.Text = turno;
                lbl_tit_linea.Text = "Linea : ";
                lbl_linea_t.Text = linea;
                lbl_tit_productor.Text = "Productor : ";
                lbl_productor_t.Text = "";
             //   btn_resumen.Visible = true;

                inicio_consulta = "select  '' as proceso, '' as lote, '' as marca , lincodigo,";
                fin_consulta = ",cptnompre from controlpt as cl " +
            " inner join defecto as def on cl.cptnumero=def.cptnumero"+
                "  where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' " +
                    " and lincodigo='" + linea + "' and cptnompre='" + productor + "'" +
                    " group by  placodigo,lincodigo,turcodigo,cptnompre;";
            }

            string cadena_consulta = " convert(varchar(255),CONVERT(decimal(18, 2),avg(defprecal*1.0))) as [defprecal]," +
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
            " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defadhesi*1.0))) as [defadhesi]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesfru*1.0))) as [defdesfru]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesped*1.0))) as [defdesped]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defblando*1.0))) as [defblando]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherabi*1.0))) as [defherabi]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmachuc*1.0))) as [defmachuc]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpartid*1.0))) as [defpartid]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparagu*1.0))) as [defparagu]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparcic*1.0))) as [defparcic]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpittin*1.0))) as [defpittin]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpudric*1.0))) as [defpudric]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmanpar*1.0))) as [defmanpar]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanopa*1.0))) as [defdanopa]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesgar*1.0))) as [defdesgar]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defcorsie*1.0))) as [defcorsie]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura_exp*1.0))) as [defsutura_exp]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))) as [promedio_final_condicion]," +
             " (case when (avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))>=10 then 'Sobre el promedio'" +
             " else 'Cumple' end) Desviacion_condicion" ;
       

            SqlCommand cmd_proc = new SqlCommand(inicio_consulta+cadena_consulta+fin_consulta, con);
            try
            {

            using (SqlDataReader reader = cmd_proc.ExecuteReader())
            {
                reader.Read();

                string prom_calidad = reader.GetString(19);
                String[] result = prom_calidad.Split('.');

                if (Convert.ToInt32(result[0]) >= 2)
                {
                    lbl_calidad.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl_calidad.ForeColor = System.Drawing.Color.Black;
                }
                string prom_condicion = reader.GetString(39);
                String[] result_cond = prom_condicion.Split('.');

                if (Convert.ToInt32(result_cond[0]) >= 10)
                {
                    lbl_condicion.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl_condicion.ForeColor = System.Drawing.Color.Black;
                }


                lbl_desde_t.Text = inicio;
                lbl_hasta_t.Text = fin;
                txt_precalibre_t.Text = reader.GetString(4);
                txt_trip_t.Text = reader.GetString(5);
                string trip = reader.GetString(5);

                txtescama_t.Text = reader.GetString(6);
                txtfrutosdeformes_t.Text = reader.GetString(7);
                txtfrutosdobles_t.Text = reader.GetString(8);
                txtguatablanca_t.Text = reader.GetString(9);
                txtherida_t.Text = reader.GetString(10);
                txtmanchas_t.Text = reader.GetString(11);
                txtmedialuna_t.Text = reader.GetString(12);
                txtpiellagarto_t.Text = reader.GetString(13);
                txt_russet_t.Text = reader.GetString(14);
                txt_sutura_t.Text = reader.GetString(15);
                txtfaltocolor_t.Text = reader.GetString(16);
                txtramaleo_t.Text = reader.GetString(17);
                txtsinpedicelo_t.Text = reader.GetString(18);

                lbl_calidad_t.Text = reader.GetString(19);
                lbl_cajas_t.Text = reader.GetString(22);

                txt_adhesion_t.Text = reader.GetString(23);
                txt_deshidfru_t.Text = reader.GetString(24);
                string deshidr = reader.GetString(24);
                
                txtdeshidpedi_t.Text = reader.GetString(25);
                txtblandos_t.Text = reader.GetString(26);
                txtheridasabiertas_t.Text = reader.GetString(27);
                txtmachucon_t.Text = reader.GetString(28);
                txtpartiduras_t.Text = reader.GetString(29);
                txtpartidurasagua_t.Text = reader.GetString(30);
                txtpartiduracicatrizada_t.Text = reader.GetString(31);
                txtpitting_t.Text = reader.GetString(32);
                txt_pudricion_t.Text = reader.GetString(33);
                txt_manchaspardas_t.Text = reader.GetString(34);
                txtdanopajaro_t.Text = reader.GetString(35);
                txtdesgarro_t.Text = reader.GetString(36);
                txtcortesierra_t.Text = reader.GetString(37);
                txt_sut_exp_t.Text = reader.GetString(38);
                lbl_condicion_t.Text = reader.GetString(39);
                lbl_productor_t.Text = reader.GetString(41);
            

           }

            con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

        private void PopUpDetalle(string proceso, string lote, string marca, string linea, string productor)
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
            " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos," +
             " convert(varchar(255),CONVERT(decimal(18, 2),avg(defadhesi*1.0))) as [defadhesi]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesfru*1.0))) as [defdesfru]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesped*1.0))) as [defdesped]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defblando*1.0))) as [defblando]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherabi*1.0))) as [defherabi]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmachuc*1.0))) as [defmachuc]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpartid*1.0))) as [defpartid]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparagu*1.0))) as [defparagu]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparcic*1.0))) as [defparcic]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpittin*1.0))) as [defpittin]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpudric*1.0))) as [defpudric]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmanpar*1.0))) as [defmanpar]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanopa*1.0))) as [defdanopa]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesgar*1.0))) as [defdesgar]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defcorsie*1.0))) as [defcorsie]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura_exp*1.0))) as [defsutura_exp]," +
            " convert(varchar(255),CONVERT(decimal(18, 2),avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))) as [promedio_final_condicion]," +
             " (case when (avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))>=10 then 'Sobre el promedio'" +
             " else 'Cumple' end) Desviacion_condicion, cptnompre" +
            " from controlpt as cl " +
            " inner join defecto as def on cl.cptnumero=def.cptnumero";

            string continuacion = "";

            if (turno == "Todos")
            {
                if (linea_2 == "Todas")
                {
                    continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "')  and cl.placodigo= '" + planta + "'" +
                        " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'" +
                        " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre order by cptproces;";
                }
                else
                {
                    continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "')  and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                        " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'" +
                        " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre order by cptproces;";
                }
            }
            else
            {
                if (linea_2 == "Todas")
                {
                    continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                        " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'" +
                        " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre order by cptproces;";
                }
                else
                {
                    continuacion = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                        " and cptproces='" + proceso + "' and cptnulote='" + lote + "' and lincodigo='" + linea + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'" +
                        " group by cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre order by cptproces;";
                }
            }


            string consulta_completa = cadena_consulta + continuacion;
            SqlCommand cmd_proc = new SqlCommand(consulta_completa, con);
            try
            {

                using (SqlDataReader reader = cmd_proc.ExecuteReader())
                {
                    reader.Read();

                    string prom_calidad = reader.GetString(19);
                    String[] result = prom_calidad.Split('.');

                    if (Convert.ToInt32(result[0]) >= 2)
                    {
                        lbl_calidad.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lbl_calidad.ForeColor = System.Drawing.Color.Black;
                    }
                    string prom_condicion = reader.GetString(39);
                    String[] result_cond = prom_condicion.Split('.');

                    if (Convert.ToInt32(result_cond[0]) >= 10)
                    {
                        lbl_condicion.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lbl_condicion.ForeColor = System.Drawing.Color.Black;
                    }


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

                    txtadhesion.Text = reader.GetString(23);
                    txtdeshid.Text = reader.GetString(24);
                    txtdeshidpedi.Text = reader.GetString(25);
                    txtblandos.Text = reader.GetString(26);
                    txtheridasabiertas.Text = reader.GetString(27);
                    txtmachucon.Text = reader.GetString(28);
                    txtpartiduras.Text = reader.GetString(29);
                    txtpartidurasagua.Text = reader.GetString(30);
                    txtpartiduracicatrizada.Text = reader.GetString(31);
                    txtpitting.Text = reader.GetString(32);
                    txtpudricion.Text = reader.GetString(33);
                    txtmanchaspardas.Text = reader.GetString(34);
                    txtdanopajaro.Text = reader.GetString(35);
                    txtdesgarro.Text = reader.GetString(36);
                    txtcortesierra.Text = reader.GetString(37);
                    txt_sut_exp.Text = reader.GetString(38);
                    lbl_condicion.Text = reader.GetString(39);
                    lbl_productor.Text = reader.GetString(41);



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
            mpeEditOrder_todos.Hide();
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
            string consulta = "select 'Todas' as lincodigo union select distinct lincodigo from controlpt where turcodigo='" + turno + "' and placodigo = '" + txt_cod_plan.Text + "'";

            if(turno=="Todos")
            {

                consulta = "select 'Todas' as lincodigo union select distinct lincodigo from controlpt where placodigo = '" + txt_cod_plan.Text + "'";

            }
            else
            {

                consulta = "select 'Todas' as lincodigo union select distinct lincodigo from controlpt where turcodigo='" + turno + "' and placodigo = '" + txt_cod_plan.Text + "'";
            
            }


            SqlCommand cmd_linea = new SqlCommand(consulta, con);
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

            SqlCommand cmd_linea = new SqlCommand("select 'Todos' as turcodigo union select distinct turcodigo from controlpt where placodigo = '" + txt_cod_plan.Text + "'", con);
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
            string primera = "";
            string comando_cadena = "";
            if (resumen_proc.Checked) { primera = "select  cptproces, cptnulote, cptmardes,lincodigo,";

            if (turno == "Todos")
            {
                if (linea_2 == "Todas")
                {
                    comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "'" +
                 " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                }
                else
                {
                    comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                }
            }
            else
            {
                if (linea_2 == "Todas")
                {
                    comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                 " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                }
                else
                {
                    comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                }
            }
            }
            else
            {
                if (resumen_gral.Checked) { primera = "select lincodigo,";

                if (turno == "Todos")
                {
                    if (linea_2 == "Todas")
                    {
                        comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "'" +
                     " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                    }
                    else
                    {
                        comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                    " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                    }
                }
                else
                {
                    if (linea_2 == "Todas")
                    {
                        comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                     " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                    }
                    else
                    {
                        comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                    " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                    }
                }
                
              
                }
                else { primera = "select lincodigo,"; }
            }


                string inicio_consulta = " convert(varchar(255),CONVERT(decimal(18, 2),avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))) as [promedio_final]," +
                " (case when (avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))>=2 then 'Sobre el promedio'" +
                " else 'Cumple' end) Desviacion, placodigo, convert(varchar(255),count(1)) as casos," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))) as [promedio_final_condicion]," +
                " (case when (avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))>=10 then 'Sobre el promedio'" +
                " else 'Cumple' end) Desviacion_condicion, cl.turcodigo as turcodigo, cptnompre " +
                " from controlpt as cl " +
                " inner join defecto as def on cl.cptnumero=def.cptnumero";
        
                SqlCommand cmd_proc = new SqlCommand(primera + inicio_consulta + comando_cadena, con);
                SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                DataSet ds_proc = new DataSet();

                try
                {

                    if (resumen_proc.Checked)
                    {
                        gvProcesos.Visible = true;
                        sda_proc.Fill(ds_proc);
                        gvProcesos.DataSource = ds_proc;
                        gvProcesos.DataBind();
                        GridTodos.Visible = false;
                    }
                    else
                    {
                        if (resumen_gral.Checked)
                        {
                            GridTodos.Visible = true;
                            sda_proc.Fill(ds_proc);
                            GridTodos.DataSource = ds_proc;
                            GridTodos.DataBind();
                            gvProcesos.Visible = false;

                        }
                        else
                        {
                            GridTodos.Visible = false;
                            gvProcesos.Visible = false;
                        }
                    }

                    con.Close();

                }
                catch (Exception e)
                {
                    this.Page.Response.Write("<script language='JavaScript'>window.alert('" + e + "');</script>");
                }
            
        }

        private void gv_solubles(string proceso, string lote, string marca, string linea, string turno, string productor)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);
            string filtro = "";
           
            if (turno == "Todos")
            {
                if (linea_2 == "Todas")
                {
                    filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "'  and placodigo= '" + txt_cod_plan.Text + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'";
                }
                else
                {
                    filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "' and nrolinea='" + linea + "' and placodigo= '" + txt_cod_plan.Text + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'";
                }
            }
            else
            {
                if (linea_2 == "Todas")
                {
                    filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "' and turno='" + turno + "' and placodigo= '" + txt_cod_plan.Text + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'";
                }
                else
                {
                    filtro = " where nroproceso='" + proceso + "' and nrolote='" + lote + "' and turno='" + turno + "' and nrolinea='" + linea + "' and placodigo= '" + txt_cod_plan.Text + "' and cptmardes='" + marca + "' and cptnompre='" + productor + "'";
                }
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
            try
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

                string primera = "";
                string comando_cadena = "";

                if (resumen_proc.Checked)
                {
                    primera = "select  cptproces, cptnulote, cptmardes,lincodigo,";


                    if (turno == "Todos")
                    {
                        if (linea_2 == "Todas")
                        {
                            comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "'" +
                         " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                        }
                        else
                        {
                            comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                        " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                        }
                    }
                    else
                    {
                        if (linea_2 == "Todas")
                        {
                            comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                         " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                        }
                        else
                        {
                            comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                        " group by cl.turcodigo , cptproces, cptnulote,cptmardes,placodigo,lincodigo,cptnompre ;";
                        }
                    }
                }
                else
                {
                    resumen_gral.Checked = true;
                    if (resumen_gral.Checked)
                    {
                        primera = "select    lincodigo , cl.turcodigo as turcodigo,";

                        if (turno == "Todos")
                        {
                            if (linea_2 == "Todas")
                            {
                                comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "'" +
                             " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                            }
                            else
                            {
                                comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                            " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                            }
                        }
                        else
                        {
                            if (linea_2 == "Todas")
                            {
                                comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "'" +
                             " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                            }
                            else
                            {
                                comando_cadena = " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.placodigo= '" + planta + "' and cl.lincodigo='" + linea_2 + "'" +
                            " group by  cl.turcodigo , placodigo,lincodigo,cptnompre ;";
                            }
                        }


                    }
                    else { primera = "select lincodigo,"; }
                }


                string segunda_parte =
                         " convert(varchar(255),CONVERT(decimal(18, 2),avg(defprecal*1.0))) as [defprecal]," +
               " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanotr*1.0))) as [DAÑO TRIPS]," +
               " convert(varchar(255),CONVERT(decimal(18, 2),avg(defescama*1.0))) as [ESCAMA]," +
                    " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutode*1.0))) as [FRUTOS DEFORMES]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffrutodo*1.0))) as [FRUTOS DOBLES]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defguatab*1.0))) as [GUATA BLANCA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherida*1.0))) as [HERIDAS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmancha*1.0))) as [MANCHAS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmedial*1.0))) as [MEDIA LUNA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpiella*1.0))) as [PIEL DE LAGARTO]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defrusset*1.0))) as [RUSSET]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura*1.0))) as [SUTURA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(deffaltoc*1.0))) as [FALTO COLOR]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(deframole*1.0))) as [RAMALEO]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsinped*1.0))) as [SIN PEDICELO]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))) as [PROMEDIO CALIDAD]," +
                " (case when (avg((defprecal+defdanotr+defescama+deffrutode+deffrutodo+defguatab+defherida+defmancha+defmedial+defpiella+defrusset+defsutura+deffaltoc+deframole+defsinped)*1.0))>=2 then 'Sobre el promedio'" +
                " else 'Cumple' end) DESVIASION_CALIDAD, placodigo AS PLANTA, convert(varchar(255),count(1)) as CAJAS," +
                 " convert(varchar(255),CONVERT(decimal(18, 2),avg(defadhesi*1.0))) as [ADHESION]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesfru*1.0))) as [DESHIDRATACION DE FRUTOS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesped*1.0))) as [DESHIDRATACION PEDICELAR]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defblando*1.0))) as [BLANDOS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defherabi*1.0))) as [HERIDAS ABIERTAS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmachuc*1.0))) as [MACHUCON]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpartid*1.0))) as [PARTIDURA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparagu*1.0))) as [PARTIDURAS POR AGUA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defparcic*1.0))) as [PARTIDURA CICATRIZADA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpittin*1.0))) as [PITTING]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defpudric*1.0))) as [PUDRICION]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defmanpar*1.0))) as [MANCHAS PARDAS]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdanopa*1.0))) as [DAÑO DE PAJARO]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defdesgar*1.0))) as [DESGARROS]," +
                 " convert(varchar(255),CONVERT(decimal(18, 2),avg(defcorsie*1.0))) as [CORTE DE SIERRA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(defsutura_exp*1.0))) as [SUTURA EXPUESTA]," +
                " convert(varchar(255),CONVERT(decimal(18, 2),avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))) as [PROMEDIO CONDICION]," +
                 " (case when (avg(([defadhesi]+[defdesfru]+[defdesped]+[defblando]+[defherabi]+[defmachuc]+[defpartid]+[defparagu]+[defparcic]+[defpittin]+[defpudric]+[defmanpar]+[defdanopa]+[defdesgar]+[defcorsie]+[defsutura_exp])*1.0))>=10 then 'Sobre el promedio'" +
                 " else 'Cumple' end) DESVIASION_CONDICION, cptnompre as [PRODUCTOR] " +
                 " from controlpt as cl " +
                 " inner join defecto as def on cl.cptnumero=def.cptnumero";


                SqlCommand command = new SqlCommand(primera + segunda_parte + comando_cadena, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.ExportToExcel(dt, "Resultado.xls");
            }
            catch
            {

            }

        }

        protected void Filtrar(object sender, EventArgs e)
        {


            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            string linea_2 = Convert.ToString(drop_linea_d.SelectedValue);
  
            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);

            

        }

        protected void Resumen_total(object sender, EventArgs e)
        {
            string linea = "";
            string turno = "";
            string tipo = "todos";
            string productor = "";
            InitializeEditPopUp();
            PopUpDetalle_Todos(linea, turno, tipo, productor);
            
            mpeEditOrder_todos.Show();

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

        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();

        }

        protected void boton_Click(object sender, EventArgs e)
        {

            string file = @"C:\Temporalpdf\Resumen_005.pdf";

            if (System.IO.File.Exists(file))
            {

                try
                {
                    System.IO.File.Delete(file);
                }
                catch (System.IO.IOException ey)
                {
                    Console.WriteLine(ey.Message);
                }
            }
            
            string html_encabezado = "";

            html_encabezado = "<html><head></head><body>" +
                    "<img alt=\"Logo iText\" src=\"http://sisqc.sfg.cl:8080/sisqc/Images/logosfg.png\" height=\"54px\" width=\"235px\">" +
                     "</body></html>";

            StringWriter sw = new StringWriter();
            string html = sw.ToString();

            Document Doc = new Document();

            PdfWriter.GetInstance
            (Doc, new FileStream(file, FileMode.Create));
            Doc.Open();
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font times2 = new Font(bfTimes, 12, Font.NORMAL, Color.BLACK);
            Font times1 = new Font(bfTimes, 15, Font.NORMAL, Color.BLACK);

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html_encabezado), new StyleSheet()))
            Doc.Add(E);

            string titulo = "";
            string cuerpo = "";
            string texto_turno = "";
            if (resumen_proc.Checked)
            {
                if (drop_turno_d.Text == "Todos")
                {
                    titulo = "\n \n Resumen\n";
                }
                else
                {
                    titulo = "\n \n Resumen " + drop_turno_d.Text + "\n";
                }

                cuerpo = "\n \n \t Proceso \t \t \t : \t \t \t " + lbl_proceso.Text + " \t \t \t \t \tLote \t \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_lote.Text + " \t \t \t \t \t Marca \t \t \t \t \t \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_marca.Text + "   \n" +
             "\n \t Linea \t \t \t \t \t : \t \t \t " + lbl_linea_popup.Text + " \t \t \t \t \t \t Desde \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_desde.Text + " \t \tHasta \t \t \t \t \t \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_hasta.Text + "   \n" +
             "\n \t Cajas \t \t \t \t \t : \t \t \t " + lbl_casos.Text + " \t \t \t \t \t \t Promedio Calidad  : \t \t \t " + lbl_calidad.Text + " \t \t \t \t \t \t Promedio Condicion \t \t \t : \t \t \t " + lbl_condicion.Text + "      \n" +
            "\n\n \t \t DEFECTOS DE CALIDAD \n" +
            "	\n	Pre Calibre \t \t \t  : \t \t \t 	" + txtprecalibre.Text + " \t \t \t 	Guata Blanca \t \t \t : \t \t \t " + txtguatablanca.Text + "	 \t \t \t Russet \t \t \t \t \t \t \t \t \t : \t \t \t " + txtrusset.Text + "	\n	" +
            "	\n	Daño Trip \t \t \t \t  : \t \t \t 	" + txtdanotrip.Text + "	 \t \t \t Herida \t \t \t \t \t \t \t \t : \t \t \t " + txtherida.Text + "	 \t \t \t Sutura \t \t \t  \t \t \t \t \t \t : \t \t \t " + txtsutura.Text + "	\n	" +
            "	\n	Escama \t \t \t \t \t \t  : \t \t \t 	" + txtescama.Text + "	 \t \t \t Manchas \t \t \t \t \t \t  : \t \t \t " + txtmanchas.Text + "	 \t \t \t Falto de Color \t \t  : \t \t \t 	" + txtfaltocolor.Text + "	\n	" +
            "	\n	Frutos Deformes: \t \t  	" + txtfrutosdeformes.Text + " \t \t \t 	Media Luna \t \t \t   : \t \t \t " + txtmedialuna.Text + "	 \t \t \t Ramaleo \t \t \t \t \t \t \t : \t \t \t " + txtramaleo.Text + "	\n	" +
            "	\n	Frutos Dobles  \t : \t \t \t 	" + txtfrutosdobles.Text + "	 \t \t \t Piel de Lagarto \t : \t \t \t " + txtpiellagarto.Text + "	 \t \t \t Sin Pedicelo \t \t \t  \t : \t \t \t " + txtsinpedicelo.Text + "	\n	" +
            "\n\n \t \t DEFECTOS DE CONDICION \n" +
            "	\n	Adhesion \t \t \t \t \t \t \t  \t \t \t \t \t : \t \t \t " + txtadhesion.Text + " \t \t \t 	Partiduras \t \t \t \t \t \t \t \t \t : \t \t \t " + txtpartiduras.Text + " \t \t \t 	Daño de Pajaro \t \t \t : \t \t \t " + txtdanopajaro.Text + "	\n	" +
            "	\n	Deshidratacion de Frutos : \t \t \t " + txtdeshid.Text + " \t \t \t 	Partiduras por Agua \t : \t \t \t " + txtpartidurasagua.Text + " \t \t \t 	Desgarro \t \t \t \t \t \t \t \t : \t \t \t " + txtdesgarro.Text + "	\n	" +
            "	\n	Deshidratacion Pedicelar : \t \t \t " + txtdeshidpedi.Text + " \t \t \t 	Partidura Cicatrizada \t: \t \t \t " + txtpartiduracicatrizada.Text + " \t \t \t 	Corte de Sierra \t \t \t : \t \t \t " + txtcortesierra.Text + "	\n	" +
            "	\n	Blandos \t \t \t \t \t \t \t \t \t \t  \t \t \t : \t \t \t " + txtblandos.Text + " \t \t \t 	Pitting	 \t \t \t \t \t \t \t \t \t \t \t \t: \t \t \t 	" + txtpitting.Text + " \t \t \t Sutura Expuesta \t \t : \t \t \t " + txt_sut_exp.Text + "	\n	" +
            "	\n	Heridas Abiertas \t \t \t  \t \t \t : \t \t \t " + txtheridasabiertas.Text + " \t \t \t 	Pudricion \t \t \t \t \t \t \t \t \t \t: \t \t \t " + txtpudricion.Text + " \t \t \t \n	" +
            "	\n	Machucon \t \t \t \t \t \t  \t \t \t \t \t : \t \t \t " + txtmachucon.Text + " \t \t \t 	Manchas Pardas \t \t \t \t \t: \t \t \t " + txtmanchaspardas.Text + " \t \t \t 	" +

            "";
               
            }
            else
            {
                resumen_gral.Checked = true;
                if (resumen_gral.Checked)
                {
                    titulo = "\n \n Resumen";
                    texto_turno = "\n \t " + lbl_tit_turno.Text + " \t \t \t \t \t \t \t \t \t \t  \t \t \t " + lbl_turno_t.Text + " \t \t" + lbl_tit_linea.Text + " \t \t \t \t \t \t  " + lbl_linea_t.Text + " \t \t \t \t \t  \t \t \t" + lbl_tit_productor.Text + " \t  " + lbl_productor_t.Text + " \n";
                    cuerpo = "\n \t Desde \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_desde_t.Text + " \t \tHasta \t \t \t \t \t \t \t \t \t \t \t \t \t \t \t : \t \t \t " + lbl_hasta_t.Text + "   Cajas \t \t \t \t \t : \t \t \t " + lbl_cajas_t.Text + " \t \t \t \t \t \t \n" +
             "\n \t Promedio Calidad  : \t \t \t " + lbl_calidad_t.Text + " \t \t \t \t \t \t Promedio Condicion \t \t \t : \t \t \t " + lbl_condicion_t.Text + "      \n" +
            "\n\n \t \t DEFECTOS DE CALIDAD \n" +
            "	\n	Pre Calibre \t \t \t  : \t \t \t 	" + txt_precalibre_t.Text + " \t \t \t 	Guata Blanca \t \t \t : \t \t \t " + txtguatablanca_t.Text + "	 \t \t \t Russet \t \t \t \t \t \t \t \t \t : \t \t \t " + txt_russet_t.Text + "	\n	" +
            "	\n	Daño Trip \t \t \t \t  : \t \t \t 	" + txt_trip_t.Text + "	 \t \t \t Herida \t \t \t \t \t \t \t \t : \t \t \t " + txtherida_t.Text + "	 \t \t \t Sutura \t \t \t  \t \t \t \t \t \t : \t \t \t " + txt_sutura_t.Text + "	\n	" +
            "	\n	Escama \t \t \t \t \t \t  : \t \t \t 	" + txtescama_t.Text + "	 \t \t \t Manchas \t \t \t \t \t \t  : \t \t \t " + txtmanchas_t.Text + "	 \t \t \t Falto de Color \t \t  : \t \t \t 	" + txtfaltocolor_t.Text + "	\n	" +
            "	\n	Frutos Deformes: \t \t  	" + txtfrutosdeformes_t.Text + " \t \t \t 	Media Luna \t \t \t   : \t \t \t " + txtmedialuna_t.Text + "	 \t \t \t Ramaleo \t \t \t \t \t \t \t : \t \t \t " + txtramaleo_t.Text + "	\n	" +
            "	\n	Frutos Dobles  \t : \t \t \t 	" + txtfrutosdobles_t.Text + "	 \t \t \t Piel de Lagarto \t : \t \t \t " + txtpiellagarto_t.Text + "	 \t \t \t Sin Pedicelo \t \t \t  \t : \t \t \t " + txtsinpedicelo_t.Text + "	\n	" +
            "\n\n \t \t DEFECTOS DE CONDICION \n" +
            "	\n	Adhesion \t \t \t \t \t \t \t  \t \t \t \t \t : \t \t \t " + txt_adhesion_t.Text + " \t \t \t 	Partiduras \t \t \t \t \t \t \t \t \t : \t \t \t " + txtpartiduras_t.Text + " \t \t \t 	Daño de Pajaro \t \t \t : \t \t \t " + txtdanopajaro_t.Text + "	\n	" +
            "	\n	Deshidratacion de Frutos : \t \t \t " + txt_deshidfru_t.Text + " \t \t \t 	Partiduras por Agua \t : \t \t \t " + txtpartidurasagua_t.Text + " \t \t \t 	Desgarro \t \t \t \t \t \t \t \t : \t \t \t " + txtdesgarro_t.Text + "	\n	" +
            "	\n	Deshidratacion Pedicelar : \t \t \t " + txtdeshidpedi_t.Text + " \t \t \t 	Partidura Cicatrizada \t: \t \t \t " + txtpartiduracicatrizada_t.Text + " \t \t \t 	Corte de Sierra \t \t \t : \t \t \t " + txtcortesierra_t.Text + "	\n	" +
            "	\n	Blandos \t \t \t \t \t \t \t \t \t \t  \t \t \t : \t \t \t " + txtblandos_t.Text + " \t \t \t 	Pitting	 \t \t \t \t \t \t \t \t \t \t \t \t: \t \t \t 	" + txtpitting_t.Text + " \t \t \t Sutura Expuesta \t \t : \t \t \t " + txt_sut_exp_t.Text + "	\n	" +
            "	\n	Heridas Abiertas \t \t \t  \t \t \t : \t \t \t " + txtheridasabiertas_t.Text + " \t \t \t 	Pudricion \t \t \t \t \t \t \t \t \t \t: \t \t \t " + txt_pudricion_t.Text + " \t \t \t \n	" +
            "	\n	Machucon \t \t \t \t \t \t  \t \t \t \t \t : \t \t \t " + txtmachucon_t.Text + " \t \t \t 	Manchas Pardas \t \t \t \t \t: \t \t \t " + txt_manchaspardas_t.Text + " \t \t \t 	" +

            "";
                }
                else
                {
                    titulo = "\n \n Resumen";
                    
                }
                
            }
            
            Chunk c = new Chunk(titulo, times1);

            Paragraph p = new Paragraph();
            p.Alignment = Element.ALIGN_CENTER;
            p.Add(c);

            Chunk chunk1 = new Chunk (cuerpo, times2);
            Chunk chunk_2 = new Chunk(texto_turno, times2);

            Paragraph p1 = new Paragraph();
            p1.Alignment = Element.ALIGN_LEFT;
            p1.Add(chunk1);

            Paragraph p2 = new Paragraph();
            p2.Alignment = Element.ALIGN_LEFT;
            p2.Add(chunk_2);
           
            
            Doc.Add(p);
            Doc.Add(p2);
            Doc.Add(p1);
            
 
            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new StringReader(html));
            HtmlParser.Parse(Doc, xmlReader);

            Doc.Close();

            ShowPdf(file);

        }
 
    }
}
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
using Microsoft.Reporting.WebForms;


namespace SisConPT.SisConPT
{
    public partial class Detalle_CC_PAC_005 : System.Web.UI.Page
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


        }

        private void DropLinea()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());

            con.Open();

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

            SqlCommand cmd_linea = new SqlCommand("select distinct turcodigo from controlpt where lincodigo ='" + linea + "' and placodigo = " + txt_cod_plan.Text + "", con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            try
            { 
            drop_turno_d.DataSourceID = "";
            drop_turno_d.DataSource = ds_linea;
            drop_turno_d.DataBind();


                string turno = Convert.ToString(drop_turno_d.SelectedValue);
                int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

                con.Close();
            }
            catch 
            {
                drop_turno_d.DataSourceID = "";
                drop_turno_d.DataSource = "";
                drop_turno_d.DataBind();

            }

            
        }

        protected void Procesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
       
            GridView gvProcesos = (GridView)sender;
            gvProcesos.PageIndex = e.NewPageIndex;

            string turno = Convert.ToString(drop_turno_d.SelectedValue);
            int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);

            string inicio = txt_fechainicio.Text;
            string fin = txt_fechafin.Text;

            GvProcesos_Llenar(turno, linea_2, inicio, fin);
    
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
            " cl.lincodigo as lincodigo,cl.cptproces as cptproces,cl.cptnulote as cptnulote,cl.cptrutprr as cptrutprr,cl.cptnompre as cptnompre,"+
            " cl.cptrutpet as cptrutpet,cl.cptnompet as cptnompet,cl.cptespcod as cptespcod,cl.cptespdes as cptespdes,cl.cptvarcod as cptvarcod,"+
            " cl.cptvardes as cptvardes,cl.cptcalibr as cptcalibr,cl.cptmarcod as cptmarcod,cl.cptmardes as cptmardes,cl.cptembcod as cptembcod,"+
            " cl.cptembdes as cptembdes,cl.cptenvcod as cptenvcod,cl.cptenvdes as cptenvdes,cl.cptpesone as cptpesone,cl.cptsalida as cptsalida,"+
            " cl.cptcodcja as cptcodcja,cl.cptclasificacion as cptclasificacion,cl.cptdestino as cptdestino,cl.cptcajasvaciadas as cptcajasvaciadas,"+
            " def.defcalbaj as defcalbaj,def.defcalnor as defcalnor,def.defcalsob as defcalsob,def.defprecal as defprecal,def.defdanotr as defdanotr,"+
            " def.defescama as defescama,def.deffrutode as deffrutode,def.deffrutodo as deffrutodo,def.defguatab as defguatab,def.defherida as defherida,"+
            " def.defmancha as defmancha,def.defmedial as defmedial,def.defpiella as defpiella,def.defrusset as defrusset,def.defsutura as defsutura,"+
            " def.deffaltoc as deffaltoc,def.deframole as deframole,def.defsinped as defsinped,def.defadhesi as defadhesi,def.defdesfru as defdesfru,"+
            " def.defdesped as defdesped,def.defblando as defblando,def.defherabi as defherabi,def.defmachuc as defmachuc,def.defpartid as defpartid,"+
            " def.defparagu as defparagu,def.defparcic as defparcic,def.defpittin as defpittin,def.defpudric as defpudric,def.defmanpar as defmanpar,"+
            " def.defdanopa as defdanopa,def.defdesgar as defdesgar,def.defcorsie as defcorsie,def.solsolub as solsolub,def.observac as observac,"+
            " def.pesoneto as pesoneto,sol.calibresoluble as calibresoluble,sol.f1 as f1,sol.f2 as f2,sol.f3 as f3,sol.f4 as f4,sol.f5 as f5,sol.nrolinea as nrolinea "+
            " from controlpt as cl  inner join defecto as def on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptcodcja=sol.codcaja "+
            " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.lincodigo='" + linea_2 + "' and cl.placodigo= " + planta + "";

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


            string sql = "select cl.placodigo as PLANTA,cl.turcodigo as TURNO,cl.cptfechor as FECHA,cl.usurutusu as USUARIO," +
            " cl.lincodigo as LINEA,cl.cptproces as PROCESO,cl.cptnulote as LOTE,cl.cptrutprr as IDPROD_REAL,cl.cptnompre as PROD_REAL," +
            " cl.cptrutpet as IDPROD_ETIQUETADO,cl.cptnompet as PROD_ETIQUETADO,cl.cptespcod as IDESPECIE,cl.cptespdes as ESPECIE,cl.cptvarcod as IDVARIEDAD," +
            " cl.cptvardes as VARIEDAD,cl.cptcalibr as CALIBRE,cl.cptmarcod as IDMARCA,cl.cptmardes as MARCA,cl.cptembcod as IDEMBALAJE," +
            " cl.cptembdes as EMBALAJE,cl.cptenvcod as IDENVASE,cl.cptenvdes as ENVASE,cl.cptpesone as PESO_NETO,cl.cptsalida as SALIDA," +
            " cl.cptcodcja as CODIGO_CAJA,cl.cptclasificacion as CLASIFICACION,cl.cptdestino as DESTINO,cl.cptcajasvaciadas as CAJAS_VACIADAS," +
            " def.defcalbaj as BAJO,def.defcalnor as CAL_NORMAL,def.defcalsob as SOBRE,def.defprecal as PRECALIBRE,def.defdanotr as DANO_TRIP," +
            " def.defescama as ESCAMA,def.deffrutode as FRUTO_DEFORME,def.deffrutodo as FRUTO_DOBLE,def.defguatab as GUATA_BLANCA,def.defherida as HERIDA," +
            " def.defmancha as MANCHAS,def.defmedial as MEDIA_LUNA,def.defpiella as PIEL_LAGARTO,def.defrusset as RUSSET,def.defsutura as SUTURA," +
            " def.deffaltoc as FALTO_COLOR,def.deframole as RAMALEO,def.defsinped as SIN_PEDICELO,def.defadhesi as ADHESION,def.defdesfru as DESH_FRUTOS," +
            " def.defdesped as DESH_PEDICELAR,def.defblando as BLANDOS,def.defherabi as HERIDAS_ABIERTAS,def.defmachuc as MACHUCON,def.defpartid as PARTIDURAS," +
            " def.defparagu as PART_AGUA,def.defparcic as PART_CICATRIZADAS,def.defpittin as PITTING,def.defpudric as PUDRICION,def.defmanpar as MANCHAS_PARDAS," +
            " def.defdanopa as DANO_PAJARO,def.defdesgar as DESGARRE,def.defcorsie as CORTE_SIERRAS,def.observac as OBSERVACIONES," +
            " def.pesoneto as PESO_NETO_II,sol.calibresoluble as CALIBRE_II,sol.f1 as f1,sol.f2 as f2,sol.f3 as f3,sol.f4 as f4,sol.f5 as f5 " +
            " from controlpt as cl  inner join defecto as def on cl.cptnumero=def.cptnumero inner join solidossolubles as sol on cl.cptcodcja=sol.codcaja " +
            " where (cl.cptfechor>='" + inicio + "' and cl.cptfechor <= '" + fin + "') and cl.turcodigo='" + turno + "' and cl.lincodigo='" + linea_2 + "' and cl.placodigo= " + planta + "";

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
                Response.Redirect("~/SisConPT/Detalle_CC_PAC_005.aspx");
            }
        }

    }
}
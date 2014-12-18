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
    public partial class Ingreso_CC_PAC_003_sat : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
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
            
         if (!IsPostBack)
            {
                DropTurno();
                DDL_linea();
                DDL_prodreal();
                DropVariedad();
            }


}

        protected void prodreal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void variedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DropVariedad()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select COD_VARIEDAD, VARDESC from VARIEDAD where CODESPECIE=21 order by vardesc asc", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_variedad_d.DataSourceID = "";
            DDL_variedad_d.DataSource = ds_proc;
            DDL_variedad_d.DataBind();
            con.Close();



        }
        private void DDL_prodreal()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select CODPRODUCTOR, ALIAS, DESCRIPCION from [dbo].[PRODUCTORES] group by CODPRODUCTOR, ALIAS, DESCRIPCION order by DESCRIPCION asc", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_prodreal_d.DataSourceID = "";
            DDL_prodreal_d.DataSource = ds_proc;
            DDL_prodreal_d.DataBind();

            con.Close();

        }
        private void DDL_linea()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select lin_descrip as linea from linea_sat", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_linea_d.DataSourceID = "";
            DDL_linea_d.DataSource = ds_proc;
            DDL_linea_d.DataBind();

            con.Close();
        }
        private void DropTurno()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select tur_nombre as turno from turno_sat", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_turno_d.DataSourceID = "";
            DDL_turno_d.DataSource = ds_proc;
            DDL_turno_d.DataBind();

            con.Close();
        }
        protected void Click_guardar(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            string CodProc = NroProceso.Text;
            string Linea = DDL_linea_d.SelectedValue;
            string Turno = DDL_turno_d.SelectedValue;
            string lote = Lote.Text;
            string Variedad = DDL_variedad_d.SelectedValue;
            string productor = DDL_prodreal_d.SelectedValue;
            if (txt_precalibre.Text == "") { txt_precalibre.Text = "0"; }
            if (txt_trips.Text == "") { txt_trips.Text = "0"; }
            if (txt_adhesion.Text == "") { txt_adhesion.Text = "0"; }
            if (txt_deshid_frutos.Text == "") { txt_deshid_frutos.Text = "0"; }
            if (txt_escama.Text == "") { txt_escama.Text = "0"; }
            if (txt_frudeformes.Text == "") { txt_frudeformes.Text = "0"; }
            if (txt_deshid_ped.Text == "") { txt_deshid_ped.Text = "0"; }
            if (txt_blandos.Text == "") { txt_blandos.Text = "0"; }
            if (txt_dobles.Text == "") { txt_dobles.Text = "0"; }
            if (txt_guatablanca.Text == "") { txt_guatablanca.Text = "0"; }
            if (txt_heri_abiertas.Text == "") { txt_heri_abiertas.Text = "0"; }
            if (txt_machucon.Text == "") { txt_machucon.Text = "0"; }
            if (txt_heri_cica.Text == "") { txt_heri_cica.Text = "0"; }
            if (txt_manchas.Text == "") { txt_manchas.Text = "0"; }
            if (txt_part_cica.Text == "") { txt_part_cica.Text = "0"; }
            if (txt_pitting.Text == "") { txt_pitting.Text = "0"; }
            if (txt_medluna.Text == "") { txt_medluna.Text = "0"; }
            if (txt_lagarto.Text == "") { txt_lagarto.Text = "0"; }
            if (txt_pudricion.Text == "") { txt_pudricion.Text = "0"; }
            if (txt_part_agua.Text == "") { txt_part_agua.Text = "0"; }
            if (txt_russet.Text == "") { txt_russet.Text = "0"; }
            if (txt_sutura.Text == "") { txt_sutura.Text = "0"; }
            if (txt_pardas.Text == "") { txt_pardas.Text = "0"; }
            if (txt_pajaro.Text == "") { txt_pajaro.Text = "0"; }
            if (txt_faltocolor.Text == "") { txt_faltocolor.Text = "0"; }
            if (txt_ramaleo.Text == "") { txt_ramaleo.Text = "0"; }
            if (txt_desgarros.Text == "") { txt_desgarros.Text = "0"; }
            if (txt_sierras.Text == "") { txt_sierras.Text = "0"; }
            if (txt_defcalidad.Text == "") { txt_defcalidad.Text = "0"; }
            if (txt_defcondicion.Text == "") { txt_defcondicion.Text = "0"; }
            if (txt_qc_pudricion.Text == "") { txt_qc_pudricion.Text = "0"; }
            if (txt_comp_pudricion.Text == "") { txt_comp_pudricion.Text = "0"; }
            if (txt_qc_deshechos.Text == "") { txt_qc_deshechos.Text = "0"; }
            if (txt_comp_deshechos.Text == "") { txt_comp_deshechos.Text = "0"; }
            if (txt_qc_exportable.Text == "") { txt_qc_exportable.Text = "0"; }
            if (txt_comp_exportable.Text == "") { txt_comp_exportable.Text = "0"; }
            if (txt_qc_deshecho_com.Text == "") { txt_qc_deshecho_com.Text = "0"; }
            if (txt_comp_deshecho_com.Text == "") { txt_comp_deshecho_com.Text = "0"; }
            if (txt_num_frutos.Text == "") { txt_num_frutos.Text = "0"; }
            if (txt_exportable_2.Text == "") { txt_exportable_2.Text = "0"; }
            if (txt_comercial_5.Text == "") { txt_comercial_5.Text = "0"; }
            if (txt_obser.Text == "") { txt_obser.Text = "0"; }
            if (txt_sut_exp.Text == "") { txt_sut_exp.Text = "0"; }
            

            string comando = "insert into CC_PAC_003 (Ctrl_id,Ctrl_CodProc,Ctrl_CodPlan,Ctrl_Lin,Ctrl_Usuario,Ctrl_Turno,Ctrl_Lote,Ctrl_FecHora,txt_precalibre," +
            " txt_trips,txt_adhesion,txt_deshid_frutos,txt_escama,txt_frudeformes,txt_deshid_ped,txt_blandos,txt_dobles,txt_guatablanca,txt_heri_abiertas," +
            " txt_machucon,txt_heri_cica,txt_manchas,txt_part_cica,txt_pitting,txt_medluna,txt_lagarto,txt_pudricion,txt_part_agua,txt_russet,txt_sutura," +
            " txt_pardas,txt_pajaro,txt_faltocolor,txt_ramaleo,txt_desgarros,txt_sierras,txt_defcalidad,txt_defcondicion,txt_qc_pudricion,txt_comp_pudricion," +
            " txt_qc_deshechos,txt_comp_deshechos,txt_qc_exportable,txt_comp_exportable,txt_qc_deshecho_com,txt_comp_deshecho_com,txt_num_frutos,txt_exportable_2," +
            " txt_comercial_5,txt_obser,productor,variedad,txt_pedicelo,txt_sut_exp) values ('" + numeroctrl + "','" + CodProc + "','" + txt_cod_plan.Text + "','" + Linea + "'," +
            " '" + username + "','" + Turno + "','" + lote + "','" + numeroctrl + "'," + txt_precalibre.Text + "," + txt_trips.Text + "," + txt_adhesion.Text + "," +
            " " + txt_deshid_frutos.Text + "," + txt_escama.Text + "," + txt_frudeformes.Text + "," + txt_deshid_ped.Text + "," + txt_blandos.Text + "," +
            " " + txt_dobles.Text + "," + txt_guatablanca.Text + "," + txt_heri_abiertas.Text + "," + txt_machucon.Text + "," + txt_heri_cica.Text + "," +
            " " + txt_manchas.Text + "," + txt_part_cica.Text + "," + txt_pitting.Text + "," + txt_medluna.Text + "," + txt_lagarto.Text + "," + txt_pudricion.Text + "," +
            " " + txt_part_agua.Text + "," + txt_russet.Text + "," + txt_sutura.Text + "," + txt_pardas.Text + "," + txt_pajaro.Text + "," + txt_faltocolor.Text + "," +
            " " + txt_ramaleo.Text + "," + txt_desgarros.Text + "," + txt_sierras.Text + "," + txt_defcalidad.Text + "," + txt_defcondicion.Text + "," +
            " " + txt_qc_pudricion.Text + "," + txt_comp_pudricion.Text + "," + txt_qc_deshechos.Text + "," + txt_comp_deshechos.Text + "," + txt_qc_exportable.Text + "," +
            " " + txt_comp_exportable.Text + "," + txt_qc_deshecho_com.Text + "," + txt_comp_deshecho_com.Text + "," + txt_num_frutos.Text + "," + txt_exportable_2.Text + "," +
            " " + txt_comercial_5.Text + ",'" + txt_obser.Text + "', '" + productor + "', '" + Variedad + "', '" + txt_pedicelo.Text + "','" + txt_sut_exp.Text + "')";
            
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();
            using (SqlCommand sql = new SqlCommand(comando, conexion))
            {
                sql.ExecuteNonQuery();
                conexion.Close();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptName", "alert(\"Registro guardado ok\");", true);

            txt_precalibre.Text = "";
            txt_trips.Text = "";
            txt_adhesion.Text = "";
            txt_deshid_frutos.Text = "";
            txt_escama.Text = "";
            txt_frudeformes.Text = "";
            txt_deshid_ped.Text = "";
            txt_blandos.Text = "";
            txt_dobles.Text = "";
            txt_guatablanca.Text = "";
            txt_heri_abiertas.Text = "";
            txt_machucon.Text = "";
            txt_heri_cica.Text = "";
            txt_manchas.Text = "";
            txt_part_cica.Text = "";
            txt_pitting.Text = "";
            txt_medluna.Text = "";
            txt_lagarto.Text = "";
            txt_pudricion.Text = "";
            txt_part_agua.Text = "";
            txt_russet.Text = "";
            txt_sutura.Text = "";
            txt_pardas.Text = "";
            txt_pajaro.Text = "";
            txt_faltocolor.Text = "";
            txt_ramaleo.Text = "";
            txt_desgarros.Text = "";
            txt_sierras.Text = "";
            txt_pedicelo.Text = "";
            txt_defcalidad.Text = "";
            txt_defcondicion.Text = "";
            txt_qc_pudricion.Text = "";
            txt_comp_pudricion.Text = "";
            txt_qc_deshechos.Text = "";
            txt_comp_deshechos.Text = "";
            txt_qc_exportable.Text = "";
            txt_comp_exportable.Text = "";
            txt_qc_deshecho_com.Text = "";
            txt_comp_deshecho_com.Text = "";
            txt_num_frutos.Text = "";
            txt_exportable_2.Text = "";
            txt_comercial_5.Text = "";
            txt_obser.Text = "";
            txt_sut_exp.Text = "";
            txt_precalibre.Focus();

        }

        protected void Click_limpiar(object sender, EventArgs e)
        {
            txt_precalibre.Text = "";
            txt_trips.Text = "";
            txt_adhesion.Text = "";
            txt_deshid_frutos.Text = "";
            txt_escama.Text = "";
            txt_frudeformes.Text = "";
            txt_deshid_ped.Text = "";
            txt_blandos.Text = "";
            txt_dobles.Text = "";
            txt_guatablanca.Text = "";
            txt_heri_abiertas.Text = "";
            txt_machucon.Text = "";
            txt_heri_cica.Text = "";
            txt_manchas.Text = "";
            txt_part_cica.Text = "";
            txt_pitting.Text = "";
            txt_medluna.Text = "";
            txt_lagarto.Text = "";
            txt_pudricion.Text = "";
            txt_part_agua.Text = "";
            txt_russet.Text = "";
            txt_sutura.Text = "";
            txt_pardas.Text = "";
            txt_pajaro.Text = "";
            txt_faltocolor.Text = "";
            txt_ramaleo.Text = "";
            txt_desgarros.Text = "";
            txt_sierras.Text = "";
            txt_defcalidad.Text = "";
            txt_defcondicion.Text = "";
            txt_qc_pudricion.Text = "";
            txt_comp_pudricion.Text = "";
            txt_qc_deshechos.Text = "";
            txt_comp_deshechos.Text = "";
            txt_qc_exportable.Text = "";
            txt_comp_exportable.Text = "";
            txt_qc_deshecho_com.Text = "";
            txt_comp_deshecho_com.Text = "";
            txt_num_frutos.Text = "";
            txt_exportable_2.Text = "";
            txt_comercial_5.Text = "";
            txt_obser.Text = "";
            txt_sut_exp.Text = ""; 
            txt_precalibre.Focus();

        }
    }
}
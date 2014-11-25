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
    public partial class Ingreso_CC_PAC_003 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.txt_cod_proc.Attributes.Add("onkeypress", "button_click(this,'" + this.btnLoadData.ClientID + "')");
            //txt_cod_proc.Focus();
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
          
        protected void proc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            DropLote(proceso);
            
        }
           
        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

            BuscaTurno(linea);
            
        }
      
        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);
            string turno = Convert.ToString(drop_turno_d.SelectedValue);

            DDLProcesos(linea, turno);
            
        }
         
        protected void lote_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //txtDescarte.Focus();
            datos();
            
        }

        protected void variedad_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtDescarte.Focus();

        }
        
        private void DDLProcesos(int linea, string turno)
             {

                 System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
                 System.Configuration.ConnectionStringSettings connStringLM;
                 if (Session["PlantaName"].ToString() == "Planta Mostazal")
                 {
                     connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
                 }
                 else
                 {
                     connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
                 }
                 SqlConnection con = new SqlConnection(connStringLM.ToString());
                 con.Open();
                 //linea
                 SqlCommand cmd_proc = new SqlCommand("select  PROC_NumeroProcesso from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk inner join ANA_Turno as tur on tur.TUR_Linea_FK=lin.lin_codice where lin.LIN_Codice=" + linea + " and tur.TUR_Descrizione='" + turno + "' group by PROC_NumeroProcesso order by PROC_NumeroProcesso desc", con);
                 SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                 DataSet ds_proc = new DataSet();
                 sda_proc.Fill(ds_proc);

                 drop_proc_d.DataSourceID = "";
                 drop_proc_d.DataSource = ds_proc;
                 drop_proc_d.DataBind();

               
                 if (drop_proc_d.Items.Count != 0)
                 {
                     int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

                     DropLote(proceso);
                 }
                 con.Close();
             }

        private void DropLinea()
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            //SqlCommand cmd_linea = new SqlCommand("select  LIN_Codice from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk where proc_numeroprocesso=" + cod_proc_busca + "group by LIN_Codice", con);
            SqlCommand cmd_linea = new SqlCommand("select  LIN_Codice from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk group by LIN_Codice", con);
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
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //turno
            SqlCommand cmd_turno = new SqlCommand("select tur_codice, TUR_Descrizione from Ana_Turno where tur_linea_fk=" + linea + "", con);
            SqlDataAdapter sda_turno = new SqlDataAdapter(cmd_turno);
            DataSet ds_turno = new DataSet();
            sda_turno.Fill(ds_turno);

            drop_turno_d.DataSourceID = "";
            drop_turno_d.DataSource = ds_turno;
            drop_turno_d.DataBind();


            if (drop_turno_d.Items.Count != 0)
            {
                int linea_2 = Convert.ToInt32(drop_linea_d.SelectedValue);
                string turno = Convert.ToString(drop_turno_d.SelectedValue);

                DDLProcesos(linea_2, turno);

            }
            con.Close();
        }

        protected void datos()
        {
            string proceso = Convert.ToString(drop_proc_d.SelectedValue);
            string lote = Convert.ToString(drop_lote_d.SelectedValue);


            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //turno
            SqlCommand cmd_lote = new SqlCommand("select distinct PROC_NumeroProcesso, PROC_DescrizioneProduttore,lote.LOT_DescrizioneSpecie ,lote.LOT_DescrizioneVarieta from PROD_Lotto as lote inner join  [PROD_Processo] as proce on lote.LOT_processo_FK=proce.proc_id where  proce.proc_numeroprocesso=" + proceso + " and lot_numerolotto=" + lote + " and LOT_DescrizioneSpecie='CEREZAS'", con);
            SqlDataAdapter sda_lote = new SqlDataAdapter(cmd_lote);
            DataSet ds_lote = new DataSet();
            sda_lote.Fill(ds_lote);

            drop_variedad_d.DataSourceID = "";
            drop_variedad_d.DataSource = ds_lote;
            drop_variedad_d.DataBind();

            con.Close();


            con.Open();
            SqlCommand cmd_proc = new SqlCommand("select distinct  PROC_DescrizioneProduttore from PROD_Lotto as lote inner join  [PROD_Processo] as proce on lote.LOT_processo_FK=proce.proc_id where  proce.proc_numeroprocesso=" + proceso + " and lot_numerolotto=" + lote + " and LOT_DescrizioneSpecie='CEREZAS'", con);
            try
            {

                using (SqlDataReader reader = cmd_proc.ExecuteReader())
                {
                    reader.Read();
                    lbl_productor.Text = reader.GetString(0);

                }
            }
            catch
            {
            }
            con.Close();
        }

        private void DropLote(int proceso)
        {

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //turno
            SqlCommand cmd_lote = new SqlCommand("select distinct LOT_NumeroLotto from PROD_Lotto as lote inner join  [PROD_Processo] as proce on lote.LOT_processo_FK=proce.proc_id where  proce.proc_numeroprocesso=" + proceso + "", con);
            SqlDataAdapter sda_lote = new SqlDataAdapter(cmd_lote);
            DataSet ds_lote = new DataSet();
            sda_lote.Fill(ds_lote);

            drop_lote_d.DataSourceID = "";
            drop_lote_d.DataSource = ds_lote;
            drop_lote_d.DataBind();

            con.Close();

            if (drop_lote_d.Items.Count != 0)
            {
                datos();

            }



        }

        protected void Click_guardar(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            string CodProc = drop_proc_d.SelectedValue;
            string Linea = drop_linea_d.SelectedValue;
            string Turno = drop_turno_d.SelectedValue;
            string Lote = drop_lote_d.SelectedValue;
            string Variedad = drop_variedad_d.SelectedValue;
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


            string comando = "insert into CC_PAC_003 (Ctrl_id,Ctrl_CodProc,Ctrl_CodPlan,Ctrl_Lin,Ctrl_Usuario,Ctrl_Turno,Ctrl_Lote,Ctrl_FecHora,txt_precalibre,txt_trips,txt_adhesion,txt_deshid_frutos,txt_escama,txt_frudeformes,txt_deshid_ped,txt_blandos,txt_dobles,txt_guatablanca,txt_heri_abiertas,txt_machucon,txt_heri_cica,txt_manchas,txt_part_cica,txt_pitting,txt_medluna,txt_lagarto,txt_pudricion,txt_part_agua,txt_russet,txt_sutura,txt_pardas,txt_pajaro,txt_faltocolor,txt_ramaleo,txt_desgarros,txt_sierras,txt_defcalidad,txt_defcondicion,txt_qc_pudricion,txt_comp_pudricion,txt_qc_deshechos,txt_comp_deshechos,txt_qc_exportable,txt_comp_exportable,txt_qc_deshecho_com,txt_comp_deshecho_com,txt_num_frutos,txt_exportable_2,txt_comercial_5,txt_obser,productor,variedad,txt_pedicelo) values ('" + numeroctrl + "','" + CodProc + "','" + txt_cod_plan.Text + "','" + Linea + "','" + username + "','" + Turno + "','" + Lote + "','" + numeroctrl + "'," + txt_precalibre.Text + "," + txt_trips.Text + "," + txt_adhesion.Text + "," + txt_deshid_frutos.Text + "," + txt_escama.Text + "," + txt_frudeformes.Text + "," + txt_deshid_ped.Text + "," + txt_blandos.Text + "," + txt_dobles.Text + "," + txt_guatablanca.Text + "," + txt_heri_abiertas.Text + "," + txt_machucon.Text + "," + txt_heri_cica.Text + "," + txt_manchas.Text + "," + txt_part_cica.Text + "," + txt_pitting.Text + "," + txt_medluna.Text + "," + txt_lagarto.Text + "," + txt_pudricion.Text + "," + txt_part_agua.Text + "," + txt_russet.Text + "," + txt_sutura.Text + "," + txt_pardas.Text + "," + txt_pajaro.Text + "," + txt_faltocolor.Text + "," + txt_ramaleo.Text + "," + txt_desgarros.Text + "," + txt_sierras.Text + "," + txt_defcalidad.Text + "," + txt_defcondicion.Text + "," + txt_qc_pudricion.Text + "," + txt_comp_pudricion.Text + "," + txt_qc_deshechos.Text + "," + txt_comp_deshechos.Text + "," + txt_qc_exportable.Text + "," + txt_comp_exportable.Text + "," + txt_qc_deshecho_com.Text + "," + txt_comp_deshecho_com.Text + "," + txt_num_frutos.Text + "," + txt_exportable_2.Text + "," + txt_comercial_5.Text + ",'" + txt_obser.Text + "', '" + lbl_productor.Text + "', '" + Variedad + "', '" + txt_pedicelo.Text + "')";
            // con comillas
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

            string error = "Registro guardado OK";
            Response.Write("<script language=javascript > alert('" + error + "'); </script>");

            txt_precalibre.Text = "0";
            txt_trips.Text = "0";
            txt_adhesion.Text = "0";
            txt_deshid_frutos.Text = "0";
            txt_escama.Text = "0";
            txt_frudeformes.Text = "0";
            txt_deshid_ped.Text = "0";
            txt_blandos.Text = "0";
            txt_dobles.Text = "0";
            txt_guatablanca.Text = "0";
            txt_heri_abiertas.Text = "0";
            txt_machucon.Text = "0";
            txt_heri_cica.Text = "0";
            txt_manchas.Text = "0";
            txt_part_cica.Text = "0";
            txt_pitting.Text = "0";
            txt_medluna.Text = "0";
            txt_lagarto.Text = "0";
            txt_pudricion.Text = "0";
            txt_part_agua.Text = "0";
            txt_russet.Text = "0";
            txt_sutura.Text = "0";
            txt_pardas.Text = "0";
            txt_pajaro.Text = "0";
            txt_faltocolor.Text = "0";
            txt_ramaleo.Text = "0";
            txt_desgarros.Text = "0";
            txt_sierras.Text = "0";
            txt_pedicelo.Text = "0";
            txt_defcalidad.Text = "0";
            txt_defcondicion.Text = "0";
            txt_qc_pudricion.Text = "0";
            txt_comp_pudricion.Text = "0";
            txt_qc_deshechos.Text = "0";
            txt_comp_deshechos.Text = "0";
            txt_qc_exportable.Text = "0";
            txt_comp_exportable.Text = "0";
            txt_qc_deshecho_com.Text = "0";
            txt_comp_deshecho_com.Text = "0";
            txt_num_frutos.Text = "0";
            txt_exportable_2.Text = "0";
            txt_comercial_5.Text = "0";
            txt_obser.Text = "0";
            txt_precalibre.Focus();




        }

        protected void Click_limpiar(object sender, EventArgs e)
        {
            txt_precalibre.Text = "0";
            txt_trips.Text = "0";
            txt_adhesion.Text = "0";
            txt_deshid_frutos.Text = "0";
            txt_escama.Text = "0";
            txt_frudeformes.Text = "0";
            txt_deshid_ped.Text = "0";
            txt_blandos.Text = "0";
            txt_dobles.Text = "0";
            txt_guatablanca.Text = "0";
            txt_heri_abiertas.Text = "0";
            txt_machucon.Text = "0";
            txt_heri_cica.Text = "0";
            txt_manchas.Text = "0";
            txt_part_cica.Text = "0";
            txt_pitting.Text = "0";
            txt_medluna.Text = "0";
            txt_lagarto.Text = "0";
            txt_pudricion.Text = "0";
            txt_part_agua.Text = "0";
            txt_russet.Text = "0";
            txt_sutura.Text = "0";
            txt_pardas.Text = "0";
            txt_pajaro.Text = "0";
            txt_faltocolor.Text = "0";
            txt_ramaleo.Text = "0";
            txt_desgarros.Text = "0";
            txt_sierras.Text = "0";
            txt_defcalidad.Text = "0";
            txt_defcondicion.Text = "0";
            txt_qc_pudricion.Text = "0";
            txt_comp_pudricion.Text = "0";
            txt_qc_deshechos.Text = "0";
            txt_comp_deshechos.Text = "0";
            txt_qc_exportable.Text = "0";
            txt_comp_exportable.Text = "0";
            txt_qc_deshecho_com.Text = "0";
            txt_comp_deshecho_com.Text = "0";
            txt_num_frutos.Text = "0";
            txt_exportable_2.Text = "0";
            txt_comercial_5.Text = "0";
            txt_obser.Text = "0";
            txt_precalibre.Focus();

        }
    }
}
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
    public partial class Ingreso_CC_PAC_075_proceso : System.Web.UI.Page
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
           // int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            txtDescarte.Focus();
            
        }
        
        private void DDLProcesos(int linea, string turno)
             {
                 // string linea = drop_linea_d.Text;
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
            // string linea = drop_linea_d.Text;
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
           // string linea = drop_linea_d.Text;
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

        private void DropLote(int proceso)
        {
            // string linea = drop_linea_d.Text;
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
        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            txtDescarte.Text = "0";
            txtCAT_Valor.Text = "0";
            txt_global_v.Text = "0";
            txt_global_p.Text = "0";
            txt_global_exp.Text = "0";
            txt_puntual_v.Text = "0";
            txt_puntual_p.Text = "0";
            txt_puntual_exp.Text = "0";
            txt_externo_v.Text = "0";
            txt_externo_p.Text = "0";
            txt_externo_exp.Text = "0";
            txt_ptoneg_v.Text = "0";
            txt_ptoneg_p.Text = "0";
            txt_ptoneg_exp.Text = "0";
            txt_ptomar_v.Text = "0";
            txt_ptomar_p.Text = "0";
            txt_ptomar_exp.Text = "0";
            txt_mancha_v.Text = "0";
            txt_mancha_p.Text = "0";
            txt_mancha_exp.Text = "0";


            KilosLote.Text = "0";
            NTotes.Text = "0";
            porc_exp.Text = "0";
            
            txtDescarte.Focus();
            btnGrabar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        protected void Grabar_Click(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            string CodProc = drop_proc_d.SelectedValue;
            string Linea = drop_linea_d.SelectedValue;
            string Turno = drop_turno_d.SelectedValue;
            string Lote = drop_lote_d.SelectedValue;
            string tipo_cat;
            if (CAT_II.Checked) { tipo_cat = "CAT II"; }
            else { if (CAT_III.Checked) { tipo_cat = "CAT III"; } else { tipo_cat = "SIN INFO"; } }
            // sin comillas


            if (txtDescarte.Text == "") { txtDescarte.Text = "0"; }
            if (txtCAT_Valor.Text == "") { txtCAT_Valor.Text = "0"; }
            if (txt_global_v.Text == "") { txt_global_v.Text = "0"; }
            if (txt_global_p.Text == "") { txt_global_p.Text = "0"; }
            if (txt_global_exp.Text == "") { txt_global_exp.Text = "0"; }
            if (txt_puntual_v.Text == "") { txt_puntual_v.Text = "0"; }
            if (txt_puntual_p.Text == "") { txt_puntual_p.Text = "0"; }
            if (txt_puntual_exp.Text == "") { txt_puntual_exp.Text = "0"; }
            if (txt_externo_v.Text == "") { txt_externo_v.Text = "0"; }
            if (txt_externo_p.Text == "") { txt_externo_p.Text = "0"; }
            if (txt_externo_exp.Text == "") { txt_externo_exp.Text = "0"; }
            if (txt_ptoneg_v.Text == "") { txt_ptoneg_v.Text = "0"; }
            if (txt_ptoneg_p.Text == "") { txt_ptoneg_p.Text = "0"; }
            if (txt_ptoneg_exp.Text == "") { txt_ptoneg_exp.Text = "0"; }
            if (txt_ptomar_v.Text == "") { txt_ptomar_v.Text = "0"; }
            if (txt_ptomar_p.Text == "") { txt_ptomar_p.Text = "0"; }
            if (txt_ptomar_exp.Text == "") { txt_ptomar_exp.Text = "0"; }
            if (txt_mancha_v.Text == "") { txt_mancha_v.Text = "0"; }
            if (txt_mancha_p.Text == "") { txt_mancha_p.Text = "0"; }
            if (txt_mancha_exp.Text == "") { txt_mancha_exp.Text = "0"; }
            if (KilosLote.Text == "") { KilosLote.Text = "0"; }
            if (NTotes.Text == "") { NTotes.Text = "0"; }
            if (porc_exp.Text == "") { porc_exp.Text = "0"; }



            string comando = "INSERT INTO [CC_PAC_075] (Ctrl_id,Ctrl_CodProc,Ctrl_CodPlan,Ctrl_Lin,Ctrl_Usuario,Ctrl_Turno,Ctrl_Lote,Ctrl_RefAjuste,Ctrl_CAT,Ctrl_CAT_valor,Ctrl_desacrte,Ctrl_global_valor,Ctrl_global_porc,Ctrl_global_prueba,Ctrl_puntual_valor,Ctrl_puntual_porc,Ctrl_puntual_prueba,Ctrl_externo_valor,Ctrl_externo_porc,Ctrl_externo_prueba,Ctrl_ptonegro_valor,Ctrl_ptonegro_porc,Ctrl_ptonegro_prueba,Ctrl_ptomarron_valor,Ctrl_ptomarron_porc,Ctrl_ptomarron_prueba,Ctrl_marchablanca_valor,Ctrl_marchablanca_porc,Ctrl_marchablanca_prueba,Ctrl_KilosLote,Ctrl_NumTotes,Ctrl_PorcExp,Ctrl_FecHora) VALUES ('" + numeroctrl + "','" + CodProc + "','" + txt_cod_plan.Text + "','" + Linea + "','" + username + "','" + Turno + "','" + Lote + "','" + txt_ref.Text + "','" + tipo_cat + "'," + txtCAT_Valor.Text + "," + txtDescarte.Text + "," + txt_global_v.Text + "," + txt_global_p.Text + "," + txt_global_exp.Text + "," + txt_puntual_v.Text + "," + txt_puntual_p.Text + "," + txt_puntual_exp.Text + "," + txt_externo_v.Text + "," + txt_externo_p.Text + "," + txt_externo_exp.Text + "," + txt_ptoneg_v.Text + "," + txt_ptoneg_p.Text + "," + txt_ptoneg_exp.Text + "," + txt_ptomar_v.Text + "," + txt_ptomar_p.Text + "," + txt_ptomar_exp.Text + "," + txt_mancha_v.Text + "," + txt_mancha_p.Text + "," + txt_mancha_exp.Text + "," + KilosLote.Text + "," + NTotes.Text + "," + porc_exp.Text + ",'" + numeroctrl + "')"; 
            // con comillas
            //string comando = "INSERT INTO [CC_PAC_075] (Ctrl_id,Ctrl_CodProc,Ctrl_CodPlan,Ctrl_Lin,Ctrl_Usuario,Ctrl_Turno,Ctrl_Lote,Ctrl_RefAjuste,Ctrl_CAT,Ctrl_CAT_valor,Ctrl_desacrte,Ctrl_global_valor,Ctrl_global_porc,Ctrl_global_prueba,Ctrl_puntual_valor,Ctrl_puntual_porc,Ctrl_puntual_prueba,Ctrl_externo_valor,Ctrl_externo_porc,Ctrl_externo_prueba,Ctrl_ptonegro_valor,Ctrl_ptonegro_porc,Ctrl_ptonegro_prueba,Ctrl_ptomarron_valor,Ctrl_ptomarron_porc,Ctrl_ptomarron_prueba,Ctrl_marchablanca_valor,Ctrl_marchablanca_porc,Ctrl_marchablanca_prueba,Ctrl_KilosLote,Ctrl_NumTotes,Ctrl_PorcExp,Ctrl_FecHora) VALUES ('" + numeroctrl + "','" + CodProc + "','" + txt_cod_plan.Text + "','" + Linea + "','" + username + "','" + Turno + "','" + Lote + "','" + txt_ref.Text + "','" + tipo_cat + "','" + txtCAT_Valor.Text + "','" + txtDescarte.Text + "','" + txt_global_v.Text + "','" + txt_global_p.Text + "','" + txt_global_exp.Text + "','" + txt_puntual_v.Text + "','" + txt_puntual_p.Text + "','" + txt_puntual_exp.Text + "','" + txt_externo_v.Text + "','" + txt_externo_p.Text + "','" + txt_externo_exp.Text + "','" + txt_ptoneg_v.Text + "','" + txt_ptoneg_p.Text + "','" + txt_ptoneg_exp.Text + "','" + txt_ptomar_v.Text + "','" + txt_ptomar_p.Text + "','" + txt_ptomar_exp.Text + "','" + txt_mancha_v.Text + "','" + txt_mancha_p.Text + "','" + txt_mancha_exp.Text + "','" + KilosLote.Text + "','" + NTotes.Text + "','" + porc_exp.Text + "','" + numeroctrl + "')"; 
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

            txtDescarte.Text = "0";
            txtCAT_Valor.Text = "0";
            txt_global_v.Text = "0";
            txt_global_p.Text = "0";
            txt_global_exp.Text = "0";
            txt_puntual_v.Text = "0";
            txt_puntual_p.Text = "0";
            txt_puntual_exp.Text = "0";
            txt_externo_v.Text = "0";
            txt_externo_p.Text = "0";
            txt_externo_exp.Text = "0";
            txt_ptoneg_v.Text = "0";
            txt_ptoneg_p.Text = "0";
            txt_ptoneg_exp.Text = "0";
            txt_ptomar_v.Text = "0";
            txt_ptomar_p.Text = "0";
            txt_ptomar_exp.Text = "0";
            txt_mancha_v.Text = "0";
            txt_mancha_p.Text = "0";
            txt_mancha_exp.Text = "0";


            KilosLote.Text = "0";
            NTotes.Text = "0";
            porc_exp.Text = "0";
            txtDescarte.Focus();
            btnGrabar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        protected void btnLoadData_click(object senders, EventArgs e)
        {
          
        }

         
    }
}
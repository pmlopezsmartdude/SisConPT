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
                DDLProcesos();
            }


}
          
        protected void proc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            DropLinea(proceso);
            
        }
           
        protected void linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linea = Convert.ToInt32(drop_linea_d.SelectedValue);

            BuscaTurno(linea);
            
        }
      
        protected void turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

           DropLote(proceso);
            
        }
         
        protected void lote_SelectedIndexChanged(object sender, EventArgs e)
        {
           // int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

            txtDescarte.Focus();
            
        }
        
        private void DDLProcesos()
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
                 SqlCommand cmd_proc = new SqlCommand("select PROC_NumeroProcesso from PROD_Processo", con);
                 SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                 DataSet ds_proc = new DataSet();
                 sda_proc.Fill(ds_proc);

                 drop_proc_d.DataSourceID = "";
                 drop_proc_d.DataSource = ds_proc;
                 drop_proc_d.DataBind();

                 if (drop_proc_d.Items.Count != 0)
                 {
                     int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

                     DropLinea(proceso);
                 }
                 con.Close();
             }

        private void DropLinea(int cod_proc_busca)
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
            SqlCommand cmd_linea = new SqlCommand("select  LIN_Codice from Ana_Linea as lin inner join [PROD_Processo] as prodproc on lin.lin_codice=proc_linea_fk where proc_numeroprocesso=" + cod_proc_busca + "group by LIN_Codice", con);
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


            if (drop_linea_d.Items.Count != 0)
            {
                int proceso = Convert.ToInt32(drop_proc_d.SelectedValue);

                DropLote(proceso);

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
            txtDescarte.Text = "";
            txtCATII.Text = "";
            txtCATIII.Text = "";
            txt3_1.Text = "";
            txt3_2.Text = "";
            txt3_porc_1.Text = "";
            txt3_porc_2.Text = "";
            txt8_1.Text = "";
            txt8_2.Text = "";
            txt8_porc_1.Text = "";
            txt8_porc_2.Text = "";
            txt21_1.Text = "";
            txt21_2.Text = "";
            txt21_porc_1.Text = "";
            txt21_porc_2.Text = "";
            txt18_1.Text = "";
            txt18_2.Text = "";
            txt18_porc_1.Text = "";
            txt18_porc_2.Text = "";
            txt25_1.Text = "";
            txt25_2.Text = "";
            txt25_porc_1.Text = "";
            txt25_porc_2.Text = "";
            txt19_1.Text = "";
            txt19_2.Text = "";
            txt19_porc_1.Text = "";
            txt19_porc_2.Text = "";
            KilosLote.Text = "";
            NTotes.Text = "";
            porc_exp.Text = "";
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

            string comando = "INSERT INTO [CtrlDescarteCom] (Ctrl_id, Ctrl_CodProc, Ctrl_CodPlan, Ctrl_Lin, Ctrl_Usuario, Ctrl_Turno, Ctrl_Lote, Ctrl_ExpDesc, Ctrl_CatII, Ctrl_CatIII, Ctrl_Rango1_3, Ctrl_Rango1_3_porc, Ctrl_Rango1_8, Ctrl_Rango1_8_porc, Ctrl_Rango1_21, Ctrl_Rango1_21_porc, Ctrl_Rango1_18, Ctrl_Rango1_18_porc, Ctrl_Rango1_25, Ctrl_Rango1_25_porc, Ctrl_Rango1_19, Ctrl_Rango1_19_porc, Ctrl_Rango2_3, Ctrl_Rango2_3_porc, Ctrl_Rango2_8, Ctrl_Rango2_8_porc, Ctrl_Rango2_21, Ctrl_Rango2_21_porc, Ctrl_Rango2_18, Ctrl_Rango2_18_porc, Ctrl_Rango2_25, Ctrl_Rango2_25_porc, Ctrl_Rango2_19, Ctrl_Rango2_19_porc, Ctrl_KilosLote, Ctrl_NumTotes, Ctrl_PorcExp, Ctrl_FecHora) VALUES ('" + numeroctrl + "','" + CodProc + "','" + txt_cod_plan.Text + "','" + Linea + "','" + username + "','" + Turno + "','" + Lote + "','" + txtDescarte.Text + "','" + txtCATII.Text + "','" + txtCATIII.Text + "','" + txt3_1.Text + "','" + txt3_2.Text + "','" + txt3_porc_1.Text + "','" + txt3_porc_2.Text + "','" + txt8_1.Text + "','" + txt8_2.Text + "','" + txt8_porc_1.Text + "','" + txt8_porc_2.Text + "','" + txt21_1.Text + "','" + txt21_2.Text + "','" + txt21_porc_1.Text + "','" + txt21_porc_2.Text + "','" + txt18_1.Text + "','" + txt18_2.Text + "','" + txt18_porc_1.Text + "','" + txt18_porc_2.Text + "','" + txt25_1.Text + "','" + txt25_2.Text + "','" + txt25_porc_1.Text + "','" + txt25_porc_2.Text + "','" + txt19_1.Text + "','" + txt19_2.Text + "','" + txt19_porc_1.Text + "','" + txt19_porc_2.Text + "','" + KilosLote.Text + "','" + NTotes.Text + "','" + porc_exp.Text + "','" + numeroctrl + "')"; 

           // string comando1 = "INSERT INTO defecto (cptnumero,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida,defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid,defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie) VALUES ('" + numeroctrl + "','" + txtbajo.Text + "','" + txtcalibreok.Text + "','" + txtsobre.Text + "','" + txtprecalibre.Text + "','" + txtdanotrip.Text + "','" + txtescama.Text + "','" + txtfrutosdeformes.Text + "','" + txtfrutosdobles.Text + "','" + txtguatablanca.Text + "','" + txtherida.Text + "','" + txtmanchas.Text + "','" + txtmedialuna.Text + "','" + txtpiellagarto.Text + "','" + txtrusset.Text + "','" + txtsutura.Text + "','" + txtfaltocolor.Text + "','" + txtramaleo.Text + "','" + txtsinpedicelo.Text + "','" + txtadhesion.Text + "','" + txtdeshid.Text + "','" + txtdeshidpedi.Text + "','" + txtblandos.Text + "','" + txtheridasabiertas.Text + "','" + txtmachucon.Text + "','" + txtpartiduras.Text + "','" + txtpartidurasagua.Text + "','" + txtpartiduracicatrizada.Text + "','" + txtpitting.Text + "','" + txtpudricion.Text + "','" + txtmanchaspardas.Text + "','" + txtdanopajaro.Text + "','" + txtdesgarro.Text + "','" + txtcortesierra.Text + "')";
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

            txtDescarte.Text = "";
            txtCATII.Text = "";
            txtCATIII.Text = "";
            txt3_1.Text = "";
            txt3_2.Text = "";
            txt3_porc_1.Text = "";
            txt3_porc_2.Text = "";
            txt8_1.Text = "";
            txt8_2.Text = "";
            txt8_porc_1.Text = "";
            txt8_porc_2.Text = "";
            txt21_1.Text = "";
            txt21_2.Text = "";
            txt21_porc_1.Text = "";
            txt21_porc_2.Text = "";
            txt18_1.Text = "";
            txt18_2.Text = "";
            txt18_porc_1.Text = "";
            txt18_porc_2.Text = "";
            txt25_1.Text = "";
            txt25_2.Text = "";
            txt25_porc_1.Text = "";
            txt25_porc_2.Text = "";
            txt19_1.Text = "";
            txt19_2.Text = "";
            txt19_porc_1.Text = "";
            txt19_porc_2.Text = "";
            KilosLote.Text = "";
            NTotes.Text = "";
            porc_exp.Text = "";
            txtDescarte.Focus();
            btnGrabar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        protected void btnLoadData_click(object senders, EventArgs e)
        {
          
        }

         
    }
}
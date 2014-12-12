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
    public partial class Ingreso_CC_PAC_005_satelite_caburgua : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropTurno();
                DDL_linea();
                DDL_calibre();
                DropEspecie();
                DDL_marca();
                DDL_prodreal();
                
                DDL_prodetiq();
                DDL_clasi();
               
            }


        }

        protected void Grabar_Click(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string username = HttpContext.Current.User.Identity.Name;
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
            if (txt_destino.Text == "") { txt_destino.Text = "0"; }


            string linea = Convert.ToString(DDL_linea_d.SelectedValue);
            string turno = Convert.ToString(DDL_turno_d.SelectedValue);

            string especie = Convert.ToString(DDL_cod_especie_d.SelectedItem.Text);
            string variedad = Convert.ToString(DDL_variedad_d.SelectedItem.Text);
            string marca = Convert.ToString(DDL_marca_d.SelectedItem.Text);
            string embalaje = Convert.ToString(DDL_embalaje_d.SelectedItem.Text);
            string envase = Convert.ToString(DDL_envase_d.SelectedItem.Text);
            string prodreal = Convert.ToString(DDL_prodreal_d.SelectedItem.Text);
            string prodetiq = Convert.ToString(DDL_prodetiq_d.SelectedItem.Text);
            string calibre = Convert.ToString(DDL_calibre_d.SelectedItem.Text);
            string clasificacion = Convert.ToString(DDL_clasi_d.SelectedItem.Text);

        
            //    string linea_2 = Convert.ToString(DDL_linea_d.SelectedItem.Value);
               

            //string turno_2 = Convert.ToString(DDL_turno_d.SelectedItem.Value);
            //string especie_2 = Convert.ToString(DDL_cod_especie_d.SelectedItem.Value);
            //string variedad_2 = Convert.ToString(DDL_variedad_d.SelectedItem.Value);
            //string marca_2 = Convert.ToString(DDL_marca_d.SelectedItem.Value);
            //string embalaje_2 = Convert.ToString(DDL_embalaje_d.SelectedItem.Value);
            //string envase_2 = Convert.ToString(DDL_envase_d.SelectedItem.Value);
            //string prodreal_2 = Convert.ToString(DDL_prodreal_d.SelectedItem.Value);
            //string prodreal_3 = Convert.ToString(DDL_prodreal_d.SelectedItem.Text);
            //string prodetiq_2 = Convert.ToString(DDL_prodetiq_d.SelectedItem.Value);
            //string calibre_2 = Convert.ToString(DDL_calibre_d.SelectedItem.Value);
            //string clasificacion_2 = Convert.ToString(DDL_clasi_d.SelectedItem.Value);
         

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

            SqlConnection conexion = new SqlConnection(connStringmain.ToString());

            string PlantaNombre = Session["PlantaName"].ToString();
            string comando1 = "SELECT convert(varchar(10),placodigo) as placodigo FROM planta WHERE pladescri ='" + PlantaNombre + "'";
            conexion.Open();
            SqlCommand sql_planta = new SqlCommand(comando1, conexion);
            SqlDataReader reader = sql_planta.ExecuteReader();
           
                reader.Read();
                string planta = reader.GetString(0);
                conexion.Close();

                  
                SqlCommand cmd_proc = new SqlCommand("select cptcodcja from CONTROLPT where cptcodcja='" + CodCaja.Text + "' group by cptcodcja", conexion);
                SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
                DataSet ds_proc = new DataSet();
                try
                {
                    sda_proc.Fill(ds_proc);
                    conexion.Close();
                    if (ds_proc.Tables[0].Rows.Count.ToString() == "0")
                    {

                        string comando = "INSERT INTO controlpt (cptnumero,placodigo,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptrutprr,cptnompre,cptrutpet," +
                        " cptnompet,cptespcod,cptespdes,cptvarcod,cptvardes,cptcalibr,cptmarcod,cptmardes,cptembcod,cptembdes,cptenvcod,cptenvdes,cptpesone,cptsalida,cptcodcja," +
                        " cptclasificacion,cptdestino,cptcajasvaciadas) VALUES ('" + numeroctrl + "','" + planta + "','" + turno + "','" + fecha + "','" + username + "'," +
                        " '" + linea + "','" + NroProceso.Text + "','" + Lote.Text + "','" + txt_prodreal_cod.Text + "','" + prodreal +"','" + txt_prodetiq_cod.Text + "'," +
                        " '" + prodetiq + "','" + especietext.Text + "','" + especie + "','" + txt_variedad_cod.Text + "','" + variedad + "','" + calibre + "'," +
                        " '" + txt_marca_cod.Text + "','" + marca + "','" + txt_embalaje_cod.Text + "','" + embalaje + "','" + txt_envase_cod.Text + "','" + envase + "','" + Peso.Text + "'," +
                        " " + Salida.Text + ",'" + CodCaja.Text + "','" + clasificacion + "','" + txt_destino.Text + "'," + txt_cajasvaciadas.Text + ")";

                        string comando_2 = "INSERT INTO defecto (cptnumero,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida," +
                        " defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid," +
                        " defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie,observac,pesoneto) VALUES ('" + numeroctrl + "','" + txtbajo.Text + "'," +
                        " '" + txtcalibreok.Text + "','" + txtsobre.Text + "','" + txtprecalibre.Text + "','" + txtdanotrip.Text + "','" + txtescama.Text + "'," +
                        " '" + txtfrutosdeformes.Text + "','" + txtfrutosdobles.Text + "','" + txtguatablanca.Text + "','" + txtherida.Text + "','" + txtmanchas.Text + "'," +
                        " '" + txtmedialuna.Text + "','" + txtpiellagarto.Text + "','" + txtrusset.Text + "','" + txtsutura.Text + "','" + txtfaltocolor.Text + "','" + txtramaleo.Text + "'," +
                        " '" + txtsinpedicelo.Text + "','" + txtadhesion.Text + "','" + txtdeshid.Text + "','" + txtdeshidpedi.Text + "','" + txtblandos.Text + "','" + txtheridasabiertas.Text + "'," +
                        " '" + txtmachucon.Text + "','" + txtpartiduras.Text + "','" + txtpartidurasagua.Text + "','" + txtpartiduracicatrizada.Text + "','" + txtpitting.Text + "'," +
                        " '" + txtpudricion.Text + "','" + txtmanchaspardas.Text + "','" + txtdanopajaro.Text + "','" + txtdesgarro.Text + "','" + txtcortesierra.Text + "'," +
                        " '" + TextBox1obs.Text + "','" + txt_peso_neto.Text + "')";

                        string comando_soluble = "insert into solidossolubles (cptnumero,nroproceso,codcaja,nrolote,turno,usuario,calibresoluble,f1,f2,f3,f4,f5, nrolinea)" +
                        " values ('" + numeroctrl + "','" + NroProceso.Text + "','" + CodCaja.Text + "','" + Lote.Text + "','" + turno + "','" + username + "'," +
                        " '" + calibre + "', " + txt_f1.Text + "," + txt_f2.Text + "," + txt_f3.Text + "," + txt_f4.Text + "," + txt_f5.Text + ",'" + linea + "')";
                        conexion.Open();
                        using (SqlCommand sql = new SqlCommand(comando, conexion))
                        {
                            sql.ExecuteNonQuery();
                            conexion.Close();
                        }

                        conexion.Open();
                        using (SqlCommand sql = new SqlCommand(comando_2, conexion))
                        {
                            sql.ExecuteNonQuery();
                            conexion.Close();

                        }

                        conexion.Open();
                        using (SqlCommand sql = new SqlCommand(comando_soluble, conexion))
                        {

                            sql.ExecuteNonQuery();
                            conexion.Close();

                        }


                        CodCaja.Text = "";
                        
                        especietext.Text = "";
                      
                        NroProceso.Text = "";
                        
                        Lote.Text = "";
                        
                        Peso.Text = "";
                       
                        Salida.Text = "";
                        
                        TextBox1obs.Text = "";
                        txt_peso_neto.Text = "";
                        txtbajo.Text = "";
                        txtprecalibre.Text = "";
                        txtrusset.Text = "";
                        txtadhesion.Text = "";
                        txtpudricion.Text = "";
                        txtcalibreok.Text = "";
                        txtdanotrip.Text = "";
                        txtsutura.Text = "";
                        txtdeshid.Text = "";
                        txtmanchaspardas.Text = "";
                        txtsobre.Text = "";
                        txtescama.Text = "";
                        txtfaltocolor.Text = "";
                        txtdeshidpedi.Text = "";
                        txtdanopajaro.Text = "";
                        txtfrutosdeformes.Text = "";
                        txtramaleo.Text = "";
                        txtblandos.Text = "";
                        txtdesgarro.Text = "";
                        txtfrutosdobles.Text = "";
                        txtsinpedicelo.Text = "";
                        txtheridasabiertas.Text = "";
                        txtcortesierra.Text = "";
                        txtguatablanca.Text = "";
                        txtmachucon.Text = "";
                        txtherida.Text = "";
                        txtpartiduras.Text = "";
                        txtmanchas.Text = "";
                        txtpartidurasagua.Text = "";
                        txtmedialuna.Text = "";
                        txtpartiduracicatrizada.Text = "";
                        txtpiellagarto.Text = "";
                        txtpitting.Text = "";
                        txt_f1.Text = "";
                        txt_f2.Text = "";
                        txt_f3.Text = "";
                        txt_f4.Text = "";
                        txt_f5.Text = "";
                        CodCaja.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptName", "alert(\"Registro guardado ok...\");", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptName", "alert(\"Registro ya existente..\");", true);
                    }


                }
                catch
                {

                }

            Grabar.Enabled = true;
            Grabar.Visible = true;
            Limpiar.Enabled = true;
            TabPanel2.Enabled = true;
            TabPanel3.Enabled = true;

            TabContainer1.ActiveTab = TabPanel1;

            //Response.Redirect("~/SisConPT/Ingreso_CC_PAC_005_satelite.aspx");

        }

        protected void btn_limpiar(object sender, EventArgs e)
        {
            Limpiar_Click();
        }
        
        private void Limpiar_Click()
        {
            CodCaja.Text = "";
            especietext.Text = "";
            txt_variedad_cod.Text = "";
            NroProceso.Text = "";
            txt_marca_cod.Text = "";
            Lote.Text = "";
            txt_embalaje_cod.Text = "";
            Peso.Text = "";
            txt_envase_cod.Text = "";
            txt_prodreal_cod.Text = "";
            Salida.Text = "";
            txt_prodetiq_cod.Text = "";
            TextBox1obs.Text = "";
            txtbajo.Text = "";
            txtprecalibre.Text = "";
            txtrusset.Text = "";
            txtadhesion.Text = "";
            txtpudricion.Text = "";
            txtcalibreok.Text = "";
            txtdanotrip.Text = "";
            txtsutura.Text = "";
            txtdeshid.Text = "";
            txtmanchaspardas.Text = "";
            txtsobre.Text = "";
            txtescama.Text = "";
            txtfaltocolor.Text = "";
            txtdeshidpedi.Text = "";
            txtdanopajaro.Text = "";
            txtfrutosdeformes.Text = "";
            txtramaleo.Text = "";
            txtblandos.Text = "";
            txtdesgarro.Text = "";
            txtfrutosdobles.Text = "";
            txtsinpedicelo.Text = "";
            txtheridasabiertas.Text = "";
            txtcortesierra.Text = "";
            txtguatablanca.Text = "";
            txtmachucon.Text = "";
            txtherida.Text = "";
            txtpartiduras.Text = "";
            txtmanchas.Text = "";
            txtpartidurasagua.Text = "";
            txtmedialuna.Text = "";
            txtpartiduracicatrizada.Text = "";
            txtpiellagarto.Text = "";
            txtpitting.Text = "";
            txt_cajasvaciadas.Text = "";
            txt_destino.Text = "";
  
            txt_f1.Text = "";
            txt_f2.Text = "";
            txt_f3.Text = "";
            txt_f4.Text = "";
            txt_f5.Text = "";
            CodCaja.Focus();

            CodCaja.Enabled = true;
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
            TabPanel2.Enabled = false;
            TabPanel3.Enabled = false;
            TabContainer1.ActiveTab = TabPanel1;
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

        private void DropEspecie()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select CODESPECIE, DESCESPECIE from ESPECIE where codespecie<>0", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_cod_especie_d.DataSourceID = "";
            DDL_cod_especie_d.DataSource = ds_proc;
            DDL_cod_especie_d.DataBind();

            con.Close();
            string especie = Convert.ToString(DDL_cod_especie_d.SelectedItem.Value);
            especietext.Text = especie;

            DropVariedad(especie);
            string variedad = Convert.ToString(DDL_variedad_d.SelectedItem.Value);
            txt_variedad_cod.Text = variedad;

            DDL_embalaje(especie);
            string embalaje = Convert.ToString(DDL_embalaje_d.SelectedItem.Value);
            txt_embalaje_cod.Text = embalaje;

            DDL_envase(especie);
            string envase = Convert.ToString(DDL_envase_d.SelectedItem.Value);
            txt_envase_cod.Text = envase;
        }

       protected void especie_SelectedIndexChanged(object sender, EventArgs e)
       {
            
            string especie = Convert.ToString(DDL_cod_especie_d.SelectedItem.Value);
            especietext.Text = especie;
            DropVariedad(especie);
            DDL_envase(especie);
            DDL_embalaje(especie);
            
       }

       protected void embalaje_SelectedIndexChanged(object sender, EventArgs e)
       {

           string embalaje = Convert.ToString(DDL_embalaje_d.SelectedItem.Value);
           txt_embalaje_cod.Text = embalaje;

       }

       protected void envase_SelectedIndexChanged(object sender, EventArgs e)
       {
           string envase = Convert.ToString(DDL_envase_d.SelectedItem.Value);
           txt_envase_cod.Text = envase;
       }
       protected void prodreal_SelectedIndexChanged(object sender, EventArgs e)
       {
           string prodreal = Convert.ToString(DDL_prodreal_d.SelectedValue);
           txt_prodreal_cod.Text = prodreal;
       }
       protected void prodetiq_SelectedIndexChanged(object sender, EventArgs e)
       {
           string prodetiq = Convert.ToString(DDL_prodetiq_d.SelectedValue);
           txt_prodetiq_cod.Text = prodetiq;
       }

       protected void marca_SelectedIndexChanged(object sender, EventArgs e)
       {
           string marca = Convert.ToString(DDL_marca_d.SelectedValue);
           txt_marca_cod.Text = marca;
       }
       protected void variedad_SelectedIndexChanged(object sender, EventArgs e)
       {
           string variedad = Convert.ToString(DDL_variedad_d.SelectedItem.Value);
           txt_variedad_cod.Text = variedad;
       }
 


       private void DropVariedad(string especie)
       {
           System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
           System.Configuration.ConnectionStringSettings connStringLM;
           connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
           SqlConnection con = new SqlConnection(connStringLM.ToString());
           con.Open();
           //linea
           SqlCommand cmd_proc = new SqlCommand("select COD_VARIEDAD, VARDESC from VARIEDAD where CODESPECIE='" + especie + "'", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_variedad_d.DataSourceID = "";
           DDL_variedad_d.DataSource = ds_proc;
           DDL_variedad_d.DataBind();
           con.Close();
        
          
       }
       private void DDL_embalaje(string especie)
       {
           System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
           System.Configuration.ConnectionStringSettings connStringLM;
           connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
           SqlConnection con = new SqlConnection(connStringLM.ToString());
           con.Open();
           //linea
           SqlCommand cmd_proc = new SqlCommand("select emb.COD_EMBALAJE, emb.DESCRIPCION, emb_esp.CODESPECIE from embalaje as emb inner join EMBALAJE_ESPECIE as emb_esp on emb.COD_EMBALAJE=emb_esp.COD_EMBALAJE where codespecie='" + especie + "'", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_embalaje_d.DataSourceID = "";
           DDL_embalaje_d.DataSource = ds_proc;
           DDL_embalaje_d.DataBind();

           con.Close();
       }
       private void DDL_envase(string especie)
       {
           System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
           System.Configuration.ConnectionStringSettings connStringLM;
           connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
           SqlConnection con = new SqlConnection(connStringLM.ToString());
           con.Open();
           //linea
           SqlCommand cmd_proc = new SqlCommand("select env.codenvase, env.nombre, env_esp.codespecie from envases as env inner join [ENVASES_ESPECIE] as env_esp on env.CODENVASE=env_esp.CODENVASE where codespecie='" + especie + "'", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_envase_d.DataSourceID = "";
           DDL_envase_d.DataSource = ds_proc;
           DDL_envase_d.DataBind();

           con.Close();
       }
       private void DDL_marca()
       {
           System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
           System.Configuration.ConnectionStringSettings connStringLM;
           connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
           SqlConnection con = new SqlConnection(connStringLM.ToString());
           con.Open();
           //linea
           SqlCommand cmd_proc = new SqlCommand("SELECT cod_etiqueta as MARCA_COD, descripcion as MARCA_NOMBRE FROM etiqueta", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_marca_d.DataSourceID = "";
           DDL_marca_d.DataSource = ds_proc;
           DDL_marca_d.DataBind();

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
           SqlCommand cmd_proc = new SqlCommand("select CODPRODUCTOR, ALIAS, DESCRIPCION from [dbo].[PRODUCTORES] group by CODPRODUCTOR, ALIAS, DESCRIPCION", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_prodreal_d.DataSourceID = "";
           DDL_prodreal_d.DataSource = ds_proc;
           DDL_prodreal_d.DataBind();

           con.Close();

      }
       private void DDL_prodetiq()
       {
           System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
           System.Configuration.ConnectionStringSettings connStringLM;
           connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["Agroweb_planta"];
           SqlConnection con = new SqlConnection(connStringLM.ToString());
           con.Open();
           //linea
           SqlCommand cmd_proc = new SqlCommand("select CODPRODUCTOR, ALIAS, DESCRIPCION from [dbo].[PRODUCTORES] group by CODPRODUCTOR, ALIAS, DESCRIPCION", con);
           SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
           DataSet ds_proc = new DataSet();
           sda_proc.Fill(ds_proc);

           DDL_prodetiq_d.DataSourceID = "";
           DDL_prodetiq_d.DataSource = ds_proc;
           DDL_prodetiq_d.DataBind();

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

        private void DDL_clasi()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select clasi_descrip from clasificacion_sat", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_clasi_d.DataSourceID = "";
            DDL_clasi_d.DataSource = ds_proc;
            DDL_clasi_d.DataBind();

            con.Close();
        }

        private void DDL_calibre()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringLM.ToString());
            con.Open();
            //linea
            SqlCommand cmd_proc = new SqlCommand("select sol_descrip as calibre from solsol", con);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            sda_proc.Fill(ds_proc);

            DDL_calibre_d.DataSourceID = "";
            DDL_calibre_d.DataSource = ds_proc;
            DDL_calibre_d.DataBind();

            con.Close();
        }



    }
}
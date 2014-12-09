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
    public partial class Ingreso_CC_PAC_005_satelite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (txt_calisificacion.Text == "") { txt_calisificacion.Text = "0"; }
           
         

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

                    //string comando = "INSERT INTO [CC_PAC_005_SATELITE] (cptnumero,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptnompre," +
                    //" cptnompet,cptespdes,cptvardes,cptcalibr,cptmardes,cptembdes,cptenvdes,cptpesone,cptsalida,cptcodcja," +
                    //" cptclasificacion,cptdestino,cptcajasvaciadas,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida," +
                    //" defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid," +
                    //" defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie,observac,pesoneto,f1,f2,f3,f4,f5,planta) VALUES " +
                    //" ('" + numeroctrl + "','" + Turno.Text + "','" + fecha + "','" + username + "'," +
                    //" '" + Linea.Text + "','" + NroProceso.Text + "','" + Lote.Text + "','" + ProdRealtxt.Text + "'," +
                    //" '" + ProdEtiqtxt.Text + "','" + especietext.Text + "','" + VariedadText.Text + "','" + Calibre.Text + "'," +
                    //" '" + MarcaTxt.Text + "','" + Embalajetx.Text + "','" + Envasetxt.Text + "','" + Peso.Text + "'," +
                    //" " + Salida.Text + ",'" + CodCaja.Text + "','" + txt_calisificacion.Text + "','" + txt_destino.Text + "'," + txt_cajasvaciadas.Text + ",'" + txtbajo.Text + "'," +
                    //" '" + txtcalibreok.Text + "','" + txtsobre.Text + "','" + txtprecalibre.Text + "','" + txtdanotrip.Text + "','" + txtescama.Text + "'," +
                    //" '" + txtfrutosdeformes.Text + "','" + txtfrutosdobles.Text + "','" + txtguatablanca.Text + "','" + txtherida.Text + "','" + txtmanchas.Text + "'," +
                    //" '" + txtmedialuna.Text + "','" + txtpiellagarto.Text + "','" + txtrusset.Text + "','" + txtsutura.Text + "','" + txtfaltocolor.Text + "','" + txtramaleo.Text + "'," +
                    //" '" + txtsinpedicelo.Text + "','" + txtadhesion.Text + "','" + txtdeshid.Text + "','" + txtdeshidpedi.Text + "','" + txtblandos.Text + "','" + txtheridasabiertas.Text + "'," +
                    //" '" + txtmachucon.Text + "','" + txtpartiduras.Text + "','" + txtpartidurasagua.Text + "','" + txtpartiduracicatrizada.Text + "','" + txtpitting.Text + "'," +
                    //" '" + txtpudricion.Text + "','" + txtmanchaspardas.Text + "','" + txtdanopajaro.Text + "','" + txtdesgarro.Text + "','" + txtcortesierra.Text + "'," +
                    //" '" + TextBox1obs.Text + "','" + txt_peso_neto.Text + "', " + txt_f1.Text + "," + txt_f2.Text + "," + txt_f3.Text + "," + txt_f4.Text + "," + txt_f5.Text + ",'" + planta + "')";


                    //conexion.Open();
                    //using (SqlCommand sql = new SqlCommand(comando, conexion))
                    //{
                    //    sql.ExecuteNonQuery();
                    //    conexion.Close();
                    //    string error = "Guardado ok";
                    //    Response.Write("<script language=javascript > alert('" + error + "'); </script>");
                    //}

                    //CodCaja.Focus();

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
                        " cptclasificacion,cptdestino,cptcajasvaciadas) VALUES ('" + numeroctrl + "','" + planta + "','" + Turno.Text + "','" + fecha + "','" + username + "'," +
                        " '" + Linea.Text + "','" + NroProceso.Text + "','" + Lote.Text + "',' ','" + ProdRealtxt.Text + "',' '," +
                        " '" + ProdEtiqtxt.Text + "',' ','" + especietext.Text + "',' ','" + VariedadText.Text + "','" + Calibre.Text + "'," +
                        " ' ','" + MarcaTxt.Text + "',' ','" + Embalajetx.Text + "',' ','" + Envasetxt.Text + "','" + Peso.Text + "'," +
                        " " + Salida.Text + ",'" + CodCaja.Text + "','" + txt_calisificacion.Text + "','" + txt_destino.Text + "'," + txt_cajasvaciadas.Text + ")";

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
                        " values ('" + numeroctrl + "','" + NroProceso.Text + "','" + CodCaja.Text + "','" + Lote.Text + "','" + Turno.Text + "','" + username + "'," +
                        " '" + Calibre.Text + "', " + txt_f1.Text + "," + txt_f2.Text + "," + txt_f3.Text + "," + txt_f4.Text + "," + txt_f5.Text + ",'" + Linea.Text + "')";
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
                        Turno.Text = "";
                        especietext.Text = "";
                        Linea.Text = "";
                        VariedadText.Text = "";
                        NroProceso.Text = "";
                        MarcaTxt.Text = "";
                        Lote.Text = "";
                        Embalajetx.Text = "";
                        Peso.Text = "";
                        Envasetxt.Text = "";
                        Calibre.Text = "";
                        ProdRealtxt.Text = "";
                        Salida.Text = "";
                        ProdEtiqtxt.Text = "";
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
            Turno.Text = "";
            especietext.Text = "";
            Linea.Text = "";
            VariedadText.Text = "";
            NroProceso.Text = "";
            MarcaTxt.Text = "";
            Lote.Text = "";
            Embalajetx.Text = "";
            Peso.Text = "";
            Envasetxt.Text = "";
            Calibre.Text = "";
            ProdRealtxt.Text = "";
            Salida.Text = "";
            ProdEtiqtxt.Text = "";
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
            txt_calisificacion.Text = "";
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

    }
}
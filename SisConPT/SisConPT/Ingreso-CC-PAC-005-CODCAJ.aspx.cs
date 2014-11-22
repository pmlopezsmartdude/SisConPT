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
    public partial class Ingreso_CC_PAC_005_CODCAJ : System.Web.UI.Page
    {
                
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CodCaja.Attributes.Add("onkeypress", "button_click(this,'"+ this.btnLoadData.ClientID +"')");
            CodCaja.Focus();
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
                    CodPta.Text = reader.GetString(0);
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


            CheckSoluble.Visible = false;

            SiguienteFinal.Visible = false;
            Button1.Visible = false;
            TabPanel2.Enabled = false;
            TabPanel3.Enabled = false;


            guardar_obs_bt.Visible = false;
            guardar_obs_bt.Enabled = false;
            //btn_clasi.Visible = false;

        

        }
        
        protected void btnLoadData_click(object senders, EventArgs e)
        {
            string codigocaja = CodCaja.Text;
            string comando = "SELECT [codCaja],[FechaProduccion],convert(varchar(8),[proceso]) as proceso ,[Lote],[codLinea],[Linea] ,[Turno],[Salida],[Clasificacion],[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada],[codEnvase],[Envase],[codEmbalaje],[Embalaje],[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca] ,[Marca] ,[ClaseCalibreColor],[CalibreTimbrado],[CAT] ,[codProductorReal],[ProductorReal],[ComunaReal],[ProvinciaReal],[RegionReal],[codProductorTimbrado],[ProductorTimbrado],[ComunaTimbrada],[ProvinciaTimbrada],[RegionTimbrada],[CondicionEmbarque],[NumeroPalet],[FechaPaletizaje] FROM DatosCajas WHERE codCaja ='" + codigocaja + "'";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringLM;
            System.Configuration.ConnectionStringSettings connStringmain;
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
            }
            SqlConnection conexion = new SqlConnection(connStringLM.ToString());
            conexion.Open();
            SqlCommand sql = new SqlCommand(comando, conexion);
            try {
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                reader.Read();
                Turno.Text = reader.GetString(6);
                especieid.Text = reader.GetString(9);
                especietext.Text = reader.GetString(10);
                Linea.Text = reader.GetString(4);
                Variedad.Text = reader.GetString(11);
                VariedadText.Text = reader.GetString(12);
                NroProceso.Text = reader.GetString(2);
                Marca.Text = reader.GetString(22);
                MarcaTxt.Text = reader.GetString(23);
                Lote.Text = reader.GetString(3);
                Embalaje.Text = reader.GetString(17);
                Embalajetx.Text = reader.GetString(18);
                Peso.Text = reader.GetString(21);
                Envase.Text = reader.GetString(15);
                Envasetxt.Text = reader.GetString(16);
                Calibre.Text = reader.GetString(25);
                ProdReal.Text = reader.GetString(27);
                ProdRealtxt.Text = reader.GetString(28);
                Salida.Text = reader.GetString(7);
                ProdEtiq.Text = reader.GetString(32);
                ProdEtiqtxt.Text = reader.GetString(33);
                lbl_calibre.Text = reader.GetString(25);
                txt_calisificacion.Text = reader.GetString(8);
                conexion.Close();
            }

    
           }
          catch 
            {

          }

            ButtonBuscar.Enabled = false;
            CodCaja.Enabled = false;
            Siguiente1.Visible = true;
            Siguiente1.Enabled = true;



            
            //SqlConnection con_2 = new SqlConnection(connStringmain.ToString());
            //SqlCommand cmd_proc_2 = new SqlCommand("select cptclasificacion,cptdestino,convert(varchar(4),cptcajasvaciadas) as cptcajasvaciadas from CONTROLPT where cptproces='" + NroProceso.Text + "' and lincodigo='" + Linea.Text + "' and turcodigo='" + Turno.Text + "' and cptnulote='" + Lote.Text + "' and placodigo='" + CodPta.Text + "' and (cptdestino ='' or cptclasificacion='' or cptcajasvaciadas<>0)", con_2);
            ////SqlCommand cmd_proc_2 = new SqlCommand("select nroproceso from solidossolubles where nroproceso='" + NroProceso.Text + "' and nrolinea = '" + Linea.Text + "' and turno='" + Turno.Text + "'", con);
            //SqlDataAdapter sda_proc_2 = new SqlDataAdapter(cmd_proc_2);
            //DataSet ds_proc_2 = new DataSet();
            //con_2.Open();
            //sda_proc_2.Fill(ds_proc_2);
            //con_2.Close();
            //if (ds_proc_2.Tables[0].Rows.Count.ToString() == "0")
            //{
            //    txt_calisificacion.Enabled = true;
            //    txt_destino.Enabled = true;
            //    txt_cajasvaciadas.Enabled = true;
            //    btn_clasi.Visible = true;
            //    btn_clasi.Enabled = true;

            //}
            //else
            //{
            //    con_2.Open();
            //    using (SqlDataReader reader = cmd_proc_2.ExecuteReader())
            //    {

            //        reader.Read();
            //        txt_calisificacion.Text = reader.GetString(0);
            //        txt_destino.Text = reader.GetString(1);
            //        txt_cajasvaciadas.Text = reader.GetString(2);
            //        txt_calisificacion.Enabled = false;
            //        txt_destino.Enabled = false;
            //        txt_cajasvaciadas.Enabled = false;
            //        btn_clasi.Visible = false;
            //        con_2.Close();
            //    }
            //}
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con_existe_caja = new SqlConnection(connStringmain.ToString());
            SqlCommand cmd__existe = new SqlCommand("select  top 1 convert(varchar(15),defprecal) as [defprecal],convert(varchar(15),defdanotr) as [defdanotr],convert(varchar(15),defescama) as [defescama],convert(varchar(15),deffrutode) as [deffrutode],convert(varchar(15),deffrutodo) as [deffrutodo],convert(varchar(15),defguatab) as [defguatab],convert(varchar(15),defherida) as [defherida],convert(varchar(15),defmancha) as [defmancha],convert(varchar(15),defmedial) as [defmedial],convert(varchar(15),defpiella) as [defpiella],convert(varchar(15),defrusset) as [defrusset],convert(varchar(15),defsutura) as [defsutura],convert(varchar(15),deffaltoc) as [deffaltoc],convert(varchar(15),deframole) as [deframole],convert(varchar(15),defsinped) as [defsinped],convert(varchar(15),defadhesi) as [defadhesi],convert(varchar(15),defdesfru) as [defdesfru],convert(varchar(15),defdesped) as [defdesped],convert(varchar(15),defblando) as [defblando],convert(varchar(15),defherabi) as [defherabi],convert(varchar(15),defmachuc) as [defmachuc],convert(varchar(15),defpartid) as [defpartid],convert(varchar(15),defparagu) as [defparagu],convert(varchar(15),defparcic) as [defparcic],convert(varchar(15),defpittin) as [defpittin],convert(varchar(15),defpudric) as [defpudric],convert(varchar(15),defmanpar) as [defmanpar],convert(varchar(15),defdanopa) as [defdanopa],convert(varchar(15),defdesgar) as [defdesgar],convert(varchar(15),defcorsie) as [defcorsie],convert(varchar(15),solsolub) as solsolub,convert(varchar(15),defcalbaj)as defcalbaj ,convert(varchar(15),defcalnor) as defcalnor,convert(varchar(15),defcalsob) as defcalsob, observac, cptclasificacion,cptdestino,convert(varchar(4),cptcajasvaciadas) as cptcajasvaciadas from defecto as def inner join controlpt as cl on cl.cptnumero=def.cptnumero where cl.cptcodcja='" + CodCaja.Text + "'", con_existe_caja);
            SqlDataAdapter sda_existe = new SqlDataAdapter(cmd__existe);
            DataSet ds_existe = new DataSet();
            con_existe_caja.Open();
            sda_existe.Fill(ds_existe);
            con_existe_caja.Close();
           
            if (ds_existe.Tables[0].Rows.Count.ToString() == "0")
            {
                 txtbajo.Enabled = true;
                txtprecalibre.Enabled = true;
                txtsobre.Enabled = true;
                txtbajo.Enabled = true;
                txtprecalibre.Enabled = true;
                txtrusset.Enabled = true;
                txtadhesion.Enabled = true;
                txtpudricion.Enabled = true;
                txtcalibreok.Enabled = true;
                txtdanotrip.Enabled = true;
                txtsutura.Enabled = true;
                txtdeshid.Enabled = true;
                txtmanchaspardas.Enabled = true;
                txtsobre.Enabled = true;
                txtescama.Enabled = true;
                txtfaltocolor.Enabled = true;
                txtdeshidpedi.Enabled = true;
                txtdanopajaro.Enabled = true;
                txtfrutosdeformes.Enabled = true;
                txtramaleo.Enabled = true;
                txtblandos.Enabled = true;
                txtdesgarro.Enabled = true;
                txtfrutosdobles.Enabled = true;
                txtsinpedicelo.Enabled = true;
                txtheridasabiertas.Enabled = true;
                txtcortesierra.Enabled = true;
                txtguatablanca.Enabled = true;
                txtmachucon.Enabled = true;
                txtherida.Enabled = true;
                txtpartiduras.Enabled = true;
                txtmanchas.Enabled = true;
                txtpartidurasagua.Enabled = true;
                txtmedialuna.Enabled = true;
                txtpartiduracicatrizada.Enabled = true;
                txtpiellagarto.Enabled = true;
                txtpitting.Enabled = true;

                //este estaba antes
                Siguiente1.Enabled = true;


            }
            else
            {
                con_existe_caja.Open();
                using (SqlDataReader reader = cmd__existe.ExecuteReader())
                {
                    reader.Read();
                    txtprecalibre.Text = reader.GetString(0);
                    txtdanotrip.Text = reader.GetString(1);
                    txtescama.Text = reader.GetString(2);
                    txtfrutosdeformes.Text = reader.GetString(3);
                    txtfrutosdobles.Text = reader.GetString(4);
                    txtguatablanca.Text = reader.GetString(5);
                    txtherida.Text = reader.GetString(6);
                    txtmanchas.Text = reader.GetString(7);
                    txtmedialuna.Text = reader.GetString(8);
                    txtpiellagarto.Text = reader.GetString(9);
                    txtrusset.Text = reader.GetString(10);
                    txtsutura.Text = reader.GetString(11);
                    txtfaltocolor.Text = reader.GetString(12);
                    txtramaleo.Text = reader.GetString(13);
                    txtsinpedicelo.Text = reader.GetString(14);
                    txtadhesion.Text = reader.GetString(15);
                    txtdeshid.Text = reader.GetString(16);
                    txtdeshidpedi.Text = reader.GetString(17);
                    txtblandos.Text = reader.GetString(18);
                    txtheridasabiertas.Text = reader.GetString(19);
                    txtmachucon.Text = reader.GetString(20);
                    txtpartiduras.Text = reader.GetString(21);
                    txtpartidurasagua.Text = reader.GetString(22);
                    txtpartiduracicatrizada.Text = reader.GetString(23);
                    txtpitting.Text = reader.GetString(24);
                    txtpudricion.Text = reader.GetString(25);
                    txtmanchaspardas.Text = reader.GetString(26);
                    txtdanopajaro.Text = reader.GetString(27);
                    txtdesgarro.Text = reader.GetString(28);
                    txtcortesierra.Text = reader.GetString(29);
                    txtbajo.Text = reader.GetString(31);
                    txtprecalibre.Text = reader.GetString(32);
                    txtsobre.Text = reader.GetString(33);
                    TextBox1obs.Text = reader.GetString(34);
                    txt_calisificacion.Text = reader.GetString(35);
                    txt_destino.Text = reader.GetString(36);
                    txt_cajasvaciadas.Text = reader.GetString(37);

                    txtbajo.Enabled = false;
                    txtprecalibre.Enabled = false;
                    txtsobre.Enabled = false;
                    txtbajo.Enabled = false;
                    txtprecalibre.Enabled = false;
                    txtrusset.Enabled = false;
                    txtadhesion.Enabled = false;
                    txtpudricion.Enabled = false;
                    txtcalibreok.Enabled = false;
                    txtdanotrip.Enabled = false;
                    txtsutura.Enabled = false;
                    txtdeshid.Enabled = false;
                    txtmanchaspardas.Enabled = false;
                    txtsobre.Enabled = false;
                    txtescama.Enabled = false;
                    txtfaltocolor.Enabled = false;
                    txtdeshidpedi.Enabled = false;
                    txtdanopajaro.Enabled = false;
                    txtfrutosdeformes.Enabled = false;
                    txtramaleo.Enabled = false;
                    txtblandos.Enabled = false;
                    txtdesgarro.Enabled = false;
                    txtfrutosdobles.Enabled = false;
                    txtsinpedicelo.Enabled = false;
                    txtheridasabiertas.Enabled = false;
                    txtcortesierra.Enabled = false;
                    txtguatablanca.Enabled = false;
                    txtmachucon.Enabled = false;
                    txtherida.Enabled = false;
                    txtpartiduras.Enabled = false;
                    txtmanchas.Enabled = false;
                    txtpartidurasagua.Enabled = false;
                    txtmedialuna.Enabled = false;
                    txtpartiduracicatrizada.Enabled = false;
                    txtpiellagarto.Enabled = false;
                    txtpitting.Enabled = false;
                    txt_calisificacion.Enabled = false;
                    txt_destino.Enabled = false;
                    txt_cajasvaciadas.Enabled = false;
                    
                    con_existe_caja.Close();

                    //este lo puse yo
                    Siguiente1.Enabled = false;
                    TabPanel3.Enabled = true;
                    TabPanel3.Visible = true;
                    Button1.Enabled = false;
                    guardar_obs_bt.Visible = true;
                    guardar_obs_bt.Enabled = true;
                    TabPanel2.Enabled = true;
                    TabPanel2.Visible = true;
                    Grabar.Visible = false;
                    CheckSoluble.Visible = true;

                    txt_f1.Enabled = true;
                    txt_f2.Enabled = true;
                    txt_f3.Enabled = true;
                    txt_f4.Enabled = true;
                    txt_f5.Enabled = true;

                    boton_existe();


                }
                con_existe_caja.Close();
            }


           // SqlConnection conexion_2 = new SqlConnection(connStringmain.ToString());
            SqlCommand Comando_2 = new SqlCommand("select convert(varchar(4),f1) as F1,convert(varchar(4),f2) as F2,convert(varchar(4),f3) as F3,convert(varchar(4),f4) as F4,convert(varchar(4),f5) as F5 from solidossolubles where nroproceso='" + NroProceso.Text + "' and nrolinea = '" + Linea.Text + "' and turno='" + Turno.Text + "'", con_existe_caja);
            //SqlCommand cmd_proc_2 = new SqlCommand("select nroproceso from solidossolubles where nroproceso='" + NroProceso.Text + "' and nrolinea = '" + Linea.Text + "' and turno='" + Turno.Text + "'", con);
            SqlDataAdapter soluble = new SqlDataAdapter(Comando_2);
            DataSet ds_soluble = new DataSet();
            con_existe_caja.Open();
            soluble.Fill(ds_soluble);
            con_existe_caja.Close();

            if (ds_soluble.Tables[0].Rows.Count.ToString() == "0")
            {
                CheckSoluble.Visible = true;
                Button1.Visible = true;
                Button1.Enabled = true;

            }
            else
            {
                con_existe_caja.Open();
                using (SqlDataReader reader = Comando_2.ExecuteReader())
                {
                    reader.Read();
                    txt_f1.Text = reader.GetString(0);
                    txt_f2.Text = reader.GetString(1);
                    txt_f3.Text = reader.GetString(2);
                    txt_f4.Text = reader.GetString(3);
                    txt_f5.Text = reader.GetString(4);
                    txt_f1.Enabled = false;
                    txt_f2.Enabled = false;
                    txt_f3.Enabled = false;
                    txt_f4.Enabled = false;
                    txt_f5.Enabled = false;
                    Button1.Visible = false;
                    Button1.Enabled = false;

                }
                con_existe_caja.Close();
            }


            Grabar.Enabled = false;
            Grabar.Visible = false;
            Limpiar.Enabled = true;
            //Button1.Visible = true;
            //Button1.Enabled = true;
            TabContainer1.ActiveTab = TabPanel1;
            txtbajo.Focus();
            
        }

        protected void btn_limpiar(object sender, EventArgs e)
        {
            Limpiar_Click();
        }
        
        protected void Grabar_Click(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            //string comando = "INSERT INTO controlpt (cptnumero,placodigo,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptrutprr,cptnompre,cptrutpet,cptnompet,cptespcod,cptespdes,cptvarcod,cptvardes,cptcalibr,cptmarcod,cptmardes,cptembcod,cptembdes,cptenvcod,cptenvdes,cptpesone,cptsalida,cptcodcja,cptclasificacion,cptdestino,cptcajasvaciadas) VALUES ('" + numeroctrl + "','" + CodPta.Text + "','" + Turno.Text + "','" + numeroctrl + "','" + username + "','" + Linea.Text + "','" + NroProceso.Text + "','" + Lote.Text + "','" + ProdReal.Text + "','" + ProdRealtxt.Text + "','" + ProdEtiq.Text + "','" + ProdEtiqtxt.Text + "','" + especieid.Text + "','" + especietext.Text + "','" + Variedad.Text + "','" + VariedadText.Text + "','" + Calibre.Text + "','" + Marca.Text + "','" + MarcaTxt.Text + "','" + Embalaje.Text + "','" + Embalajetx.Text + "','" + Envase.Text + "','" + Envasetxt.Text + "','" + Peso.Text + "','" + Salida.Text + "','" + CodCaja.Text + "','" + txt_calisificacion.Text + "','" + txt_destino.Text + "'," + txt_cajasvaciadas.Text + ")";
            //string comando1 = "INSERT INTO defecto (cptnumero,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida,defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid,defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie) VALUES ('"+numeroctrl+"','"+txtbajo.Text+"','"+txtcalibreok.Text+"','"+txtsobre.Text+"','"+txtprecalibre.Text+"','"+txtdanotrip.Text+"','"+txtescama.Text+"','"+txtfrutosdeformes.Text+"','"+txtfrutosdobles.Text+"','"+txtguatablanca.Text+"','"+txtherida.Text+"','"+txtmanchas.Text+"','"+txtmedialuna.Text+"','"+txtpiellagarto.Text+"','"+txtrusset.Text+"','"+txtsutura.Text+"','"+txtfaltocolor.Text+"','"+txtramaleo.Text+"','"+txtsinpedicelo.Text+"','"+txtadhesion.Text+"','"+txtdeshid.Text+"','"+txtdeshidpedi.Text+"','"+txtblandos.Text+"','"+txtheridasabiertas.Text+"','"+txtmachucon.Text+"','"+txtpartiduras.Text+"','"+txtpartidurasagua.Text+"','"+txtpartiduracicatrizada.Text+"','"+txtpitting.Text+"','"+txtpudricion.Text+"','"+txtmanchaspardas.Text+"','"+txtdanopajaro.Text+"','"+txtdesgarro.Text+"','"+txtcortesierra.Text+"')";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();

            SqlCommand cmd_proc = new SqlCommand("select cptcodcja from CONTROLPT where cptcodcja='" + CodCaja.Text + "' group by cptcodcja", conexion);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);
                conexion.Close();
                if (ds_proc.Tables[0].Rows.Count.ToString() == "0")
                {
                    conexion.Open();
                   string comando = "INSERT INTO controlpt (cptnumero,placodigo,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptrutprr,cptnompre,cptrutpet,cptnompet,cptespcod,cptespdes,cptvarcod,cptvardes,cptcalibr,cptmarcod,cptmardes,cptembcod,cptembdes,cptenvcod,cptenvdes,cptpesone,cptsalida,cptcodcja,cptclasificacion,cptdestino,cptcajasvaciadas) VALUES ('" + numeroctrl + "','" + CodPta.Text + "','" + Turno.Text + "','" + numeroctrl + "','" + username + "','" + Linea.Text + "','" + NroProceso.Text + "','" + Lote.Text + "','" + ProdReal.Text + "','" + ProdRealtxt.Text + "','" + ProdEtiq.Text + "','" + ProdEtiqtxt.Text + "','" + especieid.Text + "','" + especietext.Text + "','" + Variedad.Text + "','" + VariedadText.Text + "','" + Calibre.Text + "','" + Marca.Text + "','" + MarcaTxt.Text + "','" + Embalaje.Text + "','" + Embalajetx.Text + "','" + Envase.Text + "','" + Envasetxt.Text + "','" + Peso.Text + "'," + Salida.Text + ",'" + CodCaja.Text + "','" + txt_calisificacion.Text + "','" + txt_destino.Text + "'," + txt_cajasvaciadas.Text + ")";
                   // string comando = "INSERT INTO controlpt (cptnumero,placodigo,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptrutprr,cptnompre,cptrutpet,cptnompet,cptespcod,cptespdes,cptvarcod,cptvardes,cptcalibr,cptmarcod,cptmardes,cptembcod,cptembdes,cptenvcod,cptenvdes,cptpesone,cptsalida,cptcodcja,cptclasificacion,cptdestino,cptcajasvaciadas) VALUES ('" + numeroctrl + "','" + CodPta.Text + "','" + Turno.Text + "','" + numeroctrl + "','" + username + "','" + Linea.Text + "','" + NroProceso.Text + "','" + Lote.Text + "','" + ProdReal.Text + "','" + ProdRealtxt.Text + "','" + ProdEtiq.Text + "','" + ProdEtiqtxt.Text + "','" + especieid.Text + "','" + especietext.Text + "','" + Variedad.Text + "','" + VariedadText.Text + "','" + Calibre.Text + "','" + Marca.Text + "','" + MarcaTxt.Text + "','" + Embalaje.Text + "','" + Embalajetx.Text + "','" + Envase.Text + "','" + Envasetxt.Text + "','" + Peso.Text + "'," + Salida.Text + ",'" + CodCaja.Text + "')";
                    string comando1 = "INSERT INTO defecto (cptnumero,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida,defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid,defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie,observac,pesoneto) VALUES ('" + numeroctrl + "','" + txtbajo.Text + "','" + txtcalibreok.Text + "','" + txtsobre.Text + "','" + txtprecalibre.Text + "','" + txtdanotrip.Text + "','" + txtescama.Text + "','" + txtfrutosdeformes.Text + "','" + txtfrutosdobles.Text + "','" + txtguatablanca.Text + "','" + txtherida.Text + "','" + txtmanchas.Text + "','" + txtmedialuna.Text + "','" + txtpiellagarto.Text + "','" + txtrusset.Text + "','" + txtsutura.Text + "','" + txtfaltocolor.Text + "','" + txtramaleo.Text + "','" + txtsinpedicelo.Text + "','" + txtadhesion.Text + "','" + txtdeshid.Text + "','" + txtdeshidpedi.Text + "','" + txtblandos.Text + "','" + txtheridasabiertas.Text + "','" + txtmachucon.Text + "','" + txtpartiduras.Text + "','" + txtpartidurasagua.Text + "','" + txtpartiduracicatrizada.Text + "','" + txtpitting.Text + "','" + txtpudricion.Text + "','" + txtmanchaspardas.Text + "','" + txtdanopajaro.Text + "','" + txtdesgarro.Text + "','" + txtcortesierra.Text + "','" + TextBox1obs.Text + "','" +txt_peso_neto.Text+"')";
            
                    using (SqlCommand sql = new SqlCommand(comando, conexion))
                    {
                        sql.ExecuteNonQuery();
                        conexion.Close();
                    }

                    conexion.Open();
                    using (SqlCommand sql = new SqlCommand(comando1, conexion))
                    {
                        sql.ExecuteNonQuery();
                        conexion.Close();
                        
                    }
                    string error = "Registro guardado OK";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");

                    CodCaja.Text = "";
                    Turno.Text = "";
                    especieid.Text = "";
                    especietext.Text = "";
                    Linea.Text = "";
                    Variedad.Text = "";
                    VariedadText.Text = "";
                    NroProceso.Text = "";
                    Marca.Text = "";
                    MarcaTxt.Text = "";
                    Lote.Text = "";
                    Embalaje.Text = "";
                    Embalajetx.Text = "";
                    Peso.Text = "";
                    Envase.Text = "";
                    Envasetxt.Text = "";
                    Calibre.Text = "";
                    ProdReal.Text = "";
                    ProdRealtxt.Text = "";
                    Salida.Text = "";
                    ProdEtiq.Text = "";
                    ProdEtiqtxt.Text = "";
                    TextBox1obs.Text = "";
                    txt_peso_neto.Text = "";
                    txtbajo.Text = "0";
                    txtprecalibre.Text = "0";
                    txtrusset.Text = "0";
                    txtadhesion.Text = "0";
                    txtpudricion.Text = "0";
                    txtcalibreok.Text = "0";
                    txtdanotrip.Text = "0";
                    txtsutura.Text = "0";
                    txtdeshid.Text = "0";
                    txtmanchaspardas.Text = "0";
                    txtsobre.Text = "0";
                    txtescama.Text = "0";
                    txtfaltocolor.Text = "0";
                    txtdeshidpedi.Text = "0";
                    txtdanopajaro.Text = "0";
                    txtfrutosdeformes.Text = "0";
                    txtramaleo.Text = "0";
                    txtblandos.Text = "0";
                    txtdesgarro.Text = "0";
                    txtfrutosdobles.Text = "0";
                    txtsinpedicelo.Text = "0";
                    txtheridasabiertas.Text = "0";
                    txtcortesierra.Text = "0";
                    txtguatablanca.Text = "0";
                    txtmachucon.Text = "0";
                    txtherida.Text = "0";
                    txtpartiduras.Text = "0";
                    txtmanchas.Text = "0";
                    txtpartidurasagua.Text = "0";
                    txtmedialuna.Text = "0";
                    txtpartiduracicatrizada.Text = "0";
                    txtpiellagarto.Text = "0";
                    txtpitting.Text = "0";
                    CodCaja.Focus();


                }
                else
                {
                    string error = "Registro ya existente..";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");
                }


            }
            catch { }

           // Limpiar_Click();
            Response.Redirect("~/SisConPT/Ingreso-CC-PAC-005-CODCAJ.aspx");
            ButtonBuscar.Enabled = true;
            TabPanel2.Visible = true;
            TabPanel3.Visible = true;
            Button1.Visible = true;
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
            TabContainer1.ActiveTab = TabPanel1;
            CodCaja.Enabled = true;


            
        }

        private void boton_existe()
        {
            Grabar.Visible = false;
        }

        protected void Grabar_soluble(object sender, EventArgs e)
        {
             
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;

            string comando = "insert into solidossolubles (cptnumero,nroproceso,codcaja,nrolote,turno,usuario,calibresoluble,f1,f2,f3,f4,f5, nrolinea) values ('" + numeroctrl + "','" + NroProceso.Text + "','" + CodCaja.Text + "','" + Lote.Text + "','" + Turno.Text + "','" + username + "','" + lbl_calibre.Text + "', " + txt_f1.Text + "," + txt_f2.Text + "," + txt_f3.Text + "," + txt_f4.Text + "," + txt_f5.Text + ",'" + Linea.Text + "')";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();
            SqlCommand cmd_proc = new SqlCommand("select nroproceso from solidossolubles where nroproceso='" + NroProceso.Text + "' and nrolinea = '" + Linea.Text + "' and turno='" + Turno.Text + "'", conexion);
            SqlDataAdapter sda_proc = new SqlDataAdapter(cmd_proc);
            DataSet ds_proc = new DataSet();
            try
            {
                sda_proc.Fill(ds_proc);
                conexion.Close();
                if (ds_proc.Tables[0].Rows.Count.ToString() == "0")
                {
                    conexion.Open();
                    using (SqlCommand sql = new SqlCommand(comando, conexion))
                    {

                        sql.ExecuteNonQuery();
                        conexion.Close();

                    }

                    string error = "Registro guardado OK";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");

                }
                else
                {
                    string error = "Registro ya existente..";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");
                }

            }
            catch { }
                txt_f1.Text = "0";
                txt_f2.Text = "0";
                txt_f3.Text = "0";
                txt_f4.Text = "0";
                txt_f5.Text = "0";
            
            TabPanel2.Enabled = false;
            TabPanel1.Enabled = false;
            txtbajo.Focus();
            Button1.Enabled = false;
            Button1.Visible = false;
            Grabar.Enabled = true;
            Grabar.Visible = true;
            Limpiar.Enabled = true;
            TabPanel2.Enabled = true;
           // TabContainer1.ActiveTab = TabPanel2;
               
        }

        protected void Siguiente1_cick(object sender, EventArgs e)
           {


               if (CheckSoluble.Checked == true)
               {
                   TabPanel3.Enabled = true;
                   TabPanel3.Visible = true;
                   TabContainer1.ActiveTab = TabPanel3;
                   SiguienteFinal.Visible = true;
                   SiguienteFinal.Enabled = true;
               }
               else
               {
                   TabPanel2.Enabled = true;
                   TabPanel2.Visible = true;
                   TabContainer1.ActiveTab = TabPanel2;
                   Grabar.Enabled = true;
                   Grabar.Visible = true;
                   
               }
               //TabContainer1.ActiveTab = TabPanel3;
               TabPanel1.Enabled = false;
               Siguiente1.Visible = false;
               Button1.Visible = true;

           }

        private void Limpiar_Click()
    {
        CodCaja.Text = "";
            Turno.Text = "";
            especieid.Text = "";
            especietext.Text = "";
            Linea.Text = "";
            Variedad.Text = "";
            VariedadText.Text = "";
            NroProceso.Text = "";
            Marca.Text = "";
            MarcaTxt.Text = "";
            Lote.Text = "";
            Embalaje.Text = "";
            Embalajetx.Text = "";
            Peso.Text = "";
            Envase.Text = "";
            Envasetxt.Text = "";
            Calibre.Text = "";
            ProdReal.Text = "";
            ProdRealtxt.Text = "";
            Salida.Text = "";
            ProdEtiq.Text = "";
            ProdEtiqtxt.Text = "";
            TextBox1obs.Text = "";
            txtbajo.Text = "0";
            txtprecalibre.Text = "0";
            txtrusset.Text = "0";
            txtadhesion.Text = "0";
            txtpudricion.Text = "0";
            txtcalibreok.Text = "0";
            txtdanotrip.Text = "0";
            txtsutura.Text = "0";
            txtdeshid.Text = "0";
            txtmanchaspardas.Text = "0";
            txtsobre.Text = "0";
            txtescama.Text = "0";
            txtfaltocolor.Text = "0";
            txtdeshidpedi.Text = "0";
            txtdanopajaro.Text = "0";
            txtfrutosdeformes.Text = "0";
            txtramaleo.Text = "0";
            txtblandos.Text = "0";
            txtdesgarro.Text = "0";
            txtfrutosdobles.Text = "0";
            txtsinpedicelo.Text = "0";
            txtheridasabiertas.Text = "0";
            txtcortesierra.Text = "0";
            txtguatablanca.Text = "0";
            txtmachucon.Text = "0";
            txtherida.Text = "0";
            txtpartiduras.Text = "0";
            txtmanchas.Text = "0";
            txtpartidurasagua.Text = "0";
            txtmedialuna.Text = "0";
            txtpartiduracicatrizada.Text = "0";
            txtpiellagarto.Text = "0";
            txtpitting.Text = "0";
            CodCaja.Focus();
            ButtonBuscar.Enabled = true;
            CodCaja.Enabled = true;
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
            TabPanel2.Enabled = false;
            TabPanel3.Enabled = false;
            TabContainer1.ActiveTab = TabPanel1;
    }

        protected void Siguiente2_click(object sender, EventArgs e)
        {


            Grabar.Enabled = true;
            Grabar.Visible = true;
            Limpiar.Enabled = true;
            TabPanel2.Enabled = true;
            TabContainer1.ActiveTab = TabPanel2;

            TabPanel1.Enabled = false;
            Siguiente1.Visible = false;
            Button1.Visible = true;

        }

        protected void guardar_obs(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();

            //SqlCommand cmd_proc = new SqlCommand("update defecto set observac='" + TextBox1obs.Text + "' where cptnumero='" + CodCaja.Text + "'", conexion);
            string comando1 = "update defecto set observac='" + TextBox1obs.Text + "' from defecto as def inner join controlpt as cl on cl.cptnumero=def.cptnumero where cl.cptcodcja='" + CodCaja.Text + "'";
            try
            {
                using (SqlCommand sql = new SqlCommand(comando1, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    string error = "Observacion guardada..";
                    Response.Write("<script language=javascript > alert('" + error + "'); </script>");
                }
                Response.Redirect("~/SisConPT/Ingreso-CC-PAC-005-CODCAJ.aspx");
            }
            catch
            {
            }




        }


        //protected void btn_clasi_click(object sender, EventArgs e)
        //{
        //    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
        //    System.Configuration.ConnectionStringSettings connStringmain;
        //    connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];

        //    SqlConnection conexion = new SqlConnection(connStringmain.ToString());
        //    conexion.Open();

        //    //SqlCommand cmd_proc = new SqlCommand("update defecto set observac='" + TextBox1obs.Text + "' where cptnumero='" + CodCaja.Text + "'", conexion);
        //    string comando1 = "update controlpt set cptclasificacion='" + txt_calisificacion.Text + "',cptdestino='" + txt_destino.Text + "',cptcajasvaciadas=" + txt_cajasvaciadas + " where cptproces='" + NroProceso.Text + "' and lincodigo='" + Linea.Text + "' and turcodigo='" + Turno.Text + "' and cptnulote='" + Lote.Text + "' and placodigo='" + CodPta.Text + "' and (cptdestino ='' or cptclasificacion='' or cptcajasvaciadas<>0)";
        //    try
        //    {
        //        using (SqlCommand sql = new SqlCommand(comando1, conexion))
        //        {
        //            sql.ExecuteNonQuery();
        //            conexion.Close();
        //            string error = "ok";
        //            Response.Write("<script language=javascript > alert('" + error + "'); </script>");
        //        }
               
        //    }
        //    catch
        //    {
        //    }




        //}



    }
}
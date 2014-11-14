﻿using System;
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

            if (!IsPostBack)
            {
                SOLUBLE();
            }

        

        }
        protected void btnLoadData_click(object senders, EventArgs e)
        {
            string codigocaja = CodCaja.Text;
            string comando = "SELECT [codCaja],[FechaProduccion],convert(varchar(8),[proceso]) as proceso ,[Lote],[codLinea],[Linea] ,[Turno],[Salida],[Clasificacion],[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada],[codEnvase],[Envase],[codEmbalaje],[Embalaje],[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca] ,[Marca] ,[ClaseCalibreColor],[CalibreTimbrado],[CAT] ,[codProductorReal],[ProductorReal],[ComunaReal],[ProvinciaReal],[RegionReal],[codProductorTimbrado],[ProductorTimbrado],[ComunaTimbrada],[ProvinciaTimbrada],[RegionTimbrada],[CondicionEmbarque],[NumeroPalet],[FechaPaletizaje] FROM DatosCajas WHERE codCaja ='" + codigocaja + "'";
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
            }
    
           }
          catch 
            {
          }

            conexion.Close();
            ButtonBuscar.Enabled = false;
            Grabar.Enabled = true;
            Limpiar.Enabled = true;
            txtbajo.Focus();
        }
        protected void Limpiar_Click(object sender, EventArgs e)
        {
            CodCaja.Text = "0";
            Turno.Text = "0";
            especieid.Text = "0";
            especietext.Text = "0";
            Linea.Text = "0";
            Variedad.Text = "0";
            VariedadText.Text = "0";
            NroProceso.Text = "0";
            Marca.Text = "0";
            MarcaTxt.Text = "0";
            Lote.Text = "0";
            Embalaje.Text = "0";
            Embalajetx.Text = "0";
            Peso.Text = "0";
            Envase.Text = "0";
            Envasetxt.Text = "0";
            Calibre.Text = "0";
            ProdReal.Text = "0";
            ProdRealtxt.Text = "0";
            Salida.Text = "0";
            ProdEtiq.Text = "0";
            ProdEtiqtxt.Text = "0";
            TextBox1obs.Text = "0";
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
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
        }
        protected void Grabar_Click(object sender, EventArgs e)
        {
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            string comando = "INSERT INTO controlpt (cptnumero,placodigo,turcodigo,cptfechor,usurutusu,lincodigo,cptproces,cptnulote,cptrutprr,cptnompre,cptrutpet,cptnompet,cptespcod,cptespdes,cptvarcod,cptvardes,cptcalibr,cptmarcod,cptmardes,cptembcod,cptembdes,cptenvcod,cptenvdes,cptpesone,cptsalida,cptcodcja) VALUES ('"+numeroctrl+"','"+CodPta.Text+"','"+Turno.Text+"','"+numeroctrl+"','"+username+"','"+Linea.Text+"','"+NroProceso.Text+"','"+Lote.Text+"','"+ProdReal.Text+"','"+ProdRealtxt.Text+"','"+ProdEtiq.Text+"','"+ProdEtiqtxt.Text+"','"+especieid.Text+"','"+especietext.Text+"','"+Variedad.Text+"','"+VariedadText.Text+"','"+Calibre.Text+"','"+Marca.Text+"','"+MarcaTxt.Text+"','"+Embalaje.Text+"','"+Embalajetx.Text+"','"+Envase.Text+"','"+Envasetxt.Text+"','"+Peso.Text+"','"+Salida.Text+"','"+CodCaja.Text+"')";
            string comando1 = "INSERT INTO defecto (cptnumero,defcalbaj,defcalnor,defcalsob,defprecal,defdanotr,defescama,deffrutode,deffrutodo,defguatab,defherida,defmancha,defmedial,defpiella,defrusset,defsutura,deffaltoc,deframole,defsinped,defadhesi,defdesfru,defdesped,defblando,defherabi,defmachuc,defpartid,defparagu,defparcic,defpittin,defpudric,defmanpar,defdanopa,defdesgar,defcorsie) VALUES ('"+numeroctrl+"','"+txtbajo.Text+"','"+txtcalibreok.Text+"','"+txtsobre.Text+"','"+txtprecalibre.Text+"','"+txtdanotrip.Text+"','"+txtescama.Text+"','"+txtfrutosdeformes.Text+"','"+txtfrutosdobles.Text+"','"+txtguatablanca.Text+"','"+txtherida.Text+"','"+txtmanchas.Text+"','"+txtmedialuna.Text+"','"+txtpiellagarto.Text+"','"+txtrusset.Text+"','"+txtsutura.Text+"','"+txtfaltocolor.Text+"','"+txtramaleo.Text+"','"+txtsinpedicelo.Text+"','"+txtadhesion.Text+"','"+txtdeshid.Text+"','"+txtdeshidpedi.Text+"','"+txtblandos.Text+"','"+txtheridasabiertas.Text+"','"+txtmachucon.Text+"','"+txtpartiduras.Text+"','"+txtpartidurasagua.Text+"','"+txtpartiduracicatrizada.Text+"','"+txtpitting.Text+"','"+txtpudricion.Text+"','"+txtmanchaspardas.Text+"','"+txtdanopajaro.Text+"','"+txtdesgarro.Text+"','"+txtcortesierra.Text+"')";
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
                        
 
  //              SqlConnection conexion = new SqlConnection(connStringmain.ToString());
                conexion.Open();
                using (SqlCommand sql = new SqlCommand(comando1, conexion))
                {
                    sql.ExecuteNonQuery();
                    conexion.Close();
                }

                CodCaja.Text = "0";
                Turno.Text = "0";
                especieid.Text = "0";
                especietext.Text = "0";
                Linea.Text = "0";
                Variedad.Text = "0";
                VariedadText.Text = "0";
                NroProceso.Text = "0";
                Marca.Text = "0";
                MarcaTxt.Text = "0";
                Lote.Text = "0";
                Embalaje.Text = "0";
                Embalajetx.Text = "0";
                Peso.Text = "0";
                Envase.Text = "0";
                Envasetxt.Text = "0";
                Calibre.Text = "0";
                ProdReal.Text = "0";
                ProdRealtxt.Text = "0";
                Salida.Text = "0";
                ProdEtiq.Text = "0";
                ProdEtiqtxt.Text = "0";
                TextBox1obs.Text = "0";
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
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
        }

        private void SOLUBLE()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string PlantaNombre = Session["PlantaName"].ToString();
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            //turno
            SqlCommand cmd_soluble = new SqlCommand("SELECT SOL_ID, SOL_DESCRIP FROM SOLSOL", con);
            SqlDataAdapter sda_soluble = new SqlDataAdapter(cmd_soluble);
            DataSet ds_soluble = new DataSet();
            sda_soluble.Fill(ds_soluble);

            SOLUBLE_D.DataSourceID = "";
            SOLUBLE_D.DataSource = ds_soluble;
            SOLUBLE_D.DataBind();


            if (SOLUBLE_D.Items.Count != 0)
            {
                int proceso = Convert.ToInt32(SOLUBLE_D.SelectedValue);

                //SOLUBLE_D(proceso);

            }
            con.Close();
        }

        protected void SOL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int proceso = Convert.ToInt32(SOLUBLE_D.SelectedValue);

            //DropLinea(proceso);

        }



        private bool Exists(string NroProceso, string Linea, string Turno)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string existe = "select count(1) as  casos from solidossolubles where nroproceso=" + NroProceso + " and nrolinea = " + Linea + " and turno='" + Turno + "'";
            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();
            SqlCommand command = new SqlCommand(existe, conexion);
            string count = Convert.ToString(command.ExecuteScalar());
            if (count == "")

            return true;

            else

            return false;

        }



           protected void Grabar_soluble(object sender, EventArgs e)
        {
             
            string numeroctrl = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            string username = HttpContext.Current.User.Identity.Name;
            int id_sol = Convert.ToInt32(SOLUBLE_D.SelectedValue);
            string comando = "insert into solidossolubles (cptnumero,nroproceso,codcaja,nrolote,turno,usuario,idsol,f1,f2,f3,f4,f5, nrolinea) values ('" + numeroctrl + "','" + NroProceso.Text + "','" + CodCaja.Text + "','" + Lote.Text + "','" + Turno.Text + "','" + username + "','" + id_sol + "', " + txt_f1.Text + "," + txt_f2.Text + "," + txt_f3.Text + "," + txt_f4.Text + "," + txt_f5.Text + ",'" + Linea.Text + "')";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            string existe = "select nroproceso from solidossolubles where nroproceso='" + NroProceso.Text + "' and nrolinea = '" + Linea.Text + "' and turno='" + Turno.Text + "'";
            SqlConnection conexion = new SqlConnection(connStringmain.ToString());
            conexion.Open();
            
         
                   using (SqlCommand sql = new SqlCommand(comando, conexion))
               {
                   sql.ExecuteNonQuery();
                    conexion.Close();
              }



                             
                txt_f1.Text = "0";
                txt_f2.Text = "0";
                txt_f3.Text = "0";
                txt_f4.Text = "0";
                txt_f5.Text = "0";


            CodCaja.Focus();
            ButtonBuscar.Enabled = true;
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
        }





    }
}
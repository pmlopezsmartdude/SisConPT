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
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
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
        

        }
        protected void btnLoadData_click(object senders, EventArgs e)
        {
            string codigocaja = CodCaja.Text;
            string comando = "SELECT [codCaja],[FechaProduccion],convert(varchar(8),[proceso]) as proceso ,[Lote],[codLinea],[Linea] ,[Turno],[Salida],[Clasificacion],[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada],[codEnvase],[Envase],[codEmbalaje],[Embalaje],[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca] ,[Marca] ,[ClaseCalibreColor],[CalibreTimbrado],[CAT] ,[codProductorReal],[ProductorReal],[ComunaReal],[ProvinciaReal],[RegionReal],[codProductorTimbrado],[ProductorTimbrado],[ComunaTimbrada],[ProvinciaTimbrada],[RegionTimbrada],[CondicionEmbarque],[NumeroPalet],[FechaPaletizaje] FROM DatosCajas WHERE codCaja ='" + codigocaja + "'";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
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
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
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
            CodCaja.Focus();
            ButtonBuscar.Enabled = true;
            Grabar.Enabled = false;
            Limpiar.Enabled = false;
        } 
    }
}
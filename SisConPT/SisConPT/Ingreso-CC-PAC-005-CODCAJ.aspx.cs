using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SisConPT.SisConPT
{
    public partial class Ingreso_CC_PAC_005_CODCAJ : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connStringmain;
            System.Configuration.ConnectionStringSettings connStringLM;
            if (Session["PlantaName"] != null)
            {
                connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
                /* Response.Write("Base de datos: " + Session["PlantaName"].ToString());  */
                string PlantaNombre = Session["PlantaName"].ToString();
                SqlConnection SqlConnMain = new SqlConnection(connStringmain.ToString());
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = ("SELECT * FROM planta WHERE pladescri ='"+ PlantaNombre +"'");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = SqlConnMain;
                SqlConnMain.Open();
                reader = cmd.ExecuteReader();
                Response.Write("Resulta el Query?" + cmd.CommandText);
                /* Response.Write(reader["placodigo"]); */
                /*CodPta.Text = (reader["placodigo"].ToString());*/
                SqlConnMain.Close();
            }
            if (Session["PlantaName"].ToString() == "Planta Mostazal")
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager01"];
               /* if (null != connStringLM)
                    Response.Write("String de Conexion = " + connStringLM);
                else
                    Response.Write("No hay String de Conexion"); */
            }
            else
            {
                connStringLM = rootWebConfig.ConnectionStrings.ConnectionStrings["LotManager40"];
                /* if (null != connStringLM)
                    Response.Write("String de Conexion = " + connStringLM);
                else
                    Response.Write("No hay String de Conexion"); */
            }
            /*
            if (Session.["PlantaName"].ToString() == "Planta Mostazal")
            {
                string DataSourceName = "LotManager01";
            }
            if (Session.["PlantaName"].ToString() == "Planta Molina")
            {
                string DataSourceName = "LotManager40";
            }
                        if (!IsPostBack)
            {
                CodCaja.Attributes.Add("onKeyPress", "doClick('" + btnLoadData.ClientID + "',event)");
 
            }*/
          

        }
        protected void btnLoadData_click(object senders, EventArgs e)
        {
           /* ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + CodCaja.Text + "');", true);
            SqlConnection Conexion = new SqlConnection(DataSourceName);
            string CadenaSql = "SELECT * FROM dbo.DatosCajas where codCaja='" + CodCaja.Text + "'";
            SqlCommand Comando = new SqlCommand(CadenaSql, Conexion);
            Conexion.Open();
            SqlDataReader Reader = Comando.ExecuteReader();
            if (Reader.Read() == Reader.Read())
            {
                Turno.Text = Reader["Turno"].ToString();
                especieid.Text = Reader["codEspecie"].ToString();
                especietext.Text = Reader["Especie"].ToString();
                Linea.Text = Reader["Linea"].ToString();
                Variedad.Text = Reader["codVariedadReal"].ToString();
                VariedadText.Text = Reader["VariedadReal"].ToString();
                NroProceso.Text = Reader["Proceso"].ToString();
                Marca.Text = Reader["codMarca"].ToString();
                MarcaTxt.Text = Reader["Marca"].ToString();
                Lote.Text = Reader["Lote"].ToString();
                Embalaje.Text = Reader["codEmbalaje"].ToString();
                Embalajetx.Text = Reader["Embalaje"].ToString();
                Peso.Text = Reader["PesoTimbrado"].ToString();
                Envase.Text = Reader["codEnvase"].ToString();
                Envasetxt.Text = Reader["Envase"].ToString();
                Calibre.Text = Reader["ClaseCalibreColor"].ToString();
                ProdReal.Text = Reader["codProductorReal"].ToString();
                ProdRealtxt.Text = Reader["ProductorReal"].ToString();
                Salida.Text = Reader["Salida"].ToString();
                ProdEtiq.Text = Reader["codProductorTimbrado"].ToString();
                ProdEtiqtxt.Text = Reader["ProductorTimbrado"].ToString();
            } */
        } 
    
    }
}
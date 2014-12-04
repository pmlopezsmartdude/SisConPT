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
using System.Configuration;
using System.Web.Security;

namespace SisConPT.SisConPT
{
    public partial class SysConPT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_editar.Visible = false;
            string[] roles = Roles.GetRolesForUser();
            string rol = "";
            foreach (string r in roles)
            {
                if (r == "Administrador")
                {
                    btn_editar.Visible = true;
                    rol = "00";
                    break;
                }
                else
                {
                    if (r == "operador Molina")
                    {
                        rol = "40";
                        break;
                    }
                    else
                    {
                        if (r == "operador San Francisco")
                        {
                            rol = "01";
                            break;
                        }
                        else
                        {
                            rol = "00";
                            break;
                        }
                    }
                }

              // rol += r + " ";
            }
            if (!IsPostBack)
            {
                DropPlanta(rol);
            }
        }

        private void DropPlanta(string DropPlanta)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/sisconpt");
            System.Configuration.ConnectionStringSettings connStringmain;
            connStringmain = rootWebConfig.ConnectionStrings.ConnectionStrings["CONTROLPTConnectionString"];
            SqlConnection con = new SqlConnection(connStringmain.ToString());
            con.Open();
            string DDL_planta = "";
            if (DropPlanta == "00") { DDL_planta = "SELECT [pladescri] FROM [planta]"; }
            else { DDL_planta = "SELECT [pladescri] FROM [planta] where placodigo='" + DropPlanta + "'"; }

            SqlCommand cmd_linea = new SqlCommand(DDL_planta, con);
            SqlDataAdapter sda_linea = new SqlDataAdapter(cmd_linea);
            DataSet ds_linea = new DataSet();
            sda_linea.Fill(ds_linea);
            DropPlanta_d.DataSourceID = "";
            DropPlanta_d.DataSource = ds_linea;
            DropPlanta_d.DataBind();

            con.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Ingreso-CC-PAC-005-CODCAJ.aspx");
 
        }
        protected void Btn_proc_Click(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Ingreso_CC-PAC-075_proceso.aspx");

        }

        protected void detalle(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Detalle_CC_PAC_005.aspx");

        }
        protected void Editar(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Editar_CC_PAC_005.aspx");

        }

        protected void Btn_resumen_005(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Resumen_CC-PAC-005_CODCAJ.aspx");

        }
        protected void Btn_resumen_075(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Resumen_CC-PAC-075_CSV.aspx");

        }
        protected void Btn_003(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Ingreso_CC-PAC-003.aspx");

        }

        //protected void Btn_carga(object sender, EventArgs e)
        //{
        //    Session["PlantaName"] = DropDownList1.Text;
        //    Response.Redirect("~/SisConPT/ImportExcel.aspx");

        //}
        protected void Btn_resumen_003(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropPlanta_d.Text;
            Response.Redirect("~/SisConPT/Resumen_CC_PAC_003.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisConPT.SisConPT
{
    public partial class SysConPT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropDownList1.Text;
            Response.Redirect("~/SisConPT/Ingreso-CC-PAC-005-CODCAJ.aspx");
 
        }
        protected void Btn_proc_Click(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropDownList1.Text;
            Response.Redirect("~/SisConPT/Ingreso_CC-PAC-075_proceso.aspx");

        }

        //protected void Btn_cons_proc(object sender, EventArgs e)
        //{
        //    Session["PlantaName"] = DropDownList1.Text;
        //    Response.Redirect("~/SisConPT/Consulta_CC-PAC-075_proceso.aspx");

        //}

        protected void Btn_resumen_005(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropDownList1.Text;
            Response.Redirect("~/SisConPT/Resumen_CC-PAC-005_CODCAJ.aspx");

        }
        protected void Btn_resumen_075(object sender, EventArgs e)
        {
            Session["PlantaName"] = DropDownList1.Text;
            Response.Redirect("~/SisConPT/Resumen_CC-PAC-075_CSV.aspx");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Net;
using System.Data.SqlClient;




using System.Web.UI.WebControls.Adapters;



namespace SisConPT.SisConPT
{
    public partial class GenerarPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();

        }

        
        protected void boton_Click(object sender, EventArgs e)
        {          
            StringWriter sw = new StringWriter();
            string html = sw.ToString();
            
            Document Doc = new Document();
            
            PdfWriter.GetInstance
            (Doc, new FileStream(Environment.GetFolderPath
            (Environment.SpecialFolder.Desktop)
            + "\\Prueba.pdf", FileMode.Create));
            Doc.Open();

            Chunk c = new Chunk
            ("Prueba de un Documento en PDF \n", FontFactory.GetFont("Verdana", 15));
            
            Paragraph p = new Paragraph();
            p.Alignment = Element.ALIGN_CENTER;
            p.Add(c);

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font times = new Font(bfTimes, 12, Font.ITALIC, Color.RED);
            Font times2 = new Font(bfTimes, 12, Font.NORMAL, Color.BLACK);

            Chunk chunk1 = new Chunk
            ("\nEste es un parrafo (p1) alineado a la derecha, con letra cursiva y de color rojo. \n\n", times);
            Paragraph p1 = new Paragraph();
            
            p1.Alignment = Element.ALIGN_RIGHT;
            p1.Add(chunk1);

            Chunk chunk2 = new Chunk
            ("Este es un parrafo (p2) con letra normal, color negro, en el que estamos concatenando este texto un texto extraido de un textbox, que dice '" + txt.Text.ToString() + "'", times2);
            Paragraph p2 = new Paragraph();
            
            p2.Alignment = Element.ALIGN_JUSTIFIED;
            p2.Add(chunk2);

            Doc.Add(p);
            Doc.Add(p1);
            Doc.Add(p2);

            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new StringReader(html));
            HtmlParser.Parse(Doc, xmlReader);

            Doc.Close();

            string Path = Environment.GetFolderPath
            (Environment.SpecialFolder.Desktop)
            + "\\Prueba.pdf";


            ShowPdf(Path);
        }
    }
}
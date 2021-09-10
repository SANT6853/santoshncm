using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class auth_Adminpanel_Releted_Imege : System.Web.UI.Page
{
    Dal_upload_file dal = new Dal_upload_file();
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"].ToString();
        if (type == "1")
        {
          //  bindphotos.Columns[3].Visible = true;//2
            bindphotos.Columns[4].Visible = false;//1
        }
       else
        {
            bindphotos.Columns[3].Visible = false;
            bindphotos.Columns[4].Visible = true;
        }
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            bindrepeater();
          
        }
    }
    public void bindrepeater()
    {
        DataSet ds = new DataSet();
        int villageid = Int32.Parse(Request.QueryString["villageid"]);
        //Request.QueryString["type"].ToString()
        if (Request.QueryString["Resv"] != "NA")
        {
            ds = dal.show_imeges(villageid, Request.QueryString["type"].ToString(), Request.QueryString["Resv"].ToString());
        }
        else
        {
             ds = dal.show_imeges(villageid, Request.QueryString["type"].ToString(),null);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            bindphotos.DataSource = ds;
            bindphotos.DataBind();

            BtnPDFexport.Visible=true;
            BtnExcelExport.Visible = true;
        }
        else
        {

            BtnPDFexport.Visible = false;
            BtnExcelExport.Visible = false;

            bindphotos.DataSource = null;
            bindphotos.DataBind();
            lblmsg.Text = " No Images or file Uploaded";
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("report/perticular_village_report.aspx"));
    }
    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
            hw.WriteLine("<br>");
            //To Export all pages

            bindphotos.AllowPaging = false;
            bindrepeater();
            this.bindphotos.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bindphotos.HeaderStyle.BackColor = System.Drawing.Color.Red;
            foreach (TableCell cell in bindphotos.HeaderRow.Cells)
            {
                cell.BackColor = bindphotos.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in bindphotos.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = bindphotos.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = bindphotos.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            bindphotos.RenderControl(hw);

            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    
    protected void BtnPDFexport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
        hw.WriteLine("<br>");

        this.bindphotos.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 100f, 0.0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
  
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
   
}
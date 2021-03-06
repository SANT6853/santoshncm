using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_REPORT_exporttopdf : CrsfBase
{ 
    Dal_upload_file dal = new Dal_upload_file();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindrepeater();

        }
    }
    public void bindrepeater()
    {
        DataSet ds = new DataSet();
       // int villageid = Int32.Parse(Request.QueryString["villageid"]);
        //Request.QueryString["type"].ToString()
        //if (Request.QueryString["Resv"] != "NA")
        //{
        //    ds = dal.show_imeges(villageid, Request.QueryString["type"].ToString(), Request.QueryString["Resv"].ToString());
        //}
        //else
        //{
        //    ds = dal.show_imeges(villageid, Request.QueryString["type"].ToString(), null);
        //}
        ds = dal.show_imeges(10039, "1",null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            bindphotos.DataSource = ds;
            bindphotos.DataBind();
        }
        else
        {
            bindphotos.DataSource = null;
            bindphotos.DataBind();
          //  lblmsg.Text = " No Images or file Uploaded";
        }
    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

        try
        {
            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {
                    if (Page.IsValid)
                    {

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        this.bindphotos.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                    }
                }
            }
        }
        catch
        {
            throw;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
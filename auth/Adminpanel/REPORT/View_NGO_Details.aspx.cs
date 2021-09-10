using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_View_NGO_Details : CrsfBase
{
    NgoDB ngo = new NgoDB();


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "NGO REPORT :NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["V_ID"] != null)
            {

                if (Request.QueryString["V_ID"].ToString() != "")
                {
                    BindNGOById();

                }
            }

        }

    }


    protected void btn_print_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
        // {

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

                        this.printGrid();
                        //btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
                        //Session["ctrl"] = Panel1;

                        //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>"); 
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
          // if (Page.IsValid)
        // {

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

                        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/VillageSearch.aspx"), false);
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }

    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "";
        int sno = 0;
        decimal AllottedAmountRs = 0;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["amount"]);

        }
        //sno
        gvforVillages.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gvforVillages.FooterRow.Cells[0].Font.Bold = true;
        gvforVillages.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvforVillages.FooterRow.Cells[4].Text = Total + AllottedAmountRs.ToString();
        gvforVillages.FooterRow.Cells[4].Font.Bold = true;
        gvforVillages.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;


    }
    public void BindNGOById()
    {
        DataSet ds = new DataSet();
        try
        {

            ds = ngo.Proc_DisplayNGODetail(Request.QueryString["V_ID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds;
                ViewState["Data"] = ds;
                gvforVillages.DataBind();
                Button2.Visible = true;
                GridveiwNumericColumnCalculation(ds);
                BtnExcelExport.Visible = true;
            }
            else
            {
                BtnExcelExport.Visible = false;
                Button2.Visible = false;
                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvforVillages.PageIndex = e.NewPageIndex;
            BindNGOById();

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gvforVillages.DataSource = ViewState["Data"];
        gvforVillages.AllowPaging = false;
        gvforVillages.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvforVillages.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Total NGO Report for a Village ");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gvforVillages.AllowPaging = true;
        gvforVillages.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void BtnPdfExport_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
        // {

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
                        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">NGO Details</h1>");
                        hw.WriteLine("<br>");
                        //    gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gvforVillages.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gvforVillages.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gvforVillages.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gvforVillages.AllowPaging = true;
                        gvforVillages.DataBind();
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }
    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
        // {

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


                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {
                            HtmlTextWriter hw = new HtmlTextWriter(sw);
                            hw.WriteLine("<h1 style=\"text-align:center;\">NGO Details</h1>");
                            hw.WriteLine("<br>");
                            //To Export all pages

                            gvforVillages.AllowPaging = false;
                            BindNGOById();
                            //  gvforVillages.HeaderRow.BackColor = System.Drawing.Color.Black;
                            this.gvforVillages.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            this.gvforVillages.HeaderStyle.BackColor = System.Drawing.Color.Green;

                            foreach (TableCell cell in gvforVillages.HeaderRow.Cells)
                            {
                                cell.BackColor = gvforVillages.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gvforVillages.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gvforVillages.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gvforVillages.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gvforVillages.RenderControl(hw);

                            //style to format numbers to string
                            string style = @"<style> .textmode { } </style>";
                            Response.Write(style);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }
}
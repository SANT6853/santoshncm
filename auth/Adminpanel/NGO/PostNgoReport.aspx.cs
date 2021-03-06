using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_NGO_PostNgoReport : CrsfBase
{
    NgoBal bal = new NgoBal();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            return;
        }

        try
        {

            if (!IsPostBack)
            {
                BtnPdfExport.Visible = false;
                BtnExcelExport.Visible = false;
                btnprint.Visible = false;
                if (Session["UserType"].ToString() == "1")
                {
                    BindTigerReserveName1();
                    if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                    {
                        BtnBackConsoldateReport.Visible = true;
                    }
                    else
                    {
                        BtnBackConsoldateReport.Visible = false;
                    }

                }
                if (Session["UserType"].ToString() == "2")
                {
                    bindngo();
                }
                if (Session["UserType"].ToString() == "3")
                {
                    bindngo();
                }
                if (Session["UserType"].ToString() == "4")
                {
                    BtnExcelExport.Visible = true;
                    bindngo();
                }


            }
        }
        catch (Exception e3)
        {
            // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
            return;
        }



    }
    void BindTigerReserveName1()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve wise searching-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select tiger reserve wise searching-", "0"));
            }



            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectreserve.SelectedValue == "0")
        {
            gvforngo.Visible = false;
        }
        else
        {
            gvforngo.Visible = true;
            bindngoNTCA();
        }

    }
    protected void gvforngo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvforngo.PageIndex = e.NewPageIndex;
        if (Session["UserType"].ToString() == "1")
        {
            bindngoNTCA();
        }
        if (Session["UserType"].ToString() == "2")
        {
            bindngo();
        }
        if (Session["UserType"].ToString() == "3")
        {
            bindngo();
        }
        if (Session["UserType"].ToString() == "4")
        {
            bindngo();
        }
        //  bindngo();
    }
    public void bindngo3()
    {
        DataSet ds = bal.Showrecord1();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforngo.DataSource = ds;
            ViewState["Data"] = ds;
            gvforngo.DataBind();
            BtnPdfExport.Visible = true;
            BtnExcelExport.Visible = true;
            btnprint.Visible = true;
        }
    }
    public void bindngo()
    {
        DataSet ds = bal.PostShowrecord1();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforngo.DataSource = ds;
            ViewState["Data"] = ds;
            gvforngo.DataBind();
            BtnPdfExport.Visible = true;
            BtnExcelExport.Visible = true;
            btnprint.Visible = true;
        }
    }
    public void bindngoNTCA()
    {
        DataSet ds = bal.PostShowrecord11(Convert.ToInt32(ddlselectreserve.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforngo.DataSource = ds;
            ViewState["Data"] = ds;
            gvforngo.DataBind();

            BtnPdfExport.Visible = true;
            BtnExcelExport.Visible = true;
            btnprint.Visible = true;
        }
        else
        {
            gvforngo.DataSource = null;
            gvforngo.DataBind();
            BtnPdfExport.Visible = false;
            BtnExcelExport.Visible = false;
            btnprint.Visible = false;
        }
    }
    protected void gvforngo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hd = e.Row.FindControl("hiden") as HiddenField;
            int id = Int32.Parse(hd.Value);
            GridView grd = (e.Row.FindControl("grdvillage")) as GridView;
            if (ddlselectreserve.SelectedValue != "0" && ddlselectreserve.SelectedValue != "")
            {
                ds = bal.ngo_associated_village(id, ddlselectreserve.SelectedItem.Text);
            }
            else
            {
                ds = bal.ngo_associated_village(id, null);
            }


            grd.DataSource = ds;
            grd.DataBind();

        }

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        printGrid();
    }
    void printGrid()
    {

        gvforngo.DataSource = ViewState["Data"];
        gvforngo.AllowPaging = false;
        gvforngo.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvforngo.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Sariska Tiger Reserve NGO Report ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:center'> ");
        //sb.Append(Label1.Text + "&nbsp;:&nbsp;" + Label2.Text + "&nbsp;|&nbsp;" + Label3.Text + "&nbsp;:&nbsp;" + Label4.Text);
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gvforngo.AllowPaging = true;
        gvforngo.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

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
                            hw.WriteLine("<h1 style=\"text-align:center;\">Ngo Report</h1>");
                            hw.WriteLine("<br>");
                            //To Export all pages //gvforngo

                            gvforngo.AllowPaging = false;
                            if (Session["UserType"].ToString() == "1")
                            {
                                BindTigerReserveName1();


                            }
                            if (Session["UserType"].ToString() == "2")
                            {
                                bindngo();
                            }
                            if (Session["UserType"].ToString() == "3")
                            {
                                bindngo();
                            }
                            if (Session["UserType"].ToString() == "4")
                            {
                                bindngo();
                            }

                            gvforngo.HeaderRow.BackColor = System.Drawing.Color.Green;
                            foreach (TableCell cell in gvforngo.HeaderRow.Cells)
                            {
                                cell.BackColor = gvforngo.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gvforngo.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gvforngo.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gvforngo.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gvforngo.RenderControl(hw);

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
        // }
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
                        hw.WriteLine("<h1 style=\"text-align:center;\">Ngo Report</h1>");
                        hw.WriteLine("<br>");
                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gvforngo.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gvforngo.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gvforngo.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gvforngo.AllowPaging = true;
                        gvforngo.DataBind();
                    }
                }
            }

        }
        catch
        {
            throw;
        }
        // }
    }
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
    }
}
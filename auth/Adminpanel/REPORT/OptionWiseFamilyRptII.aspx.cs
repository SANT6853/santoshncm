using System;
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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_REPORT_OptionWiseFamilyRptII : CrsfBase
{
    decimal grdTotal = 0, allotedamount = 0;
    int i = 0;
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = "OPTION WISE REPORT : NTCA";
            if (Session["User_Id"] == null)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            }


            BindfamilyByOptions();
        }
    }
    protected void gvForFamily_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTotal = 0;
        allotedamount = 0;
        i = 0;
        gvForFamily.PageIndex = e.NewPageIndex;
        BindfamilyByOptions();

    }
    protected void gvForFamily_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void BindfamilyByOptions()
    {

        try
        {
            string vil_id = Request.QueryString["V_ID"].ToString();
            string sch_id = Request.QueryString["S_id"].ToString();
            string res_id = Request.QueryString["R_ID"].ToString();
            if (Request.QueryString["Reservename"].ToString() != "NA")
            {
                ds = VillDB_Obj.Proc_DisplayFamilyByVillageSchme(vil_id, res_id, sch_id, Request.QueryString["Reservename"].ToString(), null);
            }
            else
            {
                ds = VillDB_Obj.Proc_DisplayFamilyByVillageSchme(vil_id, res_id, sch_id, null, null);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTotal = 0; allotedamount = 0; i = 0;
                btn_print.Visible = true;
                gvForFamily.Visible = true;
                gvForFamily.AllowPaging = true;
                gvForFamily.DataSource = ds.Tables[0].DefaultView;
                ViewState["Data"] = ds;
                grandtotalnew.Text = ds.Tables[0].Rows[0]["grandtotol"].ToString();
                gvForFamily.DataBind();
                GridveiwNumericColumnCalculation(ds);

                BtnPdfExport.Visible = true;
                BtnExcelExport.Visible = true;
                btn_print.Visible = true;
            }
            else
            {
                BtnPdfExport.Visible = false;
                BtnExcelExport.Visible = false;
                btn_print.Visible = false;


                gvForFamily.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                btn_print.Visible = false;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    void printGrid()
    {
        DataSet ds1 = ViewState["Data"] as DataSet;
        // GridView GridView1 = new GridView();
        gvForFamily.DataSource = ViewState["Data"];
        gvForFamily.AllowPaging = false;
        gvForFamily.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvForFamily.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div>");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Option wise Family Details ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:right; color:#743D02; font-weight:bold;'><font size=3px > ");
        //   sb.Append(" Grand Total : -  ");

        //   sb.Append(ds1.Tables[0].Rows[0]["grandtotol"].ToString());
        sb.Append("</font></div>");
        sb.Append("</div>");





        sb.Append(gridHTML);

        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        BindfamilyByOptions();
    }
    protected void btn_print_Click1(object sender, EventArgs e)
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
                        this.printGrid();

                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }


    protected void ImageButton1_Click(object sender, EventArgs e)
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
                        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/OptionWiseFamilyRpt.aspx"), false);
                    }
                }
            }

        }
        catch
        {
            throw;
        }
    }


public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["allotedamount"]);
            InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["installment"]);
            FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvForFamily.FooterRow.Cells[0].Text = "Total=" + sno.ToString();
        gvForFamily.FooterRow.Cells[0].Font.Bold = true;
        gvForFamily.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvForFamily.FooterRow.Cells[5].Text =  AllottedAmountRs.ToString();
        gvForFamily.FooterRow.Cells[5].Font.Bold = true;
        gvForFamily.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gvForFamily.FooterRow.Cells[6].Text =  InstallmentAmountRs.ToString();
        gvForFamily.FooterRow.Cells[6].Font.Bold = true;
        gvForFamily.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember
        gvForFamily.FooterRow.Cells[7].Text =  FamilyMember.ToString();
        gvForFamily.FooterRow.Cells[7].Font.Bold = true;
        gvForFamily.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    protected void BtnExcelExport_Click(object sender, EventArgs e)
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

                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {
                            HtmlTextWriter hw = new HtmlTextWriter(sw);
                            hw.WriteLine("<h1 style=\"text-align:center;\">Option wise Family Details</h1>");
                            hw.WriteLine("<br>");
                            //To Export all pages

                            gvForFamily.AllowPaging = false;

                            BindfamilyByOptions();
                            //gv_villageSearch.HeaderRow.BackColor = Color.Black;
                            this.gvForFamily.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            this.gvForFamily.HeaderStyle.BackColor = System.Drawing.Color.Red;
                            foreach (TableCell cell in gvForFamily.HeaderRow.Cells)
                            {
                                cell.BackColor = gvForFamily.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gvForFamily.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gvForFamily.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gvForFamily.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gvForFamily.RenderControl(hw);

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
    }


    protected void BtnPdfExport_Click(object sender, EventArgs e)
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
                        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">Option wise Family Details</h1>");
                        hw.WriteLine("<br>");
                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gvForFamily.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gvForFamily.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gvForFamily.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();

                        gvForFamily.AllowPaging = true;
                        gvForFamily.DataBind();
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
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
}
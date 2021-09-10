using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NCM.DAL;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_perticularreportprint : CrsfBase
{
    NgoBal bal = new NgoBal();
    static string village;
    public static bool RecordChk = false;
    public static decimal Installment;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }

        if (!IsPostBack)
        {
            village = Request.QueryString["villageid"].ToString();
            villagedeatil();
            if (RecordChk == false)
            {
                lblmsg.Text = "NO RECORD FOUND!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Font.Bold = true;
                lblmsg.Font.Size = 12;
            }

        }
    }

    public void villagedeatil()
    {
        DataSet ds = new DataSet();
        int id = Int32.Parse(village);
        if (Request.QueryString["Resv"] != "NA")
        {
            ds = bal.select_village_record(id, Request.QueryString["Resv"].ToString());
        }
        else
        {
            ds = bal.select_village_record(id, null);
        }
        if (id != 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                RecordChk = true;
                lblvillagecode.Text = ds.Tables[0].Rows[0]["VILL_CD"].ToString();
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                lblpopulation.Text = ds.Tables[0].Rows[0]["VILL_POPU"].ToString();
                lbltotalland.Text = ds.Tables[0].Rows[0]["VILL_TOT_LND_AREA"].ToString();
                lblagriculture.Text = ds.Tables[0].Rows[0]["VILL_TOT_AGRI_LND_AREA"].ToString();
                lblnonagricultureland.Text = ds.Tables[0].Rows[0]["VILL_TOT_NON_AGRI_LND_AREA"].ToString();
                lblotherland.Text = ds.Tables[0].Rows[0]["VILL_OTHER_LND_AREA"].ToString();
                lblfemail.Text = ds.Tables[0].Rows[0]["VILL_FEMALE"].ToString();
                lblmail.Text = ds.Tables[0].Rows[0]["VILL_MALE"].ToString();
                lblcowbuffelo.Text = ds.Tables[0].Rows[0]["VILL_TOT_CNB"].ToString();
                lblsheepgot.Text = ds.Tables[0].Rows[0]["VILL_TOT_SNG"].ToString();
                lbltotallivestock.Text = ds.Tables[0].Rows[0]["VILL_NO_LIV_STOK"].ToString();
                lblsc.Text = ds.Tables[0].Rows[0]["VILL_TOT_SC"].ToString();
                lblst.Text = ds.Tables[0].Rows[0]["VILL_TOT_ST"].ToString();
                lblobc.Text = ds.Tables[0].Rows[0]["VILL_TOT_OBC"].ToString();
                lblother.Text = ds.Tables[0].Rows[0]["VILL_TOT_OTH"].ToString();
                lbllandvaluofagriculture.Text = ds.Tables[0].Rows[0]["VILL_VAL_AGRI"].ToString();
                lblvalueresidentialland.Text = ds.Tables[0].Rows[0]["VILL_VAL_RES"].ToString();



                //Hyperlink.NavigateUrl = ResolveUrl("~/AUTH/TIGERRESERVEADMIN/REPORT/View_NGO_Details.aspx?V_ID= " + ds.Tables[0].Rows[0]["vill_id"].ToString() + " "); 
                if (ds.Tables[0].Rows[0]["VILL_STAT"].ToString() == "1")
                {
                    lblstatus.Text = "Relocated";
                }
                if (ds.Tables[0].Rows[0]["VILL_STAT"].ToString() == "2")
                {
                    lblstatus.Text = "Non-Relocated";
                }
                if (ds.Tables[0].Rows[0]["VILL_STAT"].ToString() == "3")
                {
                    lblstatus.Text = "In Progress";
                }
                //lblstatus.Text = ds.Tables[0].Rows[0]["VILL_STAT"].ToString();
                // lblngo.Text = ds.Tables[0].Rows[0]["nongo"].ToString();
                panel.Visible = true;
                BindNGOById();
                btnprint.Visible = true;
            }
            else
            {
                btnprint.Visible = false;
                RecordChk = false;
                lblmsg.Text = "Legal Form was not filled";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                panel.Visible = false;
            }
        }

    }
    public void BindNGOById()
    {
        NgoDB ngo = new NgoDB();
        DataSet ds = new DataSet();
        ds = NgoDal.village_ngo_deatil(Int32.Parse(village));
        //ds = ngo.Proc_DisplayNGODetail(village);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.Visible = true;
            gvforVillages.DataSource = ds;
            //ViewState["Data"] = ds;
            gvforVillages.DataBind();
            GridveiwNumericColumnCalculation_BindNGOById(ds);
            BtnNgoExcel.Visible = true;
            BtnNgoExcel.Visible = true;
            BtnPdfExport.Visible = true;
        }
        else
        {
            BtnNgoExcel.Visible = false;
            BtnPdfExport.Visible = false;

            BtnNgoExcel.Visible = false;
            gvforVillages.DataSource = null;
            //ViewState["Data"] = ds;
            gvforVillages.DataBind();
        }
        bindfamilydeatil();
    }
    public void GridveiwNumericColumnCalculation_BindNGOById(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        // decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["amount"]);
            //InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvforVillages.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gvforVillages.FooterRow.Cells[0].Font.Bold = true;
        gvforVillages.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvforVillages.FooterRow.Cells[2].Text = Total + AllottedAmountRs.ToString();
        gvforVillages.FooterRow.Cells[2].Font.Bold = true;
        gvforVillages.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        //gvforVillages.FooterRow.Cells[3].Text = Total + InstallmentAmountRs.ToString();
        //gvforVillages.FooterRow.Cells[3].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    public void GridveiwNumericColumnCalculation_bindfamilydeatil(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["alloted_amount"]);
            // InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["INST_ISCM_AMT"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvforngo.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gvforngo.FooterRow.Cells[0].Font.Bold = true;
        gvforngo.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvforngo.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvforngo.FooterRow.Cells[7].Text = Total + AllottedAmountRs.ToString();
        gvforngo.FooterRow.Cells[7].Font.Bold = true;
        gvforngo.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gvforngo.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        //gvforVillages.FooterRow.Cells[8].Text = "Total Installment=" + InstallmentAmountRs.ToString();
        //gvforVillages.FooterRow.Cells[8].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    protected void gvforngo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvforngo.PageIndex = e.NewPageIndex;
        bindfamilydeatil();


    }
    protected void gvforngo_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    public void bindfamilydeatil()
    {
        int id = Int32.Parse(village);
        if (id != 0)
        {
            DataSet ds = bal.select_village_family(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforngo.DataSource = ds;
                gvforngo.DataBind();
                panel.Visible = true;
                lblmsg.Text = "";
                GridveiwNumericColumnCalculation_bindfamilydeatil(ds);
                BtnFamilYmember.Visible = true;
                BtnFamilYmember.Visible = true;
                Button1.Visible = true;
            }
            else
            {
                BtnFamilYmember.Visible = false;
                Button1.Visible = false;

                BtnFamilYmember.Visible = false;
                lblmsg.Text = "Legal Form was not filled";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                gvforngo.DataSource = null;
                gvforngo.DataBind();
                panel.Visible = false;

            }
        }

    }
    protected void gvforngo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #c3cecc";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FamilyDB FDB = new FamilyDB();
            HiddenField hd = e.Row.FindControl("hidenfid") as HiddenField;
            string id = hd.Value;
            GridView grd = (e.Row.FindControl("grvfamilydeatil")) as GridView;
            DataSet ds = FDB.Proc_DisplayFamilyMemberDetail(id);
            grd.DataSource = ds;
            grd.DataBind();
            GridView grdI = (e.Row.FindControl("gv1B")) as GridView;
            DataSet dsI = FDB.display_instalment_deatil(id);
            grdI.DataSource = dsI;

            grdI.DataBind();
        }



    }
    protected void gv1B_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        decimal InstallmentAmountRs = 0;
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #c3cecc";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hd = e.Row.FindControl("hidenIfid1") as HiddenField;
            FamilyDB FDB = new FamilyDB();
            Repeater rp = (e.Row.FindControl("Repeterinstallment")) as Repeater;

            DataSet ds = FDB.display_instalment_amount(hd.Value);
            rp.DataSource = ds;
            rp.DataBind();

            //int FamilyMember = 0;
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //   // sno = ds.Tables[0].Rows.Count;
            //    InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["INST_ISCM_AMT"]);
            //    // InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["INST_ISCM_AMT"]);
            //    // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
            //}
            //Installment += InstallmentAmountRs;
            //Response.Write(Installment);
        }


    }
    protected void grvfamilydeatil_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #c3cecc";
        }


    }
    protected void btnprint_Click(object sender, EventArgs e)
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

                        gvforngo.AllowPaging = false;
                        printGrid();
                        gvforngo.AllowPaging = true;
                        villagedeatil();
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }

    void printGrid()
    {
        // GridViewgv_villageSearch = new GridView();
        gvforngo.AllowPaging = false;

        villagedeatil();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        panel.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Particular Village Report ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:center'> ");
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        //gv_villageSearch1.DataBind();


    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void btnback_Click(object sender, EventArgs e)
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

                        Response.Redirect("perticular_village_report.aspx");
                    }
                }

            }
        }
        catch
        {
            throw;
        }
    }

    protected void BtnFamilYmember_Click(object sender, EventArgs e)
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

                            //To Export all pages

                            hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
                            hw.WriteLine("<br>");

                            gvforngo.AllowPaging = false;

                            villagedeatil();
                            //gv_villageSearch.HeaderRow.BackColor = Color.Black;
                            this.gvforVillages.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            this.gvforVillages.HeaderStyle.BackColor = System.Drawing.Color.Red;
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
    }

    protected void BtnNgoExcel_Click(object sender, EventArgs e)
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

                            //To Export all pages

                            hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
                            hw.WriteLine("<br>");

                            gvforVillages.AllowPaging = false;

                            villagedeatil();
                            //gv_villageSearch.HeaderRow.BackColor = Color.Black;
                            this.gvforVillages.HeaderStyle.ForeColor = System.Drawing.Color.White;
                            this.gvforVillages.HeaderStyle.BackColor = System.Drawing.Color.Red;
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

                        hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
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
    }
    protected void Button1_Click(object sender, EventArgs e)
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

                        hw.WriteLine("<h1 style=\"text-align:center;\">Particular Village Report</h1>");
                        hw.WriteLine("<br>");


                        //gvforngo.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        //gvforngo.HeaderStyle.BackColor = System.Drawing.Color.Green;
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
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
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

public partial class auth_Adminpanel_REPORT_CDP_NgoListDetails : CrsfBase
{
    public string Village_id = "";
    DataSet ds = new DataSet();
    FamilyDB obj = new FamilyDB();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    VillageDB VillDB_Obj = new VillageDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "CDP REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }


        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            LblNgoName.Text = Request.QueryString["NgoName"].ToString();
            if (Session["UserType"].ToString() == "1")
            {
               
                btn_print.Visible = false;

                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {
                    BtnBackConsoldateReport.Visible = true;
                }
                else
                {
                    BtnBackConsoldateReport.Visible = false;
                }
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {//Request.QueryString["ConsoldateStateName"].ToString();
                    //DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                   // DdlStateName_SelectedIndexChanged(this, EventArgs.Empty);
                    Bind();
                }
                else
                {
                    Bind();
                }
            }
            //if (Session["UserType"].ToString() == "2")
            //{
            //   // Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
            //    btn_print.Visible = false;
            //    Bind();
            //}
            //if (Session["UserType"].ToString() == "3")
            //{
            //   /// Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
            //    btn_print.Visible = false;
            //    Bind();
            //}
            //if (Session["UserType"].ToString() == "4")
            //{

            //   // FillVillage();
            //    btn_print.Visible = false;
            //    Bind();
            //}

        }
    }
   
    protected void Bind()
    {
        string villid = Request.QueryString["villid"].ToString();
        string tigerReserveName = Request.QueryString["Resv"].ToString();
        string NgoName = Request.QueryString["F_ID"].ToString();
        ds = obj.NgoListDetails(null, null, NgoName);
        
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                line.Visible = true;
                btn_print.Visible = true;
                gvwork.Visible = true;
                gvwork.DataSource = ds.Tables[0];
                ViewState["Data"] = ds;
                gvwork.DataBind();
                Label1.Text = "Total Amount Allotted :";
                Label2.Text = "";
               // lblamttotal.Text = ds.Tables[1].Rows[0]["amount"].ToString();
                double amountused = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    amountused = amountused + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"]);

                }
                lblamtused.Text = "Total Amount:" + amountused.ToString();

                GridveiwNumericColumnCalculation(ds);
                BtnExcelExport.Visible = true;

                BtnExcelExport.Visible = true;
                BtnPdfExport.Visible = true;
                btn_print.Visible = true;
            }
            else
            {//gvwork.Visible = true;
                BtnExcelExport.Visible = false;
                BtnPdfExport.Visible = false;
                btn_print.Visible = false;

                BtnExcelExport.Visible = false;
                btn_print.Visible = false;
                gvwork.Visible = false;
                Label1.Text = "";
                Label2.Text = "";
                lblamttotal.Text = "";
                line.Visible = false;
                lblamtused.Text = "";
                lblMsg.Text = "No Record Found";

                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            btn_print.Visible = false;
            gvwork.Visible = false;
            lblMsg.Text = "No Record Found";

            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    
    protected void btn_print_Click(object sender, EventArgs e)
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

                        // btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
                        printGrid();
                        if (Session["UserType"].ToString() == "1")
                        {
                            //BindTigerReserveName1();
                            //  Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                            btn_print.Visible = false;
                            Bind();
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


    protected void gvwork_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwork.PageIndex = e.NewPageIndex;
        Bind();
    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gvwork.DataSource = ViewState["Data"];
        gvwork.AllowPaging = false;
        gvwork.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvwork.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" CDP Report for a Village ");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("<div>");
        //  sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Label1.Text + "&nbsp; &nbsp;");
        //  sb.Append("<strong>" + lblamttotal.Text + "</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        // sb.Append(Label2.Text + "&nbsp; &nbsp;");
        // sb.Append("<strong>" + lblamtused.Text + "</strong>");


        sb.Append("</div>");
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gvwork.AllowPaging = true;
        gvwork.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["amount"]);
           // InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvwork.FooterRow.Cells[0].Text = "Total =" + sno.ToString();
        gvwork.FooterRow.Cells[0].Font.Bold = true;
        gvwork.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvwork.FooterRow.Cells[4].Text = Total + AllottedAmountRs.ToString();
        gvwork.FooterRow.Cells[4].Font.Bold = true;
        gvwork.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        //gvwork.FooterRow.Cells[5].Text = Total + InstallmentAmountRs.ToString();
        //gvwork.FooterRow.Cells[5].Font.Bold = true;
        //gvwork.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        //gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

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
                            hw.WriteLine("<h1 style=\"text-align:center;\">Work done for village by </h1>" + LblNgoName.Text);
                            hw.WriteLine("<br>");
                            //To Export all pages

                            gvwork.AllowPaging = false;
                            Bind();
                            gvwork.HeaderRow.BackColor = System.Drawing.Color.Black;
                            foreach (TableCell cell in gvwork.HeaderRow.Cells)
                            {
                                cell.BackColor = gvwork.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gvwork.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gvwork.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gvwork.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gvwork.RenderControl(hw);

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


                        //  Response.ContentType = "application/pdf";
                        //  Response.AddHeader("content-disposition", "attachment;filename=Village-Wise Report.pdf");
                        //  Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //  StringWriter sw = new StringWriter();
                        //  HtmlTextWriter hw = new HtmlTextWriter(sw);

                        //  hw.WriteLine("<h1 style=\"text-align:center;\">Village-Wise Report</h1>");
                        //  hw.WriteLine("<br>");

                        //  gvwork.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        //  gvwork.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        //  gvwork.RenderControl(hw);
                        //  StringReader sr = new StringReader(sw.ToString());
                        //  Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        //  HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        //  PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        //  pdfDoc.Open();
                        //  htmlparser.Parse(sr);
                        //  pdfDoc.Close();
                        //  Response.Write(pdfDoc);
                        ////  gvwork.AllowPaging = true;
                        //  Response.End();
                        //  gvwork.AllowPaging = true;

                        //  gvwork.DataBind();
                        //  gvwork.Visible = false;
                        using (StringWriter sw = new StringWriter())
                        {
                            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                            {
                                hw.WriteLine("<h1 style=\"text-align:center;\">Work done for village by </h1>" + LblNgoName.Text);
                                hw.WriteLine("<br>");
                                //To Export all pages
                                gvwork.AllowPaging = false;
                                //  this.BindGrid();
                                if (Session["UserType"].ToString() == "1")
                                {
                                    //  BindStateName();
                                    //  BindTigerReserveName1();
                                    // Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                                    // btn_print.Visible = false;
                                    this.Bind();
                                }
                                if (Session["UserType"].ToString() == "2")
                                {
                                    // Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                                    // btn_print.Visible = false;
                                    this.Bind();
                                }
                                if (Session["UserType"].ToString() == "3")
                                {
                                    // Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                                    // btn_print.Visible = false;
                                    this.Bind();
                                }
                                if (Session["UserType"].ToString() == "4")
                                {

                                    ///  FillVillage();
                                    //  btn_print.Visible = false;
                                    this.Bind();
                                }
                                gvwork.HeaderStyle.ForeColor = System.Drawing.Color.White;
                                gvwork.HeaderStyle.BackColor = System.Drawing.Color.Green;
                                gvwork.RenderControl(hw);
                                StringReader sr = new StringReader(sw.ToString());
                                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                                pdfDoc.Open();
                                htmlparser.Parse(sr);
                                pdfDoc.Close();

                                Response.ContentType = "application/pdf";
                                Response.AddHeader("content-disposition", "attachment;filename=WorkDoneForVillage.pdf");
                                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                Response.Write(pdfDoc);
                                Response.End();
                            }
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

    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
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

                        string sUrlConsoldateStateName = Request.QueryString["ConsoldateStateName"].ToString();
                        string sUrlConsoldateMode = Request.QueryString["ConsoldateMode"].ToString();
                        string sUrlReserveID = Request.QueryString["ReserveID"].ToString();
                        string sUrlVillageID = Request.QueryString["VillageID"].ToString();
                        string sUrlStateID = Request.QueryString["StateID"].ToString();
                        string sUrlVillageName = Request.QueryString["VillageName"].ToString();
                        string sUrlReserveName = Request.QueryString["ReserveName"].ToString();
                        Response.Redirect("~/AUTH/adminpanel/REPORT/NgoListConsol.aspx?&ConsoldateStateName=" + sUrlConsoldateStateName + "&ConsoldateMode=" + sUrlConsoldateMode + "&ReserveID=" + sUrlReserveID + "&VillageID=" + sUrlVillageID + "&StateID=" + sUrlStateID + "&VillageName=" + sUrlVillageName + "&ReserveName=" + sUrlVillageName);
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
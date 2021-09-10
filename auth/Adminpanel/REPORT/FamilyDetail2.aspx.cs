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

public partial class auth_Adminpanel_REPORT_FamilyDetail2 : CrsfBase
{
    VillageDB vdb = new VillageDB();
    CommonDB COMMDB_Obj = new CommonDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "FAMILY DETAILS REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("4"))
            {
                if (Request.QueryString["V_ID"] != null)
                {
                    if (Request.QueryString["V_ID"].ToString() != "")
                    {
                        FillAll();
                        displayFamily();
                    }
                }
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                if (Request.QueryString["V_ID"] != null)
                {
                    if (Request.QueryString["V_ID"].ToString() != "")
                    {
                        FillAll2();
                        displayFamily();
                    }
                }
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                if (Request.QueryString["V_ID"] != null)
                {
                    if (Request.QueryString["V_ID"].ToString() != "")
                    {
                        FillAll2();
                        displayFamily2();
                    }
                }
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                if (Request.QueryString["V_ID"] != null)
                {
                    if (Request.QueryString["V_ID"].ToString() != "")
                    {
                        FillAll2();
                        displayFamily2();
                    }
                }
            }

        }

    }
    public void FillAll()
    {
        DataSet ds = vdb.Get_OthersIDs_By_VillId(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvillcode.Text = ds.Tables[0].Rows[0][0].ToString();
            lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
            DataSet ds1 = COMMDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(Session["sStateID"].ToString(), ds.Tables[0].Rows[0][4].ToString(), Session["sTigerReserveid"].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblstatename.Text = Session["sStateName"].ToString();
                lbldistrict.Text = ds1.Tables[1].Rows[0][0].ToString();
                lblreaserve.Text = Session["sTigerReserveName"].ToString();
                lbltehsil.Text = ds1.Tables[2].Rows[0][0].ToString();
                lblgp.Text = ds1.Tables[3].Rows[0][0].ToString();
                // reservecode = ds1.Tables[2].Rows[0][1].ToString();



            }

        }
    }
    public void FillAll2()
    {
        DataSet ds = vdb.Get_OthersIDs_By_VillId(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvillcode.Text = ds.Tables[0].Rows[0][0].ToString();
            lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
            DataSet ds1 = COMMDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0]["CmnStateID"].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblstatename.Text = ds1.Tables[0].Rows[0]["ST_NAME"].ToString();//Session["sStateName"].ToString();
                lbldistrict.Text = ds1.Tables[1].Rows[0][0].ToString();
                lblreaserve.Text = ds1.Tables[4].Rows[0]["TigerReserveName"].ToString();//Session["sTigerReserveName"].ToString();
                lbltehsil.Text = ds1.Tables[2].Rows[0][0].ToString();
                lblgp.Text = ds1.Tables[3].Rows[0][0].ToString();
                // reservecode = ds1.Tables[2].Rows[0][1].ToString();

            }

        }
    }
    public void displayFamily()
    {

        DataSet ds = vdb.Proc_DisplayFamilyByVillage(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_FamilySearch.Visible = true;
            btn_print.Visible = true;
            lblnodatafound.Text = "";
            gv_FamilySearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_FamilySearch.DataBind();
            GridveiwNumericColumnCalculation(ds);
            BtnExcelExport.Visible = true;
        }
        else
        {
            btn_print.Visible = false;
            BtnExcelExport.Visible = false;
            gv_FamilySearch.Visible = false;
            lblnodatafound.Text = "No Record Found";

        }



    }
    public void displayFamily2()
    {

        DataSet ds = vdb.Proc_DisplayFamilyByVillage(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_FamilySearch.Visible = true;
            btn_print.Visible = true;
            lblnodatafound.Text = "";
            gv_FamilySearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_FamilySearch.DataBind();
            GridveiwNumericColumnCalculation(ds);
        }
        else
        {
            btn_print.Visible = false;

            gv_FamilySearch.Visible = false;
            lblnodatafound.Text = "No Record Found";

        }



    }
    protected void gv_FamilySearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_FamilySearch.PageIndex = e.NewPageIndex;
        displayFamily();
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
                        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/VillageSearch.aspx?"));
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

    }

    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["installment"]);
            InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["installment"]);
            FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gv_FamilySearch.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_FamilySearch.FooterRow.Cells[0].Font.Bold = true;
        gv_FamilySearch.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilySearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gv_FamilySearch.FooterRow.Cells[4].Text = Total + AllottedAmountRs.ToString();
        gv_FamilySearch.FooterRow.Cells[4].Font.Bold = true;
        gv_FamilySearch.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilySearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gv_FamilySearch.FooterRow.Cells[5].Text = Total + InstallmentAmountRs.ToString();
        gv_FamilySearch.FooterRow.Cells[5].Font.Bold = true;
        gv_FamilySearch.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilySearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember
        gv_FamilySearch.FooterRow.Cells[7].Text = Total + FamilyMember.ToString();
        gv_FamilySearch.FooterRow.Cells[7].Font.Bold = true;
        gv_FamilySearch.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilySearch.FooterRow.BackColor = System.Drawing.Color.Beige;
    }

    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gv_FamilySearch.DataSource = ViewState["Data"];
        gv_FamilySearch.AllowPaging = false;
        gv_FamilySearch.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);


        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_FamilySearch.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");

        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append("Village Relocation Family Data ");
        sb.Append("</font></div>");
        sb.Append("<div>");
        sb.Append("-------------------------------------------------------------------------------------------------------------------");
        sb.Append("-----------------------------------------------");
        sb.Append("</div>");
        sb.Append("<div>");

        //sb.Append("<ul>");
        //sb.Append("<li>");
        sb.Append("State :&nbsp;" + lblstatename.Text);
        //sb.Append("</li>");
        //sb.Append("<li>");
        sb.Append("&nbsp; | &nbsp; Reserve :&nbsp;" + lblreaserve.Text);
        sb.Append("&nbsp;  | &nbsp;District :&nbsp;" + lblreaserve.Text);
        sb.Append("&nbsp;  | &nbsp;Tehsil :&nbsp;" + lbltehsil.Text);
        sb.Append("&nbsp;  | &nbsp;Grampanchayat :&nbsp;" + lblgp.Text);
        sb.Append("&nbsp;  | &nbsp;Village :&nbsp;" + lblvillname.Text);
        sb.Append("&nbsp;  | &nbsp;Village Code :&nbsp;" + lblvillcode.Text);
        //sb.Append("</li>");
        //sb.Append("</ul>");

        sb.Append("</div>");
        sb.Append("<div>");
        sb.Append("-------------------------------------------------------------------------------------------------------------------");
        sb.Append("-----------------------------------------------");
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();weindow.reload();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_FamilySearch.AllowPaging = true;
        gv_FamilySearch.DataBind();
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
                        if (Session["UserType"].ToString().Equals("4"))
                        {
                            if (Request.QueryString["V_ID"] != null)
                            {
                                if (Request.QueryString["V_ID"].ToString() != "")
                                {
                                    FillAll();
                                    displayFamily();
                                }
                            }
                        }
                        if (Session["UserType"].ToString().Equals("3"))
                        {
                            if (Request.QueryString["V_ID"] != null)
                            {
                                if (Request.QueryString["V_ID"].ToString() != "")
                                {
                                    FillAll2();
                                    displayFamily();
                                }
                            }
                        }
                        if (Session["UserType"].ToString().Equals("2"))
                        {
                            if (Request.QueryString["V_ID"] != null)
                            {
                                if (Request.QueryString["V_ID"].ToString() != "")
                                {
                                    FillAll2();
                                    displayFamily2();
                                }
                            }
                        }
                        if (Session["UserType"].ToString().Equals("1"))
                        {
                            if (Request.QueryString["V_ID"] != null)
                            {
                                if (Request.QueryString["V_ID"].ToString() != "")
                                {
                                    FillAll2();
                                    displayFamily2();
                                }
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void gv_FamilySearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink hyper = e.Row.FindControl("HyperLink1") as HyperLink;
            if (hyper.Text.Equals("0"))
            {
                hyper.NavigateUrl = "#";
                hyper.Attributes.Add("target", "");

                hyper.Text = "No Record";
            }
        }
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

                        int GrdRowCount = gv_FamilySearch.Rows.Count;
                        if (GrdRowCount != 0)
                        {
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                            Response.Charset = "UTF-8";
                            Response.ContentType = "application/vnd.ms-excel";
                            using (StringWriter sw = new StringWriter())
                            {
                                HtmlTextWriter hw = new HtmlTextWriter(sw);


                                gv_FamilySearch.Caption = "<h3 style='color:green;'>State:" + "&nbsp;" + lblstatename.Text + "&nbsp;&nbsp;,District:&nbsp;" + lbldistrict.Text + "&nbsp;,Grampanchayat :" + "&nbsp;" + lblgp.Text + "&nbsp;&nbsp;,Village Code:&nbsp;" + lblvillcode.Text + "&nbsp;,Reserve name:" + "&nbsp;" + lblreaserve.Text + "&nbsp;&nbsp;,Tehsil :&nbsp;" + lbltehsil.Text + "&nbsp;,Village :" + "&nbsp;" + lblvillname.Text + "</h3>";

                                //To Export all pages

                                gv_FamilySearch.AllowPaging = false;
                                displayFamily();
                                gv_FamilySearch.HeaderRow.BackColor = System.Drawing.Color.Black;
                                foreach (TableCell cell in gv_FamilySearch.HeaderRow.Cells)
                                {
                                    cell.BackColor = gv_FamilySearch.HeaderStyle.BackColor;
                                }
                                foreach (GridViewRow row in gv_FamilySearch.Rows)
                                {
                                    row.BackColor = System.Drawing.Color.White;
                                    foreach (TableCell cell in row.Cells)
                                    {
                                        if (row.RowIndex % 2 == 0)
                                        {
                                            cell.BackColor = gv_FamilySearch.AlternatingRowStyle.BackColor;
                                        }
                                        else
                                        {
                                            cell.BackColor = gv_FamilySearch.RowStyle.BackColor;
                                        }
                                        cell.CssClass = "textmode";
                                    }
                                }

                                gv_FamilySearch.RenderControl(hw);


                                //style to format numbers to string
                                //string style = @"<h2 style='color:green;'>Receipt & Challan Report From:" + " &nbsp;" + lblstatename.Text + "&nbsp;&nbsp; To&nbsp;" + lbldistrict.Text + "</h2>" + "</br>" + "<h2 style='color:green;'>Receipt & Challan Report From:" + " &nbsp;" + lblstatename.Text + "&nbsp;&nbsp; To&nbsp;" + lbldistrict.Text + "</h2>";
                                string style = @"<style> .textmode { } </style>";
                                Response.Write(style);
                                Response.Output.Write(sw.ToString());
                                Response.Flush();
                                Response.End();
                            }

                        }
                        else
                        {
                            lblnodatafound.Text = "No Data Found to Download!";
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
                        ExportGridToPDF();
                    }
                }

            }
        
        }
        catch
        {
            throw;
        }
    }

    private void ExportGridToPDF()
    {
        lblnodatafound.Text = string.Empty;
         int GrdRowCount = gv_FamilySearch.Rows.Count;
         if (GrdRowCount != 0)
         {
             Response.ContentType = "application/pdf";
             Response.AddHeader("content-disposition", "attachment;filename=Village Relocation Family Data.pdf");
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
             StringWriter sw = new StringWriter();
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             hw.WriteLine("<h1 style=\"text-align:center;\">Village Relocation Family Data</h1>");
             hw.WriteLine("<br>");
             //-------------------


             //---------------------------------------

             gv_FamilySearch.HeaderStyle.ForeColor = System.Drawing.Color.White;
             gv_FamilySearch.HeaderStyle.BackColor = System.Drawing.Color.Green;
             gv_FamilySearch.RenderControl(hw);
             gv_FamilySearch.Caption = "<h3 style='color:green;'>State:" + "&nbsp;" + lblstatename.Text + "&nbsp;&nbsp;,District:&nbsp;" + lbldistrict.Text + "&nbsp;,Grampanchayat :" + "&nbsp;" + lblgp.Text + "&nbsp;&nbsp;,Village Code:&nbsp;" + lblvillcode.Text + "&nbsp;,Reserve name:" + "&nbsp;" + lblreaserve.Text + "&nbsp;&nbsp;,Tehsil :&nbsp;" + lbltehsil.Text + "&nbsp;,Village :" + "&nbsp;" + lblvillname.Text + "</h3>";
             StringReader sr = new StringReader(sw.ToString());
             Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
             HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
             PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
             pdfDoc.Open();
             htmlparser.Parse(sr);
             pdfDoc.Close();
             Response.Write(pdfDoc);
             Response.End();
             gv_FamilySearch.AllowPaging = true;
             gv_FamilySearch.DataBind();
         }
        else
         {
             lblnodatafound.Text = "No Data Found to Download!";
         }
    }
}
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
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_REPORT_RelocationMapGoogle : CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        // lblnodatafound.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["IndexMode"] == null)
            {
                Session["sPageIndex"] = Session["sPageIndex"].ToString();
            }
            else
            {
                Session["sPageIndex"] = Request.QueryString["IndexMode"].ToString();
            }

            if (Session["UserType"].ToString().Equals("1"))
            {
                //BindStateName();
                //  BindTigerReserveName1();
                Page.Title = "VILLAGES REPORT :NTCA";
                // displayVillage1();
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {
                    if (string.IsNullOrEmpty(Session["ssReserveName"] as string))
                    {
                        Session["ssReserveName"] = Request.QueryString["ReserveName"].ToString();
                        Session["ssReserveID"] = Request.QueryString["ReserveID"].ToString();
                        Session["ssVillageName"] = Request.QueryString["VillageName"].ToString();
                        Session["ssVillageID"] = Request.QueryString["VillageID"].ToString();

                        Session["ssStateID"] = Request.QueryString["StateID"].ToString();
                        Session["ssConsoldateMode"] = Request.QueryString["ConsoldateMode"].ToString();


                        LblMsgTigerReserveName.Text = Session["ssReserveName"].ToString();
                        LblMsgTigerReserveValue.Text = Session["ssReserveID"].ToString();
                        LblMsgVillageName.Text = Session["ssVillageName"].ToString();
                        LblMsgVillageValue.Text = Session["ssVillageID"].ToString();

                       

                    }
                    else
                    {
                        LblMsgTigerReserveName.Text = Session["ssReserveName"].ToString();
                        LblMsgTigerReserveValue.Text = Session["ssReserveID"].ToString();
                        LblMsgVillageName.Text = Session["ssVillageName"].ToString();
                        LblMsgVillageValue.Text = Session["ssVillageID"].ToString();
                    }
                    //Request.QueryString["ConsoldateStateName"].ToString();
                    BindStateNameConsolDate();
                    displayVillage1();
     
                        //FillReserve();
                       
                        gv_villageSearch1.Visible = false;
                 
                }
                else
                {

                }
            }
        }
    }
    public void displayVillage1()
    {
        DataSet ds = new DataSet();

        ds = RDb.DsVillageMapGoogle(Request.QueryString["StateID"].ToString(), null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();

            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            //---------------
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);

            BtnExcelExport.Visible = true;
            BtnPdfExport.Visible = true;
            BtnPrintAll.Visible = true;
            btn_print.Visible = true;
        }
        else
        {

            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            btn_print.Visible = false;
            BtnPrintAll.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillageSearch1()
    {
        DataSet ds = new DataSet();
        string TigerReseveIDParameters = string.Empty;
        string VillId = string.Empty;
        if (LblMsgTigerReserveValue.Text == "You have not selected.")
        {
            TigerReseveIDParameters = null;
        }
        else
        {
            TigerReseveIDParameters = LblMsgTigerReserveValue.Text.Trim();
        }
        if (LblMsgVillageValue.Text == "You have not selected.")
        {
            VillId = null;
        }
        else
        {
            VillId = LblMsgVillageValue.Text.Trim();
        }
        ds = RDb.DsVillageMapGoogle(Request.QueryString["StateID"].ToString(), TigerReseveIDParameters, VillId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();

            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            //---------------
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);

            BtnExcelExport.Visible = true;
            BtnPdfExport.Visible = true;
            BtnPrintAll.Visible = true;
            btn_print.Visible = true;
        }
        else
        {

            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            btn_print.Visible = false;
            BtnPrintAll.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    void BindStateNameConsolDate()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        _objNtcauser.StateIDParameters = Request.QueryString["StateID"].ToString();

        P_var.dSet = _commanfuction.GetStateNameConsoldate(_objNtcauser);

        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            LblMsgStateName.Text = P_var.dSet.Tables[0].Rows[0]["StateName"].ToString();
        }
        BindTigerReserveOnBasisStateID(Request.QueryString["StateID"].ToString());

    }
    void BindTigerReserveOnBasisStateID(string StateId)
    {
        ErrorChkTigerReserveName.Text = "";
        try
        {

            if (StateId != null)
            {
                DdlTigerReserve.Items.Clear();
                DataSet ds = new VillageDB().DsConsoldateBindTigerReserve(StateId);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DdlTigerReserve.DataSource = ds.Tables[0];
                    DdlTigerReserve.DataTextField = "TigerReserveName";
                    DdlTigerReserve.DataValueField = "TigerReserveid";
                    DdlTigerReserve.DataBind();

                    //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
                }
                else
                {

                    DdlTigerReserve.Items.Clear();
                    ErrorChkTigerReserveName.Text = "--No Record Found--";
                    // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
                }
            }
            else
            {
                StateId = null;
            }


        }
        catch (Exception er)
        {
        }
    }
    protected void DdlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        LblMsgTigerReserveName.Text = string.Empty;
        LblMsgTigerReserveValue.Text = string.Empty;
        string ReserveID = string.Empty;
        string ReserveName = string.Empty;

        List<String> ReserveID_list = new List<string>();
        List<String> ReserveName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in DdlTigerReserve.Items)
        {
            if (item.Selected)
            {
                ReserveID_list.Add(item.Value);
                ReserveName_list.Add(item.Text);
            }

            ReserveID = String.Join(",", ReserveID_list.ToArray());
            ReserveName = String.Join(",", ReserveName_list.ToArray());
        }
        if (ReserveID == "")
        {
            DdlVillageName.Items.Clear();
            ReserveID = null;
            LblMsgVillageName.Text = "You have not selected.";
            LblMsgVillageValue.Text = "You have not selected.";
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
        }
        else
        {
            LblMsgTigerReserveName.Text = "";
            LblMsgTigerReserveValue.Text = "";
            LblMsgTigerReserveName.Text = String.Join(",", ReserveName_list.ToArray());
            LblMsgTigerReserveValue.Text = String.Join(",", ReserveID_list.ToArray());
            BindVillageNameOnBasisTigerReserveID(ReserveID);
        }

    }
    protected void DdlVillageName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string VillageID = string.Empty;
        string VillageName = string.Empty;

        List<String> VillageID_list = new List<string>();
        List<String> VillageName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in DdlVillageName.Items)
        {
            if (item.Selected)
            {
                VillageID_list.Add(item.Value);
                VillageName_list.Add(item.Text);
            }

            VillageID = String.Join(",", VillageID_list.ToArray());
            VillageName = String.Join(",", VillageName_list.ToArray());
        }
        if (VillageID == "")
        {
            VillageID = null;
            LblMsgVillageName.Text = "You have not selected.";
            LblMsgVillageValue.Text = "You have not selected.";
        }
        else
        {
            LblMsgVillageName.Text = String.Join(",", VillageName_list.ToArray());
            LblMsgVillageValue.Text = String.Join(",", VillageID_list.ToArray());
        }

        //BindFamilyHeadNameOnBasisVillageID(VillageID);
        //BindCdpAgencyNameOnBasisVillageID(VillageID);
    }
    void BindVillageNameOnBasisTigerReserveID(string TigerReserveID)
    {
        LblerrorDdlVillageName.Text = "";
        try
        {

            if (TigerReserveID != null)
            {

            }
            else
            {
                TigerReserveID = null;
            }
            DdlVillageName.Items.Clear();
            DataSet ds = new VillageDB().DsConsoldateBindVillageName(TigerReserveID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DdlVillageName.DataSource = ds.Tables[0];
                DdlVillageName.DataTextField = "VILL_NM";
                DdlVillageName.DataValueField = "VILL_ID";
                DdlVillageName.DataBind();
                LblMsgVillageName.Text = "You have not selected.";
                LblMsgVillageValue.Text = "You have not selected.";
                //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
            }
            else
            {
                LblMsgTigerReserveName.Text = "You have not selected.";
                LblMsgTigerReserveValue.Text = "You have not selected.";

                DdlVillageName.Items.Clear();
                LblerrorDdlVillageName.Text = "--No Record Found--";
                // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
            }

        }
        catch (Exception er)
        {
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
                        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                        {
                            Session["sPageIndex"] = Request.QueryString["IndexMode"].ToString();
                            Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsolDateReport.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString() + "&IndexMode=" + Session["sPageIndex"].ToString(), false);
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

    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
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
                        displayVillageSearch1();
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }
    protected void BtnRefresh_Click(object sender, EventArgs e)
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
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }
    void printGridAll()
    {
        // GridViewgv_villageSearch = new GridView();
        gv_villageSearch.DataSource = ViewState["Data"];
        gv_villageSearch.AllowPaging = false;
        gv_villageSearch.DataBind();
        //Footer rows record sum
        DataTable dt = (DataTable)ViewState["Data"];
        GridViewNumericCalculation4(dt);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_villageSearch.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Villages wise Dynamic Report ");
        //  sb.Append("");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_villageSearch.AllowPaging = true;
        gv_villageSearch.DataBind();
    }
    protected void BtnPrintAll_Click(object sender, EventArgs e)
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
                        gv_villageSearch1.Visible = true;

                        this.printGrid();
                        gv_villageSearch1.Visible = false;
                    }
                }
            }
        }
        
        catch
        {
            throw;
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
                        //Response.Redirect("~/AUTH/adminpanel/REPORT/VillagedynmicRpt.aspx");
                        //Response.Clear();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        //Response.Charset = "UTF-8";
                        //Response.ContentType = "application/vnd.ms-excel";
                        //using (StringWriter sw = new StringWriter())
                        //{

                        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //    hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                        //    hw.WriteLine("<br>");

                        //    //To Export all pages

                        //    gv_villageSearch1.AllowPaging = false;
                        //    if (Session["UserType"].ToString().Equals("4"))
                        //    {

                        //        displayVillage();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("3"))
                        //    {

                        //        displayVillage3();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("2"))
                        //    {

                        //        displayVillage2();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("1"))
                        //    {

                        //        displayVillage1();

                        //    }
                        //    gv_villageSearch1.Visible = true;
                        //    this.gv_villageSearch1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                        //    this.gv_villageSearch1.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        //    foreach (TableCell cell in gv_villageSearch1.HeaderRow.Cells)
                        //    {
                        //        cell.BackColor = gv_villageSearch1.HeaderStyle.BackColor;
                        //    }
                        //    foreach (GridViewRow row in gv_villageSearch1.Rows)
                        //    {
                        //        row.BackColor = System.Drawing.Color.White;
                        //        foreach (TableCell cell in row.Cells)
                        //        {
                        //            if (row.RowIndex % 2 == 0)
                        //            {
                        //                cell.BackColor = gv_villageSearch1.AlternatingRowStyle.BackColor;
                        //            }
                        //            else
                        //            {
                        //                cell.BackColor = gv_villageSearch1.RowStyle.BackColor;
                        //            }
                        //            cell.CssClass = "textmode";
                        //        }
                        //    }

                        //    gv_villageSearch1.RenderControl(hw);


                        //    //-------------------

                        //    string style = @"<style> .textmode { } </style>";
                        //    Response.Write(style);
                        //    Response.Output.Write(sw.ToString());
                        //    Response.Flush();
                        //    Response.End();


                        //}
                        ////-----------------------------------
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {

                            HtmlTextWriter hw = new HtmlTextWriter(sw);
                            hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                            hw.WriteLine("<br>");

                            //To Export all pages

                            gv_villageSearch.AllowPaging = false;


                            displayVillage1();


                            this.gv_villageSearch.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            this.gv_villageSearch.HeaderStyle.BackColor = System.Drawing.Color.Green;
                            foreach (TableCell cell in gv_villageSearch.HeaderRow.Cells)
                            {
                                cell.BackColor = gv_villageSearch.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gv_villageSearch.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gv_villageSearch.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gv_villageSearch.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gv_villageSearch.RenderControl(hw);


                            //-------------------

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
                        hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                        hw.WriteLine("<br>");
                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gv_villageSearch.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gv_villageSearch.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gv_villageSearch.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gv_villageSearch.AllowPaging = true;
                        gv_villageSearch.DataBind();
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
        gv_villageSearch1.DataSource = ViewState["Data"];
        gv_villageSearch1.AllowPaging = false;
        gv_villageSearch1.DataBind();
        //Footer rows record sum
        DataTable dt = (DataTable)ViewState["Data"];
        GridViewNumericCalculation4DT(dt);
        //GridViewNumericCalculation4(dt);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_villageSearch1.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Villages wise Dynamic Report ");
        //  sb.Append("");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_villageSearch1.AllowPaging = true;
        gv_villageSearch1.DataBind();


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
                        int flag = 0;

                        //---------------------1---------------
                        CheckBox chk1 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox1");
                        string qurystring = "";
                        if (chk1.Checked == true)
                        {
                            gv_villageSearch1.Columns[0].Visible = true;
                            flag = 1;

                        }
                        else
                        {
                            gv_villageSearch1.Columns[0].Visible = false;
                        }
                        //---------------------1-----------
                        CheckBox CheckStateName = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckStateName");

                        if (CheckStateName.Checked == true)
                        {
                            gv_villageSearch1.Columns[1].Visible = true;
                            flag = 1;

                        }
                        else
                        {
                            gv_villageSearch1.Columns[1].Visible = false;
                        }
                        //-----------------2-------------
                        CheckBox CheckTigerReservename = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckTigerReservename");

                        if (CheckTigerReservename.Checked == true)
                        {
                            gv_villageSearch1.Columns[2].Visible = true;
                            flag = 1;

                        }
                        else
                        {
                            gv_villageSearch1.Columns[2].Visible = false;
                        }
                        //------------------3--------
                        CheckBox chk2 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox2");
                        if (chk2.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[3].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[3].Visible = false;
                        }
                        //------------------------4-----------
                        CheckBox chk3 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox3");
                        if (chk3.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[4].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[4].Visible = false;
                        }
                        //-------------------------5-------------------
                        CheckBox chk4 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox4");
                        if (chk4.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[5].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[5].Visible = false;

                        }
                        //------------------6------------------
                        CheckBox chk5 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox5");
                        if (chk5.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[6].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[6].Visible = false;

                        }
                        //-----------------7-------------
                        CheckBox chk6 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox6");
                        if (chk6.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[7].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[7].Visible = false;

                        }
                        //-------------------8---------------------
                        CheckBox chk7 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox7");
                        if (chk7.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[8].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[8].Visible = false;

                        }
                        //------------9---------------------
                        CheckBox chk8 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox8");
                        if (chk8.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[9].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[9].Visible = false;

                        }
                        //-------------10-----------------
                        CheckBox chk9 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox9");
                        if (chk9.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[10].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[10].Visible = false;

                        }
                        //--------------------11------------------
                        CheckBox chk10 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox10");
                        if (chk10.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[11].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[11].Visible = false;

                        }
                        //--------------------12--------------------
                        //18june

                        CheckBox ChkCow_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkCow");
                        if (ChkCow_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[12].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[12].Visible = false;

                        }
                        //-----------------13------------------------
                        CheckBox ChkBuffalo_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkBuffalo");
                        if (ChkBuffalo_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[13].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[13].Visible = false;

                        }
                        //------------------14-----------------------
                        CheckBox ChkSheep_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkSheep");

                        if (ChkSheep_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[14].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[14].Visible = false;

                        }
                        //-------------------15-------------
                        CheckBox ChkGoat_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkGoat");

                        if (ChkGoat_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[15].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }
                        else
                        {
                            gv_villageSearch1.Columns[15].Visible = false;

                        }
                        //-------------------16-------------------
                        CheckBox CheckBox13_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox13");

                        if (CheckBox13_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[16].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[16].Visible = false;

                        }
                        //---------------------17---------------
                        CheckBox CheckBox14_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox14");

                        if (CheckBox14_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[17].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[17].Visible = false;

                        }
                        //---------------------18-------------
                        CheckBox CheckBox15_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox15");

                        if (CheckBox15_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[18].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[18].Visible = false;

                        }
                        //--------------------19-------------
                        CheckBox CheckBox16_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox16");

                        if (CheckBox16_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[19].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[19].Visible = false;

                        }
                        //-------------------20--------------
                        CheckBox CheckBox17_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox17");

                        if (CheckBox17_.Checked == true)
                        {
                            flag = 1;
                            gv_villageSearch1.Columns[20].Visible = true;
                            //qurystring = qurystring + "a.VILL_NM" + ",";

                        }

                        else
                        {
                            gv_villageSearch1.Columns[20].Visible = false;

                        }
                        //--------------------21---------------------------
                        CheckBox CheckGoogleMap = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckGoogleMap");

                        if (CheckGoogleMap.Checked == true)
                        {
                            gv_villageSearch1.Columns[21].Visible = true;
                            flag = 1;

                        }
                        else
                        {
                            gv_villageSearch1.Columns[21].Visible = false;
                        }
                        //end 18june
                        //------------------------------------------------------
                        //--------------------------------------
                        if (flag == 0)
                        {
                            gv_villageSearch1.Visible = false;

                            lblnodatafound.Text = "Please Select Atleast one value";
                            lblnodatafound.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else
                        {
                            gv_villageSearch1.Visible = true;

                            this.printGrid();
                            gv_villageSearch1.Visible = false;
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
    void GridViewNumericCalculation4(DataTable dt)
    {
        //DataSet ds
        string Total = "Total=";
        int sno = 0;
        int Population = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa = 0;
        decimal OtherLandAreaHa = 0;
        decimal ValueofAgricultureland = 0;
        decimal ValueResidentialLand = 0;
        int TotalCow = 0;
        int TotalBuffalo = 0;
        int TotalSheep = 0;
        int TotalGoat = 0;
        int OtherAnimal = 0;
        int RelocatedFamilies = 0;
        int NonRelocatedFamilies = 0;
        int NGO = 0;
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    sno = ds.Tables[0].Rows.Count;
        //    Population += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_POPU"]);
        //    TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_LND_AREA"]);
        //    TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
        //    TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
        //    OtherLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_OTHER_LND_AREA"]);
        //    ValueofAgricultureland += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_AGRI"]);
        //    ValueResidentialLand += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_RES"]);
        //    TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["NoCows"]);
        //    TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBuffalo"]);
        //    TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["NoSheep"]);
        //    TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
        //    OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
        //    RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
        //    NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
        //    NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sno = dt.Rows.Count;
            Population += Convert.ToInt32(dt.Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_LND_AREA"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            OtherLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_OTHER_LND_AREA"]);
            ValueofAgricultureland += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_AGRI"]);
            ValueResidentialLand += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_RES"]);
            TotalCow += Convert.ToInt32(dt.Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(dt.Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(dt.Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(dt.Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(dt.Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(dt.Rows[i]["ngo"]);
        }
        //sno
        gv_villageSearch.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_villageSearch.FooterRow.Cells[0].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gv_villageSearch.FooterRow.Cells[5].Text = Total + Population.ToString();
        gv_villageSearch.FooterRow.Cells[5].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gv_villageSearch.FooterRow.Cells[6].Text = Total + TotalLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[6].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        gv_villageSearch.FooterRow.Cells[7].Text = Total + TotalAgricultureLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[7].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        gv_villageSearch.FooterRow.Cells[8].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[8].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        gv_villageSearch.FooterRow.Cells[9].Text = Total + OtherLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[9].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        gv_villageSearch.FooterRow.Cells[10].Text = Total + ValueofAgricultureland.ToString();
        gv_villageSearch.FooterRow.Cells[10].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        gv_villageSearch.FooterRow.Cells[11].Text = Total + ValueResidentialLand.ToString();
        gv_villageSearch.FooterRow.Cells[11].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        gv_villageSearch.FooterRow.Cells[12].Text = Total + TotalCow.ToString();
        gv_villageSearch.FooterRow.Cells[12].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        gv_villageSearch.FooterRow.Cells[13].Text = Total + TotalBuffalo.ToString();
        gv_villageSearch.FooterRow.Cells[13].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gv_villageSearch.FooterRow.Cells[14].Text = Total + TotalSheep.ToString();
        gv_villageSearch.FooterRow.Cells[14].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        gv_villageSearch.FooterRow.Cells[15].Text = Total + TotalGoat.ToString();
        gv_villageSearch.FooterRow.Cells[15].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        gv_villageSearch.FooterRow.Cells[16].Text = Total + OtherAnimal.ToString();
        gv_villageSearch.FooterRow.Cells[16].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        gv_villageSearch.FooterRow.Cells[17].Text = Total + RelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[17].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        gv_villageSearch.FooterRow.Cells[18].Text = Total + NonRelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[18].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        gv_villageSearch.FooterRow.Cells[20].Text = Total + NGO.ToString();
        gv_villageSearch.FooterRow.Cells[20].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[20].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    void GridViewNumericCalculation4DT(DataTable dt)
    {

        string Total = "Total=";
        int sno = 0;
        int Population = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa = 0;
        decimal OtherLandAreaHa = 0;
        decimal ValueofAgricultureland = 0;
        decimal ValueResidentialLand = 0;
        int TotalCow = 0;
        int TotalBuffalo = 0;
        int TotalSheep = 0;
        int TotalGoat = 0;
        int OtherAnimal = 0;
        int RelocatedFamilies = 0;
        int NonRelocatedFamilies = 0;
        int NGO = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sno = dt.Rows.Count;
            Population += Convert.ToInt32(dt.Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_LND_AREA"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            OtherLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_OTHER_LND_AREA"]);
            ValueofAgricultureland += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_AGRI"]);
            ValueResidentialLand += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_RES"]);
            TotalCow += Convert.ToInt32(dt.Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(dt.Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(dt.Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(dt.Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(dt.Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(dt.Rows[i]["ngo"]);
        }
        gv_villageSearch1.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_villageSearch1.FooterRow.Cells[0].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gv_villageSearch1.FooterRow.Cells[5].Text = Total + Population.ToString();
        gv_villageSearch1.FooterRow.Cells[5].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gv_villageSearch1.FooterRow.Cells[6].Text = Total + TotalLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[6].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        gv_villageSearch1.FooterRow.Cells[7].Text = Total + TotalAgricultureLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[7].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        gv_villageSearch1.FooterRow.Cells[8].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[8].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        gv_villageSearch1.FooterRow.Cells[9].Text = Total + OtherLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[9].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        gv_villageSearch1.FooterRow.Cells[10].Text = Total + ValueofAgricultureland.ToString();
        gv_villageSearch1.FooterRow.Cells[10].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        gv_villageSearch1.FooterRow.Cells[11].Text = Total + ValueResidentialLand.ToString();
        gv_villageSearch1.FooterRow.Cells[11].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        gv_villageSearch1.FooterRow.Cells[12].Text = Total + TotalCow.ToString();
        gv_villageSearch1.FooterRow.Cells[12].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        gv_villageSearch1.FooterRow.Cells[13].Text = Total + TotalBuffalo.ToString();
        gv_villageSearch1.FooterRow.Cells[13].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gv_villageSearch1.FooterRow.Cells[14].Text = Total + TotalSheep.ToString();
        gv_villageSearch1.FooterRow.Cells[14].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        gv_villageSearch1.FooterRow.Cells[15].Text = Total + TotalGoat.ToString();
        gv_villageSearch1.FooterRow.Cells[15].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        gv_villageSearch1.FooterRow.Cells[16].Text = Total + OtherAnimal.ToString();
        gv_villageSearch1.FooterRow.Cells[16].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        gv_villageSearch1.FooterRow.Cells[17].Text = Total + RelocatedFamilies.ToString();
        gv_villageSearch1.FooterRow.Cells[17].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        gv_villageSearch1.FooterRow.Cells[18].Text = Total + NonRelocatedFamilies.ToString();
        gv_villageSearch1.FooterRow.Cells[18].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        gv_villageSearch1.FooterRow.Cells[20].Text = Total + NGO.ToString();
        gv_villageSearch1.FooterRow.Cells[20].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[20].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    protected void gv_villageSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage1();

       
    }
    protected void gv_villageSearch_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        if (e.CommandName == "Edit")
                        {
                            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                            string TigerReserveName = commandArgs[0];
                            string VillageID = commandArgs[1];
                            //string FMLY_ID = commandArgs[2];
                            //------------
                            string sUrlConsoldateStateName = Request.QueryString["ConsoldateStateName"].ToString();
                            string sUrlConsoldateMode = Request.QueryString["ConsoldateMode"].ToString();
                            string sUrlReserveID = Request.QueryString["ReserveID"].ToString();
                            string sUrlVillageID = Request.QueryString["VillageID"].ToString();
                            string sUrlStateID = Request.QueryString["StateID"].ToString();
                            string sUrlVillageName = Request.QueryString["VillageName"].ToString();
                            string sUrlReserveName = Request.QueryString["ReserveName"].ToString();
                            Session["sPageIndex"] = Request.QueryString["IndexMode"].ToString();
                            //----------------

                            // Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyHeadGrid.aspx?F_ID=" + FMLY_ID.ToString() + "&s_ID=1" + "&Resv=" + TigerReserveName.ToString() + "&villid=" + VillageID.ToString() + "&ConsoldateStateName=" + sUrlConsoldateStateName + "&ConsoldateMode=" + Session["ssConsoldateMode"].ToString() + "&ReserveID=" + sUrlReserveID + "&VillageID=" + sUrlVillageID + "&StateID=" + Session["ssStateID"].ToString() + "&VillageName=" + sUrlVillageName + "&ReserveName=" + sUrlVillageName);
                            // Response.Redirect(ResolveUrl("GoogleMap.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vcode=" + ddlselectcode.SelectedValue.ToString() + "&vname=" + ddlselectname.SelectedValue.ToString()), false);
                            Response.Redirect(ResolveUrl("GoogleMapConsol.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + VillageID + "&Resv=" + TigerReserveName.ToString() + "&ConsoldateStateName=" + sUrlConsoldateStateName + "&ConsoldateMode=" + Session["ssConsoldateMode"].ToString() + "&ReserveID=" + sUrlReserveID + "&VillageID=" + sUrlVillageID + "&StateID=" + Session["ssStateID"].ToString() + "&VillageName=" + sUrlVillageName + "&ReserveName=" + sUrlVillageName + "&IndexMode=" + Session["sPageIndex"].ToString()), false);
                            // Response.Redirect(ResolveUrl("map.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString()), false);
                        }
                        if (e.CommandName.Equals("Sort"))
                        {

                            if (ViewState["SortExpression"] != null)
                            {

                                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                                {

                                    if (ViewState["SortOrder"].ToString() == "ASC")

                                        ViewState["SortOrder"] = "DESC";

                                    else

                                        ViewState["SortOrder"] = "ASC";

                                }

                                else
                                {

                                    ViewState["SortOrder"] = "ASC";

                                    ViewState["SortExpression"] = e.CommandArgument.ToString();

                                }

                            }

                            else
                            {

                                ViewState["SortExpression"] = e.CommandArgument.ToString();

                                ViewState["SortOrder"] = "ASC";

                            }

                        }

                        //Re Bind The Grid to reflect the Sort Order

                        //FillReserve();
                        btn_print.Visible = false;
                        gv_villageSearch1.Visible = false;

                        displayVillage1();

                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }
    protected void gv_villageSearch1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        //}
    }

    protected void gv_villageSearch_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {

                            if (Session["UserType"].ToString().Equals("1"))
                            {
                                gv_villageSearch.Columns[1].Visible = true;
                            }
                            Label lbl = (Label)e.Row.FindControl("LblStatus");

                            ImageButton img = (ImageButton)e.Row.FindControl("ibEdit");
                            if (lbl.Text == "Relocated")
                            {
                                img.Visible = true;
                            }
                            else
                            { img.Visible = false; }
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
    protected void gv_villageSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_villageSearch_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
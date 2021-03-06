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
public partial class auth_Adminpanel_REPORT_CDP_ReportConsol : CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();
    FamilyDB FMLYDB_Obj = new FamilyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
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

                    //                    &ConsoldateMode=Creport
                    //&ReserveID=9
                    //&VillageID=10036,10037
                    //&StateID=5
                    //&VillageName=Munirka%20village,Rampur%20village&ReserveName=Valmiki%20Tiger%20Reserve

                    //LblMsgTigerReserveName.Text = Request.QueryString["ReserveName"].ToString();
                    //LblMsgTigerReserveValue.Text = Request.QueryString["ReserveID"].ToString();
                    //LblMsgVillageName.Text = Request.QueryString["VillageName"].ToString();
                    //LblMsgVillageValue.Text = Request.QueryString["VillageID"].ToString();

                }
                else
                {
                    LblMsgTigerReserveName.Text = Session["ssReserveName"].ToString();
                    LblMsgTigerReserveValue.Text = Session["ssReserveID"].ToString();
                    LblMsgVillageName.Text = Session["ssVillageName"].ToString();
                    LblMsgVillageValue.Text = Session["ssVillageID"].ToString();
                }
                BindStateNameConsolDate();
                BindCdpReportUsingGridView();
            }
            else
            {

            }
        }
    }
    void BindCdpReportUsingGridView()
    {
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
        DataTable dt = FMLYDB_Obj.BindCdpAgencyConsol(TigerReseveIDParameters, VillId, Request.QueryString["ConsoldateStateName"].ToString());
        if (dt.Rows.Count > 0)
        {
            GridViewNarenConsoldateReport.Visible = true;
            GridViewNarenConsoldateReport.DataSource = dt;
            ViewState["Data"] = dt;
            GridViewNarenConsoldateReport.DataBind();
            NarenDivMessageError.Visible = false;
            GridViewNarenConsoldateReport.Caption = "TOTAL RECORD :" + dt.Rows.Count.ToString();
        }
        else
        {
            NarenDivMessageError.Visible = true;
            // GridViewNarenConsoldateReport.Visible = false;
            //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
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
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
        {
            //Session["sPageIndex"] = Request.QueryString["IndexMode"].ToString();
            Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsolDateReport.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString() + "&IndexMode=" + Session["sPageIndex"].ToString(), false);
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
    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
    {
       // BindFamilyHeadDetailsUsingGridView();
        BindCdpReportUsingGridView();
    }
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void GridViewNarenConsoldateReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridViewNarenConsoldateReport_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        if (e.CommandName == "Details")
                        {
                            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                            string TigerReserveName = commandArgs[0];
                            string VillageID = commandArgs[1];
                            string FMLY_ID = commandArgs[2];//agency name here don't be confuse for fast work i am doing
                                                            //------------
                            string sUrlConsoldateStateName = Request.QueryString["ConsoldateStateName"].ToString();
                            string sUrlConsoldateMode = Request.QueryString["ConsoldateMode"].ToString();
                            string sUrlReserveID = Request.QueryString["ReserveID"].ToString();
                            string sUrlVillageID = Request.QueryString["VillageID"].ToString();
                            string sUrlStateID = Request.QueryString["StateID"].ToString();
                            string sUrlVillageName = Request.QueryString["VillageName"].ToString();
                            string sUrlReserveName = Request.QueryString["ReserveName"].ToString();

                            //----------------

                            Response.Redirect("~/AUTH/adminpanel/REPORT/CDP_ReportConsolDetails.aspx?F_ID=" + FMLY_ID.ToString() + "&s_ID=1" + "&Resv=" + TigerReserveName.ToString() + "&villid=" + VillageID.ToString() + "&ConsoldateStateName=" + sUrlConsoldateStateName + "&ConsoldateMode=" + Session["ssConsoldateMode"].ToString() + "&ReserveID=" + sUrlReserveID + "&VillageID=" + sUrlVillageID + "&StateID=" + Session["ssStateID"].ToString() + "&VillageName=" + sUrlVillageName + "&ReserveName=" + sUrlVillageName);

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

    #region[Start Export section]
    protected void btn_print_Click(object sender, EventArgs e)
    {
        // btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
        printGrid();
        if (Session["UserType"].ToString() == "1")
        {
            // BindTigerReserveName1();
            // Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
            btn_print.Visible = false;
            BindCdpReportUsingGridView();
        }

    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        GridViewNarenConsoldateReport.DataSource = ViewState["Data"];
        GridViewNarenConsoldateReport.AllowPaging = false;
        GridViewNarenConsoldateReport.DataBind();
        //Footer rows record sum
       // DataSet Ds = (DataSet)ViewState["Data"];
      //  GridViewNumericCalculation4(Ds);
        foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
        {
            //------------start Removing link button
            //Label Lblv = (Label)row.FindControl("LblVillage");
            //Lblv.Visible = true;
            //LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
            //Lnkv.Visible = false;
            ////LblFamilyhead,LnkFamilyhead
            //Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
            //LblFamilyhead.Visible = true;
            //LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
            //LnkFamilyhead.Visible = false;
            ////LblExecutiveAgency,LnkExecutiveAgency
            //Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
            //LblExecutiveAgency.Visible = true;
            //LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
            //LnkExecutiveAgency.Visible = false;
            ////LblRelocationStatus,LnkRelocationStatus
            //Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
            //LblRelocationStatus.Visible = true;
            //LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
            //LnkRelocationStatus.Visible = false;
            ////LblMap,LnkMap
            //Label LblMap = (Label)row.FindControl("LblMap");
            //LblMap.Visible = true;
            //LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
            //LnkMap.Visible = false;
            ////LblRelocationProgressReport,LnkRelocationProgressReport
            //Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
            //LblRelocationProgressReport.Visible = true;
            //LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
            //LnkRelocationProgressReport.Visible = false;
            ////LblNGO,LnkNGO
            //Label LblNGO = (Label)row.FindControl("LblNGO");
            //LblNGO.Visible = true;
            //LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
            //LnkNGO.Visible = false;
            //------------start Removing link button
        }
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewNarenConsoldateReport.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Progress of work as per Community Development Program ");
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
        GridViewNarenConsoldateReport.AllowPaging = true;
        GridViewNarenConsoldateReport.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        //--------------------------
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "CDPReport" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteLine("<h1 style=\"text-align:center;\">CDP Report</h1>");
            hw.WriteLine("<br>");
            //To Export all pages

            GridViewNarenConsoldateReport.AllowPaging = false;
            BindCdpReportUsingGridView();
            GridViewNarenConsoldateReport.HeaderRow.BackColor = System.Drawing.Color.Black;
            foreach (TableCell cell in GridViewNarenConsoldateReport.HeaderRow.Cells)
            {
                cell.BackColor = GridViewNarenConsoldateReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
            {
                //------------start Removing link button
                //Label Lblv = (Label)row.FindControl("LblVillage");
                //Lblv.Visible = true;
                //LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
                //Lnkv.Visible = false;
                ////LblFamilyhead,LnkFamilyhead
                //Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
                //LblFamilyhead.Visible = true;
                //LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
                //LnkFamilyhead.Visible = false;
                ////LblExecutiveAgency,LnkExecutiveAgency
                //Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
                //LblExecutiveAgency.Visible = true;
                //LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
                //LnkExecutiveAgency.Visible = false;
                ////LblRelocationStatus,LnkRelocationStatus
                //Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
                //LblRelocationStatus.Visible = true;
                //LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
                //LnkRelocationStatus.Visible = false;
                ////LblMap,LnkMap
                //Label LblMap = (Label)row.FindControl("LblMap");
                //LblMap.Visible = true;
                //LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
                //LnkMap.Visible = false;
                ////LblRelocationProgressReport,LnkRelocationProgressReport
                //Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
                //LblRelocationProgressReport.Visible = true;
                //LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
                //LnkRelocationProgressReport.Visible = false;
                ////LblNGO,LnkNGO
                //Label LblNGO = (Label)row.FindControl("LblNGO");
                //LblNGO.Visible = true;
                //LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
                //LnkNGO.Visible = false;
                //------------start Removing link button


                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridViewNarenConsoldateReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridViewNarenConsoldateReport.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridViewNarenConsoldateReport.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    protected void BtnPdfExport_Click(object sender, EventArgs e)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                hw.WriteLine("<h1 style=\"text-align:center;\">Village Progress Report</h1>");
                hw.WriteLine("<br>");
                //To Export all pages
                GridViewNarenConsoldateReport.AllowPaging = false;
                //  this.BindGrid();
                if (Session["UserType"].ToString() == "1")
                {

                    this.BindCdpReportUsingGridView();
                }
                foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
                {
                    //------------start Removing link button
                    //Label Lblv = (Label)row.FindControl("LblVillage");
                    //Lblv.Visible = true;
                    //LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
                    //Lnkv.Visible = false;
                    ////LblFamilyhead,LnkFamilyhead
                    //Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
                    //LblFamilyhead.Visible = true;
                    //LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
                    //LnkFamilyhead.Visible = false;
                    ////LblExecutiveAgency,LnkExecutiveAgency
                    //Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
                    //LblExecutiveAgency.Visible = true;
                    //LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
                    //LnkExecutiveAgency.Visible = false;
                    ////LblRelocationStatus,LnkRelocationStatus
                    //Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
                    //LblRelocationStatus.Visible = true;
                    //LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
                    //LnkRelocationStatus.Visible = false;
                    ////LblMap,LnkMap
                    //Label LblMap = (Label)row.FindControl("LblMap");
                    //LblMap.Visible = true;
                    //LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
                    //LnkMap.Visible = false;
                    ////LblRelocationProgressReport,LnkRelocationProgressReport
                    //Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
                    //LblRelocationProgressReport.Visible = true;
                    //LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
                    //LnkRelocationProgressReport.Visible = false;
                    ////LblNGO,LnkNGO
                    //Label LblNGO = (Label)row.FindControl("LblNGO");
                    //LblNGO.Visible = true;
                    //LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
                    //LnkNGO.Visible = false;
                    //------------start Removing link button
                }
                GridViewNarenConsoldateReport.HeaderStyle.ForeColor = System.Drawing.Color.White;
                GridViewNarenConsoldateReport.HeaderStyle.BackColor = System.Drawing.Color.Green;
                GridViewNarenConsoldateReport.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=CDPReport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
    #endregion[End Export section]
}
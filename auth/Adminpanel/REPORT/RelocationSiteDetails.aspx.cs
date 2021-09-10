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


public partial class auth_Adminpanel_REPORT_RelocationSiteDetails : CrsfBase
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
                    LblMsgTigerReserveName.Text = Request.QueryString["ReserveName"].ToString();
                    LblMsgTigerReserveValue.Text = Request.QueryString["ReserveID"].ToString();
                    LblMsgVillageName.Text = Request.QueryString["VillageName"].ToString();
                    LblMsgVillageValue.Text = Request.QueryString["VillageID"].ToString();
                    //Request.QueryString["ConsoldateStateName"].ToString();
                    BindStateNameConsolDate();
                    // DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                    //   DdlStateName_SelectedIndexChanged(this, EventArgs.Empty);
                    // displayVillage1();
                    BindVillages();
                }
                else
                {

                }
            }
        }
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvforVillages.PageIndex = e.NewPageIndex;
            BindVillages();

        }
        catch (Exception e1)
        {
            //   lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //   lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages()
    {

        DataSet ds = new DataSet();
        string sLblMsgTigerReserveValue = string.Empty;
        string sLblMsgVillageValue = string.Empty;
        //if (LblMsgTigerReserveValue.Text == "You have not selected.")
        //{
        //    sLblMsgTigerReserveValue = null;
        //}
        //else
        //{
        //    sLblMsgTigerReserveValue = LblMsgTigerReserveValue.Text.Trim();
        //}

        //if (LblMsgVillageValue.Text == "You have not selected.")
        //{
        //    sLblMsgVillageValue = null;
        //}
        //else
        //{
        //    sLblMsgVillageValue = LblMsgVillageValue.Text.Trim();
        //}

        ds = RDb.DsRelocationDetails(Request.QueryString["StateID"].ToString(), null, null);
        //  DataSet ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.Visible = true;
            gvforVillages.DataSource = ds.Tables[0];
            gvforVillages.DataBind();
            t1.Visible = true;
            btnexporttoexel.Visible = true;
            btnprint.Visible = true;
            //lblMsg.Text = "";
            BtnPdfExport.Visible = true;

            btnprint.Visible = true;
            btnexporttoexel.Visible = true;
            BtnPdfExport.Visible = true;
        }
        else
        {
            btnprint.Visible = false;
            btnexporttoexel.Visible = false;
            BtnPdfExport.Visible = false;

            BtnPdfExport.Visible = false;
            btnexporttoexel.Visible = false;
            btnprint.Visible = false;
            gvforVillages.Visible = false;
            t1.Visible = false;
            // lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            // lblMsg.ForeColor = System.Drawing.Color.Red;
        }


    }
    public void BindVillagesOFSearching()
    {

        DataSet ds = new DataSet();
        string sLblMsgTigerReserveValue = string.Empty;
        string sLblMsgVillageValue = string.Empty;
        if (LblMsgTigerReserveValue.Text == "You have not selected.")
        {
            sLblMsgTigerReserveValue = null;
        }
        else
        {
            sLblMsgTigerReserveValue = LblMsgTigerReserveValue.Text.Trim();
        }

        if (LblMsgVillageValue.Text == "You have not selected.")
        {
            sLblMsgVillageValue = null;
        }
        else
        {
            sLblMsgVillageValue = LblMsgVillageValue.Text.Trim();
        }

        ds = RDb.DsRelocationDetails(Request.QueryString["StateID"].ToString(), sLblMsgTigerReserveValue,sLblMsgVillageValue);
        //  DataSet ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.Visible = true;
            gvforVillages.DataSource = ds.Tables[0];
            gvforVillages.DataBind();
            t1.Visible = true;
            btnexporttoexel.Visible = true;
            btnprint.Visible = true;
            //lblMsg.Text = "";
            BtnPdfExport.Visible = true;

            btnprint.Visible = true;
            btnexporttoexel.Visible = true;
            BtnPdfExport.Visible = true;
        }
        else
        {
            btnprint.Visible = false;
            btnexporttoexel.Visible = false;
            BtnPdfExport.Visible = false;

            BtnPdfExport.Visible = false;
            btnexporttoexel.Visible = false;
            btnprint.Visible = false;
            gvforVillages.Visible = false;
            t1.Visible = false;
            // lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            // lblMsg.ForeColor = System.Drawing.Color.Red;
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
                        BindVillagesOFSearching();
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

                        gvforVillages.AllowPaging = false;
                        BindVillages();
                        btnexporttoexel.Visible = false;
                        btnprint.Visible = false;
                        printGrid();
                        gvforVillages.AllowPaging = true;
                        BindVillages();
                        btnexporttoexel.Visible = true;
                        btnprint.Visible = true;

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
        gvforVillages.AllowPaging = false;

        BindVillages();
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
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        //     gv_villageSearch1.DataBind();


    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void btnexporttoexel_Click(object sender, EventArgs e)
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

                        gvforVillages.AllowPaging = false;
                        btnexporttoexel.Visible = false;
                        btnprint.Visible = false;
                        BindVillages();

                        Realocation_AreaDB.ExportToExcel(ref panel, "Relocation site");
                        gvforVillages.AllowPaging = true;
                        BindVillages();
                        btnexporttoexel.Visible = true;
                        btnprint.Visible = true;
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
                        hw.WriteLine("<h1 style=\"text-align:center;\">Relocation Site Report</h1>");
                        hw.WriteLine("<br>");

                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
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
}
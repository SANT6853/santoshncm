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


public partial class auth_Adminpanel_REPORT_ConsoldateReport_PostConsoldateReport : System.Web.UI.Page
{
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public static int Search = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }
        // GridViewNarenConsoldateReport.PageIndex=0;
        if (!IsPostBack)
        {
            BindDdlCheckboxIntoStateName();


            //start Gridview backcoding
            if (Request.QueryString["IndexMode"] != null)
            {
                GridViewNarenConsoldateReport.PageIndex = Convert.ToInt32(Request.QueryString["IndexMode"]);
               
                ConsolDateReport();

                //GridViewColumnHideShow();

                //GridViewNarenConsoldateReport.PageIndex = (Request["IndexMode"] != null) ? Request["IndexMode"] as int : 0; 
            }
            else
            {
                
                GridViewNarenConsoldateReport.PageIndex = 0;
                ConsolDateReport();
            }


        }
    }
   
    void ConsolDateReport()
    {
        //----------------
        if (Session["CtextState"] != null)
        {
            LblMsgStateName.Text = Session["CtextState"].ToString();
            LblMsgStateValue.Text = Session["CvalueState"].ToString();
        }
        if (Session["CtextTigerReserve"] != null)
        {
            LblMsgTigerReserveName.Text = Session["CtextTigerReserve"].ToString();
            LblMsgTigerReserveValue.Text = Session["CvalueTigerReserve"].ToString();
        }
        if (Session["CtextVillage"] != null)
        {
            LblMsgVillageName.Text = Session["CtextVillage"].ToString();
            LblMsgVillageValue.Text = Session["CvalueVillage"].ToString();
        }
        //--------------------------
        if (LblMsgStateValue.Text == "You have not selected.")
        {
            _objNtcauser.StateIDParameters = null;
        }
        else
        {
            _objNtcauser.StateIDParameters = LblMsgStateValue.Text.Trim();
        }
        if (LblMsgTigerReserveValue.Text == "You have not selected.")
        {
            _objNtcauser.TigerReseveIDParameters = null;
        }
        else
        {
            _objNtcauser.TigerReseveIDParameters = LblMsgTigerReserveValue.Text.Trim();
        }
        if (LblMsgVillageValue.Text == "You have not selected.")
        {
            _objNtcauser.VillId = null;
        }
        else
        {
            _objNtcauser.VillId = LblMsgVillageValue.Text.Trim();
        }
        P_var.dSet = _commanfuction.PostConsoldateReport(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GridViewNarenConsoldateReport.Visible = true;
            GridViewNarenConsoldateReport.DataSource = P_var.dSet.Tables[0];
            ViewState["Data"] = P_var.dSet;
            GridViewNarenConsoldateReport.DataBind();
            NarenDivMessageError.Visible = false;
            GridViewNarenConsoldateReport.Caption = "TOTAL RECORD COUNT:" + P_var.dSet.Tables[0].Rows.Count.ToString();
            //GridViewNumericCalculation4(P_var.dSet);

        }
        else
        {
            NarenDivMessageError.Visible = true;
            GridViewNarenConsoldateReport.Visible = false;

        }
    }
    protected void GridViewNarenConsoldateReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //if (Search == 0)
        //{
        //    GridViewNarenConsoldateReport.PageIndex = e.NewPageIndex;
        //    //pageing code belw
        //    Session["PageIndex"] = e.NewPageIndex;
        //    //pageing above code belw
        //    this.ConsolDateReport();
        //    GridViewNarenConsoldateReport.AllowPaging = true;
        //}
        //else
        //{
        //    ConsolDateReport();
        //    GridViewNarenConsoldateReport.AllowPaging = false;
        //}
        GridViewNarenConsoldateReport.PageIndex = e.NewPageIndex;
        //pageing code belw
        Session["PageIndex"] = e.NewPageIndex;
        //pageing above code belw
        this.ConsolDateReport();
        GridViewNarenConsoldateReport.AllowPaging = true;

    }
    protected void GridViewNarenConsoldateReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {//
        int PagingNo;
        if (Session["PageIndex"] != null)
        {
            PagingNo = (int)Session["PageIndex"];
        }
        else
        {
            PagingNo = 0;
        }
        string StateName = e.CommandArgument.ToString();
        string StateID = e.CommandArgument.ToString();
        string Mode = "Creport";

        if (e.CommandName == "TigerReserve")
        {

            Response.Redirect("~/AUTH/adminpanel/REPORT/ConsoldateTigerReserveDetails.aspx?ConsoldateStateID=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&IndexMode=" + PagingNo);
        }
        if (e.CommandName == "Village")
        {
            if (LblMsgStateValue.Text == "You have not selected.")
            {
               // http://localhost/NTCAReport/auth/adminpanel/Post/survey-details.aspx
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }

        }
        else if (e.CommandName == "Familyhead")
        {

            Session.Remove("ssReserveName");
            Session.Remove("ssReserveID");
            Session.Remove("ssVillageName");
            Session.Remove("ssVillageID");
            Session.Remove("ssStateID");
            Session.Remove("ssConsoldateMode");
            if (LblMsgStateValue.Text == "You have not selected.")
            {
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }

        }

        else if (e.CommandName == "CDPExecutiveAgency")
        {
            Session.Remove("ssReserveName");
            Session.Remove("ssReserveID");
            Session.Remove("ssVillageName");
            Session.Remove("ssVillageID");
            Session.Remove("ssStateID");
            Session.Remove("ssConsoldateMode");

            if (LblMsgStateValue.Text == "You have not selected.")
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/CDP_ReportConsol.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/CDP_ReportConsol.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
        }

        else if (e.CommandName == "NGO")
        {
            Session.Remove("ssReserveName");
            Session.Remove("ssReserveID");
            Session.Remove("ssVillageName");
            Session.Remove("ssVillageID");
            Session.Remove("ssStateID");
            Session.Remove("ssConsoldateMode");

            if (LblMsgStateValue.Text == "You have not selected.")
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/NgoListConsol.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/NgoListConsol.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
        }

        else if (e.CommandName == "RelocationStatus")
        {

            if (LblMsgStateValue.Text == "You have not selected.")
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/RelocationSiteDetails.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/REPORT/RelocationSiteDetails.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
        }
        else if (e.CommandName == "Map")
        {

            Session.Remove("ssReserveName");
            Session.Remove("ssReserveID");
            Session.Remove("ssVillageName");
            Session.Remove("ssVillageID");
            Session.Remove("ssStateID");
            Session.Remove("ssConsoldateMode");
            if (LblMsgStateValue.Text == "You have not selected.")
            {
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
            else
            {
                Response.Redirect("~/AUTH/adminpanel/Post/survey-details.aspx?ConsoldateStateName=" + StateID + "&ConsoldateMode=" + Mode + "&ReserveID=" + LblMsgTigerReserveValue.Text.Trim() + "&VillageID=" + LblMsgVillageValue.Text.Trim() + "&StateID=" + StateID + "&VillageName=" + LblMsgVillageName.Text.Trim() + "&ReserveName=" + LblMsgTigerReserveName.Text.Trim() + "&IndexMode=" + PagingNo);
            }
        }

        else if (e.CommandName == "RelocationProgressReport")
        {
            Response.Redirect("~/auth/adminpanel/Villagerelocationprogress/ReportConsold.aspx?ConsoldateStateName=" + StateName + "&ConsoldateMode=" + Mode + "&ModeR=45" + "&IndexMode=" + PagingNo);
        }

    }
    void GridViewNumericCalculation4(DataSet ds)
    {

        string Total = "Rs.";
        string Total1 = "";
        string Total2 = "Total";
        int sno = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa = 0;
        decimal TotalTigerReserve = 0;
        decimal TotalVillage = 0;
        decimal TotalFamily = 0;
        decimal TotalFamilyMember = 0;
        decimal TotalBenificiaries = 0;
        decimal TotalExecutiveAgency = 0;
        decimal TotalNGO = 0;
        decimal No_of_Relocated_Village = 0;

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            // Population += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDPAllotementAmount"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDPAllotementUSedAmount"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["NgoAllotAmount"]);
            TotalTigerReserve += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfTigerReserve"]);
            TotalVillage += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfVillage"]);
            TotalFamily += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfFamilyHead"]);
            TotalFamilyMember += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfFamilyMember"]);
            TotalBenificiaries += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfFamilyHead"]);
            TotalExecutiveAgency += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfCDPAgencyInVillage"]);
            TotalNGO += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfNgo"]);
            No_of_Relocated_Village += Convert.ToDecimal(ds.Tables[0].Rows[i]["NoOfVillageRelocated"]);
        }
        GridViewNarenConsoldateReport.FooterRow.Cells[1].Text = Total2.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[1].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total
        GridViewNarenConsoldateReport.FooterRow.Cells[12].Text = Total1 + No_of_Relocated_Village.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[12].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //End Total Number of Relocated Village
        GridViewNarenConsoldateReport.FooterRow.Cells[10].Text = Total1 + TotalNGO.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[10].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total No of NGO
        GridViewNarenConsoldateReport.FooterRow.Cells[7].Text = Total1 + TotalExecutiveAgency.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[7].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //End Total ExecutiveAgency 
        GridViewNarenConsoldateReport.FooterRow.Cells[6].Text = Total1 + TotalBenificiaries.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[6].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //End Total Benificiaries
        GridViewNarenConsoldateReport.FooterRow.Cells[5].Text = Total1 + TotalFamilyMember.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[5].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total Family Member
        GridViewNarenConsoldateReport.FooterRow.Cells[4].Text = Total1 + TotalFamily.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[4].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total Family
        GridViewNarenConsoldateReport.FooterRow.Cells[3].Text = Total1 + TotalVillage.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[3].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total Village
        GridViewNarenConsoldateReport.FooterRow.Cells[2].Text = Total1 + TotalTigerReserve.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[2].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //END Total Tiger Reserve
        GridViewNarenConsoldateReport.FooterRow.Cells[8].Text = Total + TotalLandAreaHa.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[8].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        GridViewNarenConsoldateReport.FooterRow.Cells[9].Text = Total + TotalAgricultureLandAreaHa.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[9].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        GridViewNarenConsoldateReport.FooterRow.Cells[11].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        GridViewNarenConsoldateReport.FooterRow.Cells[11].Font.Bold = true;
        GridViewNarenConsoldateReport.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        GridViewNarenConsoldateReport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha


    }
    void BindDdlCheckboxIntoStateName()
    {

        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);

        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "id";
            DdlStateName.DataBind();
            // DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
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
            DataSet ds = new VillageDB().DsPostConsoldateBindVillageName(TigerReserveID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DdlVillageName.DataSource = ds.Tables[0];
                DdlVillageName.DataTextField = "VILL_NM";
                DdlVillageName.DataValueField = "VILL_ID";
                DdlVillageName.DataBind();

                //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
            }
            else
            {

                DdlVillageName.Items.Clear();
                LblerrorDdlVillageName.Text = "--No Record Found--";
                // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
            }

        }
        catch (Exception er)
        {
        }
    }
    void DdlStateName_SelectedIndexChangedMethod()
    {
        LblMsgStateName.Text = string.Empty;
        LblMsgStateValue.Text = string.Empty;
        //----------------------------
        //  LblMsgTigerReserveName.Text = string.Empty;
        //  LblMsgTigerReserveValue.Text = string.Empty;
        //---------------------------------
        //  LblMsgVillageName.Text = string.Empty;
        // LblMsgVillageValue.Text = string.Empty;
        //---------------------------------
        string StateID = string.Empty;
        string StateName = string.Empty;

        List<String> StateID_list = new List<string>();
        List<String> StateName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in DdlStateName.Items)
        {
            if (item.Selected)
            {
                StateID_list.Add(item.Value);
                StateName_list.Add(item.Text);
            }

            StateID = String.Join(",", StateID_list.ToArray());
            StateName = String.Join(",", StateName_list.ToArray());
        }
        if (StateID == "")
        {
            DdlTigerReserve.Items.Clear();
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
            StateID = null;
            LblMsgStateName.Text = "You have not selected.";
            LblMsgStateValue.Text = "You have not selected.";
            //  DdlTigerReserve_SelectedIndexChanged(this, EventArgs.Empty);
            //  DdlTigerReserve_SelectedIndexChangedMethod();
            BindTigerReserveOnBasisStateIDDDl(StateID);
        }
        else
        {
            // DdlTigerReserve.Items.Clear();
            LblMsgStateName.Text = String.Join(",", StateName_list.ToArray());
            LblMsgStateValue.Text = String.Join(",", StateID_list.ToArray());
            // LblMsgTigerReserveName.Text = "";
            BindTigerReserveOnBasisStateID(StateID);
            //  DdlTigerReserve_SelectedIndexChanged(this, EventArgs.Empty);

            //ddlSponsor_SelectedIndexChanged(this, EventArgs.Empty);
            //  DdlTigerReserve_SelectedIndexChangedMethod();
            BindTigerReserveOnBasisStateIDDDl(StateID);
        }
        // BindVillageNameOnBasisTigerReserveIDDdl(ReserveID);
    }
    void BindTigerReserveOnBasisStateIDDDl(string StateId)
    {
        //LblMsgTigerReserveName.Text = string.Empty;
        //LblMsgTigerReserveValue.Text = string.Empty;
        string ReserveID = string.Empty;
        string ReserveName = string.Empty;

        List<String> ReserveID_list = new List<string>();
        List<String> ReserveName_list = new List<string>();
        try
        {

            if (StateId != null)
            {
                //  DdlTigerReserve.Items.Clear();
                DataSet ds = new VillageDB().DsConsoldateBindTigerReserve(StateId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        // string ss = ds.Tables[0].Rows[0]["TigerReserveName"].ToString();
                        // string ss = ds.Tables[0].Rows[0]["TigerReserveid"].ToString();
                        ReserveID_list.Add(ds.Tables[0].Rows[i]["TigerReserveid"].ToString());
                        ReserveName_list.Add(ds.Tables[0].Rows[i]["TigerReserveName"].ToString());

                        ReserveID = String.Join(",", ReserveID_list.ToArray());
                        ReserveName = String.Join(",", ReserveName_list.ToArray());
                    }
                    if (ReserveID != "")
                    {
                        if (LblMsgTigerReserveName.Text != "You have not selected.")
                        {
                            LblMsgTigerReserveName.Text = String.Join(",", ReserveName_list.ToArray());
                            LblMsgTigerReserveValue.Text = String.Join(",", ReserveID_list.ToArray());
                        }
                        BindVillageNameOnBasisTigerReserveIDDdl(ReserveID);
                    }

                }
                else
                {

                    //DdlTigerReserve.Items.Clear();
                    //ErrorChkTigerReserveName.Text = "--No Record Found--";
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
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlStateName_SelectedIndexChangedMethod();

    }
    void BindVillageNameOnBasisTigerReserveIDDdl(string TigerReserveID)
    {
        string VillageID = string.Empty;
        string VillageName = string.Empty;

        List<String> VillageID_list = new List<string>();
        List<String> VillageName_list = new List<string>();
        try
        {

            if (TigerReserveID != null)
            {

            }
            else
            {
                TigerReserveID = null;
            }
            //  DdlVillageName.Items.Clear();
            DataSet ds = new VillageDB().DsConsoldateBindVillageName(TigerReserveID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    VillageID_list.Add(ds.Tables[0].Rows[i]["VILL_ID"].ToString());
                    VillageName_list.Add(ds.Tables[0].Rows[i]["VILL_NM"].ToString());


                    VillageID = String.Join(",", VillageID_list.ToArray());
                    VillageName = String.Join(",", VillageName_list.ToArray());
                    //DdlVillageName.DataSource = ds.Tables[0];
                    //DdlVillageName.DataTextField = "VILL_NM";
                    //DdlVillageName.DataValueField = "VILL_ID";
                    //DdlVillageName.DataBind();

                    //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
                }
                if (VillageID != "")
                {
                    if (LblMsgVillageName.Text != "You have not selected.")
                    {
                        LblMsgVillageName.Text = String.Join(",", VillageName_list.ToArray());
                        LblMsgVillageValue.Text = String.Join(",", VillageID_list.ToArray());
                    }
                }
            }
            else
            {

                //DdlVillageName.Items.Clear();
                //LblerrorDdlVillageName.Text = "--No Record Found--";
                // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
            }

        }
        catch (Exception er)
        {
        }
    }
    void DdlTigerReserve_SelectedIndexChangedMethod()
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
            //DdlVillageName_SelectedIndexChanged(this, EventArgs.Empty);
            BindVillageNameOnBasisTigerReserveIDDdl(ReserveID);
        }
        else
        {
            LblMsgTigerReserveName.Text = "";
            LblMsgTigerReserveValue.Text = "";
            LblMsgTigerReserveName.Text = String.Join(",", ReserveName_list.ToArray());
            LblMsgTigerReserveValue.Text = String.Join(",", ReserveID_list.ToArray());
            BindVillageNameOnBasisTigerReserveID(ReserveID);
            BindVillageNameOnBasisTigerReserveIDDdl(ReserveID);
            //  DdlVillageName_SelectedIndexChanged(this, EventArgs.Empty);
        }
    }
    protected void DdlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

        DdlTigerReserve_SelectedIndexChangedMethod();
    }
    void DdlVillageName_SelectedIndexChangedMethod()
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
        }
        else
        {
            LblMsgVillageName.Text = String.Join(",", VillageName_list.ToArray());
            LblMsgVillageValue.Text = String.Join(",", VillageID_list.ToArray());
        }

        //BindFamilyHeadNameOnBasisVillageID(VillageID);
        //BindCdpAgencyNameOnBasisVillageID(VillageID);
    }
    protected void DdlVillageName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlVillageName_SelectedIndexChangedMethod();
    }
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        Session.Remove("CtextState");
        Session.Remove("CvalueState");
        Session.Remove("CtextTigerReserve");
        Session.Remove("CvalueTigerReserve");
        Session.Remove("CtextVillage");
        Session.Remove("CvalueVillage");
        Session.Remove("PageIndex");
        Session.Remove("GridSelectedColumn");
        Session.Remove("sPageIndex");
        LblMsgStateName.Text = "You have not selected.";
        LblMsgStateValue.Text = "You have not selected.";

        LblMsgTigerReserveName.Text = "You have not selected.";
        LblMsgTigerReserveValue.Text = "You have not selected.";

        LblMsgVillageName.Text = "You have not selected.";
        LblMsgVillageValue.Text = "You have not selected.";


        Response.Redirect("~/auth/adminpanel/MisReportDashBoard.aspx");
    }
    
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Search = 1;
        //---------------------------

        Session["CtextState"] = LblMsgStateName.Text.Trim();
        Session["CvalueState"] = LblMsgStateValue.Text.Trim();

        Session["CtextTigerReserve"] = LblMsgTigerReserveName.Text.Trim();
        Session["CvalueTigerReserve"] = LblMsgTigerReserveValue.Text.Trim();

        Session["CtextVillage"] = LblMsgVillageName.Text.Trim();
        Session["CvalueVillage"] = LblMsgVillageValue.Text.Trim();
        //---------------------------------------
        if (Search == 1)
        {
            GridViewNarenConsoldateReport.AllowPaging = true;
        }
        else
        {
            GridViewNarenConsoldateReport.AllowPaging = true;
        }
        ConsolDateReport();

        //gvSpectrum.Columns[columnindex].Visible = false;
        ////OR
        //gvSpectrum.Columns["columnname"].Visible = false;
       


        //columns hide if tiger reserve has Counter is 0.
        //  GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        // Label NoOfTigerReserve = row.FindControl("LblTigerReserve") as Label;

        //foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
        //{
        //    Label NoOfTigerReserve = (Label)row.FindControl("LblTigerReserve");
        //    if(NoOfTigerReserve.Text=="0")
        //    {
        //        GridViewNarenConsoldateReport.Rows[2].Visible = false;
        //    }
        //}

        //
    }
    
    public void GridViewColumnHideShowBelowGridWhenFormReturn()
    {
        #region[GridColumn visible false and true function]
        string items = string.Empty;
        string notSelected = string.Empty;


        #endregion
    }
  
    #region[Start Export section]
    protected void btn_print_Click(object sender, EventArgs e)
    {

        printGrid();
        if (Session["UserType"].ToString() == "1")
        {

            ConsolDateReport();
        }

    }
    void printGrid()
    {

        GridViewNarenConsoldateReport.DataSource = ViewState["Data"];
        GridViewNarenConsoldateReport.AllowPaging = false;
        GridViewNarenConsoldateReport.DataBind();
        DataSet Ds = (DataSet)ViewState["Data"];
        GridViewNumericCalculation4(Ds);
        foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
        {
            //------------start Removing link button
            Label Lblv = (Label)row.FindControl("LblVillage");
            Lblv.Visible = true;
            LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
            Lnkv.Visible = false;
            //LblFamilyhead,LnkFamilyhead
            Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
            LblFamilyhead.Visible = true;
            LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
            LnkFamilyhead.Visible = false;
            //LblExecutiveAgency,LnkExecutiveAgency
            Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
            LblExecutiveAgency.Visible = true;
            LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
            LnkExecutiveAgency.Visible = false;
            //LblRelocationStatus,LnkRelocationStatus
            Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
            LblRelocationStatus.Visible = true;
            LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
            LnkRelocationStatus.Visible = false;
            //LblMap,LnkMap
            Label LblMap = (Label)row.FindControl("LblMap");
            LblMap.Visible = true;
            LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
            LnkMap.Visible = false;
            //LblRelocationProgressReport,LnkRelocationProgressReport
            Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
            LblRelocationProgressReport.Visible = true;
            LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
            LnkRelocationProgressReport.Visible = false;
            //LblNGO,LnkNGO
            Label LblNGO = (Label)row.FindControl("LblNGO");
            LblNGO.Visible = true;
            LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
            LnkNGO.Visible = false;
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
        sb.Append(" Village Progress Report ");
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
        Response.AddHeader("content-disposition", "attachment;filename=" + "Consolidate Report" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteLine("<h1 style=\"text-align:center;\">Consolidate Report of NTCA_MIS</h1>");
            hw.WriteLine("<br>");
            //To Export all pages

            GridViewNarenConsoldateReport.AllowPaging = false;
            ConsolDateReport();
            GridViewNarenConsoldateReport.HeaderRow.BackColor = System.Drawing.Color.Black;
            foreach (TableCell cell in GridViewNarenConsoldateReport.HeaderRow.Cells)
            {
                cell.BackColor = GridViewNarenConsoldateReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
            {
                //------------start Removing link button
                Label Lblv = (Label)row.FindControl("LblVillage");
                Lblv.Visible = true;
                LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
                Lnkv.Visible = false;
                //LblFamilyhead,LnkFamilyhead
                Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
                LblFamilyhead.Visible = true;
                LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
                LnkFamilyhead.Visible = false;
                //LblExecutiveAgency,LnkExecutiveAgency
                Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
                LblExecutiveAgency.Visible = true;
                LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
                LnkExecutiveAgency.Visible = false;
                //LblRelocationStatus,LnkRelocationStatus
                Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
                LblRelocationStatus.Visible = true;
                LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
                LnkRelocationStatus.Visible = false;
                //LblMap,LnkMap
                Label LblMap = (Label)row.FindControl("LblMap");
                LblMap.Visible = true;
                LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
                LnkMap.Visible = false;
                //LblRelocationProgressReport,LnkRelocationProgressReport
                Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
                LblRelocationProgressReport.Visible = true;
                LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
                LnkRelocationProgressReport.Visible = false;
                //LblNGO,LnkNGO
                Label LblNGO = (Label)row.FindControl("LblNGO");
                LblNGO.Visible = true;
                LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
                LnkNGO.Visible = false;
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
                hw.WriteLine("<h1 style=\"text-align:center;\">Consolidate Report of NTCA_MIS</h1>");
                hw.WriteLine("<br>");
                //To Export all pages
                GridViewNarenConsoldateReport.AllowPaging = false;
                //  this.BindGrid();
                if (Session["UserType"].ToString() == "1")
                {

                    this.ConsolDateReport();
                }
                foreach (GridViewRow row in GridViewNarenConsoldateReport.Rows)
                {
                    //------------start Removing link button
                    Label Lblv = (Label)row.FindControl("LblVillage");
                    Lblv.Visible = true;
                    LinkButton Lnkv = (LinkButton)row.FindControl("LnkVillage");
                    Lnkv.Visible = false;
                    //LblFamilyhead,LnkFamilyhead
                    Label LblFamilyhead = (Label)row.FindControl("LblFamilyhead");
                    LblFamilyhead.Visible = true;
                    LinkButton LnkFamilyhead = (LinkButton)row.FindControl("LnkFamilyhead");
                    LnkFamilyhead.Visible = false;
                    //LblExecutiveAgency,LnkExecutiveAgency
                    Label LblExecutiveAgency = (Label)row.FindControl("LblExecutiveAgency");
                    LblExecutiveAgency.Visible = true;
                    LinkButton LnkExecutiveAgency = (LinkButton)row.FindControl("LnkExecutiveAgency");
                    LnkExecutiveAgency.Visible = false;
                    //LblRelocationStatus,LnkRelocationStatus
                    Label LblRelocationStatus = (Label)row.FindControl("LblRelocationStatus");
                    LblRelocationStatus.Visible = true;
                    LinkButton LnkRelocationStatus = (LinkButton)row.FindControl("LnkRelocationStatus");
                    LnkRelocationStatus.Visible = false;
                    //LblMap,LnkMap
                    Label LblMap = (Label)row.FindControl("LblMap");
                    LblMap.Visible = true;
                    LinkButton LnkMap = (LinkButton)row.FindControl("LnkMap");
                    LnkMap.Visible = false;
                    //LblRelocationProgressReport,LnkRelocationProgressReport
                    Label LblRelocationProgressReport = (Label)row.FindControl("LblRelocationProgressReport");
                    LblRelocationProgressReport.Visible = true;
                    LinkButton LnkRelocationProgressReport = (LinkButton)row.FindControl("LnkRelocationProgressReport");
                    LnkRelocationProgressReport.Visible = false;
                    //LblNGO,LnkNGO
                    Label LblNGO = (Label)row.FindControl("LblNGO");
                    LblNGO.Visible = true;
                    LinkButton LnkNGO = (LinkButton)row.FindControl("LnkNGO");
                    LnkNGO.Visible = false;
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
                Response.AddHeader("content-disposition", "attachment;filename=ConsolidateReport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }//
    #endregion[End Export section]
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        Search = 0;
        if (Search == 0)
        {
            GridViewNarenConsoldateReport.AllowPaging = true;
        }
        Session.Remove("CtextState");
        Session.Remove("CvalueState");
        Session.Remove("CtextTigerReserve");
        Session.Remove("CvalueTigerReserve");
        Session.Remove("CtextVillage");
        Session.Remove("CvalueVillage");
        Session.Remove("PageIndex");
        Session.Remove("GridSelectedColumn");
        Session.Remove("sPageIndex");
        LblMsgStateName.Text = "You have not selected.";
        LblMsgStateValue.Text = "You have not selected.";

        LblMsgTigerReserveName.Text = "You have not selected.";
        LblMsgTigerReserveValue.Text = "You have not selected.";

        LblMsgVillageName.Text = "You have not selected.";
        LblMsgVillageValue.Text = "You have not selected.";



        BindDdlCheckboxIntoStateName();

        ConsolDateReport();

        

    }
    protected void GridViewNarenConsoldateReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (Search == 1)
        //{
        //    GridViewNarenConsoldateReport.AllowPaging = true;
        //    foreach (GridViewRow rw in GridViewNarenConsoldateReport.Rows)
        //    {
        //        Label tx = (Label)rw.FindControl("LblTigerReserve");

        //        if (tx.Text == "0")
        //            rw.Visible = false;

        //    }

        //}
        //else
        //{
        //    GridViewNarenConsoldateReport.AllowPaging = true;
        //}
    }
}
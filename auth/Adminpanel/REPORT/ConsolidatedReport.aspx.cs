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
public partial class auth_Adminpanel_REPORT_ConsolidatedReport : CrsfBase
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStateName();
            StateNameParentGridView();
            //TigerReserveNameChildGridView();
            //VillageListChildGridView(null, 5);
        }
    }
    void StateNameParentGridView()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        _objNtcauser.StateID = null;     
        P_var.dSet = _commanfuction.ConsoldateReportGetStateName(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            Naren_GridViewParentStateName.Visible = true;
            Naren_GridViewParentStateName.DataSource = P_var.dSet.Tables[0];
            //lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
            
            Naren_GridViewParentStateName.DataBind();
            NarenDivMessageError.Visible = false;
            Naren_GridViewParentStateName.Caption ="Total State count:"+ Naren_GridViewParentStateName.Rows.Count.ToString();
           // Naren_GridViewParentStateName.ForeColor = System.Drawing.Color.Green;
            
        }
        else
        {
            NarenDivMessageError.Visible = true;
            Naren_GridViewParentStateName.Visible = false;
            //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    DataSet TigerReserveNameChildGridView(string StateName,int StateID)
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        _objNtcauser.StateName = StateName;
        _objNtcauser.StateID = StateID;
       return P_var.dSet = _commanfuction.ConsoldateReportGetTigerReserveName(_objNtcauser);
      
    }
    DataSet VillageListChildGridView(string TigerReserveName, int StateID)
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        _objNtcauser.StateName = TigerReserveName;
        _objNtcauser.StateID = StateID;
        return P_var.dSet = _commanfuction.ConsoldateReportGetVillageLIst(_objNtcauser);

    }
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        // P_var.dSet = _commanfuction.BindDdlStateBarChart(_objNtcauser);
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "StateName";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
    }
    void BindTigerReserveName1()
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

                        ErrorChkTigerReserveName.Text = "";
                        try
                        {
                            string StateName = string.Empty;
                            if (DdlStateName.SelectedValue != "0")
                            {
                                StateName = DdlStateName.SelectedValue;
                            }
                            else
                            {
                                StateName = null;
                            }
                            ChkTigerReserveName.Items.Clear();
                            //  ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                            if (StateName != null)
                            {
                                DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(StateName);
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                    ChkTigerReserveName.DataSource = ds.Tables[0];
                                    ChkTigerReserveName.DataTextField = "TigerReserveName";
                                    ChkTigerReserveName.DataValueField = "TigerReserveid";
                                    ChkTigerReserveName.DataBind();

                                    //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
                                }
                                else
                                {

                                    ChkTigerReserveName.Items.Clear();
                                    ErrorChkTigerReserveName.Text = "--No Record Found--";
                                    // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
                                }
                            }
                            else
                            {
                                ChkTigerReserveName.Items.Clear();
                                ErrorChkTigerReserveName.Text = "--No Record Found--";
                            }
                        }
                        catch (Exception er)
                        {
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
    protected void Naren_GridViewParentStateName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Naren_GridViewParentStateName.PageIndex = e.NewPageIndex;
        this.StateNameParentGridView();
    }

    protected void Naren_GridViewParentStateName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Int32 iStateID =Convert.ToInt32(Naren_GridViewParentStateName.DataKeys[e.Row.RowIndex].Value.ToString());
            
            Project_Variables P_var = new Project_Variables();

            #region [Tiger reseve list]
            GridView ObjgvTigerReserveName = e.Row.FindControl("gvTigerReserveName") as GridView;
            P_var.dSet = null;
            P_var.dSet = TigerReserveNameChildGridView(null, iStateID);
            if (P_var.dSet.Tables[0].Rows.Count > 0)
            {
                ObjgvTigerReserveName.Visible = true;
                ObjgvTigerReserveName.DataSource = P_var.dSet.Tables[0];
                ObjgvTigerReserveName.DataBind();
                ObjgvTigerReserveName.Caption = "Total Tiger Reserve count:" + ObjgvTigerReserveName.Rows.Count.ToString();
            }
            else
            {
                ObjgvTigerReserveName.Visible = false;
            }
            #endregion
            #region [Village list]
            GridView ObjGvVillageList = e.Row.FindControl("GvVillageList") as GridView;
            P_var.dSet = null;
            P_var.dSet = VillageListChildGridView(null, iStateID);
            if (P_var.dSet.Tables[0].Rows.Count > 0)
            {
                ObjGvVillageList.Visible = true;
                ObjGvVillageList.DataSource = P_var.dSet.Tables[0];
                ObjGvVillageList.DataBind();
                ObjGvVillageList.Caption = "Total village count:" + ObjGvVillageList.Rows.Count.ToString();
            }
            else
            {
                ObjGvVillageList.Visible = false;
            }
            #endregion
        }
    }
}
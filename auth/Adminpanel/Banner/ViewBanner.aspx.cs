using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Banner_ViewBanner : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    ContentOB contentObject = new ContentOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    BannerManagementBL bannerBL = new BannerManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    string LoginUserid;
    int LoginUsertype;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        LoginUserid = m.Id;
        LoginUsertype = m.UserType;
        if (!IsPostBack)
        {

            DisplayStateName();
            Bind_TigerReserveUserAccess();
            bindStatusInDropdownlist();
            ddlState.Enabled = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
            ddlTigerReserve.Enabled = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
            if (Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "4")
            {
                ddlwebsite.Enabled = false;
                ddlwebsite.Items.Remove(ddlwebsite.Items.FindByValue("1"));
               // ddlwebsite_SelectedIndexChanged(this, EventArgs.Empty);
                ddlTigerReserve.Enabled = true;
                //int TigerReserveID = Convert.ToInt32(Session["ntca_TigerReserveid"]);
                //ddlTigerReserve.SelectedValue = TigerReserveID.ToString();
                ddlTigerReserve.Enabled = false;
                if(Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "3")
                {
                    ddlTigerReserve.Enabled = true;
                }
                else
                {
                    int TigerReserveID = Convert.ToInt32(Session["ntca_TigerReserveid"]);
                    ddlTigerReserve.SelectedValue = TigerReserveID.ToString();
                }
            }
        }
    }

    protected void grdBanner_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdBanner_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        int id = Convert.ToInt32(e.CommandArgument);
                        if (e.CommandName == "Delete")
                        {

                            contentObject.TempLinkID = id;
                            contentObject.LinkID = id;
                            contentObject.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);


                            int del = MiddleContentBL.DelMiddlContent(contentObject);
                            if (del > 0)
                            {
                                Session["msg"] = "Banner has been deleted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Banner has not been deleted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
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
        //}
    }

        
    

    protected void grdBanner_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdBanner.HeaderRow.FindControl("chkSelectAll");
            //Add client side function childclick on check boxes
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));

        }
    }

    protected void grdBanner_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.Image img = e.Row.FindControl("imgedit") as System.Web.UI.WebControls.Image;
            System.Web.UI.WebControls.Image img1 = e.Row.FindControl("emgnotedit") as System.Web.UI.WebControls.Image;
            contentObject.LinkTypeID = Convert.ToInt32(grdBanner.DataKeys[e.Row.RowIndex].Value);
            p_Var.dSet = contentBL.getApproveContentForEDit(contentObject);


            for (int i = 0; i < p_Var.dSet.Tables[0].Rows.Count; i++)
            {
                if (p_Var.dSet.Tables[0].Rows[i]["Link_Id"] != DBNull.Value)
                {

                    if (Convert.ToInt32(grdBanner.DataKeys[e.Row.RowIndex].Value) == Convert.ToInt16(p_Var.dSet.Tables[0].Rows[i]["Link_Id"]))
                    {

                        img.Visible = false;
                        img1.Visible = true;
                        img1.Height = 10;
                        img1.Width = 10;


                    }
                    else
                    {
                        img1.Visible = false;
                        img.Visible = true;
                    }

                }
            }
        }
    }


    #region Function to bind state name in dropdownlist

    private void DisplayStateName()
    {
            objntcauser.UserID = Convert.ToInt32(LoginUserid);
            p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
            ddlState.DataSource = p_Var.dSet;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
            if (LoginUsertype == 1)
            {
                ddlState.Items.Insert(0, new ListItem("Select State", "0"));

            }
        
    }
               
    

    #endregion

    #region Function to bind tiger reserve name in dropdownlist

    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlState.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_PermissionModified(objntcauser);


        ddlTigerReserve.DataSource = p_Var.dSet;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    #endregion

    #region Function to bind status in dropdownlist

    private void bindStatusInDropdownlist()
    {
        contentObject.StatusID = null;
        p_Var.dSet = contentBL.getWorkStatusBanner(contentObject);
        ddlStatus.DataSource = p_Var.dSet;
        ddlStatus.DataTextField = "Status";
        ddlStatus.DataValueField = "Statusid";
        ddlStatus.DataBind();
    }

    #endregion

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        divGrid.Visible = false;
    }

    protected void btnApprove_Click(object sender, EventArgs e)
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

                        ApproveContent();
                    }
                }
            }
        }

        catch
        {
            throw;
        }
        //}
    }
    bool ChkVal()
    {
        LblMsg.Text = "";
        bool chk = true;

        if (ddlState.SelectedValue == "0")
        {
            LblMsg.Text = "Please select state";
            LblMsg.ForeColor = System.Drawing.Color.Red;
            ddlState.Focus();
            return chk = false;
        }
        if (ddlTigerReserve.SelectedValue == "0")
        {
            LblMsg.Text = "Please select Tiger reserve";
            LblMsg.ForeColor = System.Drawing.Color.Red;
            ddlTigerReserve.Focus();
            return chk = false;
        }
        return chk;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlwebsite.SelectedValue == "1")
        {
            if (ddlStatus.SelectedValue == "5")
            {
                btnApprove.Visible = false;
            }
            else
            {
                btnApprove.Visible = true;
            }
            BindGrid(Convert.ToInt16(ddlStatus.SelectedValue));
        }
        else
        {
            if(ChkVal()==true)
            {
                if (ddlStatus.SelectedValue == "5")
                {
                    btnApprove.Visible = false;
                }
                else
                {
                    btnApprove.Visible = true;
                }
                BindGrid(Convert.ToInt16(ddlStatus.SelectedValue));
            }
        }
    }

    #region Function to bind gridView

    public void BindGrid(int statusid)
    {
        LblMsg.Text = "";
        try
        {
            if (ddlStatus.SelectedValue == "0")
            {
                grdBanner.Visible = false;
               
            }
            else
            {
                grdBanner.Visible = true;
                //contentObject.LangId = langid;
                contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                contentObject.StatusID = statusid;
                contentObject.ModuleID = (int)Module_ID_Enum.Project_Module_ID.Banner;
                contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
                p_Var.dsFileName = bannerBL.GetBannerData(contentObject);
                if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    divGrid.Visible = true;
                    grdBanner.DataSource = p_Var.dsFileName;
                    grdBanner.DataBind();
                    p_Var.dSet = null;

                    p_Var.dSet = null;
                   // lblmsg.Visible = false;

                }
                else
                {
                    LblMsg.Text = "Record not found!.Please choose correct label option as per as your correct need!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    divGrid.Visible = false;
                }
            }
        }


        catch
        {
            throw;
        }
    }

    #endregion

    #region This function is used to check the approve and disapprove the data

    public void ApproveContent()
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
                            //try
                            //{
                                foreach (GridViewRow row in grdBanner.Rows)
                                {
                                    CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
                                    if ((selCheck.Checked == true))
                                    {
                                        contentObject.TempLinkID = Convert.ToInt32(grdBanner.DataKeys[row.RowIndex].Value);
                                        contentObject.LastUpdatedBy = Convert.ToInt16(Session["User_Id"]);
                                        p_Var.Result = contentBL.ApproveContent(contentObject);


                                    }
                                }
                                if (p_Var.Result > 0)
                                {
                                    Session["msg"] = "Banner has been approved successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");

                                }

                                else
                                {
                                    Session["msg"] = "Banner has not been approved successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                            //}
                           // catch
                            //{
                                //throw;
                           // }
                            
                        }
                    }
                }
            }

            catch
            {
                throw;
            }
 	   //}


     



    }

    #endregion 
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlwebsite.SelectedValue=="1")
        {
            StartState.Visible = false;
            StarReserve.Visible = false;
        }
        else
        {
            StartState.Visible = true;
            StarReserve.Visible = true;
        }
        ddlState.SelectedValue = Convert.ToInt32(ddlwebsite.SelectedValue) == 1 ? "0" : ddlState.SelectedValue;
        ddlState.Enabled = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);

        ddlTigerReserve.SelectedValue = Convert.ToInt32(ddlwebsite.SelectedValue) == 1 ? "0" : ddlTigerReserve.SelectedValue;
        ddlTigerReserve.Enabled = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }
    protected void grdBanner_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid(Convert.ToInt16(ddlStatus.SelectedValue));
        if(ddlStatus.SelectedValue=="5")
        {
            btnApprove.Visible = false;
        }
        else
        {
            btnApprove.Visible = true;
        }
    }
}
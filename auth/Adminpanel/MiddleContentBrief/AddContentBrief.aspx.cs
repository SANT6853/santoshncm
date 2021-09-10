using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_MiddleContentBrief_AddContentBrief : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables p_Var = new Project_Variables();
    MiddleContentBL middlContentBL = new MiddleContentBL();
    Content_ManagementBL contentBL=new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    ContentOB contentObject = new ContentOB();
    Commanfuction _commanfucation = new Commanfuction();
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
            divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
            divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        }
       

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }

    protected void btnsave_Click(object sender, EventArgs e)
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

                        InsertMiddlContent();
                    }

                }
            }
        }

        catch
        {
            throw;
        }
      // }
    }
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        
    }

    

    //Area for all the user defined functions

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

    #region Function to insert the record

    public void InsertMiddlContent()
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

                    //if (Page.IsValid)
                    //
                    if (Page.IsValid)
                        {
                            contentObject.ActionType = 1;
                            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
                            contentObject.Name = HttpUtility.HtmlEncode(txtTitle.Text);
                            contentObject.NameRegional = HttpUtility.HtmlEncode(txtTitleHindi.Text);
                            contentObject.AltTag = HttpUtility.HtmlEncode(txtAltTag.Text);
                            contentObject.AltTagReg = HttpUtility.HtmlEncode(txtAltTagHindi.Text);
                            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                            contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            //start 22march2018
                            contentObject.details = miscellBL.RemoveUnnecessaryHtmlTagHtml(FCKeditor1.Value);
                            contentObject.SmallDetails = HttpUtility.HtmlEncode(TxtSmallDetails.Text.Trim());
                            //end 22march2018


                            int insertdata = middlContentBL.insertMiddlContent(contentObject);
                            if (insertdata > 0)
                            {
                                Session["msg"] = "Middle Content has been submitted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/MiddleContentBrief/ViewContentBrief.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Middle Content has not been submitted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/MiddleContentBrief/ViewContentBrief.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }

                        }
                }
            }
        }

        catch
        {
            throw;
        }
      // }
    }

    

    #endregion

    #region Function to upload image

    

    #endregion
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        divstate.Visible =  (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        divTigerReserve.Visible =  (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_MiddleContentBrief_ContentBriefEdit : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables p_Var = new Project_Variables();
    MiddleContentBL middlecontetnBL = new MiddleContentBL();
    Content_ManagementBL contentBL = new Content_ManagementBL();
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
           
            string Querystring = Request.QueryString["id"].ToString();
           
            Display(Querystring);
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
        p_Var.dSetCompare = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddlTigerReserve.DataSource = p_Var.dSetCompare;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }
    #endregion

    #region function to display banner record in edit mode

    public void Display(string id)
    {
        contentObject.StatusID = Convert.ToInt16(Request.QueryString["statusID"]);
        contentObject.TempLinkID = Convert.ToInt32(id);
        p_Var.dsFileName = middlecontetnBL.DisplayMiddleContent_AtEdit(contentObject);
        ddlwebsite.SelectedValue = p_Var.dsFileName.Tables[0].Rows[0]["WebsiteID"].ToString();
        txtTitle.Text =HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[0]["Name"].ToString());
        TxtSmallDetails.Text = HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[0]["SmallDetails"].ToString());
        FCKeditor1.Value = p_Var.dsFileName.Tables[0].Rows[0]["Details"].ToString();
        txtAltTag.Text =HttpUtility.HtmlDecode( p_Var.dsFileName.Tables[0].Rows[0]["Alt_Tag"].ToString());
        txtAltTagHindi.Text =HttpUtility.HtmlDecode( p_Var.dsFileName.Tables[0].Rows[0]["AltTag_Reg"].ToString());
        txtTitleHindi.Text =HttpUtility.HtmlDecode( p_Var.dsFileName.Tables[0].Rows[0]["Name_Reg"].ToString());
        ddlState.SelectedValue = Convert.ToString(p_Var.dsFileName.Tables[0].Rows[0]["Stateid"]);
        Bind_TigerReserveUserAccess();
        ddlTigerReserve.SelectedValue = Convert.ToString(p_Var.dsFileName.Tables[0].Rows[0]["TigerReserveid"]);
       // LblImage.Text = p_Var.dsFileName.Tables[0].Rows[0]["Image_Name"].ToString();
        divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }

    #endregion

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Update_Data();
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/AdminPanel/MiddleContentBrief/ViewContentBrief.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent));
    }

    #region Function to update banner

    public void Update_Data()
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
                    //{

                        if (Page.IsValid)
                        {
                            contentObject.ActionType = 2;
                            contentObject.TempLinkID = Convert.ToInt32(Request.QueryString["id"]);
                            contentObject.StatusID = Convert.ToInt32(Request.QueryString["statusID"]);
                            contentObject.Name = HttpUtility.HtmlEncode(txtTitle.Text);
                            contentObject.AltTag = HttpUtility.HtmlEncode(txtAltTag.Text);
                            contentObject.SmallDetails = HttpUtility.HtmlEncode(TxtSmallDetails.Text.Trim());
                            contentObject.details = FCKeditor1.Value;
                            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);

                            contentObject.NameRegional = HttpUtility.HtmlEncode(txtTitleHindi.Text);
                            contentObject.AltTagReg = HttpUtility.HtmlEncode(txtAltTagHindi.Text);

                            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.MiddleContent);
                            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                            contentObject.LinkID = Convert.ToInt32(Request.QueryString["id"]);

                            int updateData = middlecontetnBL.UpdateMiddleContentData(contentObject);

                            if (updateData > 0)
                            {
                                Session["msg"] = "Middle content has been updated successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/MiddleContentBrief/ViewContentBrief.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Middle content has not been updated successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/MiddleContentBrief/ViewContentBrief.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
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

    
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }
}
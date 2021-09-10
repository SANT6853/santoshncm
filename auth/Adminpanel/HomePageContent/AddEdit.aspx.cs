using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_HomePageContent_AddEdit : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables p_Var = new Project_Variables();
    BannerManagementBL bannerBL = new BannerManagementBL();
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
            Bind_TigerReserveUserAccess();
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        InsertBanner();


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
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddlTigerReserve.DataSource = p_Var.dSet;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }


    #endregion

    #region Function to insert the record

    public void InsertBanner()
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
                            contentObject.ActionType = 1;

                            contentObject.details = HttpUtility.HtmlEncode(FCKeditor1.Value);

                            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.HomePage);
                            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                            contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            //contentObject.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
                            string fileName = string.Empty;

                            int insertdata = bannerBL.insertBanner(contentObject);
                            if (insertdata > 0)
                            {
                                Session["msg"] = "Home Page content has been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/HomePageContent/HomePageContent.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.HomePage);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Banner has not been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/HomePageContent/HomePageContent.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.HomePage);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }

                      //  }
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
}

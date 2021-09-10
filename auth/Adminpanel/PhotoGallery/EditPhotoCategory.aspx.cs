using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_PhotoGallery_EditPhotoCategory : CrsfBase
{
    #region DAta declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    PhotoGalleryBL photoCategoryBL = new PhotoGalleryBL();
    PhotoGalleryOB photoCategoryObject = new PhotoGalleryOB();
    UserBL userBL = new UserBL();
    NtcaUserOB obj_userOB = new NtcaUserOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
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
            display_Category_in_UpdateMode();
        }
    }

    #region Function to display record in edit mode

    public void display_Category_in_UpdateMode()
    {
        photoCategoryObject.StatusID = Convert.ToInt32(Request.QueryString["Status"]);
        photoCategoryObject.TempMCategoryID = Convert.ToInt32(Request.QueryString["id"]);
        p_Var.dSet = photoCategoryBL.DisplayPhotoCategoriesinEdit(photoCategoryObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            txtCategoryName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["CatName"].ToString());
            txtCategoryNameHindi.Text= HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["CaNametHindi"].ToString());
            ddlState.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["StateID"].ToString();
            Bind_TigerReserveUserAccess();
            ddlTigerReserve.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["TigerReserveid"].ToString();

        }
    }

    #endregion

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

                        updatedata();
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

    #region Function to update category record 

    public void updatedata()
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

                        //   try
                        // {
                        photoCategoryObject.TempCategoryID = Convert.ToInt32(Request.QueryString["id"]);
                        photoCategoryObject.StatusID = Convert.ToInt32(Request.QueryString["Status"]);
                        // p_Var.dSet = photoCategoryBL.DisplayPhotoCategoriesinEdit(photoCategoryObject);
                        photoCategoryObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.update);
                        //if (p_Var.dSet.Tables[0].Rows[0]["CategoryId"] != DBNull.Value)
                        //{
                        //    photoCategoryObject.CategoryID = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["CategoryId"]);
                        //}
                        //else
                        //{
                        //    photoCategoryObject.MCategoryID = null;
                        //}
                        photoCategoryObject.CategoryName = HttpUtility.HtmlEncode(txtCategoryName.Text);
                        photoCategoryObject.CategoryNameHindi = HttpUtility.HtmlEncode(txtCategoryNameHindi.Text);

                        //photoCategoryObject.UserID = Convert.ToInt16(Session["User_Id"]);

                        photoCategoryObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                        photoCategoryObject.TigerReserveID = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                        photoCategoryObject.ModuleId = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                        photoCategoryObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                        photoCategoryObject.IPAddress = miscellBL.IpAddress();
                        p_Var.Result = photoCategoryBL.InsertUpdatePhotoCategory(photoCategoryObject);
                        if (p_Var.Result > 0)
                        {

                            Session["msg"] = "Category has been updated successfully.";
                            Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoCategory.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        }
                        else
                        {
                            //edlblmsg.Text = "An error occurred.";
                            //edlblmsg.ForeColor = Color.Red;
                        }
                        //    }
                        //    catch
                        //    {
                        //        throw;
                        //    }
                        //}
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_PhotoGallery_AddPhotoCategory : CrsfBase
{
    #region DAta declaration zone

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    PhotoGalleryBL photoCategoryBL= new PhotoGalleryBL();
    PhotoGalleryOB photoCategoryObject=new PhotoGalleryOB();
    UserBL userBL = new UserBL();
    NtcaUserOB obj_userOB = new NtcaUserOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    ContentOB contentObject = new ContentOB();
    Commanfuction _commanfucation = new Commanfuction();
    string LoginUserid;
    int LoginUsertype;

    #endregion

    #region Page load event zone
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

                       // try
                       // {

                            photoCategoryObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
                            photoCategoryObject.CategoryName = HttpUtility.HtmlEncode(txtCategoryName.Text);
                            photoCategoryObject.CategoryNameHindi = HttpUtility.HtmlEncode(txtCategoryNameHindi.Text);
                            photoCategoryObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            photoCategoryObject.TigerReserveID = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                            photoCategoryObject.ModuleId = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                            photoCategoryObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            photoCategoryObject.IPAddress = miscellBL.IpAddress();
                            int tempInsert = photoCategoryBL.InsertUpdatePhotoCategory(photoCategoryObject);

                            if (tempInsert > 0)
                            {
                                Session["msg"] = "Banner has been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoCategory.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Banner has not been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoCategory.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                        //}

                        //catch
                        //{
                        //    throw;
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
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
       
    }

    //Area for all the user defined functions

    #region Function to bind state name in dropdownlist

    private void DisplayStateName()
    {

        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(obj_userOB);
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
        obj_userOB.UserType = LoginUsertype;
        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        obj_userOB.State = Convert.ToInt32(ddlState.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(obj_userOB);
        ddlTigerReserve.DataSource = p_Var.dSet;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    #endregion



    //END
}
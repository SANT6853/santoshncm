using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_PhotoGallery_ViewPhotoCategory : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();

    Content_ManagementBL contentBL = new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    ContentOB contentObject = new ContentOB();
    Project_Variables p_Var = new Project_Variables();
    PhotoGalleryBL photoCategoryBL = new PhotoGalleryBL();
    PhotoGalleryOB photoCategoryObject = new PhotoGalleryOB();
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
            bindStatusInDropdownlist();

        }
    }

    protected void grdCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdCategory_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdCategory.HeaderRow.FindControl("chkSelectAll");
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        divGrid.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindPhotoCategory(1);
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
                        ChkApprove_Disapprove();
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

    #region Function to bind status in dropdownlist

    private void bindStatusInDropdownlist()
    {
        contentObject.StatusID = null;
        p_Var.dSet = contentBL.getWorkStatus(contentObject);
        ddlStatus.DataSource = p_Var.dSet;
        ddlStatus.DataTextField = "Status";
        ddlStatus.DataValueField = "Statusid";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("Select Status", "0"));
    }

    #endregion

    #region Function to display the category in a gridview

    public void bindPhotoCategory(int pageIndex)
    {
        if (ddlStatus.SelectedValue == "0")
        {
            grdCategory.Visible = false;
            btnApprove.Visible = false;
        }
        else
        {
            photoCategoryObject.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
            photoCategoryObject.TigerReserveID= Convert.ToInt32(ddlTigerReserve.SelectedValue);
            photoCategoryObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
            photoCategoryObject.ModuleId=Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
            //photoCategoryObject.PageIndex = pageIndex;
            //photoCategoryObject.PageSize = Convert.ToInt16(ddlPageSize.SelectedValue);
            //photoCategoryObject.LangID = Convert.ToInt32(ddlLanguage.SelectedValue);
            p_Var.dSet = photoCategoryBL.DisplayPhotoCategories(photoCategoryObject, out p_Var.k);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                //rptPager.Visible = true;
                //ddlPageSize.Visible = true;
                //lblPageSize.Visible = true;
                //grdCategory.Visible = true;
                //spanPazeSize.Visible = true;
                divGrid.Visible = true;
                grdCategory.DataSource = p_Var.dSet;
                grdCategory.DataBind();
                p_Var.dSet = null;
                //code for checking category is present in temp table or not

                if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.Approved))
                {
                    grdCategory.Columns[0].Visible = false;
                    foreach (GridViewRow row in grdCategory.Rows)
                    {
                        Image imgedit = (Image)row.FindControl("imgEdit");
                        Image imgnotedit = (Image)row.FindControl("imgnotedit");
                        Label lblMCategoryID = (Label)row.FindControl("lblMCategory_ID");
                        photoCategoryObject.MCategoryID = Convert.ToInt16(lblMCategoryID.Text);
                        //p_Var.dSetCompare = obj_catBL.Category_ID_For_Comparison(photoCategoryObject);
                        //for (p_Var.i = 0; p_Var.i < p_Var.dSetCompare.Tables[0].Rows.Count; p_Var.i++)
                        //{
                        //    if (p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["MCategoryId"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt16(lblMCategoryID.Text) == Convert.ToInt16(p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["MCategoryId"]))
                        //        {
                        //            imgnotedit.Visible = true;
                        //            imgedit.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            imgnotedit.Visible = false;
                        //            imgedit.Visible = true;
                        //        }
                        //    }
                        //}
                    }
                }

                //end

               // lblmsg.Text = "";
                //obj_userOB.RoleId = Convert.ToInt32(Session["Role_Id"]);
                photoCategoryObject.ModuleId = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                //p_Var.dSet = miscellBL.getLanguagePermission(obj_userOB);
                //if (p_Var.dSet.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Permission_ID.Approved))
                //    {
                //        grdCategory.Columns[0].Visible = false;
                //    }
                //    else
                //    {
                //        grdCategory.Columns[0].Visible = true;
                //    }
                //    if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Permission_ID.draft))
                //    {
                //        btnForApprove.Visible = true;
                      
                //    }
                  
                //    else
                //    {
                //        btnForApprove.Visible = false;
                //        btnDisApprove.Visible = false;
                //        //BtnForReview.Visible = false;
                //    }
                  
                //    if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Permission_ID.ForApprover))
                //    {
                //        btnApprove.Visible = true;
                //        btnDisApprove.Visible = true;
                //        btnForApprove.Visible = false;
                //    }
                //    else
                //    {

                //        btnApprove.Visible = false;
                //    }
                //    if (Convert.ToBoolean(p_Var.dSet.Tables[0].Rows[0][6]) == true)
                //    {
                //        grdCategory.Columns[3].Visible = true;
                //    }
                //    else
                //    {
                //        grdCategory.Columns[3].Visible = false;
                //    }
                //    if (Convert.ToBoolean(p_Var.dSet.Tables[0].Rows[0][7]) == true)
                //    {
                //        grdCategory.Columns[4].Visible = true;
                //    }
                //    else
                //    {
                //        grdCategory.Columns[4].Visible = false;
                //    }
                //}
                //else
                //{
                //    BtnForReview.Visible = false;
                //    btnForApprove.Visible = false;
                //    btnApprove.Visible = false;
                //    spanPazeSize.Visible = false;

                //}
                p_Var.dSet = null;
               // lblmsg.Visible = false;
            }
            else
            {
                //rptPager.Visible = false;
                //ddlPageSize.Visible = false;
                //lblPageSize.Visible = false;
                //BtnForReview.Visible = false;
                //btnForApprove.Visible = false;
                btnApprove.Visible = false;
                divGrid.Visible = false;
              //  btnDisApprove.Visible = false;
              //  lblmsg.Visible = true;
              //  grdCategory.Visible = false;
               // lblmsg.Text = "No record found.";
               // spanPazeSize.Visible = false;
            }
        }
        p_Var.Result = p_Var.k;
        //if (p_Var.Result > Convert.ToInt16(ddlPageSize.SelectedValue))
        //{
        //    pagingBL.Paging_Show(p_Var.Result, pageIndex, ddlPageSize, rptPager);
        //    rptPager.Visible = true;
        //}
        //else
        //{
        //    rptPager.Visible = false;
        //}
        Session["Status_Id"] = ddlStatus.SelectedValue.ToString();
    }

    #endregion

    #region Function to approve the photo category

    public void ChkApprove_Disapprove()
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
                        PhotoGalleryBL categorydataBL = new PhotoGalleryBL();
                        foreach (GridViewRow row in grdCategory.Rows)
                        {
                            CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
                            if ((selCheck.Checked == true))
                            {
                                int ANCMNT_ID = Convert.ToInt32(grdCategory.DataKeys[row.RowIndex].Value);

                                photoCategoryObject.TempMCategoryID = ANCMNT_ID;
                                photoCategoryObject.UserID = Convert.ToInt16(Session["User_Id"]);
                                photoCategoryObject.IPAddress = miscellBL.IpAddress();
                                p_Var.Result = photoCategoryBL.InsertPhotoCategoryInWeb(photoCategoryObject);
                            }
                        }
                        if (p_Var.Result > 0)
                        {
                            Session["msg"] = "Category has been approved successfully.";
                            Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoCategory.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            //Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx"));
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
}
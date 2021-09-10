using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_PhotoGallery_ViewPhotoGallery :CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();

    Content_ManagementBL contentBL = new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    ContentOB contentObject = new ContentOB();
    Project_Variables p_Var = new Project_Variables();
    PhotoGalleryBL photoGalleryBL = new PhotoGalleryBL();
    PhotoGalleryOB photoGalleryObject = new PhotoGalleryOB();
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
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            //DisplayTigerReserveName(Convert.ToInt16(null), Convert.ToInt16(ddlState.SelectedValue));
            bindStatusInDropdownlist();

        }
    }



    protected void grdPhotoGallery_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdPhotoGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdPhotoGallery_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdPhotoGallery.HeaderRow.FindControl("chkSelectAll");
            //Add client side function childclick on check boxes
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));

        }
    }

    protected void grdPhotoGallery_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        binddropDownListPhotoCategory();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindPending_Approve_GridView(1);
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

    #region Function to bind dropDownlist with approved category

    public void binddropDownListPhotoCategory()
    {
        try
        {
            photoGalleryObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
            photoGalleryObject.TigerReserveID = Convert.ToInt16(ddlTigerReserve.SelectedValue);
            p_Var.dSet = photoGalleryBL.getPhotoCategoryName(photoGalleryObject);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                ddlCategory.DataSource = p_Var.dSet;

                ddlCategory.DataTextField = "PhotoCategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            }
            else
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
                ddlCategory.DataSource = null;

            }
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to bind approve and pending records in gridView

    private void bindPending_Approve_GridView(int pageIndex)
    {

        if (ddlStatus.SelectedValue == "0")
        {
            grdPhotoGallery.Visible = false;
        }
        else
        {
            photoGalleryObject.StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
            photoGalleryObject.ModuleId = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
            photoGalleryObject.StateID= Convert.ToInt32(ddlState.SelectedValue);
            photoGalleryObject.TigerReserveID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
            //photoGalleryObject.PageIndex = pageIndex;
            //photoGalleryObject.PageSize = Convert.ToInt16(ddlPageSize.SelectedValue);
            photoGalleryObject.CategoryID = Convert.ToInt16(ddlCategory.SelectedValue);
            //21june
            if (ddlStatus.SelectedValue == "13")
            {
              //  p_Var.dSet = obj_catBL.gallery_Photo_DeletedDisplay(photoGalleryObject, out p_Var.k);

                grdPhotoGallery.Columns[4].Visible = false;
                grdPhotoGallery.Columns[5].Visible = false;
                grdPhotoGallery.Columns[6].Visible = true;

            }
            else
            {
                p_Var.dSet = photoGalleryBL.PhotoGalleryDisplay(photoGalleryObject, out p_Var.k);
                grdPhotoGallery.Columns[6].Visible = false;
            }

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                //ddlPageSize.Visible = true;
                //lblPageSize.Visible = true;
                //rptPager.Visible = true;
                divGrid.Visible = true;
                grdPhotoGallery.Visible = true;
                grdPhotoGallery.DataSource = p_Var.dSet;
                grdPhotoGallery.DataBind();
                p_Var.dSet = null;
                //code for checking category is present in temp table or not

                if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.Approved))
                {
                    grdPhotoGallery.Columns[0].Visible = false;

                    foreach (GridViewRow row in grdPhotoGallery.Rows)
                    {

                        Image imgedit = (Image)row.FindControl("imgEdit");
                        Image imgnotedit = (Image)row.FindControl("imgnotedit");
                        Label lblGallery_ID = (Label)row.FindControl("lblGallery_ID");

                        photoGalleryObject.GalleryID = Convert.ToInt16(lblGallery_ID.Text);

                        p_Var.dSetCompare = photoGalleryBL.PhotoGalleryIDForComparison(photoGalleryObject);
                        for (p_Var.i = 0; p_Var.i < p_Var.dSetCompare.Tables[0].Rows.Count; p_Var.i++)
                        {
                            if (p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["GalleryId"] != DBNull.Value)
                            {
                                if (Convert.ToInt16(lblGallery_ID.Text) == Convert.ToInt16(p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["GalleryId"]))
                                {
                                    imgnotedit.Visible = true;
                                    imgedit.Visible = false;
                                    //18 Aug


                                }
                                else
                                {
                                    imgnotedit.Visible = false;
                                    imgedit.Visible = true;

                                }
                            }
                        }
                    }
                }
                //end


                //lblmsg.Text = "";
                //obj_userOB.RoleId = Convert.ToInt32(Session["Role_Id"]);
                //obj_userOB.ModuleId = Convert.ToInt32(Request.QueryString["ModuleID"]);
                //p_Var.dSet = miscellBL.getLanguagePermission(obj_userOB);
                //if (p_Var.dSet.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Permission_ID.Approved))
                //    {
                //        grdPhotoGallery.Columns[0].Visible = false;
                //    }
                //    else
                //    {
                //        grdPhotoGallery.Columns[0].Visible = true;
                //    }
                //    if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Permission_ID.draft))
                //    {
                //        btnForApprove.Visible = true;
                //        // btnDisApprove.Visible = true;
                //        //BtnForReview.Visible = true;
                //    }
                //    else
                //    {
                //        btnForApprove.Visible = false;
                //        btnDisApprove.Visible = false;
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
                //    if (ddlStatus.SelectedValue != "13")
                //    {
                //        if (Convert.ToBoolean(p_Var.dSet.Tables[0].Rows[0][6]) == true)
                //        {
                //            grdPhotoGallery.Columns[4].Visible = true;


                //        }
                //        else
                //        {
                //            grdPhotoGallery.Columns[4].Visible = false;

                //        }
                //        if (Convert.ToBoolean(p_Var.dSet.Tables[0].Rows[0][7]) == true)
                //        {
                //            grdPhotoGallery.Columns[5].Visible = true;

                //        }
                //        else
                //        {
                //            grdPhotoGallery.Columns[5].Visible = false;

                //        }
                //    }
                //}
                p_Var.dSet = null;
               // lblmsg.Visible = false;
            }


            else
            {
                divGrid.Visible = false;
                //ddlPageSize.Visible = false;
                //lblPageSize.Visible = false;
                //rptPager.Visible = false;
                //BtnForReview.Visible = false;
                //btnForApprove.Visible = false;
                //btnApprove.Visible = false;
                //btnDisApprove.Visible = false;
                //lblmsg.Visible = true;
                //grdPhotoGallery.Visible = false;
                //lblmsg.Text = "No record found.";

                //18 aug by Ruchi

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

    }

    #endregion
    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddropDownListPhotoCategory();
    }

    #region Function to approve the photo record

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


                        foreach (GridViewRow row in grdPhotoGallery.Rows)
                        {
                            CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
                            if ((selCheck.Checked == true))
                            {
                                int ANCMNT_ID = Convert.ToInt32(grdPhotoGallery.DataKeys[row.RowIndex].Value);

                                photoGalleryObject.TempGalleryID = ANCMNT_ID;
                                photoGalleryObject.UserID = Convert.ToInt16(Session["User_Id"]);
                                photoGalleryObject.IPAddress = miscellBL.IpAddress();
               
                                p_Var.Result = photoGalleryBL.InsertUpdatePhotoGalleryWeb(photoGalleryObject);
                            }


                        }

                        if (p_Var.Result > 0)
                        {
                            Session["msg"] = "Photo has been approved successfully.";
                            Session["Redirect"] = "~/Auth/AdminPanel/GalleryManagement/Photogallery.aspx?ModuleID=" + Request.QueryString["ModuleID"];
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
}
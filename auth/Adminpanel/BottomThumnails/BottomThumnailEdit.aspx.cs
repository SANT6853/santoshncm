using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_BottomThumnails_BottomThumnailEdit : CrsfBase
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
        if (Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "4")
        {
            objntcauser.TigerReserveid = Convert.ToInt32(Session["ntca_TigerReserveid"]);          
            p_Var.dSetCompare = _commanfucation.GetGetBottomThumnailUserType2and3and4(objntcauser);
            ddlTigerReserve.DataSource = p_Var.dSetCompare;
            ddlTigerReserve.DataTextField = "TigerReserveName";
            ddlTigerReserve.DataValueField = "TigerReserveid";
            ddlTigerReserve.DataBind();
            ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
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
    }
    #endregion

    #region function to display banner record in edit mode

    public void Display(string id)
    {
        contentObject.StatusID = Convert.ToInt16(Request.QueryString["statusID"]);
        contentObject.TempLinkID = Convert.ToInt32(id);
        p_Var.dsFileName = bannerBL.DisplayBanner_AtEdit(contentObject);
        ddlwebsite.SelectedValue = p_Var.dsFileName.Tables[0].Rows[0]["WebsiteID"].ToString();
        txtTitle.Text = p_Var.dsFileName.Tables[0].Rows[0]["Name"].ToString();
        txtAltTag.Text = p_Var.dsFileName.Tables[0].Rows[0]["Alt_Tag"].ToString();
        txtAltTagHindi.Text = p_Var.dsFileName.Tables[0].Rows[0]["AltTag_Reg"].ToString();
        txtTitleHindi.Text = p_Var.dsFileName.Tables[0].Rows[0]["Name_Reg"].ToString();
        ddlState.SelectedValue = Convert.ToString(p_Var.dsFileName.Tables[0].Rows[0]["Stateid"]);
        Bind_TigerReserveUserAccess();
        ddlTigerReserve.SelectedValue = Convert.ToString(p_Var.dsFileName.Tables[0].Rows[0]["TigerReserveid"]);
        LblImage.Text = p_Var.dsFileName.Tables[0].Rows[0]["Image_Name"].ToString();
        divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        txtLinkUrl.Text = p_Var.dsFileName.Tables[0].Rows[0]["UrlName"].ToString();
    }

    #endregion

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // Get file name
        bool s;
        string ext1 = System.IO.Path.GetExtension(ImageUploader.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".pdf")
        {
            s = miscellBL.GetActualFileType_pdf(ImageUploader.PostedFile.InputStream);
        }
        else
        {
            s = miscellBL.GetActualFileType(ImageUploader.PostedFile.InputStream);
        }
        if (ImageUploader.PostedFile.ContentLength == 0)
        {
            s = true;
        }
        if (s == false)
        {
            // There is no file selected
            args.IsValid = false;
            // CustomValidator1.Text = "This file extension has been changed, file is of another type.";

        }
        else
        {
            args.IsValid = true;

        }

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


                    //if (Page.IsValid)
                    //{

                    if (IsValid)
                    {
                        Update_Data();
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
        
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/auth/adminpanel/BottomThumnails/ViewBottomThumnail.aspx?Moduleid=7"));
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
                  // {
                        if (Page.IsValid)
                        {
                            contentObject.ActionType = 2;
                            contentObject.TempLinkID = Convert.ToInt32(Request.QueryString["id"]);
                            contentObject.StatusID = Convert.ToInt32(Request.QueryString["statusID"]);
                            contentObject.Name = HttpUtility.HtmlEncode(txtTitle.Text);
                            contentObject.AltTag = HttpUtility.HtmlEncode(txtAltTag.Text);
                            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);

                            contentObject.NameRegional = HttpUtility.HtmlEncode(txtTitleHindi.Text);
                            contentObject.AltTagReg = HttpUtility.HtmlEncode(txtAltTagHindi.Text);

                            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.BottomThumnail);
                            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                            contentObject.LinkID = Convert.ToInt32(Request.QueryString["id"]);
                            contentObject.UrlName = HttpUtility.HtmlEncode(txtLinkUrl.Text.Trim());
                            string fileName = string.Empty;
                            if (Upload_Image(ref fileName))
                            {
                                if (ImageUploader.PostedFile.InputStream.Length != 0)
                                {
                                    contentObject.ImageName = fileName;
                                }
                                else
                                {

                                    contentObject.ImageName = LblImage.Text;
                                }
                            }
                                else
                                {
                                    contentObject.ImageName = LblImage.Text;
                                }
                                int updateData = bannerBL.UpdateBannerData(contentObject);
                                if (updateData > 0)
                                {
                                    Session["msg"] = "Bottom thumnail has been updated successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/BottomThumnails/ViewBottomThumnail.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.BottomThumnail);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Session["msg"] = "Bottom thumnail has not been updated successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/BottomThumnails/ViewBottomThumnail.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.BottomThumnail);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                         }
                         
                    //}
                 }
            }
        }
        
        
        catch
        {
            throw;
        }
 	   
    }
    //}

    #endregion

    #region Function to upload image

    private bool Upload_Image(ref string fileName)
    {
        string Filename1, filenamewithout_Ext, ext;
        bool uploadStatus = true;
        try
        {
            Filename1 = ImageUploader.FileName;
            filenamewithout_Ext = Path.GetFileNameWithoutExtension(ImageUploader.FileName);
            ext = Path.GetExtension(ImageUploader.FileName);
            //For Unique File Name
            fileName = miscellBL.getUniqueFileName(Filename1, Server.MapPath(ResolveUrl("~") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/BannerImages/"), filenamewithout_Ext, ext);

            ImageUploader.PostedFile.SaveAs(Server.MapPath(ResolveUrl("~") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/BannerImages/" + fileName));
        }
        catch
        {
            uploadStatus = false;
        }
        return uploadStatus;
    }

    #endregion
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }
}
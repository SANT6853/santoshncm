using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;  


public partial class auth_Adminpanel_Banner_AddBanner : CrsfBase
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables p_Var = new Project_Variables();
    BannerManagementBL bannerBL = new BannerManagementBL();
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
            if (Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "4")
            {
                ddlwebsite.Enabled = false;
                ddlwebsite.Items.Remove(ddlwebsite.Items.FindByValue("1"));
                ddlwebsite_SelectedIndexChanged(this, EventArgs.Empty);
              //ddlSponsor_SelectedIndexChanged(this, EventArgs.Empty);
                int TigerReserveID = Convert.ToInt32(Session["ntca_TigerReserveid"]);
                ddlTigerReserve.SelectedValue = TigerReserveID.ToString();
                ddlTigerReserve.Enabled = false;
                ddlState.Enabled = false;
            }
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

           // string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
          //  string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

       //     if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
         //   {
           //     if (CurrentSessionId == hdnblank)
             //   {


                    //if (Page.IsValid)
                    //{
                         InsertBanner();

              //  }

           // }
        }
        catch
        {
            throw;
        }
 	   //}
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {


    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // Get file name
        
        bool s;
        string ext1 = System.IO.Path.GetExtension(ImageUploader.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".jpg" || ext1 == ".JPG" || ext1 == ".jpeg" || ext1 == ".JPEG" || ext1 == ".png" || ext1 == ".PNG" || ext1 == ".swf" || ext1 == ".SWF")
        {
            if (ext1 == ".pdf")
            {
                s = miscellBL.GetActualFileType_pdf(ImageUploader.PostedFile.InputStream);
            }
            else
            {// s = miscellBL.GetActualFileType(ImageUploader.PostedFile.InputStream);
                //s = miscellBL.GetActualFileTypeImage(ext1);
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
        else
        {
            args.IsValid = false;
        }

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
        //ddlTigerReserve.DataSource = p_Var.dSet;
        //ddlTigerReserve.DataTextField = "TigerReserveName";
        //ddlTigerReserve.DataValueField = "TigerReserveid";
        //ddlTigerReserve.DataBind();
        //ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {


            ddlTigerReserve.DataSource = p_Var.dSet;
            ddlTigerReserve.DataTextField = "TigerReserveName";
            ddlTigerReserve.DataValueField = "TigerReserveid";
            ddlTigerReserve.DataBind();
            ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
            ddlTigerReserve.BackColor = System.Drawing.Color.White;
            ddlTigerReserve.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            ddlTigerReserve.Items.Clear();
            //ddlselectcode.Items.Add(new ListItem("No Record", "0"));
            ddlTigerReserve.BackColor = System.Drawing.Color.Red;
            ddlTigerReserve.ForeColor = System.Drawing.Color.White;
            ddlTigerReserve.Items.Add(new ListItem("You don't have assigned any tiger reserve!", "0"));
        }
    }


    #endregion

    #region Function to insert the record
    bool ChkFileMendatory()
    {
        LblMsg.Text = "";
        
        if (!ImageUploader.HasFile)
        {

            LblMsg.Text = "Please upload banners.";
            return false;
        }
        else
        {
            LblMsg.Text = "";
            return true;

           
        }

        return true;
    }
    public void InsertBanner()
    {
         // if (Page.IsValid)
      // {

         try
         {

          //  string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
         //   string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

           // if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            //{
               // if (CurrentSessionId == hdnblank)
               // {


                    //if (Page.IsValid)
                    //{

                     //   if (Page.IsValid)
                       // {
                            if (ddlwebsite.SelectedValue == "1")
                            {
                                MainSiteInsert();
                            }
                            else
                            {
                                // string ss = ddlState.SelectedValue;
                                // string sssss = ddlTigerReserve.SelectedValue;
                                LblMsg.Text = string.Empty;
                                if (ddlState.SelectedValue != "0")
                                {
                                    if (ddlTigerReserve.SelectedValue != "0")
                                    {
                                        TigerReserve();
                                    }
                                    else
                                    {
                                        LblMsg.Text = "Please select reserve name!";
                                    }
                                }
                                else
                                {
                                    LblMsg.Text = "Please select state!";
                                }
                                //TigerReserve();
                            }
                        }
                    //}
                //}

           // }
       // }
        catch
        {
            throw;
        }
 	   //}
    }

    
    public void MainSiteInsert()
    {
        #region collapse
        if (ChkFileMendatory() == true)
        {
            contentObject.ActionType = 1;
            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
            contentObject.Name = HttpUtility.HtmlEncode(txtTitle.Text);
            // contentObject.NameRegional = HttpUtility.HtmlEncode(txtTitleHindi.Text);
            // contentObject.AltTag = HttpUtility.HtmlEncode(txtAltTag.Text);
            // contentObject.AltTagReg = HttpUtility.HtmlEncode(txtAltTagHindi.Text);
            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
            contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
            //contentObject.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
            string fileName = string.Empty;
            if (ImageUploader.PostedFile.ContentLength != 0)
            {
                if (Upload_Image(ref fileName))
                {
                    if (fileName != null)
                    {
                        contentObject.ImageName = fileName;
                    }

                }
            }
            else
            {
                contentObject.ImageName = null;
            }
            int insertdata = bannerBL.insertBanner(contentObject);
            if (insertdata > 0)
            {
                Session["msg"] = "Banner has been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Banner has not been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }

        }////
        #endregion
    }
    public void TigerReserve()
    {
        #region collapse
        if (ChkFileMendatory() == true)
        {
            contentObject.ActionType = 1;
            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
            contentObject.Name = HttpUtility.HtmlEncode(txtTitle.Text);
            // contentObject.NameRegional = HttpUtility.HtmlEncode(txtTitleHindi.Text);
            // contentObject.AltTag = HttpUtility.HtmlEncode(txtAltTag.Text);
            // contentObject.AltTagReg = HttpUtility.HtmlEncode(txtAltTagHindi.Text);
            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
            contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
            //contentObject.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
            string fileName = string.Empty;
            if (ImageUploader.PostedFile.ContentLength != 0)
            {
                if (Upload_Image(ref fileName))
                {
                    if (fileName != null)
                    {
                        contentObject.ImageName = fileName;
                    }

                }
            }
            else
            {
                contentObject.ImageName = null;
            }
            int insertdata = bannerBL.insertBanner(contentObject);
            if (insertdata > 0)
            {
                Session["msg"] = "Banner has been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Banner has not been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/Banner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }

        }////
        #endregion
    }

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
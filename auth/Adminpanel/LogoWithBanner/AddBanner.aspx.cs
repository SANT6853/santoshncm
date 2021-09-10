﻿using System;
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
    public string mime = "";
    public string CurrentRequestUrl = "";
    public string CurrentSessionId = "";
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
          //  DisplayStateName();
           // Bind_TigerReserveUserAccess();
         //   divstate.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
          //  divTigerReserve.Visible = (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
        }
       

    }
    
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // Get file name
        bool s;
        CurrentRequestUrl = Session["CurrentRequestUrl"].ToString();
        Miscelleneous_DL dl = new Miscelleneous_DL();
        HttpPostedFile file = ImageUploader.PostedFile;
        byte[] document = new byte[file.ContentLength];
        file.InputStream.Read(document, 0, file.ContentLength);
        System.UInt32 mimetype;
        FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
        System.IntPtr mimeTypePtr = new IntPtr(mimetype);
        mime = Marshal.PtrToStringUni(mimeTypePtr);
          CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
        Marshal.FreeCoTaskMem(mimeTypePtr);  
       
        string ext1 = System.IO.Path.GetExtension(ImageUploader.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".jpg" && mime.ToString().Equals("image/pjpeg") || ext1 == ".JPG" && mime.ToString().Equals("image/pjpeg") || ext1 == ".jpeg" && mime.ToString().Equals("image/pjpeg") || ext1 == ".JPEG" && mime.ToString().Equals("image/pjpeg") || ext1 == ".png" && mime.ToString().Equals("image/x-png") || ext1 == ".PNG" && mime.ToString().Equals("image/x-png"))
        {
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
        else
        {
            args.IsValid = false;
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
          //  string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
        //    if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            if (CurrentRequestUrl != null ||   CurrentRequestUrl.Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {
                    // if (Page.IsValid)
                    // { 
                    InsertBanner();

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
       // ddlState.DataSource = p_Var.dSet;
       // ddlState.DataTextField = "StateName";
       // ddlState.DataValueField = "id";
       // ddlState.DataBind();
        if (LoginUsertype == 1)
        {
        //    ddlState.Items.Insert(0, new ListItem("Select State", "0"));

        }


    }

    #endregion

    #region Function to bind tiger reserve name in dropdownlist

    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
      //  objntcauser.State = Convert.ToInt32(ddlState.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
      //  ddlTigerReserve.DataSource = p_Var.dSet;
       // ddlTigerReserve.DataTextField = "TigerReserveName";
       // ddlTigerReserve.DataValueField = "TigerReserveid";
       // ddlTigerReserve.DataBind();
        //ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    bool ChkLogoBannerExist()
    {
        bool chk = false;
        p_Var.dSet = null;
        objntcauser.ModuleID =Convert.ToInt32(Module_ID_Enum.Project_Module_ID.LogoBanner).ToString();
        objntcauser.LangId = ddlLanguage.SelectedValue.Trim();
       
        p_Var.dSet = _commanfucation.ChkLogoBannerExist(objntcauser);
      if(p_Var.dSet.Tables[0].Rows.Count>0)
      {
          chk = true;
      }
      return chk;
    }
    #endregion

    #region Function to insert the record

    public void InsertBanner()
    {
        //// if (Page.IsValid)
        //// {
        //try
        //{

        //    string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
        //    string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
        //    if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
        //    {
        //        if (CurrentSessionId == hdnblank)
        //        {
        //         // if (Page.IsValid)
        //           // { 
        //                if (Page.IsValid)
        //                {
                         if (ChkLogoBannerExist() == false)
                            {
                                contentObject.ActionType = 1;
                                contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.LogoBanner);
                                contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                                contentObject.LangID = Convert.ToInt32(ddlLanguage.SelectedValue);
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
                                    Session["BackUrl"] = "~/Auth/AdminPanel/LogoWithBanner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.LogoBanner);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Session["msg"] = "Banner has not been submitted successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/LogoWithBanner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.LogoBanner);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }

                            }
                            else
                            {
                                Session["msg"] = "Banner has already saved in database and you can update and delete!!";
                                Session["BackUrl"] = "~/Auth/AdminPanel/LogoWithBanner/ViewBanner.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.LogoBanner);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                        }
    //            }
    //        }
    //    }


    //    catch
    //    {
    //        throw;
    //    }
    //  // }
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
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
       // divstate.Visible =  (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
       // divTigerReserve.Visible =  (Convert.ToInt32(ddlwebsite.SelectedValue) == 2);
    }
  
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_CMS_DeletedContent : CrsfBase
{
    #region Data declaration zone

    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables p_Var = new Project_Variables();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    ContentOB contentObject = new ContentOB();
    Commanfuction _commanfucation = new Commanfuction();
    string LoginUserid;
    int LoginUsertype;
    public string mime = "";

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
            ddlMenuType.Enabled = false;
            ddlwebsite.Enabled = false;
            ddlLanguage.Enabled = false;
            ddlState.Enabled = false;
            ddlTigerReserve.Enabled = false;

            DisplayStateName();

            // bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue));
            DisplayRecordForEdit(Convert.ToInt16(Request.QueryString["statusID"]), Convert.ToInt16(Request.QueryString["MenuID"]));

            if (ddlMenuType.SelectedValue == "1")//content
            {
                divContent.Visible = true;
                divLink.Visible = false;
                DivFilDocument.Visible = false;
            }
            else
            {

            }
            if (ddlMenuType.SelectedValue == "2")//link
            {
                divLink.Visible = true;
                divContent.Visible = false;
                DivFilDocument.Visible = false;
            }

            if (ddlMenuType.SelectedValue == "3")//file/document
            {
                DivFilDocument.Visible = true;
                divLink.Visible = false;
                divContent.Visible = false;

            }
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }

    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        bool s;
        string ext1 = System.IO.Path.GetExtension(fileUpload_Menu.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".pdf")
        {
            s = miscellBL.GetActualFileType_pdf(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".xlsx")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".docx")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".doc ")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        else
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        if (fileUpload_Menu.PostedFile.ContentLength == 0)
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

        //// Get file name
        //string UploadFileName = fileUpload_Menu.PostedFile.FileName;

        //if (UploadFileName == "")
        //{
        //    // There is no file selected
        //    args.IsValid = false;
        //}
        //else
        //{
        //    string Extension = UploadFileName.Substring(UploadFileName.LastIndexOf('.') + 1).ToLower();

        //    if (Extension == "pdf" || Extension == ".xlsx" || Extension == "docx" || Extension == "doc")
        //    {
        //        args.IsValid = true; // Valid file type
        //    }
        //    else
        //    {
        //        args.IsValid = false; // Not valid file type
        //    }
        //}
    }
    //protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    protected void btnsave_Click(object sender, EventArgs e)
    {
        //  if (Page.IsValid)
        //{

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
                                UpdateContent();
                            }
                       // }
                    }
                }
            
            }
           catch
           {
               throw;
           }
    

     //  }

    
    }

    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/CMS/ViewContent.aspx?Moduleid=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.cms));
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
        p_Var.dSetCompare = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddlTigerReserve.DataSource = p_Var.dSetCompare;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    #endregion

    #region function to bind listbox with root

    private void bindMenuListBox(int langid, int positionid, int stateID, int tigerreserveID)
    {
        //lbMenu.Items.Clear();
        //contentBL _menuBL = new contentBL();

        ListItem li = default(ListItem);

        contentObject.LangID = langid;
        contentObject.LinkParentID = 0;
        contentObject.PositionID = positionid; //1
        contentObject.StateID = stateID;
        contentObject.TigerReserveid = tigerreserveID;
        try
        {

            p_Var.dSet = contentBL.getRootMenuNamFromWeb(contentObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                for (p_Var.i = 0; p_Var.i <= p_Var.dSet.Tables[0].Rows.Count - 1; p_Var.i++)
                {
                    p_Var.linkid = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"]);
                    //if (link_id != 20)
                    //{
                    li = new ListItem(p_Var.dSet.Tables[0].Rows[p_Var.i]["NAME"].ToString(), p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"].ToString());
                    //  lbMenu.Items.Add(li);
                    bindChildData(Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Level"]) + 1, Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"]), Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Position_Id"]));
                    //}
                }
                if (langid == 1)
                {
                    // lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    // lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                //  lbMenu.Items[0].Selected = true;

            }
            else
            {
                if (langid == 1)
                {
                    // lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    // lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                //lbMenu.Items[0].Selected = true;
            }
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to get child records

    public void bindChildData(int level, int Parent_ID, int Postion_ID)
    {
        ListItem lic = default(ListItem);
        Content_ManagementBL _subMenuBL = new Content_ManagementBL();
        DataSet dsubLinks = new DataSet();
        try
        {
            contentObject.LinkParentID = Parent_ID;
            contentObject.LinkLevel = level;
            contentObject.PositionID = Postion_ID;

            dsubLinks = _subMenuBL.getSubMenuOfParentMenu(contentObject);
            if (dsubLinks.Tables[0].Rows.Count > 0)
            {
                string str = "• ";
                for (int j = 0; j < level - 1; j++)
                {
                    str = str + "• ";
                }
                for (int i = 0; i <= dsubLinks.Tables[0].Rows.Count - 1; i++)
                {

                    lic = new ListItem(str + dsubLinks.Tables[0].Rows[i]["NAME"].ToString(), dsubLinks.Tables[0].Rows[i]["Link_Id"].ToString());
                    // lbMenu.Items.Add(lic);
                    contentObject.LinkParentID = Parent_ID;
                    contentObject.LinkLevel = level + 1;
                    contentObject.PositionID = Postion_ID;
                    bindChildData(level + 1, Convert.ToInt16(dsubLinks.Tables[0].Rows[i]["Link_Id"]), Postion_ID);
                }
            }
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to bind data in EDIT mode

    public void DisplayRecordForEdit(int StatusID, int TempLink_Id)
    {


        try
        {

            contentObject.StatusID = StatusID;
            contentObject.TempLinkID = TempLink_Id;

            p_Var.dSet = contentBL.DisplayContentForUpdate(contentObject);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                txtBrowserTitle.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Browser_Title"].ToString());
                txtLinkUrl.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Url"].ToString());
                txtMenuName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Name"].ToString());
                txtMetaDescription.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Mate_Description"].ToString());
                txtMetaKeyword.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Meta_Keywords"].ToString());
                ddlMetaLang.SelectedValue = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["MetaLanguage"].ToString());
                ddlState.SelectedValue = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["StateID"].ToString());
                Bind_TigerReserveUserAccess();
                ddlTigerReserve.SelectedValue = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["TigerReserveid"].ToString());
                lblFileName.Visible = true;
                lblFileName.Text = p_Var.dSet.Tables[0].Rows[0]["File_Name"].ToString();
                txtMetaTitle.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["MetaTitle"].ToString());
                txtPageTitle.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Page_Title"].ToString());
                txtUrlName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["UrlName"].ToString());
                txtSmallDescription.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["SmallDetails"].ToString());
                p_Var.i = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Type_Id"]);

                ddlMenuType.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["Link_Type_Id"].ToString();

                if (p_Var.i == 1)
                {
                    divContent.Visible = true;
                    FCKeditor1.Visible = true;

                    FCKeditor1.Value = p_Var.dSet.Tables[0].Rows[0]["Details"].ToString();

                    divLink.Visible = false;
                }
                if (p_Var.i == 2)
                {
                    divContent.Visible = false;
                    divLink.Visible = false;
                }



                if (p_Var.dSet.Tables[0].Rows[0]["Link_Parent_Id"] != DBNull.Value)
                {
                    ViewState["ParentID"] = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Parent_Id"]);
                }
                else
                {
                    ViewState["ParentID"] = DBNull.Value;
                }
                if (p_Var.dSet.Tables[0].Rows[0]["Position_Id"] != DBNull.Value)
                {
                    ViewState["PositionID"] = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Position_Id"]);
                }
                else
                {
                    ViewState["PositionID"] = DBNull.Value;
                }
                if (p_Var.dSet.Tables[0].Rows[0]["Link_Level"] != DBNull.Value)
                {
                    ViewState["Level"] = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Level"]);
                }
                else
                {
                    ViewState["Level"] = DBNull.Value;
                }
                if (p_Var.dSet.Tables[0].Rows[0]["Link_Type_Id"] != DBNull.Value)
                {
                    ViewState["LinkTypeId"] = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Type_Id"]);
                }
                else
                {
                    ViewState["LinkTypeId"] = DBNull.Value;
                }
                if (p_Var.dSet.Tables[0].Rows[0]["Link_ID"] != DBNull.Value)
                {
                    ViewState["Link_ID"] = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_ID"]);
                }
                else
                {
                    ViewState["Link_ID"] = DBNull.Value;
                }

                if (p_Var.dSet.Tables[0].Rows[0]["Lang_ID"] != DBNull.Value)
                {
                    ViewState["LangID"] = p_Var.dSet.Tables[0].Rows[0]["Lang_Id"].ToString();
                }
                else
                {
                    ViewState["LangID"] = DBNull.Value;
                }


            }

        }
        catch
        {
            throw;
        }


    }

    #endregion
    //  #region Function to add menu
    // #region Custom validator to validate extension of upload pdf files
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  

    #region Function to edit menu

    public void UpdateContent()
    {
        //if (Page.IsValid)
        //{

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
                            p_Var.Filename = string.Empty;
                            //try
                            //{
                                if (Convert.ToInt16(Request.QueryString["statusID"]) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.Approved))
                                {
                                    contentObject.ActionType = (int)Module_ID_Enum.Project_Action_Type.insert;
                                    contentObject.LinkID = Convert.ToInt16(Request.QueryString["MenuID"]);
                                    contentObject.InsertedBy = Convert.ToInt16(Session["user_id"]);
                                }
                                else
                                {
                                    contentObject.ActionType = (int)Module_ID_Enum.Project_Action_Type.update;
                                    contentObject.LastUpdatedBy = Convert.ToInt16(Session["user_id"]);
                                    if (ViewState["Link_ID"] != DBNull.Value)
                                    {
                                        contentObject.LinkID = Convert.ToInt16(Request.QueryString["MenuID"]);
                                    }
                                    else
                                    {
                                        contentObject.LinkID = null;
                                    }
                                }



                                contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
                                contentObject.LangID = Convert.ToInt32(ddlLanguage.SelectedValue);
                                contentObject.Name = HttpUtility.HtmlEncode(txtMenuName.Text);
                                contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                                contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
                                contentObject.UrlName = HttpUtility.HtmlEncode(txtUrlName.Text);
                                contentObject.LinkTypeID = Convert.ToInt16(ddlMenuType.SelectedValue); //Type of menu
                                contentObject.PageTitle = HttpUtility.HtmlEncode(txtPageTitle.Text);
                                contentObject.BrowserTitle = HttpUtility.HtmlEncode(txtBrowserTitle.Text);
                                contentObject.MetaKeywords = HttpUtility.HtmlEncode(txtMetaKeyword.Text);
                                contentObject.MateDescription = HttpUtility.HtmlEncode(txtMetaDescription.Text);
                                contentObject.TempLinkID = Convert.ToInt16(Request.QueryString["MenuID"]);
                                contentObject.MetaLng = HttpUtility.HtmlEncode(ddlMetaLang.SelectedValue);
                                contentObject.MetaTitle = HttpUtility.HtmlEncode(txtMetaTitle.Text);
                                contentObject.SmallDetails = HttpUtility.HtmlEncode(txtSmallDescription.Text);
                                contentObject.Date_Inserted = System.DateTime.Now;
                                contentObject.InsertedBy = Convert.ToInt16(Session["User_Id"]);
                                contentObject.UserID = Convert.ToInt16(Session["User_Id"]);
                                contentObject.IpAddress = miscellBL.IpAddress();
                                contentObject.UserID = Convert.ToInt16(Session["User_Id"]);


                                contentObject.ModuleID = (int)Module_ID_Enum.Project_Module_ID.cms;

                                //contentObject.ModuleId = Convert.ToInt32(Request.QueryString["ModuleID"]);
                                if (ViewState["ParentID"] != DBNull.Value)
                                {
                                    contentObject.LinkParentID = Convert.ToInt16(ViewState["ParentID"]);
                                }
                                else
                                {
                                    contentObject.LinkParentID = null;
                                }
                                if (ViewState["PositionID"] != DBNull.Value)
                                {
                                    contentObject.PositionID = Convert.ToInt16(ViewState["PositionID"]);
                                }
                                else
                                {
                                    contentObject.PositionID = null;
                                }
                                if (ViewState["Level"] != DBNull.Value)
                                {
                                    contentObject.LinkLevel = Convert.ToInt16(ViewState["Level"]);
                                }
                                else
                                {
                                    contentObject.LinkLevel = null;
                                }
                                if (ViewState["LangID"] != DBNull.Value)
                                {
                                    contentObject.LangID = Convert.ToInt16(ViewState["LangID"]);
                                }
                                else
                                {
                                    contentObject.LangID = null;
                                }

                                if (Session["Status_Id"] != null)
                                {
                                    if (Convert.ToInt32(Session["Status_Id"]) == (int)Module_ID_Enum.Module_Status_ID.Approved)
                                    {
                                        contentObject.StatusID = (int)Module_ID_Enum.Module_Status_ID.Delete;
                                    }
                                    else
                                    {
                                        contentObject.StatusID = Convert.ToInt16(Session["Status_Id"]);

                                    }
                                }
                                else
                                {
                                    contentObject.StatusID = (int)Module_ID_Enum.Module_Status_ID.Delete;
                                }

                                contentObject.Name = HttpUtility.HtmlEncode(txtMenuName.Text);

                                if (ddlMenuType.SelectedValue == "1")
                                {

                                    contentObject.details = FCKeditor1.Value;

                                }

                                else if (ddlMenuType.SelectedValue == "2")
                                {

                                    contentObject.Url = HttpUtility.HtmlEncode(txtLinkUrl.Text);
                                }
                                //start naren1june
                                //  string filenamechk = lblFileName.Text.Trim();
                                // string[] chk=filenamechk.Split('.');
                                if (ddlMenuType.SelectedValue == "3")
                                {
                                    string UploadFileName = fileUpload_Menu.PostedFile.FileName;

                                    if (UploadFileName == "")
                                    {
                                        contentObject.FileName = lblFileName.Text.Trim();

                                    }
                                    else
                                    {

                                        Miscelleneous_DL dl = new Miscelleneous_DL();
                                        HttpPostedFile file = fileUpload_Menu.PostedFile;
                                        byte[] document = new byte[file.ContentLength];
                                        file.InputStream.Read(document, 0, file.ContentLength);
                                        System.UInt32 mimetype;
                                        FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                                        System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                                        mime = Marshal.PtrToStringUni(mimeTypePtr);
                                        Marshal.FreeCoTaskMem(mimeTypePtr);
                                        if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                                        {
                                            p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                                            p_Var.ext = p_Var.ext.ToUpper();
                                            int count = fileUpload_Menu.PostedFile.FileName.Split('.').Length - 1;
                                            string contenttype = fileUpload_Menu.PostedFile.ContentType.ToString();
                                            if (count >= 2)
                                            {
                                                ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                                                return;
                                            }

                                            // if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || (p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed")) || (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png")) || (p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png")))


                                            if (p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf") || p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed") || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed"))
                                            {
                                                p_Var.Path = "~/" + ConfigurationManager.AppSettings["WriteReadData"];
                                                p_Var.Path = p_Var.Path + "/" + ConfigurationManager.AppSettings["CMS"];
                                                p_Var.Filename = fileUpload_Menu.FileName;
                                                fileUpload_Menu.SaveAs(Server.MapPath(p_Var.Path + "/" + p_Var.Filename));
                                                contentObject.FileName = p_Var.Filename;
                                            }
                                        }
                                    }
                                }///

                                //end naren1june
                                p_Var.Result = contentBL.insertMenu(contentObject);
                                if (p_Var.Result > 0)
                                {//Content has been restored successfully.Please check in status(Approved)
                                    Session["msg"] = "Content has been deleted successfully and record has been shifted in status(option:deleted and here you can also restore deleted record).";

                                    Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }



                        //    }
                        //    catch
                        //    {
                        //        throw;
                        //    }
                        }
                    }
                }
            }


            catch
            {
                throw;
            }
    //    }


    }
    
    #endregion

}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;  


public partial class auth_Adminpanel_CMS_AddContent :  CrsfBase
{
    #region Data declaration zone


    Project_Variables p_Var = new Project_Variables();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    ContentOB contentObject = new ContentOB();
    Commanfuction _commanfucation = new Commanfuction();
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
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
            if(ddlwebsite.SelectedValue=="1")
            {
                ReserveStar.Visible = false;
                StateStar.Visible = false;
            }
            else
            {
                ReserveStar.Visible = true;
                StateStar.Visible = true;
            }
           if (Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
           {
               // ddlTigerReserve.Enabled = true;
                ddlTigerReserve.Enabled = true;
               
                //ddlwebsite.Items[1].Attributes.Add("disabled", "disabled");
                ddlwebsite.Items[0].Enabled = false;
                ddlwebsite.Items.RemoveAt(0);
                DisplayStateName();
                Bind_TigerReserveUserAccess();
              //  ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
                bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
                ddlwebsite.Enabled = false;
                ddlState.Enabled = false;
                ////////---------------------
                if (ddlState.SelectedItem.Text == "Select State")
                {
                    ddlTigerReserve.Items.Clear();
                    ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
                    ddlTigerReserve.BackColor = System.Drawing.Color.White;
                    ddlTigerReserve.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    Bind_TigerReserveUserAccess();
                    bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
                }
                bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
                /////------------------------------
            }
            else
            {
                //------------
                DisplayStateName();
                // Bind_TigerReserveUserAccess();
                ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
                bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
            }
           // string ss = ddlwebsite.SelectedValue;
            if (ddlwebsite.SelectedValue == "1")
            {
                ddlState.Enabled = false;
                ddlTigerReserve.Enabled = false;
            }
            else
            {
                ddlState.Enabled = false;
                ddlTigerReserve.Enabled = true;
            }
            //if (Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
            //{
            //    ddlTigerReserve.Enabled = true;

            //}

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


                  //  if (Page.IsValid)
//{

                      //  if (Page.IsValid)
                       // {
                            Add_New_Menu();
                       // }
                    //}
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

    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        // DisplayStateName();
        // Bind_TigerReserveUserAccess();
        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
    }

    protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedItem.Text == "Select State")
        {
            ddlTigerReserve.Items.Clear();
            ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
            ddlTigerReserve.BackColor = System.Drawing.Color.White;
            ddlTigerReserve.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            Bind_TigerReserveUserAccess();
            bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
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
        
        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid)); Get_TigerReserve_state_PermissionModified
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlState.SelectedValue);
        //previous code  p_Var.dSetCompare = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        p_Var.dSetCompare = _commanfucation.Get_TigerReserve_state_PermissionModified(objntcauser);
        if (p_Var.dSetCompare.Tables[0].Rows.Count > 0)
        {
           
            ddlTigerReserve.DataSource = p_Var.dSetCompare;
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


    #region function to bind listbox with root

    private void bindMenuListBox(int langid, int positionid, int stateID, int tigerreserveID, int WebsiteID)
    {
        lbMenu.Items.Clear();
        //contentBL _menuBL = new contentBL();

        ListItem li = default(ListItem);

        contentObject.LangID = langid;
        contentObject.LinkParentID = 0;
        contentObject.PositionID = positionid; //1
        contentObject.StateID = stateID;
        contentObject.TigerReserveid = tigerreserveID;
        //10aprl2018 naren added and one parameter additional added websiteid
        contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
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
                    lbMenu.Items.Add(li);
                    bindChildData(Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Level"]) + 1, Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"]), Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Position_Id"]));
                    //}
                }
                if (langid == 1)
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                lbMenu.Items[0].Selected = true;

            }
            else
            {
                if (langid == 1)
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                lbMenu.Items[0].Selected = true;
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
                    lbMenu.Items.Add(lic);
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

    #region Function to add menu
   // #region Custom validator to validate extension of upload pdf files
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  

    public void Add_New_Menu()
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


                  //  if (Page.IsValid)
                   // {


                        if (Request.QueryString["TempLink_Id"] == null)
                        {
                            //  try
                            // {

                            if (lbMenu.SelectedValue == "0")
                            {
                                contentObject.LinkParentID = 0;
                                p_Var.dSet = contentBL.getMenulevelOrder(contentObject);
                                if (p_Var.dSet.Tables[0].Rows.Count > 0)
                                {
                                    contentObject.LinkOrder = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Order"]);
                                }
                                else
                                {
                                    contentObject.LinkOrder = 0;
                                }
                                contentObject.LinkLevel = 0;
                            }
                            else
                            {
                                contentObject.LinkParentID = (Convert.ToInt16(lbMenu.SelectedValue));

                                p_Var.dSet = contentBL.get_Menu_level_Link_Web(contentObject);
                                if (p_Var.dSet.Tables[0].Rows.Count == null)
                                {
                                    contentObject.LinkLevel = 0;
                                }
                                else
                                {
                                    contentObject.LinkLevel = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[0]["Link_Level"]) + 1;
                                }
                            }


                            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
                            contentObject.ActionType = 1;
                            contentObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            contentObject.PositionID = Convert.ToInt16(ddlPosition.SelectedValue);
                            contentObject.LinkParentID = Convert.ToInt16(lbMenu.SelectedValue);
                            contentObject.LangID = Convert.ToInt32(ddlLanguage.SelectedValue);
                            contentObject.Name = HttpUtility.HtmlEncode(txtMenuName.Text);
                            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);

                            //start 3oct18
                            //  contentObject.Url = HttpUtility.HtmlEncode(txtLinkUrl.Text);
                            contentObject.UrlName = HttpUtility.HtmlEncode(txtUrlName.Text);
                            //end 3oct18

                            contentObject.LinkTypeID = Convert.ToInt16(ddlMenuType.SelectedValue); //Type of menu
                            contentObject.PageTitle = HttpUtility.HtmlEncode(txtPageTitle.Text);
                            contentObject.BrowserTitle = HttpUtility.HtmlEncode(txtBrowserTitle.Text);
                            contentObject.MetaKeywords = HttpUtility.HtmlEncode(txtMetaKeyword.Text);
                            contentObject.MateDescription = HttpUtility.HtmlEncode(txtMetaDescription.Text);

                            contentObject.SmallDetails = HttpUtility.HtmlEncode(txtSmallDescription.Text);
                            contentObject.MetaLng = HttpUtility.HtmlEncode(ddlMetaLang.SelectedValue);
                            contentObject.MetaTitle = HttpUtility.HtmlEncode(txtMetaTitle.Text);

                            contentObject.Date_Inserted = System.DateTime.Now;
                            contentObject.InsertedBy = Convert.ToInt16(Session["User_Id"]);
                            contentObject.UserID = Convert.ToInt16(Session["User_Id"]);
                            contentObject.IpAddress = miscellBL.IpAddress();


                            //  contentObject.ModuleID = 2;
                            contentObject.ModuleID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms);

                            if (ddlMenuType.SelectedValue == "1")
                            {
                                contentObject.details = FCKeditor1.Value;
                            }

                            else if (ddlMenuType.SelectedValue == "2")
                            {
                                // contentObject.UrlName = HttpUtility.HtmlEncode(txtUrlName.Text);
                                contentObject.Url = HttpUtility.HtmlEncode(txtLinkUrl.Text);
                            }
                            //start naren1june
                            if (ddlMenuType.SelectedValue == "3")
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
                                    if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed"))
                                    {
                                        p_Var.Path = "~/" + ConfigurationManager.AppSettings["WriteReadData"];
                                        p_Var.Path = p_Var.Path + "/" + ConfigurationManager.AppSettings["CMS"];
                                        p_Var.Filename = fileUpload_Menu.FileName;
                                        fileUpload_Menu.SaveAs(Server.MapPath(p_Var.Path + "/" + p_Var.Filename));
                                        contentObject.FileName = p_Var.Filename;
                                    }
                                }
                            }
                            //end naren1june
                            p_Var.Result = contentBL.insertMenu(contentObject);

                            if (p_Var.Result > 0)
                            {
                                Session["msg"] = "Content has been added successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");

                            }

                            // }
                            //catch
                            //{
                            //    throw;
                            //}
                        }

                   // }
                }
            }
        }
        catch
        {
            throw;
        }
 	   //}
    }
    
     #endregion

    //End
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
    protected void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));

    }
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlwebsite.SelectedValue == "1")
        {
            ReserveStar.Visible = false;
            StateStar.Visible = false;
            ddlState.Enabled = false;
            ddlTigerReserve.Enabled = false;
            Response.Redirect("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=2");
        }
        else
        {
            ReserveStar.Visible = true;
            StateStar.Visible = true;
            ddlState.Enabled = true;
            ddlTigerReserve.Enabled = true;
        }
    }
}
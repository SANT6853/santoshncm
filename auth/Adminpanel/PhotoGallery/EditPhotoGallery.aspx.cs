using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_PhotoGallery_EditPhotoGallery : CrsfBase
{
    #region DAta declaration zone
   
   

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    PhotoGalleryBL photoGalleryBL = new PhotoGalleryBL();
    PhotoGalleryOB photoGalleryObject = new PhotoGalleryOB();
    UserBL userBL = new UserBL();
    NtcaUserOB obj_userOB = new NtcaUserOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    ContentOB contentObject = new ContentOB();
    string imageUrl = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/PhotoGallery/Images/";
    string thumbnailUrl = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/PhotoGallery/ThumbnailImages/";
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
            DisplayStateName();
            //DisplayTigerReserveName(Convert.ToInt16(null), Convert.ToInt16(ddlState.SelectedValue));
            //binddropDownListPhotoCategory();
            display_Gallery_In_Edit_Mode(Request.QueryString["Photoid"].ToString());
        }
    }
    // #region Custom validator to validate extension of upload pdf files
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  

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

                        photoGalleryObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.update);
                        photoGalleryObject.TempGalleryID = Convert.ToInt32(Request.QueryString["Photoid"]);
                        photoGalleryObject.CategoryID = Convert.ToInt16(Request.QueryString["MCatID"]);
                        photoGalleryObject.StatusID = Convert.ToInt32(Request.QueryString["status"]);
                        photoGalleryObject.TigerReserveID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
                        photoGalleryObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
                        photoGalleryObject.Title = HttpUtility.HtmlEncode(txtPhotoName.Text);
                        photoGalleryObject.TitleRegLng = HttpUtility.HtmlEncode(txtPhotoNameHindi.Text);
                        photoGalleryObject.Description = HttpUtility.HtmlEncode(txtPhotoDescription.Text);
                        photoGalleryObject.descriptionRegLng = HttpUtility.HtmlEncode(txtPhotoDescriptionHindi.Text);
                        photoGalleryObject.AltTag = HttpUtility.HtmlEncode(txtAlttag.Text);
                        photoGalleryObject.AltTagRegLng = HttpUtility.HtmlEncode(txtAlttagHindi.Text);

                        string fileName = string.Empty;
                        Miscelleneous_DL dl = new Miscelleneous_DL();
                        HttpPostedFile file = ImageUploader.PostedFile;
                        byte[] document = new byte[file.ContentLength];
                        file.InputStream.Read(document, 0, file.ContentLength);
                        System.UInt32 mimetype;
                        FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                        System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                        mime = Marshal.PtrToStringUni(mimeTypePtr);
                        Marshal.FreeCoTaskMem(mimeTypePtr);  
       
                        if (ImageUploader.PostedFile != null && ImageUploader.PostedFile.ContentLength > 0)
                        {
                            p_Var.ext = System.IO.Path.GetExtension(this.ImageUploader.PostedFile.FileName);
                            p_Var.ext = p_Var.ext.ToUpper();
                            int count = ImageUploader.PostedFile.FileName.Split('.').Length - 1;
                            string contenttype = ImageUploader.PostedFile.ContentType.ToString();
                            if (count >= 2)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                                return;
                            }


                            // if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || (p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed")) || (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png")) || (p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png")))
                            if (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".GIF") && mime.ToString().Equals("image/gif") || p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png"))

                          //  if (p_Var.ext.Equals(".JPEG") || p_Var.ext.Equals(".JPG") || p_Var.ext.Equals(".GIF") || p_Var.ext.Equals(".PNG"))
                            {

                                p_Var.Path = p_Var.imageUrl;
                                p_Var.Filename = ImageUploader.FileName;
                                p_Var.filenamewithout_Ext = Path.GetFileNameWithoutExtension(ImageUploader.FileName);
                                //  p_Var.ext = Path.GetExtension(ImageUploader.FileName);

                                p_Var.Filename = miscellBL.getUniqueFileName(p_Var.Filename, Server.MapPath(ResolveUrl("~/") + imageUrl), p_Var.filenamewithout_Ext, p_Var.ext);
                                ImageUploader.SaveAs(Server.MapPath(ResolveUrl("~/") + imageUrl + p_Var.Filename));
                                //code for Thumpnails images
                                Stream sourcepath = ImageUploader.PostedFile.InputStream;
                                p_Var.targetpath = Server.MapPath(ResolveUrl("~/") + thumbnailUrl + p_Var.Filename);
                                GenerateThumbnails(1, sourcepath, p_Var.targetpath); //function calling 
                                photoGalleryObject.ImageName = p_Var.Filename;
                            }

                        }


                        else
                        {
                            photoGalleryObject.ImageName = "";
                        }

                        //if (edtxtpublishdate.Text != null && edtxtpublishdate.Text != "")
                        //{
                        //    photoGalleryObject.StartDate = Convert.ToDateTime(miscellBL.getDateFormat(edtxtpublishdate.Text));
                        //}
                        //else
                        //{
                        //    photoGalleryObject.StartDate = null;
                        //}
                        //if (edTxtEXpDate.Text != null && edTxtEXpDate.Text != "")
                        //{
                        //    photoGalleryObject.EndDate = Convert.ToDateTime(miscellBL.getDateFormat(edTxtEXpDate.Text));
                        //}
                        //else
                        //{
                        //    if (edtxtpublishdate.Text != null && edtxtpublishdate.Text != "")
                        //    {
                        //        DateTime MyDate = Convert.ToDateTime(miscellBL.getDateFormat(edtxtpublishdate.Text));
                        //        MyDate = MyDate.AddMonths(3);
                        //        photoGalleryObject.EndDate = MyDate;
                        //    }
                        //    else
                        //    {
                        //        DateTime MyDate = System.DateTime.Now;
                        //        MyDate = MyDate.AddMonths(3);
                        //        photoGalleryObject.EndDate = MyDate;
                        //    }

                        //}
                        if (Request.QueryString["status"] != "" && Request.QueryString["status"] != null)
                        {
                            if (Convert.ToInt16(Request.QueryString["status"]) == 5)
                            {
                                photoGalleryObject.GalleryID = Convert.ToInt32(Request.QueryString["Photoid"].ToString());
                            }
                        }
                        photoGalleryObject.UserID = Convert.ToInt16(Session["User_Id"]);
                        photoGalleryObject.IPAddress = miscellBL.IpAddress();
                        p_Var.Result = photoGalleryBL.InsertUpdateDeletePhotoGallery(photoGalleryObject);
                        if (p_Var.Result > 0)
                        {
                            //AuditOB AE = new AuditOB();
                            //AuditTrail Obj_Audit = new AuditTrail();
                            //AE.FK_MODULE_ID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.Gallery);
                            //AE.Action = "Update Photo";
                            //AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"].ToString());
                            //AE.UserName = Convert.ToString(Session["UserName"]);
                            //Obj_Audit.GetAuditTrail(AE);
                            Session["msg"] = "Record has been updated successfully.";
                            Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoGallery.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery) + "&Status=" + Request.QueryString["Status"].ToString() + "&MCatID=" + Request.QueryString["MCatID"].ToString();
                            Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery) + "&Status=" + Request.QueryString["Status"].ToString() + "&MCatID=" + Request.QueryString["MCatID"].ToString()));

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
    

    


    protected void btnBack_Click(object sender, EventArgs e)
    {

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        ddlcategory.Items.Insert(0, new ListItem("Select Category", "0"));

    }

    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddropDownListPhotoCategory();
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }

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
        p_Var.dSetCompare = _commanfucation.Get_TigerReserve_state_Permission(obj_userOB);
        ddlTigerReserve.DataSource = p_Var.dSetCompare;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    #endregion

    #region Function to bind dropDownlist with approved category

    public void binddropDownListPhotoCategory()
    {
        try
        {

            photoGalleryObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
            photoGalleryObject.TigerReserveID = Convert.ToInt16(ddlTigerReserve.SelectedValue);
            p_Var.dSetChildData = photoGalleryBL.getPhotoCategoryName(photoGalleryObject);
            if (p_Var.dSetChildData.Tables[0].Rows.Count > 0)
            {
                ddlcategory.DataSource = p_Var.dSetChildData;

                ddlcategory.DataTextField = "PhotoCategoryName";
                ddlcategory.DataValueField = "CategoryId";
                ddlcategory.DataBind();
                ddlcategory.Items.Insert(0, new ListItem("Select Category", "0"));
            }
            else
            {
                ddlcategory.Items.Clear();
                ddlcategory.Items.Insert(0, new ListItem("Select Category", "0"));
                ddlcategory.DataSource = null;

            }
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region function to display photo in edit mode

    private void display_Gallery_In_Edit_Mode(string id)
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

                        photoGalleryObject.TempGalleryID = Convert.ToInt32(id);
                        photoGalleryObject.StatusID = Convert.ToInt32(Request.QueryString["Status"]);
                        photoGalleryObject.MCategoryID = Convert.ToInt16(Request.QueryString["MCatID"]);

                        p_Var.dSet = photoGalleryBL.DisplayPhotoGalleryInEdit(photoGalleryObject);

                        ddlState.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["StateID"].ToString();
                        Bind_TigerReserveUserAccess();
                        ddlTigerReserve.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["TigerReserveID"].ToString();

                        binddropDownListPhotoCategory();
                        ddlcategory.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["CategoryId"].ToString();
                        txtPhotoName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Title"].ToString());
                        txtPhotoNameHindi.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["TitleRegLng"].ToString());
                        txtPhotoDescription.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["Description"].ToString());

                        txtPhotoDescriptionHindi.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["DescriptionRegLng"].ToString());
                        txtAlttag.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["AltTag"].ToString());
                        txtAlttagHindi.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["AltTagRegLng"].ToString());
                        //if (p_Var.dSet.Tables[0].Rows[0]["StartDate"] != DBNull.Value)
                        //{
                        //    edtxtpublishdate.Text = miscellBL.getDateFormatddMMYYYY(p_Var.dSet.Tables[0].Rows[0]["StartDate"].ToString());
                        //}
                        //else
                        //{
                        //    edtxtpublishdate.Text = "";
                        //}
                        //if (p_Var.dSet.Tables[0].Rows[0]["EndDate"] != DBNull.Value)
                        //{
                        //    edTxtEXpDate.Text = miscellBL.getDateFormatddMMYYYY(p_Var.dSet.Tables[0].Rows[0]["EndDate"].ToString());
                        //}
                        //else
                        //{
                        //    edTxtEXpDate.Text = "";
                        //}
                        LblImage.Text = p_Var.dSet.Tables[0].Rows[0]["ImageName"].ToString();
                        // EditPhoto.Visible = true;
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

    #region Function to convert image in thumbnail

    private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    {

        using (System.Drawing.Image image = System.Drawing.Image.FromStream(sourcePath))
        {
            // can given width of image as we want
            //int newWidth = (int)(image.Width / scaleFactor);
            int newWidth = 155;
            // can given height of image as we want
            //int newHeight = (int)(image.Height / scaleFactor);
            int newHeight = 155;
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }


    }

    #endregion
}
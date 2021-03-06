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

public partial class auth_Adminpanel_PhotoGallery_AddPhotoGallery : CrsfBase
{
    #region DAta declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();

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
            Bind_TigerReserveUserAccess();
            binddropDownListPhotoCategory();
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
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

                      //  try
                        //{

                            photoGalleryObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
                           photoGalleryObject.CategoryID = Convert.ToInt32(ddlcategory.SelectedValue);
                            photoGalleryObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
                            photoGalleryObject.TigerReserveID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
                            photoGalleryObject.Title = HttpUtility.HtmlEncode(txtPhotoName.Text);
                            photoGalleryObject.TitleRegLng = HttpUtility.HtmlEncode(txtPhotoNameHindi.Text);
                            photoGalleryObject.Description = HttpUtility.HtmlEncode(txtPhotoDescription.Text);
                            photoGalleryObject.descriptionRegLng = HttpUtility.HtmlEncode(txtPhotoDescriptionHindi.Text);
                            photoGalleryObject.AltTag = HttpUtility.HtmlEncode(txtAlttag.Text);
                            photoGalleryObject.AltTagRegLng = HttpUtility.HtmlEncode(txtAlttagHindi.Text);
                            photoGalleryObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            photoGalleryObject.IPAddress = miscellBL.IpAddress();
                            photoGalleryObject.UserID = Convert.ToInt16(Session["User_Id"]);

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
                                    GenerateThumbnails(4, sourcepath, p_Var.targetpath); //function calling 
                                    photoGalleryObject.ImageName = p_Var.Filename;
                                }

                            }


                            else
                            {
                                photoGalleryObject.ImageName = "";
                            }


                            p_Var.Result = photoGalleryBL.InsertUpdateDeletePhotoGallery(photoGalleryObject);
                            if (p_Var.Result > 0)
                            {
                                //AuditOB AE = new AuditOB();
                                //AuditTrail Obj_Audit = new AuditTrail();
                                //AE.FK_MODULE_ID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.Gallery);
                                //AE.Action = "Add Photo";
                                //AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"].ToString());
                                //AE.UserName = Convert.ToString(Session["UserName"]);
                                //Obj_Audit.GetAuditTrail(AE);
                                Session["msg"] = "Photo has been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/PhotoGallery/ViewPhotoGallery.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.PhotoGallery);
                                Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx"));


                            }



                        //}
                        //catch (Exception e1)
                       // {
                         //   throw;
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
                ddlcategory.DataSource = p_Var.dSet;

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

    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddropDownListPhotoCategory();
    }
}
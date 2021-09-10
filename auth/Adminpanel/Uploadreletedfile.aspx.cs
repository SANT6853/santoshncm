using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;  


public partial class auth_Adminpanel_Uploadreletedfile :CrsfBase
{
    string filename;
    common com_Obj = new common();
    uploadfileentity entity = new uploadfileentity();
    Dal_upload_file dal = new Dal_upload_file();
    Miscelleneous_BL obMiscell = new Miscelleneous_BL();
    public string mime = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("4"))
            {
                filldropedownvillage();
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindStateName();
                BindTigerReserveName();
                filldropedownvillage1();
            }
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
                      //  if (Page.IsValid)
                      //  {
                            // bool ChkMalicousCode=obMiscell.GetActualFileType()

                            bool ckk = false;
                            if (FileUpload1.HasFile)
                            {
                                if (FileUpload1.PostedFile.ContentLength > 10485760)
                                {
                                    lblmsg.Text = "you can not upload file more then 10 Mb";
                                    lblmsg.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    ckk = Upload_Pdf();
                                }
                            }
                            else
                            {
                                lblmsg.Text = "please check your file is without content.we will not be accept.";

                                lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                            if (ckk)
                            {
                                entity._TigerReserveID = Int32.Parse(ddlTigerreserve.SelectedValue);
                                entity._stateid = Int32.Parse(ddlStatename.SelectedValue);
                                entity._v_id = Int32.Parse(ddlvillage.SelectedValue);
                                entity._type = (ddltype.SelectedValue);
                                entity._title = txttitle.Text;
                                entity._description = txtdescription.Text;
                                entity._filename = filename;
                                int i = dal.upload_files(entity);
                                if (i > 0)
                                {
                                    lblmsg.Text = "record Inserted successfuly";
                                    lblmsg.ForeColor = System.Drawing.Color.Green;
                                    reset();
                                }
                            }
                        }
                    //}
                //}
            }
        }
        catch
        {
            throw;
        }


        //  }


    }
        protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    public void reset()
    {
        ddltype.SelectedValue = "0";
     //   ddlvillage.SelectedValue = "0";
        txttitle.Text = "";
        txtdescription.Text = "";
        ddlStatename.SelectedValue = "0";
        ddlTigerreserve.SelectedValue = "0";
        ddlvillage.SelectedValue = "0";


    }
    public void filldropedownvillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villages(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage1()
    {
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        int TigerReserve = Convert.ToInt32(ddlTigerreserve.SelectedValue);
        DataTable dt = NgoDal.Get_Villages(TigerReserve);

        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
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

    public bool Upload_Pdf()
    {
        bool Chk = false;
        string path;
        string fext1 = "";

        if (FileUpload1.PostedFile != null)
        {
            fext1 = System.IO.Path.GetExtension(this.FileUpload1.FileName.ToString());
            //bool s = UploadFile.GetActualFileType(FileUpload1.PostedFile.InputStream);

            #region[for image type code]
            if (ddltype.SelectedValue == "1")
            {
                bool ChkMaliciousType = obMiscell.GetActualFileType(FileUpload1.PostedFile.InputStream);
                if (ChkMaliciousType == true)
                {
                    Miscelleneous_DL dl = new Miscelleneous_DL();
                    HttpPostedFile file =  FileUpload1.PostedFile;
                    byte[] document = new byte[file.ContentLength];
                    file.InputStream.Read(document, 0, file.ContentLength);
                    System.UInt32 mimetype;
                    FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                    System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                    mime = Marshal.PtrToStringUni(mimeTypePtr);
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                  //  if (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png") || p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png"))

                    if (fext1.Equals(".jpg") && ((mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream")) || fext1.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") || fext1.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") || fext1.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") || fext1.Equals(".png") && mime.ToString().Equals("image/x-png") ||  mime.ToString().Equals("application/octet-stream")||fext1.Equals(".PNG") && mime.ToString().Equals("image/x-png")))
                    {   
                        path = ResolveUrl("~") + "WriteReadData/UserFiles";
                        filename = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                        path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                        ViewState["newfilename"] = filename;
                     

                        string lbldisplay = ViewState["newfilename"].ToString();

                        return Chk = true;

                    }
                    else
                    {
                        string msg = "Image is in incorrect formate ";
                        lblmsg.Text = msg;
                        return Chk = false;

                    }

                }
                else
                {
                    string msg = "Image is in incorrect formate ";
                    lblmsg.Text = msg;
                    return Chk = false;
                }
            }//end ddltype.SelectedValue == "1"
            #endregion
            
            #region[for file type code]
            if (ddltype.SelectedValue == "2")
            {
                Miscelleneous_DL dl = new Miscelleneous_DL();
                HttpPostedFile file = FileUpload1.PostedFile;
                byte[] document = new byte[file.ContentLength];
                file.InputStream.Read(document, 0, file.ContentLength);
                System.UInt32 mimetype;
                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);

                if (fext1.Equals(".pdf") && mime.ToString().Equals("application/pdf") || fext1.Equals(".PDF") && mime.ToString().Equals("application/pdf"))
                {

                    bool ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload1.PostedFile.InputStream);

                    if (ChkMaliciousType == true)
                    {

                        path = ResolveUrl("~") + "WriteReadData/UserFiles";
                        filename = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                        path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                        ViewState["newfilename"] = filename;

                        string lbldisplay = ViewState["newfilename"].ToString();

                        return true;

                    }
                    else
                    {
                        string msg = "File is in incorrect formate ";
                        lblmsg.Text = msg;
                        return false;

                    }
                }
                else
                {
                    string msg = "File is in incorrect formate ";
                    lblmsg.Text = msg;
                    return Chk = false;
                }
            }
            #endregion
        }
        else
        {
            return Chk = false;
        }
        return Chk;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("upload_file_imege_manegement.aspx");
    }
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        // P_var.dSet = _commanfuction.BindDdlStateBarChart(_objNtcauser);
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlStatename.DataSource = P_var.dSet.Tables[0];
            ddlStatename.DataTextField = "StateName";
            ddlStatename.DataValueField = "id";
            ddlStatename.DataBind();
            ddlStatename.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    void BindTigerReserveName()
    {
        try
        {
            ddlTigerreserve.Items.Clear();
            ddlTigerreserve.Items.Add(new ListItem("-Select-", "0"));
            int StateID = Convert.ToInt32(ddlStatename.SelectedValue);
            DataSet ds = new VillageDB().BindTigerReservefile(StateID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlTigerreserve.DataSource = ds.Tables[0];
                ddlTigerreserve.DataTextField = "TigerReserveName";
                ddlTigerreserve.DataValueField = "TigerReserveid";
                ddlTigerreserve.DataBind();

                ddlTigerreserve.Items.Insert(0, new ListItem("-Select-", "0"));
            }



            else
            {
                ddlTigerreserve.Items.Clear();
                ddlTigerreserve.Items.Add(new ListItem("-Select-", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }
    public void filldropedownvillage2()
    {
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        int Tiger = Convert.ToInt32(ddlTigerreserve.SelectedValue);
        DataTable dt = NgoDal.Get_All_Villages2(Tiger);
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void ddlStatename_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName();
    }
    protected void ddlTigerreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["User_Id"]) != 1)
        {
            filldropedownvillage2();
        }
        else
        {
            filldropedownvillage1();
        }
    }
}
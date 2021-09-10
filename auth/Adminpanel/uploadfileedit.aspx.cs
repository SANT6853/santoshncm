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
public partial class auth_Adminpanel_uploadfileedit : System.Web.UI.Page
{
    static int fileid;
    static string filename;
    static string newfilename;
    Dal_upload_file dal = new Dal_upload_file();
    common com_Obj = new common();
    uploadfileentity entity = new uploadfileentity();
    Miscelleneous_BL obMiscell = new Miscelleneous_BL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Session["UserType"].ToString().Equals("1"))
            {

                filldropedownvillage1();
            }
            if (Session["UserType"].ToString().Equals("2"))
            {

                filldropedownvillage2();
            }
            if (Session["UserType"].ToString().Equals("3"))
            {

                filldropedownvillage3();
            }
            if (Session["UserType"].ToString().Equals("4"))
            {

                filldropedownvillage();
            }
            filldeatil();
        }
    }
    public void filldeatil()
    {
        fileid = Int32.Parse(Request.QueryString["id"]);
        DataSet ds = dal.select_file_for_update(fileid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlvillage.SelectedValue = ds.Tables[0].Rows[0]["v_id"].ToString();
            ddltype.SelectedValue = ds.Tables[0].Rows[0]["file_type"].ToString();
            txttitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
            txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            filename = ds.Tables[0].Rows[0]["file_name"].ToString();
            hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + filename;

        }


    }
    public void filldropedownvillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villagesnew(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage3()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villagesnew3(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage2()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villagesnew2(Convert.ToInt32(Session["User_Id"]));
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
        DataTable dt = NgoDal.Proc_Get_All_Villagesnew1(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public bool Upload_Pdf()
    {
        bool Chk = false;
        string path;
        string fext1 = "";

        if (FileUpload1.PostedFile != null)
        {
            fext1 = System.IO.Path.GetExtension(this.FileUpload1.FileName.ToString());
            // bool s = UploadFile.GetActualFileType(FileUpload1.PostedFile.InputStream);
            #region[for image type code]
            if (ddltype.SelectedValue == "1")
            {
                bool ChkMaliciousType = obMiscell.GetActualFileType(FileUpload1.PostedFile.InputStream);
                if (ChkMaliciousType == true)
                {
                    if (fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG") || fext1.Equals(".png") || fext1.Equals(".PNG"))
                    {



                        path = ResolveUrl("~") + "WriteReadData/UserFiles";
                        newfilename = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                        path = ResolveUrl("~") + "WriteReadData/UserFiles/" + newfilename;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                        ViewState["newfilename"] = newfilename;

                        string lbldisplay = ViewState["newfilename"].ToString();

                        return Chk = true;

                    }
                    else
                    {
                        string msg = "File or Image is in incorrect formate ";
                        lblmsg.Text = msg;
                        return Chk = false;

                    }//
                }
                else
                {
                    string msg = "Image is in incorrect formate ";
                    lblmsg.Text = msg;
                    return Chk = false;
                }
            }
            #endregion
            #region[for file type code]
            if (ddltype.SelectedValue == "2")
            {
                bool ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload1.PostedFile.InputStream);
                if (ChkMaliciousType == true)
                {
                    if (fext1.Equals(".pdf") || fext1.Equals(".PDF"))
                    {



                        path = ResolveUrl("~") + "WriteReadData/UserFiles";
                        newfilename = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                        path = ResolveUrl("~") + "WriteReadData/UserFiles/" + newfilename;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                        ViewState["newfilename"] = newfilename;

                        string lbldisplay = ViewState["newfilename"].ToString();

                        return Chk = true;

                    }
                    else
                    {
                        string msg = "File or Image is in incorrect formate ";
                        lblmsg.Text = msg;
                        return Chk = false;

                    }//
                }
                else
                {
                    string msg = "file is in incorrect formate ";
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
    public bool Upload_Pdf11()
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
                    if (fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG") || fext1.Equals(".png") || fext1.Equals(".PNG"))
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
                if (fext1.Equals(".pdf") || fext1.Equals(".PDF"))
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        bool ckk = true;

        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentLength > 10485760)
            {
                lblmsg.Text = "you can not upload file more then 10 mb";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ckk = Upload_Pdf();
                entity._filename = newfilename;

            }

        }
        else
        {
            entity._filename = filename;
        }
        if (ckk)
        {
            entity._v_id = Int32.Parse(ddlvillage.SelectedValue);
            entity._type = (ddltype.SelectedValue);
            entity._title = txttitle.Text;
            entity._description = txtdescription.Text;
            int update = dal.update_related_file(entity, fileid);
            if (update > 0)
            {
                lblmsg.Text = "Record Update Successfuly";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                if (FileUpload1.HasFile)
                {
                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(Server.MapPath(@"~\WriteReadData\UserFiles\" + filename));
                    if (fileinfo.Exists)
                    {
                        fileinfo.Delete();
                    }
                }
                //-------------
                Session["msg"] = "Record has been Update successfully.";
                Session["BackUrl"] = "~/auth/adminpanel/upload_file_imege_manegement.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Record isn't Updated Please check file/image formate.";
                Session["BackUrl"] = "~/auth/adminpanel/upload_file_imege_manegement.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        filldeatil();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("upload_file_imege_manegement.aspx");
    }
}
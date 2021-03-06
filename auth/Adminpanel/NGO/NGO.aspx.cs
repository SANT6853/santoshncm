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
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_NGO : CrsfBase
{
    Project_Variables p_Var = new Project_Variables();

    AddNgoEntity Entity = new AddNgoEntity();
    NgoBal bal = new NgoBal();
    string newfilename;
    common com_Obj = new common();
    DataSet EditDs;
    static string name, phoneno, mobno, remark, address, amount, workdone, attechment;
    static int id;
    public string mime = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserType"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }


        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("3"))
            {
               
                bindngo();
                filldropedown(Convert.ToInt32(Session["PermissionState"]));
              
               
            }
            //else if (Session["UserType"].ToString().Equals("3"))
            //{
              
            //    bindngo();
            //    filldropedown();
               

            //}
        }
       


    }
    protected void gvforngo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvforngo.PageIndex = e.NewPageIndex;
        bindngo();
    }
    public void bindngo()
    {
        DataSet ds = bal.Showrecord();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforngo.DataSource = ds;
            gvforngo.DataBind();
        }
    }

    protected void imgbtnsave_Click(object sender, EventArgs e)
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
                   // if (Page.IsValid)
                   // {
                        Entity.NGONAME = txtngoname.Text;
                        Entity.NGOADDRES = txtaddress.Text;
                        Entity.NGOMOBILENO = txtmobno.Text;
                        Entity.NGOPHONENO = txtphoneno.Text;
                        Entity.NGOREMARKS = txtremarks.Text;
                        Entity.SubmittedByUserID = Convert.ToInt32(Session["User_Id"]);
                        //Entity.NGOAMOUNT = Int64.Parse(txtamaunt.Text);
                        Entity.WORKDONE = txtworkdone.Text;
                        Entity.PermissionStateID = Convert.ToInt32(Session["PermissionState"]);
                        if (FileUpload1.HasFile)
                        {
                            bool fi = Upload_Pdf();
                            if (fi)
                            {
                                Entity.NGOFILENAME = newfilename;
                            }
                        }
                        else
                        {
                            Entity.NGOFILENAME = "";

                        }

                        int i = bal.Addngo(Entity);
                        if (i > 0)
                        {
                            lblmsg.Text = "NGO Add Successfully";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            reset();
                            bindngo();
                            filldropedown(Convert.ToInt32(Session["PermissionState"]));
                        }

                    }
                   // }
                //}
            }

        }
        catch
        {
            throw;
        }
      // }
    }
    
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        reset();
        ModalPopupaddngo.Show();
    }
    protected void imgbtncancle_Click(object sender, EventArgs e)
    {
        reset();
        ModalPopupaddngo.Hide();
    }
    protected void btnngo_Click(object sender, EventArgs e)
    {
        btnupdate.Visible = false;
        btnreset.Visible = false;
        imgbtnsave.Visible = true;
        imgbtnreset.Visible = true;
        hylinkattechmen.Visible = false;
        reset();
        ModalPopupaddngo.Show();
    }
    public void reset()
    {
        txtngoname.Text = "";
        txtaddress.Text = "";
        // txtamaunt.Text = "";
        txtmobno.Text = "";
        txtphoneno.Text = "";
        txtremarks.Text = "";
        txtworkdone.Text = "";
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

        string path;
        string fext1 = "";
        fext1 = System.IO.Path.GetExtension(this.FileUpload1.FileName.ToString());
        bool s = UploadFile.GetActualFileType(FileUpload1.PostedFile.InputStream);
        Miscelleneous_DL dl = new Miscelleneous_DL();
        HttpPostedFile file = FileUpload1.PostedFile;
        byte[] document = new byte[file.ContentLength];
        file.InputStream.Read(document, 0, file.ContentLength);
        System.UInt32 mimetype;
        FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
        System.IntPtr mimeTypePtr = new IntPtr(mimetype);
        mime = Marshal.PtrToStringUni(mimeTypePtr);
        Marshal.FreeCoTaskMem(mimeTypePtr);
        if (FileUpload1.PostedFile != null)
        {
             p_Var.ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
             p_Var.ext = p_Var.ext.ToUpper();
                                   
            int count = FileUpload1.PostedFile.FileName.Split('.').Length - 1;
            string contenttype = FileUpload1.PostedFile.ContentType.ToString();
            //if (count >= 2)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
            //    return;
            //}

            // if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || (p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed")) || (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png")) || (p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png")))

            if (fext1.Equals(".pdf") && mime.ToString().Equals("application/pdf") || fext1.Equals(".PDF") && mime.ToString().Equals("application/pdf") 
                || fext1.Equals(".jpg")&& mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") 
                || fext1.Equals(".JPG")&& mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") 
                || fext1.Equals(".jpeg")&& mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream")
               || fext1.Equals(".JPEG")&& mime.ToString().Equals("image/pjpeg")|| mime.ToString().Equals("application/octet-stream") 
               || fext1.Equals(".xls") && mime.ToString().Equals("application/x-zip-compressed")
               || fext1.Equals(".doc")&& mime.ToString().Equals("application/x-zip-compressed")  || fext1.Equals(".docx") && mime.ToString().Equals("application/x-zip-compressed") || fext1.Equals(".xlsx")&& mime.ToString().Equals("application/x-zip-compressed"))
            {



                path = ResolveUrl("~") + "WriteReadData/NgoFiles";
                newfilename = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                path = ResolveUrl("~") + "WriteReadData/NgoFiles/" + newfilename;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                ViewState["newfilename"] = newfilename;
                string lbldisplay = ViewState["newfilename"].ToString();

                return true;

            }
            else
            {
                string msg = "Document is in incorrect formate ";
                lblmsg.Text = msg;
                return false;
                //put the validation for wrong file 
            }
        }
        else
        {
            return false;
        }
    }

    protected void gvforngo_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        if (e.CommandName == "Delete")
                        {
                            int ngoid = Int32.Parse(e.CommandArgument.ToString());
                            int i = bal.Delete_Ngo(ngoid);
                            if (i > 0)
                            {
                                lblmsg.Text = "NGO Deleted Successfully";
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {

                                lblmsg.Text = "NGO is not Deleted Successfully";
                                lblmsg.ForeColor = System.Drawing.Color.Red;
                            }

                        }
                        if (e.CommandName == "Edit")
                        {
                            id = Int32.Parse(e.CommandArgument.ToString());
                            EditDs = bal.fech_ngo_by_id(id);
                            if (EditDs.Tables[0].Rows.Count > 0)
                            {

                                reset();
                                txtngoname.Text = EditDs.Tables[0].Rows[0]["name"].ToString();
                                name = EditDs.Tables[0].Rows[0]["name"].ToString();
                                txtphoneno.Text = EditDs.Tables[0].Rows[0]["phone_no"].ToString();
                                phoneno = EditDs.Tables[0].Rows[0]["phone_no"].ToString();
                                txtmobno.Text = EditDs.Tables[0].Rows[0]["mobile_no"].ToString();
                                mobno = EditDs.Tables[0].Rows[0]["mobile_no"].ToString();
                                txtremarks.Text = EditDs.Tables[0].Rows[0]["remarks"].ToString();
                                remark = EditDs.Tables[0].Rows[0]["remarks"].ToString();
                                //txtamaunt.Text = EditDs.Tables[0].Rows[0]["amount_given"].ToString();
                                // amount = EditDs.Tables[0].Rows[0]["amount_given"].ToString();
                                txtworkdone.Text = EditDs.Tables[0].Rows[0]["work_done"].ToString();
                                workdone = EditDs.Tables[0].Rows[0]["work_done"].ToString();
                                txtaddress.Text = EditDs.Tables[0].Rows[0]["address"].ToString();
                                address = EditDs.Tables[0].Rows[0]["address"].ToString();
                                attechment = EditDs.Tables[0].Rows[0]["releted_attchment"].ToString();
                                hylinkattechmen.Visible = true;
                                hylinkattechmen.NavigateUrl = "~/WriteReadData/NgoFiles/" + attechment;
                                btnupdate.Visible = true;
                                btnreset.Visible = true;
                                imgbtnsave.Visible = false;
                                imgbtnreset.Visible = false;
                                ModalPopupaddngo.Show();
                            }
                            lblmsg.Text = id.ToString();
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
    public void filldropedown(int stateId)
    {
        DataTable dt = NgoDal.binddropedownngo(stateId);
        if (dt.Rows.Count > 0)
        {
            ddlserchngo.DataSource = dt;
            ddlserchngo.DataTextField = "name";
            ddlserchngo.DataValueField = "id";
            ddlserchngo.DataBind();
            ddlserchngo.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void serch()
    {
        int id = Int32.Parse(ddlserchngo.SelectedValue);
        if (id == 0)
        {
            bindngo();
        }
        else
        {
            DataSet ds = bal.fech_ngo_by_id(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforngo.DataSource = ds;
                gvforngo.DataBind();
            }
        }
    }
    protected void gvforngo_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Entity.NGONAME = txtngoname.Text;
        Entity.NGOADDRES = txtaddress.Text;
        Entity.NGOMOBILENO = txtmobno.Text;
        Entity.NGOPHONENO = txtphoneno.Text;
        Entity.NGOREMARKS = txtremarks.Text;
        Entity.SubmittedByUserID = Convert.ToInt32(Session["User_Id"]);
        Entity.WORKDONE = txtworkdone.Text;
        if (FileUpload1.HasFile)
        {
            bool fi = Upload_Pdf();
            if (fi)
            {
                Entity.NGOFILENAME = newfilename;
            }
        }
        else
        {
            Entity.NGOFILENAME = attechment;

        }

        int i = bal.updatengo_information(Entity, id);
        if (i > 0)
        {
            lblmsg.Text = "Record Update Successfully";
            lblmsg.ForeColor = System.Drawing.Color.Green;
            reset();
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtaddress.Text = address;
        //txtamaunt.Text = amount;
        txtmobno.Text = mobno;
        txtngoname.Text = name;
        txtremarks.Text = remark;
        txtphoneno.Text = phoneno;
        txtworkdone.Text = workdone;
        ModalPopupaddngo.Show();
    }
    protected void ddlserchngo_SelectedIndexChanged(object sender, EventArgs e)
    {
        serch();

    }
    protected void gvforngo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bindngo();
    }
}
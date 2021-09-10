using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_ProcessManegment_DfoUser_AddProcessDFO : System.Web.UI.Page
{
    public static string HeaderTitle = string.Empty;
    string LoginUserid;
    int LoginUsertype;
    public String characters = "abcdeCDEfghijkzMABFHIJKLNOlmnopqrPQRSTstuvwxyUVWXYZ";
    //---------------
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();
    //-------------
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();

    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    Miscelleneous_BL obMiscell = new Miscelleneous_BL();
    DataSet ds = new DataSet();
    Project_Variables p_Val = new Project_Variables();
    public string mime = "";
    //--------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");

        }
        HiddenField2.Value = com_Obj.fordate();
        Page.Header.DataBind();

        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        LoginUserid = m.Id;
        LoginUsertype = m.UserType;
        if (!Page.IsPostBack)
        {
           // txtVillage.Enabled = false;
           // txtState.Enabled = false;
           // txtGramPanchayat.Enabled = false;
          //  txtDistrict.Enabled = false;
         //   txtTigerReserve.Enabled = false;
            if (Request.QueryString["id"] != null || Request.QueryString["id"] != "0")
            {
                int Vill_ID = 0;
                if(Request.QueryString["id"]=="")
                {
                     Vill_ID =0;
                }
                else
                {
                     Vill_ID = Convert.ToInt32(Request.QueryString["id"]);
                }
                p_Val.dSet = _tigerReserverBl.BindStates(Vill_ID);
                if (p_Val.dSet.Tables[0].Rows.Count > 0)
                {
                    txtState.Text = p_Val.dSet.Tables[0].Rows[0]["StateName"].ToString();
                    txtDistrict.Text = p_Val.dSet.Tables[0].Rows[0]["DistName"].ToString();
                    txtGramPanchayat.Text = p_Val.dSet.Tables[0].Rows[0]["GramPanchayatName"].ToString();
                    txtTigerReserve.Text = p_Val.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
                    txtVillage.Text = p_Val.dSet.Tables[0].Rows[0]["VILL_NM"].ToString();
                    if (p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"].ToString() == "1")
                    {
                         divSubmit.Visible = true;
                    }
                    else
                    {
                        divSubmit.Visible = true;
                    }
                }
                else
                {
                    divSubmit.Visible = true;
                }

                

            }
            PrivewPreform();

            DdlNotified1_a.Focus();
            String p = UniqueNumber();

            LblTokenID.Text = p.ToString().ToUpper() + "BY" + Session["UserName"].ToString();
            Fill_VillageCode_And_Name();
            if (Request.QueryString["tid"] != null)
            {
                //   BtnBack.Visible = true;
                HeaderTitle = "Reply Process Management.";

                // btnsave.Text = "Update";
            }
            else
            {

                //  BtnBack.Visible = false;

                HeaderTitle = "Add Process Management.";


            }
        }
    }
    public void ServerValidation(object source, ServerValidateEventArgs args)
    {
        // args.IsValid = DropDownList1.SelectedIndex == 1 || TextBox1.Text.Length > 0;
        if (ddlselectname.SelectedIndex == 0 && ddlselectname.SelectedValue != "")
        {

            args.IsValid = false;
        }
        else
        {

            args.IsValid = true;
        }
    }
    public void Fill_VillageCode_And_Name()
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_NameNew(Convert.ToInt32(Session["User_Id"]));

            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem li2 = new ListItem("--Select--", "0");
                ddlselectname.Items.Add(li2);
                list = com_Obj.FillDropDownListProcessManagement(ds, 0, "VILL_NM", "VILL_CD");
                int i = list.Count - 1;
                int j = 0;
                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["VILL_ID"].ToString());
                    ++j;
                    ddlselectname.Items.Add(li);

                }


            }
            else
            {
                
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public string UniqueNumber()
    {
        Random unique1 = new Random();
        string s = "TOK";
        int unique;
        int n = 0;
        while (n < 10)
        {
            if (n % 2 == 0)
            {
                s += unique1.Next(10).ToString();

            }
            else
            {
                unique = unique1.Next(52);
                if (unique < this.characters.Length)
                    s = String.Concat(s, this.characters[unique]);
            }
            //Label2.Text = s.ToString();
            n++;
        }
        return s;
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
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        LblerrorFileUpload.Text = string.Empty;string sDateTime;
        if (Page.IsValid)
        {//FromPersonID,ToPersonID,ToPersonUserName,FromPersonUserName,Action
            if(string.IsNullOrEmpty(txtSurveyDate.Text))
            {
                _TigerReserveOB.SurveyDate = null;
            }
            else
            {
                    //  string[] sDate = txtSurveyDate.Text.Split('/');
                   //    sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                 //   _TigerReserveOB.SurveyDate =Convert.ToDateTime(sDateTime);
                     //   TigerRe
                _TigerReserveOB.SurveyDate = DateTime.ParseExact(txtSurveyDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
              //  _TigerReserveOB.SurveyDate= DateTime.ParseExact(txtSurveyDate.Text, "'\"'dd/MM/yyyy'T'HH:mm:ss.fff'Z\"'", null);

            }
           
            _TigerReserveOB.Surveyor = txtSurveyor.Text.Trim();
            _TigerReserveOB.DesignationSurveyor = txtDesignationSurveyor.Text.Trim();
            _TigerReserveOB.sVillageID = Request.QueryString["id"].ToString();

            _TigerReserveOB.RecordCreatedByUserID = Convert.ToInt32(Session["User_Id"]);
            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = LblTokenID.Text.Trim();
            _TigerReserveOB.FromPersonID = Convert.ToInt32(Session["User_Id"]);
            _TigerReserveOB.ToPersonID = Convert.ToInt32(Session["CmnStateUser"]);
            if(Session["UserType"].ToString().Equals("1"))
            {
                _TigerReserveOB.ToPersonUserName ="0";
            }
            else
            {
                _TigerReserveOB.ToPersonUserName = Session["DashStateUserName"].ToString();
            }
           
            _TigerReserveOB.FromPersonUserName = Session["UserName"].ToString();
            int PkAutoID = _tigerReserverBl.InsertDFOtoReserve(_TigerReserveOB);
            
            if (Request.QueryString["p"] == "Pre")
            {
                _TigerReserveOB.Action = 0;
            }
            else
            {
                _TigerReserveOB.Action = 1;
            }
            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = LblTokenID.Text.Trim();
            _TigerReserveOB.TblFromDfoToReservePkAutoID = PkAutoID;
            _TigerReserveOB.contentbody_DdlNotified1_a = HttpUtility.HtmlEncode(DdlNotified1_a.SelectedValue);
            if (TxtDateNotification1_b.Text.Trim() != "")
            {
                   string sDateTime1;

                   // string[] sDate = TxtDateNotification1_b.Text.Split('/');
                   // sDateTime1 = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                   // _TigerReserveOB.contentbody_TxtDateNotification1_b =Convert.ToDateTime(sDateTime1);

               _TigerReserveOB.contentbody_TxtDateNotification1_b = DateTime.ParseExact(TxtDateNotification1_b.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateNotification1_b = null;
            }
            _TigerReserveOB.contentbody_TxtAreaHa1_c = Convert.ToDecimal(TxtAreaHa1_c.Text.Trim());
            _TigerReserveOB.contentbody_TxtCompliance1_d = HttpUtility.HtmlEncode(TxtCompliance1_d.Text.Trim());
            _TigerReserveOB.contentbody_DdlNotified2_a = HttpUtility.HtmlEncode(DdlNotified2_a.SelectedValue);
            if (TxtDateNotification2_b.Text.Trim() != "")
            {
                _TigerReserveOB.contentbody_TxtDateNotification2_b = DateTime.ParseExact(TxtDateNotification2_b.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
              
            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateNotification2_b = null;
            }
            _TigerReserveOB.contentbody_TxtAreaHa2_c = Convert.ToDecimal(TxtAreaHa2_c.Text.Trim());
            _TigerReserveOB.contentbody_DdlExpertCommittee2_d = HttpUtility.HtmlEncode(DdlExpertCommittee2_d.SelectedValue);
            if (TxtDateConstitution2_e.Text.Trim() != "")
            {
                _TigerReserveOB.contentbody_TxtDateConstitution2_e = DateTime.ParseExact(TxtDateConstitution2_e.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //Convert.ToDateTime(TxtDateConstitution2_e.Text.Trim());
            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateConstitution2_e = null;
            }
            _TigerReserveOB.contentbody_DdlConsultationGramSabha2_f = HttpUtility.HtmlEncode(DdlConsultationGramSabha2_f.SelectedValue);
            _TigerReserveOB.contentbody_TxtNameGramSabha2_g = HttpUtility.HtmlEncode(TxtNameGramSabha2_g.Text.Trim());

            Miscelleneous_DL dl = new Miscelleneous_DL();
            HttpPostedFile file = FileUploadMapCTH2_h.PostedFile;
            byte[] document = new byte[file.ContentLength];
            file.InputStream.Read(document, 0, file.ContentLength);
            System.UInt32 mimetype;
            FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
            System.IntPtr mimeTypePtr = new IntPtr(mimetype);
            mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            //View
      
            //----------start 1----------------------------FileUploadMapCTH2_h--
            if (FileUploadMapCTH2_h.HasFile == true)
            {
                bool ChkMaliciousType = true;
                string path;
                string fext1 = "";
                string filename;

                fext1 = System.IO.Path.GetExtension(this.FileUploadMapCTH2_h.FileName.ToString());

               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                   if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadMapCTH2_h.PostedFile.InputStream);
                }
                if ((fext1.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (fext1.Equals(".JPG") && mime.ToString().Equals("image/pjpeg"))|| (fext1.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (fext1.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")))
                {

                    ChkMaliciousType = obMiscell.GetActualFileType(FileUploadMapCTH2_h.PostedFile.InputStream);

                }

                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadMapCTH2_h.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadMapCTH2_h.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadMapCTH2_h.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUploadMapCTH2_h = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 2.Buffer or Peripheral Area in child label title:Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only) in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadMapCTH2_h.Focus();
                    FileUploadMapCTH2_h.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUploadMapCTH2_h = null;
            }
            //--------------start 1-----------------------
            //----------start 2------------------------------
            if (FileUploadUploadfile2_i.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
              //  fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_i.FileName.ToString());
                if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                             if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadUploadfile2_i.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadUploadfile2_i.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadUploadfile2_i.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadUploadfile2_i.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUploadUploadfile2_i = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 2.Buffer or Peripheral Area in child label title:Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only) in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadUploadfile2_i.Focus();
                    FileUploadUploadfile2_i.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUploadUploadfile2_i = null;
            }
            //--------------start 2-----------------------
            // _TigerReserveOB.contentbody_FileUploadUploadfile2_i = "kjkjk";//----------------
            //----------start 3------------------------------
            if (FileUploadUploadfile2_j.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_j.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                             if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadUploadfile2_j.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadUploadfile2_j.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadUploadfile2_j.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadUploadfile2_j.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUploadUploadfile2_j = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 2.Buffer or Peripheral Area in child label title:Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only) in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadUploadfile2_j.Focus();
                    FileUploadUploadfile2_j.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUploadUploadfile2_j = null;
            }
            //--------------start 3-----------------------
            // _TigerReserveOB.contentbody_FileUploadUploadfile2_j = "hhghg";//--------------
            _TigerReserveOB.contentbody_DdlCompleted3_a = HttpUtility.HtmlEncode(DdlCompleted3_a.SelectedValue);
            //----------start 4------------------------------
            if (FileUploadCompleted3_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCompleted3_a.FileName.ToString());
                if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCompleted3_a.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {



                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCompleted3_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCompleted3_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCompleted3_a.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUploadCompleted3_a = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 3.Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers in child label title:Completed  in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCompleted3_a.Focus();
                    FileUploadCompleted3_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUploadCompleted3_a = null;
            }
            //--------------start 4-----------------------
            // _TigerReserveOB.contentbody_FileUploadCompleted3_a = "hghg";//----------
            _TigerReserveOB.contentbody_DdlProvided4_a = HttpUtility.HtmlEncode(DdlProvided4_a.SelectedValue);
            _TigerReserveOB.contentbody_DdlObtained5_a = HttpUtility.HtmlEncode(DdlObtained5_a.SelectedValue);
            _TigerReserveOB.contentbody_DdlObtained6_a = HttpUtility.HtmlEncode(DdlObtained6_a.SelectedValue);
            //----------start 5------------------------------
            if (FileUpload6_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUpload6_a.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                 if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload6_a.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {



                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUpload6_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload6_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUpload6_a.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUpload6_a = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 6.Voluntary consent of individuals affected in child label title:Obtained   in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUpload6_a.Focus();
                    FileUpload6_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUpload6_a = null;
            }
            //--------------start 5-----------------------
            // _TigerReserveOB.contentbody_FileUpload6_a = "jkjkj";//----
            _TigerReserveOB.contentbody_DdlProvided7_a = HttpUtility.HtmlEncode(DdlProvided7_a.SelectedValue);
            //----------start 6------------------------------
            if (FileUploadProvided7_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadProvided7_a.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                 if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadProvided7_a.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {



                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadProvided7_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadProvided7_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadProvided7_a.PostedFile.SaveAs(Server.MapPath(path));
                    _TigerReserveOB.contentbody_FileUploadProvided7_a = filename;
                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 7.Facilities & Land Allocation At The Resettlement Location in child label title:Provided in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;
                    FileUploadProvided7_a.Focus();
                    FileUploadProvided7_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUploadProvided7_a = null;
            }
            //--------------start 6-----------------------
            // _TigerReserveOB.contentbody_FileUploadProvided7_a = "jkjkjk";//----
            _TigerReserveOB.contentbody_DdlConstituted8_a_a = HttpUtility.HtmlEncode(DdlConstituted8_a_a.SelectedValue);
            //----------start 7------------------------------
            if (FileUpload8_a_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUpload8_a_a.FileName.ToString());
             //   if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
               if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload8_a_a.PostedFile.InputStream);
                }
                if (ChkMaliciousType == true)
                {
                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUpload8_a_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload8_a_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUpload8_a_a.PostedFile.SaveAs(Server.MapPath(path));
                    _TigerReserveOB.contentbody_FileUpload8_a_a = filename;
                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal in child label title:Sub Divisional Level Committee Constituted in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUpload8_a_a.Focus();
                    FileUpload8_a_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUpload8_a_a = null;
            }
            //--------------start 7-----------------------
            // _TigerReserveOB.contentbody_FileUpload8_a_a = "jkjkjk";//---
            if (TxtDateofconstitution8_a_b.Text.Trim() != "")
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_a_b = DateTime.ParseExact(TxtDateofconstitution8_a_b.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                // Convert.ToDateTime(TxtDateofconstitution8_a_b.Text.Trim());
            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_a_b = null;
            }
            _TigerReserveOB.contentbody_DdlConstituted8_b_a = HttpUtility.HtmlEncode(DdlConstituted8_b_a.SelectedValue);
            //----------start 8------------------------------
            if (FileUpload8_b_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUpload8_b_a.FileName.ToString());
                             if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload8_b_a.PostedFile.InputStream);
                }

                if (ChkMaliciousType == true)
                {
                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUpload8_b_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload8_b_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUpload8_b_a.PostedFile.SaveAs(Server.MapPath(path));
                    _TigerReserveOB.contentbody_FileUpload8_b_a = filename;
                }
                else
                {
                    LblerrorFileUpload.Text = "Tab (legal form) in 8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal in child label title:District Level Committee Constituted in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;
                    FileUpload8_b_a.Focus();
                    FileUpload8_b_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUpload8_b_a = null;
            }
            //--------------start 8-----------------------
            //  _TigerReserveOB.contentbody_FileUpload8_b_a = "kjkjk";//---------------

            if (TxtDateofconstitution8_b_b.Text.Trim() != "")
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_b_b = DateTime.ParseExact(TxtDateofconstitution8_b_b.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                // Convert.ToDateTime(TxtDateofconstitution8_b_b.Text.Trim());
            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_b_b = null;
            }

            _TigerReserveOB.contentbody_Ddl8_c_a = HttpUtility.HtmlEncode(Ddl8_c_a.SelectedValue);
            //----------start 9------------------------------
            if (FileUpload8_c_a.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUpload8_c_a.FileName.ToString());
                 if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUpload8_c_a.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUpload8_c_a.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload8_c_a.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUpload8_c_a.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.contentbody_FileUpload8_c_a = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (legal form) in 8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal in child label title:State Level Monitoring Committee Constituted in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUpload8_c_a.Focus();
                    FileUpload8_c_a.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.contentbody_FileUpload8_c_a = null;
            }
            //--------------start 9-----------------------
            //  _TigerReserveOB.contentbody_FileUpload8_c_a = "hghghg";//----------
            if (TxtDateofconstitution8_c_b.Text.Trim() != "")
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_c_b = DateTime.ParseExact(TxtDateofconstitution8_c_b.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //  Convert.ToDateTime(TxtDateofconstitution8_c_b.Text.Trim());
            }
            else
            {
                _TigerReserveOB.contentbody_TxtDateofconstitution8_c_b = null;
            }
            _TigerReserveOB.Form1contentbody_RdbCheckItems1_0 = HttpUtility.HtmlEncode(RdbCheckItems1.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems1 = HttpUtility.HtmlEncode(TextCheckItems1.Text.Trim());
            //----------start 10------------------------------
            if (FileUploadCheckItems1.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems1.FileName.ToString());
              if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems1.PostedFile.InputStream);
                }

                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems1.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems1.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems1 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:1 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems1.Focus();
                    FileUploadCheckItems1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems1 = null;
            }
            //--------------start 10-----------------------
            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems1 = "jhjh";//-----------
            _TigerReserveOB.Form1contentbody_RdbCheckItems2_0 = HttpUtility.HtmlEncode(RdbCheckItems2.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems2 = HttpUtility.HtmlEncode(TextCheckItems2.Text.Trim());
            //----------start 11------------------------------
            if (FileUploadCheckItems2.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems2.FileName.ToString());
                //if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                 if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems2.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems2.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems2.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems2.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems2 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:2 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems2.Focus();
                    FileUploadCheckItems2.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems2 = null;
            }
            //--------------start 11-----------------------
            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems2 = "kjkjk";//---
            _TigerReserveOB.Form1contentbody_RdbCheckItems3_0 = HttpUtility.HtmlEncode(RdbCheckItems3.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems3 = HttpUtility.HtmlEncode(TextCheckItems3.Text.Trim());
            //----------start 12------------------------------
            if (FileUploadCheckItems3.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems3.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems3.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems3.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems3.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems3.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems3 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:3 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems3.Focus();
                    FileUploadCheckItems3.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems3 = null;
            }
            //--------------start 12-----------------------
            // _TigerReserveOB.Form1contentbody_FileUploadCheckItems3 = "hjhjh";//------------
            _TigerReserveOB.Form1contentbody_RdbCheckItems4_0 = HttpUtility.HtmlEncode(RdbCheckItems4.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems4 = HttpUtility.HtmlEncode(TextCheckItems4.Text.Trim());
            //----------start 13------------------------------
            if (FileUploadCheckItems4.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems4.FileName.ToString());
              //  if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                             if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems4.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems4.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems4.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems4.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems4 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:4 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems4.Focus();
                    FileUploadCheckItems4.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems4 = null;
            }
            //--------------start 13-----------------------
            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems4 = "fdfd";//---
            _TigerReserveOB.Form1contentbody_RdbCheckItems5_0 = HttpUtility.HtmlEncode(RdbCheckItems5.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems5 = HttpUtility.HtmlEncode(TextCheckItems5.Text.Trim());
            //----------start 14------------------------------
            if (FileUploadCheckItems5.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems5.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                 if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems5.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems5.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems5.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems5.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems5 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:5 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems5.Focus();
                    FileUploadCheckItems5.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems5 = null;
            }
            //--------------start 14-----------------------
            //_TigerReserveOB.Form1contentbody_FileUploadCheckItems5 = "fdfdf";//------------
            _TigerReserveOB.Form1contentbody_RdbCheckItems6_0 = HttpUtility.HtmlEncode(RdbCheckItems6.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems6 = HttpUtility.HtmlEncode(TextCheckItems6.Text.Trim());
            //----------start 15------------------------------
            if (FileUploadCheckItems6.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems6.FileName.ToString());
               // if (fext1 == ".pdf" && mime.ToString().Equals("application/pdf"))
                if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems6.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems6.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems6.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems6.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems6 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:6 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems6.Focus();
                    FileUploadCheckItems6.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems6 = null;
            }
            //--------------start 15-----------------------
            //_TigerReserveOB.Form1contentbody_FileUploadCheckItems6 = "gfgf";//---
            _TigerReserveOB.Form1contentbody_RdbCheckItems7_0 = HttpUtility.HtmlEncode(RdbCheckItems7.SelectedValue);
            _TigerReserveOB.Form1contentbody_TextCheckItems7 = HttpUtility.HtmlEncode(TextCheckItems7.Text.Trim());
            //----------start 16------------------------------
            if (FileUploadCheckItems7.HasFile == true)
            {
                string path;
                string fext1 = "";
                string filename;
                bool ChkMaliciousType = true;
                fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems7.FileName.ToString());
                           if (fext1 == ".pdf" && (mime.ToString().Equals("application/pdf")||(mime.ToString().Equals("application/octet-stream"))))
                {
                    ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadCheckItems7.PostedFile.InputStream);
                }


                if (ChkMaliciousType == true)
                {


                    path = ResolveUrl("~") + "WriteReadData/UserFiles";
                    filename = com_Obj.getUniqueFileName(FileUploadCheckItems7.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUploadCheckItems7.PostedFile.FileName), fext1);
                    path = ResolveUrl("~") + "WriteReadData/UserFiles/" + filename;
                    FileUploadCheckItems7.PostedFile.SaveAs(Server.MapPath(path));

                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems7 = filename;


                }
                else
                {

                    LblerrorFileUpload.Text = "Tab (form 1) in SNO:7 in child label title:Result in don't allow malicous file !.";
                    LblerrorFileUpload.ForeColor = System.Drawing.Color.Red;

                    FileUploadCheckItems7.Focus();
                    FileUploadCheckItems7.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                _TigerReserveOB.Form1contentbody_FileUploadCheckItems7 = null;
            }
            //--------------start 16-----------------------
            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems7 = "gfgf";//---
            _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);


            Project_Variables p_Var = new Project_Variables();
            DataTable fileUpload = new DataTable();
            DataTable fileUpload1 = new DataTable();
            DataSet dSet = new DataSet();
            fileUpload.Columns.Add("FileName", typeof(string));
            fileUpload1.Columns.Add("FileName1", typeof(string));
            p_Var.url = ResolveUrl("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/UserFiles" + "/";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                string date = System.DateTime.Now.ToString("yyyymmss");



                HttpPostedFile PostedFile = Request.Files["Free_informed" + i];
                HttpPostedFile PostedFile1 = Request.Files["Voluntary" + i];
                HttpPostedFile PostedFile2 = Request.Files[i];
                string FileName = "";
                string FileName1 = "";
                try
                {
                    if (PostedFile.ContentLength > 0)
                    {
                        DataRow dr = fileUpload.NewRow();
                        FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        PostedFile.SaveAs(Server.MapPath(p_Var.url) + System.DateTime.Now.ToString("yyyymmss") + FileName);
                        dr["FileName"] = System.DateTime.Now.ToString("yyyymmss") + FileName;
                        fileUpload.Rows.Add(dr);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (PostedFile1.ContentLength > 0)
                    {
                        DataRow dr = fileUpload1.NewRow();
                        FileName1 = System.IO.Path.GetFileName(PostedFile1.FileName);
                        PostedFile1.SaveAs(Server.MapPath(p_Var.url) + System.DateTime.Now.ToString("yyyymmss") + FileName1);
                        dr["FileName1"] = System.DateTime.Now.ToString("yyyymmss") + FileName1;
                        fileUpload1.Rows.Add(dr);
                    }
                }
                catch (Exception)
                {

                }
            }

            _TigerReserveOB.Freeinformedconsent_FileUploadCheckItems5 = fileUpload;
            _TigerReserveOB.Voluntaryconsent_FileUploadCheckItems6 = fileUpload1;
            // Insert Data From survey Information Deepak

            if (RdbAnganwadi.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAnganwadi = RdbAnganwadi.SelectedValue.ToString();
                _TigerReserveOB.Anganwadi = TxtRdbAnganwadi.Text;
            }
            else
            {
                _TigerReserveOB.RdbAnganwadi = null;
                _TigerReserveOB.Anganwadi = null;
            }
            if (RdbPanchayatOffice.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbPanchayatOffice = RdbPanchayatOffice.SelectedValue.ToString();
                _TigerReserveOB.PanchayatOffice = TxtRdbPanchayatOffice.Text;
            }
            else
            {
                _TigerReserveOB.RdbPanchayatOffice = null;
                _TigerReserveOB.PanchayatOffice = null;
            }
            if (RdbAllWeatherRoad.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAllWeatherRoad = RdbAllWeatherRoad.SelectedValue.ToString();
                _TigerReserveOB.AllWeatherRoad = TxtRdbAllWeatherRoad.Text;
            }
            else
            {
                _TigerReserveOB.RdbAllWeatherRoad = null;
                _TigerReserveOB.AllWeatherRoad = null;
            }
            if (RdbPostOffice.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbPostOffice = RdbPostOffice.SelectedValue.ToString();
                _TigerReserveOB.PostOffice = TxtRdbPostOffice.Text;
            }
            else
            {
                _TigerReserveOB.RdbPostOffice = null;
                _TigerReserveOB.PostOffice = null;
            }
            if (RdbBank.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbBank = RdbBank.SelectedValue.ToString();
                _TigerReserveOB.Bank = TxtRdbBank.Text;
            }
            else
            {
                _TigerReserveOB.RdbBank = null;
                _TigerReserveOB.Bank = null;
            }
            if (RdbPDSShop.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbPDSShop = RdbPDSShop.SelectedValue.ToString();
                _TigerReserveOB.PDSShop = TxtRdbPDSShop.Text;
            }
            else
            {
                _TigerReserveOB.RdbPDSShop = null;
                _TigerReserveOB.PDSShop = null;
            }
            if (RdbPublicTelephonePCo.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbPublicTelephonePCo = RdbPublicTelephonePCo.SelectedValue.ToString();
                _TigerReserveOB.PublicTelephonePCo = TxtRdbPublicTelephonePCo.Text;
            }
            else
            {
                _TigerReserveOB.RdbPublicTelephonePCo = null;
                _TigerReserveOB.PublicTelephonePCo = null;
            }
            if (RdbMobileSignal.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbMobileSignal = RdbMobileSignal.SelectedValue.ToString();
                _TigerReserveOB.MobileSignal = TxtRdbMobileSignal.Text;
            }
            else
            {
                _TigerReserveOB.RdbMobileSignal = null;
                _TigerReserveOB.MobileSignal = null;
            }
            if (RdbAccessibiliythealthCare.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAccessibiliythealthCare = RdbAccessibiliythealthCare.SelectedValue.ToString();
                _TigerReserveOB.AccessibiliythealthCare = TxtAccessibiliythealthCare.Text;
            }
            else
            {
                _TigerReserveOB.RdbAccessibiliythealthCare = null;
                _TigerReserveOB.AccessibiliythealthCare = null;
            }
            if (RdbAccessibiliyRoad.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAccessibiliyRoad = RdbAccessibiliyRoad.SelectedValue.ToString();
                _TigerReserveOB.AccessibiliyRoad = TxtAccessibiliyRoad.Text;
            }
            else
            {
                _TigerReserveOB.RdbAccessibiliyRoad = null;
                _TigerReserveOB.AccessibiliyRoad = null;
            }
            if (RdbAccessbilitySchool.SelectedValue == "Yes")
            {

                _TigerReserveOB.RdbAccessbilitySchool = RdbAccessbilitySchool.SelectedValue.ToString();
                _TigerReserveOB.Primary = TxtAccessbilitySchoolPrimary.Text;
                _TigerReserveOB.Secondary = TxtAccessbilitySchool_Secondary.Text;
                _TigerReserveOB.HighSchool = TxtAccessbilitySchool_HighSchool.Text;
                _TigerReserveOB.College = TxtAccessbilitySchool_College.Text;
            }
            else
            {
                _TigerReserveOB.RdbAccessbilitySchool = null;
                _TigerReserveOB.Primary = null;
                _TigerReserveOB.Secondary = null;
                _TigerReserveOB.HighSchool = null;
                _TigerReserveOB.College = null;
            }
            if (RdbAccessbilityElectrif.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAccessbilityElectrif = RdbAccessbilityElectrif.SelectedValue.ToString();
                _TigerReserveOB.AccessbilityElectrif = TxtAccessbilityElectrif_DurationElectricityVillages.Text;
            }
            else
            {
                _TigerReserveOB.RdbAccessbilityElectrif = null;
                _TigerReserveOB.AccessbilityElectrif = null;
            }
            if (RdbAccessiblityVeterinary.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAccessiblityVeterinary = RdbAccessiblityVeterinary.SelectedValue.ToString();
                _TigerReserveOB.AccessiblityVeterinary = TxtAccessiblityVeterinary.Text;

            }
            else
            {
                _TigerReserveOB.RdbAccessiblityVeterinary = null;
                _TigerReserveOB.AccessiblityVeterinary = null;
            }
            if (RdbAvenuesEmployment.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAvenuesEmployment = RdbAvenuesEmployment.SelectedValue.ToString();
                _TigerReserveOB.EmploymentPrimary = TxtAvenuesEmployment_Primary.Text;
                _TigerReserveOB.EmploymentSecondary = TxtAvenuesEmployment_Secondary.Text;

            }
            else
            {
                _TigerReserveOB.RdbAvenuesEmployment = null;
                _TigerReserveOB.EmploymentPrimary = null;
                _TigerReserveOB.EmploymentSecondary = null;

            }
            if (RdbHumanWildlifecon.SelectedValue == "Yes")
            {

                _TigerReserveOB.RdbHumanWildlifecon = RdbHumanWildlifecon.SelectedValue.ToString();
                _TigerReserveOB.HumanWildlifecon = TxtRdbHumanWildlifecon.Text;
            }
            else
            {
                _TigerReserveOB.RdbHumanWildlifecon = null;
                _TigerReserveOB.HumanWildlifecon = null;
            }
            if (RdbAccessFireFodNwfps.SelectedValue == "Yes")
            {
                _TigerReserveOB.RdbAccessFireFodNwfps = RdbAccessFireFodNwfps.SelectedValue.ToString();
                _TigerReserveOB.AccessFireFodNwfps = TXTAccessFireFodNwfps.Text;
            }
            else
            {
                _TigerReserveOB.RdbAccessFireFodNwfps = null;
                _TigerReserveOB.AccessFireFodNwfps = null;
            }
            _TigerReserveOB.Declaration = chbDeclaration.Checked;
            int legaform = _tigerReserverBl.InsertLegalFormAndForm1(_TigerReserveOB);
            if (Request.QueryString["p"] == "Pre")
            {
                 ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').show(); $('#myModal').modal('show');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModals').show(); $('#myModals').modal('show');", true);
            }
          
        }
    }
    #region Function for EDIT PRE FORM
    public void PrivewPreform()
    {
        TigerReserveBL TRBL = new TigerReserveBL();
        TigerReserveOB TRObj = new TigerReserveOB();
        if (Request.QueryString["p"] == "Pre")
        {
            TRObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            p_Val.dSet = TRBL.GETPrefromrecord(TRObj);
            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                txtSurveyDate.Text = p_Val.dSet.Tables[0].Rows[0]["SurveyDate"].ToString();
                txtSurveyor.Text = p_Val.dSet.Tables[0].Rows[0]["Surveyor"].ToString();
                txtDesignationSurveyor.Text = p_Val.dSet.Tables[0].Rows[0]["DesignationSurveyor"].ToString();
                lblUserName.Text= p_Val.dSet.Tables[0].Rows[0]["Username"].ToString();
                if (!string.IsNullOrEmpty(p_Val.dSet.Tables[0].Rows[0]["Declaration"].ToString()))
                {
                    if (Convert.ToBoolean(p_Val.dSet.Tables[0].Rows[0]["Declaration"]) == true)
                    {
                        chbDeclaration.Checked = true;
                    }
                }
                    if (p_Val.dSet.Tables[0].Rows[0]["RdbPanchayatOffice"].ToString() == "Yes")
                {
                    TxtRdbPanchayatOffice.Visible = true;
                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPanchayatOffice"].ToString();
                    TxtRdbPanchayatOffice.Text = p_Val.dSet.Tables[0].Rows[0]["PanchayatOffice"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAnganwadi"].ToString() == "Yes")
                {
                    TxtRdbAnganwadi.Visible = true;
                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAnganwadi"].ToString();
                    TxtRdbAnganwadi.Text = p_Val.dSet.Tables[0].Rows[0]["Anganwadi"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAllWeatherRoad"].ToString() == "Yes")
                {
                    TxtRdbAllWeatherRoad.Visible = true;
                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAllWeatherRoad"].ToString();
                    TxtRdbAllWeatherRoad.Text = p_Val.dSet.Tables[0].Rows[0]["AllWeatherRoad"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbPostOffice"].ToString() == "Yes")
                {
                    TxtRdbPostOffice.Visible = true;
                    RdbPostOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPostOffice"].ToString();
                    TxtRdbPostOffice.Text = p_Val.dSet.Tables[0].Rows[0]["PostOffice"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbBank"].ToString() == "Yes")
                {
                    TxtRdbBank.Visible = true;
                    RdbBank.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbBank"].ToString();
                    TxtRdbBank.Text = p_Val.dSet.Tables[0].Rows[0]["Bank"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbPDSShop"].ToString() == "Yes")
                {
                    TxtRdbPDSShop.Visible = true;
                    RdbPDSShop.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPDSShop"].ToString();
                    TxtRdbPDSShop.Text = p_Val.dSet.Tables[0].Rows[0]["Bank"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbPublicTelephonePCo"].ToString() == "Yes")
                {
                    TxtRdbPublicTelephonePCo.Visible = true;
                    RdbPublicTelephonePCo.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPublicTelephonePCo"].ToString();
                    TxtRdbPublicTelephonePCo.Text = p_Val.dSet.Tables[0].Rows[0]["PublicTelephonePCo"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbMobileSignal"].ToString() == "Yes")
                {
                    TxtRdbMobileSignal.Visible = true;
                    RdbPDSShop.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbMobileSignal"].ToString();
                    TxtRdbMobileSignal.Text = p_Val.dSet.Tables[0].Rows[0]["MobileSignal"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliythealthCare"].ToString() == "Yes")
                {
                    TxtAccessibiliythealthCare.Visible = true;
                    RdbAccessibiliythealthCare.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliythealthCare"].ToString();
                    TxtAccessibiliythealthCare.Text = p_Val.dSet.Tables[0].Rows[0]["AccessibiliythealthCare"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliyRoad"].ToString() == "Yes")
                {
                    TxtAccessibiliyRoad.Visible = true;
                    RdbAccessibiliyRoad.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliyRoad"].ToString();
                    TxtAccessibiliyRoad.Text = p_Val.dSet.Tables[0].Rows[0]["AccessibiliyRoad"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilitySchool"].ToString() == "Yes")
                {
                    TxtAccessbilitySchoolPrimary.Visible = true;
                    TxtAccessbilitySchool_Secondary.Visible = true;
                    TxtAccessbilitySchool_HighSchool.Visible = true;
                    TxtAccessbilitySchool_College.Visible = true;
                    RdbAccessbilitySchool.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilitySchool"].ToString();
                    TxtAccessbilitySchoolPrimary.Text = p_Val.dSet.Tables[0].Rows[0]["PrimarySchool"].ToString();
                    TxtAccessbilitySchool_Secondary.Text = p_Val.dSet.Tables[0].Rows[0]["SecondarySchool"].ToString();
                    TxtAccessbilitySchool_HighSchool.Text = p_Val.dSet.Tables[0].Rows[0]["HighSchool"].ToString();
                    TxtAccessbilitySchool_College.Text = p_Val.dSet.Tables[0].Rows[0]["College"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilityElectrif"].ToString() == "Yes")
                {
                    TxtAccessbilityElectrif_DurationElectricityVillages.Visible = true;
                    lblRdbAccessbilityElectrif.Visible = true;
                    RdbAccessbilityElectrif.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilityElectrif"].ToString();
                    TxtAccessbilityElectrif_DurationElectricityVillages.Text = p_Val.dSet.Tables[0].Rows[0]["AccessbilityElectrif"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessiblityVeterinary"].ToString() == "Yes")
                {
                    TxtAccessiblityVeterinary.Visible = true;
                    RdbAccessiblityVeterinary.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessiblityVeterinary"].ToString();
                    TxtAccessiblityVeterinary.Text = p_Val.dSet.Tables[0].Rows[0]["AccessiblityVeterinary"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAvenuesEmployment"].ToString() == "Yes")
                {
                    TxtAvenuesEmployment_Primary.Visible = true;
                    TxtAvenuesEmployment_Secondary.Visible = true;
                    lblRdbAvenuesEmployment1.Visible = true;
                    lblRdbAvenuesEmployment2.Visible = true;
                    RdbAvenuesEmployment.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAvenuesEmployment"].ToString();
                    TxtAvenuesEmployment_Primary.Text = p_Val.dSet.Tables[0].Rows[0]["EmploymentPrimary"].ToString();
                    TxtAvenuesEmployment_Secondary.Text = p_Val.dSet.Tables[0].Rows[0]["EmploymentSecondary"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbHumanWildlifecon"].ToString() == "Yes")
                {
                    lblRdbHumanWildlifecon.Visible = true;
                    TxtRdbHumanWildlifecon.Visible = true;
                    RdbHumanWildlifecon.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbHumanWildlifecon"].ToString();
                    TxtRdbHumanWildlifecon.Text = p_Val.dSet.Tables[0].Rows[0]["HumanWildlifecon"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessFireFodNwfps"].ToString() == "Yes")
                {
                    TXTAccessFireFodNwfps.Visible = true;
                    lblRdbAccessFireFodNwfps.Visible = true;
                    RdbAccessFireFodNwfps.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessFireFodNwfps"].ToString();
                    TXTAccessFireFodNwfps.Text = p_Val.dSet.Tables[0].Rows[0]["AccessFireFodNwfps"].ToString();
                }
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlNotified1_a"].ToString() == "Yes")
                {
                    
                    DdlNotified1_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlNotified1_a"].ToString();
                    TxtDateNotification1_b.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
                }
                TxtAreaHa1_c.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtAreaHa1_c"].ToString();
                TxtCompliance1_d.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtCompliance1_d"].ToString();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlNotified2_a"].ToString() == "Yes")
                {
                    DdlNotified2_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlNotified2_a"].ToString();
                    TxtDateNotification2_b.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification2_b"].ToString();
                }
                TxtAreaHa2_c.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtAreaHa2_c"].ToString();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlExpertCommittee2_d"].ToString() == "Yes")
                {
                    DdlExpertCommittee2_d.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlExpertCommittee2_d"].ToString();
                    TxtDateConstitution2_e.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateConstitution2_e"].ToString();

                }
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConsultationGramSabha2_f"].ToString() == "Yes")
                {
                    DdlConsultationGramSabha2_f.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConsultationGramSabha2_f"].ToString();
                    TxtNameGramSabha2_g.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtNameGramSabha2_g"].ToString();
                }
                StringBuilder sb = new StringBuilder();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadMapCTH2_h"].ToString() != "")
                {
                    sb.Append("<ul>");
                    string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadMapCTH2_h"].ToString();
                        sb.Append("<li>");
                        sb.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb.Append("</li>");
                       sb.Append("</br></ul>");
                }
                lblMap.Text = sb.ToString();
                StringBuilder sb1 = new StringBuilder();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString() != "")
                {
                    sb1.Append("<ul>");
                    string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString();
                    sb1.Append("<li>");
                    sb1.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                    sb1.Append("</li>");
                    sb1.Append("</br></ul>");
                }
                lblUpload.Text = sb1.ToString(); 
                 StringBuilder sb2 = new StringBuilder();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString() != "")
                {
                    sb2.Append("<ul>");
                    string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString();
                    sb2.Append("<li>");
                    sb2.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                    sb2.Append("</li>");
                    sb2.Append("</br></ul>");
                }
                lblUpload1.Text = sb2.ToString();
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlCompleted3_a"].ToString() == "Yes")
                {
                    DdlCompleted3_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlCompleted3_a"].ToString();
                    StringBuilder sb3 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString() != "")
                    {
                        sb3.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadCompleted3_a"].ToString();
                        sb3.Append("<li>");
                        sb3.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb3.Append("</li>");
                        sb3.Append("</br></ul>");
                    }
                    lblCompleted3_a.Text = sb3.ToString();
                }
                StringBuilder sbn = new StringBuilder();
                if (p_Val.dSet.Tables[2].Rows.Count > 0)
                {

                    sbn.Append("<ul>");
                    for (int i = 0; i < p_Val.dSet.Tables[2].Rows.Count; i++)
                    {
                        string filename = p_Val.dSet.Tables[2].Rows[i]["filename"].ToString();
                        sbn.Append("<li>");
                        sbn.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");

                        sbn.Append("</li>");
                    }
                    sbn.Append("</ul>");
                }
                lblfile.Text = sbn.ToString();
                StringBuilder vol = new StringBuilder();
                if (p_Val.dSet.Tables[1].Rows.Count > 0)
                {
                    sb.Append("<ul>");
                    for (int i = 0; i < p_Val.dSet.Tables[1].Rows.Count; i++)
                    {
                        string filename = p_Val.dSet.Tables[1].Rows[i]["filename"].ToString();
                        vol.Append("<li>");
                        vol.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");

                        vol.Append("</li>");
                    }
                    sbn.Append("</ul>");
                }
                lblVolantry.Text = vol.ToString();
                if(p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlProvided7_a"].ToString() == "Yes")
                {
                    DdlProvided7_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlProvided7_a"].ToString();
                    StringBuilder sb4 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString() != "")
                    {
                        sb4.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadProvided7_a"].ToString();
                        sb4.Append("<li>");
                        sb4.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb4.Append("</li>");
                        sb4.Append("</br></ul>");
                    }
                    lblFacilities.Text = sb4.ToString();
                }
                else
                {
                    FileUploadProvided7_a.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_a_a"].ToString() == "Yes")
                {
                    DdlConstituted8_a_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_a_a"].ToString();
                    TxtDateofconstitution8_a_b.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_a_b"].ToString();
                    StringBuilder sb5 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString() != "")
                    {
                        sb5.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString();
                        sb5.Append("<li>");
                        sb5.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb5.Append("</li>");
                        sb5.Append("</br></ul>");
                    }
                    lblFileUpload8_a_a.Text = sb5.ToString();
                }
                else
                {
                    DdlConstituted8_a_a.Visible = false;
                    TxtDateofconstitution8_a_b.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_b_a"].ToString() == "Yes")
                {
                    DdlConstituted8_b_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_b_a"].ToString();
                    TxtDateofconstitution8_b_b.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_b_b"].ToString();
                    StringBuilder sb6 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_b_a"].ToString() != "")
                    {
                        sb6.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString();
                        sb6.Append("<li>");
                        sb6.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb6.Append("</li>");
                        sb6.Append("</br></ul>");
                    }
                    lblConstituted.Text = sb6.ToString();
                }
                else
                {
                    TxtDateofconstitution8_b_b.Visible = false;
                    FileUpload8_b_a.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["contentbody_Ddl8_c_a"].ToString() == "Yes")
                {
                    Ddl8_c_a.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["contentbody_Ddl8_c_a"].ToString();
                    TxtDateofconstitution8_b_b.Text = p_Val.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_c_b"].ToString();
                    StringBuilder sb7 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_c_a"].ToString() != "")
                    {
                        sb7.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString();
                        sb7.Append("<li>");
                        sb7.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sb7.Append("</li>");
                        sb7.Append("</br></ul>");
                    }
                    lblCon2.Text = sb7.ToString();
                }
                else
                {
                    FileUpload8_c_a.Visible = false;
                    TxtDateofconstitution8_c_b.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString() == "Yes")
                {
                    RdbCheckItems1.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString();
                    TextCheckItems1.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems1"].ToString();
                    
                    StringBuilder sib = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems1"].ToString() != "")
                    {
                        sib.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems1"].ToString();
                        sib.Append("<li>");
                        sib.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib.Append("</li>");
                        sib.Append("</br></ul>");
                    }
                    lblCheck1.Text = sib.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString() == "No")
                    {
                        RdbCheckItems1.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString();
                    }
                        //FileUploadCheckItems1.Visible = false;
                        //TextCheckItems1.Visible = false;
                    }
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString() == "Yes")
                {
                    RdbCheckItems2.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString();
                    TextCheckItems2.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems2"].ToString();

                    StringBuilder sib2 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems2"].ToString() != "")
                    {
                        sib2.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems2"].ToString();
                        sib2.Append("<li>");
                        sib2.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib2.Append("</li>");
                        sib2.Append("</br></ul>");
                    }
                    lblCheckItems2.Text = sib2.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString() == "No")
                    {
                        RdbCheckItems2.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString();

                    }
                    //FileUploadCheckItems2.Visible = false;
                   // TextCheckItems2.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString() == "Yes")
                {
                    RdbCheckItems3.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString();
                    TextCheckItems3.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems3"].ToString();

                    StringBuilder sib3 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems3"].ToString() != "")
                    {
                        sib3.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems3"].ToString();
                        sib3.Append("<li>");
                        sib3.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib3.Append("</li>");
                        sib3.Append("</br></ul>");
                    }
                    lblCheckItems3.Text = sib3.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString() == "No")
                    {
                        RdbCheckItems3.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString();
                    }
                      //  FileUploadCheckItems3.Visible = false;
                   /// TextCheckItems2.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString() == "Yes")
                {
                    RdbCheckItems4.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString();
                    TextCheckItems4.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems4"].ToString();

                    StringBuilder sib4 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems4"].ToString() != "")
                    {
                        sib4.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems4"].ToString();
                        sib4.Append("<li>");
                        sib4.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib4.Append("</li>");
                        sib4.Append("</br></ul>");
                    }
                    lblCheckItems4.Text = sib4.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString() == "No")
                    {
                        RdbCheckItems4.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString();

                    }
                    //FileUploadCheckItems4.Visible = false;
                   // TextCheckItems4.Visible = false;
                }
                if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString() == "Yes")
                {
                    RdbCheckItems5.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString();
                    TextCheckItems5.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems5"].ToString();

                    StringBuilder sib5 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems5"].ToString() != "")
                    {
                        sib5.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems5"].ToString();
                        sib5.Append("<li>");
                        sib5.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib5.Append("</li>");
                        sib5.Append("</br></ul>");
                    }
                    lblCheckItems5.Text = sib5.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString() == "No")
                    {
                        RdbCheckItems5.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString();
                    }
                      //  FileUploadCheckItems5.Visible = false;
                   // TextCheckItems5.Visible = false;
                }
                TextCheckItems6.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems6"].ToString();
                if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString() == "Yes")
                {
                    RdbCheckItems7.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString();
                    TextCheckItems7.Text = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems7"].ToString();

                    StringBuilder sib6 = new StringBuilder();
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems7"].ToString() != "")
                    {
                        sib6.Append("<ul>");
                        string filename = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems7"].ToString();
                        sib6.Append("<li>");
                        sib6.Append("<a href='" + ResolveUrl("~/WriteReadData/UserFiles/") + filename + "' target='_blank'>" + filename + "</a>");
                        sib6.Append("</li>");
                        sib6.Append("</br></ul>");
                    }
                    lblCheckItems6.Text = sib6.ToString();
                }
                else
                {
                    if (p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString() == "No")
                    {
                        RdbCheckItems7.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString();
                    }
                        //FileUploadCheckItems7.Visible = false;
                        //TextCheckItems5.Visible = false;
                    }
                }
        }
    }
    #endregion
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/NGO/Tiger_Ngo.aspx");
    }
    protected void RdbPanchayatOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPanchayatOffice.SelectedValue == "Yes")
        {
            TxtRdbPanchayatOffice.Visible = true;
        }
        else
        {
            TxtRdbPanchayatOffice.Visible = false;
        }
    }
    protected void RdbAnganwadi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAnganwadi.SelectedValue == "Yes")
        {
            TxtRdbAnganwadi.Visible = true;
        }
        else
        {
            TxtRdbAnganwadi.Visible = false;
        }
    }
    protected void RdbAllWeatherRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAllWeatherRoad.SelectedValue == "Yes")
        {
            TxtRdbAllWeatherRoad.Visible = true;
        }
        else
        {
            TxtRdbAllWeatherRoad.Visible = false;
        }
    }
    protected void RdbPostOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPostOffice.SelectedValue == "Yes")
        {
            TxtRdbPostOffice.Visible = true;
        }
        else
        {
            TxtRdbPostOffice.Visible = false;
        }
    }
    protected void RdbBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbBank.SelectedValue == "Yes")
        {
            TxtRdbBank.Visible = true;
        }
        else
        {
            TxtRdbBank.Visible = false;
        }
    }
    protected void RdbPDSShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPDSShop.SelectedValue == "Yes")
        {
            TxtRdbPDSShop.Visible = true;
        }
        else
        {
            TxtRdbPDSShop.Visible = false;
        }
    }
    protected void RdbPublicTelephonePCo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPublicTelephonePCo.SelectedValue == "Yes")
        {
            TxtRdbPublicTelephonePCo.Visible = true;
        }
        else
        {
            TxtRdbPublicTelephonePCo.Visible = false;
        }
    }
    protected void RdbMobileSignal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbMobileSignal.SelectedValue == "Yes")
        {
            TxtRdbMobileSignal.Visible = true;
        }
        else
        {
            TxtRdbMobileSignal.Visible = false;
        }
    }
    protected void RdbAccessibiliythealthCare_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliythealthCare.SelectedValue == "Yes")
        {
            TxtAccessibiliythealthCare.Visible = true;
        }
        else
        {
            TxtAccessibiliythealthCare.Visible = false;
        }
    }
    protected void RdbAccessibiliyRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliyRoad.SelectedValue == "Yes")
        {
            TxtAccessibiliyRoad.Visible = true;
        }
        else
        {
            TxtAccessibiliyRoad.Visible = false;
        }
    }
    protected void RdbAccessbilitySchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilitySchool.SelectedValue == "Yes")
        {

            TxtAccessbilitySchoolPrimary.Visible = true;
            TxtAccessbilitySchool_Secondary.Visible = true;
            TxtAccessbilitySchool_HighSchool.Visible = true;
            TxtAccessbilitySchool_College.Visible = true;
        }
        else
        {
            TxtAccessbilitySchoolPrimary.Visible = false;
            TxtAccessbilitySchool_Secondary.Visible = false;
            TxtAccessbilitySchool_HighSchool.Visible = false;
            TxtAccessbilitySchool_College.Visible = false;
        }
    }
    protected void RdbAccessbilityElectrif_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilityElectrif.SelectedValue == "Yes")
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = true;
            // TxtAccessbilityElectrif_households.Visible = true;
            lblRdbAccessbilityElectrif.Visible = true;
        }
        else
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = false;
            // TxtAccessbilityElectrif_households.Visible = false;
            lblRdbAccessbilityElectrif.Visible = false;
        }
    }
    protected void RdbAccessiblityVeterinary_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessiblityVeterinary.SelectedValue == "Yes")
        {
            TxtAccessiblityVeterinary.Visible = true;

        }
        else
        {
            TxtAccessiblityVeterinary.Visible = false;

        }
    }
    protected void RdbAvenuesEmployment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAvenuesEmployment.SelectedValue == "Yes")
        {
            TxtAvenuesEmployment_Primary.Visible = true;
            TxtAvenuesEmployment_Secondary.Visible = true;
            lblRdbAvenuesEmployment1.Visible = true;
            lblRdbAvenuesEmployment2.Visible = true;
        }
        else
        {
            TxtAvenuesEmployment_Primary.Visible = false;
            TxtAvenuesEmployment_Secondary.Visible = false;
            lblRdbAvenuesEmployment1.Visible = false;
            lblRdbAvenuesEmployment2.Visible = false;
        }
    }
    protected void RdbHumanWildlifecon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbHumanWildlifecon.SelectedValue == "Yes")
        {
            TxtRdbHumanWildlifecon.Visible = true;
            lblRdbHumanWildlifecon.Visible = true;
        }
        else
        {
            TxtRdbHumanWildlifecon.Visible = false;
            lblRdbHumanWildlifecon.Visible = false;

        }
    }
    protected void RdbAccessFireFodNwfps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessFireFodNwfps.SelectedValue == "Yes")
        {
            TXTAccessFireFodNwfps.Visible = true;
            lblRdbAccessFireFodNwfps.Visible = true;
        }
        else
        {
            TXTAccessFireFodNwfps.Visible = false;
            lblRdbAccessFireFodNwfps.Visible = false;

        }
    }
    protected void btncloases_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/NGO/ngolistaspx.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
    }
    protected void btnBck_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
    }
}
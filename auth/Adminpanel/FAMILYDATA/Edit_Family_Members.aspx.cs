using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_FAMILYDATA_Edit_Family_Members : System.Web.UI.Page
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    Family_DetailEntity FMLYMEM_ENT_Obj = new Family_DetailEntity();
    CommonDB COMMDB_Obj = new CommonDB();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    common com_Obj = new common();
    public static bool check = false;
    static int FMLY_MEMB_IDstatic = 0;
    static int FinalMemeberyear = 0;
    public static string CheckHeadMember = string.Empty;
    public string mime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        txtage.Enabled = false;
        CadarTxtDOB.EndDate = DateTime.Now;
        lblMsg.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }
        if (!Page.IsPostBack)
        {
            FillGroup();
            Filloccupation();
            if (Request.QueryString["fmid"] != null && !Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].Equals(""))
            {

                LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
                if(txtage.Text!="")
                {
                    if(Convert.ToInt32(txtage.Text)>=18)
                    {
                        DvValidAgePanel.Visible = true;
                    }
                    else
                    {
                        DvValidAgePanel.Visible = false;
                    }
                }
            }
            TxtDOB_TextChangedAgeCal();
        }

    }
    public void Filloccupation()
    {
        try
        {
            ddlselectoccupation.Items.Clear();
            DataSet ds = COMMDB_Obj.FillOccupations();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                ListItem list = new ListItem("Select Occupation", "0");
                ddlselectoccupation.Items.Add(list);
                int i = 0;
                while (count > 0)
                {
                    ListItem list1 = new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                    ddlselectoccupation.Items.Add(list1);
                    count--;
                    i++;
                }
            }
        }
        catch (Exception e4)
        { }
    }
    public void ResetAllFields()
    {
        txtname.Text = "";

        txtage.Text = "";

        txtfathername.Text = "";
        txtvalidcardnumber.Text = "";
        ddlselectsex.SelectedValue = "0";
        ddlselectcast.SelectedValue = "0";
        txtvoter.Text = "";
        txtcontact.Text = "";
        txtedu.Text = "";
        ddlselectoccupation.SelectedValue = "0";
        txtincome.Text = "";
    }
    public void FillRelation()
    {
        ddlselectrelation.Items.Clear();
        try
        {
            DataSet ds = COMMDB_Obj.FillRelation();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                ListItem list = new ListItem("Select Relation", "0");
                ddlselectrelation.Items.Add(list);
                int i = 0;
                while (count > 0)
                {
                    ListItem list1 = new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                    ddlselectrelation.Items.Add(list1);
                    count--;
                    i++;
                }
            }
        }
        catch (Exception e4)
        {
        }
    }
    public void LoadInfoMemberId(string memberid)
    {
        LblHeadingPopUp.Text = "";
        try
        {
            ViewState["mid"] = memberid;
            FamilyMemberOB familyObject = new FamilyMemberOB();
            familyObject.MemberID = Convert.ToInt32(memberid);
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.Display_All_Members_From_Original_Table(familyObject);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                ResetAllFields();
                txtname.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();
                if (ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString() == "1")
                {
                    LblHeadingPopUp.Text = "Edit Family Head Details";
                    CheckHeadMember = "headexist";
                    trPhoto.Visible = true;
                    DvPhoto.Visible = true;
                    string filename = ds.Tables[0].Rows[0]["Photo"].ToString();
                    if (filename != "")
                    {//NoPhoto.png
                        IMphoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename; 
                        BtnDeleteAttachment.Visible = true;
                        hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                        hypfile.Text = filename;
                    }
                    else
                    {
                        IMphoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png"; 
                        BtnDeleteAttachment.Visible = false;
                    }
                    
                   
                   
                    FillRelation();
                    ddlselectrelation.Enabled = false;
                    ddlselectrelation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString();
                }
                else
                {
                    LblHeadingPopUp.Text = "Edit Family Member Details";
                    CheckHeadMember = "memberexist";
                    trPhoto.Visible = false;
                    DvPhoto.Visible = false;
                    ddlselectrelation.Enabled = true;
                    ddlselectrelation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString();
                }
                //card details photo
                string cardphoto = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
                if (cardphoto != "")
                {
                    Div1.Visible = true;
                    BtnDeleteAttachmentCard.Visible = true;
                    HyperLink1.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                    HyperLink1.Text = cardphoto;
                }
                else
                {
                   // IMphoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png"; 
                    Div1.Visible = false;
                    BtnDeleteAttachmentCard.Visible = false;
                }
               
                //------------------
                TxtCardFile.Text = ds.Tables[0].Rows[0]["IdentityCardPhotoTitle"].ToString();
                //--------------
                txtage.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_AGE"].ToString();
                if (!ds.Tables[0].Rows[0]["FATHER_NM"].ToString().Equals("NULL"))//9
                {

                    txtfathername.Text = ds.Tables[0].Rows[0]["FATHER_NM"].ToString();
                }
                else
                {

                }
                txtvalidcardnumber.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NAME"].ToString();
                ddlselectsex.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_SEX"].ToString();
                ddlselectcast.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_CAST"].ToString();
                DropDownvalidId.SelectedValue= ds.Tables[0].Rows[0]["validIdProof"].ToString();
                txtvoter.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NO"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_CONT_NO"].ToString();
                txtedu.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_EDU"].ToString();
                ddlselectoccupation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_OCC"].ToString();
                txtincome.Text = (Convert.ToDouble(ds.Tables[0].Rows[0]["FMLY_MEMB_ANUL_INCM"])).ToString();
                //-------------------
                TxtDOB.Text = ds.Tables[0].Rows[0]["DOB1"].ToString();
                TxtBnameMobile.Text = ds.Tables[0].Rows[0]["BankNameMobile"].ToString();
                txtBeniAddress.Text = ds.Tables[0].Rows[0]["BenAddress"].ToString();
                txtBeniMobile.Text = ds.Tables[0].Rows[0]["BenMobile"].ToString();
                TxtBankPostAccountNo.Text = ds.Tables[0].Rows[0]["BankPostAccountNo"].ToString();
                TxtBankPostOfficeName.Text = ds.Tables[0].Rows[0]["BankPostOfficeName"].ToString();
                TxtIFSC.Text = ds.Tables[0].Rows[0]["IFSC"].ToString();
                TxtBankPostOfficeAdress.Text = ds.Tables[0].Rows[0]["BankPostOfficeAdress"].ToString();
            //    TxtAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                //TxtAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                //txtothers.Text = ds.Tables[0].Rows[0]["Others"].ToString();
                string straadhar = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                //  string strshortaadhar = straadhar.Substring(0, 4);
                string strshortaadhar = straadhar.Substring(straadhar.Length - 4);


                TxtAadharNo.Text = strshortaadhar.PadLeft(12, '*'); //ds.Tables[0].Rows[0]["AadharNo"].ToString();

                if (ds.Tables[0].Rows[0]["validIdProof"].ToString()=="1")
                {
                    txtpencard.Text = ds.Tables[0].Rows[0]["PenCard"].ToString();
                }
                else if(ds.Tables[0].Rows[0]["validIdProof"].ToString() == "2")
                {
                    txtpencard.Text= ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NAME"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["validIdProof"].ToString() == "3")
                {
                 //   txtpencard.Text= ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                    string aadharnum = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                    string strshortadhaar1 = aadharnum.Substring(aadharnum.Length - 4);
                    txtpencard.Text = strshortadhaar1.PadLeft(12, '*'); //ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["validIdProof"].ToString() == "4")
                {
                    txtpencard.Text= ds.Tables[0].Rows[0]["Others"].ToString();
                }
                

                TxtTransgender.Text = ds.Tables[0].Rows[0]["Transgender"].ToString();
                DdlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

                TxtNoBeneficiary.Text = ds.Tables[0].Rows[0]["NoBeneficiary"].ToString();
                //------------------------------------

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();

            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void FieldEmpty18above()
    {
        //TxtBnameMobile.Text = string.Empty;
        //TxtBankPostAccountNo.Text = string.Empty;
        //TxtBankPostOfficeName.Text = string.Empty;
        //TxtIFSC.Text = string.Empty;
        //TxtBankPostOfficeAdress.Text = string.Empty;
        //TxtAadharNo.Text = string.Empty;
    }
    public void FieldEmpty()
    {
        TxtDOB.Text = string.Empty;
        LblTxtBnameMobile.Text = "";
        lblBeniMobile.Text = "";
        lblBeniAddress.Text = "";
        lblTxtBankPostAccountNo.Text = "";
        lblTxtBankPostOfficeName.Text = "";
        lblTxtIFSC.Text = "";
        lblTxtBankPostOfficeAdress.Text = "";
        lblTxtAadharNo.Text = "";

        TxtBnameMobile.Text = string.Empty;
        txtBeniAddress.Text = string.Empty;
        txtBeniMobile.Text = string.Empty;
        TxtBankPostAccountNo.Text = string.Empty;
        TxtBankPostOfficeName.Text = string.Empty;
        TxtIFSC.Text = string.Empty;
        TxtBankPostOfficeAdress.Text = string.Empty;
        TxtAadharNo.Text = string.Empty;




        txtname.Text = "";
        txtfathername.Text = "";
        txtage.Text = "";
        ddlselectsex.SelectedIndex = 0;

        ddlselectcast.SelectedIndex = 0;
        txtvalidcardnumber.Text = "";
        txtvoter.Text = "";
        txtcontact.Text = "";
        txtpencard.Text = "";
       // TxtAdhaarCard.Text = "";
        txtothers.Text = "";
        TxtTransgender.Text = "";
        DdlMaritalStatus.SelectedIndex = 0;
        txtedu.Text = "";
        txtincome.Text = "";
        TxtNoBeneficiary.Text = "";
    }
    public int calculateAge(int Dobyear, int Dobmonth, int Dobday, int CuttoffYear, int cuttoffmonth, int cuttoffday)
    {
        int Years = 0;

        DateTime Birth = new DateTime(Dobyear, Dobmonth, Dobday);
        DateTime Today = new DateTime(CuttoffYear, cuttoffmonth, cuttoffday);
        //TimeSpan Span = Today - Birth;
        //DateTime Age = DateTime.MinValue + Span;
        //// note: MinValue is 1/1/1 so we have to subtract...
        //Years = Age.Year - 1;
        //int Months = Age.Month - 1;
        //int Days = Age.Day - 1;
        LblCuttoffDateShow.Text = "On the basis of Cutt-off Date :[" + Today.ToString() + "] Age will be calculated: ";
        Years = Today.Year - Birth.Year;
        if (Today.DayOfYear < Birth.DayOfYear)
            Years = Years - 1;
        return Years;
    }
    public string GetCuttOffDateofVillage(int VillageID)
    {
        string cuttoffdate = string.Empty;
        try
        {


            DataSet ds = new DataSet();
            ds = new VillageDB().GetCuttOffDate(VillageID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cuttoffdate = ds.Tables[0].Rows[0]["CuttOffDate1"].ToString();

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        return cuttoffdate;
    }

    public void TxtDOB_TextChangedAgeCal()
    {
        FieldEmpty18above();

        DvValidAgePanel.Visible = false;
        LblMsgDbo.Text = string.Empty;
        string DobAge = string.Empty;
        DobAge = common.insertDate(TxtDOB.Text.Trim()).ToString();
        string[] words1 = DobAge.Split('/');

        string dd1 = null;
        string MM1 = null;
        string yyyy1 = null;
        yyyy1 = words1[0];
        MM1 = words1[1];
        dd1 = words1[2];

        string MMddyyyy = MM1 + "/" + dd1 + "/" + yyyy1;
        var parameterDate = DateTime.ParseExact(MMddyyyy, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var todaysDate = DateTime.Today;

        if (parameterDate < todaysDate)
        {


            int Dobyear = 0;
            int Dobmonth = 0;
            int Dobday = 0;

            int CuttoffYear = 0;
            int cuttoffmonth = 0;
            int cuttoffday = 0;
            string cuttoffdate = string.Empty;
            cuttoffdate = GetCuttOffDateofVillage(Convert.ToInt32(Request.QueryString["vid"].ToString()));

            if (cuttoffdate != string.Empty)
            {
                string[] words = cuttoffdate.Split('/');

                string dd = null;
                string MM = null;
                string yyyy = null;
                dd = words[0];
                MM = words[1];
                yyyy = words[2];

                cuttoffday = Convert.ToInt32(dd);
                cuttoffmonth = Convert.ToInt32(MM);
                CuttoffYear = Convert.ToInt32(yyyy);
            }

            if (TxtDOB.Text.Trim() != "")
            {
                DobAge = common.insertDate(TxtDOB.Text.Trim()).ToString();
            }
            if (DobAge != string.Empty)
            {//2018/06/01
                string[] words = DobAge.Split('/');

                string dd = null;
                string MM = null;
                string yyyy = null;
                yyyy = words[0];
                MM = words[1];
                dd = words[2];

                Dobday = Convert.ToInt32(dd);
                Dobmonth = Convert.ToInt32(MM);
                Dobyear = Convert.ToInt32(yyyy);
                //txtage.Text = year.ToString();
            }
            if (cuttoffdate != string.Empty && DobAge != string.Empty)
            {
                FinalMemeberyear = calculateAge(Dobyear, Dobmonth, Dobday, CuttoffYear, cuttoffmonth, cuttoffday);
                txtage.Text = FinalMemeberyear.ToString();
                if(txtage.Text=="-1")
                {
                    LblMsgDbo.Text = "Age should not be less then 1 year!";
                    TxtDOB.Focus();
                }
                else
                {
                    LblMsgDbo.Text = "";
                }
                if (FinalMemeberyear >= 18)
                {
                    DvValidAgePanel.Visible = true;
                    FieldEmpty18above();
                }
                else
                {
                    if (CheckHeadMember == "headexist")
                    {
                        if (FinalMemeberyear >= 18)
                        {

                        }
                        else
                        {

                            LblMsgDbo.Text = "Age should not be less then 18!";
                            TxtDOB.Focus();
                            //  return;
                        }
                    }
                    if (CheckHeadMember == "memberexist")
                    {
                        if (FinalMemeberyear >= 1)
                        {

                        }
                        else
                        {

                            LblMsgDbo.Text = "Age should not be less then 1!";
                            TxtDOB.Focus();
                            //  return;
                        }
                    }
                    DvValidAgePanel.Visible = false;
                    FieldEmpty18above();
                }
            }

        }
        else
        {
            // Response.Write("<script>alert('DOB Should Be Less Than Or Equal to Today's Date!!');</script>");
         //   LblMsgDbo.Text = "DOB Should Be Less Than Or Equal to Today's Date!";
            LblMsgDbo.Text = "";
            TxtDOB.Focus();
        }

        //ModalPopupExtender1.Show();
    }
    protected void TxtDOB_TextChanged(object sender, EventArgs e)
    {
        txtage.Enabled = false;
        TxtDOB_TextChangedAgeCal();
    }
    protected void ddlselectrelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
        {

        }
        else
        {

        }
    }
    protected void ddlselectsex_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
    {
        // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/FAMILYDATA/Edit_Family_Members.aspx"));

    }
    public void FillGroup()
    {
        try
        {
            ddlselectrelation.Items.Clear();
            DataSet ds1 = COMMDB_Obj.FillRelation();

            DataTable dt = ds1.Tables[0];
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlselectrelation.DataSource = dt;
                ddlselectrelation.DataTextField = "RELATION_NAME";
                ddlselectrelation.DataValueField = "RELATION_ID";
                ddlselectrelation.DataBind();
                ddlselectrelation.Items.Insert(0, new ListItem("Select", "0"));

            }


        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
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
    public void PopUpRecordFamilyheadMemberSave()
    {

        try
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

            FMLYMEM_ENT_Obj._FMLY_MEMB_NM = txtname.Text.Trim();
            FMLYMEM_ENT_Obj._FMLY_MEMB_REL = Convert.ToInt32(ddlselectrelation.SelectedValue);
            if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
            {
                FMLYMEM_ENT_Obj._FATHER_NM = txtfathername.Text.Trim();
            }
            else
            {
                FMLYMEM_ENT_Obj._FATHER_NM = "";
            }

            FMLYMEM_ENT_Obj._FMLY_MEMB_AGE = Convert.ToInt32(txtage.Text.Trim());
            FMLYMEM_ENT_Obj._FMLY_MEMB_SEX = Convert.ToInt32(ddlselectsex.SelectedValue);
            FMLYMEM_ENT_Obj._FMLY_MEMB_CAST = Convert.ToInt32(ddlselectcast.SelectedValue);
            FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO = common.RemoveUnnecessaryHtmlTagHtml(txtvoter.Text.Trim());
           // FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtvalidcardnumber.Text.Trim());
            FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO = txtcontact.Text.Trim();
            FMLYMEM_ENT_Obj._FMLY_MEMB_EDU = common.RemoveUnnecessaryHtmlTagHtml(txtedu.Text.Trim());
            FMLYMEM_ENT_Obj._FMLY_MEMB_OCC = Convert.ToInt32(ddlselectoccupation.SelectedValue);
            if (txtincome.Text.Trim() == "")
            {
                FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM = 0;
            }
            else
            {
                FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM = Convert.ToDouble(txtincome.Text);
            }
            //6june
            FMLYMEM_ENT_Obj.DOB = common.insertDate(TxtDOB.Text.Trim()).ToString();
            //FMLYMEM_ENT_Obj.PenCard = txtpencard.Text.Trim();
            //FMLYMEM_ENT_Obj.AdhaarCard = TxtAdhaarCard.Text.Trim();
           // FMLYMEM_ENT_Obj.Others = txtothers.Text.Trim();
            FMLYMEM_ENT_Obj.Transgender = TxtTransgender.Text.Trim();
            FMLYMEM_ENT_Obj.NoBeneficiary = TxtNoBeneficiary.Text.Trim();

            if (DdlMaritalStatus.SelectedValue != "0")
            {
                FMLYMEM_ENT_Obj.MaritalStatus = DdlMaritalStatus.SelectedValue;
            }

            //TxtBnameMobile,TxtBankPostAccountNo
            FMLYMEM_ENT_Obj.BankNameMobile = TxtBnameMobile.Text.Trim();
            FMLYMEM_ENT_Obj.BenAddress = txtBeniAddress.Text.Trim();
            FMLYMEM_ENT_Obj.BenMobile = txtBeniMobile.Text.Trim();
            FMLYMEM_ENT_Obj.BankPostAccountNo = TxtBankPostAccountNo.Text.Trim();
            FMLYMEM_ENT_Obj.BankPostOfficeName = TxtBankPostOfficeName.Text.Trim();
            FMLYMEM_ENT_Obj.IFSC = TxtIFSC.Text.Trim();
            FMLYMEM_ENT_Obj.BankPostOfficeAdress = TxtBankPostOfficeAdress.Text.Trim();

            if (DropDownvalidId.SelectedValue == "1")
            {
                FMLYMEM_ENT_Obj.PenCard = txtpencard.Text.Trim();

            }
            else if (DropDownvalidId.SelectedValue == "2")
            {
                FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtpencard.Text.Trim());
            }
            else if (DropDownvalidId.SelectedValue == "3")
            {
                FMLYMEM_ENT_Obj.AdhaarCard = txtpencard.Text.Trim();
            }
            else if (DropDownvalidId.SelectedValue == "4")
            {
                FMLYMEM_ENT_Obj.Others = txtpencard.Text.Trim();
            }
            FMLYMEM_ENT_Obj.AadharNo = TxtAadharNo.Text.Trim();
            //end 6juneTxtAadharNo,TxtAdhaarCard.Text.Trim();
            FMLYMEM_ENT_Obj.IdentityCardPhotoTitle = TxtCardFile.Text.Trim();
            //end 6june
            //---------self profile pic only for self not for other----------------
            if (hypfile.Text != string.Empty)
            {
                FMLYMEM_ENT_Obj.Photo = hypfile.Text.Trim();
            }
            else
            {
                
                if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                {
                    p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                    p_Var.ext = p_Var.ext.ToUpper();
                    int count = fileUpload_Menu.FileName.Split('.').Length - 1;
                  //  string contenttype = fileUpload_Menu.ContentType.ToString();
                    if (count >= 2)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                        return;
                    }

                    if (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")  || p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")|| p_Var.ext.Equals(".jpeg")&& mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".png")&& mime.ToString().Equals("image/x-png") || p_Var.ext.Equals(".PNG")&& mime.ToString().Equals("image/x-png"))
                    {

                        p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar";
                        p_Var.Filename = com_Obj.getUniqueFileName(fileUpload_Menu.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUpload_Menu.PostedFile.FileName), p_Var.ext);
                        p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar/" + p_Var.Filename;
                        fileUpload_Menu.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                        FMLYMEM_ENT_Obj.Photo = p_Var.Filename;
                    }
                    else
                    {
                        lblmenuMsg.Visible = true;
                        lblmenuMsg.Text = "Not a valid file";
                        //   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Not a Valid file');", true);
                       // string message = "Not a Valid file";
                       // ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        return;
                    }
                }
            }
            //---------------------------------
            //---------Card details photo----------------
            if (HyperLink1.Text != string.Empty)
            {
                FMLYMEM_ENT_Obj.IdentityCardPhoto = HyperLink1.Text.Trim();
            }
            else
            {
                if (fileUploadCardDetails.PostedFile != null && fileUploadCardDetails.PostedFile.InputStream.Length != 0)
                {
                    p_Var.ext = System.IO.Path.GetExtension(this.fileUploadCardDetails.PostedFile.FileName);
                    p_Var.ext = p_Var.ext.ToUpper();
                    int count = fileUploadCardDetails.FileName.Split('.').Length - 1;
                 //   string contenttype = fileUploadCardDetails.ContentType.ToString();
                    if (count >= 2)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                        return;
                    }
                    if (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg") || p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png") || p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png"))
                   // if (p_Var.ext.Equals(".jpg") || p_Var.ext.Equals(".JPG") || p_Var.ext.Equals(".jpeg") || p_Var.ext.Equals(".JPEG") || p_Var.ext.Equals(".png") || p_Var.ext.Equals(".PNG"))
                    {

                        p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar";
                        p_Var.Filename = com_Obj.getUniqueFileName(fileUploadCardDetails.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUploadCardDetails.PostedFile.FileName), p_Var.ext);
                        p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar/" + p_Var.Filename;
                        fileUploadCardDetails.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                        FMLYMEM_ENT_Obj.IdentityCardPhoto = p_Var.Filename;
                    }
                }
            }
            //---------------------------------

            if (chkCardPhoto() == true)
            {
                if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                {
                    if (chkHeadPhoto() == true)
                    {
                        bool check = FMLYDB_Obj.Update_Family_Member_For_Original_Table(FMLYMEM_ENT_Obj, ViewState["mid"].ToString());
                        if (check == true)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                           // RegisterClientScriptBlock("showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                         //   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                            // ResetAllFields();
                            lblMsg.Text = "Member Details Updated Successfully";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            // flagupdate = false;

                            //BindMembers();
                            new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);

                        }
                        else
                        {
                            lblMsg.Text = "Error Occur. Please Try Later";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    bool check = FMLYDB_Obj.Update_Family_Member_For_Original_Table(FMLYMEM_ENT_Obj, ViewState["mid"].ToString());
                    if (check == true)
                    {
                       // RegisterClientScriptBlock("showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                        // ResetAllFields();
                        lblMsg.Text = "Member Details Updated Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        // flagupdate = false;

                        //BindMembers();
                        new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);

                    }
                    else
                    {
                        lblMsg.Text = "Error Occur. Please Try Later";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }

            }

        }
        catch (Exception e3)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e3.Message.ToString();

            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {
        TxtDOB_TextChangedAgeCal();
        if (Page.IsValid)
        {
            if (CheckHeadMember == "headexist")
            {
                if (FinalMemeberyear >= 18)
                {
                    PopUpRecordFamilyheadMemberSave();
                }
                else
                {
                   
                    LblMsgDbo.Text = "Age should not be less then 18!";
                    //  return;
                }
            }
            if (CheckHeadMember == "memberexist")
            {
                if (FinalMemeberyear >= 1)
                {
                    PopUpRecordFamilyheadMemberSave();
                }
                else
                {
                   
                    LblMsgDbo.Text = "Age should not be less then 1!";
                    //  return;
                }
            }
            //--------------------------------------

        }
        LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
    }
    protected void imgbtnreset_Click1(object sender, EventArgs e)
    {
        LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
    }
    protected void imgbtnback_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Edit_Family.aspx?family_id=" + Request.QueryString["fmid"].ToString() + "&pindex=" + Request.QueryString["pindex"].ToString() + "&vid=" + Request.QueryString["vid"].ToString() + "&sid=" + Request.QueryString["sid"].ToString() + "&rid=" + Request.QueryString["rid"].ToString() + "&fid=" + Request.QueryString["fid"].ToString()));
    }
    protected void fdf_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ValidateFileSize(object source, ServerValidateEventArgs args)
    {
        string data = args.Value;
        args.IsValid = false;
        double filesize = fileUpload_Menu.FileContent.Length;
        if (filesize > 3145728)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void ValidateFileSize1(object source, ServerValidateEventArgs args)
    {
        string data = args.Value;
        args.IsValid = false;
        double filesize = fileUploadCardDetails.FileContent.Length;
        if (filesize > 3145728)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
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




    }
    protected void CustomValidator3_ServerValidate1(object source, ServerValidateEventArgs args)
    {

        bool s;
        string ext1 = System.IO.Path.GetExtension(fileUploadCardDetails.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".pdf")
        {
            s = miscellBL.GetActualFileType_pdf(fileUploadCardDetails.PostedFile.InputStream);
        }
        else
        {
            s = miscellBL.GetActualFileType(fileUploadCardDetails.PostedFile.InputStream);
        }
        if (fileUploadCardDetails.PostedFile.ContentLength == 0)
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
    bool chkHeadPhoto()
    {
        LblfileUpload_Menu.Text = "";
        bool chk = false;
        if (!fileUpload_Menu.HasFile)
        {
            if (hypfile.Text != string.Empty)
            {
                LblfileUpload_Menu.Text = "";
                return true;
            }
            else
            {
                LblfileUpload_Menu.Text = "Please upload your photo.";
                return false;
            }
        }

        return true;
    }
    bool chkCardPhoto()
    {
        LblCardMsge.Text = "";
        bool chk = false;
        if (fileUploadCardDetails.HasFile)
        {
            if (TxtCardFile.Text == string.Empty)
            {
                LblCardMsge.Text = "Please enter card detail title.";
                return false;
            }

        }

        return true;
    }
    protected void BtnDeleteAttachment_Click(object sender, EventArgs e)
    {
        try
        {
           
                FMLYMEM_ENT_Obj.FMLY_MEMB_IDs = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID]);
                FMLYMEM_ENT_Obj.Action = 1;
                check = FMLYDB_Obj.AttachmentDeletePhoto1(FMLYMEM_ENT_Obj);

                if (check == true)
                {
                    // LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
                   // ModalPopupExtender1.Show();
                     Response.Write("<script>alert('Attachment has deleted successfully!');</script>");
                     LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
                }
            
        }
        catch (Exception er)
        {
            throw;
        }
    }
    protected void BtnDeleteAttachment_Click1(object sender, EventArgs e)
    {
        try
        {
           
                FMLYMEM_ENT_Obj.FMLY_MEMB_IDs =Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID]);
                FMLYMEM_ENT_Obj.Action = 1;
                check = FMLYDB_Obj.AttachmentDeleteCardPhoto1(FMLYMEM_ENT_Obj);

                if (check == true)
                {
                    // LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
                   // ModalPopupExtender1.Show();
                     Response.Write("<script>alert('Attachment has deleted successfully!');</script>");
                     LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
                }
            
        }
        catch (Exception er)
        {
            throw;
        }
    }
    protected void txtage_TextChanged(object sender, EventArgs e)
    {

    }
}
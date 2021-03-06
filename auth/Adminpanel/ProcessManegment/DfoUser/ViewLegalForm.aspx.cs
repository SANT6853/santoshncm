using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_ProcessManegment_DfoUser_ViewLegalForm : CrsfBase
{
    //-------------
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();

    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    Miscelleneous_BL obMiscell = new Miscelleneous_BL();
    common com_Obj = new common();
    //--------------------------------------
    public static int? TblFromDfoToReserveAutoID;
    public static string TokenId_FirstTimeInsertNoChange;
    public static int? VillageID_FirstTimeInsertNoChange;
    public static int ActionApplyOnRowSetColorDefaultZero;
    public static int StatusIDDefault;
    public static double? FromAmount_FirstTimeInsertNoChange;
    public static double? CommentedApprovedAmount;
    public static string FromDescription_FirstTimeInsertNoChange;
    public static string CommentedRemarks;
    public static int? FromPersonID;
    public static int? ToPersonID;
    public static DateTime? FromInsertDate_FirstTimeInsertNoChange;
    public static DateTime? CommentedDate;
    public static int? ActiveDefaultOne;
    public static string FromPersonUserName;
    public static string ToPersonUserName;
    public static double? AcceptedAmount;
    public string mime = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        if (!Page.IsPostBack)
        {
            QueryStringGet();
           
        }
    }
    void QueryStringGet()
    {


        if (Request.QueryString["TblFromDfoToReserveAutoID"] != null)
        {
           // GetRecordDfoReserveProcess(Convert.ToInt32(Request.QueryString["TblFromDfoToReserveAutoID"]));
            GetRecordLegalFormAndForm1();
           // ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:funRdbCheckItems1(); ", true);
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { funRdbCheckItems1(); });", true);
        }


    }
    void GetRecordLegalFormAndForm1()
    { 
        
        P_var.dSet = null;

        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = Request.QueryString["TblFromDfoToReserveAutoID"].ToString();
        _TigerReserveOB.Action = 1;
        P_var.dSet = _tigerReserverBl.GetLegalFormFrom1(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
           
            DdlNotified1_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlNotified1_a"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlNotified1_a"].ToString() == "No")
            {
                TxtDateNotification1_b.Text = "";
            }
            else
            {
                TxtDateNotification1_b.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            }
           
            TxtAreaHa1_c.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtAreaHa1_c"].ToString();
            TxtCompliance1_d.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtCompliance1_d"].ToString();
            DdlNotified2_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlNotified2_a"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlNotified2_a"].ToString() == "No")
            {
                TxtDateNotification2_b.Text = "";
            }
            else
            {
                TxtDateNotification2_b.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification2_b"].ToString();
            }
           
            TxtAreaHa2_c.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtAreaHa2_c"].ToString();
            DdlExpertCommittee2_d.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlExpertCommittee2_d"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlExpertCommittee2_d"].ToString() == "No")
            {
                TxtDateConstitution2_e.Text = "";
            }
            else
            {
                TxtDateConstitution2_e.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateConstitution2_e"].ToString();
            }
            DdlConsultationGramSabha2_f.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConsultationGramSabha2_f"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConsultationGramSabha2_f"].ToString() == "No")
            {
                TxtNameGramSabha2_g.Text = "";
            }
            else
            {
                TxtNameGramSabha2_g.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtNameGramSabha2_g"].ToString();
            }
            //  FileUpload1.SaveAs(Server.MapPath("images/" +  FileName));
            //FileUploadMapCTH2_h.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            //WriteReadData/UserFiles
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadMapCTH2_h"].ToString() != "NA")
            {
                HypMapCTH2_h.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadMapCTH2_h"].ToString();
                HypMapCTH2_h.Text =  P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadMapCTH2_h"].ToString();
            }


            //FileUploadUploadfile2_i.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString() != "NA")
            {
                HypUploadfile2_i.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString();
                HypUploadfile2_i.Text =  P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_i"].ToString();
            }
            
            //FileUploadUploadfile2_j.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString() != "NA")
            {
                HypUploadfile2_j.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString();
                HypUploadfile2_j.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadUploadfile2_j"].ToString();
            }
            DdlCompleted3_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlCompleted3_a"].ToString();
            //FileUploadCompleted3_a.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlCompleted3_a"].ToString() == "No")
            {
               // TxtNameGramSabha2_g.Text = "";
                HypFileUploadCompleted3_a.Visible = false;
            }
            else
            {
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadCompleted3_a"].ToString() != "NA")
                {
                    HypFileUploadCompleted3_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadCompleted3_a"].ToString();
                    HypFileUploadCompleted3_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadCompleted3_a"].ToString();
                }
            }
            DdlProvided4_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlProvided4_a"].ToString();
            DdlObtained5_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlObtained5_a"].ToString();
            DdlObtained6_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlObtained6_a"].ToString();
            //FileUpload6_a.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlObtained6_a"].ToString() == "No")
            {
                // TxtNameGramSabha2_g.Text = "";
                HypFileUpload6_a.Visible = false;
            }
            else
            {
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload6_a"].ToString() != "NA")
                {
                    HypFileUpload6_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload6_a"].ToString();
                    HypFileUpload6_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload6_a"].ToString();
                }
            }
            DdlProvided7_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlProvided7_a"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlProvided7_a"].ToString() == "No")
            {
                // TxtNameGramSabha2_g.Text = "";
                HypFileUploadProvided7_a.Visible = false;
            }
            else
            {
                //FileUploadProvided7_a= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadProvided7_a"].ToString() != "NA")
                {
                    HypFileUploadProvided7_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadProvided7_a"].ToString();
                    HypFileUploadProvided7_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUploadProvided7_a"].ToString();
                }
            }
            DdlConstituted8_a_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_a_a"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_a_a"].ToString() == "No")
            {
                 TxtDateofconstitution8_a_b.Text = "";
                HypFileUpload8_a_a.Visible = false;
            }
            else
            {
                //FileUpload8_a_a.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString() != "NA")
                {
                    HypFileUpload8_a_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString();
                    HypFileUpload8_a_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_a_a"].ToString();
                }
                TxtDateofconstitution8_a_b.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_a_b"].ToString();
            }
            
            DdlConstituted8_b_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_b_a"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_DdlConstituted8_b_a"].ToString() == "No")
            {
                  TxtDateofconstitution8_b_b.Text = "";
                HypFileUpload8_b_a.Visible = false;
            }
            else
            {
                //FileUpload8_b_a.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_b_a"].ToString() != "NA")
                {
                    HypFileUpload8_b_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_b_a"].ToString();
                    HypFileUpload8_b_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_b_a"].ToString();
                }
                TxtDateofconstitution8_b_b.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_b_b"].ToString();
            }
            Ddl8_c_a.SelectedValue = P_var.dSet.Tables[0].Rows[0]["contentbody_Ddl8_c_a"].ToString();
            //FileUpload8_c_a.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["contentbody_Ddl8_c_a"].ToString() == "No")
            {
                TxtDateofconstitution8_c_b.Text = "";
                HypFileUpload8_c_a.Visible = false;
            }
            else
            {
                if (P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_c_a"].ToString() != "NA")
                {
                    HypFileUpload8_c_a.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_c_a"].ToString();
                    HypFileUpload8_c_a.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_FileUpload8_c_a"].ToString();
                }

                TxtDateofconstitution8_c_b.Text = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateofconstitution8_c_b"].ToString();
            }
            //Form1contentbody_RdbCheckItems1_0 form 1........54545454545454545454.............................................
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString() == "No")
            {
               // TextCheckItems1.Visible = false;
                //FileUploadCheckItems1.Visible = false;
                RdbCheckItems1.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString();
                TextCheckItems1.Text = "";
                HypFileUploadCheckItems1.Visible = false;
                // TextCheckItems1.Visible = false;contentbody_HypFileUploadCheckItems1
                //FileUploadCheckItems1.Visible = false;
            }
            else
            {
             
                RdbCheckItems1.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems1_0"].ToString();
                TextCheckItems1.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems1"].ToString();
            }

            //FileUploadCheckItems1.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems1"].ToString() != "NA")
            {
                HypFileUploadCheckItems1.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems1"].ToString();
                HypFileUploadCheckItems1.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems1"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString() == "No")
            {
                RdbCheckItems2.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString();
                TextCheckItems2.Text = "";
                HypFileUploadCheckItems2.Visible = false;
            }
            else
            {
                RdbCheckItems2.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems2_0"].ToString();
                TextCheckItems2.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems2"].ToString();
            }
            //FileUploadCheckItems2.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems2"].ToString() != "NA")
            {

                HypFileUploadCheckItems2.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems2"].ToString();
                HypFileUploadCheckItems2.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems2"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString() == "No")
            {
                RdbCheckItems3.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString();
                TextCheckItems3.Text = "";
                HypFileUploadCheckItems3.Visible = false;
            }
            else
            {
                RdbCheckItems3.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems3_0"].ToString();
                TextCheckItems3.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems3"].ToString();
            }
            //FileUploadCheckItems3.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems3"].ToString() != "NA")
            {
                HypFileUploadCheckItems3.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems3"].ToString();
                HypFileUploadCheckItems3.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems3"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString() == "No")
            {
                RdbCheckItems4.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString();
                TextCheckItems4.Text = "";
                HypFileUploadCheckItems4.Visible = false;
            }
            else
            {
                RdbCheckItems4.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems4_0"].ToString();
                TextCheckItems4.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems4"].ToString();
            }
            //FileUploadCheckItems4.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems4"].ToString() != "NA")
            {
                HypFileUploadCheckItems4.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems4"].ToString();
                HypFileUploadCheckItems4.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems4"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString() == "No")
            {
                RdbCheckItems5.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString();
                TextCheckItems5.Text = "";
                HypFileUploadCheckItems5.Visible = false;
            }
            else
            {
                RdbCheckItems5.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems5_0"].ToString();
                TextCheckItems5.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems5"].ToString();
            }
            //FileUploadCheckItems5.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems5"].ToString() != "NA")
            {
                HypFileUploadCheckItems5.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems5"].ToString();
                HypFileUploadCheckItems5.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems5"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems6_0"].ToString() == "No")
            {
                RdbCheckItems6.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems6_0"].ToString();
                TextCheckItems6.Text = "";
                HypFileUploadCheckItems6.Visible = false;
            }
            else
            {
                RdbCheckItems6.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems6_0"].ToString();
                TextCheckItems6.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems6"].ToString();
            }
            //FileUploadCheckItems6.FileName= P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems6"].ToString() != "NA")
            {
                HypFileUploadCheckItems6.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems6"].ToString();
                HypFileUploadCheckItems6.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems6"].ToString();
            }
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString() == "No")
            {
                RdbCheckItems7.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString();
                TextCheckItems7.Text = "";
                HypFileUploadCheckItems7.Visible = false;
            }
            else
            {
                RdbCheckItems7.SelectedValue = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_RdbCheckItems7_0"].ToString();
                TextCheckItems7.Text = P_var.dSet.Tables[0].Rows[0]["Form1contentbody_TextCheckItems7"].ToString();
            }
            //FileUploadCheckItems7.FileName = P_var.dSet.Tables[0].Rows[0]["contentbody_TxtDateNotification1_b"].ToString();
            if (P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems7"].ToString() != "NA")
            {
                HypFileUploadCheckItems7.NavigateUrl = ResolveUrl("~/WriteReadData/UserFiles/") + P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems7"].ToString();
                HypFileUploadCheckItems7.Text =  P_var.dSet.Tables[0].Rows[0]["Form1contentbody_FileUploadCheckItems7"].ToString();
            }
        }
        else
        {

        }
    }
   
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/ViewProcessDFO.aspx");
    }
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

                        //Lblmsg.Text = string.Empty;
                        if (Page.IsValid)
                        {
                            #region start insert legal form and form1 parameters
                            _TigerReserveOB.Action = 2;
                            _TigerReserveOB.UpdatedByUserID = Convert.ToInt32(Session["User_Id"]);
                            _TigerReserveOB.UpdatedDate = System.DateTime.Now;
                            _TigerReserveOB.contentbody_DdlNotified1_a = HttpUtility.HtmlEncode(DdlNotified1_a.SelectedValue);
                            if (TxtDateNotification1_b.Text.Trim() != "")
                            {
                                _TigerReserveOB.contentbody_TxtDateNotification1_b = Convert.ToDateTime(TxtDateNotification1_b.Text.Trim());
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
                                _TigerReserveOB.contentbody_TxtDateNotification2_b = Convert.ToDateTime(TxtDateNotification2_b.Text.Trim());
                            }
                            else
                            {
                                _TigerReserveOB.contentbody_TxtDateNotification2_b = null;
                            }
                            _TigerReserveOB.contentbody_TxtAreaHa2_c = Convert.ToDecimal(TxtAreaHa2_c.Text.Trim());
                            _TigerReserveOB.contentbody_DdlExpertCommittee2_d = HttpUtility.HtmlEncode(DdlExpertCommittee2_d.SelectedValue);
                            if (TxtDateConstitution2_e.Text.Trim() != "")
                            {
                                _TigerReserveOB.contentbody_TxtDateConstitution2_e = Convert.ToDateTime(TxtDateConstitution2_e.Text.Trim());
                            }
                            else
                            {
                                _TigerReserveOB.contentbody_TxtDateConstitution2_e = null;
                            }
                            _TigerReserveOB.contentbody_DdlConsultationGramSabha2_f = HttpUtility.HtmlEncode(DdlConsultationGramSabha2_f.SelectedValue);
                            _TigerReserveOB.contentbody_TxtNameGramSabha2_g = HttpUtility.HtmlEncode(TxtNameGramSabha2_g.Text.Trim());
                            //----------start 1----------------------------HypMapCTH2_h-
                            if (HypMapCTH2_h.Text != string.Empty)
                            {
                                Miscelleneous_DL dl = new Miscelleneous_DL();
                                HttpPostedFile file = FileUploadMapCTH2_h.PostedFile;
                                byte[] document = new byte[file.ContentLength];
                                file.InputStream.Read(document, 0, file.ContentLength);
                                System.UInt32 mimetype;
                                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                                mime = Marshal.PtrToStringUni(mimeTypePtr);
                                Marshal.FreeCoTaskMem(mimeTypePtr);  
                                if (FileUploadMapCTH2_h.HasFile == true)
                                {
                                    bool ChkMaliciousType = true;
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    int count = FileUploadMapCTH2_h.PostedFile.FileName.Split('.').Length - 1;
                                    string contenttype = FileUploadMapCTH2_h.PostedFile.ContentType.ToString();
                                    if (count >= 2)
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                                        return;
                                    }


                                    fext1 = System.IO.Path.GetExtension(this.FileUploadMapCTH2_h.FileName.ToString());

                                    if (fext1 == ".pdf")
                                    {
                                        ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadMapCTH2_h.PostedFile.InputStream);
                                    }
                                 //   if (fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG"))
                                    if (fext1.Equals(".jpg") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".JPG") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg"))

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
                                    _TigerReserveOB.contentbody_FileUploadMapCTH2_h = HypMapCTH2_h.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                Miscelleneous_DL dl = new Miscelleneous_DL();
                                HttpPostedFile file = FileUploadMapCTH2_h.PostedFile;
                                byte[] document = new byte[file.ContentLength];
                                file.InputStream.Read(document, 0, file.ContentLength);
                                System.UInt32 mimetype;
                                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                                mime = Marshal.PtrToStringUni(mimeTypePtr);
                                Marshal.FreeCoTaskMem(mimeTypePtr);  
                                if (FileUploadMapCTH2_h.HasFile == true)
                                {
                                    bool ChkMaliciousType = true;
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    int count = FileUploadMapCTH2_h.PostedFile.FileName.Split('.').Length - 1;
                                    string contenttype = FileUploadMapCTH2_h.PostedFile.ContentType.ToString();
                                    if (count >= 2)
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                                        return;
                                    }
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadMapCTH2_h.FileName.ToString());

                                    if (fext1 == ".pdf")
                                    {
                                        ChkMaliciousType = obMiscell.GetActualFileType_pdf(FileUploadMapCTH2_h.PostedFile.InputStream);
                                    }
                                   // if (fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG"))
                                    if (fext1.Equals(".jpg") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".JPG") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg") || fext1.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg"))

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
                            }
                            //--------------start 1-----------------------
                            //----------start 2------------------------------
                            if (HypUploadfile2_i.Text != string.Empty)
                            {
                                if (FileUploadUploadfile2_i.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_i.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUploadUploadfile2_i = HypUploadfile2_i.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadUploadfile2_i.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_i.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                }//
                                else
                                {
                                    _TigerReserveOB.contentbody_FileUploadUploadfile2_i = null;
                                }
                            }
                            //--------------start 2-----------------------
                            // _TigerReserveOB.contentbody_FileUploadUploadfile2_i = "kjkjk";//----------------
                            //----------start 3------------------------------
                            if (HypUploadfile2_j.Text != string.Empty)
                            {
                                if (FileUploadUploadfile2_j.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_j.FileName.ToString());
                                    if (fext1 == ".pdf")
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

                                    _TigerReserveOB.contentbody_FileUploadUploadfile2_j = HypUploadfile2_j.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadUploadfile2_j.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadUploadfile2_j.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 3-----------------------
                            // _TigerReserveOB.contentbody_FileUploadUploadfile2_j = "hhghg";//--------------
                            _TigerReserveOB.contentbody_DdlCompleted3_a = HttpUtility.HtmlEncode(DdlCompleted3_a.SelectedValue);
                            //----------start 4------------------------------
                            if (HypFileUploadCompleted3_a.Text != string.Empty)
                            {
                                if (FileUploadCompleted3_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCompleted3_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUploadCompleted3_a = HypFileUploadCompleted3_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCompleted3_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCompleted3_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 4-----------------------
                            // _TigerReserveOB.contentbody_FileUploadCompleted3_a = "hghg";//----------
                            _TigerReserveOB.contentbody_DdlProvided4_a = HttpUtility.HtmlEncode(DdlProvided4_a.SelectedValue);
                            _TigerReserveOB.contentbody_DdlObtained5_a = HttpUtility.HtmlEncode(DdlObtained5_a.SelectedValue);
                            _TigerReserveOB.contentbody_DdlObtained6_a = HttpUtility.HtmlEncode(DdlObtained6_a.SelectedValue);
                            //----------start 5------------------------------
                            if (HypFileUpload6_a.Text != string.Empty)
                            {
                                if (FileUpload6_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload6_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUpload6_a = HypFileUpload6_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUpload6_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload6_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 5-----------------------
                            // _TigerReserveOB.contentbody_FileUpload6_a = "jkjkj";//----
                            _TigerReserveOB.contentbody_DdlProvided7_a = HttpUtility.HtmlEncode(DdlProvided7_a.SelectedValue);
                            //----------start 6------------------------------
                            if (HypFileUploadProvided7_a.Text != string.Empty)
                            {
                                if (FileUploadProvided7_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadProvided7_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUploadProvided7_a = HypFileUploadProvided7_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadProvided7_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadProvided7_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 6-----------------------
                            // _TigerReserveOB.contentbody_FileUploadProvided7_a = "jkjkjk";//----
                            _TigerReserveOB.contentbody_DdlConstituted8_a_a = HttpUtility.HtmlEncode(DdlConstituted8_a_a.SelectedValue);
                            //----------start 7------------------------------
                            if (HypFileUpload8_a_a.Text != string.Empty)
                            {
                                if (FileUpload8_a_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_a_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUpload8_a_a = HypFileUpload8_a_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUpload8_a_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_a_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 7-----------------------
                            // _TigerReserveOB.contentbody_FileUpload8_a_a = "jkjkjk";//---
                            if (TxtDateofconstitution8_a_b.Text.Trim() != "")
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_a_b = Convert.ToDateTime(TxtDateofconstitution8_a_b.Text.Trim());
                            }
                            else
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_a_b = null;
                            }
                            _TigerReserveOB.contentbody_DdlConstituted8_b_a = HttpUtility.HtmlEncode(DdlConstituted8_b_a.SelectedValue);
                            //----------start 8------------------------------
                            if (HypFileUpload8_b_a.Text != string.Empty)
                            {
                                if (FileUpload8_b_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_b_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUpload8_b_a = HypFileUpload8_b_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {

                                if (FileUpload8_b_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_b_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 8-----------------------
                            //  _TigerReserveOB.contentbody_FileUpload8_b_a = "kjkjk";//---------------

                            if (TxtDateofconstitution8_b_b.Text.Trim() != "")
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_b_b = Convert.ToDateTime(TxtDateofconstitution8_b_b.Text.Trim());
                            }
                            else
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_b_b = null;
                            }

                            _TigerReserveOB.contentbody_Ddl8_c_a = HttpUtility.HtmlEncode(Ddl8_c_a.SelectedValue);
                            //----------start 9------------------------------
                            if (HypFileUpload8_c_a.Text != string.Empty)
                            {
                                if (FileUpload8_c_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_c_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.contentbody_FileUpload8_c_a = HypFileUpload8_c_a.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUpload8_c_a.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUpload8_c_a.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 9-----------------------
                            //  _TigerReserveOB.contentbody_FileUpload8_c_a = "hghghg";//----------
                            if (TxtDateofconstitution8_c_b.Text.Trim() != "")
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_c_b = Convert.ToDateTime(TxtDateofconstitution8_c_b.Text.Trim());
                            }
                            else
                            {
                                _TigerReserveOB.contentbody_TxtDateofconstitution8_c_b = null;
                            }
                            _TigerReserveOB.Form1contentbody_RdbCheckItems1_0 = HttpUtility.HtmlEncode(RdbCheckItems1.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems1 = HttpUtility.HtmlEncode(TextCheckItems1.Text.Trim());
                            //----------start 10------------------------------
                            if (HypFileUploadCheckItems1.Text != string.Empty)
                            {
                                if (FileUploadCheckItems1.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems1.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems1 = HypFileUploadCheckItems1.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems1.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems1.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 10-----------------------
                            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems1 = "jhjh";//-----------
                            _TigerReserveOB.Form1contentbody_RdbCheckItems2_0 = HttpUtility.HtmlEncode(RdbCheckItems2.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems2 = HttpUtility.HtmlEncode(TextCheckItems2.Text.Trim());
                            //----------start 11------------------------------
                            if (HypFileUploadCheckItems2.Text != string.Empty)
                            {
                                if (FileUploadCheckItems2.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems2.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems2 = HypFileUploadCheckItems2.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems2.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems2.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 11-----------------------
                            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems2 = "kjkjk";//---
                            _TigerReserveOB.Form1contentbody_RdbCheckItems3_0 = HttpUtility.HtmlEncode(RdbCheckItems3.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems3 = HttpUtility.HtmlEncode(TextCheckItems3.Text.Trim());
                            //----------start 12------------------------------
                            if (HypFileUploadCheckItems3.Text != string.Empty)
                            {
                                if (FileUploadCheckItems3.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems3.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems3 = HypFileUploadCheckItems3.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems3.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems3.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 12-----------------------
                            // _TigerReserveOB.Form1contentbody_FileUploadCheckItems3 = "hjhjh";//------------
                            _TigerReserveOB.Form1contentbody_RdbCheckItems4_0 = HttpUtility.HtmlEncode(RdbCheckItems4.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems4 = HttpUtility.HtmlEncode(TextCheckItems4.Text.Trim());
                            //----------start 13------------------------------
                            if (HypFileUploadCheckItems4.Text != string.Empty)
                            {
                                if (FileUploadCheckItems4.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems4.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems4 = HypFileUploadCheckItems4.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems4.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems4.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 13-----------------------
                            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems4 = "fdfd";//---
                            _TigerReserveOB.Form1contentbody_RdbCheckItems5_0 = HttpUtility.HtmlEncode(RdbCheckItems5.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems5 = HttpUtility.HtmlEncode(TextCheckItems5.Text.Trim());
                            //----------start 14------------------------------
                            if (HypFileUploadCheckItems5.Text != string.Empty)
                            {
                                if (FileUploadCheckItems5.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems5.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems5 = HypFileUploadCheckItems5.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems5.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems5.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 14-----------------------
                            //_TigerReserveOB.Form1contentbody_FileUploadCheckItems5 = "fdfdf";//------------
                            _TigerReserveOB.Form1contentbody_RdbCheckItems6_0 = HttpUtility.HtmlEncode(RdbCheckItems6.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems6 = HttpUtility.HtmlEncode(TextCheckItems6.Text.Trim());
                            //----------start 15------------------------------
                            if (HypFileUploadCheckItems6.Text != string.Empty)
                            {
                                if (FileUploadCheckItems6.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems6.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems6 = HypFileUploadCheckItems6.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems6.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems6.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 15-----------------------
                            //_TigerReserveOB.Form1contentbody_FileUploadCheckItems6 = "gfgf";//---
                            _TigerReserveOB.Form1contentbody_RdbCheckItems7_0 = HttpUtility.HtmlEncode(RdbCheckItems7.SelectedValue);
                            _TigerReserveOB.Form1contentbody_TextCheckItems7 = HttpUtility.HtmlEncode(TextCheckItems7.Text.Trim());
                            //----------start 16------------------------------
                            if (HypFileUploadCheckItems7.Text != string.Empty)
                            {
                                if (FileUploadCheckItems7.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems7.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                                    _TigerReserveOB.Form1contentbody_FileUploadCheckItems7 = HypFileUploadCheckItems7.Text.Trim();
                                }
                                // FMLYMEM_ENT_Obj.Photo = HypMapCTH2_h.Text.Trim();
                            }
                            else
                            {
                                if (FileUploadCheckItems7.HasFile == true)
                                {
                                    string path;
                                    string fext1 = "";
                                    string filename;
                                    bool ChkMaliciousType = true;
                                    fext1 = System.IO.Path.GetExtension(this.FileUploadCheckItems7.FileName.ToString());
                                    if (fext1 == ".pdf")
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
                            }
                            //--------------start 16-----------------------
                            //  _TigerReserveOB.Form1contentbody_FileUploadCheckItems7 = "gfgf";//---
                            _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);

                            #endregion end insert legal form and form1
                            int legaform = _tigerReserverBl.UpdateAllLegalFormAndForm1(_TigerReserveOB);
                            Session["msg"] = "Legal form/Form 1 has update successfully.";

                            //ConversionScheme_AddConversionScheme
                            Session["BackUrl"] = "~/Auth/AdminPanel/ProcessManegment/DfoUser/ViewProcessDFO.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");




                        }
                   // }
                }
            }
        }
        catch
        {
            throw;
        }
        // }
    }
                      

    

    protected void BtnBack_Click1(object sender, EventArgs e)
    {
        if (Request.QueryString["chk"].ToString() == "super")
        {
            Response.Redirect("~/auth/adminpanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx");
        }
        if (Request.QueryString["chk"].ToString() == "cntca")
        {
            Response.Redirect("~/auth/adminpanel/ProcessManegment/ReserveUser/ConversationBetweenStateNtca.aspx");
        }
        if (Request.QueryString["chk"].ToString() == "creserve")
        {
            Response.Redirect("~/auth/adminpanel/ProcessManegment/ReserveUser/ViewProcessReserve.aspx");
        }
        if (Request.QueryString["chk"].ToString() == "reserv")
        {
            Response.Redirect("~/auth/adminpanel/ProcessManegment/DfoUser/ViewProcessDFO.aspx");
        }
    }
}
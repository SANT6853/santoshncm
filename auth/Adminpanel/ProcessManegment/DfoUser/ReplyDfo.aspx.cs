using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_ProcessManegment_DfoUser_ReplyDfo :CrsfBase
{
    //-------------
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();

    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
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
            GetRecordDfoReserveProcess(Convert.ToInt32(Request.QueryString["TblFromDfoToReserveAutoID"]));

        }


    }
   
    void GetRecordDfoReserveProcess(int iTblFromDfoToReserveAutoID)
    {
        P_var.dSet = null;

        _TigerReserveOB.TblFromDfoToReserveAutoID = iTblFromDfoToReserveAutoID;
        _TigerReserveOB.Action = 3;
        P_var.dSet = _tigerReserverBl.GetDfoReserveProcessDal(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            TokenId_FirstTimeInsertNoChange = P_var.dSet.Tables[0].Rows[0]["TokenId_FirstTimeInsertNoChange"].ToString();
            LblTokenID.Text = TokenId_FirstTimeInsertNoChange;
            VillageID_FirstTimeInsertNoChange = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["VillageID_FirstTimeInsertNoChange"]);
            LblVillageName.Text = P_var.dSet.Tables[0].Rows[0]["VILL_NM"].ToString();
            StatusIDDefault = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["StatusIDDefault"]);
            lblstatus.Text = P_var.dSet.Tables[0].Rows[0]["StatusIDDefault1"].ToString();
            FromAmount_FirstTimeInsertNoChange = Convert.ToDouble(P_var.dSet.Tables[0].Rows[0]["FromAmount_FirstTimeInsertNoChange"]);
            LblAmount.Text = FromAmount_FirstTimeInsertNoChange.ToString();
            lblAcceptedAmount.Text = P_var.dSet.Tables[0].Rows[0]["AcceptedAmount"].ToString();
            AcceptedAmount = Convert.ToDouble(P_var.dSet.Tables[0].Rows[0]["AcceptedAmount"]);
            //if (P_var.dSet.Tables[0].Rows[0]["CommentedApprovedAmount"] != null)
            //{
            //    CommentedApprovedAmount = Convert.ToDouble(P_var.dSet.Tables[0].Rows[0]["CommentedApprovedAmount"]);
            //}
            //else
            //{
            //    CommentedApprovedAmount = 0;
            //}
            // LblApprovedAmount.Text = CommentedApprovedAmount.ToString();
            FromDescription_FirstTimeInsertNoChange = P_var.dSet.Tables[0].Rows[0]["FromDescription_FirstTimeInsertNoChange"].ToString();
            LblDescrption.Text = P_var.dSet.Tables[0].Rows[0]["FromDescription_FirstTimeInsertNoChange"].ToString();
            CommentedRemarks = P_var.dSet.Tables[0].Rows[0]["CommentedRemarks"].ToString();

            FromPersonID = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["FromPersonID"]);
            ToPersonID = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["ToPersonID"]);

            FromInsertDate_FirstTimeInsertNoChange = Convert.ToDateTime(P_var.dSet.Tables[0].Rows[0]["FromInsertDate_FirstTimeInsertNoChange1"]);
            lblapplydate.Text = P_var.dSet.Tables[0].Rows[0]["FromInsertDate_FirstTimeInsertNoChange1"].ToString();
            if (!Convert.IsDBNull(P_var.dSet.Tables[0].Rows[0]["CommentedDate"]))
            {
                CommentedDate = Convert.ToDateTime(P_var.dSet.Tables[0].Rows[0]["CommentedDate"]);
            }
            else
            {

            }
            // CommentedDate = Convert.ToDateTime(P_var.dSet.Tables[0].Rows[0]["CommentedDate"]);
            FromPersonUserName = P_var.dSet.Tables[0].Rows[0]["FromPersonUserName"].ToString();
            ToPersonUserName = P_var.dSet.Tables[0].Rows[0]["ToPersonUserName"].ToString();
            LblReportingManager.Text = P_var.dSet.Tables[0].Rows[0]["ToPersonUserName"].ToString();
          
        }
        else
        {

        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/ViewProcessDFO.aspx");
    }
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


                        Lblmsg.Text = string.Empty;
                        if (Page.IsValid)
                        {

                            _TigerReserveOB.RecordCreatedByUserID = Convert.ToInt32(Session["User_Id"]);
                            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = TokenId_FirstTimeInsertNoChange;
                            _TigerReserveOB.FromPersonID = Convert.ToInt32(FromPersonID);
                            _TigerReserveOB.ToPersonID = Convert.ToInt32(ToPersonID);
                            _TigerReserveOB.ToPersonUserName = ToPersonUserName;
                            _TigerReserveOB.FromPersonUserName = FromPersonUserName;
                            _TigerReserveOB.Action = 4;
                            _TigerReserveOB.AcceptedAmount = AcceptedAmount;
                            _TigerReserveOB.VillageID_FirstTimeInsertNoChange = VillageID_FirstTimeInsertNoChange;
                            _TigerReserveOB.FromAmount_FirstTimeInsertNoChange = FromAmount_FirstTimeInsertNoChange;
                            _TigerReserveOB.FromDescription_FirstTimeInsertNoChange = FromDescription_FirstTimeInsertNoChange;
                            _TigerReserveOB.CommentedRemarks = HttpUtility.HtmlEncode(txtfunddescription.Text.Trim());
                            _TigerReserveOB.FromInsertDate_FirstTimeInsertNoChange = FromInsertDate_FirstTimeInsertNoChange;

                            _tigerReserverBl.InsertDFOtoReserve(_TigerReserveOB);

                            Session["msg"] = "Process has been added successfully.";

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

}
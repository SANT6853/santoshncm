using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_ProcessManegment_ReserveUser_ReplyFromReserveToDfo : CrsfBase
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
    public static string StatusIdi;
    public static int? TblFromReserveToDfoAutoIDStateForwardedRowID;
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
            BindStatus();
            QueryStringGet();
            PendingStatusId(1);
        }
    }
    void QueryStringGet()
    {


        if (Request.QueryString["TblFromStateToReserveAutoID"] != null)
        {
            GetRecordDfoReserveProcess(Convert.ToInt32(Request.QueryString["TblFromStateToReserveAutoID"]));

        }


    }
    void GetRecordDfoReserveProcess(int TblFromStateToReserveAutoID)
    {
        P_var.dSet = null;

        _TigerReserveOB.TblFromStateToReserveAutoID = TblFromStateToReserveAutoID;
        _TigerReserveOB.Action = 7;
        P_var.dSet = _tigerReserverBl.GetNtcaStateReplyProcessDal(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            TblFromReserveToDfoAutoIDStateForwardedRowID = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["TblFromReserveToDfoAutoIDStateForwardedRowID"]);
            TokenId_FirstTimeInsertNoChange = P_var.dSet.Tables[0].Rows[0]["TokenId_FirstTimeInsertNoChange"].ToString();
            LblTokenID.Text = TokenId_FirstTimeInsertNoChange;
            VillageID_FirstTimeInsertNoChange = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["VillageID_FirstTimeInsertNoChange"]);
            LblVillageName.Text = P_var.dSet.Tables[0].Rows[0]["VILL_NM"].ToString();
            StatusIDDefault = Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["StatusIDDefault"]);
            DDlStatus.SelectedValue = StatusIDDefault.ToString();
            FromAmount_FirstTimeInsertNoChange = Convert.ToDouble(P_var.dSet.Tables[0].Rows[0]["FromAmount_FirstTimeInsertNoChange"]);
            //  txtamount.Text = FromAmount_FirstTimeInsertNoChange.ToString();

            LblRequestedAmount.Text = P_var.dSet.Tables[0].Rows[0]["FromAmount_FirstTimeInsertNoChange"].ToString();
            LblPreviousAcceptedAmount.Text = P_var.dSet.Tables[0].Rows[0]["AcceptedAmount"].ToString();
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
            // CommentedDate = Convert.ToDateTime(P_var.dSet.Tables[0].Rows[0]["CommentedDate"]);FromPersonUserName
            FromPersonUserName = P_var.dSet.Tables[0].Rows[0]["FromPersonUserName"].ToString();
            ToPersonUserName = P_var.dSet.Tables[0].Rows[0]["ToPersonUserName"].ToString();
            //LblReportingManager.Text = P_var.dSet.Tables[0].Rows[0]["ToPersonUserName"].ToString();
            LblReportingManager.Text = P_var.dSet.Tables[0].Rows[0]["FromPersonUserName"].ToString();
        }
        else
        {

        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Auth/AdminPanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx");
    }
    void DeleteVerifiedReject()
    {
        try
        {
            _TigerReserveOB.Action = 10;
            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = TokenId_FirstTimeInsertNoChange.ToString();
            _TigerReserveOB.StatusIDDefault = Convert.ToInt32(DDlStatus.SelectedValue);
            _tigerReserverBl.InsertDFOtoReserve(_TigerReserveOB);
        }
        catch (Exception)
        {
            throw;
        }
    }
    void ReplyCode()
    {
        _TigerReserveOB.TblFromReserveToDfoAutoIDStateForwardedRowID = TblFromReserveToDfoAutoIDStateForwardedRowID;
        _TigerReserveOB.RecordCreatedByUserID = Convert.ToInt32(Session["User_Id"]);
        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = TokenId_FirstTimeInsertNoChange;
        _TigerReserveOB.FromPersonID = Convert.ToInt32(FromPersonID);
        _TigerReserveOB.ToPersonID = Convert.ToInt32(ToPersonID);
        _TigerReserveOB.ToPersonUserName = ToPersonUserName;
        _TigerReserveOB.FromPersonUserName = FromPersonUserName;
        _TigerReserveOB.Action = 8;

        _TigerReserveOB.VillageID_FirstTimeInsertNoChange = VillageID_FirstTimeInsertNoChange;
        _TigerReserveOB.FromAmount_FirstTimeInsertNoChange = FromAmount_FirstTimeInsertNoChange;
        _TigerReserveOB.AcceptedAmount = Convert.ToDouble(txtAcceptedAmount.Text.Trim());
        _TigerReserveOB.FromDescription_FirstTimeInsertNoChange = FromDescription_FirstTimeInsertNoChange;
        _TigerReserveOB.CommentedRemarks = HttpUtility.HtmlEncode(txtfunddescription.Text.Trim());
        _TigerReserveOB.FromInsertDate_FirstTimeInsertNoChange = FromInsertDate_FirstTimeInsertNoChange;
        _TigerReserveOB.StatusIDDefault = Convert.ToInt32(DDlStatus.SelectedValue);

        _tigerReserverBl.InsertNtcaStateReplyDal(_TigerReserveOB);

        Session["msg"] = "Process has been added successfully.";

        //ConversionScheme_AddConversionScheme
        Session["BackUrl"] = "~/Auth/AdminPanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx";
        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
    }
    public void BindStatus()
    {
        VillageDB VillDB_Obj = new VillageDB();
        try
        {
            common com_Obj = new common();
           
            DDlStatus.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.FundStatusBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
              // ListItem li2 = new ListItem("Select", "0");
                ListItem li2 = new ListItem();
                DDlStatus.Items.Clear();
                DDlStatus.Items.Add(li2);
                DDlStatus.Items.Clear();
                list = com_Obj.FillDropDownList(ds, 0, "StatusName");
                int i = list.Count - 1;
                int j = 0;
                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["StatusID"].ToString());
                    ++j;
                    DDlStatus.Items.Add(li);

                }


            }
            else
            {


                DDlStatus.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void PendingStatusId(int statusId)
    {
        VillageDB VillDB_Obj = new VillageDB();
        try
        {
            common com_Obj = new common();

            DataSet ds = new DataSet();
            ds = VillDB_Obj.StatusIDDs(statusId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                StatusIdi = ds.Tables[0].Rows[0]["StatusName"].ToString();

            }
           
        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
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
                    {        //StatusIdi
                        Lblmsg.Text = "";
                        // if (Page.IsValid)
                        //{
                        //FromPersonID,ToPersonID,ToPersonUserName,FromPersonUserName,Action
                        // DeleteVerifiedReject();

                        if (DDlStatus.SelectedValue == "1")//Verified
                        {
                            ReplyCode();
                        }
                        if (DDlStatus.SelectedValue == "2")//Verified
                        {//Verified only then previous accepted amount current txtaccepted amount must be 
                            //match don't match it means you first disscuss with dfo with using status pending.
                            //After he satisfied your with comment then Verifed to proceed on senior level

                            //------------27juneStart
                            if (LblRequestedAmount.Text == txtAcceptedAmount.Text.Trim())
                            {
                                if (LblPreviousAcceptedAmount.Text == "0.00")
                                {
                                    ReplyCode();
                                }
                            }

                            //-----------27juneEnd
                            if (LblPreviousAcceptedAmount.Text != txtAcceptedAmount.Text)
                            {
                                Lblmsg.Text = "Your previous accepted amount is not match with current accepted amount.So that reason you choose status [" + StatusIdi + "].After discussion with comment then you can changed status [" + DDlStatus.SelectedItem.Text + "]!.";
                                Lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                ReplyCode();

                            }
                        }

                        if (DDlStatus.SelectedValue == "3")//Approved
                        {//Verified only then previous accepted amount current txtaccepted amount must be 
                            //match don't match it means you first disscuss with dfo with using status pending.
                            //After he satisfied your with comment then Verifed to proceed on senior level
                            //------------27juneStart
                            if (LblRequestedAmount.Text == txtAcceptedAmount.Text.Trim())
                            {
                                if (LblPreviousAcceptedAmount.Text == "0.00")
                                {
                                    ReplyCode();
                                }
                            }

                            //-----------27juneEnd
                            if (LblPreviousAcceptedAmount.Text != txtAcceptedAmount.Text)
                            {
                                //[" + StatusIdi + "]
                                //[" + DDlStatus.SelectedItem.Text+ "]
                                Lblmsg.Text = "Your previous accepted amount is not match with current accepted amount.So that reason you choose status [" + StatusIdi + "].After discussion with comment then you can changed status [" + DDlStatus.SelectedItem.Text + "]!.";
                                Lblmsg.ForeColor = System.Drawing.Color.Red;
                            }//
                            else
                            {
                                ReplyCode();

                            }
                        }

                        if (DDlStatus.SelectedValue == "4")//Rejected
                        {//Verified only then previous accepted amount current txtaccepted amount must be 
                            //match don't match it means you first disscuss with dfo with using status pending.
                            //After he satisfied your with comment then Verifed to proceed on senior level
                            if (LblPreviousAcceptedAmount.Text != txtAcceptedAmount.Text)
                            {
                                Lblmsg.Text = "Your previous accepted amount is not match with current accepted amount.So that reason you choose status [" + StatusIdi + "].After discussion with comment then you can changed status [" + DDlStatus.SelectedItem.Text + "]!.";
                                Lblmsg.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                ReplyCode();

                            }
                        }
                        //}
                    }
                }
            }
        }
        //}

        catch
        {
            throw;
        }
        // }
    }
}
               
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_ProcessManegment_ReserveUser_ConversationBetweenStateNtca :CrsfBase
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    protected void Page_Load(object sender, EventArgs e)
    {
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
          
            LblMsg.Text = "";


            BindDfoReserveProcess();
        }
    }
    void BindDfoReserveProcess()
    {
        LblMsg.Text = "";
        P_var.dSet = null;
       // _TigerReserveOB.ToPersonID = Convert.ToInt32(Session["User_Id"]);
        _TigerReserveOB.FromPersonID = Convert.ToInt32(Session["User_Id"]);
        _TigerReserveOB.Action = 13;
        P_var.dSet = _tigerReserverBl.GetFromStateToNtcaDal(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GrdDfoReserve.DataSource = P_var.dSet;
            GrdDfoReserve.DataBind();
        }
        else
        {
            LblMsg.Text = "NO RECORD FOUND!";
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    string PendingStatusId(int statusId)
    {
        string StatusName = string.Empty;
        VillageDB VillDB_Obj = new VillageDB();
        try
        {
            common com_Obj = new common();

            DataSet ds = new DataSet();
            ds = VillDB_Obj.StatusIDDs(statusId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                StatusName = ds.Tables[0].Rows[0]["StatusName"].ToString();

            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        return StatusName;
    }
    protected void GrdDfoReserve_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDfoReserve.PageIndex = e.NewPageIndex;
        BindDfoReserveProcess();
    }
    protected void GrdDfoReserve_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        LblMsg.Text = string.Empty;
                        if (e.CommandName == "rep")
                        {
                            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                            int rowIndex = gvr.RowIndex;

                            var varStatus = (GrdDfoReserve.Rows[rowIndex].FindControl("HydStatus") as HiddenField).Value;
                            var TokenId = (GrdDfoReserve.Rows[rowIndex].FindControl("LblTokenID") as Label).Text;
                            var BtnRequestToStateUser = (GrdDfoReserve.Rows[rowIndex].FindControl("BtnRequestToStateUser") as Button);

                            if (varStatus == "2" || varStatus == "3" || varStatus == "4")
                            {
                                string DynamicStatus = PendingStatusId(Convert.ToInt32(varStatus));
                                string pendingStatus = PendingStatusId(1);
                                string Msg = "TokenID:" + TokenId + " ,Sorry! your token status has [" + DynamicStatus + "]" + " So,that reason you don't have permission to access this event in case of [" + pendingStatus + "] status you can do reply only!";
                                LblMsg.Text = Msg;
                                LblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                LblMsg.Text = string.Empty;
                                int TblFromReserveToStateAutoID = Convert.ToInt32(e.CommandArgument);
                                Response.Redirect("~/Auth/AdminPanel/ProcessManegment/ReserveUser/ReplyFromStateToNtca.aspx?TblFromReserveToStateAutoID=" + TblFromReserveToStateAutoID, false);

                            }

                            //  Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/ReplyDfo.aspx?TblFromDfoToReserveAutoID=" + TblFromDfoToReserveAutoID + "&TokenId_FirstTimeInsertNoChange=" + TokenId_FirstTimeInsertNoChange + "&StatusIDDefault1=" + StatusIDDefault1 + "&VILL_NM=" + VILL_NM + "&FromAmount_FirstTimeInsertNoChange=" + FromAmount_FirstTimeInsertNoChange + "&FromDescription_FirstTimeInsertNoChange=" + FromDescription_FirstTimeInsertNoChange + "&ToPersonUserName=" + ToPersonUserName + "&FromInsertDate_FirstTimeInsertNoChange1=" + FromInsertDate_FirstTimeInsertNoChange1 + "&CommentedApprovedAmount=" + CommentedApprovedAmount, false);  

                        }
                        if (e.CommandName == "history")
                        {
                            string tokenID = e.CommandArgument.ToString();
                            Response.Redirect("~/Auth/AdminPanel/ProcessManegment/ReserveUser/StateToNtcaHistory.aspx?tokenID=" + tokenID, false);


                        }
                        if (e.CommandName == "Back")
                        {//LblTokenID

                            int TblFromReserveToStateAutoID = Convert.ToInt32(e.CommandArgument);
                            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                            int rowIndex = gvr.RowIndex;
                            var varAutoIDStateForwardedRowID = (GrdDfoReserve.Rows[rowIndex].FindControl("HydTblFromReserveToDfoAutoIDStateForwardedRowID") as HiddenField).Value;

                            //  _TigerReserveOB.ForwardToStateUserName = Convert.ToInt32(Request.QueryString["TblFromReserveToDfoAutoID"]);
                            _TigerReserveOB.TblFromReserveToDfoAutoIDStateForwardedRowID = Convert.ToInt32(varAutoIDStateForwardedRowID);
                            _TigerReserveOB.TblFromReserveToStateAutoID = TblFromReserveToStateAutoID;

                            _TigerReserveOB.Action = 15;

                            _tigerReserverBl.BackToStateDeleteRecord(_TigerReserveOB);

                            Session["msg"] = "Record has BACK successfully.";

                            //ConversionScheme_AddConversionScheme
                            Session["BackUrl"] = "~/Auth/AdminPanel/ProcessManegment/ReserveUser/ConversationBetweenStateNtca.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");



                            //var varStatus = (GrdDfoReserve.Rows[rowIndex].FindControl("HydStatus") as HiddenField).Value;
                            //var TokenId = (GrdDfoReserve.Rows[rowIndex].FindControl("LblTokenID") as Label).Text;
                            //var BtnRequestToStateUser = (GrdDfoReserve.Rows[rowIndex].FindControl("BtnRequestToStateUser") as Button);

                            //if (varStatus == "1")
                            //{
                            //    string Verified = PendingStatusId(2);

                            //    string Msg = "TokenID:" + TokenId + " ,please Update status [" + Verified + "]";
                            //    LblMsg.Text = Msg;
                            //    LblMsg.ForeColor = System.Drawing.Color.Red;
                            //}
                            //else
                            //{
                            //    LblMsg.Text = string.Empty;
                            //    int TblFromReserveToDfoAutoID = Convert.ToInt32(e.CommandArgument);
                            //    Response.Redirect("~/Auth/AdminPanel/ProcessManegment/ReserveUser/RequestToStateUser.aspx?TblFromReserveToDfoAutoID=" + TblFromReserveToDfoAutoID, false);
                            //}

                        }
                        //Bind_TigerReserveList();
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
        protected void GrdDfoReserve_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    bool ChkTokenHasVerified(string tokenid)
    {
        bool chk = false;
        try
        {
            P_var.dSet = null;

            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = tokenid;
            _TigerReserveOB.Action = 11;
            P_var.dSet = _tigerReserverBl.GetDfoReserveProcessDal(_TigerReserveOB);
            if (P_var.dSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < P_var.dSet.Tables[0].Rows.Count; i++)
                {
                    string status = P_var.dSet.Tables[0].Rows[i]["StatusIDDefault"].ToString();
                    if (status == "2" || status == "3" || status == "4")
                    {
                        //VerifedAmount = P_var.dSet.Tables[0].Rows[0]["FromAmount_FirstTimeInsertNoChange"].ToString();
                        return chk = true;
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        return chk;
    }
    protected void GrdDfoReserve_RowDataBound(object sender, GridViewRowEventArgs e)
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


                        if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
                        {
                            if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
                            {

                                Button cBtnReply = (Button)e.Row.Cells[11].FindControl("BtnReplyToDfoUser");
                                Label lblLblTokenID = (Label)e.Row.Cells[1].FindControl("LblTokenID");

                                Button BtnRequestToStateUser = (Button)e.Row.Cells[11].FindControl("BtnRequestToStateUser"); //access the LinkButton from the TemplateField using FindControl method
                                Label lblStatus = (Label)e.Row.Cells[2].FindControl("LblStatus");
                                HiddenField HydStatus = (HiddenField)e.Row.Cells[2].FindControl("HydStatus");

                                //HiddenField hhydForwardToStateUserID = (HiddenField)e.Row.Cells[2].FindControl("hydForwardToStateUserID");
                                //HiddenField hHydForwardToStateUserName = (HiddenField)e.Row.Cells[2].FindControl("HydForwardToStateUserName");
                                Label lblLblActionMsg = (Label)e.Row.Cells[11].FindControl("LblActionMsg");
                                if (BtnRequestToStateUser != null)
                                {

                                    BtnRequestToStateUser.Attributes.Add("onclick", "return ConfirmOnDelete('" + lblLblTokenID.Text + "');"); //attach the JavaScript function
                                }



                                //if table name TblFromReserveToDfo column has update value of state user itmeans record has send to state user
                                //and both has disable and show message in label for reserve user confirmation what is the position of this token id
                                //if (hhydForwardToStateUserID.Value != "0")
                                //{
                                //    BtnRequestToStateUser.Visible = false;
                                //    cBtnReply.Visible = false;
                                //    lblLblActionMsg.Text = "Your Request has forwarded to ntca";
                                //    lblLblActionMsg.ForeColor = System.Drawing.Color.Green;
                                //}
                                //else
                                //{
                                //    BtnRequestToStateUser.Visible = true;
                                //    cBtnReply.Visible = true;
                                //}
                            }
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
    
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LblMsg.Text = string.Empty;
        if (TxtTokenId.Text == "")
        {
            TxtTokenId.Text = null;
        }

        string ddval = string.Empty;
        if (DDlStatus.SelectedIndex != 0)
        {
            ddval = DDlStatus.SelectedValue;
        }
        else
        {
            ddval = null;
        }
        P_var.dSet = null;

        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = TxtTokenId.Text;
        _TigerReserveOB.StatusIDDefault = Convert.ToInt32(ddval);
        _TigerReserveOB.Action = 13;
        _TigerReserveOB.ToPersonID = Convert.ToInt32(Session["User_Id"]);
        P_var.dSet = _tigerReserverBl.GetDfoReserveProcessDal(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GrdDfoReserve.Visible = true;
            GrdDfoReserve.DataSource = P_var.dSet;
            GrdDfoReserve.DataBind();
        }
        else
        {
            GrdDfoReserve.Visible = false;
            LblMsg.Text = "NO RECORD FOUND!";
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {

    }
   
}
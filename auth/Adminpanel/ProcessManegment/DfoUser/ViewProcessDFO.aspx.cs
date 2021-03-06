using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_ProcessManegment_DfoUser_ViewProcessDFO : CrsfBase
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
    public static string TokenID;
    public static string VerifedAmount;
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
        _TigerReserveOB.FromPersonID = Convert.ToInt32(Session["User_Id"]);
        _TigerReserveOB.Action = 2;
        P_var.dSet = _tigerReserverBl.GetDfoReserveProcessDal(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GrdDfoReserve.DataSource = P_var.dSet;
            GrdDfoReserve.DataBind();
            GridveiwNumericColumnCalculation(P_var.dSet);
        }
        else
        {
            LblMsg.Text = "NO RECORD FOUND!";
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void GrdDfoReserve_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDfoReserve.PageIndex = e.NewPageIndex;
        BindDfoReserveProcess();
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
                                int TblFromDfoToReserveAutoID = Convert.ToInt32(e.CommandArgument);
                                Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/ReplyDfo.aspx?TblFromDfoToReserveAutoID=" + TblFromDfoToReserveAutoID, false);

                            }

                        }
                        if (e.CommandName == "history")
                        {
                            string TokenID = e.CommandArgument.ToString();
                            Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/DfoHistory.aspx?TokenID=" + TokenID, false);


                        }
                        if (e.CommandName == "del")
                        {
                            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                            Label lbltokenid = row.FindControl("LblTokenID") as Label;
                            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = lbltokenid.Text;

                            _TigerReserveOB.Action = 6;

                            _tigerReserverBl.InsertDFOtoReserve(_TigerReserveOB);

                            Session["msg"] = "Record has been deleted successfully.";

                            //ConversionScheme_AddConversionScheme
                            Session["BackUrl"] = "~/Auth/AdminPanel/ProcessManegment/DfoUser/ViewProcessDFO.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");

                        }
                        if (e.CommandName == "legal")
                        {
                            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                            int rowIndex = gvr.RowIndex;

                            var varStatus = (GrdDfoReserve.Rows[rowIndex].FindControl("HydStatus") as HiddenField).Value;
                            var TokenId = (GrdDfoReserve.Rows[rowIndex].FindControl("LblTokenID") as Label).Text;
                            var BtnRequestToStateUser = (GrdDfoReserve.Rows[rowIndex].FindControl("BtnRequestToStateUser") as Button);
                            var BtnEditLegalFormForm1 = (GrdDfoReserve.Rows[rowIndex].FindControl("BtnEditLegalFormForm1") as Button);

                            if (varStatus == "2" || varStatus == "3" || varStatus == "4")
                            {
                                //  BtnEditLegalFormForm1.Text="View legal from and form 1";
                                string TblFromDfoToReserveAutoID = e.CommandArgument.ToString();
                                Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/ViewLegalForm.aspx?TblFromDfoToReserveAutoID=" + TblFromDfoToReserveAutoID + "&chk=reserv", false);
                            }
                            else
                            {
                                LblMsg.Text = string.Empty;
                                string TblFromDfoToReserveAutoID = e.CommandArgument.ToString();
                                Response.Redirect("~/Auth/AdminPanel/ProcessManegment/DfoUser/EditLegalForm1.aspx?TblFromDfoToReserveAutoID=" + TblFromDfoToReserveAutoID, false);

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

        //Bind_TigerReserveList();
    
    bool ChkTokenHasVerified(string tokenid)
    {
        bool chk = false;
        try
        {
            P_var.dSet = null;

            _TigerReserveOB.TokenId_FirstTimeInsertNoChange = tokenid;
            _TigerReserveOB.Action = 9;
            P_var.dSet = _tigerReserverBl.GetDfoReserveProcessDal(_TigerReserveOB);
            if (P_var.dSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < P_var.dSet.Tables[0].Rows.Count; i++)
                {
                    string status = P_var.dSet.Tables[0].Rows[i]["StatusIDDefault"].ToString();
                    if (status == "2" || status == "3" || status == "4")
                    {
                        VerifedAmount = P_var.dSet.Tables[0].Rows[0]["FromAmount_FirstTimeInsertNoChange"].ToString();
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
    protected void GrdDfoReserve_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdDfoReserve_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowState != DataControlRowState.Edit) // check for RowState
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //check for RowType
            {//BtnReply
                
                Button cBtnReply = (Button)e.Row.Cells[11].FindControl("BtnReply");
                Label lblLblTokenID = (Label)e.Row.Cells[1].FindControl("LblTokenID");

                Button BtnBtnDelete = (Button)e.Row.Cells[11].FindControl("BtnDelete"); //access the LinkButton from the TemplateField using FindControl method
                Label lblStatus = (Label)e.Row.Cells[2].FindControl("LblStatus");
                HiddenField HydStatus = (HiddenField)e.Row.Cells[2].FindControl("HydStatus");
                Label LblActionBy = (Label)e.Row.Cells[9].FindControl("lblActionBy");
                Button BtnEditLegalFormForm1 = (Button)e.Row.Cells[11].FindControl("BtnEditLegalFormForm1");
                if (HydStatus.Value == "2" || HydStatus.Value == "3" || HydStatus.Value == "4")
                {
                    BtnEditLegalFormForm1.Text = "View Legal form/Form1 (Your status have Approved or Verified or Rejected you can't edit legal form only view)";
                    
                }
                if(LblActionBy.Text=="admin")
                {
                    LblActionBy.Text = "Self";
                }
                
            }
        }
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
        _TigerReserveOB.StatusIDDefault =Convert.ToInt32(ddval);
        _TigerReserveOB.Action = 2;
        _TigerReserveOB.FromPersonID =Convert.ToInt32(Session["User_Id"]);
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
    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["FromAmount_FirstTimeInsertNoChange"]);
            InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["AcceptedAmount"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        GrdDfoReserve.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        GrdDfoReserve.FooterRow.Cells[0].Font.Bold = true;
        GrdDfoReserve.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        GrdDfoReserve.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        GrdDfoReserve.FooterRow.Cells[4].Text = Total + AllottedAmountRs.ToString();
        GrdDfoReserve.FooterRow.Cells[4].Font.Bold = true;
        GrdDfoReserve.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        GrdDfoReserve.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        GrdDfoReserve.FooterRow.Cells[5].Text = Total + InstallmentAmountRs.ToString();
        GrdDfoReserve.FooterRow.Cells[5].Font.Bold = true;
        GrdDfoReserve.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        GrdDfoReserve.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
}
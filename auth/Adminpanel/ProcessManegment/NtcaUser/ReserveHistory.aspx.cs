using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_ProcessManegment_ReserveUser_ReserveHistory : System.Web.UI.Page
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
        P_var.dSet = null;
        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = Request.QueryString["tokenID"].ToString();
        _TigerReserveOB.Action = 14;
        P_var.dSet = _tigerReserverBl.GetNtcaStatehistoryProcessDal(_TigerReserveOB);
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
    protected void GrdDfoReserve_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        
    }
  
    protected void GrdDfoReserve_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdDfoReserve_RowDataBound(object sender, GridViewRowEventArgs e)
    {

       
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LblMsg.Text = "";

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

        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = Request.QueryString["tokenID"].ToString();
      //  _TigerReserveOB.TokenIdSearch = TxtTokenId.Text;
        _TigerReserveOB.StatusIDDefault =Convert.ToInt32(ddval);
        _TigerReserveOB.Action = 14;
       // _TigerReserveOB.ToPersonID =Convert.ToInt32(Session["User_Id"]);
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
        Response.Redirect("~/Auth/AdminPanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx");
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
        GrdDfoReserve.FooterRow.Cells[0].Text = "";
        GrdDfoReserve.FooterRow.Cells[0].Font.Bold = true;
        GrdDfoReserve.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        GrdDfoReserve.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        GrdDfoReserve.FooterRow.Cells[4].Text = "";
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
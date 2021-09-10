using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_ProcessManegment_ReserveUser_StateToNtcaHistory : System.Web.UI.Page
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
        _TigerReserveOB.TokenId_FirstTimeInsertNoChange = Request.QueryString["tokenID"].ToString();
        _TigerReserveOB.Action = 14;
        P_var.dSet = _tigerReserverBl.GetStateNtcaHistoryDal(_TigerReserveOB);
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
        Response.Redirect("~/Auth/AdminPanel/ProcessManegment/ReserveUser/ConversationBetweenStateNtca.aspx");
    }
}
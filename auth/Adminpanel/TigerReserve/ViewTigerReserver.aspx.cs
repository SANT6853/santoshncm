using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_TigerReserve_ViewTigerReserver :CrsfBase
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
            Bind_state();
            Bind_TigerReserveList();
        }
    }
    void Bind_state()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        _objNtcauser.UserID = Convert.ToInt32(LoginUserid);
        P_var.dSet = _commanfuction.StateListByUserAccess(_objNtcauser);
        ddlstate.DataSource = P_var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
        }
        
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveList();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

    }

    void Bind_TigerReserveList()
    {
        _TigerReserveOB.StateID = ddlstate.SelectedValue == "0" ? null : (int?)Convert.ToInt32(ddlstate.SelectedValue);
        _TigerReserveOB.Status = 1;
        P_var.dSet= _tigerReserverBl.Get_TigerReservationList(_TigerReserveOB);

        grdtiger.DataSource = P_var.dSet;
        grdtiger.DataBind();
    }
    protected void grdtiger_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtiger.PageIndex = e.NewPageIndex;
        Bind_TigerReserveList();
    }
    protected void grdtiger_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdtiger_RowDataBound(object sender, GridViewRowEventArgs e)
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

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            LinkButton lnkAd = (LinkButton)e.Row.FindControl("LnkActiveDeaActive");
                            if (lnkAd.Text.Trim() == "1")
                            {

                                lnkAd.Text = "Active";
                            }
                            else
                            {

                                lnkAd.Text = "Deactivate";
                            }


                            string username = e.Row.Cells[0].Text;
                            string ActiveD = string.Empty;
                            if (lnkAd.Text == "Active")
                            {
                                ActiveD = "Deactivate";
                            }
                            if (lnkAd.Text == "Deactivate")
                            {
                                ActiveD = "Active";
                            }
                            lnkAd.OnClientClick = "return confirm('Are you sure want " + ActiveD + " " + username + " ');";
                        }
                    }
                }

            }//}
        }
        catch
        {
            throw;
        }
        // }
    }
    
    
    protected void grdtiger_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        int TigerReserveID = Convert.ToInt32(e.CommandArgument);
                        if (e.CommandName == "AD")
                        {
                            objntcauser.TigerReserveid = TigerReserveID;
                            int recordcount = _Userbl.UpdateActiveDeaActiveTigerReserve(objntcauser);
                        }
                        Bind_TigerReserveList();
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
}
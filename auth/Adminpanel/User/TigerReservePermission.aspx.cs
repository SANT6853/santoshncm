using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_User_TigerReservePermission : CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    public static bool LstLeftSide = false;
    public static bool LstRightSide = false;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    UserBL _userbl = new UserBL();
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
        if (!IsPostBack)
        {
            Bind_state();
            Bind_TigerReserve();
            Bind_TigerReserveUserAccess();
        }

    }
    void Bind_state()
    {

        _objNtcauser.UserID = Convert.ToInt32(Request.QueryString["uid"].ToString());
        P_var.dSet = _commanfuction.StateListByUserAccess(_objNtcauser);
        ddlstate.DataSource = P_var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();


    }
    void Bind_TigerReserve()
    {
        P_var.dSet = null;
        P_var.dSet = _tigerReserverBl.GetTigerReserverByState(1, Convert.ToInt32(Request.QueryString["uid"].ToString()));
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            lstMsttiger.DataSource = P_var.dSet;
            lstMsttiger.DataTextField = "TigerReserveName";
            lstMsttiger.DataValueField = "TigerReserveid";
            lstMsttiger.DataBind();
            LstLeftSide = true;
        }
        else
        {
            //lstMsttiger.Enabled = false;
            lstMsttiger.Items.Insert(0, new ListItem("No record found", "0"));
            LstLeftSide = false;
        }
    }
    void Bind_TigerReserveUserAccess()
    {
        P_var.dSet = null;

        P_var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(Request.QueryString["uid"].ToString()));
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlselected.DataSource = P_var.dSet;
            ddlselected.DataTextField = "TigerReserveName";
            ddlselected.DataValueField = "TigerReserveid";
            ddlselected.DataBind();
            LstRightSide = true;
        }
        else
        {
            LstRightSide = false;
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
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
                        //Response.Write("<script>alert('Please add Tiger Resever!!');</script>");
                        if (LstLeftSide == false && LstRightSide == false)
                        {
                            Response.Write("<script>alert('Please add Tiger Resever!!');</script>");
                        }
                        else
                        {

                            string str = hydselectedTigerReserve.Value;
                            if (!string.IsNullOrEmpty(str))
                            {
                                if (LstRightSide == false)
                                {
                                    _userbl.Update_User_TigerReserve_Permission(str, Convert.ToInt32(Request.QueryString["uid"].ToString()));

                                    Session["msg"] = "User Tiger Reserve Access has been Updated successfully.";

                                    Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                if (LstRightSide == true)
                                {
                                    _userbl.Update_User_TigerReserve_Permission(str, Convert.ToInt32(Request.QueryString["uid"].ToString()));

                                    Session["msg"] = "User Tiger Reserve Access has been Updated successfully.";

                                    Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }

                            }
                            else
                            {
                                if (LstRightSide == true)
                                {
                                    _userbl.Update_User_TigerReserve_Permission(str, Convert.ToInt32(Request.QueryString["uid"].ToString()));

                                    Session["msg"] = "User Tiger Reserve Access has been Updated successfully.";

                                    Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please add/remove Tiger Resever!!');</script>");
                                }
                            }

                        }

                        //string[] arr = str.Split(',');
                        //int arrcount = arr.Length;
                        //if (arrcount == 2)
                        //{
                        //    _userbl.Update_User_TigerReserve_Permission(str, Convert.ToInt32(Request.QueryString["uid"].ToString()));

                        //    Session["msg"] = "User Tiger Reserve Access has been Updated successfully.";

                        //    Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                        //    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        //}
                        //else
                        //{
                        //    Session["msg"] = "Sorry multiple tiger reserve not allow!.Please select single tiger reserver for every single tiger reserve users.";

                        //    Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                        //    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        //}
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
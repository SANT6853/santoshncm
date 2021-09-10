using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_User_DpPermision :  CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    UserBL _userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;
        if (!IsPostBack)
        {
            LtrUserName.Text = Request.QueryString["UserName"].ToString();
            GetTigerReserveOfTigerReserveUsers();
            GetDataOperatorPermisson();
        }
    }
    void GetTigerReserveOfTigerReserveUsers()
    {

        _objNtcauser.UserID = Convert.ToInt32(Session["User_Id"]);
        P_var.dSet = _commanfuction.GetTigerReserveOfTigerReserveUsers(_objNtcauser);
        Rdb.DataSource = P_var.dSet;
        Rdb.DataTextField = "TigerReserveName";
        Rdb.DataValueField = "TigerReserveid";
        Rdb.DataBind();


    }
    void GetDataOperatorPermisson()
    {
        Pvar.dSet = null;
        objntcauser.ParentTigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
        objntcauser.DataOperatorUserID = Convert.ToInt32(Request.QueryString["uid"]); 
        objntcauser.Action =2;
        Pvar.dSet = _commanfucation.GetDataOperatorPermisson(objntcauser);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
            //  Rdb.SelectedValue = Pvar.dSet.Tables[0].Rows[0]["TigerReserveID"].ToString();
            Rdb.Visible = false;
            LtrTigerReserver.Text = Pvar.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
            btnsubmit.Visible = false;
        }
        else
        {
            LtrTigerReserver.Text = "N/A";
        }
       
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
        //{

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

                        int i = _userbl.DataOperatorPermission(Convert.ToInt32(Session["User_Id"]), Convert.ToInt32(Request.QueryString["uid"]), Convert.ToInt32(Rdb.SelectedValue), 1);
                        if (i > 0)
                        {

                            Session["msg"] = "User data operator Access has been Updated successfully.";
                            //auth/adminpanel/User/View_Users.aspx?Moduleid=1
                            Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        }
                    }

                }


            }
        }
         catch
        {
            throw;
        }
        //  }
    }
}             


    

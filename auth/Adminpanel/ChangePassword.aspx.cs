using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_ChangePassword : System.Web.UI.Page
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    string LoginUserid;
    int LoginUsertype;
    static string StaticOldPassword = string.Empty;
    static string StaticNewPassword = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;
        if (!IsPostBack)
        {
            BindProfile();
        }
    }
   public string  BindProfile()
    {
        string pwd = string.Empty;
        Pvar.dSet = null;
        objntcauser.UserID = Convert.ToInt32(Session["User_Id"]);
        objntcauser.Action = 1;
        Pvar.dSet = _commanfucation.BindProfile(objntcauser);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
        pwd = Pvar.dSet.Tables[0].Rows[0]["Password"].ToString();
            
        }
        return pwd;
    }
    void Reset()
   {
       OldPassword.Text = string.Empty;
       NewPassword.Text = string.Empty;
       ConfirmPassword.Text = string.Empty;
   }
    protected void update_Click(object sender, EventArgs e)
    {
        if ((Page.IsValid))
        {
            string Password = BindProfile();
            if (!string.IsNullOrEmpty(Password))
            {
                StaticOldPassword = GetLast(Password, 3);
                StaticNewPassword = GetLast(NewPassword.Text.Trim(), 3);
                if (StaticOldPassword != StaticNewPassword)
                {
                    if (OldPassword.Text.Trim() == Password)
                    {

                        objntcauser.UserID = Convert.ToInt32(Session["User_Id"]);
                        objntcauser.Password = NewPassword.Text.Trim();
                        objntcauser.Action = 3;
                        int recordcount = _Userbl.ChangePassword(objntcauser);
                        if (recordcount > 0)
                        {

                            Session["msg"] = "Password Changed successfully.";
                            Session["BackUrl"] = "~/Auth/AdminPanel/ChangePassword.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        }


                    }
                    else
                    {
                      //  Session["msg"] = "Please Enter Your Correct Old Password.";
                      //  Session["BackUrl"] = "~/Auth/AdminPanel/ChangePassword.aspx";
                       // Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        lblmsg.Text = string.Empty;
                        lblmsg.Text = "Please enter correct old password!.";
                    }
                }
                else
                {
                    lblmsg.Text = string.Empty;
                    lblmsg.Text = "Sorry,Don't use last used three password!";
                   // Response.Write("<script>alert('Sorry,Don't use last three character of old password with new password!!');</script>");
                }
            }//end password empty check
        }
    }
    public string GetLast(string source, int tail_length)
    {
        if (tail_length >= source.Length)
            return source;
        return source.Substring(source.Length - tail_length);
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
}
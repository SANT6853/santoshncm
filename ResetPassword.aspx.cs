using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Auth_Adminpanel_ResetPassword : System.Web.UI.Page
{
    #region variable declration

    UserEntity entity = new UserEntity();
    UserBL obj = new UserBL();
    DataSet dSet = new DataSet();
    int Result;
    string randomid;
    int lenth = -1;
    int Uid = -1;

    #endregion
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            if (Request.QueryString["uid"] == null)
            {
                Response.Redirect("~/Auth/AdminPanel/login.aspx");
            }
            randomid = Convert.ToString(Request.QueryString["uid"]);
            lenth = randomid.Length;
            Uid = Convert.ToInt32(randomid.Substring(4, lenth - 8));
            CheckLink(Uid, randomid);
            Response.CacheControl = "no-cache";
            Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            
                randomid = Convert.ToString(Request.QueryString["uid"]);
                lenth = randomid.Length;
                Uid = Convert.ToInt32(randomid.Substring(4, lenth - 8));
                CheckLink(Uid, randomid);//procedure


                entity.PASSWORD = txtNewPass.Text;
                entity.LOG_ID = Uid;
                bool val = obj.Proc_Update_User_Password(entity);//procedure
                if (val == true)
                {
                    SendTime(Uid, randomid);
                    Session["ResetMSG"] = "PWDCHANGED";
                    // Response.Redirect("Notification.aspx");
                    Session["msg"] = "Your password has been changed successfully.";
                    Session["BackUrl"] = "~/Auth/AdminPanel/Login.aspx";

                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx", false);
                }
                else
                {
                    // txtCaptcha.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Password already used Please choose another password');", true);
                }

            }
          
          
        

        catch (Exception)
        {

        }

    }



    protected void CheckLink(int id, string rand1)
    {
        try
        {
            entity.LOG_ID = id;
            entity.RANDOMID = rand1;
            entity.USER_TYPE = "Admin";
            string check = "";
            obj.Proc_Check_Password(entity, ref check);//procedure
            if (check == "expired")
            {
                Session["ResetMSG"] = "TIMEOUT";
                //  Response.Redirect("Notification.aspx", false);
                //pnlwelcome.Visible = true;
                //pnlReset.Visible = false;
            }
            else if (check == "deactivated")
            {
                Session["msg"] = "User Is Deactivate Contact Super admin";
                //Response.Redirect("Notification.aspx", false);
                //pnlwelcome.Visible = true;
                //pnlReset.Visible = false;
            }
            else if (check == "Timeout")
            {
                Session["msg"] = "TIMEOUT try After Some time";
                //pnlwelcome.Visible = true;
                //pnlReset.Visible = false;
                // Response.Redirect("Notification.aspx", false);
            }
            else
            {
                //pnlReset.Visible = true;
                //pnlwelcome.Visible = false;
            }
        }
        catch (Exception)
        {
            Session["msg"] = "DISTURBANCE OCCURED try After Some time ";
            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx", false);
        }

    }


    protected bool SendTime(int id, string rand1)
    {
        entity.LOG_ID = id;
        entity.RANDOMID = rand1;
        entity.USER_TYPE = "Admin";
        return obj.Proc_Update_Into_RESETPASSWORD(entity);

    }
    protected void ServerValidation(object source, ServerValidateEventArgs args)
    {
        if (txtNewPass.Text == txtConfirmPass.Text)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}
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
            this.Page.ClientScript.RegisterClientScriptInclude("SCRIPT1", ResolveUrl("~/Auth/Adminpanel/assets/js/sha512.js"));
            //Page.Header.DataBind();
            //if (Request.QueryString["uid"] == null)
            //{
            //    Response.Redirect("~/Auth/AdminPanel/login.aspx");
            //}
            //randomid = Convert.ToString(Request.QueryString["uid"]);
            //lenth = randomid.Length;
            //Uid = Convert.ToInt32(randomid.Substring(4, lenth - 8));
            //CheckLink(Uid, randomid);
            //Response.CacheControl = "no-cache";
            //Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetNoStore();
        }

       // DisableCache();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            
                randomid = Convert.ToString(Request.QueryString["uid"]);
                lenth = randomid.Length;
                Uid = Convert.ToInt32(randomid.Substring(4, lenth - 8));
                CheckLink(Uid, randomid);


                entity.PASSWORD = txtNewPass.Text;
                entity.LOG_ID = Uid;
              bool val = obj.Proc_Update_User_Password(entity);
             //   bool val = true;
                if (val == true)
                {
                    SendTime(Uid, randomid);
                    Session["ResetMSG"] = "PWDCHANGED";
                    // Response.Redirect("Notification.aspx");
                    Session["msg"] = "Your password has been changed successfully.";
                    Session["BackUrl"] = "~/Home.aspx";
                    Response.Redirect("~/Auth/AdminPanel/Confirm.aspx", false);
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
            obj.Proc_Check_Password(entity, ref check);
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


    private void DisableCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache); //Cache-Control : no-cache, Pragma : no-cache
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1)); //Expires : date time
        Response.Cache.SetNoStore(); //Cache-Control :  no-store
        Response.Cache.SetProxyMaxAge(new TimeSpan(0, 0, 0)); //Cache-Control: s-maxage=0
        Response.Cache.SetValidUntilExpires(false);
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);//Cache-Control:  must-revalidate
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {

    }
}
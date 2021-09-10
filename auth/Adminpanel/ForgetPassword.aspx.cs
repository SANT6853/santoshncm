using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_ForgetPassword : System.Web.UI.Page
{
    UserEntity entity = new UserEntity();
    UserBL obj = new UserBL();
    Random Rand = new Random();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            recaptcha.ValidateCaptcha(txtcaptcha.Text);
            if (recaptcha.UserValidated)
            {
                try
                {

                    if (txtUserName.Text != "")
                    {
                        entity.USERNAME = txtUserName.Text;

                        ds = obj.Proc_Select_USER_DETAIL_BY_Name(entity);//procedure call

                    }


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string userid = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["UserID"].ToString());
                        string emailid = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["EmailID"].ToString());
                        string password = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["Password"].ToString());
                        string ran = Rand.Next(1000, 9999).ToString() + userid + Rand.Next(1000, 9999).ToString();
                      //  string strMSG = "</br><b>To reset your password please follow the below given link :-</b><br><a href=" + System.Configuration.ConfigurationManager.AppSettings["SITE_ADMIN_URL"].ToString() + "ResetPassword.aspx?uid=" + ran + "><b>" + System.Configuration.ConfigurationManager.AppSettings["SITE_ADMIN_URL"].ToString() + "ConfirmEmail.aspx</b></a>";
                        string strMSG = "</br><b>To reset your password please follow the below given link :-</b><br><a href=" + System.Configuration.ConfigurationManager.AppSettings["SITE_ADMIN_URL"].ToString() + "ResetPassword.aspx?uid=" + ran + "><b>" + System.Configuration.ConfigurationManager.AppSettings["SITE_ADMIN_URL"].ToString() + "ResetPassword.aspx</b></a>";

                        try
                        {
                            if (SendTime(Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]), ran))
                            {
                                Miscelleneous_BL ObjMiscel_mail = new Miscelleneous_BL();
                                if (ObjMiscel_mail.SendEmail(emailid, "", "", "Forgot password", System.Configuration.ConfigurationManager.AppSettings["ADMINMAIL"].ToString(), strMSG))
                                {
                                    Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Thank you, Your reset password link has been sent on your email. check your mail to reset password');", true);

                                    txtUserName.Text = "";

                                }
                                else
                                {
                                   // lblmsg.Text = "Email id does not exist.";
                                    Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Email id does not exist.!');", true);
                                    txtUserName.Text = "";

                                    lblmsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                               // lblmsg.Text = "An error occured.";
                                lblmsg.ForeColor = System.Drawing.Color.Red;

                            }
                        }
                        catch (Exception exp)
                        {
                            txtcaptcha.Text = string.Empty;
                            Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('An error has been occured.Please configure your mail server!');", true);
                           // lblmsg.Text = "An error has been occured";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            txtUserName.Text = "";

                            //Response.Write(exp.Message);
                        }

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Please enter valid input');", true);
                        //lblmsg.Text = "Please Use correct UserId";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        txtUserName.Text = "";

                        return;
                    }


                }
                catch (Exception e2)
                {
                    txtcaptcha.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('An error has been occured.Please configure your mail server!');", true);
                   // lblmsg.Text = "An error has been occured.Please configure your mail server!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;

                }
            }
            else
            {


                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Please enter valid input');", true);

            }
        }
        txtcaptcha.Text = string.Empty;
    }
    protected bool SendTime(int id, string rand1)
    {
        entity.ActionType = 1;
        entity.LOG_ID = id;
        entity.RANDOMID = rand1;
        entity.USER_TYPE = "Admin";
        return obj.Proc_Insert_Into_RESETPASSWORD(entity);//procedure call


    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ftype"] != null)
        {
            if (Request.QueryString["Ftype"] == "MainSite")
            {
                //string BaseUrl = Session["Burl"].ToString();
                Response.Redirect("~/auth/adminpanel/Login.aspx");
               
            }
            else
            {
                string BaseUrl = Session["Burl"].ToString();
                Response.Redirect("~/index.aspx" + BaseUrl);
            }
        }
    }
}
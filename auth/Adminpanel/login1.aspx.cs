using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Data;

public partial class auth_Adminpanel_login1 : System.Web.UI.Page
{
    Random random = new Random();
    UserBL _UserBL = new UserBL();
    NtcaUserOB _ntcauser = new NtcaUserOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterClientScriptInclude("SCRIPT1", ResolveUrl("~/Auth/Adminpanel/assets/js/sha512.js"));
        if (!IsPostBack)
        {
           
            txtUserName.Focus();
            Session["salt"] = random.Next(59999, 199999).ToString();
            //Session["Cookie"] = random.Next(59999, 199999).ToString();
        }
    }
    public string GetMapKeyByStateID(int stateid)
    {
        string MapKEy=string.Empty;
        _ntcauser.StateID = stateid;
        string Mapkey = string.Empty;
        DataSet ds = new DataSet();
        ds = null;

        ds = _UserBL.GetMapKeyByStateID(_ntcauser);
        if (ds.Tables[0].Rows.Count > 0)
        {
            MapKEy= ds.Tables[0].Rows[0]["MapStatID"].ToString();
        }
        return MapKEy;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    { 
        
        LblMsg.InnerText = "";
        recaptcha.ValidateCaptcha(txtcaptcha.Text);
        if (recaptcha.UserValidated)
        {
            DataSet ds = new DataSet();

            if (Session["Username"] != null)
            {
                if (Session["Username"].ToString() != txtUserName.Text)
                {
                    Session.Abandon();
                    Response.Redirect("~/Auth/adminpanel/Login.aspx");
                }
            }

            if (Session["salt"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Auth/adminpanel/Login.aspx");
            }

            Session["msg"] = "";
            HttpCookie cookie = new HttpCookie("Temp");

            Session["Temp"] = random.Next(59999, 199999).ToString();
            cookie.Value = Session["Temp"].ToString();
            Response.Cookies.Add(cookie);


            _ntcauser.UserName = txtUserName.Text.Trim();

            ds = _UserBL.Asp_userLogin(_ntcauser);

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (Session["User_Id"] != null)
                {
                    if (Session["User_Id"].ToString() == ds.Tables[0].Rows[0]["UserID"].ToString())
                    {
                        Session.Abandon();


                    }

                }


                string password = ds.Tables[0].Rows[0]["Password"].ToString();
                string Tpass = hashcodegenerate.GetSHA512(ds.Tables[0].Rows[0]["Password"].ToString() + Session["salt"].ToString());

                bool status = Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"].ToString());
                string Upass = hfpwd.Value;

                if (status)
                {
                    if (Tpass == Upass)
                    {

                        Session["User_Id"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        Session["UserName"] = txtUserName.Text;
                        Session["PermissionState"] = ds.Tables[0].Rows[0]["PermissionState"].ToString();
                        Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                        if (Session["UserType"].ToString() != "1")
                        {
                            string MapKeyDistrict = GetMapKeyByStateID(Convert.ToInt32(Session["PermissionState"]));

                            if (!string.IsNullOrEmpty(MapKeyDistrict))
                            {

                                Session["sMapStatID"] = MapKeyDistrict.ToString();
                            }
                        }

                        //AuditOB AE = new AuditOB();
                        //AuditTrail objAudit = new AuditTrail();
                        //AE.UserName = _awardeduser.UserName;
                        //AE.Action = "Login";
                        //AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"]);
                        //AE.Attempt_success = true;
                        //objAudit.GetAuditTrailLogin(AE);

                        //  Form Authotication
                        CustomPrincipalSerializer objSerializer = new CustomPrincipalSerializer();
                        objSerializer.Id = Session["User_Id"].ToString();
                        objSerializer.UserName = txtUserName.Text;
                        objSerializer.IsAdmin = 1;//Convert.ToInt16(user.IsAdmin);
                        objSerializer.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());


                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        string userData = serializer.Serialize(objSerializer);
                        FormsAuthenticationTicket formAuthTicket = null;
                        formAuthTicket = new FormsAuthenticationTicket(1, objSerializer.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

                        string encformAuthTicket = FormsAuthentication.Encrypt(formAuthTicket);

                        HttpCookie formAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encformAuthTicket);
                        System.Web.HttpContext.Current.Response.Cookies.Add(formAuthCookie);

                        //start narend 31may2018
                        if (ds.Tables[0].Rows[0]["ActiveStatus"].ToString() != "0")
                        {
                            if (Session["UserType"].ToString() == "1")
                            {
                                Response.Redirect("DashBoardNTCA.aspx");
                                return;
                            }
                            else
                            {
                                Response.Redirect("DashBoard.aspx");
                                return;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/auth/adminpanel/UsersDeactive.aspx?Ftype=MainSite",false);
                            return;
                        }
                        //end narend 31may2018
                       

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username or Password.!!');</script>");
                        return;
                        // lblmsg.Text = "Invalid Username or Password.";
                        // lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                    return;
                    //  lblmsg.Text = "You are not validate user";
                    //  lblmsg.ForeColor = System.Drawing.Color.Red;
                }

            }

            else
            {
                // lblmsg.ForeColor = System.Drawing.Color.Red;
                txtUserName.Focus();
                txtUserName.Text = "";
                // lblmsg.Text = "Invalid Username or Password.";
                Response.Write("<script>alert('Invalid user name and password!!');</script>");
                return;
            }



        }
        else
        {
            Response.Write("<script>alert('You have entered wrong captcha!!');</script>");
            return;
            // LblMsg.InnerText = "";
        }
    }
}
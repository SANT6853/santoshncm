using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

public partial class Index : BasePage
{
    public static string url = string.Empty;
  
    Random random = new Random();
    UserBL _UserBL = new UserBL();
    NtcaUserOB _ntcauser = new NtcaUserOB();
    //below naren
    BannerManagementBL menuBL = new BannerManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB contentObject = new ContentOB();
    public static int GetReserveID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterClientScriptInclude("SCRIPT1", ResolveUrl("~/Auth/Adminpanel/assets/js/sha512.js"));
        if (!Page.IsPostBack)
        {//Request.QueryString["StateID"]!= null || Request.QueryString["StateID"]!= ""
            //string.IsNullOrEmpty(Request.QueryString["aspxerrorpath"])
            FillCapctha();
            Page.DataBind();
            Page.Title = "Home:NTCA";
            if (!string.IsNullOrWhiteSpace(Request.QueryString["StateID"]))
            {
               
                url = "?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString();
                Session["Burl"] = url.ToString();
                
                if (Request.QueryString["StateID"]!="0")
                {
                    GetSateNameMethod();
                    GetTigerReserverName();
                    GetDistrictNameByMapDistrictIDM();
                    getTigerReserveBannerDetails1();
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
               // Response.Redirect(ResolveUrl("~/index.aspx" + url));
            }

            //getReserveIDbyRname();
           
            // Response.Write(Request.QueryString["trname"].ToString());
           // DisplayTigerReserver();
            txtUserName.Focus();
            Session["salt"] = random.Next(59999, 199999).ToString();
            //Session["Cookie"] = random.Next(59999, 199999).ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["TigerreserveName"]))
            {
                Session["tigerreserveNameforLable"] = Request.QueryString["TigerreserveName"];
            }
            
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {//DdlUserType.SelectedValue == "1" ||
        if (DdlUserType.SelectedValue == "1" || DdlUserType.SelectedValue == "2" || DdlUserType.SelectedValue == "3")
        {
            //string.IsNullOrWhiteSpace
            if (Page.IsValid)
            {
                NtcaStateReserveLogin();
            }
        }
        else
        {
            if (Page.IsValid)
            {
                DfoLogin();
            }

        }
    }

    #region Function to display tiger reserve

    private void DisplayTigerReserver()
    {
        Project_Variables p_var = new Project_Variables();
        TigerReserveOB tigerObject = new TigerReserveOB();
        //Request.QueryString["Tid"] != null && Request.QueryString["Tid"] != ""
        if (!string.IsNullOrWhiteSpace(Request.QueryString["Tid"]))
        {
            tigerObject.TigerReserveid = Convert.ToInt16(Request.QueryString["Tid"]);
            Session["Tid"] = Convert.ToInt16(Request.QueryString["Tid"]);
        }
        else
        {
            tigerObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
            Session["Tid"] = Convert.ToInt16(Session["Tid"]);
        }
        Commanfuction cf = new Commanfuction();
        p_var.dSet = cf.getTigerReserveName(tigerObject);
        if (p_var.dSet.Tables[0].Rows.Count > 0)
        {
            ltrlTigerReserveName.Text = p_var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
        }
        if (p_var.dSet.Tables[1].Rows.Count > 0)
        {
            ltrlContent.Text = HttpUtility.HtmlDecode(p_var.dSet.Tables[1].Rows[0]["details"].ToString());
        }
    }

    #endregion

    public void getReserveIDbyRname()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["trname"]))
            {
                contentObject.TigerReserveName = Request.QueryString["trname"].ToString();
                p_var.dsFileName = menuBL.getTigerReserveIdByTname(contentObject);
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                    Session["sTigerReserveID"] = GetReserveID;
                }
            }
        }
        catch
        {
            //throw;
        }
    }
    public void GetTigerReserverName()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["TigerReserveid"]))
            {
                contentObject.TigerReserveID = Convert.ToInt32(Request.QueryString["TigerReserveid"]);
                p_var.dsFileName = menuBL.GetTigerReserveName(contentObject);
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                    Session["sTigerReserveID"] = GetReserveID;
                    Session["sTigerReserveName"] = p_var.dsFileName.Tables[0].Rows[0]["TigerReserveName"];
                }
            }
        }
        catch
        {
            //throw;
        }
    }
    public void GetSateNameMethod()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["StateID"]))
            {
                contentObject.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
                p_var.dsFileName = menuBL.GetStateName(contentObject);
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    //  GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                    Session["Sstatename"] = p_var.dsFileName.Tables[0].Rows[0]["StateName"];
                }
            }
        }
        catch
        {
            //throw;
        }
    }
    public void GetDistrictNameByMapDistrictIDM()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["MapDistricID"]))
            {
                contentObject.mapDistrictID = Convert.ToInt32(Request.QueryString["MapDistricID"]);
                p_var.dsFileName = menuBL.GetDistrictNameByMapDistrictID(contentObject);
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    //  GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                    Session["SMapDistrictName"] = p_var.dsFileName.Tables[0].Rows[0]["DistName"];
                }
            }
        }
        catch
        {
            //throw;
        }
    }
    public bool BoolCheckDataOperatorWithTigerReserve()
    {
        bool ret = false;
        try
        {
            if (!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
            {
                p_var.dsFileName = null;
                contentObject.DataOperatorUserID = Convert.ToInt32(Session["User_Id"]);
                contentObject.TigerReserveID = GetReserveID;
                contentObject.Action = 4;
                p_var.dsFileName = menuBL.CheckDataOperatorWithTigerReserve(contentObject);
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {

                    ret = true;
                }
            }
        }
        catch
        {
            throw;
        }
        return ret;
    }
    public void getTigerReserveBannerDetails1()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["StateID"]))
            {
                contentObject.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
                contentObject.TigerReserveid = GetReserveID;
                contentObject.ModuleID = 3;
                StringBuilder sb = new StringBuilder();
                p_var.dsFileName = menuBL.getTigerReserveBanner(contentObject);

                sb.Append("<div id=\"myCarousel\" class=\"carousel slide\" data-ride=\"carousel\">");//first div
                if (p_var.dsFileName.Tables[0].Rows.Count > 0)
                {
                    sb.Append("<ol class=\"carousel-indicators\">");
                    for (p_var.i = 0; p_var.i < p_var.dsFileName.Tables[0].Rows.Count; p_var.i++)
                    {
                        if (p_var.i == 0)
                        {
                            sb.Append("<li data-target=\"#myCarousel\" data-slide-to='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Link_Id"].ToString() + "' class=\"active\">");
                        }
                        else
                        {
                            sb.Append("<li data-target=\"#myCarousel\" data-slide-to='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Link_Id"].ToString() + "'>");
                        }

                        // p_var.sbuilder.Append("<img width=\"100%\" height=\"300px\"  alt='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");

                        sb.Append("</li>");
                    }
                    sb.Append("</ol>");
                }

                //start carousel-inner
                sb.Append("<div class=\"carousel-inner\">");
                for (p_var.i = 0; p_var.i < p_var.dsFileName.Tables[0].Rows.Count; p_var.i++)
                {
                    if (p_var.i == 0)
                    {
                        sb.Append("<div class=\"item active\"> ");
                        sb.Append("<img width=\"100%\" max-height=\"323px\"  alt='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
                        sb.Append("</div>");
                    }
                    else
                    {
                        sb.Append("<div class=\"item\">");
                        sb.Append("<img width=\"100%\" max-height=\"323px\"  alt='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
                        sb.Append("</div>");
                    }
                }
                sb.Append("</div>");
                //LtrBannerCarouserInner.Text = sb.ToString();
                //end carousel-inner

                //start previous
                sb.Append("<a class=\"left carousel-control\" href=\"#myCarousel\" data-slide=\"prev\">");
                sb.Append("<span class=\"glyphicon glyphicon-chevron-left\"></span>");
                sb.Append("<span class=\"sr-only\">Previous</span>");
                sb.Append("</a>");
                //  LtrPrevious.Text = sb.ToString();
                //end previous

                //start next
                sb.Append("<a class=\"right carousel-control\" href=\"#myCarousel\" data-slide=\"next\">");
                sb.Append("<span class=\"glyphicon glyphicon-chevron-right\"></span>");
                sb.Append("<span class=\"sr-only\">Next</span>");
                sb.Append("</a>");
                // LtrNext.Text = sb.ToString();
                //end next

                sb.Append("</div>");//end first div

                LtrBanner1.Text = sb.ToString();
            }
        }
        catch
        {
            throw;
        }
    }
    void NtcaStateReserveLogin()//1
    {
        #region collaps
        Session["sStateID"] = Request.QueryString["StateID"].ToString();
        Session["sMapStatID"] = Request.QueryString["MapStatID"].ToString();
        Session["sMapDistricID"] = Request.QueryString["MapDistricID"].ToString();
        Session["sTigerReserveid"] = Request.QueryString["TigerReserveid"].ToString();
        Session["sDataOperatorUserID"] = Request.QueryString["DataOperatorUserID"].ToString();

        if (DdlUserType.SelectedValue == "4")
        {
            Session["sTigerReserveName"] = Session["sTigerReserveName"].ToString();

            Session["sStateName"] = Session["Sstatename"].ToString();
        }
      //  LblMsg.InnerText = "";
       // recaptcha.ValidateCaptcha(txtcaptcha.Text);//(temporary captch code comment)

        if (Session["captcha"].ToString() == txtcaptcha.Text.Trim())
        {
        DataSet ds = new DataSet();
        //Session["Username"] != null
        if (!string.IsNullOrWhiteSpace(Session["Username"] as string))
        {
            if (Session["Username"].ToString() != txtUserName.Text)
            {
                Session.Abandon();
                //Response.Redirect("~/home.aspx");
              //  Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You have entered wrong captcha!');", true);
                Response.Redirect(ResolveUrl("~/index.aspx" + url));
                return;
            }
        }
        //Session["salt"] == null
        if (string.IsNullOrWhiteSpace(Session["salt"] as string))
        {
            Session.Abandon();
           // Response.Redirect("~/Home.aspx");
           // Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You have entered wrong captcha!');", true);
            Response.Redirect(ResolveUrl("~/index.aspx" + url));
            return;
        }

        Session["msg"] = "";
        HttpCookie cookie = new HttpCookie("Temp");

        Session["Temp"] = random.Next(59999, 199999).ToString();
        cookie.Value = Session["Temp"].ToString();
        Response.Cookies.Add(cookie);


        _ntcauser.UserName = txtUserName.Text.Trim();
        //
        _ntcauser.UserType =Convert.ToInt32(DdlUserType.SelectedValue);
        ds = _UserBL.Asp_userLogin(_ntcauser);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //Session["User_Id"] != null
            if (!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
            {
                if (Session["User_Id"].ToString() == ds.Tables[0].Rows[0]["UserID"].ToString())
                {
                    Session.Abandon();

                   // Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You have entered wrong captcha!');", true);
                    Response.Redirect(ResolveUrl("~/index.aspx" + url));
                    return;
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
                        {//~/auth/adminpanel/DashBoard.aspx
                            Session["User_Id"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                            Session["UserName"] = txtUserName.Text;
                            Session["PermissionState"] = ds.Tables[0].Rows[0]["PermissionState"].ToString();
                            Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                                // Response.Redirect("~/auth/adminpanel/DashBoard.aspx?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString() + "&TigerReserveName=" + Session["sTigerReserveName"].ToString() + "&StateName=" + Session["Sstatename"].ToString());
                                AuditOB AE = new AuditOB();
                                AuditTrail objAudit = new AuditTrail();
                                AE.UserName = txtUserName.Text;
                                AE.Action = "Login";
                                AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"]);
                                AE.Attempt_success = true;
                                objAudit.GetAuditTrailLogin(AE);
                                Response.Redirect("~/auth/adminpanel/DashBoardNTCA.aspx?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString());
                            return;
                        }
                        else
                        {
                            if (Request.QueryString["StateID"].ToString() == Session["PermissionState"].ToString())
                            {
                                Session["User_Id"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                                Session["UserName"] = txtUserName.Text;
                                Session["PermissionState"] = ds.Tables[0].Rows[0]["PermissionState"].ToString();
                                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                                    AuditOB AE = new AuditOB();
                                    AuditTrail objAudit = new AuditTrail();
                                    AE.UserName = txtUserName.Text;
                                    AE.Action = "Login";
                                    AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"]);
                                    AE.Attempt_success = true;
                                    objAudit.GetAuditTrailLogin(AE);
                                    Response.Redirect("~/auth/adminpanel/DashBoard.aspx?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString());

                                return;
                            }
                            else
                            {
                              //  Response.Write("<script>alert('Sorry you have not authorize to login this panel.!');</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sorry you have not authorize to login this panel!');", true);
                                return;
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/auth/adminpanel/UsersDeactive.aspx?Ftype=MainSite", false);
                       // return;
                    }
                    //end narend 31may2018


                }
                else
                {
                    //Response.Write("<script>alert('Invalid Username or Password.!!');</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Username or Password!');", true);
                    return;
                    // lblmsg.Text = "Invalid Username or Password.";
                    // lblmsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
               // Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter captcha code is incorrect!');", true);
                    FillCapctha();
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
           // Response.Write("<script>alert('Invalid user name and password!!');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid user name and password!');", true);
           
            return;
        }
        }
        else
        {
           
           // Response.Write("<script>alert('You have entered wrong captcha!!');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You have entered wrong captcha!');", true);
            FillCapctha();
           // string message = "You have entered wrong captcha!";
           //// ScriptManager.RegisterClientScriptBlock(this.Page, typeof(UpdatePanel), "MyMessage", message, true);

            // //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", message.ToString(), true);
            return;

        }
        #endregion
    }
    void DfoLogin()//4
    {
        #region collapse
        GetSateNameMethod();
        GetTigerReserverName();
        GetDistrictNameByMapDistrictIDM();

      //  recaptcha.ValidateCaptcha(txtcaptcha.Text);
        if (Session["captcha"].ToString() == txtcaptcha.Text.Trim())
        {
            DataSet ds = new DataSet();
            //Session["Username"] != null
            if (!string.IsNullOrWhiteSpace(Session["Username"] as string))
            {
                if (Session["Username"].ToString() != txtUserName.Text)
                {
                    Session.Abandon();
                   // Response.Redirect("~/Home.aspx");
                   // Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter captcha code is incorrect!');", true);
                    Response.Redirect(ResolveUrl("~/index.aspx" + url));
                    return;
                }
            }
            //Session["salt"] == null
            if (string.IsNullOrWhiteSpace(Session["salt"] as string))
            {
                Session.Abandon();
                //Response.Redirect("~/Home.aspx");
              //  Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter captcha code is incorrect!');", true);
                Response.Redirect(ResolveUrl("~/index.aspx" + url));
                return;

            }

            Session["msg"] = "";
            HttpCookie cookie = new HttpCookie("Temp");

            Session["Temp"] = random.Next(59999, 199999).ToString();
            cookie.Value = Session["Temp"].ToString();
            Response.Cookies.Add(cookie);


            _ntcauser.UserName = txtUserName.Text.Trim();
            _ntcauser.UserType = Convert.ToInt32(DdlUserType.SelectedValue);
            ds = _UserBL.Asp_forntuserLogin(_ntcauser);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //Session["User_Id"] != null
                if (!string.IsNullOrWhiteSpace(Session["User_Id"] as string))
                {
                    if (Session["User_Id"].ToString() == ds.Tables[0].Rows[0]["UserID"].ToString())
                    {
                        Session.Abandon();
                       // Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter captcha code is incorrect!');", true);
                        Response.Redirect(ResolveUrl("~/index.aspx" + url));
                        return;

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

                        // Response.Redirect("~/auth/adminpanel/DashBoard.aspx");
                        Session["sStateID"] = Request.QueryString["StateID"].ToString();
                        Session["sMapStatID"] = Request.QueryString["MapStatID"].ToString();
                        Session["sMapDistricID"] = Request.QueryString["MapDistricID"].ToString();
                        Session["sTigerReserveid"] = Request.QueryString["TigerReserveid"].ToString();
                        Session["sDataOperatorUserID"] = Request.QueryString["DataOperatorUserID"].ToString();
                        Session["sTigerReserveName"] = Session["sTigerReserveName"].ToString();
                        Session["sStateName"] = Session["Sstatename"].ToString();


                        bool checkExist = BoolCheckDataOperatorWithTigerReserve();

                        //start narend 31may2018
                        if (ds.Tables[0].Rows[0]["ActiveStatus"].ToString() != "0")
                        {
                            if (checkExist == false)
                            {
                                Response.Redirect("~/LoginFailed.aspx");
                                return;
                            }
                            else
                            {
                                AuditOB AE = new AuditOB();
                                AuditTrail objAudit = new AuditTrail();
                                AE.UserName = txtUserName.Text; 
                                AE.Action = "Login";
                                AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"]);
                                AE.Attempt_success = true;
                                objAudit.GetAuditTrailLogin(AE);
                                //Response.Redirect("~/auth/adminpanel/DashBoard.aspx?trname=" + Request.QueryString["trname"] + "&stateIDq=" + Request.QueryString["stateIDq"] + "&statename=" + Request.QueryString["statename"] + "&HcKey=" + Request.QueryString["hckey"] + "&TreserveID=" + Session["sTigerReserveID"].ToString());
                                Response.Redirect("~/auth/adminpanel/DashBoard.aspx?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString() + "&TigerReserveName=" + Session["sTigerReserveName"].ToString() + "&StateName=" + Session["Sstatename"].ToString());
                                return;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/auth/adminpanel/UsersDeactive.aspx?Ftype=MainSite11", false);
                            return;
                        }
                        //end narend 31may2018



                    }
                    else
                    {
                       // Response.Write("<script>alert('Invalid Username or Password.!!');</script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Username or Password!');", true);
                        return;
                        // lblmsg.Text = "Invalid Username or Password.";
                        // lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                  //  Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter captcha code is incorrect!');", true);
                    FillCapctha();
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
               // Response.Write("<script>alert('Invalid user name and password!!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid user name and password!');", true);
                return;
            }



        }
        else
        {
           
          //  Response.Write("<script>alert('You have entered wrong captcha!!');</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You have entered wrong captcha!');", true);
            FillCapctha();
            return;

        }
        #endregion
    }
    public string GetMapKeyByStateID(int stateid)
    {
        string MapKEy = string.Empty;
        _ntcauser.StateID = stateid;
        string Mapkey = string.Empty;
        DataSet ds = new DataSet();
        ds = null;

        ds = _UserBL.GetMapKeyByStateID(_ntcauser);
        if (ds.Tables[0].Rows.Count > 0)
        {
            MapKEy = ds.Tables[0].Rows[0]["MapStatID"].ToString();
        }
        return MapKEy;
    }

    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }

    public void FillCapctha()
    {
        try
        {

            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 5; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
			 Regex r = new Regex(@"(?:[0-9][^ ]*[A-Za-z][^ ]*)|(?:[A-Za-z][^ ]*[0-9][^ ]*)");
            if (!r.IsMatch(captcha.ToString()))
            {
                FillCapctha();
            }
            else
            {
                Session["captcha"] = captcha.ToString();
                imgCaptcha.ImageUrl = ResolveUrl("~/GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString());

            }
			}
        catch
        {
            throw;
        }
    }
	protected override void PageMetaTags()
    {

        MetaTitle = "Home: National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Page_Title"].ToString();
        MetaKeywords = "NTCA";//p_var.dSet.Tables[0].Rows[0]["Meta_Keywords"].ToString();
        MetaDescription = "National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Mate_Description"].ToString();
        MetaLang = "en";
    }
}
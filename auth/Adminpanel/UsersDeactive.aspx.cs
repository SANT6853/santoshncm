using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_UsersDeactive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Ftype"] != null)
        {
            if (Request.QueryString["Ftype"] == "MainSite")
            {
               // Response.Redirect("~/Auth/Adminpanel/Login.aspx");
                //http://localhost:2429/index.aspx?StateID=5&MapStatID=in-br&MapDistricID=68&TigerReserveid=9&DataOperatorUserID=1024
                string BaseUrl = Session["Burl"].ToString();
                Response.Redirect("~/index.aspx" + BaseUrl);
            }
            else
            {
                string BaseUrl = Session["Burl"].ToString();
                Response.Redirect("~/index.aspx" + BaseUrl);
            }
        }
    }
}
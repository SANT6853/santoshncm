using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Logout : System.Web.UI.Page
{
    public static string url = string.Empty;
    protected void Page_Init(object sender, System.EventArgs e)
    {
        Page.ViewStateUserKey = Session.SessionID;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Session["sStateID"] as string))
        {
            if (Session["1ntca_StateID"] != "0")
            {
                //url = "?trname=" + Session["Strname"].ToString() + "&stateIDq=" + Session["SstateIDq"].ToString() + "&statename=" + Session["Sstatename"].ToString() + "&hckey=" + Session["SHcKey"].ToString();
                // url = "?StateID=" + Session["sStateID"].ToString() + "&MapStatID=" + Session["sMapStatID"].ToString() + "&MapDistricID=" + Session["sMapDistricID"].ToString() + "&TigerReserveid=" + Session["sTigerReserveid"].ToString() + "&DataOperatorUserID=" + Session["sDataOperatorUserID"].ToString();
                url = "?StateID=" + Session["1ntca_StateID"].ToString() + "&MapStatID=" + Session["1ntca_MapStatID"].ToString() + "&MapDistricID=" + Session["1ntca_MapDistricID"].ToString() + "&TigerReserveid=" + Session["1ntca_TigerReserveid"].ToString() + "&DataOperatorUserID=" + Session["1ntca_DataOperatorUserID"].ToString() + "&TigerreserveName=" + Session["tigerreserveNameforLable"].ToString();
                FormsAuthentication.SignOut();
                Session.Abandon();

                Session.RemoveAll();
                Session.Clear();
                Response.CacheControl = "no-cache";
                Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                // clear session cookie
                HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
                cookie2.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie2);
                Response.Redirect(ResolveUrl("~/index.aspx" + url));
            }
            else
            {
                url = "?StateID=" + Session["1ntca_StateID"].ToString() + "&MapStatID=" + Session["1ntca_MapStatID"].ToString() + "&MapDistricID=" + Session["1ntca_MapDistricID"].ToString() + "&TigerReserveid=" + Session["1ntca_TigerReserveid"].ToString() + "&DataOperatorUserID=" + Session["1ntca_DataOperatorUserID"].ToString();
                FormsAuthentication.SignOut();
                Session.Abandon();

                Session.RemoveAll();
                Session.Clear();
                Response.CacheControl = "no-cache";
                Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                // clear session cookie
                HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
                cookie2.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie2);
                Response.Redirect(ResolveUrl("~/IndiaMapHighChart.aspx"));
            }
        }
        else
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"));
        }
    }
}
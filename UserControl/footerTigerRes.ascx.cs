using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserControl_footerTigerRes : System.Web.UI.UserControl
{
    #region Data declaration zone

    Content_ManagementBL footerMenuBL = new Content_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB lnkObject = new ContentOB();
    // BreadcrumDL brdl = new BreadcrumDL();
    #endregion
    public int Websiteid { get; set; }
    #region page load event zone
    static string strlatestdate;
    //naren
    BannerManagementBL menuBL1 = new BannerManagementBL();
    public static int GetReserveID = 0;
    public static string url = string.Empty;
    ContentOB contentObject = new ContentOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        // GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
        if (Request.QueryString["MapStatID"] != "0")
        {
            GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
        }
        else
        {
            GetReserveID = 0;
        }
        if (!IsPostBack)
        {
            //GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
            if (Request.QueryString["MapStatID"] != "0")
            {
                GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
            }
            else
            {
                GetReserveID = 0;
            }
            if (Request.QueryString["StateID"] != string.Empty && Request.QueryString["StateID"] != null)
            {

                // getReserveIDbyRname();
                // url = "?trname=" + Request.QueryString["trname"].ToString() + "&stateIDq=" + Request.QueryString["stateIDq"].ToString() + "&statename=" + Request.QueryString["statename"].ToString() + "&hckey=" + Request.QueryString["HcKey"].ToString();
                // url = "?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString() + "&TigerReserveName=" + Session["sTigerReserveName"].ToString() + "&StateName=" + Session["Sstatename"].ToString();
                url = "?StateID=" + Request.QueryString["StateID"].ToString() + "&MapStatID=" + Request.QueryString["MapStatID"].ToString() + "&MapDistricID=" + Request.QueryString["MapDistricID"].ToString() + "&TigerReserveid=" + Request.QueryString["TigerReserveid"].ToString() + "&DataOperatorUserID=" + Request.QueryString["DataOperatorUserID"].ToString();
            }
            BindFooterMenu();

        }

    }

    #endregion
    public void getReserveIDbyRname()
    {
        try
        {
            contentObject.TigerReserveName = Request.QueryString["trname"].ToString();
            p_var.dsFileName = menuBL1.getTigerReserveIdByTname(contentObject);
            if (p_var.dsFileName.Tables[0].Rows.Count > 0)
            {
                GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                Session["sTigerReserveID"] = GetReserveID;
            }
        }
        catch
        {
            throw;
        }
    }
    #region Function to get Main Root menu

    public void BindFooterMenu()
    {
        try
        {
            p_var.sbuilder.Remove(0, p_var.sbuilder.Length);
            lnkObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
            lnkObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
            p_var.position = (int)lnkObject.PositionID;
            lnkObject.ModuleID = (int)Module_ID_Enum.Project_Module_ID.cms;
            lnkObject.LinkParentID = (int)Module_ID_Enum.Link_parentID_Footer.parent_Footer;
            lnkObject.StateID = 1;
            if (GetReserveID == 0)
            {
                lnkObject.TigerReserveid = 0;
            }
            else
            {
                lnkObject.TigerReserveid = GetReserveID;
            }
            //lnkObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
            lnkObject.Websiteid = Websiteid;

            p_var.dSet = footerMenuBL.getFrontRootMenu(lnkObject);

            p_var.sbuilder.Append("<li>");
            if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
            {
                if (GetReserveID == 0)
                {
                    if (Request.QueryString["MapStatID"] != "0")
                    {
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");
                        //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "feedback.aspx'> Feedback </a>");
                    }
                    else
                    {
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "index.aspx" + url + "'> Home </a>");
                        //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "FeedBackTigerReserve.aspx" + url + "'> Feedback </a>");
                    }
                }
                else
                {
                    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "index.aspx" + url + "'> Home </a>");
                    //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "FeedBackTigerReserve.aspx'> Feedback </a>");
                   // p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "FeedBackTigerReserve.aspx" + url + "'> Feedback </a>");
                }

            }
            for (int i = 0; i < p_var.dSet.Tables[0].Rows.Count; i++)
            {
                p_var.menu_name = HttpUtility.HtmlDecode(p_var.dSet.Tables[0].Rows[i]["name"].ToString());
                p_var.menuid = Convert.ToInt16(p_var.dSet.Tables[0].Rows[i]["link_id"]);
                p_var.urlname = p_var.dSet.Tables[0].Rows[i]["UrlName"].ToString();

                if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                {

                    //Code to remove 
                    ContentOB _lnkSubmenuObject = new ContentOB();
                    DataSet ds = new DataSet();
                    _lnkSubmenuObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
                    _lnkSubmenuObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
                    _lnkSubmenuObject.LinkParentID = p_var.menuid;
                    ds = footerMenuBL.getSubmenuofRootMenu(_lnkSubmenuObject);

                    if (ds.Tables[0].Rows.Count > 0)
                    {



                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href=" + ResolveUrl("~/content/") + p_var.url + ds.Tables[0].Rows[0]["link_id"] + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + p_var.menu_name + "</a>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");

                    }

                }
                else
                {
                    //Code to remove 
                    ContentOB _lnkSubmenuObject = new ContentOB();
                    DataSet ds = new DataSet();
                    _lnkSubmenuObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
                    _lnkSubmenuObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
                    _lnkSubmenuObject.LinkParentID = p_var.menuid;
                    ds = footerMenuBL.getSubmenuofRootMenu(_lnkSubmenuObject);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href=" + ResolveUrl("~/content/") + p_var.url + ds.Tables[0].Rows[0]["link_id"] + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + p_var.menu_name + "</a>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + p_var.position + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");

                    }

                }

                p_var.sbuilder.Append("</li>");
            }

            ltrlFooter.Text = p_var.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }

    #endregion
}



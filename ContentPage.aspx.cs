using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContentPage :BasePage
{
    #region Data delcaration zone

    Content_ManagementBL menuBL = new Content_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB lnkObject = new ContentOB();
    public string headerName = string.Empty;
    public string ParentName = string.Empty;
    public static string UrlPrint = string.Empty;

    string RootParentName = string.Empty;
    string Childname = string.Empty;
    string strbreadcrum = string.Empty;
    string PositionID = HttpContext.Current.Request.QueryString["position"];
    string PageID = string.Empty; //HttpContext.Current.Request.QueryString["id"].ToString().Substring(6);
    string ParentID = string.Empty;
    string browserTitle = string.Empty;
    int RootID;

    string MetaKeyword = string.Empty;
    string MetaDescription = string.Empty;
    string MetaLng = string.Empty;
    string MetaTitles = string.Empty;
    string PageTitle = string.Empty;
    public string lastUpdatedDate = string.Empty;

   //below naren
    Content_ManagementBL footerMenuBL = new Content_ManagementBL();
//Project_Variables p_var = new Project_Variables();
    //ContentOB lnkObject = new ContentOB();
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
    #endregion
    public int WebsiteID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        p_var.position = Convert.ToInt16(RewriteModule.RewriteContext.Current.Params["position"]);  //Convert.ToInt32(Request.QueryString["position"].ToString());
        p_var.LanguageID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        // p_var.url = Resources.NTCAResources.PageUrl.ToString();
        p_var.url = p_var.LanguageID == 1 ? Resources.NTCAResources.PageUrl.ToString() : Resources.NTCAResources.PageUrlMain.ToString();
        p_var.PageID = RewriteModule.RewriteContext.Current.Params["menuid"].ToString(); //Request.QueryString["menuid"].ToString();
        if (p_var.PageID.Length > 4)
        {
            p_var.PageID = p_var.PageID.Substring(4);
        }

        if (!IsPostBack)
        {
            if (p_var.PageID != null)
            {
                bindMainContent();
               
            }
            if (Session["Strname"] != string.Empty && Session["Strname"] != null)
            {

                getReserveIDbyRname();
                url = "?trname=" + Session["Strname"].ToString() + "&stateIDq=" + Session["SstateIDq"].ToString() + "&statename=" + Session["Sstatename"].ToString() + "&hckey=" + Session["SHcKey"].ToString();
            }
            BindFooterMenu();
        }
    }

    public void getReserveIDbyRname()
    {
        try
        {
            contentObject.TigerReserveName = Session["Strname"].ToString();
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
            lnkObject.Websiteid = 2;

            p_var.dSet = footerMenuBL.getFrontRootMenu(lnkObject);
            p_var.sbuilder.Append("<div class=\"col-md-3\">");
           
            if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
            {
                
                if (GetReserveID == 0)
                {
                    //p_var.sbuilder.Append("<li>");
                    //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");
                    //p_var.sbuilder.Append("</li>");

                    //p_var.sbuilder.Append("<li>");
                    //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "feedback.aspx'> feedback </a>");
                    //p_var.sbuilder.Append("</li>");
                }
                else
                {
                    p_var.sbuilder.Append("<li>");
                    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "index.aspx" + url + "'> Home </a>");
                    p_var.sbuilder.Append("</li>");

                    p_var.sbuilder.Append("<li>");
                    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "FeedBackTigerReserve.aspx'> feedback </a>");
                    p_var.sbuilder.Append("</li>");
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

                        p_var.sbuilder.Append("<li>");

                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href=" + ResolveUrl("~/content/") + p_var.url + ds.Tables[0].Rows[0]["link_id"] + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + p_var.menu_name + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                        p_var.sbuilder.Append("</li>");
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
                        p_var.sbuilder.Append("</li>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + p_var.position + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                }

                
                
            }
            p_var.sbuilder.Append("</div>");
            LtrLeftMenu.Text = p_var.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }
    #region Function to bind Main Contents

    public void bindMainContent()
    {
        DataSet subMenuData = new DataSet();
        DataSet parent = new DataSet();
        ContentOB _lnkSubmenuObject = new ContentOB();

        //Variables to get child submenu

        ContentOB subSubMenuOB = new ContentOB();
        DataSet sub_dataSet = new DataSet();

        //end

        try
        {
            string spageid = p_var.PageID;
            
            if (spageid.Contains("ent/"))
            {
                spageid = spageid.Replace("ent/", "");
            }

            lnkObject.LinkID = Convert.ToInt16(spageid);
          //  lnkObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
            lnkObject.TigerReserveid = Convert.ToInt16(Session["sTigerReserveID"]);
            lnkObject.LangID = p_var.LanguageID;
            lnkObject.Websiteid = 2;
            p_var.dSet = menuBL.get_Cliked_Parent_Menu(lnkObject);
            p_var.parentID = p_var.dSet.Tables[0].Rows[0]["link_parent_id"].ToString();
            lnkObject.LinkParentID = Convert.ToInt16(p_var.parentID);
            p_var.position = Convert.ToInt16(p_var.dSet.Tables[0].Rows[0]["position_id"]);
            if (p_var.dSet.Tables[0].Rows.Count > 0)
            {
               // Page.Title = p_var.dSet.Tables[0].Rows[0]["name"].ToString() +":NTCA";

                ltrlastupdated.Text = "<span class='spanbold'> " + Resources.NTCAResources.LastUpdated + "</span>&nbsp;" + p_var.dSet.Tables[0].Rows[0]["Last_update"].ToString();
                headerName = p_var.dSet.Tables[0].Rows[0]["name"].ToString();

                ParentName = p_var.dSet.Tables[0].Rows[0]["parent"].ToString();
                browserTitle = p_var.dSet.Tables[0].Rows[0]["Browser_Title"].ToString();
               // ViewState["header"] = p_var.dSet.Tables[0].Rows[0]["placeholderone"].ToString();

               // ltrlMainContent.Text = HttpUtility.HtmlDecode(p_var.dSet.Tables[0].Rows[0]["details"].ToString());
                Page.Title = p_var.dSet.Tables[0].Rows[0]["name"].ToString()+"NTCA";
                PageTitle = p_var.dSet.Tables[0].Rows[0]["Page_Title"].ToString();
                MetaKeyword = p_var.dSet.Tables[0].Rows[0]["Meta_Keywords"].ToString();
                MetaDescription = p_var.dSet.Tables[0].Rows[0]["Mate_Description"].ToString();
                MetaLng = p_var.dSet.Tables[0].Rows[0]["MetaLanguage"].ToString();
                MetaTitles = p_var.dSet.Tables[0].Rows[0]["MetaTitle"].ToString();

                LitDesc.Text = HttpUtility.HtmlDecode(p_var.dSet.Tables[0].Rows[0]["Details"].ToString());

                if (!string.IsNullOrEmpty(p_var.dSet.Tables[0].Rows[0]["parent"].ToString()))
                {
                    ParentName = p_var.dSet.Tables[0].Rows[0]["parent"].ToString();
                    litPageHead.Text = headerName;
                }
                else
                {
                    litPageHead.Text = headerName;
                }
            }
          

        }
        catch
        {
            throw;
        }
    }

    #endregion
}
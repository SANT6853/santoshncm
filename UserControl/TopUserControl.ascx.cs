using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public partial class UserControl_TopUserControl : System.Web.UI.UserControl
{
    #region Data declaration zone

    Content_ManagementBL menuBL = new Content_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB contentObject = new ContentOB();
    //naren
    BannerManagementBL menuBL1 = new BannerManagementBL();
    public static int GetReserveID = 0;
    #endregion
    public int WebsiteID { get; set; }
    #region Page load event zone

    protected void Page_Load(object sender, EventArgs e)
    {

        p_var.url = WebsiteID==2? Resources.NTCAResources.PageUrl.ToString():Resources.NTCAResources.PageUrlMain.ToString();


        if (!IsPostBack)
        {
            if (Request.QueryString["trname"] != string.Empty && Request.QueryString["trname"] != null)
            {
               
                getReserveIDbyRname();
            }
            
           BindRootMenu_Category();
            
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

    public void BindRootMenu_Category()
    {
        try
        {
            contentObject.Websiteid = WebsiteID;
            contentObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
            contentObject.PositionID = 1;
            p_var.position = (int)contentObject.PositionID;
            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.cms);
            contentObject.LinkParentID = 0;
            contentObject.StateID = 1;
            if (GetReserveID == 0)
            {
                contentObject.TigerReserveid = 0;
            }
            else
            {
                contentObject.TigerReserveid = GetReserveID;
            }


            p_var.dSet = menuBL.getFrontRootMenu(contentObject);
            
            if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
            {
                p_var.sbuilder.Append("<li>");
                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");              
                p_var.sbuilder.Append("</li>");

                p_var.sbuilder.Append("<li>");
                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=1021&bts=0'>Why Relocation?</a>");
                p_var.sbuilder.Append("</li>");
                p_var.sbuilder.Append("<li>");
                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "IndiaMapHighChart.aspx'> Tiger Reserves in India </a>");
                p_var.sbuilder.Append("</li>");
                p_var.sbuilder.Append("<li>");
                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/ReportGPAdminMaster/") + "reportsgp.aspx'> Reports for General Public </a>");
                //ReportGPAdminMaster/reportsgp.aspx
                //p_var.sbuilder.Append("</li>");
                //p_var.sbuilder.Append("<li>");            
                //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "contactus.aspx?ModuleID=6&Websiteid=1&Link_Id=1024'>Contact Us</a>");
                //p_var.sbuilder.Append("</li>");
            }
            for (p_var.i = 0; p_var.i < p_var.dSet.Tables[0].Rows.Count; p_var.i++)
            {
                p_var.menu_name = p_var.dSet.Tables[0].Rows[p_var.i]["name"].ToString();
                p_var.urlname = p_var.dSet.Tables[0].Rows[p_var.i]["UrlName"].ToString();
                p_var.menuid = Convert.ToInt16(p_var.dSet.Tables[0].Rows[p_var.i]["link_id"]);

                if (p_var.menuid == (int)Module_ID_Enum.HomePageEnum.Home || p_var.menuid == (int)Module_ID_Enum.HomePageEnum.HomeHindi) //For Home page and Gallery.
                {

                    

                    //if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                    //{
                    //    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");
                    //    //if (p_var.menuid == Convert.ToInt16(Module_ID_Enum.HomePageEnum.Home)) //Only for home
                    //    //{
                    //    //    if (WebsiteID == 1)
                    //    //    {
                    //    //        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + p_var.url + "index.aspx?Tid='" + Convert.ToInt16(Session["Tid"]) + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                    //    //    }
                    //    //}
                    //}
                    //else
                    //{
                    //    if (p_var.menuid == Convert.ToInt16(Module_ID_Enum.HomePageEnum.HomeHindi)) //Only for home English
                    //    {
                    //        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' class=\"home_btn\" href='" + ResolveUrl("~/") + "index.aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");

                    //    }
                    //}

                    // p_var.sbuilder.Append("</li>");
                }
                else
                {
                    if (p_var.dSet.Tables[0].Rows[p_var.i]["counter_Child"] != DBNull.Value)
                    {

                        p_var.sbuilder.Append("<li>");

                        if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                        {
                            //'" + p_var.dSet.Tables[0].Rows[p_var.i]["url"].ToString() + "'>"
                            p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/")+"Maincontent/" + p_var.menuid+"_"+"1" +"_"+ p_var.dSet.Tables[0].Rows[p_var.i]["UrlName"].ToString() + ".aspx" + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                           // p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='#'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                           // p_var.sbuilder.Append("<span title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' >" + HttpUtility.HtmlDecode(p_var.menu_name) + "</span>");
                        }


                        else
                        {
                            p_var.sbuilder.Append("<span title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</span>");

                        }

                    }
                    else
                    {
                        p_var.sbuilder.Append("<li >");
                        if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                        {
                            if (Convert.ToInt16(p_var.dSet.Tables[0].Rows[p_var.i]["Link_Type_Id"]) == Convert.ToInt16(Module_ID_Enum.LinkTypeId.link))
                            {
                               ////p_var.sbuilder.Append("<li >");
                                p_var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_var.menu_name) + ": " + Resources.NTCAResources.externallink + "'  onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\" href='" + p_var.dSet.Tables[0].Rows[p_var.i]["UrlName"].ToString() + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                            }
                            else
                            {
                                if (Convert.ToInt16(p_var.menuid) == Convert.ToInt16(Module_ID_Enum.Project_Module_ID.TigerReserveMap))
                                {//tiger reserve
                                    // p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name)TigerReserveMap + "'IndiaMapHighChart   href='" + ResolveUrl("~/") + "index.aspx'>"    href='TigerReserveMap.aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //if (p_var.menu_name.ToUpper() == "TIGER RESERVE IN INDIA")
                                    //{
                                    //    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "IndiaMapHighChart.aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //}
                                    //else
                                    //{
                                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "TigerReserveMap.aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //}
                                 }
                                else
                                {//why relo
                                   // p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' ='Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=1021&bts=0'>"='Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=1021&bts=0'>"  href='" + ResolveUrl("~/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //if (p_var.menu_name.ToUpper() == "WHY RELOCATION")
                                    //{
                                    //    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + "Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=1021&bts=0'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //}
                                    //else
                                    //{
                                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                                    //}
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToInt16(p_var.dSet.Tables[0].Rows[p_var.i]["Link_Type_Id"]) == Convert.ToInt16(Module_ID_Enum.LinkTypeId.link))
                            {
                               //// p_var.sbuilder.Append("<li >");
                                p_var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_var.menu_name) + ": " + Resources.NTCAResources.externallink + "'  onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\" href='" + p_var.dSet.Tables[0].Rows[p_var.i]["UrlName"].ToString() + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                            }
                            else
                            {
                                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'   href='" + ResolveUrl("~/Maincontent/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");
                            }

                           // p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'  href='" + ResolveUrl("~/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(p_var.menu_name) + "</a>");

                        }

                    }


                }

                //function to bind child of parent menu

                BindMenuChildren(1, Convert.ToInt16(p_var.dSet.Tables[0].Rows[p_var.i]["link_id"]));

                //end

                p_var.sbuilder.Append("</li>");
            }

            ltrlMenu.Text = p_var.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to bind child menu of root menu

    void BindMenuChildren(int level, int parent_ID)
    {
        Content_ManagementBL subMenuBL = new Content_ManagementBL();

        DataSet subMenuDataSet = new DataSet();
        DataSet parentMenuDataSet = new DataSet();
        ContentOB _contentObject = new ContentOB();
        ContentOB _lnkParentObject = new ContentOB();
        Content_ManagementBL lnkBL = new Content_ManagementBL();
        string subMenuName = string.Empty;
        int subMenuID;
        _contentObject.LinkParentID = parent_ID;
        _contentObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);


        subMenuDataSet = subMenuBL.getSubmenuofRootMenu(_contentObject);
        if (subMenuDataSet.Tables[0].Rows.Count > 0)
        {

            p_var.sbuilder.Append("<ul>");
            for (int i = 0; i < subMenuDataSet.Tables[0].Rows.Count; i++)
            {
                Content_ManagementBL parentMenuBL = new Content_ManagementBL();
                _lnkParentObject.LinkParentID = Convert.ToInt16(subMenuDataSet.Tables[0].Rows[i]["link_id"]);
                parentMenuDataSet = parentMenuBL.getLinkMenuID(_lnkParentObject);
                subMenuName = subMenuDataSet.Tables[0].Rows[i]["name"].ToString();
                p_var.urlname = subMenuDataSet.Tables[0].Rows[i]["UrlName"].ToString();
                subMenuID = Convert.ToInt16(subMenuDataSet.Tables[0].Rows[i]["link_id"]);

                if (subMenuDataSet.Tables[0].Rows[i]["counter_Child"] != DBNull.Value)
                {
                    if (parentMenuDataSet.Tables[0].Rows.Count > 0)
                    {

                        p_var.sbuilder.Append("<li>");


                      //  p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='#'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");

                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/") + p_var.url + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");

                    }
                    else
                    {
                        if (subMenuDataSet.Tables[0].Rows[i]["LinkTypeId"].ToString() == "3")
                        {
                            p_var.sbuilder.Append("<li>");
                            p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + ": This link shall take you to a webpage outside this website. Click OK to continue. Click Cancel to stop.' onclick=\"javascript:return confirm( 'This link shall take you to a webpage outside this website. Click OK to continue. Click Cancel to stop.');\" href='" + ResolveUrl("~/") + p_var.url + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");

                        }

                        else
                        {

                            p_var.sbuilder.Append("<li >");

                            p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/") + p_var.url + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");

                        }
                     p_var.sbuilder.Append("</li>");
                    }
                }
                else
                {
                    if (parentMenuDataSet.Tables[0].Rows.Count > 0)
                    {

                        p_var.sbuilder.Append("<li>");

                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/") + p_var.url + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");



                    }
                    else
                    {
                        if (subMenuDataSet.Tables[0].Rows[i]["Link_Type_Id"].ToString() == "3")
                        {
                            p_var.sbuilder.Append("<li>");

                            p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + ": This link shall take you to a webpage outside this website. Click OK to continue. Click Cancel to stop.' onclick=\"javascript:return confirm( 'This link shall take you to a webpage outside this website. Click OK to continue. Click Cancel to stop.');\" target='_blank' href=" + subMenuDataSet.Tables[0].Rows[i]["url"].ToString() + ">" + HttpUtility.HtmlDecode(subMenuName) + "</a>");

                        }
                       
                     
                        else
                        {

                         p_var.sbuilder.Append("<li>");
                            //if (subMenuID == (int)Module_ID_Enum.Menu_ID_Fixed.Feedbak_Hindi)
                            //{
                            //    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/Feedback/") + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");
                            //}
                            //else if (subMenuID == (int)Module_ID_Enum.Menu_ID_Fixed.Feedbak)
                            //{
                            //    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/content/Eng/Feedback/") + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");
                            //}
                            //else
                            //{

                                p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(subMenuName) + "' href='" + ResolveUrl("~/") + p_var.url + subMenuID + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(subMenuName) + "</a>");
                          //  }

                        }
                        p_var.sbuilder.Append("</li>");
                    }
                }

                //recursively called function to bind child of subchild

                BindMenuChildren(level + 1, Convert.ToInt16(subMenuDataSet.Tables[0].Rows[i]["link_id"]));

                //end
            }
            p_var.sbuilder.Append("</ul>");
        }

    }

    #endregion

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class UserControl_LeftMenu : System.Web.UI.UserControl
{
    #region Data declaration zone

    DataSet dSet = new DataSet();
    ContentOB lnkObject = new ContentOB();
    StringBuilder sb = new StringBuilder();
    Project_Variables p_var=new Project_Variables();
    string Menu_Name = string.Empty;
    int Menu_Id;

    string PageID = string.Empty;
    string PositionID = RewriteModule.RewriteContext.Current.Params["position"];
    string RelatedCatId = string.Empty;
    string Url_page = Resources.NTCAResources.PageUrl;
    int langID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);

    #endregion
    public int WebsiteID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        p_var.url = WebsiteID == 2 ? Resources.NTCAResources.PageUrl.ToString() : Resources.NTCAResources.PageUrlMain.ToString();
        p_var.position = Convert.ToInt16(RewriteModule.RewriteContext.Current.Params["position"]);
        p_var.LanguageID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        //p_var.url = Resources.NTCAResources.PageUrl.ToString();
        if (!IsPostBack)
        {
            if (RewriteModule.RewriteContext.Current.Params["menuid"] != null)
            {
                p_var.PageID = RewriteModule.RewriteContext.Current.Params["menuid"].ToString();
                if (p_var.PageID.Length > 6)
                {
                    p_var.PageID = p_var.PageID.Substring(6);
                }
                else
                {
                    p_var.PageID = p_var.PageID.ToString();
                }
                //if (Convert.ToInt16(p_var.PageID) == (int)Module_ID_Enum.Project_Module_ID.Publication_front || Convert.ToInt16(p_var.PageID) == (int)Module_ID_Enum.Project_Module_ID.Publication_front_Hindi)
                //{
                // bindLeftSideMenu_Publication();
                //}
                //else
                //{
                bindLeftSideMenu();
                //}
            }
        }
    }


    #region Function to bind Left side menu

    public void bindLeftSideMenu()
    {
        Content_ManagementBL menuBL = new Content_ManagementBL();
        Content_ManagementBL subMenuBL = new Content_ManagementBL();
        DataSet subMenuData = new DataSet();
        ContentOB _lnkSubmenuObject = new ContentOB();

        try
        {

            lnkObject.LinkID = Convert.ToInt16(p_var.PageID);
            lnkObject.LangID = langID;
            lnkObject.TigerReserveid= Convert.ToInt16(Session["Tid"]);
            lnkObject.Websiteid = WebsiteID;
            dSet = menuBL.get_Cliked_Parent_Menu(lnkObject);

            //Code to check level and parentID
            Content_ManagementBL _subMenuBL = new Content_ManagementBL();
            DataSet _subMenuData = new DataSet();
            ContentOB _lnkOB = new ContentOB();
            if (Convert.ToInt16(dSet.Tables[0].Rows[0]["link_level"]) == 2)
            {
                _lnkOB.LinkID = Convert.ToInt16(dSet.Tables[0].Rows[0]["link_parent_ID"]);
                _lnkOB.LangID = langID;
                _lnkOB.Websiteid = WebsiteID;
                _subMenuData = _subMenuBL.get_Cliked_Parent_Menu(_lnkOB);
                PageID = _lnkOB.LinkID.ToString();

                if (Convert.ToInt16(_subMenuData.Tables[0].Rows[0]["link_parent_id"]) == 0)
                {
                    if (Convert.ToInt16(PositionID) == 1)
                    {
                        _lnkSubmenuObject.LinkParentID = lnkObject.LinkID;
                    }
                    else
                    {
                        _lnkSubmenuObject.LinkParentID = Convert.ToInt16(_subMenuData.Tables[0].Rows[0]["link_parent_id"]);
                    }
                }
                else
                {
                    _lnkSubmenuObject.LinkParentID = Convert.ToInt16(_subMenuData.Tables[0].Rows[0]["link_parent_id"]);

                }
            }

            //End

            else
            {

                if (Convert.ToInt16(dSet.Tables[0].Rows[0]["link_parent_id"]) == 0)
                {
                    if (Convert.ToInt16(PositionID) == 1)
                    {
                        _lnkSubmenuObject.LinkParentID = lnkObject.LinkID;
                    }
                    else
                    {
                        _lnkSubmenuObject.LinkParentID = Convert.ToInt16(dSet.Tables[0].Rows[0]["link_parent_id"]);
                    }
                }
                else
                {
                    _lnkSubmenuObject.LinkParentID = Convert.ToInt16(dSet.Tables[0].Rows[0]["link_parent_id"]);

                }
            }
            _lnkSubmenuObject.LangID = langID;
            _lnkSubmenuObject.PositionID = Convert.ToInt16(PositionID);
            subMenuData = subMenuBL.get_Cliked_Parent_Child_Menu(_lnkSubmenuObject);



            for (int i = 0; i < subMenuData.Tables[0].Rows.Count; i++)
            {
                Menu_Name = subMenuData.Tables[0].Rows[i]["name"].ToString();
                Menu_Id = Convert.ToInt16(subMenuData.Tables[0].Rows[i]["link_id"]);

                //sb.Append("<li>");
                //if (RelatedCatId != null)
                //{
                //    PageID = subMenuData.Tables[0].Rows[i]["link_id"].ToString();
                //}
                if (Convert.ToInt16(p_var.PageID) == Menu_Id)
                {
                    //if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.Sitemap))
                    //{
                    //    // sb.Append("<a class=\"current\" href='" + ResolveUrl("~/") + "Sitemap.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "</a>");
                    //    sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "Sitemap/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                    //}
                    //else
                    //{
                    //    if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.CommitteeMembers))
                    //    {
                    //        //sb.Append("<a class=\"current\" href='" + ResolveUrl("~/") + "ViewEmpoweredCommitteeMember.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "<span class=\"hidethis\">(Show/Hide the sub menu)</span></a>");
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "CommitteeMember/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                    //    }
                    //    else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.CommitteeMembers_HIndi))
                    //    {
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "content/Hindi/CommitteeMember/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                    //    }
                    //    else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.PhotoGallery))
                    //    {
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "PhotoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                    //    }
                    //    else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.PhotoGallery_Hindi))
                    //    {
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "content/Hindi/PhotoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                    //    }
                    //    else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.VideoGallery))
                    //    {
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "VideoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                    //    }
                    //    else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.VideoGallery_Hindi))
                    //    {
                    //        sb.Append("<a class=\"current\" href=" + ResolveUrl("~/") + "content/Hindi/VideoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                    //    }
                    //    else
                    //    {
                    sb.Append("<li>");
                    // sb.Append("<a class=\"current\" href='content.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "<span class=\"hidethis\">(Show/Hide the sub menu)</span></a>");
                    sb.Append("<a href=" + ResolveUrl("~/") + Url_page + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                        //}
                    }
                
                else
                {
                    if (subMenuData.Tables[0].Rows[i]["UrlName"] != DBNull.Value)
                    {
                        // sb.Append("<a href='content.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "<span class=\"hidethis\">(Show/Hide the sub menu)</span></a>");
                        sb.Append("<li>");
                        sb.Append("<a href=" + ResolveUrl("~/") + "content/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");

                    }
                    else
                    {
                        //if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.Sitemap) || Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.Sitemap_Hindi))
                        //{
                        //    if (langID == 1)
                        //    {
                        //        sb.Append("<a href=" + ResolveUrl("~/") + "Sitemap/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                        //    }
                        //    else
                        //    {
                        //        sb.Append("<a href=" + ResolveUrl("~/") + "content/Hindi/Sitemap/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                        //    }
                        //}
                        //else
                        //{
                            //if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.CommitteeMembers))
                            //{
                            //    //  sb.Append("<a href='" + ResolveUrl("~/") + "ViewEmpoweredCommitteeMember.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "<span class=\"hidethis\">(Show/Hide the sub menu)</span></a>");
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "CommitteeMember/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                            //}
                            //else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.CommitteeMembers_HIndi))
                            //{
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "content/Hindi/CommitteeMember/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "");
                            //}
                            //else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.PhotoGallery))
                            //{
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "PhotoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                            //}
                            //else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.PhotoGallery_Hindi))
                            //{
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "content/Hindi/PhotoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                            //}
                            //else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.VideoGallery))
                            //{
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "VideoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                            //}
                            //else if (Menu_Id == Convert.ToInt16(Module_ID_Enum.Module_Wise_Enum.VideoGallery_Hindi))
                            //{
                            //    sb.Append("<a href=" + ResolveUrl("~/") + "content/Hindi/VideoGallery/" + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                            //}
                            //else
                            //{
                                //  sb.Append("<a href='content.aspx?id=" + Menu_Id + "&position=" + PositionID + "'>" + Menu_Name + "<span class=\"hidethis\">(Show/Hide the sub menu)</span></a>");
                                sb.Append("<a href=" + ResolveUrl("~/") + Url_page + Menu_Id + "_" + PositionID + "_" + Menu_Name.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + Menu_Name + "</a>");
                           // }
                       // }
                    }
                }
                sb.Append("</li>");
                
                

            }

            ltlrLeftMenu.Text = sb.ToString();

        }
        catch
        {
            throw;
        }
    }

    #endregion
}
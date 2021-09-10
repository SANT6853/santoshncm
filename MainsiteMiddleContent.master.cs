using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mainsite : System.Web.UI.MasterPage
{
    ContentOB contentObject = new ContentOB();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    Project_Variables p_Var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
       string strUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        if(strUrl.Contains("alert"))
       {
            Response.Redirect("~/error.aspx");
       }

        if (!IsPostBack)
        {
            Page.Header.DataBind();
            bindTopMiddleLower();
            BindBottomThumnailMarquee();
        }

    }
    public void bindTopMiddleLower()
    {
        try
        {

            contentObject.ModuleID = 6;
            contentObject.Websiteid = 1;

            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePage(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                p_Var.sbuilder.Append("<div class=\"col-sm-3\">");
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {

                   
                        if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                        {
                            if (Convert.ToInt32(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["link_id"]) == Convert.ToInt32(Session["menuid"]))
                            {
                                p_Var.sbuilder.Append("<div id=\"look" + p_Var.i + "\" class=\"text-center selectleftmnu\" runat=\"server\">");
                                p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=" + p_Var.i + "\" class=\"read_morea get12\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                                p_Var.sbuilder.Append("</a>");
                            }
                            else
                            {
                                p_Var.sbuilder.Append("<div id=\"look" + p_Var.i + "\" class=\"text-center\" runat=\"server\">");
                                p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=" + p_Var.i + "\" class=\"read_morea get12\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                                p_Var.sbuilder.Append("</a>");
                            }
                           
                            p_Var.sbuilder.Append("</div>");
                            
                        }
                        else
                        {
                           
                            p_Var.sbuilder.Append("<div class=\"text-center\">");
                            p_Var.sbuilder.Append("<a href=\"contactus.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "\" class=\"read_morea\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</div>");
                           
                        }
                       

                    
                }
                p_Var.sbuilder.Append("</div>");
            }
            LtrLeftVerticalMenu.Text = p_Var.sbuilder.ToString();

        }


        catch
        {
            throw;
        }
    }
    public void BindBottomThumnailMarquee()
    {
        try
        {
            p_Var.sbuilder.Clear();
            p_Var.dsFileName = null;
            contentObject.ModuleID = 7;
            contentObject.Websiteid = 1;

            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePage(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {
                    p_Var.sbuilder.Append("<li>");

                   // p_Var.sbuilder.Append("<img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' />");
                    p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "' onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\"   href='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["UrlName"].ToString() + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    //p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "'     href='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    p_Var.sbuilder.Append("</li>");
                }
            }
            LtrBottomMarquee.Text = p_Var.sbuilder.ToString();

        }


        catch
        {
            throw;
        }
    }
   
}

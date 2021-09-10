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
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {
                    if (p_Var.i == 0)//first
                    {
                        p_Var.sbuilder.Append("<div class=\"col-md-3 col-sm-3 homebox hvr-float-shadow\">");

                        p_Var.sbuilder.Append("<div class=\"homeboxinner bg-green\" >");

                        p_Var.sbuilder.Append("<h3 class=\"relo_heading text-center\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                        p_Var.sbuilder.Append("</h3>");

                        p_Var.sbuilder.Append("<p class=\"text-justify\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["SmallDetails"].ToString() + "");
                        p_Var.sbuilder.Append("</p>");

                        if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                        {
                            //  int abc =Convert.ToInt32(p_Var.dsFileName.Tables[0].Rows[p_Var.i]);
                            p_Var.sbuilder.Append("<p class=\"text-center\">");
                            p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=0" + "\" class=\"read_morea\">Read More...");
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</p>");
                        }



                        p_Var.sbuilder.Append("</div>");

                        p_Var.sbuilder.Append("</div>");
                    }//end of if
                    if (p_Var.i == 1)//2nd code
                    {
                        p_Var.sbuilder.Append("<div class=\"col-md-3 col-sm-3 homebox hvr-float-shadow\">");

                        p_Var.sbuilder.Append("<div class=\"homeboxinner bg-yellow\" >");

                        p_Var.sbuilder.Append("<h3 class=\"relo_heading text-center\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                        p_Var.sbuilder.Append("</h3>");

                        p_Var.sbuilder.Append("<p class=\"text-justify\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["SmallDetails"].ToString() + "");
                        p_Var.sbuilder.Append("</p>");

                        if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                        {
                            //  int abc =Convert.ToInt32(p_Var.dsFileName.Tables[0].Rows[p_Var.i]);
                            p_Var.sbuilder.Append("<p class=\"text-center\">");
                            p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=0" + "\" class=\"read_morea\">Read More...");
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</p>");
                        }



                        p_Var.sbuilder.Append("</div>");

                        p_Var.sbuilder.Append("</div>");
                    }//end of if
                    if (p_Var.i == 2)//3rd code
                    {
                        p_Var.sbuilder.Append("<div class=\"col-md-3 col-sm-3 homebox hvr-float-shadow\">");

                        p_Var.sbuilder.Append("<div class=\"homeboxinner bg-red\" >");

                        p_Var.sbuilder.Append("<h3 class=\"relo_heading text-center\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                        p_Var.sbuilder.Append("</h3>");

                        p_Var.sbuilder.Append("<p class=\"text-justify\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["SmallDetails"].ToString() + "");
                        p_Var.sbuilder.Append("</p>");

                        if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                        {
                            //  int abc =Convert.ToInt32(p_Var.dsFileName.Tables[0].Rows[p_Var.i]);
                            p_Var.sbuilder.Append("<p class=\"text-center\">");
                            p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=0" + "\" class=\"read_morea\">Read More...");
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</p>");
                        }



                        p_Var.sbuilder.Append("</div>");

                        p_Var.sbuilder.Append("</div>");
                    }//end of if
                    if (p_Var.i == 3)//4forth code
                    {
                        p_Var.sbuilder.Append("<div class=\"col-md-3 col-sm-3 homebox hvr-float-shadow\">");

                        p_Var.sbuilder.Append("<div class=\"homeboxinner bg-aqua\" >");

                        p_Var.sbuilder.Append("<h3 class=\"relo_heading text-center\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                        p_Var.sbuilder.Append("</h3>");

                        p_Var.sbuilder.Append("<p class=\"text-justify\">");
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["SmallDetails"].ToString() + "");
                        p_Var.sbuilder.Append("</p>");

                        if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                        {
                            //  int abc =Convert.ToInt32(p_Var.dsFileName.Tables[0].Rows[p_Var.i]);
                            p_Var.sbuilder.Append("<p class=\"text-center\">");
                            p_Var.sbuilder.Append("<a href=\"Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=0" + "\" class=\"read_morea\">Read More...");
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</p>");
                        }



                        p_Var.sbuilder.Append("</div>");

                        p_Var.sbuilder.Append("</div>");
                    }//end of if
                }//end of for
            }
            LtrCntMiddleContent.Text = p_Var.sbuilder.ToString();

        }


        catch (Exception er)
        {
            //throw;
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

                  //  p_Var.sbuilder.Append("<img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' />");
                    //  p_var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_var.menu_name) + ": " + Resources.NTCAResources.externallink + "'  onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\" href='" + p_var.dSet.Tables[0].Rows[p_var.i]["UrlName"].ToString() + "'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                  //  p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "'     href='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "' onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\"   href='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["UrlName"].ToString() + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    p_Var.sbuilder.Append("</li>");
                }
            }
            LtrBottomMarquee.Text = p_Var.sbuilder.ToString();

        }


        catch(Exception er)
        {
            throw;
        }
    }
}

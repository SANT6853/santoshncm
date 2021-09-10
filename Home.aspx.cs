using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home : BasePage
{
    #region Data declaration zone

    Content_ManagementBL menuBL = new Content_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB contentObject = new ContentOB();
    BannerManagementBL bannerBL =new BannerManagementBL();

    #endregion
    public int WebsiteID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
       // MasterPage mstr = this.Parent.Page.Master as MasterPage;
       // ((HtmlControl)mstr.Master.FindControl("DivPrintHideShow")).Visible = false;
        ((HtmlControl)this.Master.FindControl("DivPrintHideShow")).Visible = false;
        if (!IsPostBack)
        {
            this.Title = "Home:NTCA";
            homeBanner();
        }
       
    }
    public void homeBanner()
    {
        try
        {
            int width = (Request.Browser.ScreenPixelsWidth) * 2 - 100;
            StringBuilder sb = new StringBuilder();
           
            contentObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
            contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
            contentObject.StateID = 1;
            contentObject.Websiteid = 1;
            contentObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
            p_var.dsFileName = bannerBL.getBannerList(contentObject);

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
                {//   p_var.sbuilder.Append("<embed height='336px' width='100%'  src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + "'/>"));
                    sb.Append("<div class=\"item active\"> ");
                    sb.Append("<img class='bannerImg'  alt='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
                    sb.Append("</div>");
                }
                else
                {
                    sb.Append("<div class=\"item\">");
                    sb.Append("<img class='bannerImg'  alt='" + p_var.dsFileName.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dsFileName.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
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
			
			
            sb.Append("<div id=\"carouselButtons\">");			
            sb.Append("<button id=\"playButton\" type=\"button\" title=\"Play\" class=\"btn btn-default btn-xs\">");
            sb.Append("<span class=\"glyphicon glyphicon-play\">");
            sb.Append("</span>");
            sb.Append("</button>");
			sb.Append("<button id=\"pauseButton\" type=\"button\" title=\"Pause\" class=\"btn btn-default btn-xs\">");
            sb.Append("<span class=\"glyphicon glyphicon-pause\">");
            sb.Append("</span>");
            sb.Append("</button>");
            sb.Append("</div>");
			
            // LtrNext.Text = sb.ToString();
            //end next

            sb.Append("</div>");//end first div

            LtrBanner1.Text = sb.ToString();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_BannerUserControl : System.Web.UI.UserControl
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
        if (!IsPostBack)
        {
            BindHomepageBanner();
        }
    }

    //Area for all the user-defined function to bind banner

    public void BindHomepageBanner()
    {
        contentObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.Banner);
        contentObject.StateID = 1;
        contentObject.Websiteid = WebsiteID;
        contentObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
        //.TigerReserveid = Convert.ToInt16(Session["sTigerReserveID"]);
        p_var.dSet = bannerBL.getBannerList(contentObject);
        //p_var.sbuildertmp.Append("<ol class=\"carousel - indicators\">");
        //for (p_var.i = 0; p_var.i < p_var.dSet.Tables[0].Rows.Count; p_var.i++)
        //{
           
        //    if (p_var.i == (Convert.ToInt16(p_var.dSet.Tables[0].Rows.Count) - 1))
        //    {
        //        p_var.sbuildertmp.Append("<li data-target=\"#myCarousel\" data-slide-to=\'" + p_var.i + "\' class=\"active\">");
        //    }
        //    else
        //    {
        //        p_var.sbuildertmp.Append("<li data-target=\"#myCarousel\" data-slide-to=\'" + p_var.i + "' class=\"\">");
        //    }
        //    p_var.sbuildertmp.Append("</li>");

        //}
        //p_var.sbuildertmp.Append("</ol>");
    //    ltrlCounter.Text = p_var.sbuildertmp.ToString();
        for (p_var.i = 0; p_var.i < p_var.dSet.Tables[0].Rows.Count; p_var.i++)
        {
            if (WebsiteID == 2)
            {
                if (p_var.i == (Convert.ToInt16(p_var.dSet.Tables[0].Rows.Count) - 1))
                {
                    p_var.sbuilder.Append("<div class=\"item active\">");

                    p_var.sbuilder.Append("<img  alt='" + p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");

                    // p_var.sbuilder.Append(p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString());

                    p_var.sbuilder.Append("</div>");
                }
                else
                {
                    p_var.sbuilder.Append("<div class=\"item\">");

                    p_var.sbuilder.Append("<img  alt='" + p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");

                    //  p_var.sbuilder.Append(p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString());

                    p_var.sbuilder.Append("</div>");
                }
            }
            else
            {
                int width = (Request.Browser.ScreenPixelsWidth) * 2 - 100;
                //width='" + width.ToString() + "px'

                p_var.sbuilder.Append("<img class='bannerImg'  src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + "'/>"));

              //  p_var.sbuilder.Append("<embed height='336px' width='100%'  src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + "'/>"));
              //  p_var.sbuilder.Append("<img  alt='" + p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
                //  p_var.sbuilder.Append("<img  alt='NTCA' title='National Tiger Conservation Authority,Government of India' src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
            }


        }

        //litContent.Text = p_var.sbuilder.ToString();
        ltrlContent.Text = p_var.sbuilder.ToString();
    }


    //End
}
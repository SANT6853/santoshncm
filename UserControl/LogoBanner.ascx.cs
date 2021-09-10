using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_LogoBanner : System.Web.UI.UserControl
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
    public void BindHomepageBanner()
    {
        contentObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.LogoBanner);

        p_var.dSet = bannerBL.LogoBannerBind(contentObject);
        
        if (p_var.dSet.Tables[0].Rows.Count > 0)
        {
            p_var.sbuilder.Append("<a href='" + ResolveUrl("~/") + "home.aspx'>");              
            p_var.sbuilder.Append("<img  alt='NTCA' title='National Tiger Conservation Authority,Government of India' src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_var.dSet.Tables[0].Rows[p_var.i]["Image_Name"].ToString() + " ") + "' />");
                // p_var.sbuilder.Append(p_var.dSet.Tables[0].Rows[p_var.i]["alt_tag"].ToString())
            p_var.sbuilder.Append("</a>");
        }

      
        ltrlContent.Text = p_var.sbuilder.ToString();
    }
}
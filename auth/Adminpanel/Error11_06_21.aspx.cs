using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class Error :  BasePage
{
    string MetaLng = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        litleftheading.Text = Resources.Resource.Error;
    }
    protected override void PageMetaTags()
    {
        base.Page.Title = Resources.Resource.Error + ":" + Resources.Resource.PPAC;
        Title = Resources.Resource.Error + ":" + Resources.Resource.PPAC;
        PageDescription = Resources.Resource.Error + "," + ConfigurationManager.AppSettings["Description"].ToString();
        PageKeywords = Resources.Resource.Error + "," + ConfigurationManager.AppSettings["Keyword"].ToString();
        MetaLang = MetaLng;
        MetaTitle = Resources.Resource.Error + ":" + Resources.Resource.PPAC;
    }
}
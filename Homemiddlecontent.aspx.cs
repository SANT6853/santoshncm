using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homemiddlecontent : BasePage
{
	  string pgTitle = string.Empty;
    ContentOB contentObject = new ContentOB();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    Project_Variables p_Var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Link_Id"] != null)
            {
                bindTopMiddleLower();
            }
        }
    }
    public void bindTopMiddleLower()
    {

        try
        {

            contentObject.ModuleID = 6;
            contentObject.Websiteid = 1;
            contentObject.LinkID =Convert.ToInt32(Request.QueryString["Link_Id"]);
            Session["menuid"] = contentObject.LinkID;
            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePagespecific(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                this.Title= p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + ":National Tiger Conservation Authority";
                pgTitle = p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString();
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {
                   // p_Var.sbuilder.Append("<div class=\"col-md-3\">");

                   // p_Var.sbuilder.Append("<h3 class=\"relo_heading text-center\">");
                   
                   
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() + "");
                        // p_Var.sbuilder.Append("</h3>");
                        p_Var.sbuildertmp.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                   
                    
                    //  p_Var.sbuilder.Append("</div>");sbuildertmp
                }
            }
            LtrTitle.Text = p_Var.sbuildertmp.ToString();
            LtrCntMiddleContent.Text = p_Var.sbuilder.ToString();

        }


        catch
        {
            throw;
        }
    }
	protected override void PageMetaTags()
    {

        MetaTitle = pgTitle + ": National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Page_Title"].ToString();
        MetaKeywords = "NTCA"+", "+ pgTitle;//p_var.dSet.Tables[0].Rows[0]["Meta_Keywords"].ToString();
        MetaDescription = "National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Mate_Description"].ToString();
        MetaLang = "en";
    }
}
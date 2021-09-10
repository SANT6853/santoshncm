using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contactus : BasePage
{
    ContentOB contentObject = new ContentOB();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    Project_Variables p_Var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = "Contact Us:NTCA";
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
            contentObject.LinkID = Convert.ToInt32(Request.QueryString["Link_Id"]);
            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePagespecific(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {
                    if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                    {
                    }
                    else
                    {
                        p_Var.sbuilder.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["SmallDetails"].ToString() + "");
                        // p_Var.sbuilder.Append("</h3>");
                        p_Var.sbuildertmp.Append("" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + "");
                    }

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
}
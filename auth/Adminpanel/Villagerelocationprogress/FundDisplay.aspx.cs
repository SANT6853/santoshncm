using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;

public partial class auth_Adminpanel_Villagerelocationprogress_FundDisplay : System.Web.UI.Page
{
    string filename;
    common com_Obj = new common();
    uploadfileentity entity = new uploadfileentity();
    Dal_upload_file dal = new Dal_upload_file();
    Miscelleneous_BL obMiscell = new Miscelleneous_BL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("4"))
            {
                DisplayFundDetails();
            }
            DisplayFundDetails();
        }
    }

    #region Function to display fund details

    private void DisplayFundDetails()
    {
        Project_Variables p_Var = new Project_Variables();
        VillageDB fundBL = new VillageDB();

        p_Var.dSet = fundBL.Display_FundDisplayFundDetails();
        if (p_Var.dSet.Tables.Count > 0)
        {
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                gvDisplayFund.DataSource = p_Var.dSet;
                gvDisplayFund.DataBind();
            }
            else
            {
                gvDisplayFund.DataSource = null;
                gvDisplayFund.DataBind();
            }
        }
        else
        {
            gvDisplayFund.DataSource = null;
            gvDisplayFund.DataBind();
        }
    }

    #endregion
}
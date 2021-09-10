using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_VillageListPopUp : System.Web.UI.Page
{
    FeedBackBL _obBl = new FeedBackBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB contentObject = new ContentOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                //int ss = Convert.ToInt32(Request.QueryString["vid"]);
               Bind_FeedbackDetails(Convert.ToInt32(Request.QueryString["vid"]));
                //Bind_FeedbackDetails(9);
            }
        }
    }
    protected void gvVillage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvVillage_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    void Bind_FeedbackDetails(int TigerReserveID)
    {
        p_var.dSet = _obBl.GetTigerReserveOFVilageList(TigerReserveID);
        if (p_var.dSet.Tables[0].Rows.Count > 0)
        {
            gvVillage.DataSource = p_var.dSet;
            gvVillage.DataBind();
           // p_var.dSet = null;

            lblnorecord.Text = "";
        }
        else
        {
            lblnorecord.Text = "Record(s) Not Available.";
        }
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_ConfirmationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["msg"] != null)
            {
                lblmsg.Text = Session["msg"].ToString();
            }
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Session["BackUrl"] != null)
        {
            Response.Redirect(Session["BackUrl"].ToString());
        }

    }
}
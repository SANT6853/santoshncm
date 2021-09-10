using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FeedBack_FeedbackDetails : System.Web.UI.Page
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
                Bind_FeedbackDetails(Convert.ToInt32(Request.QueryString["vid"]));
            }
        }
    }
    void Bind_FeedbackDetails(int feedbackID)
    {
        p_var.dSet = _obBl.GetParticularFeedBackData(feedbackID);
        if (p_var.dSet.Tables[0].Rows.Count > 0)
        {
            LblName.Text = p_var.dSet.Tables[0].Rows[0]["Name"].ToString();
            LblEmail.Text = p_var.dSet.Tables[0].Rows[0]["EmailID"].ToString();
            LblPhone.Text = p_var.dSet.Tables[0].Rows[0]["Phone"].ToString();
            Lblstate.Text = p_var.dSet.Tables[0].Rows[0]["StateName"].ToString();
            LblfeedbackTpe.Text = p_var.dSet.Tables[0].Rows[0]["ModuleId"].ToString();
            LblAddress.Text = p_var.dSet.Tables[0].Rows[0]["Address"].ToString();
            Lblmessage.Text = p_var.dSet.Tables[0].Rows[0]["Message"].ToString();
           
        }
    }
   
}
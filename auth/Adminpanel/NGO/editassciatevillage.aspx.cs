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
using NCM.DAL;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_NGO_editassciatevillage : CrsfBase
{
    NgoBal bal = new NgoBal();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        int id = Int32.Parse(Request.QueryString["id"].ToString());
        if (!IsPostBack)
        {
            filldeatil();


        }
    }
    public void filldeatil()
    {
        int id = Int32.Parse(Request.QueryString["id"].ToString());
        ds = bal.select_associate_village_deatil(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvillge.Text = ds.Tables[0].Rows[0]["vill_nm"].ToString();
            lblngoname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txtamount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
            txtworkdone.Text = ds.Tables[0].Rows[0]["work_done_for_village"].ToString();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
         // if (Page.IsValid)
        // {
        try
        {

            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {

                    if (Page.IsValid)
                    {

                        int id = Int32.Parse(Request.QueryString["id"].ToString());
                        double amount = double.Parse(txtamount.Text);
                        string workdone = txtworkdone.Text;
                        int i = bal.update_associate_village_deatilnew(id, amount, workdone);
                        if (i > 0)
                        {
                            panel.Visible = false;
                            btnreset.Visible = false;
                            btnsubmit.Visible = false;
                            lblmsg.Text = "Record is  update successfully";
                            lblmsg.ForeColor = System.Drawing.Color.Green;

                        }
                        else
                        {
                            lblmsg.Text = "Record is not update successfully";
                            lblmsg.ForeColor = System.Drawing.Color.Red;

                        }

                    }
                }
            }

        }
        catch
        {
            throw;
        }
      // }
    }
    
    
    public void update()
    {


    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        filldeatil();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
    }
}
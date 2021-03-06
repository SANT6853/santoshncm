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

public partial class auth_Adminpanel_NGO_editassciatevillage1 :CrsfBase
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
            if (Session["UserType"].ToString() == "1")
            {
                AdminNgo();
            }
            else
            {
                filldropedownngo(Convert.ToInt32(Session["PermissionState"]));
                
            }

            filldeatil();
        }
    }

    public void AdminNgo()
    {
        ddlngo.Items.Clear();
        DataTable dt = NgoDal.adminNgo();
        if (dt.Rows.Count > 0)
        {
            ddlngo.DataSource = dt;
            ddlngo.DataTextField = "name";
            ddlngo.DataValueField = "id";
            ddlngo.DataBind();
            ddlngo.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownngo(int Statid)
    {
        ddlngo.Items.Clear();
        DataTable dt = NgoDal.binddropedownngo(Statid);
        if (dt.Rows.Count > 0)
        {
            ddlngo.DataSource = dt;
            ddlngo.DataTextField = "name";
            ddlngo.DataValueField = "id";
            ddlngo.DataBind();
            ddlngo.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldeatil()
    {
        int id = Int32.Parse(Request.QueryString["id"].ToString());
        ds = bal.select_associate_village_deatil(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvillge.Text = ds.Tables[0].Rows[0]["vill_nm"].ToString();
           // lblngoname.Text = ds.Tables[0].Rows[0]["name"].ToString();
            for (int i = 0; i < ddlngo.Items.Count; i++)
            {
                string p = ddlngo.Items[i].ToString();
                if (p == ds.Tables[0].Rows[0]["name"].ToString())
                {
                    ddlngo.Items[i].Selected = true;

                }
            }
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
                        int i = bal.update_associate_village_deatil(id, amount, workdone, Convert.ToInt32(ddlngo.SelectedValue));
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
        Response.Redirect("~/auth/adminpanel/Ngo/ViewNgo.aspx");
    }
}
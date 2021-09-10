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

public partial class auth_Adminpanel_NGO_Associate_Village1 :CrsfBase
{
    Associate_Village entity = new Associate_Village();
    NgoBal obj_bal = new NgoBal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            //string ss = Session["PermissionState"].ToString();
            if (Session["UserType"].ToString() == "1")
            {
                GetAdminVillage();
                AdminNgo();
            }
            else
            {
                filldropedownngo(Convert.ToInt32(Session["PermissionState"]));
                filldropedownvillage();
            }
            
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
    public void filldropedownngo(int StateID)
    {
        ddlngo.Items.Clear();
        DataTable dt = NgoDal.binddropedownngo(StateID);
        if (dt.Rows.Count > 0)
        {
            ddlngo.DataSource = dt;
            ddlngo.DataTextField = "name";
            ddlngo.DataValueField = "id";
            ddlngo.DataBind();
            ddlngo.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villages(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void GetAdminVillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.GetAdminVillageAll();
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
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



                        lblDdngo.Text = "";
                        bool chk = false;

                        entity.villageid = Int32.Parse(ddlvillage.SelectedValue);
                        entity.amount = double.Parse(txtamount.Text);
                        entity.work_done_by_ngo = txtworkdone.Text;
                        entity.UserID = Convert.ToInt32(Session["User_Id"]);
                        int count = ddlngo.Items.Count;
                        if (count > 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (ddlngo.Items[i].Selected)
                                {
                                    chk = true;
                                    entity.ngoid = Int32.Parse(ddlngo.Items[i].Value);
                                    int j = obj_bal.Associate_Village(entity);


                                }
                            }

                        }
                        if (chk == false)
                        {
                            lblDdngo.Text = "Please select NGO name!!";
                        }
                        else
                        {
                            lblmsg.Text = "Record Inserted Successfully";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            Session["msg"] = "Record Inserted Successfully.";
                            Session["BackUrl"] = "~/Auth/AdminPanel/NGO/ViewNgo.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
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
    
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    public void reset()
    {
        ddlvillage.SelectedValue = "0";
        ddlngo.SelectedValue = "0";
        txtamount.Text = "";
        txtworkdone.Text = "";

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Ngo/ViewNgo.aspx"));
    }
}
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

public partial class auth_Adminpanel_Villagerelocationprogress_RelocationProgresManagement :CrsfBase
{
    relocationprogress del = new relocationprogress();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("1"))
            {

                btnAdd.Visible = false;
                bindgrid1();
            }
            if (Session["UserType"].ToString().Equals("2"))
            {

                btnAdd.Visible = false;
                bindgrid2();
            }
            if (Session["UserType"].ToString().Equals("3"))
            {

                btnAdd.Visible = false;
                bindgrid3();
            }
            if (Session["UserType"].ToString().Equals("4"))
            {

          
                bindgrid();
            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Relocation_Progress_Report.aspx?Operation=" + 1);
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvforVillages.PageIndex = e.NewPageIndex;
        bindgrid();



    }
    public void bindgrid()
    {
        DataSet ds = del.SelectRecordForeGrid(null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            gvforVillages.DataBind();
        }
        else
        {
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
        }

    }
    public void bindgrid3()
    {
        DataSet ds = del.SelectRecordForeGrid3(null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            gvforVillages.DataBind();
        }
        else
        {
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
        }

    }
    public void bindgrid2()
    {
        DataSet ds = del.SelectRecordForeGrid2(null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            gvforVillages.DataBind();
        }
        else
        {
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
        }

    }
    public void bindgrid1()
    {
        DataSet ds = del.SelectRecordForeGrid1(null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            gvforVillages.DataBind();
        }
        else
        {
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
        }

    }
    protected void gvforVillages_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvforVillages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvforVillages_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        if (e.CommandName == "Edit")
                        {
                            int id = Int32.Parse(e.CommandArgument.ToString());

                            Response.Redirect("Relocation_Progress_Report.aspx?id=" + id + "&Operation=" + 2);
                        }

                        if (e.CommandName == "Delete")
                        {
                            int id = Int32.Parse(e.CommandArgument.ToString());
                            int i = del.DeleteReport(id);
                            if (i > 0)
                            {
                                lblmsg.Text = "Record Deleted Successfuly";
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                                bindgrid();
                            }

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


    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FundManagement_fundlist : System.Web.UI.Page
{
    NgoOB ngObj = new NgoOB();
    NgoBL ngBL = new NgoBL();
    Project_Variables p_Val = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            DisplayNGODetail();
        }
    }
    
    protected void GvAdd_NGODetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (Page.IsValid)
        //{

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
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            int vid  = Convert.ToInt32(e.CommandArgument);
                            int id=Convert.ToInt32(Request.QueryString["id"]);
                            Response.Redirect("~/auth/Adminpanel/FundManagement/fund.aspx?id=" + id + "&vid=" + vid);
                        }
                        if (e.CommandName == "Delete")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            ngObj.VillageID = Convert.ToInt32(e.CommandArgument);
                            p_Val.Result = ngBL.DeleteFund(ngObj);
                            DisplayNGODetail();
                        }
                    }
                }
            }
       // }
    }

     catch
     {
       throw;
      }
        // }
    }
                   
    protected void GvAdd_NGODetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (Page.IsValid)
        //{

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
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField hddnFinal = (HiddenField)e.Row.FindControl("hddnFinal");
                            Button imgedit = (Button)e.Row.FindControl("imgedit");
                            Button imgedit1 = (Button)e.Row.FindControl("imgedit1");
                            if (hddnFinal.Value == "1")
                            {
                                imgedit.Visible = true;
                                imgedit1.Visible = true;
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
    protected void GvAdd_NGODetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    #region function for bind NGO Detail
    public void DisplayNGODetail()
    {
        if (Request.QueryString["id"] != null)
        {
            ngObj.UserID=Convert.ToInt32(Session["User_Id"]);
            ngObj.VillageID=Convert.ToInt32(Request.QueryString["id"]);
            p_Val.dSet = ngBL.FundDetails(ngObj);

            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                GvAdd_NGODetails.DataSource = p_Val.dSet;
                GvAdd_NGODetails.DataBind();
            }
            else
            {
                GvAdd_NGODetails.DataSource = p_Val.dSet;
                GvAdd_NGODetails.DataBind();
            }
        }
    }
    #endregion
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/form-preview.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_NGO_ngolistaspx :CrsfBase
{
    NgoOB ngObj = new NgoOB();
    NgoBL ngBL = new NgoBL();
    Project_Variables p_Val = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindNGO();
            DisplayNGODetail();
        }
    }
    protected void btnAddNGO_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/NGO/addngo.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            ngObj.UserID = Convert.ToInt32(Session["User_Id"]);
            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            p_Val.dSet = ngBL.FundDetails(ngObj);

            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fund.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));

                }
            }
        }
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DisplayNGODetail();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            ngObj.UserID = Convert.ToInt32(Session["User_Id"]);
            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            p_Val.dSet = ngBL.FundDetails(ngObj);

            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fund.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));

                }
            }
        }
    }
    #region Functiion for bind NGO DropDown List 
    public void bindNGO()
    {
        int stateId = Convert.ToInt32(Request.QueryString["id"]);
      
        DataTable dt = NgoDal.bindNGO(stateId);
        if (dt.Rows.Count > 0)
        {
            ddlNGO.DataSource = dt;
            ddlNGO.DataTextField = "NGO_NAME";
            ddlNGO.DataValueField = "NGO_ID";
            ddlNGO.DataBind();
            ddlNGO.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    #endregion
    protected void GvAdd_NGODetails_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        if (e.CommandName == "Add")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            int id = Convert.ToInt32(e.CommandArgument);
                            Response.Redirect("~/auth/adminpanel/NGO/ngohistory.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&h=" + id);
                        }
                        if (e.CommandName == "Delete")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            ngObj.VillageID = Convert.ToInt32(e.CommandArgument);
                            p_Val.Result = ngBL.DeleteNGO(ngObj);
                            DisplayNGODetail();
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
    protected void GvAdd_NGODetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hddnfinalsubmit = (HiddenField)e.Row.FindControl("hddnfinalsubmit");
            Button imgedit = (Button)e.Row.FindControl("imgedit");
            Button imgedit1 = (Button)e.Row.FindControl("imgedit1");
            if (hddnfinalsubmit.Value == "1")
            {
                //imgedit.Visible = false;
                imgedit1.Visible = true;
            }
        }
    }
    protected void GvAdd_NGODetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    #region function for bind NGO Detail
    public void DisplayNGODetail()
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

                        if (Request.QueryString["id"] != null)
                        {
                            divNGO.Visible = true;
                            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
                            if (ddlNGO.SelectedValue.ToString() == "0" || ddlNGO.SelectedValue.ToString() == "")
                            {
                                ngObj.NgoID = null;

                            }
                            else
                            {
                                ngObj.NgoID = Convert.ToInt32(ddlNGO.SelectedValue.ToString());
                            }
                            p_Val.dSet = ngBL.NGODetails(ngObj);

                            if (p_Val.dSet.Tables[0].Rows.Count > 0)
                            {
                                GvAdd_NGODetails.DataSource = p_Val.dSet;
                                GvAdd_NGODetails.DataBind();
                                if (Convert.ToInt16(p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
                                {
                                    divNGO.Visible = true;
                                }
                            }
                            else
                            {
                                divNGO.Visible = true;
                                GvAdd_NGODetails.DataSource = p_Val.dSet;
                                GvAdd_NGODetails.DataBind();
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
    
    #endregion
	  #region Fuction for Bind Modal Ppopup
    [WebMethod]
    public static string BindModelGridView(string ConversionID)
    {

        string response;
        NgoOB ngObj = new NgoOB();
        NgoBL ngBL = new NgoBL();
        Project_Variables p_Var = new Project_Variables();
        ngObj.SchemeID = Convert.ToInt32(ConversionID);
        p_Var.dSet = ngBL.POSTNGO_History(ngObj);
        p_Var.dSet = ngBL.PRENGO_History(ngObj);
        response = JsonConvert.SerializeObject(p_Var.dSet.Tables[0]);

        return response;
    }
    #endregion

    protected void GvAdd_NGODetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
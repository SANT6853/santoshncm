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

public partial class auth_Adminpanel_Post_workperformlist :CrsfBase
{
    NgoOB ngObj = new NgoOB();
    NgoBL ngBL = new NgoBL();
    Project_Variables p_Val = new Project_Variables();
    Dictionary<string, string> Disv = new Dictionary<string, string>();
    ExportToExcel exportExcel = new ExportToExcel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                CheckStatus();
                bindExcutive();
                Displayworkperform();
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/auth/Adminpanel/Post/survey-details.aspx"));
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("~/auth/Adminpanel/Post/postngodetail.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
            
        }
    }
    #region Functiion for bind Excutive DropDown List
    public void bindExcutive()
    {
        int stateId = Convert.ToInt32(Request.QueryString["id"]);

        DataTable dt = NgoDal.bindworkperform(stateId);
        if (dt.Rows.Count > 0)
        {
            ddlexcutive.DataSource = dt;
            ddlexcutive.DataTextField = "ExecutiveName";
            ddlexcutive.DataValueField = "ID";
            ddlexcutive.DataBind();
            ddlexcutive.Items.Insert(0, new ListItem("Select", "0"));
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

                        if (e.CommandName == "Delete")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            ngObj.VillageID = Convert.ToInt32(e.CommandArgument);
                            p_Val.Result = ngBL.DeleteExcutive(ngObj);
                            if (p_Val.Result > 0)
                            {
                                Response.Redirect("~/auth/Adminpanel/Post/workperformlist.aspx?id=" + Request.QueryString["id"]);
                            }
                            // Displayworkperform();
                        }
                        if (e.CommandName == "Add")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            int workID = Convert.ToInt32(e.CommandArgument);
                            Response.Redirect("~/Auth/Adminpanel/Post/Addworkperform.aspx?id=" + workID + "&p=" + Request.QueryString["id"]);
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

                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField hddnfinalsubmit = (HiddenField)e.Row.FindControl("hddnfinalsubmit1");
                            Button imgedit = (Button)e.Row.FindControl("imgedit");
                            Button imgedit1 = (Button)e.Row.FindControl("imgedit1");
                            if (hddnfinalsubmit.Value == "1")
                            {
                                this.GvAdd_NGODetails.Columns[8].Visible = true;
                                this.GvAdd_NGODetails.Columns[7].Visible = true;
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
    public void Displayworkperform()
    {
        if (Request.QueryString["id"] != null)
        {
           
            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            if (ddlexcutive.SelectedValue.ToString() == "0" || ddlexcutive.SelectedValue.ToString() == "")
            {
                ngObj.NgoID = null;

            }
            else
            {
                ngObj.NgoID = Convert.ToInt32(ddlexcutive.SelectedValue.ToString());
            }
           
            p_Val.dSet = ngBL.workperform(ngObj);

            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                Disv.Add("HeaderState", p_Val.dSet.Tables[0].Rows[0]["StateName"].ToString());
                Disv.Add("HeaderVillage", p_Val.dSet.Tables[0].Rows[0]["PostVillageName"].ToString());
                Disv.Add("HeaderTiger Reserver", p_Val.dSet.Tables[0].Rows[0]["tigerReserveName"].ToString());

                GvAdd_NGODetails.DataSource = p_Val.dSet;
                GvAdd_NGODetails.DataBind();
                //if (Convert.ToInt16(p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
                //{
                //    divNGO.Visible = false;
                //}
            }
            else
            {
                //divNGO.Visible = true;
                GvAdd_NGODetails.DataSource = p_Val.dSet;
                GvAdd_NGODetails.DataBind();
            }

        }
    }
    #endregion
    protected void btnExecutive_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Post/WorkPerform.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Displayworkperform();
    }
    [WebMethod]
    public static string BindModelGridView(string ConversionID)
    {

        string response;
        NgoOB ngObj = new NgoOB();
        NgoBL ngBL = new NgoBL();
        Project_Variables p_Var = new Project_Variables();
        ngObj.SchemeID = Convert.ToInt32(ConversionID);
        p_Var.dSet = ngBL.workperform_History(ngObj);
        response = JsonConvert.SerializeObject(p_Var.dSet.Tables[0]);

        return response;
    }
    public void CheckStatus()
    {
        VillageDB Vill_BL = new VillageDB();
        TigerReserveOB _TigerReserveOB = new TigerReserveOB();
        _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
        p_Val.dSet = Vill_BL.CheckfinalStatus(_TigerReserveOB);
        if (p_Val.dSet.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
            {
                divNGO.Visible = true;
                btnexport.Visible = true;
            }
            else
            {
                divNGO.Visible = true;
                btnexport.Visible = false;
            }

        }
    }
    protected void GvAdd_NGODetails_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void btnexport_Click(object sender, EventArgs e)
    {

        Disv.Clear();
        Disv.Add("HeaderName", "Post Work performed under option (II) Details");

        exportExcel.excelImportstart(GvAdd_NGODetails, () => Displayworkperform(), Disv);
        Displayworkperform();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}
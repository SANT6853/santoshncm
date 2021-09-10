using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Post_ConversionScheme : System.Web.UI.Page
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
                bindScheme();
                DisplayScheme();
            }
        }

    }
    #region Functiion for bind Scheme DropDown List
    public void bindScheme()
    {
        int stateId = Convert.ToInt32(Request.QueryString["id"]);

       
        DataTable dt = NgoDal.bindScheme(stateId);
        if (dt.Rows.Count > 0)
        {
            ddlScheme.DataSource = dt;
            ddlScheme.DataTextField = "SchemeName";
            ddlScheme.DataValueField = "ConversionID";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    #endregion
    protected void btnScheme_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/Adminpanel/Post/AddConversionScheme.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void GV_Scheme_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            p_Val.Result = ngBL.DeleteScheme(ngObj);
                            if (p_Val.Result > 0)
                            {
                                Response.Redirect("~/auth/Adminpanel/Post/ConversionScheme.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
                            }
                            // Displayworkperform();
                        }
                        if (e.CommandName == "Add")
                        {
                            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                            int VillageID = Convert.ToInt32(e.CommandArgument);
                            Response.Redirect("~/auth/Adminpanel/Post/Addscheme.aspx?id=" + VillageID + "&s=" + Request.QueryString["id"]);
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
    
    protected void GV_Scheme_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hddnfinalsubmit = (HiddenField)e.Row.FindControl("hddnfinalsubmit");
            Button imgedit = (Button)e.Row.FindControl("imgedit");
            Button imgedit1 = (Button)e.Row.FindControl("imgedit1");
            if (hddnfinalsubmit.Value == "1")
            {

                this.GV_Scheme.Columns[8].Visible = false;
                this.GV_Scheme.Columns[7].Visible = false;
                //imgedit.Visible = false;
                //imgedit1.Visible = false;
            }

           
        }
    }
    public void DisplayScheme()
    {
        if (Request.QueryString["id"] != null)
        {
          
            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            if (ddlScheme.SelectedValue.ToString() == "0" || ddlScheme.SelectedValue.ToString() == "")
            {
                ngObj.NgoID = null;

            }
            else
            {
                ngObj.NgoID = Convert.ToInt32(ddlScheme.SelectedValue.ToString());
            }
            p_Val.dSet = ngBL.GetSchemeDetail(ngObj);

            if (p_Val.dSet.Tables[0].Rows.Count > 0)
            {
                Disv.Add("HeaderState", p_Val.dSet.Tables[0].Rows[0]["StateName"].ToString());
                Disv.Add("HeaderVillage", p_Val.dSet.Tables[0].Rows[0]["PostVillageName"].ToString());
                Disv.Add("HeaderTiger Reserver", p_Val.dSet.Tables[0].Rows[0]["tigerReserveName"].ToString());
                GV_Scheme.DataSource = p_Val.dSet;
                GV_Scheme.DataBind();
                //if (Convert.ToInt16(p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
                //{
                //    divNGO.Visible = false;
                //}
            }
            else
            {
                //divNGO.Visible = true;
                GV_Scheme.DataSource = p_Val.dSet;
                GV_Scheme.DataBind();
            }

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DisplayScheme();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/Adminpanel/Post/workperformlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    [WebMethod]
    public static string BindModelGridView(string ConversionID)
    {

        string response;
        NgoOB ngObj = new NgoOB();
        NgoBL ngBL = new NgoBL();
        Project_Variables p_Var = new Project_Variables();
        ngObj.SchemeID = Convert.ToInt32(ConversionID);
        p_Var.dSet = ngBL.ConverSionScheme_History(ngObj);
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
    protected void GV_Scheme_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void btnexport_Click(object sender, EventArgs e)
    {

        Disv.Clear();
        Disv.Add("HeaderName", "Post Scheme Details");
       
        exportExcel.excelImportstart(GV_Scheme, ()=>DisplayScheme(), Disv);
        DisplayScheme();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}
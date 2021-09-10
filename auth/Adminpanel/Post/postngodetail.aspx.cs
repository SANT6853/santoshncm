using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Post_postngodetail : System.Web.UI.Page
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
                bindNGO();
                DisplayNGODetail();
            }
        }
    }
    protected void btnAddNGO_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Post/postngo.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DisplayNGODetail();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        
     Response.Redirect("~/auth/Adminpanel/Post/post-preview.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
            
    }
    #region Functiion for bind NGO DropDown List
    public void bindNGO()
    {
        NgoDal ngoDL = new NgoDal();
        int stateId = Convert.ToInt32(Request.QueryString["id"]);
        p_Val.dSet = ngoDL.BindPostNGO(stateId);
        if (p_Val.dSet.Tables[0].Rows.Count > 0)
        {
            ddlNGO.DataSource = p_Val.dSet;
            ddlNGO.DataTextField = "NGO_NAME";
            ddlNGO.DataValueField = "NGO_ID";
            ddlNGO.DataBind();
            ddlNGO.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    #endregion
    protected void GvAdd_NGODetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            ngObj.VillageID = Convert.ToInt32(e.CommandArgument);
            p_Val.Result = ngBL.DeletePostNGO(ngObj);
            DisplayNGODetail();
        }
        if(e.CommandName=="Add")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int NGOID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/auth/Adminpanel/Post/addpostngo.aspx?id=" + NGOID + "&n=" + Convert.ToInt32(Request.QueryString["id"]));
        }
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
                this.GvAdd_NGODetails.Columns[9].Visible = false;
				this.GvAdd_NGODetails.Columns[10].Visible = false;
                //this.GV_Scheme.Columns[7].Visible = false;
            }
        }
    }
    protected void GvAdd_NGODetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    #region function for bind NGO Detail
    public void DisplayNGODetail()
    {
        if (Request.QueryString["id"] != null)
        {
           
            ngObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            if (ddlNGO.SelectedValue.ToString() == "0" || ddlNGO.SelectedValue.ToString() == "")
            {
                ngObj.NgoID = null;

            }
            else
            {
                ngObj.NgoID = Convert.ToInt32(ddlNGO.SelectedValue.ToString());
            }
            p_Val.dSet = ngBL.getPostNGODetails(ngObj);

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
                divNGO.Visible = true;
                GvAdd_NGODetails.DataSource = p_Val.dSet;
                GvAdd_NGODetails.DataBind();
            }

        }
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
        response = JsonConvert.SerializeObject(p_Var.dSet.Tables[0]);

        return response;
    }
    #endregion
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
                divNGO.Visible = false;
                btnexport.Visible = true;
            }
            else
            {
                divNGO.Visible = true;
                btnexport.Visible = false;
            }

        }
    }
    protected void GvAdd_NGODetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnexport_Click(object sender, EventArgs e)
    {

        Disv.Clear();
        Disv.Add("HeaderName", "Post NGO Management Details");
        Disv.Add("Hide1", "8");
        exportExcel.excelImportstart(GvAdd_NGODetails, () => DisplayNGODetail(), Disv);
        DisplayNGODetail();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}

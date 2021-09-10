using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Post_post_preview : System.Web.UI.Page
{

    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    VillageDB Vill_BL = new VillageDB();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
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
                BindSurveyDetail();

            }
        }
    }
    #region Function for SurveyDetail
    public void BindSurveyDetail()
    {
        
        _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
        P_var.dSet = Vill_BL.PostPrivew(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GVSurvey_Details.DataSource = P_var.dSet;
            GVSurvey_Details.DataBind();
        }
    }
    #endregion
    protected void linkFamily_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/survey.aspx?id=" + Vill_ID + "&p=2");
    }
    protected void btnScheme_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/ConversionScheme.aspx?id=" + Vill_ID);
    }
    protected void btnWorkperform_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/workperformlist.aspx?id=" + Vill_ID);
    }
    protected void btnNGO_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/postngodetail.aspx?id=" + Vill_ID);
    }
    protected void GVSurvey_Details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Map")
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/auth/Adminpanel/Map/Post.aspx?id=" + id);
        }
    }
    protected void GVSurvey_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnFinalSubmit_Click(object sender, EventArgs e)
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
                        //_TigerReserveOB.Action = 1;
                        //_TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
                        //P_var.Result = Vill_BL.finalSubmit(_TigerReserveOB);
                        //if(P_var.Result>0)
                        //{
                        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').modal('show');", true);
                        //}
                        Response.Redirect(ResolveUrl("~/auth/Adminpanel/Post/survey-details.aspx"));

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
    
    public void CheckStatus()
    {
        _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
        P_var.dSet = Vill_BL.CheckfinalStatus(_TigerReserveOB);
        if(P_var.dSet.Tables[0].Rows.Count>0)
        {
            if (Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["FinalSubmit"])==1)
            {
                divfinal.Visible = true;
            }
            else
            {
                divfinal.Visible = true;
            }
            
        }
    }
    protected void btnnextstep_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Post/survey-details.aspx");
    }
}
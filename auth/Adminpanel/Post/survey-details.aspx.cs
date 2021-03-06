using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Post_survey_details :CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    VillageDB Vill_BL = new VillageDB();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    ExportToExcel exportExcel = new ExportToExcel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
            {
                Session.Abandon();
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                {
                    divAddOption.Visible = false;
                    divState.Visible = false;
                    
                }
                
                BindStateName();
                BindVillage();
                BindTigerreserve();
                BindSurveyDetail(1);
            }
            
          if(Request.QueryString["ConsoldateStateName"] !=null)
            {
                btnexport.Visible = true;
                getconsolidatedata();
            }
            else
            {
                btnexport.Visible = false;
            }
            if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3")|| Session["UserType"].ToString().Equals("4"))
            {
                ddlstate.SelectedValue= Session["sStateID"].ToString();
                ddlstate.Attributes.Add("disabled", "disabled");
                BindTigerreserve();
                BindSurveyDetail(1);
            }

        }
    }
    #region Function for Bind Village
    public void BindVillage()
    {
        int ID=0;
        if (Convert.ToInt32(Session["ntca_TigerReserveid"]) != 0)
        {
             ID = Convert.ToInt32(Session["ntca_TigerReserveid"]);
        }
        else
        {
            if (ddlTigerReserve.SelectedValue !="")
            {
                ID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
            }
        }
     
        P_var.dSet = Vill_BL.BindVillagesurvey(ID);
        
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlVillage.DataSource = P_var.dSet.Tables[0];
            ddlVillage.DataTextField = "VILL_NM";
            ddlVillage.DataValueField = "VILL_ID";
            ddlVillage.DataBind();

            ddlVillage.Items.Insert(0, new ListItem("Select Village", "0"));
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    #region Function for  Bind State Name
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
     
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlstate.DataSource = P_var.dSet.Tables[0];
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "id";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    #endregion
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

                        Label lblAction = (Label)e.Row.FindControl("lblAction");
                        ImageButton ibEdit = (ImageButton)e.Row.FindControl("ibEdit");
                        LinkButton stateApprove = (LinkButton)e.Row.FindControl("stateApprove");
                        HiddenField hddnActionNTCA = (HiddenField)e.Row.FindControl("hddnActionNTCA");
                        LinkButton stateApproveNTCA = (LinkButton)e.Row.FindControl("stateApproveNTCA");
                        Label lblActionNTCA = (Label)e.Row.FindControl("lblActionNTCA");
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {

                            if (lblAction.Text == "Submitted")
                            {
                                lblAction.ForeColor = Color.Green;
                                stateApprove.Visible = false;
                                lblAction.ForeColor = Color.Green;
                                lblAction.Text = "Submitted/Approved";
                            }

                            else
                            {
                                lblAction.ForeColor = Color.Red;
                                if (Session["UserType"].ToString().Equals("2"))
                                {
                                    lblAction.Visible = false;
                                }
                                else
                                {
                                    stateApprove.Visible = false;
                                    lblAction.Visible = true;
                                }

                            }

                            if (hddnActionNTCA.Value == "1")
                            {
                                lblActionNTCA.Text = "Approved By NTCA";
                                lblActionNTCA.ForeColor = Color.Green;
                                stateApproveNTCA.Visible = false;
                            }
                            else
                            {
                                if (Session["UserType"].ToString().Equals("1"))
                                {
                                    lblActionNTCA.Visible = false;
                                    stateApproveNTCA.Visible = true;
                                }
                                else
                                {
                                    lblActionNTCA.Text = "Pending";
                                    stateApproveNTCA.Visible = false;
                                    lblActionNTCA.ForeColor = Color.Red;
                                }
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
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindSurveyDetail(1);
        if (Request.QueryString["ConsoldateStateName"] != null)
        {
            BindSurveyDetail(2);
        }
    }

    #region Function for SurveyDetail
    public void BindSurveyDetail(int Flag=1)
    {
        if(Convert.ToInt32(ddlVillage.SelectedValue) !=0)
        {
            _TigerReserveOB.VillageID = Convert.ToInt32(ddlVillage.SelectedValue);
        }
        else
        {
            _TigerReserveOB.VillageID = null;
        }
        if(ddlstate.SelectedValue !="0")
        {
            _TigerReserveOB.sVillageID = ddlstate.SelectedValue.ToString();
        }
        else
        {
            _TigerReserveOB.sVillageID = null;
        }
        if (ddlTigerReserve.SelectedValue != "0")
        {
            if (ddlTigerReserve.SelectedValue != "")
            {
                _TigerReserveOB.TigerReserveid = Convert.ToInt32(ddlTigerReserve.SelectedValue);
            }
            else
            {
                _TigerReserveOB.TigerReserveid = null;
            }
          
        }
        else
        {
            _TigerReserveOB.TigerReserveid = null;
        }
        _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);
        _TigerReserveOB.flag = Flag;
        if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("4"))
        {
            if (Session["sStateID"] != null)
            {
                _TigerReserveOB.sVillageID = Session["sStateID"].ToString();
            }
        }
            
         P_var.dSet = Vill_BL.GetPostSurveyDetail(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GVSurvey_Details.DataSource = P_var.dSet;
            GVSurvey_Details.DataBind();
        }
        else
        {
            GVSurvey_Details.DataSource = null;
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
    protected void stateApprove_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        Label lblAction = btnStatus.NamingContainer.FindControl("lblAction") as Label;
        LinkButton stateApprove = btnStatus.NamingContainer.FindControl("stateApprove") as LinkButton;
        int PostVill_ID =Convert.ToInt32(btnStatus.CommandArgument);
        if (ApproveByState(PostVill_ID, 2))
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Approved successfully!');", true);
            stateApprove.Visible = false;
            lblAction.Visible = true;
            lblAction.Text = "Approved by state";
            lblAction.ForeColor = Color.Green;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sorry Approve Is NOt Completed!');", true);
        }
        

    }

    protected void stateApproveNTCA_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        Label lblAction = btnStatus.NamingContainer.FindControl("lblActionNTCA") as Label;
        LinkButton stateApprove = btnStatus.NamingContainer.FindControl("stateApproveNTCA") as LinkButton;       
        string[] allcommand = btnStatus.CommandArgument.ToString().Split(',');
        string chechFinal = allcommand[1].Trim().ToLower(); ;
        int PostVill_ID = Int32.Parse(allcommand[0]);
        if (chechFinal != "submitted")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('State is not Approve It!!');", true);
        }
        else if (ApproveByNTCA(PostVill_ID, 2))
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Approved successfully!');", true);
            stateApprove.Visible = false;
            lblAction.Visible = true;
            lblAction.Text = "Approved by NTCA";
            lblAction.ForeColor = Color.Green;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sorry Approve Is NOt Completed!');", true);
        }


    }

    protected void btnNGO_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/postngodetail.aspx?id=" + Vill_ID);
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerreserve();
    }
    protected void ddltigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillage();
    }
    #region Function for Bind Tiger reserve
    public void BindTigerreserve()
    {
       
        if (ddlstate.SelectedValue != "0")
        {
            _TigerReserveOB.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        }
        else
        {
            if (Session["UserType"].ToString().Equals("2"))
            {
                _TigerReserveOB.StateID = Convert.ToInt32(Session["ntca_StateID"]);
            }
            else
            {
                _TigerReserveOB.StateID = null;
            }
            
        }
        if(Session["UserType"].ToString().Equals("3"))
        {
             _TigerReserveOB.TigerReserveid = Convert.ToInt32(Session["ntca_TigerReserveid"]);
        }
        else
        {
            _TigerReserveOB.TigerReserveid = null;
        }
        DataSet ds = new VillageDB().GetTigerReserve(_TigerReserveOB);
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlTigerReserve.DataSource = ds.Tables[0];
            ddlTigerReserve.DataTextField = "TigerReserveName";
            ddlTigerReserve.DataValueField = "TigerReserveid";
            ddlTigerReserve.DataBind();
            ddlTigerReserve.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlTigerReserve.Items.Clear();
            ddlTigerReserve.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    protected void btnWorkperform_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/workperformlist.aspx?id=" + Vill_ID);
    }

    private void getconsolidatedata()
    {
        divAddOption.Visible = false;
        ddlstate.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
        ddlstate.Attributes.Add("disabled", "disabled");
        BindTigerreserve();
        BindSurveyDetail(2);

    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        
        Dictionary<string, string> Disv = new Dictionary<string, string>();
        Disv.Add("HeaderName", "Post Survey Details");
        Disv.Add("Hide1", "10");
        Disv.Add("Hide2", "11");
        Disv.Add("Hide3", "12");
        exportExcel.excelImportstart(GVSurvey_Details,()=>BindSurveyDetail(2), Disv);
        BindSurveyDetail(2);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private bool ApproveByState(int id,int flag)
    {
        VillageEntity VillEntity_Obj = new VillageEntity();
        VillageDB VillDB_Obj = new VillageDB();
        VillEntity_Obj.VillageID = id;
        VillEntity_Obj.flag = flag;
        return VillDB_Obj.ChangeStatusByState(VillEntity_Obj);
    }
    private bool ApproveByNTCA(int id, int flag)
    {
        VillageEntity VillEntity_Obj = new VillageEntity();
        VillageDB VillDB_Obj = new VillageDB();
        VillEntity_Obj.VillageID = id;
        VillEntity_Obj.flag = flag;
        return VillDB_Obj.ChangeStatusByNTCA(VillEntity_Obj);
    }

    protected void GVSurvey_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSurvey_Details.PageIndex = e.NewPageIndex;
        BindSurveyDetail(1);
        if (Request.QueryString["ConsoldateStateName"] != null)
        {
            BindSurveyDetail(2);
        }

    }
}
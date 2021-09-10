using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_form_preview : System.Web.UI.Page
{
    Project_Variables p_Val = new Project_Variables();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayFinalSubmit();
        }
    }
    protected void btnFinalSubmit_Click(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(Request.QueryString["id"]) != null)
        //{


        //   //  p_Val.Result = _tigerReserverBl.FinalSubmit(_TigerReserveOB);
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').show(); $('#myModal').modal('show');", true);

        //}

        Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx"));
    }
    protected void GvAdd_NGODetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
       
    }
    protected void GvAdd_NGODetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void DisplayFinalSubmit()
    {
        if (Convert.ToInt32(Request.QueryString["id"]) != null)
        {

            Project_Variables p_Val = new Project_Variables();
            TigerReserveBL _tigerReserverBl = new TigerReserveBL();
            TigerReserveOB _TigerReserveOB = new TigerReserveOB();
            _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
            _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);
             p_Val.dSet = _tigerReserverBl.PriviewRecord(_TigerReserveOB);
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
             if (Convert.ToInt32(p_Val.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
             {
                 divfinal.Visible = true;
             }
             else
             {
                 if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                 {
                     divfinal.Visible = true;
                 }
                 else
                 {
                     divfinal.Visible = true;
                 }
                 
             }
        }
    }
    protected void linkFamily_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=" + Vill_ID);
    }
    protected void btnServey_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/adminpanel/ProcessManegment/DfoUser/AddProcessDFO.aspx?id=" + Vill_ID);
    }
    protected void btnNGO_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/NGO/ngolistaspx.aspx?id=" + Vill_ID);
    }
    protected void btnFund_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Vill_ID);

    }
    protected void linkVillage_Click(object sender, EventArgs e)
    {
        
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management_Edit.aspx?village_id=" + Vill_ID + "&inid=0&vcode=0&vname=0");
    }
    protected void btnnextstep_Click(object sender, EventArgs e)
    {
        _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
        _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);
        p_Val.Result = _tigerReserverBl.FinalSubmit(_TigerReserveOB);
        if (p_Val.Result > 0)
        {
            Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
        }
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_CDPManagement_AddCDP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["village"] != null)
            {
                DisplayVillageDetails(Convert.ToInt16(Request.QueryString["village"]));
            }
        }
    }
    public void DisplayVillageDetails(int villid)
    {
        Project_Variables p_Var = new Project_Variables();
        VillageBL villBL = new VillageBL();
        VillageOB villObject = new VillageOB();
        villObject.Villageid = villid;
        p_Var.dSet = villBL.Get_VillageDetailsCDP(villObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            lblstatename.Text = p_Var.dSet.Tables[0].Rows[0]["StateName"].ToString();
            lblreaserve.Text= p_Var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
            lbldistrict.Text = p_Var.dSet.Tables[0].Rows[0]["DistName"].ToString();
            lbltehsil.Text = p_Var.dSet.Tables[0].Rows[0]["Tehsil_Name"].ToString();
            lblgp.Text = p_Var.dSet.Tables[0].Rows[0]["GramPanchayatName"].ToString();
            lblvillname.Text= p_Var.dSet.Tables[0].Rows[0]["Village_Name"].ToString();
        }
        else
        {

        }
    }




    public void BindMembers()
    {
       
    }

    public void ResetAllFields()
    {
        Textcdpwork.Text = "";
        txtalltdamt.Text = "";
        txtamtusd.Text = "";
        txtagency.Text = "";
        txtcomment.Text = "";
        //txtsite.Text = "";


    }


    protected void gvForwork_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvForwork_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

    }
    protected void gvForwork_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    public void ShowCDPWrokData(int cdpwrkid1)
    {
       
    }


    protected void imgbtnaddwork_Click(object sender, EventArgs e)
    {
        

    }
    protected void imgbtncancel_Click(object sender, EventArgs e)
    {
       
    }
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
       
    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {
       
    }

    protected void ImgbtnCancel1_Click(object sender, EventArgs e)
    {
        ddlselectstatus.SelectedValue = "0";
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
      
    }
    protected void imgbtnpopupwork_Click(object sender, EventArgs e)
    {
       
    }
}
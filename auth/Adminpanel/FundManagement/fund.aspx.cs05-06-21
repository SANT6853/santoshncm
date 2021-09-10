using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FundManagement_fund : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // txtAmount.Enabled = false;
           // btnBack.Visible = true;
            NGORecord();
            DisplayFundAmount();
            DisplayFundAmount1();
            //AddFundAmount();
        }
    }
    public void NGORecord()
    {

        Project_Variables p_Var = new Project_Variables();
        TigerReserveBL _tigerReserverBl = new TigerReserveBL();
        TigerReserveOB _TigerReserveOB = new TigerReserveOB();
        int Vill_ID = Convert.ToInt32(Request.QueryString["id"]);
        p_Var.dSet = _tigerReserverBl.BindPreStates(Vill_ID);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            if(p_Var.dSet.Tables[0].Rows[0]["SCHM_ID"].ToString()=="3")
            {
                txtAmount.Enabled = false;
            }
            ViewState["amount"] = "";
            txtStateName.Text = p_Var.dSet.Tables[0].Rows[0]["StateName"].ToString();
            txtTigerReserve.Text = p_Var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
            txtDistrict.Text = p_Var.dSet.Tables[0].Rows[0]["DistName"].ToString();
            txtVillage.Text = p_Var.dSet.Tables[0].Rows[0]["VILL_NM"].ToString();
            //txtAmount.Text = p_Var.dSet.Tables[0].Rows[0]["fundamount"].ToString();
            ViewState["amount"] = p_Var.dSet.Tables[0].Rows[0]["fundamount"].ToString();  
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Project_Variables p_Var = new Project_Variables();
        TigerReserveBL TigerBL = new TigerReserveBL();
        TigerReserveOB TigerObj = new TigerReserveOB();
        if (Convert.ToInt32(Request.QueryString["id"]) != null)
        {
            if (Convert.ToInt32(Request.QueryString["vid"]) == 0)
            {
                TigerObj.Action = 0;
                TigerObj.EditedUserID = null;
                TigerObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
                TigerObj.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);
                //TigerObj.AcceptedAmount = Convert.ToDouble(txtAmount.Text);
                TigerObj.CommentedRemarks = txtRemarks.Text.Trim();
                double amount = 0.00;
                double amount2 = 0.00;
                if (!string.IsNullOrEmpty(txtAmount.Text))
                {
                    amount = Convert.ToDouble(txtAmount.Text);
                }
                else
                {
                    amount = 0.00;
                }

                if (!string.IsNullOrEmpty(txtAmount2.Text))
                {
                    amount2 = Convert.ToDouble(txtAmount2.Text);
                }
                else
                {
                    amount2 = 0.00;
                }
                TigerObj.AcceptedAmount = amount + amount2;
                p_Var.Result = TigerBL.FundManagement(TigerObj);
                if (p_Var.Result > 0)
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Request.QueryString["id"]);
                }
            }
            else
            {
                TigerObj.EditedUserID = Convert.ToInt32(Request.QueryString["vid"]);
                TigerObj.Action = 1;
                TigerObj.VillageID = Convert.ToInt32(Request.QueryString["id"]);
                TigerObj.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);
                double amount = 0.00;
                double amount2 = 0.00;
                if (!string.IsNullOrEmpty(txtAmount.Text))
                {
                    amount = Convert.ToDouble(txtAmount.Text);
                }
                else
                {
                    amount = 0.00;
                }

                if (!string.IsNullOrEmpty(txtAmount2.Text))
                {
                    amount2 = Convert.ToDouble(txtAmount2.Text);
                }
                else
                {
                    amount2 = 0.00;
                }
                TigerObj.AcceptedAmount = amount + amount2;
                TigerObj.CommentedRemarks = txtRemarks.Text.Trim();
                p_Var.Result = TigerBL.FundManagement(TigerObj);
                if (p_Var.Result > 0)
                {
                    Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Request.QueryString["id"]);
                }
            }
            
        }

    }
    public void AddFundAmount()
    {
        if (Convert.ToInt32(Request.QueryString["vid"]) != null)
        {
            btnBack.Visible = true;
            Project_Variables p_Var = new Project_Variables();
            TigerReserveBL _tigerReserverBl = new TigerReserveBL();
            TigerReserveOB _TigerReserveOB = new TigerReserveOB();
            int Vill_ID = Convert.ToInt32(Request.QueryString["vid"]);
            p_Var.dSet = _tigerReserverBl.GetFund(Vill_ID);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                txtAmount.Text = p_Var.dSet.Tables[0].Rows[0]["FundAmount"].ToString();
                txtRemarks.Text = p_Var.dSet.Tables[0].Rows[0]["FunDescription"].ToString();
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/Adminpanel/FundManagement/fundlist.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }

    //protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    VillageEntity villageObject = new VillageEntity();
    //    VillageDB villageBL = new VillageDB();
    //    Project_Variables p_Var = new Project_Variables();
    //    villageObject.CmnStateID = Convert.ToInt16(Request.QueryString["id"]);
    //    villageObject.Action = Convert.ToInt16(ddltype.SelectedValue);
    //    p_Var.dSet = villageBL.Display_FundAmoutAsPerOptions(villageObject);
    //    if (p_Var.dSet.Tables.Count > 0)
    //    {
    //        if (p_Var.dSet.Tables[0].Rows.Count > 0)
    //        {
    //            txtAmount.Text = p_Var.dSet.Tables[0].Rows[0]["OptionWiseAmount"].ToString();
    //        }
    //        else
    //        {
    //            txtAmount.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        txtAmount.Text = "";
    //    }
    //}

    #region Function to display amount as per options

    public void DisplayFundAmount()
    {
        VillageEntity villageObject = new VillageEntity();
        VillageDB villageBL = new VillageDB();
        Project_Variables p_Var = new Project_Variables();
        villageObject.CmnStateID = Convert.ToInt16(Request.QueryString["id"]);
        villageObject.Action = Convert.ToInt16(ddltype.SelectedValue);
        p_Var.dSet = villageBL.Display_FundAmoutAsPerOptions(villageObject);
        if (p_Var.dSet.Tables.Count > 0)
        {
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                txtAmount.Text = p_Var.dSet.Tables[0].Rows[0]["OptionWiseAmount"].ToString();
            }
            else
            {
                txtAmount.Text = "";
            }
        }
        else
        {
            txtAmount.Text = "";
        }
    }

    #endregion

    #region Function to display amount as per options

    public void DisplayFundAmount1()
    {
        VillageEntity villageObject = new VillageEntity();
        VillageDB villageBL = new VillageDB();
        Project_Variables p_Var = new Project_Variables();
        villageObject.CmnStateID = Convert.ToInt16(Request.QueryString["id"]);
        villageObject.Action = Convert.ToInt16(ddlType2.SelectedValue);
        p_Var.dSet = villageBL.Display_FundAmoutAsPerOptions(villageObject);
        if (p_Var.dSet.Tables.Count > 0)
        {
           if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                txtAmount2.Text = p_Var.dSet.Tables[0].Rows[0]["OptionWiseAmount"].ToString();
               
            }
            else
            {
                txtAmount2.Text = "";
            }
            if (p_Var.dSet.Tables[1].Rows.Count > 0)
            {
                txtRemarks.Text = p_Var.dSet.Tables[1].Rows[0]["FunDescription"].ToString();
            }
            else
            {
                txtRemarks.Text = "";
            }
                
        }
        else
        {
            txtAmount2.Text = "";
        }
    }

    #endregion

}
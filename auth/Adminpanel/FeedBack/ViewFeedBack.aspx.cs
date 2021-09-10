using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FeedBack_ViewFeedBack : System.Web.UI.Page
{
    #region Data declaration zone
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    ContentOB contentObject = new ContentOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    Project_Variables p_Var = new Project_Variables();
    FeedBackBL objFeedbkBL = new FeedBackBL();
    string LoginUserid;
    int LoginUsertype;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3") )
            {
                DdlType.Items.Remove(DdlType.Items.FindByValue("9"));
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindFeedBackGrid();
            }
            else
            {
                DdlType.SelectedValue = "11";
                DdlType.Enabled = false;
                Reservesub.Visible = true;
                BindFeedBackGridReserveState();
                grdFeedback.Columns[5].Visible = false;
                divTpe.Visible = false;
            }
            //}
        }
    }
    public void BindFeedBackGrid()
    {
        try
        {


            p_Var.dSet = null;
           
            if(DdlType.SelectedValue!="0")
            {
                contentObject.ModuleID = Convert.ToInt16(DdlType.SelectedValue);
                p_Var.dsFileName = objFeedbkBL.GetFeedBackData(contentObject);
            }
            if (DdlNtcaSub.SelectedValue != "0")
            {
                contentObject.FeedBackFrom = Convert.ToInt16(DdlNtcaSub.SelectedValue);
                p_Var.dsFileName = objFeedbkBL.GetFeedBackData(contentObject);
            }
            if (DdlTigerreserSub.SelectedValue != "0")
            {
                contentObject.FeedBackFrom = Convert.ToInt16(DdlTigerreserSub.SelectedValue);
                p_Var.dsFileName = objFeedbkBL.GetFeedBackData1(contentObject);
            }
            if (DdlType.SelectedValue == "0")
            {
                p_Var.dsFileName = objFeedbkBL.GetFeedBackData(contentObject);
            }
           
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {

                grdFeedback.DataSource = p_Var.dsFileName;
                grdFeedback.DataBind();
                p_Var.dSet = null;


            }

        }


        catch
        {
            throw;
        }
    }
    public void BindFeedBackGridReserveState()
    {
        try
        {


            p_Var.dSet = null;

            if (DdlType.SelectedValue != "0")
            {
                contentObject.ModuleID = Convert.ToInt16(DdlType.SelectedValue);
            }

            p_Var.dsFileName = objFeedbkBL.GetFeedBackDataReserveState(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {

                grdFeedback.DataSource = p_Var.dsFileName;
                grdFeedback.DataBind();
                p_Var.dSet = null;


            }

        }


        catch
        {
            throw;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindFeedBackGrid();
      
    }
    protected void grdFeedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdFeedback.PageIndex = e.NewPageIndex;
        if (Session["UserType"].ToString().Equals("1"))
        {
            BindFeedBackGrid();
        }
        else
        {
            BindFeedBackGridReserveState();
        }
       // BindFeedBackGrid();
    }
    protected void grdFeedback_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Delete")
        {

            contentObject.FeedBackID = id;

            int del = objFeedbkBL.DelFeedback(contentObject);
            if (del > 0)
            {
                Session["msg"] = "feedback data has been deleted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/FeedBack/ViewFeedBack.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "feedback data has not been deleted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/FeedBack/ViewFeedBack.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
        }
      
        if (e.CommandName == "AD")
        {
            objntcauser.FeedBackFormID = id;
            int recordcount = _Userbl.UpdateActiveDeaActiveTigerReserveFeedback(objntcauser);
        }
      //  BindFeedBackGrid();
        if (Session["UserType"].ToString().Equals("1"))
        {
            BindFeedBackGrid();
        }
        else
        {
            BindFeedBackGridReserveState();
        }
    }
    protected void grdFeedback_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdFeedback_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkAd = (LinkButton)e.Row.FindControl("LnkActiveDeaActive");
            if (lnkAd.Text.Trim() == "1")
            {

                lnkAd.Text = "Disposed";
                //DeaActive
            }
            else
            {

                lnkAd.Text = "Received";
                //Active
            }
            //lnkViewDetailss
            LinkButton lnkViewDetailssss = (LinkButton)e.Row.FindControl("lnkViewDetailss");

            string username =".Name:" +lnkViewDetailssss.Text;

            string ActiveD = string.Empty;
            if(lnkAd.Text=="Disposed")
            {
                ActiveD = "Received";
            }
            if (lnkAd.Text == "Received")
            {
                ActiveD = "Disposed";
            }
          
            lnkAd.OnClientClick = "return confirm('Are you sure want to change status " + ActiveD + " " + username + " ');";
            
        }
    }
    protected void DdlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DdlType.SelectedValue=="9")
        {
            Ntcasub.Visible = true;
            Reservesub.Visible = false;
        }
        if (DdlType.SelectedValue == "11")
        {
            Ntcasub.Visible = false;
            Reservesub.Visible = true;
        }
        if (DdlType.SelectedValue == "0")
        {
            Ntcasub.Visible = false;
            Reservesub.Visible = false;
        }
       
    }
}
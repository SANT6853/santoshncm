using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Enterform_VillageAreaDisplay :CrsfBase
{
    #region Data declaration zone
    NtcaUserOB _ntcauserob = new NtcaUserOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    VillageOB villageObject = new VillageOB();
    VillageBL villageBL = new VillageBL();
    Project_Variables p_Var = new Project_Variables();
    Commanfuction _commanfucation=new Commanfuction();
    PaginationBL pagingBL = new PaginationBL();
    Miscelleneous_BL miscellBL=new Miscelleneous_BL();
    string LoginUserid;
    int LoginUsertype;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        LoginUserid = m.Id;
        LoginUsertype = m.UserType;
        if (!IsPostBack)
        {
            Bind_State();
            Bind_TigerReserve();
            DisplayVillageInGrid(1);
            DisplayNGOInGrid(1);
        }
    }

  
    void Bind_State()
    {
        _ntcauserob.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(_ntcauserob);
        ddlstate.DataSource = p_Var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype==1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
            
        }
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind_TigerReserve();
    }
    private void Bind_TigerReserve()
    {
        _ntcauserob.State = Convert.ToInt32(ddlstate.SelectedValue);
        _ntcauserob.UserID=Convert.ToInt32(LoginUserid);
        _ntcauserob.UserType= Convert.ToInt32(LoginUsertype);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(_ntcauserob);
        ddltigerreserve.DataSource = p_Var.dSet;
        ddltigerreserve.DataTextField = "TigerReserveName";
        ddltigerreserve.DataValueField = "TigerReserveid";
        ddltigerreserve.DataBind();
        ddltigerreserve.Items.Insert(0, new ListItem("Select Tiger Reserve", "0"));
    }

    void Bind_NGOState()
    {
        _ntcauserob.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(_ntcauserob);
        ddlNGOState.DataSource = p_Var.dSet;
        ddlNGOState.DataTextField = "StateName";
        ddlNGOState.DataValueField = "id";
        ddlNGOState.DataBind();
        if (LoginUsertype == 1)
        {
            ddlNGOState.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }

    private void Bind_NGOTigerReserve()
    {
        ddlNGOTigerReserve.Items.Clear();
        _ntcauserob.State = Convert.ToInt32(ddlNGOState.SelectedValue);
        _ntcauserob.UserID = Convert.ToInt32(LoginUserid);
        _ntcauserob.UserType = Convert.ToInt32(LoginUsertype);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(_ntcauserob);
        ddlNGOTigerReserve.DataSource = p_Var.dSet;
        ddlNGOTigerReserve.DataTextField = "TigerReserveName";
        ddlNGOTigerReserve.DataValueField = "TigerReserveid";
        ddlNGOTigerReserve.DataBind();
        ddlNGOTigerReserve.Items.Insert(0, new ListItem("Select Tiger Reserve", "0"));
    }


    private void DisplayVillageInGrid(int pageindex)
    {
        if (Convert.ToInt32(ddlstate.SelectedValue) != 0)
        {
            villageObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        }
        else
        {
            villageObject.StateID = null;
        }

        if (Convert.ToInt32(ddltigerreserve.SelectedValue) != 0)
        {
            villageObject.TigerReserveid = Convert.ToInt32(ddltigerreserve.SelectedValue);
        }
        else
        {
            villageObject.TigerReserveid = null;
        }
      
        
        villageObject.Pageindex = pageindex;
        villageObject.PageSize =Convert.ToInt32(ddlPageSize.SelectedValue);
        p_Var.dSet=villageBL.getVillageList(villageObject);
       
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            p_Var.count = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["TotalRecord"].ToString());
            pagingBL.Paging_Show(p_Var.count, pageindex, ddlPageSize, rptPager);
            rptPager.Visible = true;
            gvVillage.DataSource = p_Var.dSet;
            gvVillage.DataBind();

            divGrid.Visible = true;
           
            divPager.Visible = true;
           
            p_Var.dSet = null;
           

        }
        else
        {
            divGrid.Visible = false;
            divPager.Visible = false;
        }

    }
    protected void lnkPage_Click(object sender, EventArgs e)
    {
        int index = int.Parse((sender as LinkButton).CommandArgument);
        this.DisplayVillageInGrid(index);
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
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
                        DisplayVillageInGrid(1);
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



    protected void OnSelectedIndexChanged_PageSizeChanged(object sender, EventArgs e)
    {
        DisplayVillageInGrid(1);
    }

    protected void gvVillage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvVillage_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.gvVillage.HeaderRow.FindControl("chkSelectAll");
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));
        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
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
                        ChkApprove_Disapprove();
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



    #region Function to approve the photo category

    public void ChkApprove_Disapprove()
    {
        PhotoGalleryBL categorydataBL = new PhotoGalleryBL();
        foreach (GridViewRow row in gvVillage.Rows)
        {
            CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
            if ((selCheck.Checked == true))
            {
                int tmpVillageID = Convert.ToInt32(gvVillage.DataKeys[row.RowIndex].Value);

                villageObject.TempVillageID = tmpVillageID;
                villageObject.UserID = Convert.ToInt16(LoginUserid);
                villageObject.IpAddress = miscellBL.IpAddress();
                p_Var.Result = villageBL.InsertVillageDetailsInWeb(villageObject);
            }
        }
        if (p_Var.Result > 0)
        {
            Session["msg"] = "Village Details has been Updated successfully.";
            Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
            Response.Redirect("~/auth/adminpanel/ConfirmationPage.aspx");
        }
    }

    #endregion

    protected void btnAssocateNGO_Click(object sender, EventArgs e)
    {
        mpAssociateNGO.Show();
        Bind_NGOState();
        Bind_NGOTigerReserve();
        //ddlNGOTigerReserve.Items.Insert(0, new ListItem("Select Tiger Reserve", "0"));
        ddlVillage.Items.Insert(0, new ListItem("Select Village", "0"));
        ddlNGO.Items.Insert(0, new ListItem("Select NGO", "0"));
        //
        //insertVillageEntry();
    }

    #region Function to display village

    private void displayVillageinDropdownlist()
    {
        villageObject.TigerReserveid = Convert.ToInt32(ddlNGOTigerReserve.SelectedValue);
        p_Var.dSet = villageBL.getVillageName(villageObject);

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlVillage.DataSource = p_Var.dSet;
            ddlVillage.DataTextField = "village_name";
            ddlVillage.DataValueField = "villageid";
            ddlVillage.DataBind();
            ddlVillage.Items.Insert(0, new ListItem("Select village", "0"));
        }
    }
    #endregion
    protected void btnsaveNGO_Click(object sender, EventArgs e)
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
                       // try
                       // {
                            villageObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
                            villageObject.StateID = Convert.ToInt16(ddlNGOState.SelectedValue);
                            villageObject.TigerReserveid = Convert.ToInt16(ddlNGOTigerReserve.SelectedValue);
                            villageObject.villageID = Convert.ToInt16(ddlVillage.SelectedValue);
                            villageObject.NGO_ID = Convert.ToInt16(ddlNGO.SelectedValue);
                            villageObject.amount = Convert.ToDecimal(txtAmount.Text);
                            villageObject.WorkForVillage = txtWorkByNGO.Text;
                            villageObject.UserID = Convert.ToInt16(Session["User_Id"]);
                            villageObject.IpAddress = miscellBL.IpAddress();
                            p_Var.Result = villageBL.InsertUpdateAssociateNGO(villageObject);
                            if (p_Var.Result > 0)
                            {
                                Session["msg"] = "NGO is associated with village successfully.";
                                Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                                Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx"));
                            }
                        //}
                        //catch
                        //{
                        //    throw;
                        //}
                    }
                }
                //}
            }
        }
        catch
        {
            throw;
        }
     // }
    }


    protected void btnupdateNGO_Click(object sender, EventArgs e)
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
                      //  try
                      //{
                            villageObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.update);
                            villageObject.StateID = Convert.ToInt16(ddlNGOState.SelectedValue);
                            villageObject.NGOAssociatedID = Convert.ToInt16(hfpwd.Value);
                            villageObject.TigerReserveid = Convert.ToInt16(ddlNGOTigerReserve.SelectedValue);
                            villageObject.villageID = Convert.ToInt16(ddlVillage.SelectedValue);
                            villageObject.NGO_ID = Convert.ToInt16(ddlNGO.SelectedValue);
                            villageObject.amount = Convert.ToDecimal(txtAmount.Text);
                            villageObject.WorkForVillage = txtWorkByNGO.Text;
                            villageObject.UserID = Convert.ToInt16(Session["User_Id"]);
                            villageObject.IpAddress = miscellBL.IpAddress();
                            p_Var.Result = villageBL.InsertUpdateAssociateNGO(villageObject);
                            if (p_Var.Result > 0)
                            {
                                Session["msg"] = "NGO is associated with village updated successfully.";
                                Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                                Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx"));
                            }
                        //}
                       // catch
                         //{
                           // throw;
                      //  }
                    }
                }
                //}
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mpAssociateNGO.Hide();
    }

    protected void ddlNGOState_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind_NGOTigerReserve();
    }
    protected void ddlNGOTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

        displayVillageinDropdownlist();
        displayNGO();


    }

    #region Function to display village

    private void displayNGO()
    {
       
        p_Var.dSet = villageBL.getNGOName();

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlNGO.DataSource = p_Var.dSet;
            ddlNGO.DataTextField = "NgoName";
            ddlNGO.DataValueField = "NgoID";
            ddlNGO.DataBind();
            ddlNGO.Items.Insert(0, new ListItem("Select NGO", "0"));
        }
    }
    #endregion

    protected void grvngo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowPopup")
        {
            btnUpdate.Visible = true;
            btnsave.Visible = false;
            LinkButton btndetails = (LinkButton)e.CommandSource;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            HiddenField hidVillageNgo =(HiddenField) gvrow.FindControl("hidVillageNgo");
            HiddenField hidTigerReserveID = (HiddenField)gvrow.FindControl("hidTigerReserveID");
            HiddenField hidNgoID = (HiddenField)gvrow.FindControl("hidNgoID");
            Label lblAmount = (Label)gvrow.FindControl("lblAmount");
            Label lblNGO = (Label)gvrow.FindControl("lblWorkbyNGO");
            string id = e.CommandArgument.ToString();
            hfpwd.Value = id;

            mpAssociateNGO.Show();
            Bind_NGOState();
            displayNGO();
            Bind_NGOTigerReserve();
            ddlNGOTigerReserve.SelectedValue = hidTigerReserveID.Value;
            displayVillageinDropdownlist();
            ddlVillage.SelectedValue = hidVillageNgo.Value;
            ddlNGO.SelectedValue = hidNgoID.Value;

            string str= grvngo.DataKeys[gvrow.RowIndex].Value.ToString();
            
            txtAmount.Text = HttpUtility.HtmlDecode(lblAmount.Text);
            txtWorkByNGO.Text = HttpUtility.HtmlDecode(lblNGO.Text);
           
        }
       
    }

    protected void grvngo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    private void DisplayNGOInGrid(int pageindex)
    {
        if (Convert.ToInt32(ddlstate.SelectedValue) != 0)
        {
            villageObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        }
        else
        {
            villageObject.StateID = null;
        }

        if (Convert.ToInt32(ddltigerreserve.SelectedValue) != 0)
        {
            villageObject.TigerReserveid = Convert.ToInt32(ddltigerreserve.SelectedValue);
        }
        else
        {
            villageObject.TigerReserveid = null;
        }
      
        villageObject.Pageindex = pageindex;
       // villageObject.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        p_Var.dSet = villageBL.getAssociatedNGOList(villageObject);

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            grvngo.DataSource = p_Var.dSet;
            grvngo.DataBind();

        }
    }


    
}
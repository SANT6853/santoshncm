using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_CMS_ViewContent : CrsfBase
{
    #region Data declaration zone
    DataSet dSet = new DataSet();
    LinkOB lnkObject = new LinkOB();
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    ContentOB contentObject = new ContentOB();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    string LoginUserid;
    int LoginUsertype;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
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
            if (Session["UserType"].ToString() == "3")
            {

                ddlwebsite.Items[0].Enabled = false;

                DisplayStateName();
                ddlTigerReserve.Enabled = true;
                Bind_TigerReserveUserAccess();
                bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));



            }
            else
            {
                DisplayStateName();
                Bind_TigerReserveUserAccess();
                bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
            }

            if (Session["mstatus"] != null)
            {
                bindStatusInDropdownlist();
                ddlStatus.SelectedValue = Session["mstatus"].ToString();
                Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
            }
            else
            {
                bindStatusInDropdownlist();
                Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue));
            }


            if (ddlwebsite.SelectedValue == "1")
            {
                DisplayStateName();
                Bind_TigerReserveUserAccess();
                ddlState.Enabled = false;
                ddlTigerReserve.Enabled = false;
            }
            else
            {
                ddlState.Enabled = true;
                ddlTigerReserve.Enabled = true;

            }
            if (ddlStatus.SelectedValue == "3")//draft
            {
                btnApprove.Visible = true;
                grdCMSMenu.Columns[6].Visible = false;
            }
            else
            { btnApprove.Visible = false; }
            ///-----------------
            ///if (ddlStatus.SelectedValue == "6")//delete
            {
                grdCMSMenu.Columns[6].Visible = false;
                grdCMSMenu.Columns[7].Visible = true;
            }
            if (ddlStatus.SelectedValue == "3")//draft
            {
                btnApprove.Visible = true;
                btnApprove.Text = "Publish";
                grdCMSMenu.Columns[6].Visible = false;
            }
            else
            { btnApprove.Visible = false; }
            if (ddlStatus.SelectedValue == "6")//delete
            {
                // grdCMSMenu.Columns[6].Visible = false;
                //  grdCMSMenu.Columns[5].Visible = false;
                btnApprove.Visible = true;
                btnApprove.Text = "Restore deleted record";
            }
            if (Session["UserType"].ToString() == "3")
            {
                ddlTigerReserve.Enabled = true;

            }
        }

    }

    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayStateName();

        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));

    }
    protected void grdCMSMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCMSMenu.PageIndex = e.NewPageIndex;
        Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
    }

    protected void grdCMSMenu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if(Page.IsValid)
      {

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
                        string i = e.CommandArgument.ToString();


                        if (e.CommandName == "View")
                        {
                            if (Session["update"].ToString() == ViewState["update"].ToString())
                            {


                                string strId = e.CommandArgument.ToString();
                                string popupScript = "<script language='javascript'>" +
                                    "window.open('../../../ContentPage.aspx?Value=" + i + "&status=" + ddlStatus.SelectedValue + "&langId=" + ddlLanguage.SelectedValue + "', 'mywindow', " +
                                    "' menubar=no, resizable=no, scrollbars=yes,width=1200,height=530,top=0,left=0 ')" +
                                    "</script>";

                                Page.RegisterStartupScript("PopupScript", popupScript);
                                // }
                                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());


                            }
                        }
                        if (e.CommandName == "Delete")
                        {
                            Menu_ManagementBL menuDeleteBL = new Menu_ManagementBL();
                            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                            Label lblStatus = (Label)row.Cells[0].FindControl("lblStatus");
                            LinkButton hyperMenu = (LinkButton)row.Cells[2].FindControl("hyperMenu");
                            lnkObject.TempLinkId = Convert.ToInt16(e.CommandArgument);
                            lnkObject.LastUpdatedBy = Convert.ToInt16(Session["User_Id"]);
                            lnkObject.StatusId = Convert.ToInt16(lblStatus.Text);
                            //HydLinkID
                            HiddenField hydlinkid = (HiddenField)row.Cells[2].FindControl("HydLinkID");
                            if (hydlinkid.Value != "")
                            {
                                lnkObject.link_id = Convert.ToInt32(hydlinkid.Value);
                            }
                            p_Var.Result = menuDeleteBL.Delete_Pending_Approved_Record(lnkObject);
                            if (p_Var.Result > 0)
                            {
                                    AuditOB AE = new AuditOB();

                                    AuditTrail Obj_Audit = new AuditTrail();
                                    //AE.PageTitle = (Page.Master.FindControl("PageName") as Label).Text;

                                    AE.FK_MODULE_ID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms);

                                    AE.Action = " Menu deleted";

                                    AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"].ToString());

                                    Obj_Audit.GetAuditTrail(AE);

                                    Session["msg"] = "Menu has been deleted successfully.";


                                    Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms) + "&position=" + ddlPosition.SelectedValue;

                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Menu can't delete because it has submenu.If you want to delete this menu, first delete it's submenu";

                                Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms) + "&position=" + ddlPosition.SelectedValue;

                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            // }
                        }
                        if (e.CommandName == "Restore")
                        {
                            Menu_ManagementBL menuDeleteBL = new Menu_ManagementBL();
                            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                            Label lblStatuss = (Label)row.Cells[0].FindControl("lblRestoreStatus");
                            LinkButton hyperMenu = (LinkButton)row.Cells[2].FindControl("hyperMenu");
                            lnkObject.TempLinkId = Convert.ToInt16(e.CommandArgument);
                            lnkObject.LastUpdatedBy = Convert.ToInt16(Session["User_Id"]);
                            lnkObject.StatusId = Convert.ToInt16(lblStatuss.Text);

                            p_Var.Result = menuDeleteBL.Restore_Link(lnkObject);
                            if (p_Var.Result > 0)
                            {
                                AuditOB AE = new AuditOB();

                                AuditTrail Obj_Audit = new AuditTrail();
                                //AE.PageTitle = (Page.Master.FindControl("PageName") as Label).Text;

                                AE.FK_MODULE_ID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms);

                                AE.Action = " Menu Restore";

                                AE.Admin_Login_id = Convert.ToInt32(Session["User_Id"].ToString());

                                Obj_Audit.GetAuditTrail(AE);

                                Session["msg"] = "Menu has been Restored successfully.";


                                Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms) + "&position=" + ddlPosition.SelectedValue;

                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Menu can't be restore";

                                Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms) + "&position=" + ddlPosition.SelectedValue;

                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                           // }
                        }
                    }
                }

            }
        
        }
           catch
            {
                throw;
            }

      }


    }

    protected void grdCMSMenu_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void grdCMSMenu_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdCMSMenu.HeaderRow.FindControl("chkSelectAll");
            //Add client side function childclick on check boxes
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));

        }
    }

    protected void grdCMSMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ddlStatus.SelectedValue == "6")//delete
            {
                // grdCMSMenu.Columns[6].Visible = false;
                //  grdCMSMenu.Columns[5].Visible = false;

                btnApprove.Text = "Restore deleted record";
            }
            if (ddlStatus.SelectedValue == "3")//draft
            {
                grdCMSMenu.Columns[6].Visible = false;
            }
            if (ddlStatus.SelectedValue == "5")//approve
            {
                grdCMSMenu.Columns[0].Visible = false;
                grdCMSMenu.Columns[7].Visible = false;
                grdCMSMenu.Columns[6].Visible = true;
            }
            else
            {
                grdCMSMenu.Columns[0].Visible = true;
                btnApprove.Visible = true;
            }
            System.Web.UI.WebControls.Image img1 = e.Row.FindControl("emgnotedit") as System.Web.UI.WebControls.Image;
            System.Web.UI.WebControls.Image img = e.Row.FindControl("imgedit") as System.Web.UI.WebControls.Image;
            //---------------------------------
            System.Web.UI.WebControls.Image img11 = e.Row.FindControl("emgnotedit1") as System.Web.UI.WebControls.Image;
            System.Web.UI.WebControls.Image img00 = e.Row.FindControl("imgedit1") as System.Web.UI.WebControls.Image;

            contentObject.LinkTypeID = Convert.ToInt32(grdCMSMenu.DataKeys[e.Row.RowIndex].Value);
            p_Var.dSet = contentBL.getApproveContentForEDit(contentObject);
            for (int i = 0; i < p_Var.dSet.Tables[0].Rows.Count; i++)
            {
                if (p_Var.dSet.Tables[0].Rows[i]["Link_Id"] != DBNull.Value)
                {

                    if (Convert.ToInt32(grdCMSMenu.DataKeys[e.Row.RowIndex].Value) == Convert.ToInt16(p_Var.dSet.Tables[0].Rows[i]["Link_Id"]))
                    {

                        img.Visible = false;
                        img1.Visible = true;
                        img1.Height = 10;
                        img1.Width = 10;
                        //------------------
                        img00.Visible = false;
                        img11.Visible = true;
                        img11.Height = 10;
                        img11.Width = 10;

                    }
                    else
                    {
                        img1.Visible = false;
                        img.Visible = true;
                        //--------------------------
                        img11.Visible = false;
                        img00.Visible = true;
                    }


                }
            }
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        divGrid.Visible = false;
        Bind_TigerReserveUserAccess();
        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
    }

    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        divGrid.Visible = false;
        bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
    }

    protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMenuListBox(Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
    }

    //protected void lbMenu_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //ddlStatus.SelectedValue = Convert.ToString(Module_ID_Enum.Module_Status_ID.draft);
    //  //  Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
    //}
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        ContentApprove();

    }
    #region Function to bind state name in dropdownlist

    private void DisplayStateName()
    {

        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlState.DataSource = p_Var.dSet;
        ddlState.DataTextField = "StateName";
        ddlState.DataValueField = "id";
        ddlState.DataBind();
        if (LoginUsertype == 1)
        {
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));

        }


    }

    #endregion

    #region Function to bind tiger reserve name in dropdownlist

    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlState.SelectedValue);

        // p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);Get_TigerReserve_state_PermissionModified
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_PermissionModified(objntcauser);
        ddlTigerReserve.DataSource = p_Var.dSet;
        ddlTigerReserve.DataTextField = "TigerReserveName";
        ddlTigerReserve.DataValueField = "TigerReserveid";
        ddlTigerReserve.DataBind();
        ddlTigerReserve.Items.Insert(0, new ListItem("Select", "0"));



    }


    #endregion

    #region function to bind listbox with root

    private void bindMenuListBox(int langid, int positionid, int stateID, int tigerreserveID, int WebsiteID)
    {
        lbMenu.Items.Clear();
        //contentBL _menuBL = new contentBL();

        ListItem li = default(ListItem);

        contentObject.LangID = langid;
        contentObject.LinkParentID = 0;
        contentObject.PositionID = positionid; //1
        contentObject.StateID = stateID;
        contentObject.TigerReserveid = tigerreserveID;
        contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
        try
        {

            p_Var.dSet = contentBL.getRootMenuNamFromWeb(contentObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                for (p_Var.i = 0; p_Var.i <= p_Var.dSet.Tables[0].Rows.Count - 1; p_Var.i++)
                {
                    p_Var.linkid = Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"]);
                    //if (link_id != 20)
                    //{
                    li = new ListItem(p_Var.dSet.Tables[0].Rows[p_Var.i]["NAME"].ToString(), p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"].ToString());
                    lbMenu.Items.Add(li);
                    bindChildData(Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Level"]) + 1, Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Link_Id"]), Convert.ToInt16(p_Var.dSet.Tables[0].Rows[p_Var.i]["Position_Id"]));
                    //}
                }
                if (langid == 1)
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                lbMenu.Items[0].Selected = true;

            }
            else
            {
                if (langid == 1)
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- On Root ------>", "0"));
                }
                else
                {
                    lbMenu.Items.Insert(0, new ListItem("<----- मुख पृष्ठ ------>", "0"));
                }
                lbMenu.Items[0].Selected = true;
            }
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to get child records

    public void bindChildData(int level, int Parent_ID, int Postion_ID)
    {
        ListItem lic = default(ListItem);
        Content_ManagementBL _subMenuBL = new Content_ManagementBL();
        DataSet dsubLinks = new DataSet();
        try
        {
            contentObject.LinkParentID = Parent_ID;
            contentObject.LinkLevel = level;
            contentObject.PositionID = Postion_ID;

            dsubLinks = _subMenuBL.getSubMenuOfParentMenu(contentObject);
            if (dsubLinks.Tables[0].Rows.Count > 0)
            {
                string str = "• ";
                for (int j = 0; j < level - 1; j++)
                {
                    str = str + "• ";
                }
                for (int i = 0; i <= dsubLinks.Tables[0].Rows.Count - 1; i++)
                {

                    lic = new ListItem(str + dsubLinks.Tables[0].Rows[i]["NAME"].ToString(), dsubLinks.Tables[0].Rows[i]["Link_Id"].ToString());
                    lbMenu.Items.Add(lic);
                    contentObject.LinkParentID = Parent_ID;
                    contentObject.LinkLevel = level + 1;
                    contentObject.PositionID = Postion_ID;
                    bindChildData(level + 1, Convert.ToInt16(dsubLinks.Tables[0].Rows[i]["Link_Id"]), Postion_ID);
                }
            }
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to approve menu/modules

    private void ContentApprove()
    {
       //if (Page.IsValid)
       //{

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
                            //try
                            //{
                                foreach (GridViewRow row in grdCMSMenu.Rows)
                                {
                                    CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
                                    if (selCheck.Checked == true)
                                    {
                                        contentObject.TempLinkID = Convert.ToInt32(grdCMSMenu.DataKeys[row.RowIndex].Value);
                                        contentObject.LastUpdatedBy = Convert.ToInt16(Session["User_Id"]);
                                        contentObject.IpAddress = miscellBL.IpAddress();
                                        p_Var.Result = contentBL.ApproveContent(contentObject);
                                    }
                                }

                                if (p_Var.Result > 0)
                                {
                                    if (ddlStatus.SelectedValue == "6")
                                    {
                                        Session["msg"] = "Content has been restored successfully and record has been shifted in status(Approved and here you can edit and delete temporary)";
                                        Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                    }
                                    else
                                    {
                                        Session["msg"] = "Content has been approved successfully.";
                                        Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                    }
                                }
                            //}
                            //catch
                            //{
                            //    throw;
                            //}
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

    #endregion


    #region Function To bind the gridView with menu

    public void Bind_Grid(int list_value, int langid, int positionid, int stateid, int tigerreserveid, int statusid)
    {
        LblMsg.Text = "";
        if (ddlStatus.SelectedValue == "0")
        {
            grdCMSMenu.Visible = false;
            // BtnForReview.Visible = false;
        }
        else
        {
            //if (ddlStatus.SelectedValue == "6")
            //{
            //    grdCMSMenu.Columns[7].Visible = false;
            //}
            grdCMSMenu.Visible = true;
            contentObject.StatusID = statusid;
            contentObject.ModuleID = Convert.ToInt32(Module_ID_Enum.Project_Module_ID.cms);
            contentObject.LangID = langid;
            contentObject.PositionID = positionid;
            contentObject.StateID = stateid;
            contentObject.TigerReserveid = tigerreserveid;
            contentObject.LinkParentID = list_value;


            p_Var.dsFileName = contentBL.gridDisplayData(contentObject, out p_Var.k);


            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {

                divGrid.Visible = true;
                grdCMSMenu.DataSource = p_Var.dsFileName;

                //Codes for the sorting of records

                DataTable dt = p_Var.dsFileName.Tables[0];
                Cache["dt"] = dt;
                ViewState["Column_Name"] = "Brand";
                ViewState["Sort_Order"] = "ASC";

                //End

                grdCMSMenu.DataBind();




                p_Var.dSet = null;

            }
            else
            {
                LblMsg.Text = "Record not found!.Please choose correct label option as per as your correct need!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                divGrid.Visible = false;
                grdCMSMenu.Visible = false;

            }

            //}
            p_Var.Result = p_Var.k;

            // Session["Status_Id"] = ddlStatus.SelectedValue.ToString();
            Session["Lanuage"] = ddlLanguage.SelectedValue;

        }
    }

    #endregion

    #region Function to bind status in dropdownlist

    private void bindStatusInDropdownlist()
    {
        contentObject.StatusID = null;
        p_Var.dSet = contentBL.getWorkStatus(contentObject);
        ddlStatus.DataSource = p_Var.dSet;
        ddlStatus.DataTextField = "Status";
        ddlStatus.DataValueField = "Statusid";
        ddlStatus.DataBind();
    }

    #endregion

    bool ChkVal()
    {
        LblMsg.Text = "";
        bool chk = true;

        if (ddlState.SelectedValue == "0")
        {
            LblMsg.Text = "Please select state";
            LblMsg.ForeColor = System.Drawing.Color.Red;
            ddlState.Focus();
            return chk = false;
        }
        if (ddlTigerReserve.SelectedValue == "0")
        {
            LblMsg.Text = "Please select Tiger reserve";
            LblMsg.ForeColor = System.Drawing.Color.Red;
            ddlTigerReserve.Focus();
            return chk = false;
        }
        return chk;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlwebsite.SelectedValue == "1")
        {
            if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft))
            {
                btnApprove.Visible = true;
            }
            else
            {
                btnApprove.Visible = false;
            }
            divGrid.Visible = true;
            Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
        }
        else
        {
            if (ChkVal() == true)
            {

                if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft))
                {
                    btnApprove.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                }
                divGrid.Visible = true;
                Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
            }
        }
    }
    private void onupclick()
    {
        Menu_ManagementBL _menuBL = new Menu_ManagementBL();
        DataSet dsf = new DataSet();
        DataTable dtu = new DataTable();

        lnkObject.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
        lnkObject.LinkParentId = 0;
        lnkObject.PositionId = Convert.ToInt32(ddlPosition.SelectedValue);
        dsf = _menuBL.getMenuName_From_Web(lnkObject);
        dtu = dsf.Tables[0];
        int rcount = dsf.Tables[0].Rows.Count;
        DataView dv = new DataView(dtu);

        lnkObject.LinkParentId = Convert.ToInt16(lbMenu.SelectedValue);
        lnkObject.LangId = Convert.ToInt16(ddlLanguage.SelectedValue);
        dSet = _menuBL.get_Menu_level_Link_Web(lnkObject);
        if (dSet.Tables[0].Rows.Count > 0)
        {


            /*To avoid up action on TopMenu i.e.Home*/
            if (Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]) == Convert.ToInt32(0) && Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]) == Convert.ToInt32(1))
            {
            }

            else
            {

                lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]);
                lnkObject.LinkOrder = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]);
                lnkObject.linkID = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_id"]);
                int order = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]);
                //dv.RowFilter = " max(link_order) <"+order;
                if (lnkObject.LinkParentId == 0)  /*Its a root parent*/
                {
                    dv.RowFilter = "Link_Order<" + order; //to find next mimimum order bcoz v need upward motion

                    dtu = dv.ToTable();

                    dtu.AcceptChanges();
                    dv = dtu.DefaultView; /*Assigning newly created table*/
                    dv.RowFilter = "Link_order=max(Link_Order)";
                    dtu = dv.ToTable();
                    dtu.AcceptChanges();
                    if (Convert.ToInt32(dtu.Rows[0]["link_parent_id"]) == Convert.ToInt32(0) && Convert.ToInt32(dtu.Rows[0]["link_order"]) == Convert.ToInt32(1))
                    {
                    }
                    else
                    {
                        int uuporder = Convert.ToInt32(dtu.Rows[0]["Link_order"]);
                        lnkObject.UPLinkOrder = uuporder;
                        // 
                        lnkObject.ORGLinkOrder = order;  // original id
                    }

                }


                else         /* slected item is submenu */
                {
                    lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]);
                    lnkObject.LinkLevel = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_level"]);
                    lnkObject.PositionId = Convert.ToInt32(dSet.Tables[0].Rows[0]["Position_Id"]);
                    Menu_ManagementBL _subMenuBL = new Menu_ManagementBL();
                    DataSet dsubLink = new DataSet();
                    dsubLink = _subMenuBL.get_SublinksID_of_Parant_From_Web(lnkObject);
                    dtu = dsubLink.Tables[0];
                    dv = dtu.DefaultView;
                    dv.RowFilter = "Link_Order<" + order;
                    dtu = dv.ToTable();
                    dtu.AcceptChanges();
                    dv = dtu.DefaultView;
                    if (dtu.Rows.Count > 0 && dtu != null)
                    {
                        dv.RowFilter = "Link_order=max(Link_Order)";
                        dtu = dv.ToTable();
                        dtu.AcceptChanges();
                        //if (Convert.ToInt32(dtu.Rows[0]["link_parent_id"]) == Convert.ToInt32(0) && Convert.ToInt32(dtu.Rows[0]["link_order"]) == Convert.ToInt32(1))
                        //{
                        //}
                        //else
                        //{
                        int uuporder = Convert.ToInt32(dtu.Rows[0]["Link_order"]);
                        lnkObject.UPLinkOrder = uuporder;
                        lnkObject.ORGLinkOrder = order;  // original id
                        //}
                    }

                }
            }




            Menu_ManagementBL menuBL = new Menu_ManagementBL();
            int i = menuBL.change_order_menu(lnkObject);
            bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
            // bindMenu_ListBox(Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlMenuPosition.SelectedValue));
            if (i > 0)
            {
                Session["msg"] = "Menu has been Changed  successfully.";
                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Menu Could not have been Changed.";
                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
            }
        }




    }
    #region button btnTop click event to move menu on top
    protected void btnUp_Click(object sender, EventArgs e)
    {
         //if (Page.IsValid)
        //{

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
                       
                        onupclick();
                    }
                }
            }
        }
           catch
           {
               throw;
           }
           

     //  }

    
    }

    

    #endregion
    private void ondownclick()
    {
        Menu_ManagementBL _menuBL = new Menu_ManagementBL();
        lnkObject.LinkParentId = Convert.ToInt16(lbMenu.SelectedValue);
        lnkObject.LangId = Convert.ToInt16(ddlLanguage.SelectedValue);
        dSet = _menuBL.get_Menu_level_Link_Web(lnkObject);
        DataSet dsf = new DataSet();
        DataTable dtu = new DataTable();
        lnkObject.LangId = Convert.ToInt32(ddlLanguage.SelectedValue);
        lnkObject.LinkParentId = 0;
        lnkObject.PositionId = Convert.ToInt32(ddlPosition.SelectedValue);
        dsf = _menuBL.getMenuName_From_Web(lnkObject);
        dtu = dsf.Tables[0];
        DataView dv = new DataView(dtu);
        if (dSet.Tables[0].Rows.Count > 0)
        {
            /*To avoid down action on TopMenu i.e.Home*/
            if (Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]) == Convert.ToInt32(0) && Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]) == Convert.ToInt32(1))
            // if (dSet.Tables[0].Rows.Count < 0)
            {
            }


            else
            {

                lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]);
                lnkObject.LinkOrder = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]);
                lnkObject.linkID = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_id"]);
                int order = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]);




                if (lnkObject.LinkParentId == 0)  /*Its a root parent*/
                {

                    dv.RowFilter = "Link_Order>" + order; //to find next max order bcoz v need downward motion

                    dtu = dv.ToTable();
                    if (dtu.Rows.Count > 0)
                    {
                        dtu.AcceptChanges();
                        dv = dtu.DefaultView; /*Assigning newly created table*/
                        dv.RowFilter = "Link_order=min(Link_Order)";
                        dtu = dv.ToTable();
                        dtu.AcceptChanges();
                        int downorder = Convert.ToInt32(dtu.Rows[0]["Link_order"]);
                        lnkObject.DOWNLinkOrder = downorder;

                        lnkObject.ORGLinkOrder = order;  // original id

                    }
                }


                else         /* slected item is submenu */
                {
                    lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]);
                    lnkObject.LinkLevel = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_level"]);
                    lnkObject.PositionId = Convert.ToInt32(dSet.Tables[0].Rows[0]["Position_Id"]);
                    Menu_ManagementBL _subMenuBL = new Menu_ManagementBL();
                    DataSet dsubLink = new DataSet();
                    dsubLink = _subMenuBL.get_SublinksID_of_Parant_From_Web(lnkObject);
                    dtu = dsubLink.Tables[0];
                    dv = dtu.DefaultView;
                    dv.RowFilter = "Link_Order>" + order;
                    dtu = dv.ToTable();
                    dtu.AcceptChanges();
                    dv = dtu.DefaultView;
                    if (dtu.Rows.Count > 0 && dtu != null)
                    {
                        dv.RowFilter = "Link_order=min(Link_Order)";
                        dtu = dv.ToTable();
                        dtu.AcceptChanges();
                        int downorder = Convert.ToInt32(dtu.Rows[0]["Link_order"]);
                        lnkObject.DOWNLinkOrder = downorder;
                        lnkObject.ORGLinkOrder = order;  // original id
                    }
                }

            }
            //int downorder = order + 1;    // link order id will increment to bring menu downward
            //lnkObject.UPLinkOrder = downorder;

            //lnkObject.ORGLinkOrder = order;  // original id
            Menu_ManagementBL menuBL = new Menu_ManagementBL();
            int i = menuBL.change_order_menu_down(lnkObject);
            // bindMenu_ListBox(Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlMenuPosition.SelectedValue));
            bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
            if (i > 0)
            {
                Session["msg"] = "Menu has been Changed  successfully.";
                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Menu Could not have been Changed.";
                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
            }
        }

    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
         //if (Page.IsValid)
        //{

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
                        ondownclick();
                    }
                }
            }
        }
           catch
           {
               throw;
           }
           

     //  }

    
    }

    
    #region button btnLeft click event to move menu left

    protected void btnLeft_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

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
                        Menu_ManagementBL _menuBL = new Menu_ManagementBL();
                        lnkObject.LinkParentId = Convert.ToInt16(lbMenu.SelectedValue);
                        lnkObject.LangId = Convert.ToInt16(ddlLanguage.SelectedValue);
                        DataSet ds1 = new DataSet();
                        ds1 = _menuBL.get_Menu_level_Link_Web(lnkObject);
                        dSet = _menuBL.get_Menu_level_Link_Web_left_right(lnkObject);

                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToInt32(ds1.Tables[0].Rows[0]["link_level"]) > 1)
                                {
                                    int rows_contain = dSet.Tables[0].Rows.Count;
                                    //for (int i = 0; i < rows_contain; i++)
                                    //{
                                    int rowno = 0;
                                    lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentI"]);
                                    if (dSet.Tables[0].Rows[rowno]["parentI"].ToString() != "")
                                    {
                                        if (Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentI"]) != Convert.ToInt32(0))
                                        {
                                            int newchildsI = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["childI"]);
                                            newchildsI--;

                                            lnkObject.linkID = Convert.ToInt16(lbMenu.SelectedValue);
                                            lnkObject.ChildI = newchildsI;
                                            lnkObject.ParentI = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentI"]);
                                            rowno++;

                                        }
                                    }

                                    if (dSet.Tables[0].Rows[rowno]["parentII"].ToString() != "")
                                    {
                                        if (Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentII"]) != Convert.ToInt32(0))
                                        {
                                            int newchildII = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["childII"]);
                                            newchildII++;

                                            lnkObject.ParentII = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentII"]);
                                            lnkObject.ChildII = newchildII;
                                            rowno++;
                                        }
                                    }
                                    if (dSet.Tables[0].Rows[rowno]["parentIII"].ToString() != "")
                                    {
                                        if (Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentIII"]) != Convert.ToInt32(0))
                                        {
                                            int newchildIII = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["childIII"]);
                                            newchildIII++;

                                            lnkObject.ParentIII = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentIII"]);
                                            lnkObject.ChildIII = newchildIII;
                                            rowno++;
                                        }
                                    }

                                    if (dSet.Tables[0].Rows[rowno]["parentIV"].ToString() != "")
                                    {


                                        if (Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentIV"]) != Convert.ToInt32(0))
                                        {
                                            int newchildIV = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["childIV"]);
                                            newchildIV++;

                                            lnkObject.ParentIV = Convert.ToInt32(dSet.Tables[0].Rows[rowno]["parentIV"]);
                                            lnkObject.ChildIV = newchildIV;
                                            rowno++;
                                        }
                                    }

                                }


                            }
                        }
                        int i = _menuBL.Left_Swift_Menus(lnkObject);
                        if (i > 0)
                        {
                            Session["msg"] = "Menu has been Changed  successfully.";
                            Session["BackUrl"] = "~/Auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            lbMenu.Items.Clear();
                            // bindMenu_ListBox(Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlMenuPosition.SelectedValue));
                            bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
                        }
                        else
                        {
                            Session["msg"] = "Menu Could not have been Changed.";
                            Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                            Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
                        }
                    }

                }
            }
        }
        catch
        {
            throw;
        }


        //  }


    }

    #endregion
    #region button btnRight click event to move menu right

    protected void btnRight_Click(object sender, EventArgs e)
    {
         //if (Page.IsValid)
        //{

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
                        //
                        Menu_ManagementBL _menuBL = new Menu_ManagementBL();
                        lnkObject.LinkParentId = Convert.ToInt16(lbMenu.SelectedValue);
                        lnkObject.LangId = Convert.ToInt16(ddlLanguage.SelectedValue);
                        //   dSet = _menuBL.get_Menu_level_Link_Web_left_right(lnkObject);
                        dSet = _menuBL.get_Menu_level_Link_Web(lnkObject);
                        int li;
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            li = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_id"]);
                            li--;





                            DataSet ds1, ds2 = new DataSet();
                            // ds1 = _menuBL.get_Menu_level_Link_Web(lnkObject);
                            ds2 = _menuBL.get_Menu_level_Link_Web_left_right(lnkObject);

                            if (li == Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]) || 0 == Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]))
                            {
                                Session["msg"] = "Menu Could not have been Changed.";
                                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            if (1 == Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]))
                            {
                                Session["msg"] = "Menu Could not have been Changed.";
                                Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                lnkObject.linkID = li;
                                //// lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_parent_id"]);
                                // lnkObject.LinkLevel = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_level"]);
                                // lnkObject.PositionId = Convert.ToInt32(dSet.Tables[0].Rows[0]["Position_Id"]);
                                // Menu_ManagementBL _subMenuBL = new Menu_ManagementBL();
                                // DataSet dsubLink = new DataSet();
                                // dsubLink = _subMenuBL.get_SublinksID_of_Parant_From_Web(lnkObject);
                                // if (dsubLink.Tables[0].Rows.Count > 0)
                                // {

                                // }
                                // else  /*record not found so decrement it */
                                // {
                                //     li--;
                                //     for (li--; dsubLink.Tables[0].Rows.Count < 0; li--)
                                //     {
                                //         lnkObject.LinkParentId = li;

                                //     }
                                // }
                                // dtu = dsubLink.Tables[0];




                                //if (Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]) > 1 && Convert.ToInt32(dSet.Tables[0].Rows[0]["link_level"])>0)
                                //{
                                //lnkObject.LinkOrder = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_order"]);
                                //}
                                if (Convert.ToInt32(dSet.Tables[0].Rows[0]["link_id"]) != 0)
                                {
                                    lnkObject.LinkParentId = Convert.ToInt32(dSet.Tables[0].Rows[0]["link_id"]);/*id at which updation occurs*/
                                }
                                int i = _menuBL.Right_Swift_Menus(lnkObject);

                                if (i > 0)
                                {
                                    Session["msg"] = "Menu has been Changed  successfully.";
                                    Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Session["msg"] = "Menu Could not have been Changed.";
                                    Session["BackUrl"] = "~/auth/AdminPanel/CMS/ViewContent.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                    Response.Redirect("~/auth/AdminPanel/ConfirmationPage.aspx");
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


        //  }


    }
    
    #endregion
    protected void ddlwebsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlwebsite.SelectedValue == "1")
        {
            ReserveStar.Visible = false;
            StateStar.Visible = false;
            DisplayStateName();
            Bind_TigerReserveUserAccess();
            ddlState.Enabled = false;
            ddlTigerReserve.Enabled = false;
            bindMenuListBox(Convert.ToInt16(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt32(ddlwebsite.SelectedValue));
        }
        else
        {
            ReserveStar.Visible = true;
            StateStar.Visible = true;
            ddlState.Enabled = true;
            ddlTigerReserve.Enabled = true;


        }
    }
    //#region Dropdownlist ddlStatus selectedIndexChanged event
    //protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
    //}

    //#endregion  
    protected void ddlStatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue == "6")//delete
        {
            grdCMSMenu.Columns[6].Visible = false;
            grdCMSMenu.Columns[7].Visible = true;
        }
        if (ddlStatus.SelectedValue == "3")//draft
        {
            btnApprove.Visible = true;
            btnApprove.Text = "Publish";
            grdCMSMenu.Columns[6].Visible = false;
        }
        else
        { btnApprove.Visible = false; }
        if (ddlStatus.SelectedValue == "6")//delete
        {
            // grdCMSMenu.Columns[6].Visible = false;
            //  grdCMSMenu.Columns[5].Visible = false;
            btnApprove.Visible = true;
            btnApprove.Text = "Restore deleted record";
        }


        //--------------
        if (ddlStatus.SelectedValue == "0")
        {
            grdCMSMenu.Visible = false;

            btnApprove.Visible = false;

            //btnForApprove.Visible = false;
            //btnDisApprove.Visible = false;
            //binddropDownlistStatus();
            //ddlPageSize.Visible = false;
            //lblPageSize.Visible = false;
            //rptPager.Visible = false;
        }
        else if ((ddlStatus.SelectedValue == "3") || (ddlStatus.SelectedValue == "6") || (ddlStatus.SelectedValue == "5"))
        {
            Session["mstatus"] = ddlStatus.SelectedValue;
            Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
            //grdCMSMenu.Columns[7].Visible = true;

        }
        else
        {
            if (lbMenu.SelectedValue.ToString() != null && lbMenu.SelectedValue.ToString() != "")
            {
                Session["mstatus"] = ddlStatus.SelectedValue;
                Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
                // grdCMSMenu.Columns[7].Visible = false;
                btnApprove.Visible = false;
            }
        }

        //--------------

        // Bind_Grid(Convert.ToInt32(lbMenu.SelectedValue), Convert.ToInt32(ddlLanguage.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue), Convert.ToInt16(ddlState.SelectedValue), Convert.ToInt16(ddlTigerReserve.SelectedValue), Convert.ToInt16(ddlStatus.SelectedValue));
    }
}
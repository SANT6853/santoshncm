using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FundManagement_viewfund : System.Web.UI.Page
{
    string LoginUserid;
    int LoginUsertype;
    static int StateID;
    static int StateUserID;
    static string StateUserName;
    static string StateName;
    //How to determine which button was clicked in gridview
    string ButtonClickFindToolTipValue;

    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    Project_Variables p_Var = new Project_Variables();
    VillageBL _villageBl = new VillageBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Commanfuction _commanfuction = new Commanfuction();
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
            //if (Request.QueryString["vid"] != null)
            //{
            //    string ss = Request.QueryString["vid"].ToString();
            //}
            Bind_State();
            Bind_TigerReserveUserAccess();

            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
            DefaultgetFund_List();


        }

    }
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            StateID = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["id"]);
            StateName = (string)p_Var.dSet.Tables[0].Rows[0]["StateName"];
        }
        ddlstate.DataSource = p_Var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }
    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddltigerreserve.DataSource = p_Var.dSet;
        ddltigerreserve.DataTextField = "TigerReserveName";
        ddltigerreserve.DataValueField = "TigerReserveid";
        ddltigerreserve.DataBind();
        ddltigerreserve.Items.Insert(0, new ListItem("Select", "0"));
    }
    void Bind_VillageList()
    {
        p_Var.dSet = _villageBl.GetVillageByTigerReserverID(Convert.ToInt32(ddltigerreserve.SelectedValue));
        ddlvillage.DataSource = p_Var.dSet;
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "TempVillageid";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddltigerreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_VillageList();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }
    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        getFund_List();
    }
    void getFund_List()
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
                        FunbDL _funddl = new FunbDL();
                        FundOb _fund_ob = new FundOb();
    
                        if (Session["UserType"].ToString() == "1")
                        {
                            //super admin
                            _fund_ob.NtcaUserID = Convert.ToInt32(Session["User_Id"]);
                            _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                            _fund_ob.TigerReserveID = Convert.ToInt32(ddltigerreserve.SelectedValue);
                            _fund_ob.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
                            p_Var.dSet = _funddl.BindFundMangementRecord(_fund_ob);
                            if (p_Var.dSet.Tables[0].Rows.Count > 0)
                            {
                                grdfund.DataSource = p_Var.dSet;
                                grdfund.DataBind();
                            }
                            else
                            {
                                //  Response.Write("<Script></Script>");
                                grdfund.DataSource = null;
                                grdfund.DataBind();
                                // Response.Write("<script language=javascript>alert('No Record found!');</script>");
                            }
                        }
                        else if (Session["UserType"].ToString() == "2")
                        {
                            //state user
                            _fund_ob.StateUserID = Convert.ToInt32(Session["User_Id"]);
                            _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                            _fund_ob.TigerReserveID = Convert.ToInt32(ddltigerreserve.SelectedValue);
                            _fund_ob.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
                            p_Var.dSet = _funddl.BindFundMangementRecord(_fund_ob);
                            if (p_Var.dSet.Tables[0].Rows.Count > 0)
                            {
                                grdfund.DataSource = p_Var.dSet;
                                grdfund.DataBind();
                            }
                            else
                            {
                                //  Response.Write("<Script></Script>");
                                grdfund.DataSource = null;
                                grdfund.DataBind();
                                //Response.Write("<script language=javascript>alert('No Record found!');</script>");
                            }
                        }
                        else if (Session["UserType"].ToString() == "3")
                        {
                            _fund_ob.TigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
                            _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                            _fund_ob.TigerReserveID = Convert.ToInt32(ddltigerreserve.SelectedValue);
                            _fund_ob.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
                            p_Var.dSet = _funddl.BindFundMangementRecord(_fund_ob);
                            if (p_Var.dSet.Tables[0].Rows.Count > 0)
                            {
                                grdfund.DataSource = p_Var.dSet;
                                grdfund.DataBind();
                            }
                            else
                            {
                                //  Response.Write("<Script></Script>");
                                grdfund.DataSource = null;
                                grdfund.DataBind();
                                // Response.Write("<script language=javascript>alert('No Record found!');</script>");
                            }
                        }
                        else
                        {

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
//}


    }
    void DefaultgetFund_List()
    {
        if (Session["UserType"].ToString() == "1")
        {
            //super admin
            if (ddltigerreserve.SelectedValue == "0" && ddlvillage.SelectedValue == "0")
            {
                FunbDL _funddl = new FunbDL();
                FundOb _fund_ob = new FundOb();

                _fund_ob.NtcaUserID = Convert.ToInt32(Session["User_Id"]);
                _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);

                p_Var.dSet = _funddl.BindDefalultFundMangementRecord(_fund_ob);
                if (p_Var.dSet.Tables[0].Rows.Count > 0)
                {
                    grdfund.DataSource = p_Var.dSet;
                    grdfund.DataBind();
                }
                else
                {
                    //  Response.Write("<Script></Script>");
                    grdfund.DataSource = null;
                    grdfund.DataBind();
                    //Response.Write("<script language=javascript>alert('No Record found!');</script>");
                }
            }
        }
        else if (Session["UserType"].ToString() == "2")
        {
            //state user
            if (ddltigerreserve.SelectedValue == "0" && ddlvillage.SelectedValue == "0")
            {
                FunbDL _funddl = new FunbDL();
                FundOb _fund_ob = new FundOb();

                _fund_ob.StateUserID = Convert.ToInt32(Session["User_Id"]);
                _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);

                p_Var.dSet = _funddl.BindDefalultFundMangementRecord(_fund_ob);
                if (p_Var.dSet.Tables[0].Rows.Count > 0)
                {
                    grdfund.DataSource = p_Var.dSet;
                    grdfund.DataBind();
                }
                else
                {
                    //  Response.Write("<Script></Script>");
                    grdfund.DataSource = null;
                    grdfund.DataBind();
                    // Response.Write("<script language=javascript>alert('No Record found!');</script>");
                }
            }
        }
        else if (Session["UserType"].ToString() == "3")
        {
            if (ddltigerreserve.SelectedValue == "0" && ddlvillage.SelectedValue == "0")
            {
                FunbDL _funddl = new FunbDL();
                FundOb _fund_ob = new FundOb();

                _fund_ob.TigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
                _fund_ob.StateID = Convert.ToInt32(ddlstate.SelectedValue);

                p_Var.dSet = _funddl.BindDefalultFundMangementRecord(_fund_ob);
                if (p_Var.dSet.Tables[0].Rows.Count > 0)
                {
                    grdfund.DataSource = p_Var.dSet;
                    grdfund.DataBind();
                }
                else
                {
                    //  Response.Write("<Script></Script>");
                    grdfund.DataSource = null;
                    grdfund.DataBind();
                    //Response.Write("<script language=javascript>alert('No Record found!');</script>");
                }
            }
        }
        else
        {

        }
    }
    protected void btnfinalsumbit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in grdfund.Rows)
        {
            if (((CheckBox)gr.FindControl("childCheckbox")).Checked)
            {
                FunbDL _funddl1 = new FunbDL();
                FundOb objfund = new FundOb();
                objfund.FundId = Convert.ToInt32(((HiddenField)gr.FindControl("hydfundid")).Value);
                objfund.FundStatus = Convert.ToInt32(Module_ID_Enum.FundStatus.SendForRequest);
                _funddl1.SubmitFund(objfund);
            }
        }
        getFund_List();
    }
    protected void grdfund_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdfund_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hydActionButtonStatusTigerReserve = (HiddenField)e.Row.FindControl("HActionButtonStatusTigerReserveUser");
            HiddenField hydActionButtonStatusStateUser = (HiddenField)e.Row.FindControl("HActionButtonStatusStateUser");
            HiddenField hydActionButtonStatusNtcaUser = (HiddenField)e.Row.FindControl("HActionButtonStatusNtcaUser");
            HiddenField hydHFundSanctionStatus = (HiddenField)e.Row.FindControl("HFundSanctionStatus");

            ImageButton ImgFrwrd = (ImageButton)e.Row.FindControl("ImgForward");
            ImageButton ImgReturnStateUser = (ImageButton)e.Row.FindControl("ImgReturnStateUser");
            ImageButton ImgForwardStateUser = (ImageButton)e.Row.FindControl("ImgForwardStateUser");
            ImageButton ImgApproveNtcaUser = (ImageButton)e.Row.FindControl("ImgApproveNtcaUser");
            ImageButton ImgReturnNtcaUser = (ImageButton)e.Row.FindControl("ImgReturnNtcaUser");


            ImgFrwrd.ImageUrl = "~/auth/Adminpanel/images/forward.png";
            ImgFrwrd.ToolTip = "Forwarded by TIGER RESERVE user send to STATE user only";
            ImgReturnStateUser.ImageUrl = "~/auth/Adminpanel/images/return.png";
            ImgReturnStateUser.ToolTip = "Return by STATE user send to TIGER RESERVE user only";
            ImgForwardStateUser.ImageUrl = "~/auth/Adminpanel/images/forward.png";
            ImgForwardStateUser.ToolTip = "Forwarded by STATE user send to NTCA user only";
            ImgApproveNtcaUser.ImageUrl = "~/auth/Adminpanel/images/approve.png";
            ImgApproveNtcaUser.ToolTip = "Approve by NTCA user send to STATE user only";
            ImgReturnNtcaUser.ImageUrl = "~/auth/Adminpanel/images/return.png";
            ImgReturnNtcaUser.ToolTip = "Return by NTCA user send to STATE user only";
            if (Session["UserType"].ToString() == "1")
            {
                this.grdfund.Columns[5].Visible = false;//tiger reserve  user
                this.grdfund.Columns[7].Visible = false;//ntca user
                //super admin
                if (hydHFundSanctionStatus.Value == "Approved")
                {
                    ImgApproveNtcaUser.Visible = false;
                    ImgReturnNtcaUser.Visible = false;
                }
                if (hydActionButtonStatusTigerReserve.Value == "0" && hydActionButtonStatusStateUser.Value == "0" && hydActionButtonStatusNtcaUser.Value == "0")
                {
                    ImgApproveNtcaUser.Visible = false;
                    ImgReturnNtcaUser.Visible = false;
                }
                if (hydActionButtonStatusNtcaUser.Value == "1")
                {
                    ImgApproveNtcaUser.Visible = false;
                    ImgReturnNtcaUser.Visible = false;
                }
                ImgFrwrd.Visible = false;
                ImgReturnStateUser.Visible = false;
                ImgForwardStateUser.Visible = false;
            }
            else if (Session["UserType"].ToString() == "2")
            {
                this.grdfund.Columns[6].Visible = false;//state user
                //state user
                if (hydActionButtonStatusTigerReserve.Value == "0" && hydActionButtonStatusStateUser.Value == "0" && hydActionButtonStatusNtcaUser.Value == "0")
                {
                    ImgReturnStateUser.Visible = false;
                    ImgForwardStateUser.Visible = false;
                }
                if (hydActionButtonStatusStateUser.Value == "1")
                {
                    ImgReturnStateUser.Visible = false;
                    ImgForwardStateUser.Visible = false;
                }
                ImgFrwrd.Visible = false;
                ImgApproveNtcaUser.Visible = false;
                ImgReturnNtcaUser.Visible = false;
            }
            else if (Session["UserType"].ToString() == "3")
            {
                this.grdfund.Columns[7].Visible = false;//ntca user
                if (hydActionButtonStatusTigerReserve.Value == "0" && hydActionButtonStatusStateUser.Value == "0" && hydActionButtonStatusNtcaUser.Value == "0")
                {
                    ImgFrwrd.Visible = false;
                }
                if (hydActionButtonStatusTigerReserve.Value == "1")//this belongs to tiger reserved
                {
                    ImgFrwrd.Visible = false;

                }


                ImgReturnStateUser.Visible = false;
                ImgForwardStateUser.Visible = false;
                ImgApproveNtcaUser.Visible = false;
                ImgReturnNtcaUser.Visible = false;

            }


        }
    }
    protected void grdfund_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grdfund_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdfund.PageIndex = e.NewPageIndex;
        getFund_List();
        DefaultgetFund_List();
    }
    void BindMstUserByStateID()
    {
        FunbDL _fndDL = new FunbDL();
        FundOb _fundob = new FundOb();
        try
        {

            _fundob.StateID = Convert.ToInt32(StateID);
            p_Var.dSet = _fndDL.GetMstUserByStateID(_fundob);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                // StateID = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["id"]);
                StateUserID = (int)p_Var.dSet.Tables[0].Rows[0]["UserID"];
                StateUserName = (string)p_Var.dSet.Tables[0].Rows[0]["UserName"];
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            _fndDL.Dispose();

        }

    }

    //protected void BtnActionEvent_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow gr in grdfund.Rows)
    //    {
          
    //        if (Session["UserType"].ToString() == "1")
    //        {
    //            //super admin
    //            //state user
    //            BindMstUserByStateID();
    //            string ProccessButtonClickValue = HImageButtonClickFind.Value;
    //            int ProccessButtonClickID = Convert.ToInt32(HImageButtonClickFindID.Value);




    //            //--------------
    //            FunbDL _fndDL = new FunbDL();
    //            FundOb _fundob = new FundOb();

    //            _fundob.Fid = Convert.ToInt32(((HiddenField)gr.FindControl("HfundID")).Value);
    //            _fundob.TigerReserveUserID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveUserID")).Value);
    //            _fundob.TigerReserveUserName = ((HiddenField)gr.FindControl("HTigerReserveUserName")).Value;
    //            _fundob.TigerReserveID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveID")).Value);
    //            _fundob.TigerReserveName = ((HiddenField)gr.FindControl("HTigerReserveName")).Value;
    //            _fundob.VillageID = Convert.ToInt32(((HiddenField)gr.FindControl("HVillageID")).Value);
    //            _fundob.VillageName = ((HiddenField)gr.FindControl("HVillageName")).Value;
    //            //--------------------------
    //            _fundob.StateUserID = Convert.ToInt32(((HiddenField)gr.FindControl("HiStateUserID")).Value);
    //            _fundob.StateUserName = ((HiddenField)gr.FindControl("HStateUserName")).Value;
    //            _fundob.StateID = Convert.ToInt32(((HiddenField)gr.FindControl("HStateID")).Value);
    //            _fundob.StateName = ((HiddenField)gr.FindControl("HStateName")).Value;
    //            _fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
    //            try
    //            {
    //                _fundob.ProcessingStatusID = ProccessButtonClickID;
    //                _fundob.ProcessingStatusName = ProccessButtonClickValue;
    //                _fundob.ActionButtonStatusNtcaUser = 1;
    //                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
    //                _fundob.CreatedByUserName = (string)Session["UserName"];
    //                _fundob.FunDescription = txtamountdetials.Text.Trim();
    //                if (ProccessButtonClickID == 4)
    //                {
    //                    _fundob.FundSanctionStatus = "Approved";
    //                    _fundob.FundAmount = Convert.ToSingle(Convert.ToInt32(((HiddenField)gr.FindControl("HFundAmount")).Value));
    //                    _fundob.NtcaUserID = Convert.ToInt32(Convert.ToInt32(((HiddenField)gr.FindControl("HNtcaUserID")).Value));
    //                    _fundob.FundSanctionStatus = "Approved";
    //                    _fndDL.InsertFundManagementNTCAUser2(_fundob);
    //                    _fndDL.UpdateActionButtonStatusNTCAUser(_fundob);
    //                }
    //                else
    //                {

    //                    _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
    //                    _fndDL.InsertFundManagementNTCAUser(_fundob);
    //                    _fndDL.UpdateActionButtonStatusNTCAUser(_fundob);
    //                }




    //                //  


    //                //_fndDL.UpdateActionAPPROVEntcaUser(_fundob);

    //            }
    //            catch
    //            {

    //            }
    //            finally
    //            {
    //                _fndDL.Dispose();

    //            }

    //            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");

    //        }//

    //        if (Session["UserType"].ToString() == "2")
    //        {
    //            //state user
    //            BindMstUserByStateID();
    //            string ProccessButtonClickValue = HImageButtonClickFind.Value;
    //            int ProccessButtonClickID = Convert.ToInt32(HImageButtonClickFindID.Value);



    //            //--------------
    //            FunbDL _fndDL = new FunbDL();
    //            FundOb _fundob = new FundOb();

    //            _fundob.Fid = Convert.ToInt32(((HiddenField)gr.FindControl("HfundID")).Value);
    //            _fundob.TigerReserveUserID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveUserID")).Value);
    //            _fundob.TigerReserveUserName = ((HiddenField)gr.FindControl("HTigerReserveUserName")).Value;
    //            _fundob.TigerReserveID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveID")).Value);
    //            _fundob.TigerReserveName = ((HiddenField)gr.FindControl("HTigerReserveName")).Value;
    //            _fundob.VillageID = Convert.ToInt32(((HiddenField)gr.FindControl("HVillageID")).Value);
    //            _fundob.VillageName = ((HiddenField)gr.FindControl("HVillageName")).Value;

    //            _fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
    //            //--------------------------
    //            try
    //            {
    //                _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
    //                _fundob.FunDescription = txtamountdetials.Text.Trim();
    //                _fundob.StateUserID = StateUserID;
    //                _fundob.StateUserName = StateUserName;
    //                _fundob.StateID = StateID;
    //                _fundob.StateName = StateName;
    //                _fundob.ProcessingStatusID = ProccessButtonClickID;
    //                _fundob.ProcessingStatusName = ProccessButtonClickValue;
    //                _fundob.ActionButtonStatusStateUser = 1;
    //                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
    //                _fundob.CreatedByUserName = (string)Session["UserName"];
    //               // _fndDL.InsertFundManagementStateUser(_fundob);
    //               // _fndDL.UpdateActionButtonStatusStateUser(_fundob);


    //            }
    //            catch
    //            {

    //            }
    //            finally
    //            {
    //                _fndDL.Dispose();

    //            }

    //            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");

    //        }//

    //        if (Session["UserType"].ToString() == "3")
    //        {
    //            //state user
    //            BindMstUserByStateID();
    //            string ProccessButtonClickValue = HImageButtonClickFind.Value;
    //            int ProccessButtonClickID = Convert.ToInt32(HImageButtonClickFindID.Value);


    //            //--------------
    //            FunbDL _fndDL = new FunbDL();
    //            FundOb _fundob = new FundOb();

    //            _fundob.Fid = Convert.ToInt32(((HiddenField)gr.FindControl("HfundID")).Value);
    //            _fundob.TigerReserveUserID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveUserID")).Value);
    //            _fundob.TigerReserveUserName = ((HiddenField)gr.FindControl("HTigerReserveUserName")).Value;
    //            _fundob.TigerReserveID = Convert.ToInt32(((HiddenField)gr.FindControl("HTigerReserveID")).Value);
    //            _fundob.TigerReserveName = ((HiddenField)gr.FindControl("HTigerReserveName")).Value;
    //            _fundob.VillageID = Convert.ToInt32(((HiddenField)gr.FindControl("HVillageID")).Value);
    //            _fundob.VillageName = ((HiddenField)gr.FindControl("HVillageName")).Value;
    //            _fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
    //            //--------------------------
    //            try
    //            {
    //                _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
    //                _fundob.FunDescription = txtamountdetials.Text.Trim();
    //                _fundob.StateUserID = StateUserID;
    //                _fundob.StateUserName = StateUserName;
    //                _fundob.StateID = StateID;
    //                _fundob.StateName = StateName;
    //                _fundob.ProcessingStatusID = ProccessButtonClickID;
    //                _fundob.ProcessingStatusName = ProccessButtonClickValue;
    //                _fundob.ActionButtonStatusTigerReserveUser = 1;
    //                _fundob.ActionButtonStatusStateUser = 1;
    //                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
    //                _fundob.CreatedByUserName = (string)Session["UserName"];
    //                _fndDL.InsertFundManagement2(_fundob);
    //                _fndDL.UpdateActionButtonStatusTigerReserveUser(_fundob);


    //            }
    //            catch
    //            {

    //            }
    //            finally
    //            {
    //                _fndDL.Dispose();

    //            }

    //            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");


    //        }
    //    }
    //}
}
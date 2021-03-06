using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_FundManagement_FunPopUpSave : CrsfBase
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
           Bind_State();
           int iHImageButtonClickFindID = Convert.ToInt32(Request.QueryString["HImageButtonClickFindID"]);
           if (iHImageButtonClickFindID == 4)
           {
               txtfundRealeaseamount.Text = Request.QueryString["HFundAmount"].ToString();
               txtfundRealeaseamount.Enabled = false;
           }
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
    protected void BtnActionEvent_Click(object sender, EventArgs e)
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

                        if (Session["UserType"].ToString() == "1")
                        {
                            //super admin
                            //state user
                            BindMstUserByStateID();
                            string ProccessButtonClickValue = Request.QueryString["HImageButtonClickFind"].ToString();
                            int ProccessButtonClickID = Convert.ToInt32(Request.QueryString["HImageButtonClickFindID"]);




                            //--------------
                            FunbDL _fndDL = new FunbDL();
                            FundOb _fundob = new FundOb();

                            _fundob.Fid = Convert.ToInt32(Request.QueryString["HfundID"]);
                            _fundob.TigerReserveUserID = Convert.ToInt32(Request.QueryString["HTigerReserveUserID"]);
                            _fundob.TigerReserveUserName = Request.QueryString["HTigerReserveUserName"].ToString();
                            _fundob.TigerReserveID = Convert.ToInt32(Request.QueryString["HTigerReserveID"]);
                            _fundob.TigerReserveName = Request.QueryString["HTigerReserveName"].ToString();
                            _fundob.VillageID = Convert.ToInt32(Request.QueryString["HVillageID"]);
                            _fundob.VillageName = Request.QueryString["HVillageName"].ToString();
                            //--------------------------
                            _fundob.StateUserID = Convert.ToInt32(Request.QueryString["HiStateUserID"]);
                            _fundob.StateUserName = Request.QueryString["HStateUserName"].ToString();
                            _fundob.StateID = Convert.ToInt32(Request.QueryString["HStateID"]);
                            _fundob.StateName = Request.QueryString["HStateName"].ToString();
                            _fundob.CommonGroupQueryID = Convert.ToInt32(Request.QueryString["HCommonGroupQueryID"]);
                            try
                            {
                                _fundob.ProcessingStatusID = ProccessButtonClickID;
                                _fundob.ProcessingStatusName = ProccessButtonClickValue;
                                _fundob.ActionButtonStatusNtcaUser = 1;
                                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
                                _fundob.CreatedByUserName = (string)Session["UserName"];
                                _fundob.FunDescription = txtamountdetials.Text.Trim();
                                if (ProccessButtonClickID == 4)
                                {
                                    _fundob.FundSanctionStatus = "Approved";
                                    _fundob.FundAmount = Convert.ToSingle(Request.QueryString["HFundAmount"]);
                                    _fundob.NtcaUserID = Convert.ToInt32(Request.QueryString["HNtcaUserID"]);
                                    _fundob.FundSanctionStatus = "Approved";
                                    _fndDL.InsertFundManagementNTCAUser2(_fundob);
                                    _fndDL.UpdateActionButtonStatusNTCAUser(_fundob);
                                    txtfundRealeaseamount.Text = _fundob.FundAmount.ToString();

                                }
                                else
                                {

                                    _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
                                    _fndDL.InsertFundManagementNTCAUser(_fundob);
                                    _fndDL.UpdateActionButtonStatusNTCAUser(_fundob);
                                }
                                //  


                                //_fndDL.UpdateActionAPPROVEntcaUser(_fundob);

                            }
                            catch
                            {

                            }
                            finally
                            {
                                _fndDL.Dispose();

                            }

                            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");

                        }//

                        if (Session["UserType"].ToString() == "2")
                        {
                            //state user
                            BindMstUserByStateID();
                            string ProccessButtonClickValue = Request.QueryString["HImageButtonClickFind"].ToString();
                            int ProccessButtonClickID = Convert.ToInt32(Request.QueryString["HImageButtonClickFindID"]);



                            //--------------
                            FunbDL _fndDL = new FunbDL();
                            FundOb _fundob = new FundOb();

                            _fundob.Fid = Convert.ToInt32(Request.QueryString["HfundID"]);
                            _fundob.TigerReserveUserID = Convert.ToInt32(Request.QueryString["HTigerReserveUserID"]);
                            _fundob.TigerReserveUserName = Request.QueryString["HTigerReserveUserName"].ToString();
                            _fundob.TigerReserveID = Convert.ToInt32(Request.QueryString["HTigerReserveID"]);
                            _fundob.TigerReserveName = Request.QueryString["HTigerReserveName"].ToString();
                            _fundob.VillageID = Convert.ToInt32(Request.QueryString["HVillageID"]);
                            _fundob.VillageName = Request.QueryString["HVillageName"].ToString();

                            _fundob.CommonGroupQueryID = Convert.ToInt32(Request.QueryString["HCommonGroupQueryID"]);
                            //--------------------------
                            try
                            {
                                _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
                                _fundob.FunDescription = txtamountdetials.Text.Trim();
                                _fundob.StateUserID = StateUserID;
                                _fundob.StateUserName = StateUserName;
                                _fundob.StateID = StateID;
                                _fundob.StateName = StateName;
                                _fundob.ProcessingStatusID = ProccessButtonClickID;
                                _fundob.ProcessingStatusName = ProccessButtonClickValue;
                                _fundob.ActionButtonStatusStateUser = 1;
                                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
                                _fundob.CreatedByUserName = (string)Session["UserName"];
                                _fndDL.InsertFundManagementStateUser(_fundob);
                                _fndDL.UpdateActionButtonStatusStateUser(_fundob);


                            }
                            catch
                            {

                            }
                            finally
                            {
                                _fndDL.Dispose();

                            }

                            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");

                        }//

                        if (Session["UserType"].ToString() == "3")
                        {
                            //state user
                            BindMstUserByStateID();
                            string ProccessButtonClickValue = Request.QueryString["HImageButtonClickFind"].ToString();
                            int ProccessButtonClickID = Convert.ToInt32(Request.QueryString["HImageButtonClickFindID"]);


                            //--------------
                            FunbDL _fndDL = new FunbDL();
                            FundOb _fundob = new FundOb();

                            _fundob.Fid = Convert.ToInt32(Request.QueryString["HfundID"]);
                            _fundob.TigerReserveUserID = Convert.ToInt32(Request.QueryString["HTigerReserveUserID"]);
                            _fundob.TigerReserveUserName = Request.QueryString["HTigerReserveUserName"].ToString();
                            _fundob.TigerReserveID = Convert.ToInt32(Request.QueryString["HTigerReserveID"]);
                            _fundob.TigerReserveName = Request.QueryString["HTigerReserveName"].ToString();
                            _fundob.VillageID = Convert.ToInt32(Request.QueryString["HVillageID"]);
                            _fundob.VillageName = Request.QueryString["HVillageName"].ToString();
                            _fundob.CommonGroupQueryID = Convert.ToInt32(Request.QueryString["HCommonGroupQueryID"]);
                            //--------------------------
                            try
                            {
                                _fundob.FundAmount = Convert.ToSingle(txtfundRealeaseamount.Text.Trim());
                                _fundob.FunDescription = txtamountdetials.Text.Trim();
                                _fundob.StateUserID = StateUserID;
                                _fundob.StateUserName = StateUserName;
                                _fundob.StateID = StateID;
                                _fundob.StateName = StateName;
                                _fundob.ProcessingStatusID = ProccessButtonClickID;
                                _fundob.ProcessingStatusName = ProccessButtonClickValue;
                                _fundob.ActionButtonStatusTigerReserveUser = 1;
                                _fundob.ActionButtonStatusStateUser = 1;
                                _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
                                _fundob.CreatedByUserName = (string)Session["UserName"];
                                _fndDL.InsertFundManagement2(_fundob);
                                _fndDL.UpdateActionButtonStatusTigerReserveUser(_fundob);


                            }
                            catch
                            {

                            }
                            finally
                            {
                                _fndDL.Dispose();

                            }

                            Response.Redirect("~/auth/adminpanel/FundManagement/viewfund.aspx");
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

}
//}
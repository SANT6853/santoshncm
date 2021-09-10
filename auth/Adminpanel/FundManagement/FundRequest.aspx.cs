using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_FundManagement_FundRequest : System.Web.UI.Page
{
    string LoginUserid;
    int LoginUsertype;
    static int StateID;
  static  int StateUserID;
  static string StateUserName;

    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    Project_Variables p_Var = new Project_Variables();
    VillageBL _villageBl = new VillageBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Commanfuction _commanfuction = new Commanfuction();
    FunbDL _fndDL = new FunbDL();
    FundOb _fundob = new FundOb();
       
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
                BindMstUserByStateID();
                Bind_TigerReserveUserAccess();             
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                        
        }
    }
    void BindMstUserByStateID()
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
    protected void ddltigerreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_VillageList();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            StateID =Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["id"]);
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
    protected void btnsumbit_Click(object sender, EventArgs e)
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
                            _fundob.StateUserID = StateUserID;
                            _fundob.StateUserName = StateUserName;
                            _fundob.TigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
                            _fundob.TigerReserveUserName = (string)Session["UserName"];
                            _fundob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                            _fundob.StateName = ddlstate.SelectedItem.Text;
                            _fundob.TigerReserveID = Convert.ToInt32(ddltigerreserve.SelectedValue);
                            _fundob.TigerReserveName = ddltigerreserve.SelectedItem.Text;
                            _fundob.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
                            _fundob.VillageName = ddlvillage.SelectedItem.Text;
                            _fundob.FundAmount = Convert.ToSingle(txtamount.Text);
                            _fundob.FunDescription = txtfunddescription.Text.Trim();
                            _fundob.ProcessingStatusID = GloballyStaticVariable.ProcessingID_FrwdByTigerReserve;
                            _fundob.ProcessingStatusName = GloballyStaticVariable.ProcessingName_FrwdByTigerReserve;
                            _fundob.ActionButtonStatusTigerReserveUser = 1;

                            _fundob.CreatedByID = Convert.ToInt32(Session["User_Id"]);
                            _fundob.CreatedByUserName = (string)Session["UserName"];
                            _fndDL.InsertFundManagement(_fundob);

                            Session["msg"] = "Fund has been saved successfully.";
                        }
                        ////catch
                        ////{
                        ////    Session["msg"] = "Fund has not been saved successfully.";
                        //}
                        //finally
                        //{
                        //    _fndDL.Dispose();
                        //}
                        Session["BackUrl"] = "~/Auth/AdminPanel/FundManagement/viewfund.aspx";
                        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                    }
                    // }

                }
            }
        catch
        {
            throw;
        }
        // }
    }

    protected void ddlvillage_SelectedIndexChanged(object sender, EventArgs e)
    {
        FunbDL _fndl=new FunbDL();
        p_Var.dSetChildData = _fndl.Get_Village_DetailsSummary(Convert.ToInt32(ddlvillage.SelectedValue));
        if (p_Var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            txttotalfamily.Text = p_Var.dSetChildData.Tables[0].Rows[0]["TotalFamily"].ToString();
            txtfamillymember.Text = p_Var.dSetChildData.Tables[0].Rows[0]["TotalFamilyMember"].ToString();
            txtoption1.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Cash"].ToString();
            txtoption2.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Rellacation"].ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Familymanegment_ViewFamily : System.Web.UI.Page
{
    string LoginUserid;
    int LoginUsertype;
    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    Project_Variables p_Var = new Project_Variables();
    VillageBL _villageBl = new VillageBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Commanfuction _commanfuction = new Commanfuction();
    FamilyBL _familybl = new FamilyBL();
    FamilyOB _familyOB = new FamilyOB();
    PaginationBL pagingBL = new PaginationBL();
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
            Bind_TigerReserveUserAccess();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));


        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
    }
    
    protected void ddltigerreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_VillageList();
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
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = p_Var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Displayfamily(1);
    }
    protected void lnkPage_Click(object sender, EventArgs e)
    {
        int index = int.Parse((sender as LinkButton).CommandArgument);
        this.Displayfamily(index);
    }
    protected void OnSelectedIndexChanged_PageSizeChanged(object sender, EventArgs e)
    {
        Displayfamily(1);
    }
    void Displayfamily(int PageIndex)
    {
        _familyOB.Stateid = Convert.ToInt32(ddlstate.SelectedValue);
        _familyOB.TigerReserveid = Convert.ToInt32(ddltigerreserve.SelectedValue);
        _familyOB.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
        _familyOB.PageNumber = PageIndex;
        _familyOB.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        p_Var.dSet = _familybl.get_FamilyList(_familyOB);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            p_Var.count = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["TotalRecord"].ToString());
            pagingBL.Paging_Show(p_Var.count, PageIndex, ddlPageSize, rptPager);
            rptPager.Visible = true;
        }
        else
        {
            divPager.Visible = false;
        }
            grdfamily.DataSource = p_Var.dSet;
        grdfamily.DataBind();
    }
   
}
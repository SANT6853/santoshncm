using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class auth_Adminpanel_Dashboard : System.Web.UI.Page
{
    #region Data declaration zone
    NtcaUserOB _ntcauserob = new NtcaUserOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    VillageOB villageObject = new VillageOB();
    VillageBL villageBL = new VillageBL();
    Project_Variables p_Var = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    PaginationBL pagingBL = new PaginationBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    string LoginUserid;
    int LoginUsertype;
    #endregion
    public static int TigerReserveID;
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["LG"] = "TIGER";
        Page.Header.DataBind();
        //naren
        if (!IsPostBack)
        {//Session["UserType"]!= null
            Session["LG"] = "TIGER";
            if (!string.IsNullOrWhiteSpace(Session["UserType"] as string))
            {
              //  Session["LG"] = "TIGER";
                //UserType
                //if (Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "3")
                //{
                    // if (!string.IsNullOrWhiteSpace(Session["UserType"] as string))
                    //Session["ntca_StateID"] == null
                if (Session["ntca_StateID"] == null)
                {
                    if (Request.QueryString["MapStatID"].ToString() != "0")
                    {
                        Session["ntca_StateID"] = Request.QueryString["StateID"].ToString();
                        Session["ntca_MapStatID"] = Request.QueryString["MapStatID"].ToString();
                        Session["ntca_MapDistricID"] = Request.QueryString["MapDistricID"].ToString();
                        Session["ntca_TigerReserveid"] = Request.QueryString["TigerReserveid"].ToString();
                        Session["ntca_DataOperatorUserID"] = Request.QueryString["DataOperatorUserID"].ToString();
                        //  -----------------------
                        Session["1ntca_StateID"] = Session["ntca_StateID"].ToString();
                        Session["1ntca_MapStatID"] = Session["ntca_MapStatID"].ToString();
                        Session["1ntca_MapDistricID"] = Session["ntca_MapDistricID"].ToString();
                        Session["1ntca_TigerReserveid"] = Session["ntca_TigerReserveid"].ToString();
                        Session["1ntca_DataOperatorUserID"] = Session["ntca_DataOperatorUserID"].ToString();
                    }
                    else
                    {
                        Session["ntca_StateID"] = Request.QueryString["StateID"].ToString();
                        Session["ntca_MapStatID"] = Request.QueryString["MapStatID"].ToString();
                        Session["ntca_MapDistricID"] = Request.QueryString["MapDistricID"].ToString();
                        Session["ntca_TigerReserveid"] = Request.QueryString["TigerReserveid"].ToString();
                        Session["ntca_DataOperatorUserID"] = Request.QueryString["DataOperatorUserID"].ToString();
                        //  -----------------------
                        Session["1ntca_StateID"] = Session["ntca_StateID"].ToString();
                        Session["1ntca_MapStatID"] = Session["ntca_MapStatID"].ToString();
                        Session["1ntca_MapDistricID"] = Session["ntca_MapDistricID"].ToString();
                        Session["1ntca_TigerReserveid"] = Session["ntca_TigerReserveid"].ToString();
                        Session["1ntca_DataOperatorUserID"] = Session["ntca_DataOperatorUserID"].ToString();
                    }
                }


               // }


                if (Session["UserType"].ToString() == "4")
                {

                    NGoCounter();
                    dCdpMng.Attributes.Add("style", "display:none;");
                    tigerboard.Attributes.Add("style", "display:none;");
                    VillageCounter4();
                    FamilyCounter4();
                    TigerReserveCounter4();
                    //NgoCounter4();

                    //if (Request.QueryString != null && Request.QueryString["StateID"] != null && Request.QueryString["StateID"] == "1")
                    //{
                        Session["sTigerReserveName"] = Session["sTigerReserveName"].ToString();
                        Session["sStateID"] = Session["sStateID"].ToString();
                        Session["sStatename"] = Session["sStateName"].ToString();

                        Session["sTreserveID"] = Session["sTigerReserveid"].ToString();
                        TigerReserveID = Convert.ToInt32(Session["sTreserveID"]);

                  //  }



                    DisplayVillageInGrid(1);
                    GetStateUserTigerReserveUserID();
                }



                if (Session["UserType"].ToString() == "3")
                {
                    NGoCounter();
                    dBannerMang.Visible = false;
                    dCdpMng.Visible = false;
                    dCms.Visible = false;
                    VillageCounter3();
                    FamilyCounter3();
                    TigerReserveCounter3();
                   // NgoCounter3();
                    DisplayVillageInGridTigerUser(1);
                    GetStateUserTigerReserveUserID();
                }
                if (Session["UserType"].ToString() == "2")
                {
                    NGoCounter();
                    dBannerMang.Attributes.Add("style", "display:none;");
                    dCdpMng.Attributes.Add("style", "display:none;");
                    dCms.Visible = false;
                    VillageCounter2();
                    FamilyCounter2();
                    TigerReserveCounter2();
                   // NgoCounter2();
                    DisplayVillageInGridStateUser(1);
                    GetStateUserTigerReserveUserID();
                }

            }
            else
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"));

            }
            
        }
    }
    void VillageCounter4()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 1;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblVillageCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["VillageCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void NGoCounter()
    {
        p_Var.dSet = null;
        try
        {
            
            if (Session["UserType"].ToString() == "1")
            {
                villageObject.StateID = null;
            }
            if (Session["UserType"].ToString() == "2")
            {
                villageObject.StateID = Convert.ToInt32(Session["PermissionState"]);
            }
            if (Session["UserType"].ToString() == "3")
            {
                villageObject.StateID = Convert.ToInt32(Session["PermissionState"]);
            }
            if (Session["UserType"].ToString() == "4")
            {
                villageObject.StateID = Convert.ToInt32(Session["PermissionState"]);
            }
           
          //  villageObject.ActionType = 1;
            p_Var.dSet = villageBL.NGoDashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblNgocounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["countDown"].ToString();
                LblPostcounter.InnerText= p_Var.dSet.Tables[1].Rows[0]["countDown"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void VillageCounter3()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.CmnTigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 2;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblVillageCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["VillageCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void VillageCounter2()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.CmnStateUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 3;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblVillageCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["VillageCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }

    void FamilyCounter4()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 5;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblFamilyCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["FamilyCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void FamilyCounter3()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.CmnTigerReserveUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 6;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblFamilyCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["FamilyCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void FamilyCounter2()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.CmnStateUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 7;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblFamilyCounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["FamilyCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }

    void TigerReserveCounter4()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 9;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblTigerReserve.InnerText = p_Var.dSet.Tables[0].Rows[0]["TigerReserveCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void TigerReserveCounter3()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 10;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblTigerReserve.InnerText = p_Var.dSet.Tables[0].Rows[0]["TigerReserveCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void TigerReserveCounter2()
    {
        p_Var.dSet = null;
        try
        {
            villageObject.PermissionState = Convert.ToInt32(Session["PermissionState"]);
            villageObject.ActionType = 11;
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblTigerReserve.InnerText = p_Var.dSet.Tables[0].Rows[0]["TigerReserveCount"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }

    void NgoCounter4()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            //villageObject.Submitedby=
            villageObject.ActionType = 14;
          //  villageObject.StateID = (Convert.ToInt32(Session["PermissionState"]));
            p_Var.dSet = villageBL.DashBoardCounterNTCA(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblNgocounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["ngoCounter"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void NgoCounter3()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            //villageObject.Submitedby=
            villageObject.ActionType = 14;
            villageObject.StateID = (Convert.ToInt32(Session["PermissionState"]));
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblNgocounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["ngoCounter"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    void NgoCounter2()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            //villageObject.Submitedby=
            villageObject.ActionType = 14;
            villageObject.StateID = (Convert.ToInt32(Session["PermissionState"]));
            p_Var.dSet = villageBL.DashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblNgocounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["ngoCounter"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    public void GetUserNameOfStateReserveDfo(int StateUserID, int ReserveUserID, int DfoUserId)
    {
        try
        {
            p_Var.dSet = null;
            villageObject.StateUserID = StateUserID;
            villageObject.ReserveUserId = ReserveUserID;
            villageObject.DfoUserID = DfoUserId;
            p_Var.dSet = villageBL.GetUserNameOfStateReserveDfoDAL(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)//@StateUserID
            {
                Session["DashStateUserName"] = p_Var.dSet.Tables[0].Rows[0]["StateUserName"].ToString();

            }
            if (p_Var.dSet.Tables[1].Rows.Count > 0)//@ReserveUserId
            {
                Session["DashReserveUserName"] = p_Var.dSet.Tables[1].Rows[0]["ReserveUserName"].ToString();
            }
            if (p_Var.dSet.Tables[2].Rows.Count > 0)//@DfoUserID
            {
                Session["DfoUserName"] = p_Var.dSet.Tables[2].Rows[0]["DfoUserName"].ToString();
            }
            if (p_Var.dSet.Tables[3].Rows.Count > 0)//@ntcha
            {
                Session["DashNtcaUserName"] = p_Var.dSet.Tables[3].Rows[0]["NtcaUserName"].ToString();
            }


        }
        catch (Exception er)
        {
            throw;
        }
    }
    public void GetStateUserTigerReserveUserID()
    {
        try
        {
            p_Var.dSet = null;
            villageObject.CmnDataOperatorUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.CmnStateID = Convert.ToInt32(Session["PermissionState"]);
            p_Var.dSet = villageBL.GetStateUserTigerReserveUserDataOperatorUser(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                Session["CmnDataOperatorUserID"] = p_Var.dSet.Tables[0].Rows[0]["DataOperatorUserID"].ToString();
                Session["CmnTigerReserveUserID"] = p_Var.dSet.Tables[0].Rows[0]["TigerReserveUserID"].ToString();
                Session["CmnTigerReserveID"] = p_Var.dSet.Tables[0].Rows[0]["TigerReserveID"].ToString();
            }
            if (p_Var.dSet.Tables[1].Rows.Count > 0)
            {
                Session["CmnStateUser"] = p_Var.dSet.Tables[1].Rows[0]["StateUser"].ToString();
            }
            if (Session["CmnDataOperatorUserID"] != null || Session["CmnTigerReserveUserID"] != null || Session["CmnStateUser"] != null)
            {
                GetUserNameOfStateReserveDfo(Convert.ToInt32(Session["CmnStateUser"]), Convert.ToInt32(Session["CmnTigerReserveUserID"]), Convert.ToInt32(Session["CmnDataOperatorUserID"]));
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    private void DisplayVillageInGrid(int pageindex)
    {
        if (Convert.ToInt32(Session["sStateID"]) != 0)
        {
            villageObject.StateID = Convert.ToInt32(Session["sStateID"]);
        }
        else
        {
            villageObject.StateID = null;
        }

        if (Convert.ToInt32(Session["sTreserveID"]) != 0)
        {
            villageObject.TigerReserveid = Convert.ToInt32(Session["sTreserveID"]);
        }
        else
        {
            villageObject.TigerReserveid = null;
        }


        villageObject.Pageindex = pageindex;
        villageObject.PageSize = Convert.ToInt32(100);
        p_Var.dSet = villageBL.getVillageList(villageObject);

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            p_Var.count = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["TotalRecord"].ToString());
            //pagingBL.Paging_Show(p_Var.count, pageindex, ddlPageSize, rptPager);
            //rptPager.Visible = true;
            gvVillage.DataSource = p_Var.dSet;
            gvVillage.DataBind();
            lblcount.Text = p_Var.count.ToString();
            lblcount.ForeColor = System.Drawing.Color.Black;


            //divGrid.Visible = true;

            //divPager.Visible = true;

            p_Var.dSet = null;

            lblnorecord.Text = "";
        }
        else
        {
            lblnorecord.Text = "Record(s) Not Available.";
            //divGrid.Visible = false;
            //divPager.Visible = false;
        }

    }
    private void DisplayVillageInGridTigerUser(int pageindex)
    {
        if (Convert.ToInt32(Session["sStateID"]) != 0)
        {
            villageObject.StateID = Convert.ToInt32(Session["sStateID"]);
        }
        else
        {
            villageObject.StateID = null;
        }

        if (Convert.ToInt32(Session["sTreserveID"]) != 0)
        {
            villageObject.TigerReserveid = Convert.ToInt32(Session["sTreserveID"]);
        }
        else
        {
            villageObject.TigerReserveid = null;
        }


        villageObject.Pageindex = pageindex;
        villageObject.PageSize = Convert.ToInt32(100);
        p_Var.dSet = villageBL.getVillageListTigerUser(villageObject);

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            p_Var.count = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["TotalRecord"].ToString());
            //pagingBL.Paging_Show(p_Var.count, pageindex, ddlPageSize, rptPager);
            //rptPager.Visible = true;
            gvVillage.DataSource = p_Var.dSet;
            gvVillage.DataBind();
            lblcount.Text = p_Var.count.ToString();
            lblcount.ForeColor = System.Drawing.Color.Black;


            //divGrid.Visible = true;

            //divPager.Visible = true;

            p_Var.dSet = null;

            lblnorecord.Text = "";
        }
        else
        {
            lblnorecord.Text = "Record(s) Not Available.";
            //divGrid.Visible = false;
            //divPager.Visible = false;
        }

    }
    private void DisplayVillageInGridStateUser(int pageindex)
    {
        if (Convert.ToInt32(Session["sStateID"]) != 0)
        {
            villageObject.StateID = Convert.ToInt32(Session["sStateID"]);
        }
        else
        {
            villageObject.StateID = null;
        }

        if (Convert.ToInt32(Session["sTreserveID"]) != 0)
        {
            villageObject.TigerReserveid = Convert.ToInt32(Session["sTreserveID"]);
        }
        else
        {
            villageObject.TigerReserveid = null;
        }


        villageObject.Pageindex = pageindex;
        villageObject.PageSize = Convert.ToInt32(100);
        p_Var.dSet = villageBL.getVillageListStateUser(villageObject);

        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            p_Var.count = Convert.ToInt32(p_Var.dSet.Tables[0].Rows[0]["TotalRecord"].ToString());
            //pagingBL.Paging_Show(p_Var.count, pageindex, ddlPageSize, rptPager);
            //rptPager.Visible = true;
            gvVillage.DataSource = p_Var.dSet;
            gvVillage.DataBind();
            lblcount.Text = p_Var.count.ToString();
            lblcount.ForeColor = System.Drawing.Color.Black;


            //divGrid.Visible = true;

            //divPager.Visible = true;

            p_Var.dSet = null;

            lblnorecord.Text = "";
        }
        else
        {
            lblnorecord.Text = "Record(s) Not Available.";
            //divGrid.Visible = false;
            //divPager.Visible = false;
        }

    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByStateID(int StateID, string mapStatID)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByStateID1(StateID, mapStatID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            _poa.RelocateVillageList = "Record not available";
            _poa.RelocateyetVillageList = "Record not available";
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            // _poa.Notice = "You have permission to access this tiger reserver.Please click to login!!";

            //9june
            //No. of the villages in the notified Core (CTH)[Village]--
            _poa.Village = dr["Village"].ToString();
            //No. of the families in the notified Core (CTH)[family]--
            _poa.Family = dr["Family"].ToString();
            // -- No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger[relocatedvill]
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

            //--No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger[relocatefam]
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            //--No. of villages remaining inside the core (CTH)[remainvill]
            _poa.RemainVill = dr["RemainVill"].ToString();


            //--No.of families remaining inside the core (CTH)[remainfam]
            _poa.RemainFam = dr["RemainFam"].ToString();
            //--10 Lakh per Family[moneyperfam]
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
            //--1 Lakh per Family & Land[landandmoney]
            _poa.landAndMoney = dr["landAndMoney"].ToString();
            //--Families relocated with any other package[villrelocotherpack]
            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();
            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByDistrictID(int StateID, string mapStatID, int mapDistricid, string TigerReserID)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        // p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoard(StateID, mapStatID, mapDistricid, TigerReserID);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoard44(StateID, mapStatID, mapDistricid, TigerReserID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            //_poa.RelocateVillageList = "Record not available";
            //_poa.RelocateyetVillageList = "Record not available";

            _poa.RelocateVillageList = dr["Relocated"].ToString();
            _poa.RelocateyetVillageList = dr["YetRelocated"].ToString();
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            _poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            //9june
            //No. of the villages in the notified Core (CTH)[Village]--
            _poa.Village = dr["Village"].ToString();
            //No. of the families in the notified Core (CTH)[family]--
            _poa.Family = dr["Family"].ToString();
            // -- No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger[relocatedvill]
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

            //--No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger[relocatefam]
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            //--No. of villages remaining inside the core (CTH)[remainvill]
            _poa.RemainVill = dr["RemainVill"].ToString();


            //--No.of families remaining inside the core (CTH)[remainfam]
            _poa.RemainFam = dr["RemainFam"].ToString();
            //--10 Lakh per Family[moneyperfam]
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
            //--1 Lakh per Family & Land[landandmoney]
            _poa.landAndMoney = dr["landAndMoney"].ToString();
            //--Families relocated with any other package[villrelocotherpack]
            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();
            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();

            //------------------
            _poa.DistrictIconImage = "";
            if (dr["Remarks"].ToString() == "")
            {
                _poa.DistrictIconImage = "";
            }
            else
            {
                _poa.DistrictIconImage = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<img id=\"theImg\" src=\"./images/ttt.jpg\" prepended=\"yes\" width=\"25px\"/>";
            }
            //--------------------
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByDistrictIDTigerUser33(int StateID, string mapStatID, string ParentTigerReserveUserID, string MapDistrictID)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        p_Var.dsFileName = null;
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        // p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser(StateID, mapStatID, ParentTigerReserveUserID, MapDistrictID);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser330(StateID, mapStatID, ParentTigerReserveUserID, MapDistrictID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            //_poa.RelocateVillageList = "Record not available";
            //_poa.RelocateyetVillageList = "Record not available";
            _poa.RelocateVillageList = dr["Relocated"].ToString();
            _poa.RelocateyetVillageList = dr["YetRelocated"].ToString();

            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            _poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            //9june
            //No. of the villages in the notified Core (CTH)[Village]--
            _poa.Village = dr["Village"].ToString();
            //No. of the families in the notified Core (CTH)[family]--
            _poa.Family = dr["Family"].ToString();
            // -- No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger[relocatedvill]
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

            //--No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger[relocatefam]
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            //--No. of villages remaining inside the core (CTH)[remainvill]
            _poa.RemainVill = dr["RemainVill"].ToString();


            //--No.of families remaining inside the core (CTH)[remainfam]
            _poa.RemainFam = dr["RemainFam"].ToString();
            //--10 Lakh per Family[moneyperfam]
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
            //--1 Lakh per Family & Land[landandmoney]
            _poa.landAndMoney = dr["landAndMoney"].ToString();
            //--Families relocated with any other package[villrelocotherpack]
            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();
            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();
            _poa.DistrictIconImage = "";
            if (dr["Remarks"].ToString() == "")
            {
                _poa.DistrictIconImage = "";
            }
            else
            {
                _poa.DistrictIconImage = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<img id=\"theImg\" src=\"./images/ttt.jpg\" prepended=\"yes\" width=\"25px\"/>";
            }
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByDistrictIDTigerUser(int StateID, string mapStatID, string ParentTigerReserveUserID, string MapDistrictID)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        p_Var.dsFileName = null;
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        // p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser(StateID, mapStatID, ParentTigerReserveUserID, MapDistrictID);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser33(StateID, mapStatID, ParentTigerReserveUserID, MapDistrictID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            //_poa.RelocateVillageList = "Record not available";
            //_poa.RelocateyetVillageList = "Record not available";
            _poa.RelocateVillageList = dr["Relocated"].ToString();
            _poa.RelocateyetVillageList = dr["YetRelocated"].ToString();

            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            _poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            //9june
            //No. of the villages in the notified Core (CTH)[Village]--
            _poa.Village = dr["Village"].ToString();
            //No. of the families in the notified Core (CTH)[family]--
            _poa.Family = dr["Family"].ToString();
            // -- No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger[relocatedvill]
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

            //--No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger[relocatefam]
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            //--No. of villages remaining inside the core (CTH)[remainvill]
            _poa.RemainVill = dr["RemainVill"].ToString();


            //--No.of families remaining inside the core (CTH)[remainfam]
            _poa.RemainFam = dr["RemainFam"].ToString();
            //--10 Lakh per Family[moneyperfam]
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
            //--1 Lakh per Family & Land[landandmoney]
            _poa.landAndMoney = dr["landAndMoney"].ToString();
            //--Families relocated with any other package[villrelocotherpack]
            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();
            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();
            _poa.DistrictIconImage = "";
            if (dr["Remarks"].ToString() == "")
            {
                _poa.DistrictIconImage = "";
            }
            else
            {
                _poa.DistrictIconImage = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<img id=\"theImg\" src=\"./images/ttt.jpg\" prepended=\"yes\" width=\"25px\"/>";
            }
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByDistrictIDStateUser(int StateID, string mapStatID, string MapDistrictID)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        p_Var.dsFileName = null;
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        //   p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDStateUserMap(StateID, mapStatID,MapDistrictID);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDStateUserMap22(StateID, mapStatID, MapDistrictID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            //_poa.RelocateVillageList = "Record not available";
            //_poa.RelocateyetVillageList = "Record not available";
            _poa.RelocateVillageList = dr["Relocated"].ToString();
            _poa.RelocateyetVillageList = dr["YetRelocated"].ToString();
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            _poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            //9june
            //No. of the villages in the notified Core (CTH)[Village]--
            _poa.Village = dr["Village"].ToString();
            //No. of the families in the notified Core (CTH)[family]--
            _poa.Family = dr["Family"].ToString();
            // -- No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger[relocatedvill]
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

            //--No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger[relocatefam]
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            //--No. of villages remaining inside the core (CTH)[remainvill]
            _poa.RemainVill = dr["RemainVill"].ToString();


            //--No.of families remaining inside the core (CTH)[remainfam]
            _poa.RemainFam = dr["RemainFam"].ToString();
            //--10 Lakh per Family[moneyperfam]
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
            //--1 Lakh per Family & Land[landandmoney]
            _poa.landAndMoney = dr["landAndMoney"].ToString();
            //--Families relocated with any other package[villrelocotherpack]
            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();
            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();
            //------------------
            _poa.DistrictIconImage = "";
            if (dr["Remarks"].ToString() == "")
            {
                _poa.DistrictIconImage = "";
            }
            else
            {
                _poa.DistrictIconImage = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<img id=\"theImg\" src=\"./images/ttt.jpg\" prepended=\"yes\" width=\"25px\"/>";
            }
            //--------------------
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }

    public class HighChart
    {

        public string name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string drilldown { get; set; }
        public string VillageList { get; set; }
        public string RelocateVillageList { get; set; }
        public string RelocateyetVillageList { get; set; }
        public int StateID { get; set; }
        public string mapStatID { get; set; }
        public string MapDistrictID { get; set; }
        public int TigerReserveid { get; set; }
        public int DataOperatorUserID { get; set; }
        // public string Notice { get; set; }
        public string Village { get; set; }
        public string RelocatedVill { get; set; }
        public string RemainVill { get; set; }
        public string Family { get; set; }
        public string RelocateFam { get; set; }
        public string RemainFam { get; set; }
        public string MoneyPerfam { get; set; }
        // public string LandPackge { get; set; }
        public string landAndMoney { get; set; }
        public string VillRelocOtherPack { get; set; }
        public string SNO { get; set; }
        public string Remarks { get; set; }
        public string DistrictIconImage { get; set; }
        //public string Remarks { get; set; }
        // public string Notice { get; set; }
    }
    protected void gvVillage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvVillage_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}
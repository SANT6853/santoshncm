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
public partial class auth_Adminpanel_DashboardNTCA : System.Web.UI.Page
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
    public static int TigerReserveID;
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["LG"] = "NTCA";
        Page.Header.DataBind();
        //naren
        if (!IsPostBack)
        {//Session["UserType"]!= null
            Session["LG"] = "NTCA";
            if (!string.IsNullOrWhiteSpace(Session["UserType"] as string))
            {
              //  Session["LG"] = "NTCA";
                DisplayVillageInGrid(1);
               // if (Session["UserType"].ToString() == "1")
               // {//Request.QueryString["StateID"].ToString() != null && 
                    //Request.QueryString != null && Request.QueryString["id"] != null && Request.QueryString["id"] == "1"
                    //Session["ntca_StateID"] == null

                    //if (Session["ntca_StateID"] == null)
                    //{
                    //    Session["ntca_StateID"] = Request.QueryString["StateID"].ToString();
                    //    Session["ntca_MapStatID"] = Request.QueryString["MapStatID"].ToString();
                    //    Session["ntca_MapDistricID"] = Request.QueryString["MapDistricID"].ToString();
                    //    Session["ntca_TigerReserveid"] = Request.QueryString["TigerReserveid"].ToString();
                    //    Session["ntca_DataOperatorUserID"] = Request.QueryString["DataOperatorUserID"].ToString();

                    //    //-----------------------
                    //    Session["1ntca_StateID"] = Session["ntca_StateID"].ToString();
                    //    Session["1ntca_MapStatID"] = Session["ntca_MapStatID"].ToString();
                    //    Session["1ntca_MapDistricID"] = Session["ntca_MapDistricID"].ToString();
                    //    Session["1ntca_TigerReserveid"] = Session["ntca_TigerReserveid"].ToString();
                    //    Session["1ntca_DataOperatorUserID"] = Session["ntca_DataOperatorUserID"].ToString();
                    //}
                    

                    //---------------------------------

                    VillageCounter1();
                    FamilyCounter1();
                    TigerReserveCounter1();
                   // NgoCounter1();
                    NGoCounter();
               // }
            }
        }

    }
    void NGoCounter()
    {
        p_Var.dSet = null;
        try
        {

           
            villageObject.StateID = null;
            //  villageObject.ActionType = 1;
            p_Var.dSet = villageBL.NGoDashBoardCounter(villageObject);

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                LblNgocounter.InnerText = p_Var.dSet.Tables[0].Rows[0]["countDown"].ToString();
                Labelpost.InnerText= p_Var.dSet.Tables[1].Rows[0]["countDown"].ToString();
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    #region[India map Icon code]
    //

    [WebMethod]
    public static HighChart[] ChkRecordExistInStateBihar(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();
            //  _poa = null;
            _poa.BiharStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateUp(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();
            //  _poa = null;

            _poa.UttarPradeshStateName = dr["StateName"].ToString();

            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateAndamanNicobar(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();
            //  _poa = null;

            _poa.AndamanNicobarStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateAndhraPradesh(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.AndhraPradeshStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateArunachalPradesh(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.ArunachalPradeshStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateAssam(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.AssamStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateChhattisgarh(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.ChhattisgarhStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateChandigarh(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.ChandigarhStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateDamanDiu(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.DamanDiuStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInStateDelhi(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.DelhiStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInDadraHaveliStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.DadraHaveliStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInGoaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.GoaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInGujaratStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.GujaratStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInHimachalPradeshStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.HimachalPradeshStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInHaryanaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.HaryanaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInJammuKashmirStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.JammuKashmirStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInJharkhandStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.JharkhandStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInKeralaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.KeralaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInKarnatakaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.KarnatakaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInLakshadweepStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.LakshadweepStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInMeghalayaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.MeghalayaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInMaharashtraStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.MaharashtraStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInManipurStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.ManipurStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInMadhyaPradeshStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.MadhyaPradeshStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInMizoramStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.MizoramStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInNagalandStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.NagalandStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInOrissaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.OrissaStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInPunjabStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.PunjabStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInPuducherryStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.PuducherryStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInRajasthanStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.RajasthanStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInSikkimStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.SikkimStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInTamilNaduStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.TamilNaduStateName = dr["StateName"].ToString();

            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInTripuraStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.TripuraStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInUttarakhandStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.UttarakhandStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInWestBengalStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();


            _poa.WestBengalStateName = dr["StateName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkRecordExistInTelenganaStateName(string StateName)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.MapStateRecordExistanceCheckDal(StateName);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            _poa.TelenganaStateName = dr["StateName"].ToString();

            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }


    //
    #endregion
    void NgoCounter1()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.UserID = Convert.ToInt32(Session["User_Id"]);
            //villageObject.Submitedby=
            villageObject.ActionType = 15;
         //   villageObject.StateID = (Convert.ToInt32(Session["PermissionState"]));
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
    void TigerReserveCounter1()
    {
        p_Var.dSet = null;
        try
        {
            //  villageObject.PermissionState = Convert.ToInt32(Session["PermissionState"]);
            villageObject.ActionType = 12;
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
    void FamilyCounter1()
    {
        p_Var.dSet = null;
        try
        {
            // villageObject.CmnStateUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 8;
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
    void VillageCounter1()
    {
        p_Var.dSet = null;
        try
        {
            // villageObject.CmnStateUserID = Convert.ToInt32(Session["User_Id"]);
            villageObject.ActionType = 4;
            
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
        p_Var.dSet = villageBL.getTigerReserveListNTCA(villageObject);

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
    public static HighChart[] GetTigerReserveByDistrictID(int StateID, string mapStatID, int mapDistricid)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        p_Var.dsFileName = null;
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
      //  p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricID(StateID, mapStatID, mapDistricid);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDMap(StateID, mapStatID, mapDistricid);
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
    public static HighChart[] GetTigerReserveByDistrictIDgetTigerReservesByDistricIDOnShow(int StateID, string mapStatID, int mapDistricid)
    {


        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();

        List<HighChart> _JointForceList = new List<HighChart>();


        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDMapgetTigerReservesByDistricIDOnShow(StateID, mapStatID, mapDistricid);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)//user 3
        {
            HighChart _poa = new HighChart();


            _poa.name = dr["TigerReserveName"].ToString();
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            //_poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            //------------------
            _poa.DistrictIconImage = "";
            if (dr["StateID"].ToString() == "")
            {
                _poa.DistrictIconImage = "";
            }
            else
            {
                _poa.DistrictIconImage = "<img id=\"theImg\" src=\"./images/ttt.jpg\" prepended=\"yes\" width=\"25px\"/>";
            }
            //--------------------
            _JointForceList.Add(_poa);
        }
        //var json = new JavaScriptSerializer().Serialize(_JointForceList);
        //return json;
        return _JointForceList.ToArray();
    }

    [WebMethod]
    public static HighChart[] GetTigerReserveByStateIDgetTigerReserves(int StateID, string mapStatID)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        // p_Var.dsFileName = objHighChartBL.GetTigerReserveByStateID1(StateID, mapStatID);
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByStateID1getTigerReserves(StateID, mapStatID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)//4
        {
            HighChart _poa = new HighChart();



            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();

            _JointForceList.Add(_poa);
        }

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
        //public string Remarks { get; set; }
        // public string Notice { get; set; }
        public string SNO { get; set; }
        public string Remarks { get; set; }
        public string DistrictIconImage { get; set; }
        //Start India map Icon code
        public string AndamanNicobarStateName { get; set; }
        public string AndhraPradeshStateName { get; set; }
        public string ArunachalPradeshStateName { get; set; }
        public string AssamStateName { get; set; }
        public string BiharStateName { get; set; }
        public string ChhattisgarhStateName { get; set; }
        public string ChandigarhStateName { get; set; }
        public string DamanDiuStateName { get; set; }
        public string DelhiStateName { get; set; }
        public string DadraHaveliStateName { get; set; }
        public string GoaStateName { get; set; }
        public string GujaratStateName { get; set; }
        public string HimachalPradeshStateName { get; set; }
        public string HaryanaStateName { get; set; }
        public string JammuKashmirStateName { get; set; }
        public string JharkhandStateName { get; set; }
        public string KeralaStateName { get; set; }
        public string KarnatakaStateName { get; set; }
        public string LakshadweepStateName { get; set; }
        public string MeghalayaStateName { get; set; }
        public string MaharashtraStateName { get; set; }
        public string ManipurStateName { get; set; }
        public string MadhyaPradeshStateName { get; set; }
        public string MizoramStateName { get; set; }
        public string NagalandStateName { get; set; }
        public string OrissaStateName { get; set; }
        public string PunjabStateName { get; set; }
        public string PuducherryStateName { get; set; }
        public string RajasthanStateName { get; set; }
        public string SikkimStateName { get; set; }
        public string TamilNaduStateName { get; set; }
        public string TripuraStateName { get; set; }
        public string UttarakhandStateName { get; set; }
        public string UttarPradeshStateName { get; set; }
        public string WestBengalStateName { get; set; }
        public string TelenganaStateName { get; set; }
        //End India map Icon code
    }
    protected void gvVillage_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvVillage_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndiaMapHighChart : BasePage
{
    // HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
    //Project_Variables p_Var = new Project_Variables();

    protected void Page_Load(object sender, EventArgs e)
    {
        //string hostName = Dns.GetHostName();
        //string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
        if (!IsPostBack)
        {
            this.Title = " Tiger Reserve in india " + ":NTCA";
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Session["SysIP"] = myIP.ToString();
        }
        //string link = Request.QueryString["bts"].ToString();
        //if(link !=null)
        //{
        //    look0.Attributes["class"]=
        //}

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
    #endregion
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

    [WebMethod]
    public static HighChart[] GetTigerReserveByStateID(int StateID, string mapStatID)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByStateID1(StateID, mapStatID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)//4
        {
            HighChart _poa = new HighChart();


            _poa.name = dr["TigerReserveName"].ToString();

            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            _poa.RelocateVillageList = "Record not available";
            _poa.RelocateyetVillageList = "Record not available";
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();

            _poa.Village = dr["Village"].ToString();

            _poa.Family = dr["Family"].ToString();

            _poa.RelocatedVill = dr["RelocatedVill"].ToString();


            _poa.RelocateFam = dr["RelocateFam"].ToString();


            _poa.RemainVill = dr["RemainVill"].ToString();

            _poa.RemainFam = dr["RemainFam"].ToString();

            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();

            _poa.landAndMoney = dr["landAndMoney"].ToString();

            _poa.VillRelocOtherPack = dr["VillRelocOtherPack"].ToString();

            _poa.SNO = dr["SNO"].ToString();
            _poa.Remarks = dr["Remarks"].ToString();
            _JointForceList.Add(_poa);
        }
       
        return _JointForceList.ToArray();
    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByDistrictID(int StateID, string mapStatID, int mapDistricid)
    {


        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // AwardeeDL _awardeeDL = new AwardeeDL();
        // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        //  p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricID(StateID, mapStatID, mapDistricid);
        // p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDNew(StateID, mapStatID, mapDistricid);

        p_Var.dsFileName = objHighChartBL.GetTigerReserveByMapDistricIDMap(StateID, mapStatID, mapDistricid);
        foreach (DataRow dr in p_Var.dsFileName.Tables[4].Rows)//user 3
        {
            HighChart _poa = new HighChart();

           
            _poa.name = dr["TigerReserveName"].ToString();
           
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat = Convert.ToDouble(dr["latitude"]);
            _poa.lon = Convert.ToDouble(dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
           

            _poa.RelocateVillageList = dr["Relocated"].ToString();
            _poa.RelocateyetVillageList = dr["YetRelocated"].ToString();
            _poa.StateID = Convert.ToInt32(dr["StateID"]);
            _poa.mapStatID = dr["MapStatID"].ToString();
            _poa.MapDistrictID = dr["MapDistrictID"].ToString();
            _poa.TigerReserveid = Convert.ToInt32(dr["TigerReserveid"]);
            _poa.DataOperatorUserID = Convert.ToInt32(dr["DataOperatorUserID"]);

            
            _poa.Village = dr["Village"].ToString();
           
            _poa.Family = dr["Family"].ToString();
          
            _poa.RelocatedVill = dr["RelocatedVill"].ToString();

          
            _poa.RelocateFam = dr["RelocateFam"].ToString();

            
            _poa.RemainVill = dr["RemainVill"].ToString();

            _poa.RemainFam = dr["RemainFam"].ToString();
            
            _poa.MoneyPerfam = dr["MoneyPerfam"].ToString();
           
            _poa.landAndMoney = dr["landAndMoney"].ToString();
          
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
    public static HighChart[] ChkNoRecordFoundClickCreateDataOperator(string MapDistrictID)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.ChkNoRecordFoundClickCreateDataOperatorDal(MapDistrictID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();
            //  _poa = null;
            _poa.DistName = dr["DistName"].ToString();


            _JointForceList.Add(_poa);
        }

        return _JointForceList.ToArray();

    }
    [WebMethod]
    public static HighChart[] ChkNoRecordFoundClickCreateDataOperatorUserPemission(string MapDistrictID)
    {

        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
        // p_Var = null;
        List<HighChart> _JointForceList = new List<HighChart>();
        //_JointForceList = null;
        p_Var.dsFileName = objHighChartBL.ChkNoRecordFoundClickCreateDataOperatorUserPemissionDal(MapDistrictID);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();
            //  _poa = null;
            _poa.DistName1 = dr["TigerReserveName"].ToString();


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
        //Start India map Icon code
        public string AndamanNicobarStateName { get; set; }
        public string AndhraPradeshStateName { get; set; }
        public string ArunachalPradeshStateName { get; set; }
        public string AssamStateName { get; set; }
        public string BiharStateName { get; set; }
        public string DistName { get; set; }
        public string DistName1 { get; set; }
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
}
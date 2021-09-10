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

public partial class IndiaMapHighCharttest1 : System.Web.UI.Page
{
   // HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
    //Project_Variables p_Var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string link = Request.QueryString["bts"].ToString();
        //if(link !=null)
        //{
        //    look0.Attributes["class"]=
        //}

    }
    [WebMethod]
    public static HighChart[] GetTigerReserveByStateID(int StateID,string mapstatid)
    {
        HighChartIndiaMapBL objHighChartBL = new HighChartIndiaMapBL();
        Project_Variables p_Var = new Project_Variables();
       // AwardeeDL _awardeeDL = new AwardeeDL();
       // DataSet ds = new DataSet();
        List<HighChart> _JointForceList = new List<HighChart>();
        p_Var.dsFileName = objHighChartBL.GetTigerReserveByStateID(StateID, mapstatid);
        foreach (DataRow dr in p_Var.dsFileName.Tables[0].Rows)
        {
            HighChart _poa = new HighChart();

            //_poa.TigerReseveId = dr["TigerReserveid"].ToString();
            _poa.name = dr["TigerReserveName"].ToString();
            //_poa.stateID = dr["StateID"].ToString();
            _poa.drilldown = dr["StateName"].ToString();
            _poa.lat =Convert.ToDouble(dr["latitude"]);
            _poa.lon =Convert.ToDouble( dr["longitude"]);
            _poa.VillageList = dr["VILL_NM"].ToString();
            _poa.RelocateVillageList = "Record not available";
            _poa.RelocateyetVillageList = "Record not available";
           // _poa.Notice = "You have permission to access this tiger reserver.Please click to login!!";
            
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
       // public string Notice { get; set; }
    }
}
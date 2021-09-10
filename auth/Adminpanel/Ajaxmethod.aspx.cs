using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;
public partial class auth_Adminpanel_Ajaxmethod : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]

    public static string GetAllAnimal()
    {
        Commanfuction _commanfuction = new Commanfuction();
        Project_Variables P_var = new Project_Variables();
        List<AnimalList> _amimalList = new List<AnimalList>();
      
        P_var.dSet = _commanfuction.GetAnimal();
        foreach (DataRow dr in P_var.dSet.Tables[0].Rows)
        {
            AnimalList ani = new AnimalList();
            ani.Animalid = Convert.ToInt32( dr["AnimalID"].ToString());
            ani.Animal = dr["Animal"].ToString();
            _amimalList.Add(ani);
        }
           
       
        var json = new JavaScriptSerializer().Serialize(_amimalList);
        return json;
    }
    [WebMethod]
    public static string GetAll_Animal_Village(VillageOB villageOB)
    {
      
        Project_Variables P_var = new Project_Variables();
        List<AnimalDetials> _amimalList = new List<AnimalDetials>();
          VillageBL _villagebl = new VillageBL();
         P_var.dSet = _villagebl.Get_Animal_By_Village_ForEdit(villageOB);
        foreach (DataRow dr in P_var.dSet.Tables[0].Rows)
        {
            AnimalDetials ani = new AnimalDetials();
            ani.id = Convert.ToInt32(dr["id"]);
            ani.Animalid = Convert.ToInt32(dr["Animalid"]);
            ani.TotalAnimal = Convert.ToInt32(dr["TotalAnimal"]); ;
           _amimalList.Add(ani);
        }


        var json = new JavaScriptSerializer().Serialize(_amimalList);
        return json;
    }
    [WebMethod]
    public static string getMapCredentials()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        List<MapShowingTigerReserve> _amimalList = new List<MapShowingTigerReserve>();
        MapShowingTigerReserve _villagebl = new MapShowingTigerReserve();
        P_var.dSet = _commanfuction.GetMapCredentials();
        foreach (DataRow dr in P_var.dSet.Tables[0].Rows)
        {
            MapShowingTigerReserve ani = new MapShowingTigerReserve();
            ani.TigerReserveID = Convert.ToInt32(dr["TigerReserveid"]);
            ani.TigerReserveName = Convert.ToString(dr["TigerReserveName"]);
            ani.latitude = Convert.ToString(dr["latitude"]);
            ani.longitude = Convert.ToString(dr["longitude"]);
            _amimalList.Add(ani);
        }


        var json = new JavaScriptSerializer().Serialize(_amimalList);
        return json;
    }

}
public  class AnimalList
{
public int Animalid { get; set; }
public string Animal { get; set; }
}
public class AnimalSearch
{
    public int Villageid { get; set; }
    public string StatusID { get; set; }
}
public class AnimalDetials
{
   public int id { get; set; }
    public int Animalid { get; set; }
    public int TotalAnimal { get; set; }
}

public class MapShowingTigerReserve
{
    public int TigerReserveID { get; set; }
    public string TigerReserveName { get; set; }
    public int StateID { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
}
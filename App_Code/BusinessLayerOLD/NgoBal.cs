using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for NgoBal
/// </summary>
public class NgoBal
{
    NgoDal dal = new NgoDal();
	public NgoBal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Addngo(AddNgoEntity Entity)
    {
        return dal.Addngo(Entity);
    }
    public DataSet Showrecord()
    {
        return dal.Showrecord();
    }
    public DataSet Showrecord1()
    {
        return dal.Showrecord1();
    }
    public DataSet PostShowrecord1()
    {
        return dal.PostShowrecord1();
    }
    public DataSet Showrecord13()
    {
        return dal.Showrecord13();
    }
    public DataSet Showrecord11(int TigerReserveId)
    {
        return dal.Showrecord11(TigerReserveId);
    }
    public DataSet PostShowrecord11(int TigerReserveId)
    {
        return dal.PostShowrecord11(TigerReserveId);
    }
    public DataSet fech_ngo_by_id(int id)
        
    {
        return dal.fech_ngo_by_id(id);
    }
    public int updatengo_information(AddNgoEntity Entity, int id)
    {
        return dal.updatengo_information(Entity, id);
    }
    public int Associate_Village(Associate_Village entity)
    {
        return dal.Associate_Village(entity);
    }
    public DataSet select_associate_village_deatil(int id)
    {
        return dal.select_associate_village_deatil(id);
    }
    public int update_associate_village_deatil(int id, double amount, string workdone, int ngoid)
    {
        return dal.update_associate_village_deatil(id, amount, workdone,ngoid);
    }
    public int update_associate_village_deatilnew(int id, double amount, string workdone)
    {
        return dal.update_associate_village_deatilnew(id, amount, workdone);
    }
    public DataSet select_village_record(int id,string TigerReserveName)
    {
        return dal.select_village_record(id, TigerReserveName);
    }
    public DataSet select_village_family(int id)
    {
        return dal.select_village_family(id);
    }
    public int Delete_ngo_work(int id)
    {
        return dal.Delete_ngo_work(id);
    }
    public int Delete_Ngo(int ngoid)
    {
        return dal.Delete_Ngo(ngoid);
    }
    public DataSet ngo_associated_village(int ngoid, string TigerReserveName)
    {
        return dal.ngo_associated_village(ngoid, TigerReserveName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for HighChartIndiaMapDL
/// </summary>
public class HighChartIndiaMapDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion
	public HighChartIndiaMapDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetTigerReserveByStateID(int stateID, string MapStatID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID",MapStatID);

            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByStateID");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByStateID1(int stateID, string MapStatID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);

            return ncmdbObject.ExecuteDataSet("spMapPopUp0");
            //return ncmdbObject.ExecuteDataSet("spMapPopUp00");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByStateID1getTigerReserves(int stateID, string MapStatID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);

           // return ncmdbObject.ExecuteDataSet("spMapPopUp0");
            return ncmdbObject.ExecuteDataSet("spMapPopUp00");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet MapStateRecordExistanceCheckDal(string StateName)
    {
        try
        {
            ncmdbObject.AddParameter("@StateName", StateName);
            return ncmdbObject.ExecuteDataSet("MapStateRecordExistanceCheck");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet ChkNoRecordFoundClickCreateDataOperatorDal(string mapDistrictID)
    {
        try
        {
            ncmdbObject.AddParameter("@MapDistrictID", mapDistrictID);
            return ncmdbObject.ExecuteDataSet("spGetCheckNoFoundCreateDtlogin");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet ChkNoRecordFoundClickCreateDataOperatorUserPemissionDal(string mapDistrictID)
    {
        try
        {
            ncmdbObject.AddParameter("@MapDistrictID", mapDistrictID);
            return ncmdbObject.ExecuteDataSet("spGetCheckNoFoundCreateDtloginUserPemission");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricID(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);

            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricID");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricID1(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricID1");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDNew(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            ncmdbObject.AddParameter("@IPid", HttpContext.Current.Session["SysIP"].ToString());
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDtest");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDMap(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
           // ncmdbObject.AddParameter("@IPid", HttpContext.Current.Session["SysIP"].ToString());
            ncmdbObject.AddParameter("@IPid", "0");
            return ncmdbObject.ExecuteDataSet("spMapPopUp");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDMapgetTigerReservesByDistricIDOnShow(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            //spMapPopUp000 ncmdbObject.AddParameter("@IPid", HttpContext.Current.Session["SysIP"].ToString());
           // ncmdbObject.AddParameter("@IPid", "0");
            //return ncmdbObject.ExecuteDataSet("spMapPopUp");
            return ncmdbObject.ExecuteDataSet("spMapPopUp000");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard(int stateID, string MapStatID, int MapDistrictID,string TigerReserveID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            ncmdbObject.AddParameter("@TigerReserveid", TigerReserveID);

            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDDashboard");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard4(int stateID, string MapStatID, int MapDistrictID, string TigerReserveID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            ncmdbObject.AddParameter("@TigerReserveid", TigerReserveID);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDtest4");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard44(int stateID, string MapStatID, int MapDistrictID, string TigerReserveID)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@MapDistrictID", MapDistrictID);
            ncmdbObject.AddParameter("@TigerReserveid", TigerReserveID);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spMapPopUp4");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser(int stateID, string MapStatID, string ParentTigerReserveUserID,string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDDashboardtest");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser3(int stateID, string MapStatID, string ParentTigerReserveUserID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDDashboardtest3");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser33(int stateID, string MapStatID, string ParentTigerReserveUserID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spMapPopUp3");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser330(int stateID, string MapStatID, string ParentTigerReserveUserID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spMapPopUp33");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap(int stateID, string MapStatID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
          //  ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDDStateUser");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap2(int stateID, string MapStatID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            //  ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByMapDistricIDDStateUser2");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap22(int stateID, string MapStatID, string DistrictIDMap)
    {
        try
        {

            ncmdbObject.AddParameter("@StateID", stateID);
            ncmdbObject.AddParameter("@MapStatID", MapStatID);
            //  ncmdbObject.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ncmdbObject.AddParameter("@DistricMapID", DistrictIDMap);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"].ToString());
            return ncmdbObject.ExecuteDataSet("spMapPopUp2");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserveByTigerReserveID(int TigerReserveid)
    {
        try
        {

            ncmdbObject.AddParameter("@TigerReserveid", TigerReserveid);
            ncmdbObject.AddParameter("@UserID", HttpContext.Current.Session["User_Id"]);
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveByTigerReserveID");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
}
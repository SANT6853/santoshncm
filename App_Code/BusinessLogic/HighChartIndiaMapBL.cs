using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HighChartIndiaMapBL
/// </summary>
public class HighChartIndiaMapBL
{
    #region Variable declaration zone

    HighChartIndiaMapDL HighChartBL = new HighChartIndiaMapDL();
    
    #endregion
	public HighChartIndiaMapBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetTigerReserveByStateID(int stateID, string MapStatID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByStateID(stateID, MapStatID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByStateID1(int stateID, string MapStatID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByStateID1(stateID, MapStatID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByStateID1getTigerReserves(int stateID, string MapStatID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByStateID1getTigerReserves(stateID, MapStatID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet MapStateRecordExistanceCheckDal(string StateName)
    {//
        try
        {
            return HighChartBL.MapStateRecordExistanceCheckDal(StateName);
        }
        catch
        {
            throw;
        }

    }
    public DataSet ChkNoRecordFoundClickCreateDataOperatorDal(string mapDistrictID)
    {//
        try
        {
            return HighChartBL.ChkNoRecordFoundClickCreateDataOperatorDal(mapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet ChkNoRecordFoundClickCreateDataOperatorUserPemissionDal(string mapDistrictID)
    {//
        try
        {
            return HighChartBL.ChkNoRecordFoundClickCreateDataOperatorUserPemissionDal(mapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricID(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricID(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricID1(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricID1(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDNew(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDNew(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDMap(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDMap(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDMapgetTigerReservesByDistricIDOnShow(int stateID, string MapStatID, int MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDMapgetTigerReservesByDistricIDOnShow(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard(int stateID, string MapStatID, int MapDistrictID,string TigerReserveID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoard(stateID, MapStatID, MapDistrictID, TigerReserveID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard4(int stateID, string MapStatID, int MapDistrictID, string TigerReserveID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoard4(stateID, MapStatID, MapDistrictID, TigerReserveID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoard44(int stateID, string MapStatID, int MapDistrictID, string TigerReserveID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoard44(stateID, MapStatID, MapDistrictID, TigerReserveID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser(int stateID, string MapStatID,string TigerReserveID,string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser(stateID, MapStatID, TigerReserveID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser3(int stateID, string MapStatID, string TigerReserveID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser3(stateID, MapStatID, TigerReserveID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser33(int stateID, string MapStatID, string TigerReserveID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser33(stateID, MapStatID, TigerReserveID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDDashBoardSateUser330(int stateID, string MapStatID, string TigerReserveID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDDashBoardSateUser330(stateID, MapStatID, TigerReserveID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap(int stateID, string MapStatID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDStateUserMap(stateID, MapStatID,MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap2(int stateID, string MapStatID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDStateUserMap2(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByMapDistricIDStateUserMap22(int stateID, string MapStatID, string MapDistrictID)
    {
        try
        {
            return HighChartBL.GetTigerReserveByMapDistricIDStateUserMap22(stateID, MapStatID, MapDistrictID);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveByTigerReserveID(int TigerReserveid)
    {
        try
        {
            return HighChartBL.GetTigerReserveByTigerReserveID(TigerReserveid);
        }
        catch
        {
            throw;
        }

    }
}
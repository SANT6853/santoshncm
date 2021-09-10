using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NCM.DAL;

/// <summary>
/// Summary description for relocationprogress
/// </summary>
public class relocationprogress
{
    NCMdbAccess ncm = new NCMdbAccess();
    public relocationprogress()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataSet statefordropedown()
    {
        using (NCMdbAccess ncm = new NCMdbAccess())
        {
            return ncm.ExecuteDataSet("getstate");
        }
    }
    public static DataSet CheckRecordExistenceAfterSaveM(int userID)
    {
        using (NCMdbAccess ncm = new NCMdbAccess())
        {
            ncm.AddParameter("@UserID", userID);
            return ncm.ExecuteDataSet("CheckExistence");
        }
    }
    public int Insert_Relocation_Progress_Deatil(RelocationProgresEntity objEntity)
    {
        ncm.AddParameter("@date", objEntity._DATE);
        ncm.AddParameter("@state", objEntity._STATENAME);
        ncm.AddParameter("@reserveId", objEntity._RESERVNAME);
        ncm.AddParameter("@village", objEntity._VILLAGE);
        ncm.AddParameter("@Relocatedvill", objEntity._RELOCVILLAGE);
        ncm.AddParameter("@remainVill", objEntity._REMAININGVILLAGE);
        ncm.AddParameter("@Family", objEntity._FAMILY);
        ncm.AddParameter("@RelocatedFam", objEntity._RELOCFAMILY);
        ncm.AddParameter("@Remainfam", objEntity._REMAINFAMILY);
        ncm.AddParameter("@MoneyPerFam", objEntity._MONEYPERFAMILY);
        ncm.AddParameter("@LandPack", objEntity._LANDPACKAGE);
        ncm.AddParameter("@LandAndMoney", objEntity._MONEYANDLAND);
        ncm.AddParameter("@VillRelocOtherPac", objEntity._RELOCOTHERPCK);
        ncm.AddParameter("@Remarks", objEntity._REMARKS);
        ncm.AddParameter("@UserID", objEntity.UserID);

        ncm.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["CmnStateUser"]));
        ncm.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveUserID"]));
        ncm.AddParameter("@CmnDataOperatorUserID", Convert.ToInt32(HttpContext.Current.Session["CmnDataOperatorUserID"]));
        ncm.AddParameter("@CmnStateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
        ncm.AddParameter("@CmnDataOperatorTigerReserveID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveID"]));
        return ncm.ExecuteNonQuery("Insert_Relocation_Progress_Deatil");

    }

    public DataSet SelectRecordForeGrid(string date)
    {
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report");
    }
    public DataSet SelectRecordForeGrid22(string date)
    {
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report_st");
    }
    public DataSet SelectRecordForeGrid33(string date)
    {
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report_Re");
    }
    public DataSet SelectRecordForeGrid11(string date, string TigerReserveName)
    {
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        ncm.AddParameter("@TigerReserveName", TigerReserveName);
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report_Nt");
    }
    public DataSet DsGetVillageProgressReportByStateID(string StateID)
    {

        ncm.AddParameter("@StateID", StateID);
        return ncm.ExecuteDataSet("spGetStateWiseVillageProgressReport");
    }
    public DataSet SelectRecordForeGridRGP(string Treservename, string StateName)
    {
        ncm.AddParameter("@ReserveId", Treservename);
        ncm.AddParameter("@StateName", StateName);
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_ReportNew");
    }
    public DataSet SelectRecordForeGrid3(string date)
    {
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report3");
    }
    public DataSet SelectRecordForeGrid2(string date)
    {///
        if (!(String.IsNullOrEmpty(date)))
        {
            ncm.AddParameter("@date", date);
        }
        ncm.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report3_1");
    }
    public DataSet SelectRecordForeGrid1(string date)
    {///
        //if (!(String.IsNullOrEmpty(date)))
        //{
        //    ncm.AddParameter("@date", date);
        //}
        //  ncm.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ncm.ExecuteDataSet("Select_Record_For_Relocation_Progress_Report3_11");
    }
    public int DeleteReport(int id)
    {
        ncm.AddParameter("@id", id);
        return ncm.ExecuteNonQuery("DeleteReport");
    }
    public int Update_Relocation_Progress_Deatil(RelocationProgresEntity objEntity, int id)
    {
        ncm.AddParameter("@id", id);
        ncm.AddParameter("@date", objEntity._DATE);
        ncm.AddParameter("@state", objEntity._STATENAME);
        ncm.AddParameter("@reserveId", objEntity._RESERVNAME);
        ncm.AddParameter("@village", objEntity._VILLAGE);
        ncm.AddParameter("@Relocatedvill", objEntity._RELOCVILLAGE);
        ncm.AddParameter("@remainVill", objEntity._REMAININGVILLAGE);
        ncm.AddParameter("@Family", objEntity._FAMILY);
        ncm.AddParameter("@RelocatedFam", objEntity._RELOCFAMILY);
        ncm.AddParameter("@Remainfam", objEntity._REMAINFAMILY);
        ncm.AddParameter("@MoneyPerFam", objEntity._MONEYPERFAMILY);
        ncm.AddParameter("@LandPack", objEntity._LANDPACKAGE);
        ncm.AddParameter("@LandAndMoney", objEntity._MONEYANDLAND);
        ncm.AddParameter("@VillRelocOtherPac", objEntity._RELOCOTHERPCK);
        ncm.AddParameter("@Remarks", objEntity._REMARKS);
        ncm.AddParameter("@ReUpdateByID", HttpContext.Current.Session["User_Id"]);
        return ncm.ExecuteNonQuery("update_relocation_process_report");

    }
    public DataSet select_record_for_update(int id)
    {
        ncm.AddParameter("@id", id);
        return ncm.ExecuteDataSet("select_record_for_update");
    }

}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using NCM.DAL;

/// <summary>
/// Summary description for ReserveDB
/// </summary>
public class ReserveDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool AddReserveDB(Reserve_Entity objReserve_Entity, StateEntity Obj_StateEntity)
    {
        try
        {
            ObjDB.AddParameter("@ST_ID", Obj_StateEntity._ST_ID);
            ObjDB.AddParameter("@RSRV_CD", objReserve_Entity._RSRV_CD);
            ObjDB.AddParameter("@RSRV_AREA_NM", objReserve_Entity._RSRV_AREA_NM);
            ObjDB.AddParameter("@RSRV_NO_Vill", objReserve_Entity._RSRV_NO_Vill);
            ObjDB.AddParameter("@RSRV_TOT_LND_AREA", objReserve_Entity._RSRV_TOT_LND_AREA);
            ObjDB.AddParameter("@RSRV_TOT_AGRI_LND_AREA", objReserve_Entity._RSRV_TOT_AGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_TOT_NONAGRI_LND_AREA", objReserve_Entity._RSRV_TOT_NONAGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_POPU", objReserve_Entity._RSRV_POPU);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Reserve");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public DataSet CheckAvailability(string reservecode)
    {
        ObjDB.AddParameter("@RSRV_CD", reservecode);

        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_Reserve_Code");
    }
    public DataSet FillStatesDB()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_States_Reserve");
    }
    public DataSet Display_All_Reserve(Reserve_Entity RSVR_Entity, string name)
    {
        ObjDB.AddParameter("@RSRV_ID", RSVR_Entity._RSRV_ID);
        ObjDB.AddParameter("@RSRV_CD", RSVR_Entity._RSRV_CD);
        // ObjDB.AddParameter("@RSRV_AREA_NM", RSVR_Entity._RSRV_AREA_NM);
        ObjDB.AddParameter("@RSRV_AREA_NM", name);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Reserve");

    }

    public DataSet Display_State_Name_By_ReserveID(string reserveid)
    {
        ObjDB.AddParameter("@RSRV_ID", reserveid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_State_Name_By_ReserveID");

    }
    public bool UpdateReserveDB(Reserve_Entity objReserve_Entity, string reserveid)
    {
        try
        {
            ObjDB.AddParameter("@RSRV_ID", reserveid);
            ObjDB.AddParameter("@RSRV_AREA_NM", objReserve_Entity._RSRV_AREA_NM);
            ObjDB.AddParameter("@RSRV_NO_Vill", objReserve_Entity._RSRV_NO_Vill);
            ObjDB.AddParameter("@RSRV_TOT_LND_AREA", objReserve_Entity._RSRV_TOT_LND_AREA);
            ObjDB.AddParameter("@RSRV_TOT_AGRI_LND_AREA", objReserve_Entity._RSRV_TOT_AGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_TOT_NONAGRI_LND_AREA", objReserve_Entity._RSRV_TOT_NONAGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_POPU", objReserve_Entity._RSRV_POPU);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Reserve");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Delete_Reserve_By_ID(string reserveid)
    {
        try
        {
            ObjDB.AddParameter("@RSRV_ID", reserveid);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_Info_Reserve");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public DataSet GenerateCodeForReserveDB()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Generate_Code_For_Reserve");
    }
    public DataSet Fill_ReserveCode_And_Name()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Reserve_Code_And_Name");
    }
    public DataSet Proc_VillageSearchByReserve(string VillageName, string VillCode, string villstatus)
    {
        if (VillageName == "Select Name")
        {
            VillageName = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_NM", VillageName);
        }
        if (VillCode == "Select Code")
        {
            VillCode = null;
        }
        else if (VillCode == "No Record")
        {
            VillCode = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_CD", VillCode);
        }
        //ObjDB.AddParameter("@VILL_NM", VillageName);
        //ObjDB.AddParameter("@VILL_CD", VillCode);
        ObjDB.AddParameter("@vill_status", villstatus);
        //-----------
        ObjDB.AddParameter("@UserID", HttpContext.Current.Session["User_Id"]);
        ObjDB.AddParameter("@TigerReserveid", HttpContext.Current.Session["sTigerReserveid"]);
        return ObjDB.ExecuteDataSet("Proc_VillageSearch");

    }
    public DataSet Proc_VillageSearchByReserveRGP(string TigerReserveName, string vill_stat, string StateName, string VillageName)
    {
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@vill_stat", vill_stat);
        ObjDB.AddParameter("@StateName", StateName);
        ObjDB.AddParameter("@vill_nm", VillageName);
        return ObjDB.ExecuteDataSet("Proc_VillageSearchRGP");

    }
    public DataSet Proc_VillageSearchByReserve3(string VillageName, string VillCode, string villstatus)
    {
        //ObjDB.AddParameter("@VILL_NM", VillageName);
        //ObjDB.AddParameter("@VILL_CD", VillCode);
        if (VillageName == "Select Name")
        {
            VillageName = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_NM", VillageName);
        }
        if (VillCode == "Select Code")
        {
            VillCode = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_CD", VillCode);
        }
        ObjDB.AddParameter("@vill_status", villstatus);
        //-----------

        ObjDB.AddParameter("@CmnTigerReserveUserID", HttpContext.Current.Session["User_Id"]);
        return ObjDB.ExecuteDataSet("Proc_VillageSearch3");

    }
    public DataSet Proc_VillageSearchByReserve2(string VillageName, string VillCode, string villstatus)
    {
       // ObjDB.AddParameter("@VILL_NM", VillageName);
       // ObjDB.AddParameter("@VILL_CD", VillCode);
        if (VillageName == "Select Name")
        {
            VillageName = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_NM", VillageName);
        }
        if (VillCode == "Select Code")
        {
            VillCode = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_CD", VillCode);
        }

        ObjDB.AddParameter("@vill_status", villstatus);
        //-----------

        ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["User_Id"]);
        return ObjDB.ExecuteDataSet("Proc_VillageSearch2");

    }
    public DataSet Proc_VillageSearchByReserve1(string VillageName, string VillCode, string villstatus)
    {
        ObjDB.AddParameter("@VILL_NM", VillageName);
        ObjDB.AddParameter("@VILL_CD", VillCode);
        ObjDB.AddParameter("@vill_status", villstatus);
        //  ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["User_Id"]);
        return ObjDB.ExecuteDataSet("Proc_VillageSearch1");

    }
    public DataSet Proc_VillageSearchByReserveRevise1(string VillageName, string VillCode, string villstatus, string TigerReserveName, string StateName)
    {
        if (VillageName == "Select Name")
        {
            VillageName = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_NM", VillageName);
        }
        if (VillCode == "Select Code")
        {
            VillCode = null;
        }
        else
        {
            ObjDB.AddParameter("@VILL_CD", VillCode);
        }
        ObjDB.AddParameter("@vill_status", villstatus);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@StateName", StateName);
        return ObjDB.ExecuteDataSet("Proc_VillageSearchRevise1");

    }
    public DataSet DsVillageMapGoogle(string StateID,string TigerReserveID,string VillageID)
    {

        ObjDB.AddParameter("@StateID", StateID);
        ObjDB.AddParameter("@TigerReseveID", TigerReserveID);
        ObjDB.AddParameter("@VillageID", VillageID);
        return ObjDB.ExecuteDataSet("SpGoogleMapConsol");

    }
    public DataSet DsVillageBindConsoldate(string StateId, string TigerReserveID, string VillageID)
    {

        ObjDB.AddParameter("@StateId", StateId);
        ObjDB.AddParameter("@TigerReserveID", TigerReserveID);
        ObjDB.AddParameter("@VILL_ID", VillageID);
        return ObjDB.ExecuteDataSet("SpVillageDetailConsol");

    }
    public DataSet DsRelocationDetails(string stateID,string TigerReserveID, string VillageID)
    {

        ObjDB.AddParameter("@StateID", stateID);
        ObjDB.AddParameter("@TigerReserveid", TigerReserveID);
        ObjDB.AddParameter("@villageid", VillageID);
        return ObjDB.ExecuteDataSet("SpGetRelocationDetailsConsolDateReport");

    }
    public DataSet Proc_VillageSearchYearWise(string VillageName, string VillCode, string villstatus, string TigerReserveName, string StateName, string REC_CRT_DTfrom, string REC_CRT_DTto)
    {
        ObjDB.AddParameter("@VILL_NM", VillageName);
        ObjDB.AddParameter("@VILL_CD", VillCode);
        ObjDB.AddParameter("@vill_status", villstatus);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@StateName", StateName);

        ObjDB.AddParameter("@REC_CRT_DTfrom", REC_CRT_DTfrom);
        ObjDB.AddParameter("@REC_CRT_DTto", REC_CRT_DTto);
        return ObjDB.ExecuteDataSet("spVillageSearchReviseYearWise");

    }

}

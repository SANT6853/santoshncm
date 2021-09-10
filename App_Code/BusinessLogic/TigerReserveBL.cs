using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for TigerReserveBL
/// </summary>
public class TigerReserveBL
{
    #region Variable declaration zone

    TigerReserveDL tigerreserverDL = new TigerReserveDL();

    #endregion
    public TigerReserveBL()
    {
        //
        // TODO: Add constructor logic here
        //
        //Get_TigerReserve
    }
    public DataSet GetDist(int Stateid)
    {
        return tigerreserverDL.GetDist(Stateid);
    }
    public DataSet GetCity(int Distid)
    {
        return tigerreserverDL.GetCity(Distid);
    }
    public int Insert_UpdateTigerReserver(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.Insert_UpdateTigerReserver(_tigerOb);
    }
    public int InsertDFOtoReserve(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.InsertDFOtoReserve(_tigerOb);
    }
    public int UpdateLegalForm(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.UpdateLegalForm(_tigerOb);
    }
    public int InsertLegalFormAndForm1(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.InsertLegalFormAndForm1(_tigerOb);
    }

    public int UpdateAllLegalFormAndForm1(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.UpdateAllLegalFormAndForm1(_tigerOb);
    }
    public int InsertNtcaStateReplyDal(TigerReserveOB _tigerOb)
    {//
        return tigerreserverDL.InsertNtcaStateReplyDal(_tigerOb);
    }
    public int InsertStateToNtcaRelpy(TigerReserveOB _tigerOb)
    {//
        return tigerreserverDL.InsertStateToNtcaRelpy(_tigerOb);
    }
    public int UpdateStatusOfResereUser(TigerReserveOB _tigerOb)
    {/////
        return tigerreserverDL.UpdateStatusOfResereUser(_tigerOb);
    }
    public int InsertReserveToState(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.InsertReserveToState(_tigerOb);
    }
    public int BackToStateDeleteRecord(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.BackToStateDeleteRecord(_tigerOb);
    }
    public int Insert_UpdateConversionScheme(TigerReserveOB _tigerOb)
    {
        return tigerreserverDL.Insert_UpdateConversionScheme(_tigerOb);
    }
    public DataSet Get_TigerReservationList(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.Get_TigerReservationList(_tigerob);
    }
    public DataSet Get_ConvesionSchemList(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.Get_ConvesionSchemList(_tigerob);
    }
    public DataSet GetDfoReserveProcessDal(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetDfoReserveProcessDal(_tigerob);
    }
    public DataSet GetLegalFormFrom1(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetLegalFormFrom1(_tigerob);
    }
    public DataSet GetDfoReserveProcessDalActonRequest(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetDfoReserveProcessDalActonRequest(_tigerob);
    }
    public DataSet GetDfoReserveProcessDalReplynew(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetDfoReserveProcessDalReplynew(_tigerob);
    }
    public DataSet GetDfoReserveProcessDalhistory(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetDfoReserveProcessDalhistory(_tigerob);
    }
    public DataSet GetDfoReserveProcessDalNew(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetDfoReserveProcessDalNew(_tigerob);
    }

    public DataSet GetDfoReserveProcessDalReserveFolder(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetDfoReserveProcessDalReserveFolder(_tigerob);
    }
    public DataSet GetNtcaStatehistoryProcessDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetNtcaStatehistoryProcessDal(_tigerob);
    }
    public DataSet GetNtcaStateReplyProcessDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetNtcaStateReplyProcessDal(_tigerob);
    }
    public DataSet GetNtcaStateProcessDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetNtcaStateProcessDal(_tigerob);
    }
    public DataSet GetStateNtcaHistoryDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetStateNtcaHistoryDal(_tigerob);
    }
    public DataSet GetStateToReserveProcessDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.GetStateToReserveProcessDal(_tigerob);
    }
    public DataSet GetFromStateToNtcaDal(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetFromStateToNtcaDal(_tigerob);
    }
    public DataSet Get_CrudOperation(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.Get_CrudOperation(_tigerob);
    }
    public DataSet GetCheckVillageIDExist(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.GetCheckVillageIDExist(_tigerob);
    }
    public DataSet AutoGenerateSerialNumber(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.AutoGenerateSerialNumber(_tigerob);
    }
    public DataSet Get_TigerReservationDetials(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.Get_TigerReservationDetials(_tigerob);
    }
    public DataSet CheckDuplicateTigerReserve(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.CheckDuplicateTigerReserve(_tigerob);
    }
    public DataSet CheckTigerReserSingleInStateDistrictDal(TigerReserveOB _tigerob)
    {//
        return tigerreserverDL.CheckTigerReserSingleInStateDistrictDal(_tigerob);
    }
    public DataSet updateCheckDuplicateTigerReserve(TigerReserveOB _tigerob)
    {
        return tigerreserverDL.updateCheckDuplicateTigerReserve(_tigerob);
    }
    public DataSet GetTigerReserverByState(int flag, int Userid)
    {
        return tigerreserverDL.GetTigerReserverByState(flag, Userid);
    }
    #region Function for BindState and Village Detail 
    public DataSet BindStates(int Vill_ID)
    {
        try
        {
          return tigerreserverDL.BindStates(Vill_ID);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for BindState and Village Detail
    public DataSet BindPostStates(int Vill_ID)
    {
        try
        {
            return tigerreserverDL.BindPostStates(Vill_ID);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for Save NGO Data 
    public int SaveNgoDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.SaveNgoDetail(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for FundManagement 
    public int FundManagement(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.FundManagement(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for BindState and Village Detail
    public DataSet GetFund(int Vill_ID)
    {
        try
        {
            return tigerreserverDL.GetFund(Vill_ID);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for PriviewRecord 
    public DataSet PriviewRecord(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.PriviewRecord(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for  Final Submit
    public int FinalSubmit(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.FinalSubmit(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Prefrom Record
    public DataSet GETPrefromrecord(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.GETPrefromrecord(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save Work Perform Detail   SaveConversionScheme
    public int SaveWorkPerformDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.SaveWorkPerformDetail(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion

    #region Function for Save Work Perform Detail   
    public int SaveConversionScheme(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.SaveConversionScheme(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save Post NGO Data
    public int SavePostNgoDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return tigerreserverDL.SavePostNgoDetail(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for BindPreState and Village Detail
    public DataSet BindPreStates(int Vill_ID)
    {
        try
        {
            return tigerreserverDL.BindPreStates(Vill_ID);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for FeedBackDL
/// </summary>
public class FeedBackDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion
	public FeedBackDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int insertFeedBack(ContentOB lnkObject)
    {
        try
        {

            ncmdbObject.AddParameter("@Name", lnkObject.Name);
            ncmdbObject.AddParameter("@EmailID", lnkObject.EmailID);
            ncmdbObject.AddParameter("@Phone", lnkObject.Phone);
            ncmdbObject.AddParameter("@Address", lnkObject.Address);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@StateName", lnkObject.StateName);
            ncmdbObject.AddParameter("@Message", lnkObject.details);
            ncmdbObject.AddParameter("@Ip", lnkObject.IpAddress);
            ncmdbObject.AddParameter("@ModuleId", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@FeedBackFrom", lnkObject.FeedBackFrom);
            return ncmdbObject.ExecuteNonQuery("spInsertFeedbackForm");
            
           
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
    public DataSet GetFeedBackData(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.AddParameter("@FeedBackFrom", lnkObject.FeedBackFrom);
            ncmdbObject.AddParameter("@ModuleId", lnkObject.ModuleID);
            return ncmdbObject.ExecuteDataSet("spBindFeedback");
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
    public DataSet GetFeedBackData1(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.AddParameter("@FeedBackFrom", lnkObject.FeedBackFrom);
            ncmdbObject.AddParameter("@ModuleId", lnkObject.ModuleID);
            return ncmdbObject.ExecuteDataSet("spBindFeedbackTigerReserveSub");
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
    public DataSet GetFeedBackDataReserveState(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@ModuleId", lnkObject.ModuleID);
            return ncmdbObject.ExecuteDataSet("spBindFeedbackTigerReserve");
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
    public DataSet GetParticularFeedBackData(int feedbackid)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@FeedBackFormID", feedbackid);
            return ncmdbObject.ExecuteDataSet("spBindParticularFeedback");
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
    public DataSet GetTigerReserveOFVilageList(int CmnDataOperatorTigerReserveID)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@CmnDataOperatorTigerReserveID", CmnDataOperatorTigerReserveID);
            return ncmdbObject.ExecuteDataSet("GetTigerReserveOFVilageList");
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
    public int DelFeedback(ContentOB lnkObject)
    {
        try
        {

            ncmdbObject.AddParameter("@FeedBackFormID", lnkObject.FeedBackID);

            return ncmdbObject.ExecuteNonQuery("spFeedbackDelete");
            
            
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
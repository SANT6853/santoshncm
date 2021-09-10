using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FeedBackBL
/// </summary>
public class FeedBackBL
{
    #region Variable declaration zone

    FeedBackDL feedbackBL = new FeedBackDL();
    
    #endregion
	public FeedBackBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int insertFeedBack(ContentOB obj)
    {
        try
        {
            return feedbackBL.insertFeedBack(obj);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetFeedBackData(ContentOB obj)
    {
        try
        {
            return feedbackBL.GetFeedBackData(obj);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetFeedBackData1(ContentOB obj)
    {
        try
        {
            return feedbackBL.GetFeedBackData1(obj);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetFeedBackDataReserveState(ContentOB obj)
    {
        try
        {
            return feedbackBL.GetFeedBackDataReserveState(obj);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetParticularFeedBackData(int feedbackid)
    {
        try
        {
            return feedbackBL.GetParticularFeedBackData(feedbackid);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveOFVilageList(int CmnDataOperatorTigerReserveID)
    {
        try
        {
            return feedbackBL.GetTigerReserveOFVilageList(CmnDataOperatorTigerReserveID);
        }
        catch
        {
            throw;
        }

    }
    public int DelFeedback(ContentOB lnkObject)
    {
        try
        {
            return feedbackBL.DelFeedback(lnkObject);
        }
        catch
        {
            throw;
        }

    }
}
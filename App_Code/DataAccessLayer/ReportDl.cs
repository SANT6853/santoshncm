using NCM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportDl
/// </summary>
public class ReportDl
{

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public ReportDl()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Function for BindState and Village Detail FundManagement 
    public DataSet SurveyReport(NtcaUserOB _objNtcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateIDParameters", _objNtcauser.StateIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReseveIDParameters", _objNtcauser.TigerReseveIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _objNtcauser.UserID));           
            return ncmdbObject.ExecuteDataSet("spserveyReport");
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
    #endregion
}
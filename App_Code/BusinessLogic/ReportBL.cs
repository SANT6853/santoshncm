using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportBL
/// </summary>
public class ReportBL
{
    ReportDl reportdl = new ReportDl();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public ReportBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Function for BindState and Village Detail 
    public DataSet SurveyReport(NtcaUserOB _objNtcauser)
    {
        try
        {
            
            return reportdl.SurveyReport(_objNtcauser);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for FunbDL
/// </summary>
public class FunbDL:IDisposable
{
    private bool disposed = false;
    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
	public FunbDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertFundRequest(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@submituserid", _FundOB.submitedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundDescription", _FundOB.FundDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@Amount", _FundOB.Fundamount));
            ncmdbObject.Parameters.Add(new SqlParameter("@fundStatus", _FundOB.FundStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@villageid", _FundOB.Villageid));
            
            
            return ncmdbObject.ExecuteNonQuery("InsertFund_Request");

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
    #region(function naren save fund management table)
    public int InsertFundManagement(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 1));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserName", _FundOB.StateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserName", _FundOB.TigerReserveUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", _FundOB.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _FundOB.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", _FundOB.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundAmount", _FundOB.FundAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@FunDescription", _FundOB.FunDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusID", _FundOB.ProcessingStatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusTigerReserveUser", _FundOB.ActionButtonStatusTigerReserveUser));
          //  ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            //  _fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByID", _FundOB.CreatedByID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserName", _FundOB.CreatedByUserName));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int InsertFundManagement2(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 14));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserName", _FundOB.StateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserName", _FundOB.TigerReserveUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", _FundOB.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _FundOB.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", _FundOB.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundAmount", _FundOB.FundAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@FunDescription", _FundOB.FunDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusID", _FundOB.ProcessingStatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusTigerReserveUser", _FundOB.ActionButtonStatusTigerReserveUser));
              ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            //  _fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByID", _FundOB.CreatedByID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserName", _FundOB.CreatedByUserName));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int InsertFundManagementStateUser(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 6));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserName", _FundOB.StateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserName", _FundOB.TigerReserveUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", _FundOB.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _FundOB.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", _FundOB.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundAmount", _FundOB.FundAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@FunDescription", _FundOB.FunDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusID", _FundOB.ProcessingStatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusStateUser", _FundOB.ActionButtonStatusStateUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByID", _FundOB.CreatedByID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserName", _FundOB.CreatedByUserName));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int InsertFundManagementNTCAUser(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 15));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserName", _FundOB.StateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserName", _FundOB.TigerReserveUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", _FundOB.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _FundOB.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", _FundOB.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundAmount", _FundOB.FundAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@FunDescription", _FundOB.FunDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusID", _FundOB.ProcessingStatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusNtcaUser", _FundOB.ActionButtonStatusNtcaUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByID", _FundOB.CreatedByID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserName", _FundOB.CreatedByUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int InsertFundManagementNTCAUser2(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 11));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserName", _FundOB.StateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserName", _FundOB.TigerReserveUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", _FundOB.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _FundOB.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", _FundOB.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundAmount", _FundOB.FundAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@FunDescription", _FundOB.FunDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusID", _FundOB.ProcessingStatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundSanctionStatus", _FundOB.FundSanctionStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            //_fundob.CommonGroupQueryID = Convert.ToInt32(((HiddenField)gr.FindControl("HCommonGroupQueryID")).Value);
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByID", _FundOB.CreatedByID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserName", _FundOB.CreatedByUserName));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int UpdateActionButtonStatusStateUser(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 7));
            ncmdbObject.Parameters.Add(new SqlParameter("@Fid", _FundOB.Fid));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusStateUser", _FundOB.ActionButtonStatusStateUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int UpdateActionButtonStatusNTCAUser(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 12));
            ncmdbObject.Parameters.Add(new SqlParameter("@Fid", _FundOB.Fid));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusNtcaUser", _FundOB.ActionButtonStatusNtcaUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int UpdateActionAPPROVEntcaUser(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 13));
           // ncmdbObject.Parameters.Add(new SqlParameter("@Fid", _FundOB.Fid));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundSanctionStatus", _FundOB.FundSanctionStatus));
           // ncmdbObject.Parameters.Add(new SqlParameter("@ProcessingStatusName", _FundOB.ProcessingStatusName));
            ncmdbObject.Parameters.Add(new SqlParameter("@NtcaUserID", _FundOB.NtcaUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));

            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public int UpdateActionButtonStatusTigerReserveUser(FundOb _FundOB)
    {
        try
        {//ActionButtonStatusStateUser
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 8));
            ncmdbObject.Parameters.Add(new SqlParameter("@Fid", _FundOB.Fid));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusTigerReserveUser", _FundOB.ActionButtonStatusTigerReserveUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionButtonStatusStateUser", _FundOB.ActionButtonStatusStateUser));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommonGroupQueryID", _FundOB.CommonGroupQueryID));
            return ncmdbObject.ExecuteNonQuery("spInsertFundManagement");

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
    public DataSet GetMstUserByStateID(FundOb _FundOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@PermissionState", _FundOB.StateID));


            return ncmdbObject.ExecuteDataSet("spGetMstUserByStateID");

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
    public DataSet Get_FundList(FundOb _FundOB)
    {

        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", _FundOB.Villageid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Statusid", _FundOB.FundStatus));


            return ncmdbObject.ExecuteDataSet("Get_FundList");

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
    public DataSet BindFundMangementRecord(FundOb _FundOB)
    {

        if (HttpContext.Current.Session["UserType"].ToString() == "1")
        {
            //super admin
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action", 10));
                ncmdbObject.Parameters.Add(new SqlParameter("@NtcaUserID", _FundOB.NtcaUserID));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
                ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));

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
        else if (HttpContext.Current.Session["UserType"].ToString() == "2")
        {
            //state user
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action",4));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
                ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));

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
        else if (HttpContext.Current.Session["UserType"].ToString() == "3")
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action", 2));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", _FundOB.TigerReserveID));
                ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _FundOB.VillageID));
               
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
        else
        {

        }
        return ncmdbObject.ExecuteDataSet("spInsertFundManagement");
       
    }
    public DataSet BindDefalultFundMangementRecord(FundOb _FundOB)
    {
        if (HttpContext.Current.Session["UserType"].ToString() == "1")
        {
            //super admin
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action", 9));
                ncmdbObject.Parameters.Add(new SqlParameter("@NtcaUserID", _FundOB.NtcaUserID));
               // ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));


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
        else if (HttpContext.Current.Session["UserType"].ToString() == "2")
        {
            //state user
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action", 5));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", _FundOB.StateUserID));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));


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
        else if (HttpContext.Current.Session["UserType"].ToString() == "3")
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Action", 3));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveUserID", _FundOB.TigerReserveUserID));
                ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _FundOB.StateID));
               

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
        else
        {

        }
        return ncmdbObject.ExecuteDataSet("spInsertFundManagement"); 
       
    }
    public int SubmitFund(FundOb _fund)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Fundid", _fund.FundId));
            ncmdbObject.Parameters.Add(new SqlParameter("@FundStatus", _fund.FundStatus));


            return ncmdbObject.ExecuteNonQuery("SubmitFund");

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
    public DataSet Get_Village_DetailsSummary(int villageid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid",villageid));
           
            return ncmdbObject.ExecuteDataSet("Get_Village_DetailsSummary");

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
    public DataSet Get_VillageDetailsForDisplay_FundSenction(int villageid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", villageid));

            return ncmdbObject.ExecuteDataSet("Get_VillageDetailsForDisplay_FundSenction");
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
    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //this.Dispose();
                // TO DO: clean up managed objects
            }

            // TO DO: clean up unmanaged objects

            disposed = true;
        }
    }
}
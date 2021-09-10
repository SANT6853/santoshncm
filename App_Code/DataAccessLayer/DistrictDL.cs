using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DistrictDL
/// </summary>
public class DistrictDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion
    public DistrictDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region Fucntion to insert and update district

    public int insertUpdateDistrict(DistrictTehshilOB distObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", distObject.ActionType);
            ncmdbObject.AddParameter("@DistID", distObject.DistrictID);
            ncmdbObject.AddParameter("@DistName", distObject.DistrictName);
            ncmdbObject.AddParameter("@InsertedBy", distObject.UserID);
            ncmdbObject.AddParameter("@StateID", distObject.StateID);
            ncmdbObject.AddParameter("@IpAddress", distObject.IPAddress);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("asp_InsertUpdateDistrict");
            recordCount = Convert.ToInt32(param[0].Value);
            return recordCount;
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

    #region Function to display all district

    public DataSet DisplayDistrict(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);

          
            ncmdbObject.AddParameter("@PageIndex", distObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", distObject.PageSize);
           
            ncmdbObject.AddParameter("@StateID", distObject.StateID);

            p_Val.dSet = ncmdbObject.ExecuteDataSet("asp_DisplayDistrict");
            Catvalue = Convert.ToInt16(param[0].Value);

            return p_Val.dSet;

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

    #region Function to display district name for updation

    public DataSet DisplayDistrictInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            ncmdbObject.AddParameter("@DistID", distObject.DistrictID);
            p_Val.dSet = ncmdbObject.ExecuteDataSet("ASP_GetDistrictNameEdit");
            return p_Val.dSet;

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


    #region Fucntion to insert and update Tehshil of district

    public int insertUpdateTehshil(DistrictTehshilOB distObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", distObject.ActionType);
            ncmdbObject.AddParameter("@Tehsil", distObject.TehsilID);
            ncmdbObject.AddParameter("@Tehsil_Name", distObject.TehshilName);
            ncmdbObject.AddParameter("@SubmitBy", distObject.UserID);
            ncmdbObject.AddParameter("@Distid", distObject.DistrictID);
            ncmdbObject.AddParameter("@IpAddress", distObject.IPAddress);
            ncmdbObject.AddParameter("@StateID", distObject.StateID);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("asp_InsertUpdateDistrictTehshil");
            recordCount = Convert.ToInt32(param[0].Value);
            return recordCount;
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
   
    public int DeleteDistrict(int districtID,int action)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@DistID", districtID);
            ncmdbObject.AddParameter("@action",action );

            return ncmdbObject.ExecuteNonQuery("DeleteMasters");
         
             
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
    public int DeleteTehshil(int TeshilID, int action)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@Tehsil", TeshilID);
            ncmdbObject.AddParameter("@action", action);

            return ncmdbObject.ExecuteNonQuery("DeleteMasters");


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
    public int DeleteGramPanchyat(int id, int action)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@GramPanchayatID", id);
            ncmdbObject.AddParameter("@action", action);

            return ncmdbObject.ExecuteNonQuery("DeleteMasters");


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

    #region Function to display all district tehshil

    public DataSet DisplayDistrictTehshil(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);


            ncmdbObject.AddParameter("@PageIndex", distObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", distObject.PageSize);

            ncmdbObject.AddParameter("@Distid", distObject.DistrictID);

            p_Val.dSet = ncmdbObject.ExecuteDataSet("asp_DisplayDistrictTehshil");
            Catvalue = Convert.ToInt16(param[0].Value);

            return p_Val.dSet;

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

    #region Function to display district tehshil name for updation

    public DataSet DisplayDistrictTehshilInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            ncmdbObject.AddParameter("@Tehsil", distObject.TehsilID);
            p_Val.dSet = ncmdbObject.ExecuteDataSet("ASP_GetDistrictTehshilNameEdit");
            return p_Val.dSet;

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

    #region Fucntion to insert and update Tehshil grampanchayat of district

    public int insertUpdateTehshilGrampanchayat(DistrictTehshilOB distObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", distObject.ActionType);
            ncmdbObject.AddParameter("@GramPanchayatID", distObject.GrampanchayatID);
            ncmdbObject.AddParameter("@GramPanchayatName", distObject.Grampanchayatname);
            ncmdbObject.AddParameter("@SubmitBy", distObject.UserID);
            ncmdbObject.AddParameter("@Tehsilid", distObject.TehsilID);
            ncmdbObject.AddParameter("@IpAddress", distObject.IPAddress);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("asp_InsertUpdateTehshilGrampanchayat");
            recordCount = Convert.ToInt32(param[0].Value);
            return recordCount;
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

    #region Function to display all district tehshil grampanchayat

    public DataSet DisplayDistrictTehshilGrampanchayat(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);


            ncmdbObject.AddParameter("@PageIndex", distObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", distObject.PageSize);

            ncmdbObject.AddParameter("@Tehsilid", distObject.TehsilID);

            p_Val.dSet = ncmdbObject.ExecuteDataSet("asp_DisplayTehshilGrampanchayat");
            Catvalue = Convert.ToInt16(param[0].Value);

            return p_Val.dSet;

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

    #region Function to display district tehshil grampanchayat name for updation

    public DataSet DisplayDistrictTehshilGramPanchayatInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            ncmdbObject.AddParameter("@GramPanchayatID", distObject.GrampanchayatID);
            p_Val.dSet = ncmdbObject.ExecuteDataSet("ASP_GetTehshilGrampanchayatNameEdit");
            return p_Val.dSet;

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
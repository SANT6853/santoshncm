using System;
using System.Collections.Generic;

using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for NgoDL
/// </summary>
public class NgoDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion
    public NgoDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Fucntion to insert and update NGO details

    public int InsertUpdateNGODetails(NgoOB ngoObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", ngoObject.ActionType);

            ncmdbObject.AddParameter("@NgoName", ngoObject.NgoName);
            ncmdbObject.AddParameter("@NgoAddress", ngoObject.NgoAddress);
            ncmdbObject.AddParameter("@PhoneNumber", ngoObject.PhoneNumber);
            ncmdbObject.AddParameter("@NgoIDTemp", ngoObject.NgoIDTemp);
            ncmdbObject.AddParameter("@MobileNumber", ngoObject.MobileNumber);
            ncmdbObject.AddParameter("@StatusID", ngoObject.StatusID);
            ncmdbObject.AddParameter("@WorkDoneByNGO", ngoObject.WorkDoneByNGO);
            ncmdbObject.AddParameter("@Remarks", ngoObject.Remarks);
            ncmdbObject.AddParameter("@StateID", ngoObject.StateID);
            ncmdbObject.AddParameter("@Attachment", ngoObject.Attachment);
            ncmdbObject.AddParameter("@Submitby", ngoObject.UserID);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("asp_InsertUpdateNGODetails");
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

    #region Funciton to display all photos

    public DataSet NGODetailsDisplay(NgoOB ngoObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.AddParameter("@NgoIDTemp", ngoObject.NgoIDTemp);
            ncmdbObject.AddParameter("@StateID", ngoObject.StateID);
            ncmdbObject.AddParameter("@PageIndex", ngoObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", ngoObject.PageSize);
            ncmdbObject.AddParameter("@StatusID", ngoObject.StatusID);
            p_Val.dSet = ncmdbObject.ExecuteDataSet("ASP_Get_NGODetails");
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

    #region Function to insert ngo details in final table

    public int InsertUpdateNGOInFinal(NgoOB ngoObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@NgoIDTemp", ngoObject.NgoIDTemp);
            ncmdbObject.AddParameter("@UserID", ngoObject.UserID);
            ncmdbObject.AddParameter("@IpAddress", ngoObject.IpAddress);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDeleteNGODetails");
            p_Val.Result = Convert.ToInt16(param[0].Value);
            return p_Val.Result;
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

    #region Function to display ngo for updation

    public DataSet DisplayNGODetailsinEdit(NgoOB ngoObject)
    {
        try
        {

            ncmdbObject.AddParameter("@NgoIDTemp", ngoObject.NgoIDTemp);
            ncmdbObject.AddParameter("@statusid", ngoObject.StatusID);
            p_Val.dSet = ncmdbObject.ExecuteDataSet("ASP_GetNgoDetailsForEdit");
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

    #region Function to compare category of gallery

    public DataSet NGOIDForComparison(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NgoID", ngoObject.NgoID));
            return ncmdbObject.ExecuteDataSet("ASP_NGO_Id");
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
    #region Function to NGO Detail  workperform

    public DataSet NGODetails(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NgoID", ngoObject.NgoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", ngoObject.VillageID));
            return ncmdbObject.ExecuteDataSet("NTCA_NGO");
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
    #region Function to NGO Detail

    public DataSet workperform(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@WORKPID", ngoObject.NgoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", ngoObject.VillageID));
            return ncmdbObject.ExecuteDataSet("NTCA_WORKPERFORM");
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
    #region Function to NGO Detail

    public DataSet GetSchemeDetail(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@SchemeID", ngoObject.NgoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", ngoObject.VillageID));
            return ncmdbObject.ExecuteDataSet("NTCA_GetSchemeDetail");
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
    #region Function for Delete NGO  DeleteExcutive
    public int DeleteNGO(NgoOB NGOID)
    {
        try
        {

             ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", NGOID.VillageID));
            return ncmdbObject.ExecuteNonQuery("Delete_NGO");
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Delete Excutive
    public int DeleteExcutive(NgoOB NGOID)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@EXID", NGOID.VillageID));
            return ncmdbObject.ExecuteNonQuery("NTCA_DeleteExcutive");
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Delete Excutive
    public int DeleteScheme(NgoOB NGOID)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@ConversionID", NGOID.VillageID));
            return ncmdbObject.ExecuteNonQuery("NTCA_DeleteScheme");
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Delete FUND 
    public int DeleteFund(NgoOB NGOID)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@FID", NGOID.VillageID));
            return ncmdbObject.ExecuteNonQuery("Delete_Fund");
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function to fund Detail

    public DataSet FundDetails(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", ngoObject.UserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", ngoObject.VillageID));
            return ncmdbObject.ExecuteDataSet("NTCA_GetFundDetail");
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
    #region Function for Delete NGO  DeleteExcutive
    public int DeletePostNGO(NgoOB NGOID)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", NGOID.VillageID));
            return ncmdbObject.ExecuteNonQuery("Delete_POSTNGO");
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function to NGO Detail  workperform
    public DataSet getPostNGODetails(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NgoID", ngoObject.NgoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", ngoObject.VillageID));
            return ncmdbObject.ExecuteDataSet("NTCA_POST_NGO");
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
    #region Function to Get Scheme
    public DataSet GetScheme(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@SchemeID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("sp_GetScheme");
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
    #region Function for Save Conversion Scheme
    public int SaveMultipleScheme(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@ConversionScheme", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SaveMultipleScheme");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Scheme History 
    public DataSet ConverSionScheme_History(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ConversionID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("sp_GetSchemeHistory");
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
    #region Function for Save WorkPerform History 
    public int SaveworkPerformHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@workperform", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@WorkID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEWORKPERFORMHISTORY");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function to  GetWorkName
    public DataSet GetWorkName(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@WorkID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("sp_GetWork");
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
    #region Function for Scheme History 
    public DataSet workperform_History(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@WorkID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("sp_GetWorkperformHistory");
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
    #region Function for Save NGO History
    public int SavePostNgoHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@PostNGODetail", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEPOSTNGOHISTORYRECORD");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for NGO Name
    public DataSet NGONAME(int ID)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", ID));
            return ncmdbObject.ExecuteDataSet("SP_POSTNGO");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Post Ngo History
    public DataSet POSTNGO_History(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("POSTNGO_History");
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
	 #region Function for Save NGO History
    public int SavePreNgoHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@PostNGODetail", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEPRENGOHISTORY");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Pre Ngo History
    public DataSet PRENGO_History(NgoOB ngoObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@NGOID", ngoObject.SchemeID));
            return ncmdbObject.ExecuteDataSet("PRENGO_History");
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
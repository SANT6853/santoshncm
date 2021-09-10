using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for BannerManagementDL
/// </summary>
public class BannerManagementDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion

    #region Default constructor zone
    public BannerManagementDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Fucntion to insert and update link temp records

    public int insertBanner(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", lnkObject.ActionType);

            ncmdbObject.AddParameter("@Name", lnkObject.Name);
            ncmdbObject.AddParameter("@AltTag", lnkObject.AltTag);
            ncmdbObject.AddParameter("@Image_Name", lnkObject.ImageName);
            ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangID);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@NameReg", lnkObject.NameRegional);
            ncmdbObject.AddParameter("@AltReg", lnkObject.AltTagReg);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@WebsiteId", lnkObject.Websiteid);
            ncmdbObject.AddParameter("@UrlName", lnkObject.UrlName);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("sp_Links_Insert_Update_Banner");
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

    #region Function to display all banner data

    public DataSet GetBannerData(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@status_id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@Websiteid", lnkObject.Websiteid);
            return ncmdbObject.ExecuteDataSet("sp_Display_All_Banner");
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
    public DataSet GetLogoBannerData(ContentOB lnkObject)
    {
        try
        {
           
            ncmdbObject.AddParameter("@status_id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@module_Id", lnkObject.ModuleID);

            return ncmdbObject.ExecuteDataSet("sp_Display_All_BannerNew");
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

    #region Function to display banner in edit mode

    public DataSet DisplayBanner_AtEdit(ContentOB lnkObject)
    {
        try
        {

            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@TempLink_Id", lnkObject.TempLinkID);
            return ncmdbObject.ExecuteDataSet("ASP_GetData_For_Edit");

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

    #region Function to update banner data

    public int UpdateBannerData(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", lnkObject.ActionType);
            ncmdbObject.AddParameter("@TempLink_Id", lnkObject.TempLinkID);
            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@Name", lnkObject.Name);
            ncmdbObject.AddParameter("@Image_Name", lnkObject.ImageName);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@AltTag", lnkObject.AltTag);
            ncmdbObject.AddParameter("@Link_Id", lnkObject.LinkID);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@NameReg", lnkObject.NameRegional);
            ncmdbObject.AddParameter("@AltReg", lnkObject.AltTagReg);
            ncmdbObject.AddParameter("@WebsiteId", lnkObject.Websiteid);
            ncmdbObject.AddParameter("@UrlName", lnkObject.UrlName);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("sp_Links_Insert_Update_Banner");
            recordCount = Convert.ToInt16(param[0].Value);
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

    #region Function to bind banner on home page

    public DataSet getBannerList(ContentOB  lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@module_id", lnkObject.ModuleID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Tigerreserveid", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@WebsiteID", lnkObject.Websiteid));

            return ncmdbObject.ExecuteDataSet("USP_get_Banner");
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
    public DataSet LogoBannerBind(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Lang_Id", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Module_Id", lnkObject.ModuleID));
            return ncmdbObject.ExecuteDataSet("ChkLogoBannerExist");
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

    public DataSet getTigerReserveIdByTname(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", lnkObject.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 2));

            return ncmdbObject.ExecuteDataSet("spTigerReserveBannerParticular");
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
    public DataSet GetStateName(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 1));

            return ncmdbObject.ExecuteDataSet("Mischellous");
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
    public DataSet GetTigerReserveName(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", lnkObject.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 2));

            return ncmdbObject.ExecuteDataSet("Mischellous");
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
    public DataSet GetDistrictNameByMapDistrictID(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@MapDistrictID", lnkObject.mapDistrictID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 3));

            return ncmdbObject.ExecuteDataSet("Mischellous");
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
    public DataSet CheckDataOperatorWithTigerReserve(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@DataOperatorUserID", lnkObject.DataOperatorUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", lnkObject.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", lnkObject.Action));

            return ncmdbObject.ExecuteDataSet("spUserDetailsAction");
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
    public DataSet getTigerReserveBanner(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@stateid", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@tigerreserveid", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Module_Id",3));
            
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", 1));

            return ncmdbObject.ExecuteDataSet("spTigerReserveBannerParticular");
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
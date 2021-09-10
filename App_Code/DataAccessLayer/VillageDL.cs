using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for VillageDL
/// </summary>
public class VillageDL
{
    Project_Variables P_var = new Project_Variables();
    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    public VillageDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert_VillageDetails(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", obj_village.Villageid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", obj_village.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Village_Name", obj_village.Village_Name));
            ncmdbObject.Parameters.Add(new SqlParameter("@Agriculture_Land",obj_village.Agriculture_Land));
            ncmdbObject.Parameters.Add(new SqlParameter("@Population",obj_village.Population));
            ncmdbObject.Parameters.Add(new SqlParameter("@Residential_property", obj_village.Residential_property));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Standing_Trees", obj_village.Total_Standing_Trees));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Livestock", obj_village.Total_Livestock));
            ncmdbObject.Parameters.Add(new SqlParameter("@Relocated_from", obj_village.Relocated_from));
            ncmdbObject.Parameters.Add(new SqlParameter("@Relocated_place", obj_village.Relocated_place));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_well", obj_village.Total_well));
            ncmdbObject.Parameters.Add(new SqlParameter("@Other_Assets", obj_village.Other_Assets));
            ncmdbObject.Parameters.Add(new SqlParameter("@Current_location_Latitude", obj_village.Current_location_Latitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@Current_location_Longitude", obj_village.Current_location_Longitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@location_Latitude_From", obj_village.location_Latitude_From));
            ncmdbObject.Parameters.Add(new SqlParameter("@location_Longitude_From", obj_village.location_Longitude_From));
            ncmdbObject.Parameters.Add(new SqlParameter("@Submitedby", obj_village.Submitedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@LastUpdatedby", obj_village.LastUpdatedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@stateid", obj_village.StateID));

            ncmdbObject.Parameters.Add(new SqlParameter("@GramPanchayatID", obj_village.GrampanchayatID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Tehsilid", obj_village.TehshilID));
            ncmdbObject.Parameters.Add(new SqlParameter("@DistID", obj_village.DistrictID));
            ncmdbObject.Parameters.Add(new SqlParameter("@AreaType", obj_village.AreaType));
            ncmdbObject.Parameters.Add(new SqlParameter("@RelocationStatusID", obj_village.RelocationStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@LegalStatus", obj_village.LegalStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@DateofSurvey", obj_village.DateofSurvey));
            ncmdbObject.Parameters.Add(new SqlParameter("@DateofConcenment", obj_village.DateofConcenment));

          //  ncmdbObject.Parameters.Add(new SqlParameter("@Animal_Details", dt));

            return ncmdbObject.ExecuteNonQuery("Insert_VillageDetails");
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
    public int Update_VillageDetails(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", obj_village.Villageid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", obj_village.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Village_Name", obj_village.Village_Name));
            ncmdbObject.Parameters.Add(new SqlParameter("@Agriculture_Land", obj_village.Agriculture_Land));
            ncmdbObject.Parameters.Add(new SqlParameter("@Population", obj_village.Population));
            ncmdbObject.Parameters.Add(new SqlParameter("@Residential_property", obj_village.Residential_property));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Standing_Trees", obj_village.Total_Standing_Trees));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Livestock", obj_village.Total_Livestock));
            ncmdbObject.Parameters.Add(new SqlParameter("@Relocated_from", obj_village.Relocated_from));
            ncmdbObject.Parameters.Add(new SqlParameter("@Relocated_place", obj_village.Relocated_place));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_well", obj_village.Total_well));
            ncmdbObject.Parameters.Add(new SqlParameter("@Other_Assets", obj_village.Other_Assets));
            ncmdbObject.Parameters.Add(new SqlParameter("@Current_location_Latitude", obj_village.Current_location_Latitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@Current_location_Longitude", obj_village.Current_location_Longitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@location_Latitude_From", obj_village.location_Latitude_From));
            ncmdbObject.Parameters.Add(new SqlParameter("@location_Longitude_From", obj_village.location_Longitude_From));
            ncmdbObject.Parameters.Add(new SqlParameter("@Submitedby", obj_village.Submitedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@LastUpdatedby", obj_village.LastUpdatedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusID", obj_village.StatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@tmpVillageID", obj_village.TempVillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", obj_village.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@GramPanchayatID", obj_village.GrampanchayatID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Tehsilid", obj_village.TehshilID));
            ncmdbObject.Parameters.Add(new SqlParameter("@DistID", obj_village.DistrictID));
            ncmdbObject.Parameters.Add(new SqlParameter("@AreaType", obj_village.AreaType));
            ncmdbObject.Parameters.Add(new SqlParameter("@RelocationStatusID", obj_village.RelocationStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@LegalStatus", obj_village.LegalStatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@DateofSurvey", obj_village.DateofSurvey));
            ncmdbObject.Parameters.Add(new SqlParameter("@DateofConcenment", obj_village.DateofConcenment));

            //ncmdbObject.Parameters.Add(new SqlParameter("@Animal_Details", dt));

            return ncmdbObject.ExecuteNonQuery("sp_UpdateVillage");
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
    #region function to get village list 
    public DataSet getVillageList(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", HttpContext.Current.Session["User_Id"]));
            
            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_VillageList");
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
    public DataSet GetUserNameOfStateReserveDfoDAL(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateUserID", obj_village.StateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ReserveUserId", obj_village.ReserveUserId));
            ncmdbObject.Parameters.Add(new SqlParameter("@DfoUserID", obj_village.DfoUserID));
            return ncmdbObject.ExecuteDataSet("spStateReserveDfoUserName");
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
    public DataSet GetStateUserTigerReserveUserDataOperatorUser(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@DataOperatorUserID", obj_village.CmnDataOperatorUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_village.CmnStateID));
          //  ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_village.ActionType));
            return ncmdbObject.ExecuteDataSet("getStateUserTigerReserveUser");
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
    #region [dashboard counter]
    public DataSet DashBoardCounter(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", obj_village.UserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CmnTigerReserveUserID", obj_village.CmnTigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CmnStateUserID", obj_village.CmnStateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@PermissionState", obj_village.PermissionState));
            ncmdbObject.Parameters.Add(new SqlParameter("@SubmittedByUserID", obj_village.SubmittedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_village.ActionType));
               

                if (HttpContext.Current.Session["User_Id"].ToString() == "1")
                {

                    return ncmdbObject.ExecuteDataSet("spDashboardCounterNTCA");
                }
            else
                {
                    ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_village.StateID));
                    return ncmdbObject.ExecuteDataSet("spDashboardCounter");
                }
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
    public DataSet NGoDashBoardCounter(VillageOB obj_village)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_village.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", HttpContext.Current.Session["User_Id"]));
            return ncmdbObject.ExecuteDataSet("NgoCounter");
           
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
    public DataSet DashBoardCounterNTCA(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", obj_village.UserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CmnTigerReserveUserID", obj_village.CmnTigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CmnStateUserID", obj_village.CmnStateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@PermissionState", obj_village.PermissionState));
            ncmdbObject.Parameters.Add(new SqlParameter("@SubmittedByUserID", obj_village.SubmittedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_village.ActionType));
           // ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_village.StateID));
            return ncmdbObject.ExecuteDataSet("spDashboardCounter");
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
    public DataSet getVillageListNTCA(VillageOB obj_village)
    {
        try
        {
           // ncmdbObject.Parameters.Add(new SqlParameter("@UserID", HttpContext.Current.Session["User_Id"]));

            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_VillageListNTCA");
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
    public DataSet getTigerReserveListNTCA(VillageOB obj_village)
    {
        try
        {
            // ncmdbObject.Parameters.Add(new SqlParameter("@UserID", HttpContext.Current.Session["User_Id"]));

            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_TigerReserListNTCA");
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
    public DataSet getVillageListTigerUser(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ParentTigerReserveUserID", HttpContext.Current.Session["User_Id"]));

            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_VillageListTigerUserUser");
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
    public DataSet getVillageListStateUser(VillageOB obj_village)
    {
        try
        {
          //  string ss=HttpContext.Current.Session["PermissionState"].ToString();
           // string ssdd = HttpContext.Current.Session["User_Id"].ToString();
            ncmdbObject.Parameters.Add(new SqlParameter("@stateID", HttpContext.Current.Session["PermissionState"]));
            //ncmdbObject.Parameters.Add(new SqlParameter("@ParentTigerReserveUserID", HttpContext.Current.Session["User_Id"]));

            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_VillageListSateUser");
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
    public DataSet Get_VillageDetialsForEdit(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", obj_village.Villageid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Stattus", obj_village.StatusID));
           
            return ncmdbObject.ExecuteDataSet("ASP_Get_Village_DetailsForEdit");
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
    public DataSet Get_Animal_By_Village_ForEdit(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", obj_village.Villageid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status", obj_village.StatusID));

            return ncmdbObject.ExecuteDataSet("Get_Animal_By_Village_ForEdit");
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

    #region Function to insert photo category in final table

    public int InsertVillageDetailsInWeb(VillageOB obj_village)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@TempVillageid", obj_village.TempVillageID);
            ncmdbObject.AddParameter("@UserID", obj_village.UserID);
            ncmdbObject.AddParameter("@IpAddress", obj_village.IpAddress);

            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_Approve_Village");
            P_var.Result = Convert.ToInt16(param[0].Value);
            return P_var.Result;
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

    public DataSet VillageIDForComparison(VillageOB villageObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageId", villageObject.Villageid));
            return ncmdbObject.ExecuteDataSet("ASP_Village_Id");
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
    public DataSet GetVillageByTigerReserverID(int TigerReserveid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveId", TigerReserveid));
            return ncmdbObject.ExecuteDataSet("GetVillageByTigerReserverID");
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

    #region Function to insert-update village associate with NGO

    public int InsertUpdateAssociateNGO(VillageOB villageObject)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", villageObject.ActionType);
            ncmdbObject.AddParameter("@ID", villageObject.NGOAssociatedID);
            ncmdbObject.AddParameter("@NGO_ID", villageObject.NGO_ID);
            ncmdbObject.AddParameter("@VillageID", villageObject.villageID);
            ncmdbObject.AddParameter("@Amount", villageObject.amount);
            ncmdbObject.AddParameter("@WorkForVillage", villageObject.WorkForVillage);

            ncmdbObject.AddParameter("@stateID", villageObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveid", villageObject.TigerReserveid);

            ncmdbObject.AddParameter("@UserId", villageObject.UserID);
            ncmdbObject.AddParameter("@IpAddress", villageObject.IpAddress);

            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("usr_insertUpdateAssociateNGO");
            P_var.Result = Convert.ToInt16(param[0].Value);
            return P_var.Result;

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

    #region Function to get village name

    public DataSet getVillageName(VillageOB villageObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", villageObject.TigerReserveid));
            return ncmdbObject.ExecuteDataSet("adm_GetVillage");
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

    
    #region Function to get NGO name

    public DataSet getNGOName()
    {
        try
        {
          return ncmdbObject.ExecuteDataSet("adm_GetNGO");
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

    public DataSet getAssociatedNGOList(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_village.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", obj_village.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status", obj_village.StatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", obj_village.Pageindex));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", obj_village.PageSize));
            return ncmdbObject.ExecuteDataSet("Get_NGOAssociatedWithVillage");
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

    //date 13-01-2018

    public DataSet Get_VillageDetailsCDP(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", obj_village.Villageid));
            return ncmdbObject.ExecuteDataSet("ASP_Get_Village_DetailsForCDP");
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
    public DataSet TestJquery(VillageOB obj_village)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_village.Action));
            return ncmdbObject.ExecuteDataSet("sptestJquery");
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
    public DataSet Get_VillageDetailsForDisplay(int villageid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", villageid));

            return ncmdbObject.ExecuteDataSet("Get_VillageDetailsForDisplay");
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
    //End
}

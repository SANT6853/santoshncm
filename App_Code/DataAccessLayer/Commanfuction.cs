using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Commanfuction
/// </summary>
public class Commanfuction
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
   
    #endregion
    public Commanfuction()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet StateListByUserAccess(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@userid", obj_ntca.UserID));
            return ncmdbObject.ExecuteDataSet("Get_StateListByUser");
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
    public DataSet TestMenu()
    {
        try
        {
           // ncmdbObject.Parameters.Add(new SqlParameter("@userid", obj_ntca.UserID));
            return ncmdbObject.ExecuteDataSet("spTestMenu");
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
    public DataSet BindBarChart(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            return ncmdbObject.ExecuteDataSet("BarChart");
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
    public DataSet BindBarComparativeChart(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            return ncmdbObject.ExecuteDataSet("BarChartComparative");
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
    public DataSet BindDdlStateBarChart(NtcaUserOB obj_ntca)
    {
        try
        {
          //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
           // ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            return ncmdbObject.ExecuteDataSet("GetStateBarPieChart");
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
    public DataSet GetStateName(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            // ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            return ncmdbObject.ExecuteDataSet("spGetStateName");
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
    public DataSet GetStateNameConsoldate(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntca.StateIDParameters));
            return ncmdbObject.ExecuteDataSet("spGetStateNameConsoldate");
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
    public DataSet ConsoldateReportGetStateName(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("SpConsoldateReportGetStateName");
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
    public DataSet ConsoldateReport(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateIDParameters", obj_ntca.StateIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReseveIDParameters", obj_ntca.TigerReseveIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillId", obj_ntca.VillId));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadID", obj_ntca.FamilyHeadID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyMemeberID", obj_ntca.FamilyMemeberID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadPlusFamilyMemeberID", obj_ntca.FamilyHeadPlusFamilyMemeberID));
            return ncmdbObject.ExecuteDataSet("SpConsoldateReportFinal");
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
    public DataSet ConsoldateReportButtonSearch(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateIDParameters", obj_ntca.StateIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReseveIDParameters", obj_ntca.TigerReseveIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillId", obj_ntca.VillId));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadID", obj_ntca.FamilyHeadID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyMemeberID", obj_ntca.FamilyMemeberID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadPlusFamilyMemeberID", obj_ntca.FamilyHeadPlusFamilyMemeberID));
            return ncmdbObject.ExecuteDataSet("SpConsoldateReportFinalSearch");
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
    public DataSet ConsoldateReportTigerReserveName(NtcaUserOB obj_ntca)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("SpConsolDateReportTigerReserveName");
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
    public DataSet ConsoldateReportGetTigerReserveName(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("SpConsoldateReportGetTigerReserve");
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
    public DataSet ConsoldateReportGetVillageLIst(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("SpConsoldateReportGetVillageList");
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
    public DataSet GoogleMap(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromVill_ID", obj_ntca.FromVill_ID));
            return ncmdbObject.ExecuteDataSet("SpGoogleMap");
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
    public DataSet PostGoogleMap(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", obj_ntca.FromVill_ID));
            return ncmdbObject.ExecuteDataSet("sp_PostMapDetail");
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
    public DataSet BindDdlStateBarChart1(NtcaUserOB obj_ntca)
    {
        try
        {
            //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            // ncmdbObject.Parameters.Add(new SqlParameter("@StateName", obj_ntca.StateName));
            return ncmdbObject.ExecuteDataSet("spGetStateList");
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
    public DataSet BindVillagenameChart(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", obj_ntca.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            return ncmdbObject.ExecuteDataSet("spVillageGenderChartOnAction");
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
    public DataSet BindVillagename(NtcaUserOB obj_ntca)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", obj_ntca.UserID));
            return ncmdbObject.ExecuteDataSet("sp_BindVillage");
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
    public DataSet BindVillageCastBenficieryChart(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", obj_ntca.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            return ncmdbObject.ExecuteDataSet("spVillageCastChartOnAction");
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
    public DataSet BindVillageMaritalStatusOptionWiseChart(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageName", obj_ntca.VillageName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            return ncmdbObject.ExecuteDataSet("spVillageMaritalOptionWiseChartOnAction");
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
    public DataSet BindBarChartRelocated(NtcaUserOB obj_ntca)
    {
        try
        {
           
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));

            return ncmdbObject.ExecuteDataSet("BarChartOnAction");
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
    public DataSet BindBarChartComparativeNoRelocated(NtcaUserOB obj_ntca)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));

            return ncmdbObject.ExecuteDataSet("BarChartComparativeOnAction");
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
    public DataSet BindBarChartComparativeRelocated(NtcaUserOB obj_ntca)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", obj_ntca.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.sAction));

            return ncmdbObject.ExecuteDataSet("BarChartComparativeOnAction");
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
    public DataSet CheckSchemeName(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@SNo", obj_ntca.SNo));
            return ncmdbObject.ExecuteDataSet("spCheckSchemeNameAlreadyexist");
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
    public DataSet UserExistanceCheck(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserName", obj_ntca.UserName));
            return ncmdbObject.ExecuteDataSet("UserExistMischellous");
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
    public DataSet MustBeStateUserEntrySingleCheckds(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@PermissionState", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("UserExistMischellous");
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
    public DataSet OnlySingleStateUserInParticularStateds(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@PermissionState", obj_ntca.StateID));
            return ncmdbObject.ExecuteDataSet("UserExistMischellous");
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
    public DataSet BindProfile(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", obj_ntca.UserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.Action));
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
    public DataSet GetDataOperatorPermisson(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ParentTigerReserveUserID", obj_ntca.ParentTigerReserveUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@DataOperatorUserID", obj_ntca.DataOperatorUserID));
          //  ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", obj_ntca.TigerReserveID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", obj_ntca.Action));
            return ncmdbObject.ExecuteDataSet("spDataOperatonPermission");
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
    public DataSet GetTigerReserveOfTigerReserveUsers(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@userid", obj_ntca.UserID));
            return ncmdbObject.ExecuteDataSet("spGetTigerReserveOfTigerReserveUsers");
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
    public DataSet GetAnimal()
    {
        try
        {
           
            return ncmdbObject.ExecuteDataSet("Get_Animal");
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
    public DataSet Get_TigerReserve_state_Permission(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@UserType", obj_ntcauser.UserType));

            ncmdbObject.Parameters.Add(new SqlParameter("@Userid", obj_ntcauser.UserID));

            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", obj_ntcauser.State));

            return ncmdbObject.ExecuteDataSet("Get_TigerReserve_state_Permission");
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
    public DataSet GetGetBottomThumnailUserType2and3and4(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveId", obj_ntcauser.TigerReserveid));
            return ncmdbObject.ExecuteDataSet("GetBottomThumnailUserType2and3and4");
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
    public DataSet Get_TigerReserve_state_PermissionModified(NtcaUserOB obj_ntcauser)
    {
        try
        {
           // ncmdbObject.Parameters.Add(new SqlParameter("@UserType", obj_ntcauser.UserType));

           // ncmdbObject.Parameters.Add(new SqlParameter("@Userid", obj_ntcauser.UserID));

            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", obj_ntcauser.State));

            return ncmdbObject.ExecuteDataSet("spGetTigerReserveUsed");
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
    public DataSet ChkLogoBannerExist(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Module_Id", obj_ntcauser.ModuleID));

            ncmdbObject.Parameters.Add(new SqlParameter("@Lang_Id", obj_ntcauser.LangId));

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
    public DataSet GetDistrict(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", obj_ntcauser.State));

            return ncmdbObject.ExecuteDataSet("Get_District");
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
    public DataSet GetTehshil(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Distid", obj_ntcauser.Dist));

            return ncmdbObject.ExecuteDataSet("Get_Tehshil");
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
    public DataSet GetGramPanchayat(NtcaUserOB obj_ntcauser)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Tehsil", obj_ntcauser.TehshilID));

            return ncmdbObject.ExecuteDataSet("Get_GramPanchayat");
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
    public DataSet GetMapCredentials()
    {
        try
        {
            
            return ncmdbObject.ExecuteDataSet("usp_getTigerReserveForMap");
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
    public DataSet DistrictListByUserAccess(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@userid", obj_ntca.UserID));
            return ncmdbObject.ExecuteDataSet("Get_DistrictListByUser");
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
    public DataSet getTigerReserveName(TigerReserveOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", obj_ntca.TigerReserveid));
            return ncmdbObject.ExecuteDataSet("usr_GetTigerReserveName");
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
    public DataSet getVillageName(VillageOB obj_ntca)
    {
        try
        {
            ncmdbObject.AddParameter("@TigerReserveID", obj_ntca.TigerReserveid);
            ncmdbObject.AddParameter("@TempVillageid", obj_ntca.villageID);
            return ncmdbObject.ExecuteDataSet("usr_GetvillageName");
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
    public DataSet CheckCDP_details(string id)
    {
        try
        {
            ncmdbObject.AddParameter("@VillageID", id);
            return ncmdbObject.ExecuteDataSet("usr_Tiger_CheckCDP_details");
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


    public DataSet PostConsoldateReport(NtcaUserOB obj_ntca)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateIDParameters", obj_ntca.StateIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReseveIDParameters", obj_ntca.TigerReseveIDParameters));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillId", obj_ntca.VillId));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadID", obj_ntca.FamilyHeadID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyMemeberID", obj_ntca.FamilyMemeberID));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyHeadPlusFamilyMemeberID", obj_ntca.FamilyHeadPlusFamilyMemeberID));
            return ncmdbObject.ExecuteDataSet("SpPostConsoldateReportFinal");
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


    public bool checkviewform(string id)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@rowcount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.AddParameter("@VillageID", id);
            ncmdbObject.ExecuteDataSet("SpCheckVieForm");
            int result = Convert.ToInt32(param[0].Value);
            if(result>=1)
            {
                return true;
            }
            else
            {
                return false;
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
    public bool Remarks(ContentOB contentObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@rowcount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.AddParameter("@userId", contentObject.UserID);
            ncmdbObject.AddParameter("@villageId", contentObject.LinkParentID);
            ncmdbObject.AddParameter("@remarks", contentObject.details);
            ncmdbObject.AddParameter("@action", contentObject.Action);
            ncmdbObject.ExecuteNonQuery("Spremarks");
            int result = Convert.ToInt32(param[0].Value);
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
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
    public DataSet GetRemarksData(ContentOB contentObject)
    {
        try
        {
            ncmdbObject.AddParameter("@userId", contentObject.UserID);
            ncmdbObject.AddParameter("@villageId", contentObject.LinkParentID);          
            return ncmdbObject.ExecuteDataSet("SpGetRemarks");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FamilyDL
/// </summary>
public class FamilyDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();

    #endregion
    public FamilyDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet Get_AnimalByfamily(int Familyid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@familyidId", Familyid));
            return ncmdbObject.ExecuteDataSet("Asp_Get_family_AnimalList");
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
    public DataSet Get_FamilyMemeberList(int familyid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@familyid", familyid));
            return ncmdbObject.ExecuteDataSet("Get_FamilyMemeberList");
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
    public int Asp_Update_Family_Detials(FamilyOB _familyOb, DataTable dtfamilyanimal, DataTable dtfamilymember)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@familyid", _familyOb.familyid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", _familyOb.Stateid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", _familyOb.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _familyOb.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Head_Name", _familyOb.Head_Name));
            ncmdbObject.Parameters.Add(new SqlParameter("@Agriculature_land", _familyOb.Agriculature_land));
            ncmdbObject.Parameters.Add(new SqlParameter("@Residential_Property", _familyOb.Residential_Property));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Livestock", _familyOb.Total_Livestock));
            ncmdbObject.Parameters.Add(new SqlParameter("@Other_assest", _familyOb.Other_assest));
            ncmdbObject.Parameters.Add(new SqlParameter("@Longitude", _familyOb.Longitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@Latitude", _familyOb.Latitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@SanctionLeter", _familyOb.SanctionLeter));
            ncmdbObject.Parameters.Add(new SqlParameter("@Submitedby", _familyOb.Submitedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@IPAddress", _familyOb.IPAddress));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedBy", _familyOb.UpdatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyMember", dtfamilymember));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyAnimal", dtfamilyanimal));

            return ncmdbObject.ExecuteNonQuery("Asp_Update_Family_Detials");

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
    public int InsertFamilydetiails(FamilyOB _familyOb, DataTable dtfamilyanimal, DataTable dtfamilymember)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", _familyOb.Stateid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", _familyOb.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _familyOb.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Head_Name", _familyOb.Head_Name));
            ncmdbObject.Parameters.Add(new SqlParameter("@Agriculature_land", _familyOb.Agriculature_land));
            ncmdbObject.Parameters.Add(new SqlParameter("@Residential_Property", _familyOb.Residential_Property));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Livestock", _familyOb.Total_Livestock));
            ncmdbObject.Parameters.Add(new SqlParameter("@Other_assest", _familyOb.Other_assest));
            ncmdbObject.Parameters.Add(new SqlParameter("@Longitude", _familyOb.Longitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@Latitude", _familyOb.Latitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@SanctionLeter", _familyOb.SanctionLeter));
            ncmdbObject.Parameters.Add(new SqlParameter("@Submitedby", _familyOb.Submitedby));
            ncmdbObject.Parameters.Add(new SqlParameter("@IPAddress", _familyOb.IPAddress));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedBy", _familyOb.UpdatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyMember", dtfamilymember));
            ncmdbObject.Parameters.Add(new SqlParameter("@FamilyAnimal", dtfamilyanimal));

            ncmdbObject.Parameters.Add(new SqlParameter("@SurveryDate", _familyOb.SurveryDate));
            ncmdbObject.Parameters.Add(new SqlParameter("@DistictID", _familyOb.DistictID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Tehshilid", _familyOb.Tehshilid));
            ncmdbObject.Parameters.Add(new SqlParameter("@GramPanchayat", _familyOb.GramPanchayat));
            ncmdbObject.Parameters.Add(new SqlParameter("@Area", _familyOb.Area));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusofResidence", _familyOb.StatusofResidence));
            ncmdbObject.Parameters.Add(new SqlParameter("@ReallocationPlace", _familyOb.ReallocationPlace));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Well", _familyOb.Total_Well));
            ncmdbObject.Parameters.Add(new SqlParameter("@Total_Tree", _familyOb.Total_Tree));
            ncmdbObject.Parameters.Add(new SqlParameter("@LagalStatus", _familyOb.Legalstatus));
            ncmdbObject.Parameters.Add(new SqlParameter("@OptionSelected", _familyOb.OptionSelected));


           


            return ncmdbObject.ExecuteNonQuery("Asp_Add_Family_Detials");
            
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
    public DataSet get_FamilyList(FamilyOB _familyOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@stateid", _familyOb.Stateid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Tigerreserveid", _familyOb.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Villageid", _familyOb.VillageID));
           
            ncmdbObject.Parameters.Add(new SqlParameter("@PageNumber", _familyOb.PageNumber));
            ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", _familyOb.PageSize));

            return ncmdbObject.ExecuteDataSet("get_FamilyList");
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
    public DataSet Asp_GetFamilyDetialsForEdit(int familyid)
    {
        try
        {
           
            ncmdbObject.Parameters.Add(new SqlParameter("@Familyid", familyid));

            return ncmdbObject.ExecuteDataSet("Asp_GetFamilyDetialsForEdit");
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
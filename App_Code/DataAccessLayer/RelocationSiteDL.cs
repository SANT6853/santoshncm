using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RelocationSiteDL
/// </summary>
public class RelocationSiteDL
{
    Project_Variables P_var = new Project_Variables();
    NCMdbAccess ncmdbObject = new NCMdbAccess();

    public RelocationSiteDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Function to add relocation site for village

    public bool Add_Relocation_Site(RelocationSiteOB relocationObject)
    {
        try
        {

            ncmdbObject.AddParameter("@StateName", relocationObject.StateName);
            ncmdbObject.AddParameter("@DistrictName", relocationObject.DistrictName);
            ncmdbObject.AddParameter("@TehshilName", relocationObject.TehshilName);
            ncmdbObject.AddParameter("@GramPanchayatName", relocationObject.GrampanchayatName);
            ncmdbObject.AddParameter("@VillageName", relocationObject.VillageName);
            ncmdbObject.AddParameter("@COMMENT", relocationObject.Comment);
            ncmdbObject.AddParameter("@RelocatedSiteAddress", relocationObject.RelocatedSiteAddress);
            ncmdbObject.AddParameter("@VillageID", relocationObject.VillageID);
            int i = ncmdbObject.ExecuteNonQuery("Relocation_SiteInsert");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    #endregion

    #region Function to update relocation site

    public bool Update_Relocation_Site(RelocationSiteOB relocationObject)
    {
        try
        {
            ncmdbObject.AddParameter("@RelocationAreaId", relocationObject.RelocationAreaId);
            ncmdbObject.AddParameter("@StateName", relocationObject.StateName);
            ncmdbObject.AddParameter("@DistrictName", relocationObject.DistrictName);
            ncmdbObject.AddParameter("@TehshilName", relocationObject.TehshilName);
            ncmdbObject.AddParameter("@GramPanchayatName", relocationObject.GrampanchayatName);
            ncmdbObject.AddParameter("@VillageName", relocationObject.VillageName);
            ncmdbObject.AddParameter("@COMMENT", relocationObject.Comment);
            ncmdbObject.AddParameter("@RelocatedSiteAddress", relocationObject.RelocatedSiteAddress);
            ncmdbObject.AddParameter("@VillageID", relocationObject.VillageID);
            int i = ncmdbObject.ExecuteNonQuery("Proc_Tiger_Update_Info_Relocation_Area");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    #endregion

    #region Function to display all relocation areas

    public DataSet Display_All_Relocation_Area(RelocationSiteOB relocationObject, string Relo_id)
    {
        ncmdbObject.AddParameter("@VillageID", relocationObject.VillageID);
        ncmdbObject.AddParameter("@RelocationAreaId", Relo_id);

        return ncmdbObject.ExecuteDataSet("Relocation_DisplayAreaByID");
    }

    #endregion
}
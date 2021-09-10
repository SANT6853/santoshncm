using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelocatinSiteBL
/// </summary>
public class RelocatinSiteBL
{
    RelocationSiteDL relocationDL = new RelocationSiteDL();

    public RelocatinSiteBL()
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
            return relocationDL.Add_Relocation_Site(relocationObject);
        }
        catch 
        {
            throw;
        }
    }

    #endregion

    #region Function to update relocation site

    public bool Update_Relocation_Site(RelocationSiteOB relocationObject)
    {
        try
        {
            return relocationDL.Update_Relocation_Site(relocationObject);
        }
        catch 
        {
            throw;
        }
    }

    #endregion

    #region Function to display all relocation areas

    public DataSet Display_All_Relocation_Area(RelocationSiteOB relocationObject, string Relo_id)
    {
        return relocationDL.Display_All_Relocation_Area(relocationObject, Relo_id);
    }

    #endregion
}
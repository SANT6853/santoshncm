using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistrictTehshilBL
/// </summary>
public class DistrictTehshilBL
{
    #region Variable declaration zone

    DistrictDL districtTehshilDL = new DistrictDL();

    #endregion
    public DistrictTehshilBL()
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
            return districtTehshilDL.insertUpdateDistrict(distObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to display all district

    public DataSet DisplayDistrict(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            return districtTehshilDL.DisplayDistrict(distObject, out Catvalue);

        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to display district name for updation

    public DataSet DisplayDistrictInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            return districtTehshilDL.DisplayDistrictInEdit(distObject);

        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Fucntion to insert and update Tehshil of district

    public int insertUpdateTehshil(DistrictTehshilOB distObject)
    {
        try
        {
            return districtTehshilDL.insertUpdateTehshil(distObject);
        }
        catch
        {
            throw;
        }

    }
    public int DeleteDistrict(int districtID, int action)
    {
        try
        {
            return districtTehshilDL.DeleteDistrict(districtID, action);
        }
        catch
        {
            throw;
        }

    }
    public int DeleteTehshil(int tehshilID, int action)
    {
        try
        {
            return districtTehshilDL.DeleteTehshil(tehshilID, action);
        }
        catch
        {
            throw;
        }

    }
    public int DeleteGramPanchyat(int id, int action)
    {
        try
        {
            return districtTehshilDL.DeleteGramPanchyat(id, action);
        }
        catch
        {
            throw;
        }

    }


    #endregion

    #region Function to display all district

    public DataSet DisplayDistrictTehshil(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            return districtTehshilDL.DisplayDistrictTehshil(distObject, out  Catvalue);

        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to display district tehshil name for updation

    public DataSet DisplayDistrictTehshilInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            return districtTehshilDL.DisplayDistrictTehshilInEdit(distObject);

        }
        catch
        {
            throw;
        }
      
    }

    #endregion

    #region Fucntion to insert and update Tehshil grampanchayat of district

    public int insertUpdateTehshilGrampanchayat(DistrictTehshilOB distObject)
    {
        try
        {
            return districtTehshilDL.insertUpdateTehshilGrampanchayat(distObject);
        }
        catch
        {
            throw;
        }
      
    }

    #endregion

    #region Function to display all district tehshil grampanchayat

    public DataSet DisplayDistrictTehshilGrampanchayat(DistrictTehshilOB distObject, out int Catvalue)
    {
        try
        {
            return districtTehshilDL.DisplayDistrictTehshilGrampanchayat(distObject, out  Catvalue);

        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to display district tehshil grampanchayat name for updation

    public DataSet DisplayDistrictTehshilGramPanchayatInEdit(DistrictTehshilOB distObject)
    {
        try
        {

            return districtTehshilDL.DisplayDistrictTehshilGramPanchayatInEdit(distObject);

        }
        catch
        {
            throw;
        }
    }

    #endregion
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BannerManagementBL
/// </summary>
public class BannerManagementBL
{
    #region Variable declaration zone

    BannerManagementDL bannerBL = new BannerManagementDL();

    #endregion
    public BannerManagementBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Fucntion to insert and update link temp records

    public int insertBanner(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.insertBanner(bannerObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to display all banner data

    public DataSet GetBannerData(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.GetBannerData(bannerObject);
        }
        catch
        {
            throw;
        }
       
    }
    public DataSet GetLogoBannerData(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.GetLogoBannerData(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    #endregion

    #region Function to display banner in edit mode

    public DataSet DisplayBanner_AtEdit(ContentOB bannerObject)
    {
        try
        {

            return bannerBL.DisplayBanner_AtEdit(bannerObject);

        }
        catch
        {
            throw;
        }
        
    }

    #endregion

    #region Function to update banner data

    public int UpdateBannerData(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.UpdateBannerData(bannerObject);
        }
        catch
        {
            throw;
        }
        
    }

    #endregion

    #region Function to bind banner on home page

    public DataSet getBannerList(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.getBannerList(bannerObject);
        }
        catch
        {
            throw;
        }
       
    }
    public DataSet LogoBannerBind(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.LogoBannerBind(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    #endregion
    public DataSet getTigerReserveIdByTname(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.getTigerReserveIdByTname(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetStateName(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.GetStateName(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetTigerReserveName(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.GetTigerReserveName(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetDistrictNameByMapDistrictID(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.GetDistrictNameByMapDistrictID(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    public DataSet CheckDataOperatorWithTigerReserve(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.CheckDataOperatorWithTigerReserve(bannerObject);
        }
        catch
        {
            throw;
        }

    }
    public DataSet getTigerReserveBanner(ContentOB bannerObject)
    {
        try
        {
            return bannerBL.getTigerReserveBanner(bannerObject);
        }
        catch
        {
            throw;
        }
    }
}
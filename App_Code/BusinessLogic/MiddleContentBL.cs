using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MiddleContentBL
/// </summary>
public class MiddleContentBL
{
    #region Variable declaration zone

    MiddlContentDL middlContentBL = new MiddlContentDL();
    
    #endregion
	public MiddleContentBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Fucntion to insert and update link temp records

    public int insertMiddlContent(ContentOB bannerObject)
    {
        try
        {
            return middlContentBL.insertMiddlContent(bannerObject);
        }
        catch
        {
            throw;
        }

    }

    #endregion
    #region Function to display all Middle content data

    public DataSet GetMiddleContentData(ContentOB bannerObject)
    {
        try
        {
            return middlContentBL.GetMiddleContentData(bannerObject);
        }
        catch
        {
            throw;
        }

    }

    #endregion
    #region Function to display banner in edit mode

    public DataSet DisplayMiddleContent_AtEdit(ContentOB bannerObject)
    {
        try
        {

            return middlContentBL.DisplayMiddleContent_AtEdit(bannerObject);

        }
        catch
        {
            throw;
        }

    }

    #endregion
    #region Function to update MiddleContent data

    public int UpdateMiddleContentData(ContentOB bannerObject)
    {
        try
        {
            return middlContentBL.UpdateMiddleContentData(bannerObject);
        }
        catch
        {
            throw;
        }

    }

    #endregion
    #region function delete middle content
    public int DelMiddlContent(ContentOB lnkObject)
    {
        try
        {
            return middlContentBL.DelMiddlContent(lnkObject);
        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region function bindTopMiddleLowerOnHomePage
    public DataSet bindTopMiddleLowerOnHomePage(ContentOB lnkObject)
    {
        try
        {
            return middlContentBL.bindTopMiddleLowerOnHomePage(lnkObject);
        }
        catch
        {
            throw;
        }
    }
    public DataSet bindTopMiddleLowerOnHomePageTreserve(ContentOB lnkObject)
    {
        try
        {
            return middlContentBL.bindTopMiddleLowerOnHomePageTreserve(lnkObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion

    #region function bindTopMiddleLowerOnHomePage specific details
    public DataSet bindTopMiddleLowerOnHomePagespecific(ContentOB lnkObject)
    {
        try
        {
            return middlContentBL.bindTopMiddleLowerOnHomePagespecific(lnkObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
}
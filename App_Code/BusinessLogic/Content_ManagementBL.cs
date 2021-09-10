using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Content_ManagementBL
/// </summary>
public class Content_ManagementBL
{
    #region Variable declaration zone

    Content_ManagementDL contentBL = new Content_ManagementDL();

    #endregion

    #region Default constructor zone
    public Content_ManagementBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    //Area for all the functions to get data

    #region Function to get State name

    public DataSet getStateName(ContentOB contentObject)
    {
        try
        {
            return contentBL.getStateName(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get Tiger reserve on the basis of state selected

    public DataSet getTigerReserve(ContentOB contentObject)
    {
        try
        {
            return contentBL.getTigerReserve(contentObject);
        }
        catch
        {
            throw;
        }
        
    }

    #endregion

    #region Function to get menuName from Link_Web table

    public DataSet getRootMenuNamFromWeb(ContentOB lnkObject)
    {
        try
        {
            return contentBL.getRootMenuNamFromWeb(lnkObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get Sublinks of Parant Menu from final table

    public DataSet getSubMenuOfParentMenu(ContentOB lnkObject)
    {
        try
        {
            return contentBL.getSubMenuOfParentMenu(lnkObject);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to get menu order at the ROOT level

    public DataSet getMenulevelOrder(ContentOB lnkObject)
    {
        try
        {
            return contentBL.getMenulevelOrder(lnkObject);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to get menu level  at the ROOT level

    public DataSet get_Menu_level_Link_Web(ContentOB lnkObject)
    {
        try
        {
            return contentBL.get_Menu_level_Link_Web(lnkObject);
        }
        catch
        {
            throw;
        }
        
    }

    #endregion

    #region Function To Display Details With Paging

    public DataSet gridDisplayData(ContentOB contentObject, out int catValue)
    {
        try
        {
            return contentBL.gridDisplayData(contentObject, out catValue);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get data for edit either from links table or links_web table

    public DataSet DisplayContentForUpdate(ContentOB contentObject)
    {
        try
        {
            return contentBL.DisplayContentForUpdate(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get Status according to permission

    public DataSet getWorkStatus(ContentOB contentObject)
    {
        try
        {
            return contentBL.getWorkStatus(contentObject);
        }
        catch
        {
            throw;
        }
       
    }
    public DataSet getWorkStatusBanner(ContentOB contentObject)
    {
        try
        {
            return contentBL.getWorkStatusBanner(contentObject);
        }
        catch
        {
            throw;
        }

    }
    #endregion

    #region Function to get Link Id  for edit from WEB LINKS

    public DataSet getApproveContentForEDit(ContentOB contentObject)
    {
        try
        {
            return contentBL.getApproveContentForEDit(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    //End


    //Area for all the functions to insert

    #region function to insert top menu in links temp table

    public int insertMenu(ContentOB lnkObject)
    {
        try
        {
            return contentBL.insertMenu(lnkObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region function to insert top menu in links web table

    public int ApproveContent(ContentOB contentObject)
    {
        try
        {
            return contentBL.ApproveContent(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    //End

    //ALL FUNCTIONS ARE WRITTEN FOR THE FRONT END SIDE

    #region Function to get ROOT MENU

    public DataSet getFrontRootMenu(ContentOB contentObject)
    {
        try
        {
            return contentBL.getFrontRootMenu(contentObject);
        }
        catch
        {
            throw;
        }
    }


    #endregion

    #region Function to get submenu of root menu

    public DataSet getSubmenuofRootMenu(ContentOB contentObject)
    {
        try
        {
            return contentBL.getSubmenuofRootMenu(contentObject);
        }
        catch
        {
            throw;
        }
       
    }


    #endregion

    #region Function to get MENU_ID to move it LEFT

    public DataSet getLinkMenuID(ContentOB contentObject)
    {
        try
        {
            return contentBL.getLinkMenuID(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get Root menu

    public DataSet get_Cliked_Parent_Menu(ContentOB contentObject)
    {
        try
        {
            return contentBL.get_Cliked_Parent_Menu(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get child of the parent menu

    public DataSet get_Cliked_Parent_Child_Menu(ContentOB contentObject)
    {
        try
        {
            return contentBL.get_Cliked_Parent_Child_Menu(contentObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion
    //END
}
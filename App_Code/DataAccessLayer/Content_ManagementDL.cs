using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Content_ManagementDAL
/// </summary>
public class Content_ManagementDL
{

    //Area for all the variables declaration

    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();

    #endregion

    //End

    #region Default constructor zone
    public Content_ManagementDL()
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
            ncmdbObject.Parameters.Add(new SqlParameter("@langID", contentObject.LangID));
            return ncmdbObject.ExecuteDataSet("sp_GetStateName");
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

    #region Function to get Tiger reserve on the basis of state selected

    public DataSet getTigerReserve(ContentOB contentObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@langID", contentObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", contentObject.StateID));
            return ncmdbObject.ExecuteDataSet("sp_GetTigerReserve");
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

    #region Function to get menuName from Link_Web table

    public DataSet getRootMenuNamFromWeb(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.CommandText = "sp_GetMainMenuForSubMenuLink";
            ncmdbObject.Parameters.Add(new SqlParameter("@LangID", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@PositionId", lnkObject.PositionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkParentId", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@WebsiteID", lnkObject.Websiteid));
            return ncmdbObject.ExecuteDataSet();
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

    #region Function to get Sublinks of Parant Menu from final table

    public DataSet getSubMenuOfParentMenu(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkParentId", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkLevel", lnkObject.LinkLevel));
            ncmdbObject.Parameters.Add(new SqlParameter("@PositionId", lnkObject.PositionID));
            return ncmdbObject.ExecuteDataSet("sp_GetParantSublinksID");
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

    #region Function to get menu order at the ROOT level

    public DataSet getMenulevelOrder(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@rootLevelId", lnkObject.LinkParentID));
            return ncmdbObject.ExecuteDataSet("sp_CountRootOrder_Link");
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

    #region Function to get menu level  at the ROOT level

    public DataSet get_Menu_level_Link_Web(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@rootLevelId", lnkObject.LinkParentID));
            return ncmdbObject.ExecuteDataSet("ASP_CountRootLevel_Link");
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

    #region Function To Display Details With Paging

    public DataSet gridDisplayData(ContentOB obj_linkOB, out int catValue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.AddParameter("@Lang_Id", obj_linkOB.LangID);
           
            ncmdbObject.AddParameter("@module_Id", obj_linkOB.ModuleID);
            ncmdbObject.AddParameter("@Statusid", obj_linkOB.StatusID);
            ncmdbObject.AddParameter("@position_Id", obj_linkOB.PositionID);
            ncmdbObject.AddParameter("@StateID", obj_linkOB.StateID);
            ncmdbObject.AddParameter("@TigerReserveid", obj_linkOB.TigerReserveid);
            ncmdbObject.AddParameter("@List_value", obj_linkOB.LinkParentID);
            ncmdbObject.AddParameter("@PageIndex", obj_linkOB.PageIndex);
            ncmdbObject.AddParameter("@PageSize", obj_linkOB.PageSize);
            
            p_Val.dSet = ncmdbObject.ExecuteDataSet("sp_TmpDataDisplayInGrid");
            catValue = Convert.ToInt16(param[0].Value);

            return p_Val.dSet;
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

    #region Function to get data for edit either from links table or links_web table

    public DataSet DisplayContentForUpdate(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@statusId", lnkObject.StatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TempLinkId", lnkObject.TempLinkID));
            //ncmdbObject.Parameters.Add(new SqlParameter("@LangId", lnkObject.LangID));
            return ncmdbObject.ExecuteDataSet("sp_Get_Link_Tmp_Edit");
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

    #region Function to get Status according to permission

    public DataSet getWorkStatus(ContentOB contentObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Status_Id", contentObject.StatusID));
            return ncmdbObject.ExecuteDataSet("MST_GetStatus");
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
    public DataSet getWorkStatusBanner(ContentOB contentObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Status_Id", contentObject.StatusID));
            return ncmdbObject.ExecuteDataSet("MST_GetStatusBanner");
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

    #region Function to get Link Id  for edit from WEB LINKS

    public DataSet getApproveContentForEDit(ContentOB obj_linkOB)
    {
        try
        {
            ncmdbObject.AddParameter("@Link_Id", obj_linkOB.LinkTypeID);
            return ncmdbObject.ExecuteDataSet("sp_getApproveContent forEdit");
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


    //End

    //Area for all the functions to insert

    #region function to insert top menu in links temp table

    public int insertMenu(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            // ncmdbObject.CommandText = "ASP_InsertUpdateDelete_Link_Tmp";
           // ncmdbObject.CommandText = "sp_Tmp_link_Insert_Update";
            ncmdbObject.CommandText = "sp_Tmp_link_Insert_Update";
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionType", lnkObject.ActionType));
            ncmdbObject.Parameters.Add(new SqlParameter("@Lang_Id", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Parent_Id", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Order", lnkObject.LinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Level", lnkObject.LinkLevel));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Type_Id", lnkObject.LinkTypeID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Id", lnkObject.LinkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Temp_Link_Id", lnkObject.TempLinkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Browser_Title", lnkObject.BrowserTitle));
            ncmdbObject.Parameters.Add(new SqlParameter("@Page_Title", lnkObject.PageTitle));
            ncmdbObject.Parameters.Add(new SqlParameter("@Meta_Keywords", lnkObject.MetaKeywords));
            ncmdbObject.Parameters.Add(new SqlParameter("@Mate_Description", lnkObject.MateDescription));

            ncmdbObject.Parameters.Add(new SqlParameter("@MetaLng", lnkObject.MetaLng));
            ncmdbObject.Parameters.Add(new SqlParameter("@MetaTitle", lnkObject.MetaTitle));
            ncmdbObject.Parameters.Add(new SqlParameter("@SmallDetails", lnkObject.SmallDetails));
            ncmdbObject.Parameters.Add(new SqlParameter("@Module_Id", lnkObject.ModuleID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Name", lnkObject.Name));
            ncmdbObject.Parameters.Add(new SqlParameter("@Position_Id", lnkObject.PositionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status_Id", lnkObject.StatusID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UrlName", lnkObject.UrlName));
           
             ncmdbObject.Parameters.Add(new SqlParameter("@IpAddress",lnkObject.IpAddress));
            ncmdbObject.Parameters.Add(new SqlParameter("@Last_Updated_By", lnkObject.LastUpdatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@Inserted_By", lnkObject.InsertedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@WebsiteID", lnkObject.Websiteid));
            if (lnkObject.LinkTypeID == 2)
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Url", lnkObject.Url));
            }
            else if (lnkObject.LinkTypeID == 1)
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Details", lnkObject.details));
            }
            else if (lnkObject.LinkTypeID == 3)
            {//naren added new one1june
                ncmdbObject.Parameters.Add(new SqlParameter("@File_Name", lnkObject.FileName));
            }
            //Output parameter to return Record count

            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);

            //End
            
            ncmdbObject.ExecuteNonQuery();
            p_Val.Result = Convert.ToInt32(param[0].Value);
            return p_Val.Result;
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


    #region function to insert top menu in links web table

    public int ApproveContent(ContentOB contentObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.Parameters.Add(new SqlParameter("@TempLinkId", contentObject.TempLinkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedBY", contentObject.LastUpdatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@IpAddress", contentObject.IpAddress));
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("sp_insertUpdateWebLink");
            p_Val.Result = Convert.ToInt16(param[0].Value);
            return p_Val.Result;
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

    //End

    //ALL FUNCTIONS ARE WRITTEN FOR THE FRONT END SIDE

    #region Function to get ROOT MENU

    public DataSet getFrontRootMenu(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@moduleid", lnkObject.ModuleID));
            ncmdbObject.Parameters.Add(new SqlParameter("@linkparentid", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@positionid", lnkObject.PositionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@langid", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", lnkObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Websiteid", lnkObject.Websiteid));
            return ncmdbObject.ExecuteDataSet("sp_GetRootMenu");

            //return ncmdbObject.ExecuteDataSet("USP_Get_Root_Menu_Ombudsman");
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

    #region Function to get submenu of root menu

    public DataSet getSubmenuofRootMenu(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangID));
            return ncmdbObject.ExecuteDataSet("sp_GetChildofRootMenu");
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

    #region Function to get MENU_ID to move it LEFT

    public DataSet getLinkMenuID(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentID));
            return ncmdbObject.ExecuteDataSet("ASP_Links_Web_Get_Menu_Parent_ID");
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

    #region Function to get Root menu

    public DataSet get_Cliked_Parent_Menu(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.LinkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", lnkObject.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@Websiteid", lnkObject.Websiteid));
            return ncmdbObject.ExecuteDataSet("USP_GetFrontMenu_Root");
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

    #region Function to get child of the parent menu

    public DataSet get_Cliked_Parent_Child_Menu(ContentOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentID));
            ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangID));
            return ncmdbObject.ExecuteDataSet("USP_GetFrontMenuSubMenu_Root");
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

    //END
}
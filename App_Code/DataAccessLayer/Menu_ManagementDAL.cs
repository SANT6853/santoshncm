using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using NCM.DAL;
public class Menu_ManagementDAL
{
    //Area for all the variables declaration 

    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    static int h;
   
    #endregion 

    //End

    //Area for all the constructors declaration

    #region Default constructor zone

    public Menu_ManagementDAL()
	{

    }

    #endregion 

    //End
    
    //Area for all the functions to get data

    #region Function to get menuName from Link_Web table

    public DataSet getMenuName_From_Web(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.CommandText = "asp_getmenus";
            ncmdbObject.Parameters.Add(new SqlParameter("@LangID", lnkObject.LangId));
            ncmdbObject.Parameters.Add(new SqlParameter("@PositionId", lnkObject.PositionId));
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkParentId", lnkObject.LinkParentId));
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

    #region Function to get menu type

    public DataSet getMenuType()
    {
        try
        {
            ncmdbObject.CommandText = "ASP_Get_LinkType_Mst";
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

    #region Function to get menu position

    public DataSet getMenuPosition()
    {
        try
        {
            ncmdbObject.CommandText = "ASP_Get_Position_Mst";
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

    #region Function to get menu order at the ROOT level

    public DataSet get_levelOrder_Link_Web(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@rootLevelId", lnkObject.LinkParentId));
            return ncmdbObject.ExecuteDataSet("ASP_CountRootOrder_Link");
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

    public DataSet getMenu_For_Editing(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@statusId", lnkObject.StatusId));
            ncmdbObject.Parameters.Add(new SqlParameter("@TempLinkId", lnkObject.TempLinkId));
            ncmdbObject.Parameters.Add(new SqlParameter("@LangId", lnkObject.LangId));
            return ncmdbObject.ExecuteDataSet("edit_data_menu");
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

    public DataSet get_SublinksID_of_Parant_From_Web(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkParentId", lnkObject.LinkParentId));
            ncmdbObject.Parameters.Add(new SqlParameter("@LinkLevel", lnkObject.LinkLevel));
            ncmdbObject.Parameters.Add(new SqlParameter("@PositionId", lnkObject.PositionId));
            return ncmdbObject.ExecuteDataSet("ASP_GetParantSublinksID_Link");
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

    public DataSet get_Menu_level_Link_Web(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@rootLevelId", lnkObject.LinkParentId));
            //return ncmdbObject.ExecuteDataSet("ASP_CountRootLevel_Link");
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
    #region swift_menus
    public int Left_Swift_Menus(LinkOB lnkObject)
    {


        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@linkid", lnkObject.linkID));

            ncmdbObject.Parameters.Add(new SqlParameter("@linkparentid", lnkObject.LinkParentId));



            ncmdbObject.Parameters.Add(new SqlParameter("@parenthierarchylevel", lnkObject.ParentII));
            ncmdbObject.Parameters.Add(new SqlParameter("@newchilds", lnkObject.ChildI));
            ncmdbObject.Parameters.Add(new SqlParameter("@linkorder", lnkObject.ChildII));


            int i = ncmdbObject.ExecuteNonQuery("leftswift ");
            return i;





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

    #region function for right_shift_menus
    public int Right_Swift_Menus(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@linkid", lnkObject.linkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@linkid_clicked", lnkObject.LinkParentId));
            int i = ncmdbObject.ExecuteNonQuery("rightingmodify ");
            return i;
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

    #region Function to get menu level left right  at the ROOT level

    public DataSet get_Menu_level_Link_Web_left_right(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@linkid", lnkObject.LinkParentId));
            //return ncmdbObject.ExecuteDataSet("ASP_CountRootLevel_Link");
            return ncmdbObject.ExecuteDataSet("temp_i ");
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

        //ALL FUNCTIONS ARE WRITTEN FOR THE FRONT END SIDE

        #region Function to get ROOT MENU

        public DataSet get_Frontside_RootMenu(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@moduleid", lnkObject.ModuleId));
                ncmdbObject.Parameters.Add(new SqlParameter("@linkparentid", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@positionid", lnkObject.PositionId));
                ncmdbObject.Parameters.Add(new SqlParameter("@langid", lnkObject.LangId));
                //ncmdbObject.Parameters.Add(new SqlParameter("@deptt_id", lnkObject.DepttId));
                return ncmdbObject.ExecuteDataSet("USP_Get_Root_Menu");

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

        public DataSet get_Frontside_Submenu_of_RootMenu(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                return ncmdbObject.ExecuteDataSet("USP_Get_Child_of_Root_Menu");
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

        #region get cicked Parent Child menu
        public DataSet get_Cliked_Parent_Child_Menu(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionId));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
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

        #region get cicked Parent Child menu for ombudsman

        public DataSet get_Cliked_Parent_ChildOmbudsman_Menu(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionId));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                return ncmdbObject.ExecuteDataSet("USP_GetFrontMenuSubMenuOmbudsman_Root");
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


        #region get cicked Parent Child menu for ombudsman
        public DataSet get_Cliked_ParentChild_Menuombudsman(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionId));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                return ncmdbObject.ExecuteDataSet("USP_GetFrontMenuSubMenu_RootOmbudsman");
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

        public DataSet get_Link_Menu_ID(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
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

        public DataSet get_Cliked_Parent_Menu(LinkOB lnkObject)
        {
            try
            {//'@Websiteid', 
                ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", lnkObject.TigerReserveid));
                ncmdbObject.Parameters.Add(new SqlParameter("@Websiteid", 1));
                
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

        ////////#region Function to get child of the parent menu

        ////////public DataSet get_Cliked_Parent_Child_Menu(LinkOB lnkObject)
        ////////{
        ////////    try
        ////////    {
        ////////        ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
        ////////        ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionId));
        ////////        ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
        ////////        return ncmdbObject.ExecuteDataSet("USP_GetFrontMenuSubMenu_Root");
        ////////    }
        ////////    catch
        ////////    {
        ////////        throw;
        ////////    }
        ////////    finally
        ////////    {
        ////////        ncmdbObject.Dispose();
        ////////    }
        ////////}

        ////////#endregion

        #region Function to get clicked root name

        public DataSet getParent_name_ofRoot(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                return ncmdbObject.ExecuteDataSet("USP_GetRootMenuName");
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

        #region Function to get right side external link menu

        //////public DataSet get_RightSide_External_Menu(LinkOB lnkObject)
        //////{
        //////    //try
        //////    //{
        //////    //    ncmdbObject.Parameters.Add(new SqlParameter("@lang_id",lnkObject.LangId));
        //////    //    ncmdbObject.Parameters.Add(new SqlParameter("@position_id", lnkObject.PositionId));
        //////    //    ncmdbObject.Parameters.Add(new SqlParameter("@module_id", lnkObject.ModuleId));
        //////    //    ncmdbObject.Parameters.Add(new SqlParameter("@linktype_id", lnkObject.LinkTypeId));
        //////    //}
        //////    //catch
        //////    //{
        //////    //    throw;
        //////    //}
        //////    //finally
        //////    //{
        //////    //    ncmdbObject.Dispose();
        //////    //}
        //////}

        #endregion

        #region Function to bind banner on home page

        public DataSet get_Banner(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                ncmdbObject.Parameters.Add(new SqlParameter("@module_id", lnkObject.ModuleId));

                return ncmdbObject.ExecuteDataSet("USP_get_Banner");
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

        #region Function to get Latest News

        public DataSet getLatestNews(LinkOB lnkObject)
        {
            try
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                ncmdbObject.Parameters.Add(new SqlParameter("@module_id", lnkObject.ModuleId));
                ncmdbObject.Parameters.Add(new SqlParameter("@linkid", lnkObject.linkID));

                return ncmdbObject.ExecuteDataSet("USP_get_latestNews");
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

        #region Function to get ALL Latest News

        public DataSet getLatestNewsAll(LinkOB lnkObject, out int catValue)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RecordCount", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                ncmdbObject.Parameters.Add(param[0]);

                ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
                ncmdbObject.Parameters.Add(new SqlParameter("@module_id", lnkObject.ModuleId));
                ncmdbObject.Parameters.Add(new SqlParameter("@linkid", lnkObject.linkID));
                ncmdbObject.Parameters.Add(new SqlParameter("@PageIndex", 1));
                ncmdbObject.Parameters.Add(new SqlParameter("@PageSize", 10));
                p_Val.dSet = ncmdbObject.ExecuteDataSet("USP_get_latestNewsAll");
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

        //End
    //End

    //Area for all the functions to insert

    #region function to insert top menu in links temp table

    public int insert_Top_Menu(LinkOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
           // ncmdbObject.CommandText = "ASP_InsertUpdateDelete_Link_Tmp";
            ncmdbObject.CommandText = "ASP_Tmp_link_Insert_Update";
            ncmdbObject.Parameters.Add(new SqlParameter("@ActionType", lnkObject.ActionType));
            ncmdbObject.Parameters.Add(new SqlParameter("@Lang_Id", lnkObject.LangId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Parent_Id", lnkObject.LinkParentId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Order", lnkObject.LinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Level", lnkObject.LinkLevel));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Type_Id", lnkObject.LinkTypeId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_Id", lnkObject.linkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Temp_Link_Id", lnkObject.TempLinkId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Browser_Title", lnkObject.BrowserTitle));
            ncmdbObject.Parameters.Add(new SqlParameter("@Page_Title", lnkObject.PageTitle));
            ncmdbObject.Parameters.Add(new SqlParameter("@Meta_Keywords", lnkObject.MetaKeywords));
            ncmdbObject.Parameters.Add(new SqlParameter("@Mate_Description", lnkObject.MateDescription));
            ncmdbObject.Parameters.Add(new SqlParameter("@Module_Id", lnkObject.ModuleId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Name", lnkObject.NAME));
            ncmdbObject.Parameters.Add(new SqlParameter("@Position_Id", lnkObject.PositionId));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status_Id", lnkObject.StatusId));
  
            //ncmdbObject.Parameters.Add(new SqlParameter("@DateInserted", lnkObject.in));
            ncmdbObject.Parameters.Add(new SqlParameter("@UrlName", lnkObject.UrlName));
            ncmdbObject.Parameters.Add(new SqlParameter("@Start_Date", lnkObject.StartDate));
            ncmdbObject.Parameters.Add(new SqlParameter("@End_Date", lnkObject.EndDate));
           // ncmdbObject.Parameters.Add(new SqlParameter("@IpAddress",lnkObject.IpAddress));
            ncmdbObject.Parameters.Add(new SqlParameter("@Last_Updated_By",lnkObject.LastUpdatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@IpAddress", lnkObject.IpAddress));
            ncmdbObject.Parameters.Add(new SqlParameter("@Inserted_By", lnkObject.InsertedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@SHow_IN_Whatsnew", lnkObject.WhatsnewCheck));
            ncmdbObject.Parameters.Add(new SqlParameter("@Image_Name", lnkObject.ImageName));


            ncmdbObject.Parameters.Add(new SqlParameter("@Ismodule", lnkObject.Ismodule));
            ncmdbObject.Parameters.Add(new SqlParameter("@Link_ModuleID", lnkObject.Linked_ModuleID));
          //  ncmdbObject.Parameters.Add(new SqlParameter("@User_Id", lnkObject.InsertedBy));
            if (lnkObject.LinkTypeId == 3)
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Url", lnkObject.URL));
            }
            else if (lnkObject.LinkTypeId == 1)
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Details", lnkObject.details));
            }
            else if (lnkObject.LinkTypeId == 2)
            {
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

    public int insert_Top_Menu_in_Web(LinkOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.Parameters.Add(new SqlParameter("@TempLinkId", lnkObject.TempLinkId));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedBY", lnkObject.LastUpdatedBy));
           // ncmdbObject.Parameters.Add(new SqlParameter("@IpAddress", lnkObject.IpAddress));
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDelete_Link");
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


    #region function to insert top menu in links web table

    public int change_order_Menu_in_Web(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Up_link_order", lnkObject.UPLinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@checked_order", lnkObject.ORGLinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
            int i= ncmdbObject.ExecuteNonQuery("change_order ");
            return i;
            //ncmdbObject.Parameters.Add(new SqlParameter("@linkid ", lnkObject.linkID));
            //p_Val.dSet = ncmdbObject.ExecuteDataSet("temp_i");
            ////return p_Val.dSet;
          
            //return p_Val.Result;
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

    public int change_order_Menu_in_Web_down(LinkOB lnkObject)
    {
        try
        {
            if (lnkObject.LinkParentId!=0)
            {
            ncmdbObject.Parameters.Add(new SqlParameter("@Down_link_order", lnkObject.DOWNLinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@checked_order", lnkObject.ORGLinkOrder));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
          p_Val.Result=   ncmdbObject.ExecuteNonQuery("change_order_down");
            }
            if (lnkObject.LinkParentId == 0)
            {
                ncmdbObject.Parameters.Add(new SqlParameter("@Down_link_order", lnkObject.DOWNLinkOrder));
                ncmdbObject.Parameters.Add(new SqlParameter("@checked_order", lnkObject.ORGLinkOrder));
                ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
                ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
            p_Val.Result=      ncmdbObject.ExecuteNonQuery("change_order_down_rootmenu");
            }

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

    //Area for all the functions to delete

    #region function to delete pending or approved record

    public int Delete_Pending_Approved_Record(LinkOB lnkObject)
    {
        try
        {
            SqlParameter param = new SqlParameter();
            ncmdbObject.AddParameter("@link_id", lnkObject.link_id);
            ncmdbObject.AddParameter("@TempLinkId", lnkObject.TempLinkId);
            ncmdbObject.AddParameter("@StatusId", lnkObject.StatusId);
            //  ncmdbObject.AddParameter("@IpAddress", lnkObject.IpAddress);
            ncmdbObject.AddParameter("@UpdatedBy", lnkObject.LastUpdatedBy);
            param = new SqlParameter("@recordCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param);
            ncmdbObject.ExecuteNonQuery("ASP_Delete_Link_Tmp_Link");


            p_Val.Result = Convert.ToInt16(param.Value);
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


    //#region Function to get submenu of root menu By kumar Gaurav

    //public DataSet get_Frontside_Submenu_of_RootMenu(LinkOB lnkObject)
    //{
    //    try
    //    {
    //        ncmdbObject.Parameters.Add(new SqlParameter("@link_parent_id", lnkObject.LinkParentId));
    //        ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
    //        return ncmdbObject.ExecuteDataSet("USP_Get_Child_of_Root_Menu");
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        ncmdbObject.Dispose();
    //    }
    //}
    //#endregion

    #region Function to get Last updated date for sitemap

    public string getLastUpdatedDateSiteMap(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.AddParameter("@langid", lnkObject.LangId);
            p_Val.str = ncmdbObject.ExecuteScalar("usp_GetLastUpdatedSiteMap").ToString();
            return p_Val.str;
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



    //Area of Ombudsman

    #region Function to get ROOT MENU FOR OMBUDSMAN

    public DataSet get_Frontside_RootMenu_Ombudsman(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@moduleid", lnkObject.ModuleId));
            ncmdbObject.Parameters.Add(new SqlParameter("@linkparentid", lnkObject.LinkParentId));
            ncmdbObject.Parameters.Add(new SqlParameter("@positionid", lnkObject.PositionId));
            ncmdbObject.Parameters.Add(new SqlParameter("@langid", lnkObject.LangId));
            return ncmdbObject.ExecuteDataSet("USP_Get_Root_Menu_Ombudsman");
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



    public DataSet Proc_Select_Left_For_MenuClick_Footer(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
            ncmdbObject.Parameters.Add(new SqlParameter("@ModuleId", lnkObject.ModuleId));
            ncmdbObject.Parameters.Add(new SqlParameter("@statusid", lnkObject.StatusId));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
            ncmdbObject.Parameters.Add(new SqlParameter("@PositionId", lnkObject.PositionId));
            p_Val.dSet = ncmdbObject.ExecuteDataSet("Proc_Select_Left_For_MenuClick_Footer");
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




    public DataSet Proc_Select_Left_For_MenuClick(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@lang_id", lnkObject.LangId));
            ncmdbObject.Parameters.Add(new SqlParameter("@ModuleId", lnkObject.ModuleId));
            ncmdbObject.Parameters.Add(new SqlParameter("@statusid", lnkObject.StatusId));
            ncmdbObject.Parameters.Add(new SqlParameter("@link_id", lnkObject.linkID));
            p_Val.dSet = ncmdbObject.ExecuteDataSet("Proc_Select_Left_For_MenuClick");
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

    #region Mul_Delete

    public int Mul_Delete(LinkOB lnkObject)
    {
        try
        {

            ncmdbObject.AddParameter("@Status", lnkObject.status);
            ncmdbObject.AddParameter("@News_ID", lnkObject.RefNo);

            ncmdbObject.AddParameter("@APPRV_STATUS", lnkObject.ApproveStatus);
            ncmdbObject.AddParameter("@ModuleID", lnkObject.ModuleId);
            int i = ncmdbObject.ExecuteNonQuery("Menu_Multiple_Delete ");
            return i;


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

    public DataSet GetSubmenu(LinkOB lnkObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ParentID", lnkObject.LinkParentId));
            
            ncmdbObject.Parameters.Add(new SqlParameter("@statusid", lnkObject.StatusId));
            
            p_Val.dSet = ncmdbObject.ExecuteDataSet("GetSubmenu");
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


    #region function to delete pending or approved record

    public int Restore_Link(LinkOB lnkObject)
    {
        try
        {
            SqlParameter param = new SqlParameter();
            ncmdbObject.AddParameter("@linkId", lnkObject.TempLinkId);
            // ncmdbObject.AddParameter("@StatusId", lnkObject.StatusId);

            ncmdbObject.AddParameter("@UpdatedBy", lnkObject.LastUpdatedBy);
            param = new SqlParameter("@recordCount", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param);
            ncmdbObject.ExecuteNonQuery("ASP_Restore_link");


            p_Val.Result = Convert.ToInt16(param.Value);
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
}

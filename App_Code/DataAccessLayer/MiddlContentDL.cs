using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MiddlContentDL
/// </summary>
public class MiddlContentDL
{
    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
    int recordCount = 0;

    #endregion
	public MiddlContentDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Fucntion to insert and update link temp records

    public int insertMiddlContent(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", lnkObject.ActionType);

            ncmdbObject.AddParameter("@Name", lnkObject.Name);
            ncmdbObject.AddParameter("@AltTag", lnkObject.AltTag);
            ncmdbObject.AddParameter("@Image_Name", lnkObject.ImageName);
            ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangID);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@NameReg", lnkObject.NameRegional);
            ncmdbObject.AddParameter("@AltReg", lnkObject.AltTagReg);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@WebsiteId", lnkObject.Websiteid);
            //start naren 22march2018
            ncmdbObject.AddParameter("@Details", lnkObject.details);
            ncmdbObject.AddParameter("@SmallDetails", lnkObject.SmallDetails);
            //end naren 22march2018
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("spLinksInsertUpdateMiddleContent");
            recordCount = Convert.ToInt32(param[0].Value);
            return recordCount;
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
    #region Function to display all Middle content data

    public DataSet GetMiddleContentData(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@status_id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@Websiteid", lnkObject.Websiteid);
            return ncmdbObject.ExecuteDataSet("spDisplayAllMiddleContent");
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
    #region Function to display Middlecontent in edit mode

    public DataSet DisplayMiddleContent_AtEdit(ContentOB lnkObject)
    {
        try
        {

            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@TempLink_Id", lnkObject.TempLinkID);
            return ncmdbObject.ExecuteDataSet("SpGetMiddleContentDataForEdit");

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
    #region Function to update MiddleContent data

    public int UpdateMiddleContentData(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", lnkObject.ActionType);
            ncmdbObject.AddParameter("@TempLink_Id", lnkObject.TempLinkID);
            ncmdbObject.AddParameter("@Status_Id", lnkObject.StatusID);
            ncmdbObject.AddParameter("@Name", lnkObject.Name);
            ncmdbObject.AddParameter("@Image_Name", lnkObject.ImageName);
            ncmdbObject.AddParameter("@StateID", lnkObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", lnkObject.TigerReserveid);
            ncmdbObject.AddParameter("@AltTag", lnkObject.AltTag);
            ncmdbObject.AddParameter("@Link_Id", lnkObject.LinkID);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@NameReg", lnkObject.NameRegional);
            ncmdbObject.AddParameter("@AltReg", lnkObject.AltTagReg);
            ncmdbObject.AddParameter("@WebsiteId", lnkObject.Websiteid);
            //start naren 22march2018
            ncmdbObject.AddParameter("@Details", lnkObject.details);
            ncmdbObject.AddParameter("@SmallDetails", lnkObject.SmallDetails);
            //end naren 22march2018
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("spLinksInsertUpdateMiddleContent");
            recordCount = Convert.ToInt16(param[0].Value);
            return recordCount;
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
    #region function delete middle content
    public int DelMiddlContent(ContentOB lnkObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];

            ncmdbObject.AddParameter("@Temp_Link_Id", lnkObject.TempLinkID);
            ncmdbObject.AddParameter("@Link_Id", lnkObject.LinkID);
            ncmdbObject.AddParameter("@StatusID", lnkObject.StatusID);
            
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.ExecuteNonQuery("spDeleteMiddleContent");
            recordCount = Convert.ToInt32(param[0].Value);
            return recordCount;
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
    #region function bindTopMiddleLowerOnHomePage
    public DataSet bindTopMiddleLowerOnHomePage(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@WebsiteID", lnkObject.Websiteid);
           
            return ncmdbObject.ExecuteDataSet("spBindTopMiddleLowerItem");
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
    public DataSet bindTopMiddleLowerOnHomePageTreserve(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@WebsiteID", lnkObject.Websiteid);
            ncmdbObject.AddParameter("@TigerReserveid", lnkObject.TigerReserveid);

            return ncmdbObject.ExecuteDataSet("spThumnailTigerReserve");
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

    #region function bindTopMiddleLowerOnHomePage specific details
    public DataSet bindTopMiddleLowerOnHomePagespecific(ContentOB lnkObject)
    {
        try
        {
            // ncmdbObject.AddParameter("@Lang_Id", lnkObject.LangId);
            ncmdbObject.AddParameter("@Module_Id", lnkObject.ModuleID);
            ncmdbObject.AddParameter("@WebsiteID", lnkObject.Websiteid);
            ncmdbObject.AddParameter("@Link_Id", lnkObject.LinkID);

            return ncmdbObject.ExecuteDataSet("spBindTopMiddleLowerItemSpecific");
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
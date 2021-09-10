using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for PhotoGalleryDL
/// </summary>
public class PhotoGalleryDL
{
    #region Data declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_var = new Project_Variables();
    Miscelleneous_BL miscellBL=new Miscelleneous_BL();
    public int counter;

    #endregion
    public PhotoGalleryDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Function to insert-update Photo category into temp table

    public int InsertUpdatePhotoCategory(PhotoGalleryOB photoGalleryObject)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@ActionType", photoGalleryObject.ActionType);
            ncmdbObject.AddParameter("@TempMCategoryId", photoGalleryObject.TempCategoryID);
            ncmdbObject.AddParameter("@MCategoryId", photoGalleryObject.CategoryID);
            ncmdbObject.AddParameter("@CatName", photoGalleryObject.CategoryName);
            ncmdbObject.AddParameter("@CatNameRegLng", photoGalleryObject.CategoryNameHindi);
            ncmdbObject.AddParameter("@StatusId", photoGalleryObject.StatusID);

            ncmdbObject.AddParameter("@StateID", photoGalleryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoGalleryObject.TigerReserveID);

            ncmdbObject.AddParameter("@UserId", photoGalleryObject.UserID);
            ncmdbObject.AddParameter("@IpAddress", photoGalleryObject.IPAddress);
            
            param[0] = new SqlParameter("@recordCount",SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDeleteCategoryTmp");
            p_var.Result = Convert.ToInt16(param[0].Value);
            return p_var.Result;

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

    #region Function to display all category

    public DataSet DisplayPhotoCategories(PhotoGalleryOB photoCategoryObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
           
            ncmdbObject.AddParameter("@ModuleId", photoCategoryObject.ModuleId);
            ncmdbObject.AddParameter("@TempMCategoryId", photoCategoryObject.TempMCategoryID);
            ncmdbObject.AddParameter("@PageIndex", photoCategoryObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", photoCategoryObject.PageSize);
            ncmdbObject.AddParameter("@statusid", photoCategoryObject.StatusID);
            ncmdbObject.AddParameter("@StateID", photoCategoryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoCategoryObject.TigerReserveID);
            p_var.dSet = ncmdbObject.ExecuteDataSet("sp_GetPhotoCategoryTmp");
            Catvalue = Convert.ToInt16(param[0].Value);

            return p_var.dSet;

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

    #region Function to display all category for updation

    public DataSet DisplayPhotoCategoriesinEdit(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            
            ncmdbObject.AddParameter("@TempMCategoryId", photoCategoryObject.TempMCategoryID);
            ncmdbObject.AddParameter("@statusid", photoCategoryObject.StatusID);
            p_var.dSet = ncmdbObject.ExecuteDataSet("ASP_GetPhotoCategoryEdit");
            return p_var.dSet;

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

    #region Function to insert photo category in final table

    public int InsertPhotoCategoryInWeb(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@TempMCategoryId", photoCategoryObject.TempMCategoryID);
            ncmdbObject.AddParameter("@UserID", photoCategoryObject.UserID);
            ncmdbObject.AddParameter("@IpAddress", photoCategoryObject.IPAddress);

            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDelete_Category");
            p_var.Result = Convert.ToInt16(param[0].Value);
            return p_var.Result;
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

    #region Function to get photo category

    public DataSet getPhotoCategoryName(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", photoCategoryObject.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveID", photoCategoryObject.TigerReserveID));
            return ncmdbObject.ExecuteDataSet("ASP_Get_Photo_Category_Name");
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

    #region Function to insert photo in photo gallery

    public int InsertUpdateDeletePhotoGallery(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@actionType", photoCategoryObject.ActionType);
            ncmdbObject.AddParameter("@CategoryId", photoCategoryObject.CategoryID);
            ncmdbObject.AddParameter("@StateID", photoCategoryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoCategoryObject.TigerReserveID);
            if (!string.IsNullOrEmpty(photoCategoryObject.Title))
            {
                ncmdbObject.AddParameter("@Title", miscellBL.strip_dangerous_tags(photoCategoryObject.Title));
            }
            else
            {
                ncmdbObject.AddParameter("@Title", photoCategoryObject.Title);
            }
            ncmdbObject.AddParameter("@TitleRegLng", photoCategoryObject.TitleRegLng);
            if (!string.IsNullOrEmpty(photoCategoryObject.Description))
            {
                ncmdbObject.AddParameter("@Description", miscellBL.strip_dangerous_tags(photoCategoryObject.Description));
            }
            else
            {
                ncmdbObject.AddParameter("@Description", photoCategoryObject.Description);
            }
            ncmdbObject.AddParameter("@DescriptionRegLng", photoCategoryObject.descriptionRegLng);
            if (!string.IsNullOrEmpty(photoCategoryObject.AltTag))
            {
                ncmdbObject.AddParameter("@AltTag", miscellBL.strip_dangerous_tags(photoCategoryObject.AltTag));
            }
            else
            {
                ncmdbObject.AddParameter("@AltTag", photoCategoryObject.AltTag);
            }
            ncmdbObject.AddParameter("@AltTagRegLng ", photoCategoryObject.AltTagRegLng);
            ncmdbObject.AddParameter("@ImageName", photoCategoryObject.ImageName);
            ncmdbObject.AddParameter("@StatusId", photoCategoryObject.StatusID);
            ncmdbObject.AddParameter("@StartDate", photoCategoryObject.StartDate);
            ncmdbObject.AddParameter("@EndDate", photoCategoryObject.EndDate);
            ncmdbObject.AddParameter("@UserId", photoCategoryObject.UserID);
            ncmdbObject.AddParameter("@MediaTypeId", photoCategoryObject.MediaTypeId);
            ncmdbObject.AddParameter("@TempGalleryId", photoCategoryObject.TempGalleryID);
            ncmdbObject.AddParameter("@GalleryId", photoCategoryObject.GalleryID);
            ncmdbObject.AddParameter("@IpAddress", photoCategoryObject.IPAddress);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDelete_Gallery_Tmp");
            p_var.Result = Convert.ToInt16(param[0].Value);
            return p_var.Result;

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

    #region Funciton to display all photos

    public DataSet PhotoGalleryDisplay(PhotoGalleryOB photoCategoryObject, out int Catvalue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int, 4);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.AddParameter("@TempGalleryId", photoCategoryObject.TempGalleryID);
            ncmdbObject.AddParameter("@CategoryId", photoCategoryObject.CategoryID);
            ncmdbObject.AddParameter("@StateID", photoCategoryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoCategoryObject.TigerReserveID);
            ncmdbObject.AddParameter("@PageIndex", photoCategoryObject.PageIndex);
            ncmdbObject.AddParameter("@PageSize", photoCategoryObject.PageSize);
            ncmdbObject.AddParameter("@StatusID", photoCategoryObject.StatusID);
            p_var.dSet = ncmdbObject.ExecuteDataSet("ASP_Get_Gallery_Tmp");
            Catvalue = Convert.ToInt16(param[0].Value);
            return p_var.dSet;
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

    #region Function to insert photo in final table

    public int InsertUpdatePhotoGalleryWeb(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            ncmdbObject.AddParameter("@TempGalleryId", photoCategoryObject.TempGalleryID);
            ncmdbObject.AddParameter("@UserID", photoCategoryObject.UserID);
            ncmdbObject.AddParameter("@IpAddress", photoCategoryObject.IPAddress);
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.AddParameter(param[0]);
            ncmdbObject.ExecuteNonQuery("ASP_InsertUpdateDelete_Gallery");
            p_var.Result = Convert.ToInt16(param[0].Value);
            return p_var.Result;
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

    #region Funciton to display all photos for updation

    public DataSet DisplayPhotoGalleryInEdit(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            ncmdbObject.AddParameter("@TempGalleryId", photoGalleryObject.TempGalleryID);
            ncmdbObject.AddParameter("@MCategoryId", photoGalleryObject.MCategoryID);
            ncmdbObject.AddParameter("@StatusID", photoGalleryObject.StatusID);
            return ncmdbObject.ExecuteDataSet("ASP_Get_Gallery_Tmp_Edit");
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

    #region Function to compare category of gallery

    public DataSet PhotoGalleryIDForComparison(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@GalleryId", photoGalleryObject.GalleryID));
            return ncmdbObject.ExecuteDataSet("ASP_PhotoGallery_Id");
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

    #region Function to get photo category
    public DataSet GetPhotoCategoryFront(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            ncmdbObject.AddParameter("@StateID", photoGalleryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoGalleryObject.TigerReserveID);
            ncmdbObject.AddParameter("@LangID", photoGalleryObject.LangID);
            p_var.dSet = ncmdbObject.ExecuteDataSet("USP_GetCategory");
            return p_var.dSet;

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

    #region function to get photo gallery category wise
    public DataSet Get_PhotoGalleryImage(PhotoGalleryOB photoGalleryObject, out int catValue)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.AddParameter("@PageIndex", photoGalleryObject.PageIndex);
            ncmdbObject.AddParameter("@StateID", photoGalleryObject.StateID);
            ncmdbObject.AddParameter("@TigerReserveID", photoGalleryObject.TigerReserveID);
            ncmdbObject.AddParameter("@CategoryID", photoGalleryObject.CategoryID);
            ncmdbObject.AddParameter("@PageSize", photoGalleryObject.PageSize);
            p_var.dSet = ncmdbObject.ExecuteDataSet("usp_GetPhotoGalleryImage");
            catValue = Convert.ToInt16(param[0].Value);
            return p_var.dSet;
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
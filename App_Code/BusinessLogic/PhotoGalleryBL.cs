using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhotoGalleryBL
/// </summary>
public class PhotoGalleryBL
{
    #region Variable declaration zone

    PhotoGalleryDL photoGalleryDL = new PhotoGalleryDL();

    #endregion
    public PhotoGalleryBL()
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
            return photoGalleryDL.InsertUpdatePhotoCategory(photoGalleryObject);

        }
        catch
        {
            throw;
        }
      
    }

    #endregion

    #region Function to display all category

    public DataSet DisplayPhotoCategories(PhotoGalleryOB photoCategoryObject, out int Catvalue)
    {
        try
        {
            return photoGalleryDL.DisplayPhotoCategories(photoCategoryObject, out Catvalue);

        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to display all category for updation

    public DataSet DisplayPhotoCategoriesinEdit(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            return photoGalleryDL.DisplayPhotoCategoriesinEdit(photoCategoryObject);


        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to insert photo category in final table

    public int InsertPhotoCategoryInWeb(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            return photoGalleryDL.InsertPhotoCategoryInWeb(photoCategoryObject);
        }
        catch
        {
            throw;
        }
      
    }

    #endregion

    #region Function to get photo category

    public DataSet getPhotoCategoryName(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            return photoGalleryDL.getPhotoCategoryName(photoCategoryObject);
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to insert photo in photo gallery

    public int InsertUpdateDeletePhotoGallery(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            return photoGalleryDL.InsertUpdateDeletePhotoGallery(photoCategoryObject);

        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Funciton to display all photos

    public DataSet PhotoGalleryDisplay(PhotoGalleryOB photoCategoryObject, out int Catvalue)
    {
        try
        {
            return photoGalleryDL.PhotoGalleryDisplay(photoCategoryObject, out Catvalue);
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to insert photo in final table

    public int InsertUpdatePhotoGalleryWeb(PhotoGalleryOB photoCategoryObject)
    {
        try
        {
            return photoGalleryDL.InsertUpdatePhotoGalleryWeb(photoCategoryObject);
        }
        catch
        {
            throw;
        }
      
    }

    #endregion

    #region Funciton to display all photos for updation

    public DataSet DisplayPhotoGalleryInEdit(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            return photoGalleryDL.DisplayPhotoGalleryInEdit(photoGalleryObject);
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to compare category of gallery

    public DataSet PhotoGalleryIDForComparison(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            return photoGalleryDL.PhotoGalleryIDForComparison(photoGalleryObject);
        }
        catch
        {
            throw;
        }
      
    }


    #endregion

    #region Function to get photo category
    public DataSet GetPhotoCategoryFront(PhotoGalleryOB photoGalleryObject)
    {
        try
        {
            return photoGalleryDL.GetPhotoCategoryFront(photoGalleryObject);

        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region function to get photo gallery category wise
    public DataSet Get_PhotoGalleryImage(PhotoGalleryOB photoGalleryObject, out int catValue)
    {
        try
        {
            return photoGalleryDL.Get_PhotoGalleryImage(photoGalleryObject,out catValue);
        }
        catch
        {
            throw;
        }
    }

    #endregion
}
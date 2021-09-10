using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhotoGalleryOB
/// </summary>
public class PhotoGalleryOB
{
    public PhotoGalleryOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Properties declaration

    public  int? CategoryID {get; set;}

    public int? TempMCategoryID { get; set; }

    public int? OldMCategoryID { get; set; }

    public int? StateID { get; set; }
    public int? TigerReserveID { get; set; }
    public int? UserID { get; set; }

    public int? MediaTypeId { get; set; }
    public int? StatusID { get; set; }
    public int? ActionType { get; set; }
    public int? TempCategoryID { get; set; }
    public int? CategoryTypeID { get; set; }
    public int? LangID { get; set; }
    public int? ModuleId { get; set; }
    public int? MCategoryID { get; set; }
    public int? GalleryID { get; set; }
    public int? PageIndex { get; set; }
    public int? CurrentPage { get; set; }
    public int? PageSize { get; set; }
    public int? Status { get; set; }

    public string CategoryName { get; set; }
    public string CategoryNameHindi { get; set; }
    public string Title { get; set; }
    public string TitleRegLng { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? TempGalleryID { get; set; }
    public int? OldGalleryID { get; set; }
    public string Description { get; set; }
    public string descriptionRegLng { get; set; }
    public string File_name { get; set; }
    public string ImageName { get; set; }
    public string AltTag { get; set; }
    public string AltTagRegLng { get; set; }
    public string IPAddress { get; set; }
    public string VideoPath { get; set; }


    #endregion

}
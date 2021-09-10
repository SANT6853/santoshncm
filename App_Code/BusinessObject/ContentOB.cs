using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContentOB
/// </summary>
public class ContentOB
{
    #region Default constructor zone
    public ContentOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Properties declaration zone

    public int? ActionType { get; set; }
    public int? mapDistrictID { get; set; }
    public int? TempLinkID { get; set; }
    public int? ModuleID { get; set; }
    public int? FeedBackFrom { get; set; }
    public int? FeedBackID { get; set; }
    public int? LinkParentID { get; set; }
    public int? LinkOrder { get; set; }
    public int? LinkLevel { get; set; }
    public int? LinkTypeID { get; set; }
    public int? PositionID { get; set; }
    public int? StateID { get; set; }
    public int? TigerReserveid { get; set; }
    public int? Websiteid { get; set; }
    public int? StatusID { get; set; }
    public int? LinkID { get; set; }
    public int? LangID { get; set; }
    public int? InsertedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
    //naren
    public int? DataOperatorUserID { get; set; }
    public int? TigerReserveID { get; set; }
    public int? Action { get; set; }
    //naren
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public int? UserID { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? RecInsertDate { get; set; }
    public DateTime? RecUpdateDate { get; set; }

    public DateTime? Date_Inserted { get; set; }
    public string TigerReserveName { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string EmailID { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string StateName { get; set; }
    public string UrlName { get; set; }
    public string Url { get; set; }
    public string FileName { get; set; }
    public string PageTitle { get; set; }
    public string BrowserTitle { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaTag { get; set; }
    public string MateDescription { get; set; }
    public string MetaLng { get; set; }
    public string MetaTitle { get; set; }
    public string details { get; set; }
    public string SmallDetails { get; set; }

    public string AltTag { get; set; }

    public string AltTagReg { get; set; }
    public string NameRegional { get; set; }
    public string ImageName { get; set; }

    #endregion
}
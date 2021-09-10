using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelocationSiteOB
/// </summary>
public class RelocationSiteOB
{

    public RelocationSiteOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Property declaration zone

    public int? RelocationAreaId { get; set; }
    public int? StateID { get; set; }
    public int? VillageID { get; set; }
    public int? DistrictID { get; set; }
    public string RelocatedSiteAddress { get; set; }
    public DateTime? date { get; set; }
    public string StateName { get; set; }
    public string DistrictName { get; set; }
    public string GrampanchayatName { get; set; }
    public int? GrampanchayatID { get; set; }
    public string TehshilName { get; set; }
    public int? TehshilID { get; set; }
    public string VillageName { get; set; }
    public string Comment { get; set; }
    public int? TigerReserveID { get; set; }
    public int? UserID { get; set; }
    #endregion
}
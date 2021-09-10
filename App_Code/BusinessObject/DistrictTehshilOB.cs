using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistrictTehshilOB
/// </summary>
public class DistrictTehshilOB
{
    public DistrictTehshilOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int? DistrictID { get; set; }
    public int? ActionType { get; set; }
    public string DistrictName { get; set; }
    public int? StateID { get; set; }
    public string IPAddress { get; set; }

    public int UserID { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }

    public int? TehsilID { get; set; }
    public string TehshilName { get; set; }

    public string Grampanchayatname { get; set; }
    public int? GrampanchayatID { get; set; }
}
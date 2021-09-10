using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NgoOB
/// </summary>
public class NgoOB
{
    public NgoOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ActionType { get; set; }
    public int? NgoID { get; set; }
    public int? NgoIDTemp { get; set; }
    public int? ModuleID { get; set; }
    public int? StateID { get; set; }
    public int? UserID { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public int? StatusID { get; set; }
    public string PhoneAreaCode { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }

    public string NgoName { get; set; }
    public string NgoAddress { get; set; }
    public string WorkDoneByNGO { get; set; }
    public string Remarks { get; set; }
    public string Attachment { get; set; }

    public DateTime? InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string IpAddress { get; set; }
    public int? VillageID { get; set; }
    public int? SchemeID { get; set; }
}
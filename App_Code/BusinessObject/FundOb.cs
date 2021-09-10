using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FundOb
/// </summary>
public class FundOb
{
    public FundOb()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int? FundId { get; set; }
    public string FundDescription { get; set; }
    public decimal Fundamount { get; set; }
    public int? submitedby { get; set; }
    public int? FundStatus { get; set; }
    public int? Villageid { get; set; }
    //naren below 4march 
    public int? Fid { get; set; }
    public int? NtcaUserID { get; set; }
    public string NtcaUserName { get; set; }
    public string FundSanctionStatus { get; set; }
    public int? StateUserID { get; set; }
    public string StateUserName { get; set; }
    public int? TigerReserveUserID { get; set; }
    public string TigerReserveUserName { get; set; }
    public int? StateID { get; set; }
    public string StateName { get; set; }
    public int? TigerReserveID { get; set; }
    public string TigerReserveName { get; set; }
    public int? VillageID { get; set; }
    public string VillageName { get; set; }
    public float? FundAmount { get; set; }
    public string FunDescription { get; set; }
    public int? ProcessingStatusID { get; set; }
    public string ProcessingStatusName { get; set; }
    public int? ActionButtonStatusTigerReserveUser { get; set; }
    public int? ActionButtonStatusStateUser { get; set; }
    public int? CommonGroupQueryID { get; set; }
    public int? ActionButtonStatusNtcaUser { get; set; }
    public DateTime? CreateDate { get; set; }
    public int? CreatedByID { get; set; }
    public string CreatedByUserName { get; set; }
}
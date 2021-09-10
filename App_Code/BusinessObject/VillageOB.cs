using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VillageOB
/// </summary>
public class VillageOB
{
    public VillageOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int? Villageid { get; set; }
    public string Action { get; set; }
    public int? StateID { get; set; }
    public int? TempVillageID { get; set; }
    public int? TigerReserveid { get; set; }
    public string Village_Name { get; set; }
    public decimal? Agriculture_Land { get; set; }
    public string Population { get; set; }
    public decimal? Residential_property { get; set; }
    public int? Total_Standing_Trees { get; set; }
    public int? Total_Livestock { get; set; }
    public string Relocated_from { get; set; }
    public string Relocated_place { get; set; }
    public int? Total_well { get; set; }
    public string Other_Assets { get; set; }
    public string Current_location_Latitude { get; set; }
    public string Current_location_Longitude { get; set; }
    public string location_Latitude_From { get; set; }
    public string location_Longitude_From { get; set; }
    public int? Submitedby { get; set; }
    public DateTime? SubmitedDate { get; set; }
    public int ? LastUpdatedby {get;set;}
    public DateTime ? LastUpdateDate { get; set; }
    public int Pageindex { get; set; }
    public int PageSize { get; set; }

    public int? StatusID { get; set; }

    public int? UserID { get; set; }

    public string IpAddress { get; set; }
    public int? villageID { get; set; }
    public int? GrampanchayatID { get; set; }
    public int? TehshilID { get; set; }
    public int? DistrictID { get; set; }
    public DateTime? DateofSurvey { get; set; }
    public DateTime? DateofConcenment { get; set; }
    public int? LegalStatus { get; set; }
    public  int? RelocationStatus { get; set; }
    public int? AreaType { get; set; }

    public int? NGO_ID { get; set; }
    public decimal? amount { get; set; }
    public string WorkForVillage { get; set; }
    public int NGOAssociatedID { get; set; }
    public int ActionType { get; set; }
    //09may2018
    public int? SubmittedByUserID { get; set; }
    public int? PermissionState { get; set; }
    public int? CmnStateUserID { get; set; }
    public int? CmnTigerReserveUserID { get; set; }
    public int? CmnDataOperatorUserID { get; set; }
    public int? CmnStateID { get; set; }
    public int? CmnDataOperatorTigerReserveID { get; set; }
    public int? CmnVerifyID { get; set; }
    public DateTime? CmnVerifyUpdateDate { get; set; }
    //-
   
    public int? StateUserID { get; set; }
    public int? ReserveUserId { get; set; }
    public int? DfoUserID { get; set; }
}
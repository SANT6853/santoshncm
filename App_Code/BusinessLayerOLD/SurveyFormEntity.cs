using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SurveyFormEntity
/// </summary>
public class SurveyFormEntity
{
    public SurveyFormEntity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //  public int MyProperty { get; set; }
    public int? PreSurveyFormAutoID { get; set; }
    public int? FromVillID { get; set; }
    public string FromVillNm { get; set; }
    public string SurveyType { get; set; }
    public int? ToVillID { get; set; }
    public string ToVillNm { get; set; }
    public int? DfoUserID { get; set; }
    public DateTime? DfoCreatedDate { get; set; }
    public DateTime? DfoUpdatedDate { get; set; }
    public int DifferentUserIDWhenUpdate { get; set; }
    public DateTime? DifferentUpdateDateThatWhoUpdate { get; set; }
    public int ActiveStatus { get; set; }
    public DateTime? TxtDatesurvey { get; set; }
    public string TxtNamesurveyor { get; set; }
    public string TxtDesignationSurveyor { get; set; }
    public int ddlSelectDistrict { get; set; }
    public int ddlselecttehsil { get; set; }
    public int ddlselectgp { get; set; }
    public string RdbPanchayatOffice { get; set; }
    public string TxtRdbPanchayatOffice { get; set; }
    public string RdbAnganwadi { get; set; }
    public string TxtRdbAnganwadi { get; set; }
    public string RdbAllWeatherRoad { get; set; }
    public string TxtRdbAllWeatherRoad { get; set; }
    public string RdbPostOffice { get; set; }
    public string TxtRdbPostOffice { get; set; }
    public string RdbBank { get; set; }
    public string TxtRdbBank { get; set; }
    public string RdbPDSShop { get; set; }
    public string TxtRdbPDSShop { get; set; }
    public string RdbPublicTelephonePCo { get; set; }
    public string TxtRdbPublicTelephonePCo { get; set; }
    public string RdbMobileSignal { get; set; }
    public string TxtRdbMobileSignal { get; set; }
    public string RdbAccessibiliythealthCare { get; set; }
    public string TxtAccessibiliythealthCare { get; set; }
    public string RdbAccessibiliyRoad { get; set; }
    public string TxtAccessibiliyRoad { get; set; }
    public string RdbAccessbilitySchool { get; set; }
    public string TxtAccessbilitySchoolPrimary { get; set; }
    public string TxtAccessbilitySchool_Secondary { get; set; }
    public string TxtAccessbilitySchool_HighSchool { get; set; }
    public string TxtAccessbilitySchool_College { get; set; }
    public string RdbAccessbilityElectrif { get; set; }
    public string TxtAccessbilityElectrif_DurationElectricityVillages { get; set; }
    public string RdbAccessiblityVeterinary { get; set; }
    public string TxtAccessiblityVeterinary { get; set; }
    public string RdbAvenuesEmployment { get; set; }
    public string TxtAvenuesEmployment_Primary { get; set; }
    public string TxtAvenuesEmployment_Secondary { get; set; }
    public string RdbHumanWildlifecon { get; set; }
    public string TxtRdbHumanWildlifecon { get; set; }
    public string RdbAccessFireFodNwfps { get; set; }
    public string TXTAccessFireFodNwfps { get; set; }
    public int? Action { get; set; }
}
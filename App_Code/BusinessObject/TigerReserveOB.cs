using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TigerReserveOB
/// </summary>
public class TigerReserveOB
{
    public TigerReserveOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //conversion schem

    public string SchemeName { get; set; }
    public bool Declaration { get; set; }
    public string LegalStatus { get; set; }
    public string StateCentralType { get; set; }
    public string BenfitExten { get; set; }
    public double AmountSpent { get; set; }
    public int? VillageID { get; set; }
    public int? PostVillageID { get; set; }
    public int? PostStateID { get; set; }
    public int? PostReserveID { get; set; }
    public string sVillageID { get; set; }
    public string CreatedDate { get; set; }
    public string EditedDate { get; set; }
    public int? CreatedUserID { get; set; }
    public int? EditedUserID { get; set; }
    public string SNo { get; set; }
    public int? Statuss { get; set; }
    public int? Action { get; set; }
    //
    public int? TblFromStateToReserveAutoID { get; set; }
    public int? TigerReserveid { get; set; }
    public int? ConversionID { get; set; }
    public string TigerReserveName { get; set; }
    public string TigerReserveNameHindi { get; set; }
    public int? NoofVillages { get; set; }
    public int? StateID { get; set; }
    public int? Dist { get; set; }
    public int? City { get; set; }
    public string TigerReserveMap { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? Status { get; set; }
    public string CoreArea { get; set; }
    public string BufferArea { get; set; }
    public string longitude { get; set; }
    public string latitude { get; set; }
    //----------------
    public int? TblFromDfoToReservePkAutoID { get; set; }
    public int? TblFromReserveToStateAutoID { get; set; }
    public int? TblFromReserveToDfoAutoID { get; set; }
    public int? TblFromDfoToReserveAutoID { get; set; }
    public string TokenId_FirstTimeInsertNoChange { get; set; }
    public string TokenIdSearch { get; set; }
    public int? VillageID_FirstTimeInsertNoChange { get; set; }
    public int? ActionApplyOnRowSetColorDefaultZero { get; set; }
    public int? StatusIDDefault { get; set; }
    public string StatusIDDefault1 { get; set; }
    public double? FromAmount_FirstTimeInsertNoChange { get; set; }
    public double? CommentedApprovedAmount { get; set; }
    public string FromDescription_FirstTimeInsertNoChange { get; set; }
    public string CommentedRemarks { get; set; }
    public int? FromPersonID { get; set; }
    public int? ToPersonID { get; set; }
    public DateTime? FromInsertDate_FirstTimeInsertNoChange { get; set; }
    public DateTime? CommentedDate { get; set; }
    public int? ActiveDefaultOne { get; set; }
    public string FromPersonUserName { get; set; }
    public string ToPersonUserName { get; set; }
    public int? RecordCreatedByUserID { get; set; }
    public double? AcceptedAmount { get; set; }
    public int? ForwardToStateUserID { get; set; }
    public string ForwardToStateUserName { get; set; }
    public string ForwardToNtcaUserName { get; set; }
    public int? TblFromReserveToDfoAutoIDStateForwardedRowID { get; set; }
    //legal form and form1
   // public int? TblFromDfoToReservePkAutoID { get; set; }
    public string contentbody_DdlNotified1_a { get; set; }
    public DateTime? contentbody_TxtDateNotification1_b { get; set; }
    public decimal? contentbody_TxtAreaHa1_c { get; set; }
    public string contentbody_TxtCompliance1_d { get; set; }
    public string contentbody_DdlNotified2_a { get; set; }
    public DateTime? contentbody_TxtDateNotification2_b { get; set; }
    public decimal? contentbody_TxtAreaHa2_c { get; set; }
    public string contentbody_DdlExpertCommittee2_d { get; set; }
    public DateTime? contentbody_TxtDateConstitution2_e { get; set; }
    public string contentbody_DdlConsultationGramSabha2_f { get; set; }
    public string contentbody_TxtNameGramSabha2_g { get; set; }
    public string contentbody_FileUploadMapCTH2_h { get; set; }
    public string contentbody_FileUploadUploadfile2_i { get; set; }
    public string contentbody_FileUploadUploadfile2_j { get; set; }
    public string contentbody_DdlCompleted3_a { get; set; }
    public string contentbody_FileUploadCompleted3_a { get; set; }
    public string contentbody_DdlProvided4_a { get; set; }
    public string contentbody_DdlObtained5_a { get; set; }
    public string contentbody_DdlObtained6_a { get; set; }
    public string contentbody_FileUpload6_a { get; set; }
    public string contentbody_DdlProvided7_a { get; set; }
    public string contentbody_FileUploadProvided7_a { get; set; }
    public string contentbody_DdlConstituted8_a_a { get; set; }
    public string contentbody_FileUpload8_a_a { get; set; }
    public DateTime? contentbody_TxtDateofconstitution8_a_b { get; set; }
    public string contentbody_DdlConstituted8_b_a { get; set; }
    public string contentbody_FileUpload8_b_a { get; set; }
    public DateTime? contentbody_TxtDateofconstitution8_b_b { get; set; }
    public string contentbody_Ddl8_c_a { get; set; }
    public string contentbody_FileUpload8_c_a { get; set; }
    public DateTime? contentbody_TxtDateofconstitution8_c_b { get; set; }
    public string Form1contentbody_RdbCheckItems1_0 { get; set; }
    public string Form1contentbody_TextCheckItems1 { get; set; }
    public string Form1contentbody_FileUploadCheckItems1 { get; set; }
    public string Form1contentbody_RdbCheckItems2_0 { get; set; }
    public string Form1contentbody_TextCheckItems2 { get; set; }
    public string Form1contentbody_FileUploadCheckItems2 { get; set; }
    public string Form1contentbody_RdbCheckItems3_0 { get; set; }
    public string Form1contentbody_TextCheckItems3 { get; set; }
    public string Form1contentbody_FileUploadCheckItems3 { get; set; }
    public string Form1contentbody_RdbCheckItems4_0 { get; set; }
    public string Form1contentbody_TextCheckItems4 { get; set; }
    public string Form1contentbody_FileUploadCheckItems4 { get; set; }
    public string Form1contentbody_RdbCheckItems5_0 { get; set; }
    public string Form1contentbody_TextCheckItems5 { get; set; }
    public string Form1contentbody_FileUploadCheckItems5 { get; set; }
    public string Form1contentbody_RdbCheckItems6_0 { get; set; }
    public string Form1contentbody_TextCheckItems6 { get; set; }
    public string Form1contentbody_FileUploadCheckItems6 { get; set; }
    public DataTable Freeinformedconsent_FileUploadCheckItems5 { get; set; }
    public DataTable Voluntaryconsent_FileUploadCheckItems6 { get; set; }
    public string Form1contentbody_RdbCheckItems7_0 { get; set; }
    public string Form1contentbody_TextCheckItems7 { get; set; }
    public string Form1contentbody_FileUploadCheckItems7 { get; set; }
   // public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserID { get; set; }
    public int? UpdatedByUserID { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? SurveyDate { get; set; }
    public string Surveyor { get; set; }
    public string DesignationSurveyor { get; set; }
    public DataTable NGODetail { get; set; }
    public string RdbAnganwadi { get; set; }
    public string Anganwadi { get; set; }
    public string RdbPanchayatOffice { get; set; }
    public string PanchayatOffice { get; set; }
    public string RdbAllWeatherRoad { get; set; } 
    public string AllWeatherRoad { get; set; }
    public string RdbPostOffice { get; set; }
    public string PostOffice { get; set; }
    public string RdbBank { get; set; }
    public string Bank { get; set; }
    public string RdbPDSShop { get; set; }
    public string  PDSShop { get; set; }
    public string RdbPublicTelephonePCo { get; set; }
    public string PublicTelephonePCo { get; set; }
    public string RdbMobileSignal { get; set; }
    public string MobileSignal { get; set; }
    public string RdbAccessibiliythealthCare { get; set; }
    public string AccessibiliythealthCare { get; set; }
    public string RdbAccessibiliyRoad { get; set; }
    public string AccessibiliyRoad { get; set; }
    public string RdbAccessbilitySchool { get; set; }
    public string Primary { get; set; }
    public string Secondary { get; set; }
    public string HighSchool { get; set; }
    public string College { get; set; }
    public string RdbAccessbilityElectrif { get; set; }
    public string AccessbilityElectrif { get; set; }
    public string RdbAccessiblityVeterinary { get; set; }
    public string AccessiblityVeterinary { get; set; }
    public string RdbAvenuesEmployment { get; set; }
    public string EmploymentPrimary { get; set; }
    public string EmploymentSecondary { get; set; }
    public string RdbHumanWildlifecon { get; set; }
    public string HumanWildlifecon { get; set; }
    public string RdbAccessFireFodNwfps { get; set; }
    public string AccessFireFodNwfps { get; set; }
    public string postVillageName { get; set; }
    public int flag { get; set; }



}
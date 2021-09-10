using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TigerReserveDL
/// </summary>
public class TigerReserveDL
{
    //Area for all the variables declaration

    #region variable declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();

    #endregion

    //End



    //Area for all the functions to get data
    public DataSet GetDist(int Stateid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", Stateid));
            return ncmdbObject.ExecuteDataSet("Get_Dist_ByState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetCity(int Distid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Distid", Distid));
            return ncmdbObject.ExecuteDataSet("Get_City_ByDist");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int Insert_UpdateTigerReserver(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", _tigerOb.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _tigerOb.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveNameHindi", _tigerOb.TigerReserveNameHindi));
            ncmdbObject.Parameters.Add(new SqlParameter("@NoofVillages", _tigerOb.NoofVillages));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _tigerOb.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Dist", _tigerOb.Dist));
            ncmdbObject.Parameters.Add(new SqlParameter("@City", _tigerOb.City));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveMap", _tigerOb.TigerReserveMap));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedBy", _tigerOb.CreatedBy));
            ncmdbObject.Parameters.Add(new SqlParameter("@CoreArea", _tigerOb.CoreArea));
            ncmdbObject.Parameters.Add(new SqlParameter("@BufferArea", _tigerOb.BufferArea));
            ncmdbObject.Parameters.Add(new SqlParameter("@longitude", _tigerOb.longitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@latitude", _tigerOb.latitude));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status", _tigerOb.Status));
            return ncmdbObject.ExecuteNonQuery("InsertUpdateTigerReserve");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertNtcaStateReplyDal(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoIDStateForwardedRowID", _tigerOb.TblFromReserveToDfoAutoIDStateForwardedRowID));
            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@RecordCreatedByUserID", _tigerOb.RecordCreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID_FirstTimeInsertNoChange", _tigerOb.VillageID_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerOb.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromAmount_FirstTimeInsertNoChange", _tigerOb.FromAmount_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromDescription_FirstTimeInsertNoChange", _tigerOb.FromDescription_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerOb.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerOb.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromInsertDate_FirstTimeInsertNoChange", _tigerOb.FromInsertDate_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonUserName", _tigerOb.FromPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonUserName", _tigerOb.ToPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerOb.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));

            return ncmdbObject.ExecuteNonQuery("spFromNtcaToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertDFOtoReserve(TigerReserveOB _tigerOb)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@RecordCreatedByUserID", _tigerOb.RecordCreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID_FirstTimeInsertNoChange", _tigerOb.VillageID_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerOb.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromAmount_FirstTimeInsertNoChange", _tigerOb.FromAmount_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromDescription_FirstTimeInsertNoChange", _tigerOb.FromDescription_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerOb.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerOb.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromInsertDate_FirstTimeInsertNoChange", _tigerOb.FromInsertDate_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonUserName", _tigerOb.FromPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonUserName", _tigerOb.ToPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerOb.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));
            //-------

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);

            ncmdbObject.ExecuteNonQuery("spFromDfoToReserve");
           Int32 PkAutoID = Convert.ToInt32(param[0].Value);
           return PkAutoID;
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int UpdateLegalForm(TigerReserveOB _tigerOb)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@RecordCreatedByUserID", _tigerOb.RecordCreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID_FirstTimeInsertNoChange", _tigerOb.VillageID_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerOb.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromAmount_FirstTimeInsertNoChange", _tigerOb.FromAmount_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromDescription_FirstTimeInsertNoChange", _tigerOb.FromDescription_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerOb.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerOb.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromInsertDate_FirstTimeInsertNoChange", _tigerOb.FromInsertDate_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonUserName", _tigerOb.FromPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonUserName", _tigerOb.ToPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerOb.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));
            //-------

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);

            ncmdbObject.ExecuteNonQuery("spFromDfoToReserve");
            Int32 PkAutoID = Convert.ToInt32(param[0].Value);
            return PkAutoID;
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertLegalFormAndForm1(TigerReserveOB _tigerOb)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@Freeinformed", _tigerOb.Freeinformedconsent_FileUploadCheckItems5);
            var SaleInvoiceDetailParam = new SqlParameter("@Voluntary", _tigerOb.Voluntaryconsent_FileUploadCheckItems6);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            SaleInvoiceDetailParam.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _tigerOb.sVillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@SurveyDate", _tigerOb.SurveyDate));
            ncmdbObject.Parameters.Add(new SqlParameter("@Surveyor", _tigerOb.Surveyor));
            ncmdbObject.Parameters.Add(new SqlParameter("@DesignationSurveyor", _tigerOb.DesignationSurveyor));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReservePkAutoID", _tigerOb.TblFromDfoToReservePkAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlNotified1_a", _tigerOb.contentbody_DdlNotified1_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateNotification1_b", _tigerOb.contentbody_TxtDateNotification1_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtAreaHa1_c", _tigerOb.contentbody_TxtAreaHa1_c));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtCompliance1_d", _tigerOb.contentbody_TxtCompliance1_d));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlNotified2_a", _tigerOb.contentbody_DdlNotified2_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateNotification2_b", _tigerOb.contentbody_TxtDateNotification2_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtAreaHa2_c", _tigerOb.contentbody_TxtAreaHa2_c));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlExpertCommittee2_d", _tigerOb.contentbody_DdlExpertCommittee2_d));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateConstitution2_e", _tigerOb.contentbody_TxtDateConstitution2_e));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConsultationGramSabha2_f", _tigerOb.contentbody_DdlConsultationGramSabha2_f));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtNameGramSabha2_g", _tigerOb.contentbody_TxtNameGramSabha2_g));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadMapCTH2_h", _tigerOb.contentbody_FileUploadMapCTH2_h));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadUploadfile2_i", _tigerOb.contentbody_FileUploadUploadfile2_i));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadUploadfile2_j", _tigerOb.contentbody_FileUploadUploadfile2_j));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlCompleted3_a", _tigerOb.contentbody_DdlCompleted3_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadCompleted3_a", _tigerOb.contentbody_FileUploadCompleted3_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlProvided4_a", _tigerOb.contentbody_DdlProvided4_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlObtained5_a", _tigerOb.contentbody_DdlObtained5_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlObtained6_a", _tigerOb.contentbody_DdlObtained6_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload6_a", _tigerOb.contentbody_FileUpload6_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlProvided7_a", _tigerOb.contentbody_DdlProvided7_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadProvided7_a", _tigerOb.contentbody_FileUploadProvided7_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConstituted8_a_a", _tigerOb.contentbody_DdlConstituted8_a_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_a_a", _tigerOb.contentbody_FileUpload8_a_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_a_b", _tigerOb.contentbody_TxtDateofconstitution8_a_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConstituted8_b_a", _tigerOb.contentbody_DdlConstituted8_b_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_b_a", _tigerOb.contentbody_FileUpload8_b_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_b_b", _tigerOb.contentbody_TxtDateofconstitution8_b_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_Ddl8_c_a", _tigerOb.contentbody_Ddl8_c_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_c_a", _tigerOb.contentbody_FileUpload8_c_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_c_b", _tigerOb.contentbody_TxtDateofconstitution8_c_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems1_0", _tigerOb.Form1contentbody_RdbCheckItems1_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems1", _tigerOb.Form1contentbody_TextCheckItems1));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems1", _tigerOb.Form1contentbody_FileUploadCheckItems1));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems2_0", _tigerOb.Form1contentbody_RdbCheckItems2_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems2", _tigerOb.Form1contentbody_TextCheckItems2));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems2", _tigerOb.Form1contentbody_FileUploadCheckItems2));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems3_0", _tigerOb.Form1contentbody_RdbCheckItems3_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems3", _tigerOb.Form1contentbody_TextCheckItems3));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems3", _tigerOb.Form1contentbody_FileUploadCheckItems3));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems4_0", _tigerOb.Form1contentbody_RdbCheckItems4_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems4", _tigerOb.Form1contentbody_TextCheckItems4));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems4", _tigerOb.Form1contentbody_FileUploadCheckItems4));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems5_0", _tigerOb.Form1contentbody_RdbCheckItems5_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems5", _tigerOb.Form1contentbody_TextCheckItems5));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems5", _tigerOb.Form1contentbody_FileUploadCheckItems5));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems6_0", _tigerOb.Form1contentbody_RdbCheckItems6_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems6", _tigerOb.Form1contentbody_TextCheckItems6));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems6", _tigerOb.Form1contentbody_FileUploadCheckItems6));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems7_0", _tigerOb.Form1contentbody_RdbCheckItems7_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems7", _tigerOb.Form1contentbody_TextCheckItems7));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems7", _tigerOb.Form1contentbody_FileUploadCheckItems7));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedByUserID", _tigerOb.CreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId", _tigerOb.TokenId_FirstTimeInsertNoChange));//pry survey start
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAnganwadi", _tigerOb.RdbAnganwadi));
            ncmdbObject.Parameters.Add(new SqlParameter("@Anganwadi", _tigerOb.Anganwadi));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbPanchayatOffice", _tigerOb.RdbPanchayatOffice));
            ncmdbObject.Parameters.Add(new SqlParameter("@PanchayatOffice", _tigerOb.PanchayatOffice));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAllWeatherRoad", _tigerOb.RdbAllWeatherRoad));
            ncmdbObject.Parameters.Add(new SqlParameter("@AllWeatherRoad", _tigerOb.AllWeatherRoad));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbPostOffice", _tigerOb.RdbPostOffice));
            ncmdbObject.Parameters.Add(new SqlParameter("@PostOffice", _tigerOb.PostOffice));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbBank", _tigerOb.RdbBank));
            ncmdbObject.Parameters.Add(new SqlParameter("@Bank", _tigerOb.Bank));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbPDSShop", _tigerOb.RdbPDSShop));
            ncmdbObject.Parameters.Add(new SqlParameter("@PDSShop", _tigerOb.PDSShop));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbPublicTelephonePCo", _tigerOb.RdbPublicTelephonePCo));
            ncmdbObject.Parameters.Add(new SqlParameter("@PublicTelephonePCo", _tigerOb.PublicTelephonePCo));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbMobileSignal", _tigerOb.RdbMobileSignal));
            ncmdbObject.Parameters.Add(new SqlParameter("@MobileSignal", _tigerOb.MobileSignal));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessibiliythealthCare", _tigerOb.RdbAccessibiliythealthCare));
            ncmdbObject.Parameters.Add(new SqlParameter("@AccessibiliythealthCare", _tigerOb.AccessibiliythealthCare));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessibiliyRoad", _tigerOb.RdbAccessibiliyRoad));
            ncmdbObject.Parameters.Add(new SqlParameter("@AccessibiliyRoad", _tigerOb.AccessibiliyRoad));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessbilitySchool", _tigerOb.RdbAccessbilitySchool));
            ncmdbObject.Parameters.Add(new SqlParameter("@PrimarySchool", _tigerOb.Primary));
            ncmdbObject.Parameters.Add(new SqlParameter("@SecondarySchool", _tigerOb.Secondary));
            ncmdbObject.Parameters.Add(new SqlParameter("@HighSchool", _tigerOb.HighSchool));
            ncmdbObject.Parameters.Add(new SqlParameter("@College", _tigerOb.College));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessbilityElectrif", _tigerOb.RdbAccessbilityElectrif));
            ncmdbObject.Parameters.Add(new SqlParameter("@AccessbilityElectrif", _tigerOb.AccessbilityElectrif));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessiblityVeterinary", _tigerOb.RdbAccessiblityVeterinary));
            ncmdbObject.Parameters.Add(new SqlParameter("@AccessiblityVeterinary", _tigerOb.AccessiblityVeterinary));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAvenuesEmployment", _tigerOb.RdbAvenuesEmployment));
            ncmdbObject.Parameters.Add(new SqlParameter("@EmploymentPrimary", _tigerOb.EmploymentPrimary));
            ncmdbObject.Parameters.Add(new SqlParameter("@EmploymentSecondary", _tigerOb.EmploymentSecondary));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbHumanWildlifecon", _tigerOb.RdbHumanWildlifecon));
            ncmdbObject.Parameters.Add(new SqlParameter("@HumanWildlifecon", _tigerOb.HumanWildlifecon));
            ncmdbObject.Parameters.Add(new SqlParameter("@RdbAccessFireFodNwfps", _tigerOb.RdbAccessFireFodNwfps));
            ncmdbObject.Parameters.Add(new SqlParameter("@AccessFireFodNwfps", _tigerOb.AccessFireFodNwfps));
            ncmdbObject.Parameters.Add(new SqlParameter("@Declaration", _tigerOb.Declaration));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            ncmdbObject.Parameters.Add(SaleInvoiceDetailParam);
            return ncmdbObject.ExecuteNonQuery("SpLegalFormAndForm1");
           
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int UpdateAllLegalFormAndForm1(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReservePkAutoID", _tigerOb.TblFromDfoToReservePkAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlNotified1_a", _tigerOb.contentbody_DdlNotified1_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateNotification1_b", _tigerOb.contentbody_TxtDateNotification1_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtAreaHa1_c", _tigerOb.contentbody_TxtAreaHa1_c));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtCompliance1_d", _tigerOb.contentbody_TxtCompliance1_d));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlNotified2_a", _tigerOb.contentbody_DdlNotified2_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateNotification2_b", _tigerOb.contentbody_TxtDateNotification2_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtAreaHa2_c", _tigerOb.contentbody_TxtAreaHa2_c));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlExpertCommittee2_d", _tigerOb.contentbody_DdlExpertCommittee2_d));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateConstitution2_e", _tigerOb.contentbody_TxtDateConstitution2_e));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConsultationGramSabha2_f", _tigerOb.contentbody_DdlConsultationGramSabha2_f));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtNameGramSabha2_g", _tigerOb.contentbody_TxtNameGramSabha2_g));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadMapCTH2_h", _tigerOb.contentbody_FileUploadMapCTH2_h));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadUploadfile2_i", _tigerOb.contentbody_FileUploadUploadfile2_i));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadUploadfile2_j", _tigerOb.contentbody_FileUploadUploadfile2_j));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlCompleted3_a", _tigerOb.contentbody_DdlCompleted3_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadCompleted3_a", _tigerOb.contentbody_FileUploadCompleted3_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlProvided4_a", _tigerOb.contentbody_DdlProvided4_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlObtained5_a", _tigerOb.contentbody_DdlObtained5_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlObtained6_a", _tigerOb.contentbody_DdlObtained6_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload6_a", _tigerOb.contentbody_FileUpload6_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlProvided7_a", _tigerOb.contentbody_DdlProvided7_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUploadProvided7_a", _tigerOb.contentbody_FileUploadProvided7_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConstituted8_a_a", _tigerOb.contentbody_DdlConstituted8_a_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_a_a", _tigerOb.contentbody_FileUpload8_a_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_a_b", _tigerOb.contentbody_TxtDateofconstitution8_a_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_DdlConstituted8_b_a", _tigerOb.contentbody_DdlConstituted8_b_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_b_a", _tigerOb.contentbody_FileUpload8_b_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_b_b", _tigerOb.contentbody_TxtDateofconstitution8_b_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_Ddl8_c_a", _tigerOb.contentbody_Ddl8_c_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_FileUpload8_c_a", _tigerOb.contentbody_FileUpload8_c_a));
            ncmdbObject.Parameters.Add(new SqlParameter("@contentbody_TxtDateofconstitution8_c_b", _tigerOb.contentbody_TxtDateofconstitution8_c_b));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems1_0", _tigerOb.Form1contentbody_RdbCheckItems1_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems1", _tigerOb.Form1contentbody_TextCheckItems1));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems1", _tigerOb.Form1contentbody_FileUploadCheckItems1));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems2_0", _tigerOb.Form1contentbody_RdbCheckItems2_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems2", _tigerOb.Form1contentbody_TextCheckItems2));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems2", _tigerOb.Form1contentbody_FileUploadCheckItems2));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems3_0", _tigerOb.Form1contentbody_RdbCheckItems3_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems3", _tigerOb.Form1contentbody_TextCheckItems3));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems3", _tigerOb.Form1contentbody_FileUploadCheckItems3));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems4_0", _tigerOb.Form1contentbody_RdbCheckItems4_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems4", _tigerOb.Form1contentbody_TextCheckItems4));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems4", _tigerOb.Form1contentbody_FileUploadCheckItems4));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems5_0", _tigerOb.Form1contentbody_RdbCheckItems5_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems5", _tigerOb.Form1contentbody_TextCheckItems5));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems5", _tigerOb.Form1contentbody_FileUploadCheckItems5));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems6_0", _tigerOb.Form1contentbody_RdbCheckItems6_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems6", _tigerOb.Form1contentbody_TextCheckItems6));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems6", _tigerOb.Form1contentbody_FileUploadCheckItems6));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_RdbCheckItems7_0", _tigerOb.Form1contentbody_RdbCheckItems7_0));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_TextCheckItems7", _tigerOb.Form1contentbody_TextCheckItems7));
            ncmdbObject.Parameters.Add(new SqlParameter("@Form1contentbody_FileUploadCheckItems7", _tigerOb.Form1contentbody_FileUploadCheckItems7));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedByUserID", _tigerOb.UpdatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedDate", _tigerOb.UpdatedDate));
            
            // ncmdbObject.Parameters.Add(new SqlParameter("@UpdatedDate", _tigerOb.UpdatedDate));
            return ncmdbObject.ExecuteNonQuery("spGetLegalFormAndForm1");

        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertStateToNtcaRelpy(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoIDStateForwardedRowID", _tigerOb.TblFromReserveToDfoAutoIDStateForwardedRowID));
            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@RecordCreatedByUserID", _tigerOb.RecordCreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID_FirstTimeInsertNoChange", _tigerOb.VillageID_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerOb.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromAmount_FirstTimeInsertNoChange", _tigerOb.FromAmount_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromDescription_FirstTimeInsertNoChange", _tigerOb.FromDescription_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerOb.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerOb.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromInsertDate_FirstTimeInsertNoChange", _tigerOb.FromInsertDate_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonUserName", _tigerOb.FromPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonUserName", _tigerOb.ToPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerOb.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));

            return ncmdbObject.ExecuteNonQuery("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int UpdateStatusOfResereUser(TigerReserveOB _tigerOb)
    {
        try
        {

            //TblFromReserveToStateAutoID,TblFromReserveToDfoAutoIDStateForwardedRowID
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToStateAutoID", _tigerOb.TblFromReserveToStateAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoIDStateForwardedRowID", _tigerOb.TblFromReserveToDfoAutoIDStateForwardedRowID));
                      
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));

            return ncmdbObject.ExecuteNonQuery("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertReserveToState(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoIDStateForwardedRowID", _tigerOb.TblFromReserveToDfoAutoIDStateForwardedRowID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ForwardToStateUserID", _tigerOb.ForwardToStateUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ForwardToStateUserName", _tigerOb.ForwardToStateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerOb.TblFromReserveToDfoAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ForwardToNtcaUserName", _tigerOb.ForwardToStateUserName));
            //
            ncmdbObject.Parameters.Add(new SqlParameter("@AcceptedAmount", _tigerOb.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@RecordCreatedByUserID", _tigerOb.RecordCreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID_FirstTimeInsertNoChange", _tigerOb.VillageID_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerOb.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromAmount_FirstTimeInsertNoChange", _tigerOb.FromAmount_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromDescription_FirstTimeInsertNoChange", _tigerOb.FromDescription_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerOb.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerOb.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CommentedRemarks", _tigerOb.CommentedRemarks));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromInsertDate_FirstTimeInsertNoChange", _tigerOb.FromInsertDate_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonUserName", _tigerOb.FromPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonUserName", _tigerOb.ToPersonUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", _tigerOb.StatusIDDefault));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerOb.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));

            return ncmdbObject.ExecuteNonQuery("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int BackToStateDeleteRecord(TigerReserveOB _tigerOb)
    {
        try
        {
           // ncmdbObject.Parameters.Add(new SqlParameter("@ForwardToStateUserName", _tigerOb.ForwardToStateUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoIDStateForwardedRowID", _tigerOb.TblFromReserveToDfoAutoIDStateForwardedRowID));
          //  ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToStateAutoID", _tigerOb.TblFromReserveToStateAutoID));
           
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));

            return ncmdbObject.ExecuteNonQuery("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int Insert_UpdateConversionScheme(TigerReserveOB _tigerOb)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ConversionID", _tigerOb.ConversionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@SchemeName", _tigerOb.SchemeName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateCentralType", _tigerOb.StateCentralType));
            ncmdbObject.Parameters.Add(new SqlParameter("@BenfitExten", _tigerOb.BenfitExten));
            ncmdbObject.Parameters.Add(new SqlParameter("@AmountSpent", _tigerOb.AmountSpent));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _tigerOb.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@CreatedUserID", _tigerOb.CreatedUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@EditedUserID", _tigerOb.EditedUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@SNo", _tigerOb.SNo));
          
            return ncmdbObject.ExecuteNonQuery("InsertUpdateConversionScheme");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet Get_TigerReservationList(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Stateid", _tigerob.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Status", _tigerob.Status));
            return ncmdbObject.ExecuteDataSet("Get_TigerReservationList");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet Get_ConvesionSchemList(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@SchemeName", _tigerob.SchemeName));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _tigerob.sVillageID));
            return ncmdbObject.ExecuteDataSet("spGetConversionSchem");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetStateToReserveProcessDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToStateAutoID", _tigerob.TblFromReserveToStateAutoID));
            return ncmdbObject.ExecuteDataSet("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetStateNtcaHistoryDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetNtcaStateProcessDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromNtcaToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetNtcaStateReplyProcessDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromStateToReserveAutoID", _tigerob.TblFromStateToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromNtcaToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetNtcaStatehistoryProcessDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromNtcaToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;
               
            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromNtcaToState");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetLegalFormFrom1(TigerReserveOB _tigerob)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));

            return ncmdbObject.ExecuteDataSet("spGetLegalFormAndForm1");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDalActonRequest(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            return ncmdbObject.ExecuteDataSet("spFromDfoToReserve");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDalReplynew(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            return ncmdbObject.ExecuteDataSet("spFromDfoToReserve");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDalhistory(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);
            return ncmdbObject.ExecuteDataSet("spFromDfoToReserve");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDalNew(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PkAutoID", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ncmdbObject.Parameters.Add(param[0]);

            return ncmdbObject.ExecuteDataSet("spFromDfoToReserve");
           // Int32 PkAutoID = Convert.ToInt32(param[0].Value);
            //return PkAutoID;
           // return ncmdbObject.ExecuteDataSet("spFromDfoToReserve");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetDfoReserveProcessDalReserveFolder(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromToReserveToState");//spFromNtcaToState//spFromDfoToReserve//spFromToReserveToState
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetFromStateToNtcaDal(TigerReserveOB _tigerob)
    {
        try
        {
            string ddval = string.Empty;
            if (_tigerob.StatusIDDefault == 0 || _tigerob.StatusIDDefault == null)
            {
                ddval = null;

            }
            else
            {
                ddval = _tigerob.StatusIDDefault.ToString();
            }
            ncmdbObject.Parameters.Add(new SqlParameter("@ForwardToNtcaUserName", _tigerob.ForwardToNtcaUserName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenId_FirstTimeInsertNoChange", _tigerob.TokenId_FirstTimeInsertNoChange));
            ncmdbObject.Parameters.Add(new SqlParameter("@TokenIdSearch", _tigerob.TokenIdSearch));
            ncmdbObject.Parameters.Add(new SqlParameter("@StatusIDDefault", ddval));
            ncmdbObject.Parameters.Add(new SqlParameter("@FromPersonID", _tigerob.FromPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@ToPersonID", _tigerob.ToPersonID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromDfoToReserveAutoID", _tigerob.TblFromDfoToReserveAutoID));
            ncmdbObject.Parameters.Add(new SqlParameter("@TblFromReserveToDfoAutoID", _tigerob.TblFromReserveToDfoAutoID));
            return ncmdbObject.ExecuteDataSet("spFromToReserveToState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet Get_TigerReservationDetials(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", _tigerob.TigerReserveid));
    
            return ncmdbObject.ExecuteDataSet("Get_TigerReservationDetials");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet CheckDuplicateTigerReserve(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _tigerob.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveNameHindi", _tigerob.TigerReserveNameHindi));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _tigerob.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Dist", _tigerob.Dist));
           
            return ncmdbObject.ExecuteDataSet("spCheckDuplicatTigerReserve");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet CheckTigerReserSingleInStateDistrictDal(TigerReserveOB _tigerob)
    {
        try
        {
           
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _tigerob.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Dist", _tigerob.Dist));

            return ncmdbObject.ExecuteDataSet("CheckTigerReserSingleInStateDistrict");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet updateCheckDuplicateTigerReserve(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveid", _tigerob.TigerReserveid));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveName", _tigerob.TigerReserveName));
            ncmdbObject.Parameters.Add(new SqlParameter("@TigerReserveNameHindi", _tigerob.TigerReserveNameHindi));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateID", _tigerob.StateID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Dist", _tigerob.Dist));

            return ncmdbObject.ExecuteDataSet("spUpdateCheckDuplicatTigerReserve");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet Get_CrudOperation(TigerReserveOB _tigerob)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@ConversionID", _tigerob.ConversionID));
            ncmdbObject.Parameters.Add(new SqlParameter("@SchemeName", _tigerob.SchemeName));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateCentralType", _tigerob.StateCentralType));
            ncmdbObject.Parameters.Add(new SqlParameter("@BenfitExten", _tigerob.BenfitExten));
            ncmdbObject.Parameters.Add(new SqlParameter("@AmountSpent", _tigerob.AmountSpent));
            ncmdbObject.Parameters.Add(new SqlParameter("@EditedUserID", _tigerob.EditedUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Statuss", _tigerob.Statuss));
            ncmdbObject.Parameters.Add(new SqlParameter("@SNo", _tigerob.SNo));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _tigerob.Action));

            return ncmdbObject.ExecuteDataSet("spConversionCrud");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetCheckVillageIDExist(TigerReserveOB _tigerob)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _tigerob.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@StateCentralType", _tigerob.StateCentralType));
            return ncmdbObject.ExecuteDataSet("spCheckVillageiDExistInConversionScheme");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet AutoGenerateSerialNumber(TigerReserveOB _tigerob)
    {
        try
        {

            return ncmdbObject.ExecuteDataSet("spSerialnoConvergence");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public DataSet GetTigerReserverByState(int flag, int Userid)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@flag", flag));
            ncmdbObject.Parameters.Add(new SqlParameter("@Userid", Userid));

            return ncmdbObject.ExecuteDataSet("GetTigerReserverByState");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #region Function for BindState and Village Detail FundManagement 
    public DataSet BindStates(int Vill_ID)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", Vill_ID));
            return ncmdbObject.ExecuteDataSet("sp_GetPreserveStateDetail");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function for BindState and Village Detail FundManagement
    public DataSet BindPostStates(int Vill_ID)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", Vill_ID));
            return ncmdbObject.ExecuteDataSet("sp_GetPostStateDetail");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function for Save NGO Data SaveWorkPerformDetail
    public int SaveNgoDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@NGODetail", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVENGORECORD");
           
        }
        catch
        {
            throw;
        }
       
    }
    #endregion
    #region Function for BindState and Village Detail 
    public int FundManagement(TigerReserveOB _TigerReserveOB)
    {
        try
        {

            ncmdbObject.Parameters.Add(new SqlParameter("@fid", _TigerReserveOB.EditedUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Action", _TigerReserveOB.Action));
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(new SqlParameter("@Amount", _TigerReserveOB.AcceptedAmount));
            ncmdbObject.Parameters.Add(new SqlParameter("@Remarks", _TigerReserveOB.CommentedRemarks));
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEFUNDAMOUNT");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function for Get Fund Amount
    public DataSet GetFund(int Vill_ID)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@FID", Vill_ID));
            return ncmdbObject.ExecuteDataSet("sp_GetFundDetail");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function  Priview Record 
    public DataSet PriviewRecord(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            return ncmdbObject.ExecuteDataSet("sp_GetPrivewDetail");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function  Final Submit
    public int FinalSubmit(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            return ncmdbObject.ExecuteNonQuery("NTCA_FINALSUBMIT");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function for  Prefrom Record
    public DataSet GETPrefromrecord(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", _TigerReserveOB.VillageID));
            return ncmdbObject.ExecuteDataSet("sp_GetPrefromDetail");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
    #region Function for Save WorkPerformDetail 
    public int SaveWorkPerformDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@workperform", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEWORKPERFORM");

        }
        catch
        {
            throw;
        }

    }
    #endregion

    #region Function for Save Conversion Scheme
    public int SaveConversionScheme(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@ConversionScheme", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SaveConversionScheme");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for Save NGO Data SaveWorkPerformDetail
    public int SavePostNgoDetail(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordCount", SqlDbType.NVarChar, 50);
            param[0].Direction = ParameterDirection.Output;
            var ApplicantRecordDetail = new SqlParameter("@PostNGODetail", _TigerReserveOB.NGODetail);
            ApplicantRecordDetail.SqlDbType = SqlDbType.Structured;
            ncmdbObject.Parameters.Add(param[0]);
            ncmdbObject.Parameters.Add(new SqlParameter("@VillageID", _TigerReserveOB.VillageID));
            ncmdbObject.Parameters.Add(new SqlParameter("@UserID", _TigerReserveOB.CreatedByUserID));
            ncmdbObject.Parameters.Add(ApplicantRecordDetail);
            return ncmdbObject.ExecuteNonQuery("NTCA_SAVEPOSTNGORECORD");

        }
        catch
        {
            throw;
        }

    }
    #endregion
    #region Function for BindState and Village Detail FundManagement
    public DataSet BindPreStates(int Vill_ID)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Vill_ID", Vill_ID));
            return ncmdbObject.ExecuteDataSet("sp_BindPreStates");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion
}
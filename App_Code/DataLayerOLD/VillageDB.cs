using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NCM.DAL;
using System.Data.SqlClient;
/// <summary>
/// Summary description for VillageDB
/// </summary>
public class VillageDB
{
    int i = 0;
    NCMdbAccess ObjDB = new NCMdbAccess();
    public DataSet GenerateCodeForVillageDB()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Generate_Code_For_Village");
    }
    public DataSet Proc_DisplayFamilyByVillage(string v_id)
    {
        ObjDB.AddParameter("@VILL_ID", v_id);
        return ObjDB.ExecuteDataSet("Proc_DisplayFamilyByVillage");

    }

    public DataSet FillStatesDB()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_States_District_Reserve");
    }
    public bool AddVillageDB(VillageEntity VillEntity_Obj, StateEntity State_Entity, DistrictEntity Dist_Ent_Obj, Reserve_Entity RSVREntity_Obj, Tehsil_Entity TH_EN_Obj, Grampanchayat_Entity GP_EN_Obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;

            ObjDB.AddParameter("@UserID", VillEntity_Obj.UserID);
            ObjDB.AddParameter("@VILL_CD", VillEntity_Obj._VILL_CD);
            ObjDB.AddParameter("@VILL_NM", VillEntity_Obj._VILL_NM);
            ObjDB.AddParameter("@VILL_POPU", VillEntity_Obj._VILL_POPU);
            ObjDB.AddParameter("@VILL_TOT_LND_AREA", VillEntity_Obj._VILL_TOT_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_AGRI_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_NON_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_ID", RSVREntity_Obj._RSRV_ID);
            ObjDB.AddParameter("@VILL_LGL_STAT", VillEntity_Obj._VILL_LGL_STAT);
            ObjDB.AddParameter("@VILL_NO_FM", VillEntity_Obj._VILL_NO_FM);
            ObjDB.AddParameter("@VILL_NO_LIV_STOK", VillEntity_Obj._VILL_NO_LIV_STOK);
            ObjDB.AddParameter("@ST_ID", State_Entity._ST_ID);
            ObjDB.AddParameter("@DT_ID", Dist_Ent_Obj._DT_ID);
            ObjDB.AddParameter("@ST_VILL_CD", VillEntity_Obj._ST_VILL_CD);
            ObjDB.AddParameter("@VILL_STAT", VillEntity_Obj._VILL_STAT);
            ObjDB.AddParameter("@TH_ID", TH_EN_Obj._TH_ID);
            ObjDB.AddParameter("@GP_ID", GP_EN_Obj._GP_ID);

            ObjDB.AddParameter("@VILL_MALE", VillEntity_Obj._VILL_MALE);
            ObjDB.AddParameter("@VILL_FEMALE", VillEntity_Obj._VILL_FEMALE);
            ObjDB.AddParameter("@VILL_OTHER_LND_AREA", VillEntity_Obj._VILL_OTHER_LND_AREA);
            //ObjDB.AddParameter("@VILL_CUT_DT", VillEntity_Obj._VILL_CUT_DT);
            ObjDB.AddParameter("@VILL_SURVEY_DT", VillEntity_Obj._VILL_SURVEY_DT);
            ObjDB.AddParameter("@COMMENTS", VillEntity_Obj._COMMENT);

            ObjDB.AddParameter("@VILL_LNG1", VillEntity_Obj._VILL_LNG1);
            ObjDB.AddParameter("@VILL_LNG2", VillEntity_Obj._VILL_LNG2);
            ObjDB.AddParameter("@VILL_LNG3", VillEntity_Obj._VILL_LNG3);
            ObjDB.AddParameter("@VILL_LNG4", VillEntity_Obj._VILL_LNG4);
            ObjDB.AddParameter("@VILL_LONG1", VillEntity_Obj._VILL_LONG1);
            ObjDB.AddParameter("@VILL_LONG2", VillEntity_Obj._VILL_LONG2);
            ObjDB.AddParameter("@VILL_LONG3", VillEntity_Obj._VILL_LONG3);
            ObjDB.AddParameter("@VILL_LONG4", VillEntity_Obj._VILL_LONG4);
            ObjDB.AddParameter("@VILL_CR_BFFR_STS", VillEntity_Obj._VILL_CR_BFFR_STS);


            ObjDB.AddParameter("@VILL_TOT_OBC", VillEntity_Obj._VILL_TOT_OBC);
            ObjDB.AddParameter("@VILL_TOT_ST", VillEntity_Obj._VILL_TOT_ST);
            ObjDB.AddParameter("@VILL_TOT_SC", VillEntity_Obj._VILL_TOT_SC);
            ObjDB.AddParameter("@VILL_TOT_OTH", VillEntity_Obj._VILL_TOT_OTH);

            ObjDB.AddParameter("@VILL_TOT_CNB", VillEntity_Obj._VILL_TOT_CNB);
            ObjDB.AddParameter("@VILL_TOT_SNG", VillEntity_Obj._VILL_TOT_SNG);
            ObjDB.AddParameter("@TOT_OTHR_ANML", VillEntity_Obj._TOT_OTHR_ANML);


            ObjDB.AddParameter("@VILL_LNGMIN1", VillEntity_Obj._VILL_LNGMIN1);
            ObjDB.AddParameter("@VILL_LNGMIN2", VillEntity_Obj._VILL_LNGMIN2);
            ObjDB.AddParameter("@VILL_LNGMIN3", VillEntity_Obj._VILL_LNGMIN3);
            ObjDB.AddParameter("@VILL_LNGMIN4", VillEntity_Obj._VILL_LNGMIN4);

            ObjDB.AddParameter("@VILL_LNGSEC1", VillEntity_Obj._VILL_LNGSEC1);
            ObjDB.AddParameter("@VILL_LNGSEC2", VillEntity_Obj._VILL_LNGSEC2);
            ObjDB.AddParameter("@VILL_LNGSEC3", VillEntity_Obj._VILL_LNGSEC3);
            ObjDB.AddParameter("@VILL_LNGSEC4", VillEntity_Obj._VILL_LNGSEC4);


            ObjDB.AddParameter("@VILL_LONGMIN1", VillEntity_Obj._VILL_LONGMIN1);
            ObjDB.AddParameter("@VILL_LONGMIN2", VillEntity_Obj._VILL_LONGMIN2);
            ObjDB.AddParameter("@VILL_LONGMIN3", VillEntity_Obj._VILL_LONGMIN3);
            ObjDB.AddParameter("@VILL_LONGMIN4", VillEntity_Obj._VILL_LONGMIN4);


            ObjDB.AddParameter("@VILL_LONGSEC1", VillEntity_Obj._VILL_LONGSEC1);
            ObjDB.AddParameter("@VILL_LONGSEC2", VillEntity_Obj._VILL_LONGSEC2);
            ObjDB.AddParameter("@VILL_LONGSEC3", VillEntity_Obj._VILL_LONGSEC3);
            ObjDB.AddParameter("@VILL_LONGSEC4", VillEntity_Obj._VILL_LONGSEC4);

            ObjDB.AddParameter("@VILL_VAL_AGRI", VillEntity_Obj._VILL_VAL_AGRI);
            ObjDB.AddParameter("@VILL_VAL_RES", VillEntity_Obj._VILL_VAL_RES);

            ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["CmnStateUser"]));
            ObjDB.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveUserID"]));
            ObjDB.AddParameter("@CmnDataOperatorUserID", Convert.ToInt32(HttpContext.Current.Session["CmnDataOperatorUserID"]));
            ObjDB.AddParameter("@CmnStateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
            ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveID"]));

            //----june2june
            ObjDB.AddParameter("@DateMeeting", VillEntity_Obj.DateMeeting);
            ObjDB.AddParameter("@Kmlfileupload", VillEntity_Obj.KMLFile);

            ObjDB.AddParameter("@NoAdult", VillEntity_Obj.NoAdult);
            ObjDB.AddParameter("@NoTransGender", VillEntity_Obj.NoTransGender);
            ObjDB.AddParameter("@NoCows", VillEntity_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", VillEntity_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", VillEntity_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", VillEntity_Obj.NoGoat);
            ObjDB.AddParameter("@CuttOffDate", VillEntity_Obj.CuttOffDate);
            ObjDB.AddParameter("@Latitude", VillEntity_Obj.Latitude);
            ObjDB.AddParameter("@Longitude", VillEntity_Obj.Longitude);
            var commanMISTableDetailParam = new SqlParameter("@FileNames",  VillEntity_Obj.filenames);
            commanMISTableDetailParam.SqlDbType = SqlDbType.Structured;
            ObjDB.Parameters.Add(commanMISTableDetailParam);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Village");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool AddVillageDB1(VillageEntity VillEntity_Obj, StateEntity State_Entity, DistrictEntity Dist_Ent_Obj, Reserve_Entity RSVREntity_Obj, Tehsil_Entity TH_EN_Obj, Grampanchayat_Entity GP_EN_Obj)
    {
        try
        {
            ObjDB.AddParameter("@UserID", VillEntity_Obj.UserID);
            ObjDB.AddParameter("@VILL_CD", VillEntity_Obj._VILL_CD);
            ObjDB.AddParameter("@VILL_NM", VillEntity_Obj._VILL_NM);
            ObjDB.AddParameter("@VILL_POPU", VillEntity_Obj._VILL_POPU);
            ObjDB.AddParameter("@VILL_TOT_LND_AREA", VillEntity_Obj._VILL_TOT_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_AGRI_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_NON_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA);
            ObjDB.AddParameter("@RSRV_ID", RSVREntity_Obj._RSRV_ID);
            ObjDB.AddParameter("@VILL_LGL_STAT", VillEntity_Obj._VILL_LGL_STAT);
            ObjDB.AddParameter("@VILL_NO_FM", VillEntity_Obj._VILL_NO_FM);
            ObjDB.AddParameter("@VILL_NO_LIV_STOK", VillEntity_Obj._VILL_NO_LIV_STOK);
            ObjDB.AddParameter("@ST_ID", State_Entity._ST_ID);
            ObjDB.AddParameter("@DT_ID", Dist_Ent_Obj._DT_ID);
            ObjDB.AddParameter("@ST_VILL_CD", VillEntity_Obj._ST_VILL_CD);
            ObjDB.AddParameter("@VILL_STAT", VillEntity_Obj._VILL_STAT);
            ObjDB.AddParameter("@TH_ID", TH_EN_Obj._TH_ID);
            ObjDB.AddParameter("@GP_ID", GP_EN_Obj._GP_ID);

            ObjDB.AddParameter("@VILL_MALE", VillEntity_Obj._VILL_MALE);
            ObjDB.AddParameter("@VILL_FEMALE", VillEntity_Obj._VILL_FEMALE);
            ObjDB.AddParameter("@VILL_OTHER_LND_AREA", VillEntity_Obj._VILL_OTHER_LND_AREA);
            //ObjDB.AddParameter("@VILL_CUT_DT", VillEntity_Obj._VILL_CUT_DT);
            ObjDB.AddParameter("@VILL_SURVEY_DT", VillEntity_Obj._VILL_SURVEY_DT);
            ObjDB.AddParameter("@COMMENTS", VillEntity_Obj._COMMENT);

            ObjDB.AddParameter("@VILL_LNG1", VillEntity_Obj._VILL_LNG1);
            ObjDB.AddParameter("@VILL_LNG2", VillEntity_Obj._VILL_LNG2);
            ObjDB.AddParameter("@VILL_LNG3", VillEntity_Obj._VILL_LNG3);
            ObjDB.AddParameter("@VILL_LNG4", VillEntity_Obj._VILL_LNG4);
            ObjDB.AddParameter("@VILL_LONG1", VillEntity_Obj._VILL_LONG1);
            ObjDB.AddParameter("@VILL_LONG2", VillEntity_Obj._VILL_LONG2);
            ObjDB.AddParameter("@VILL_LONG3", VillEntity_Obj._VILL_LONG3);
            ObjDB.AddParameter("@VILL_LONG4", VillEntity_Obj._VILL_LONG4);
            ObjDB.AddParameter("@VILL_CR_BFFR_STS", VillEntity_Obj._VILL_CR_BFFR_STS);


            ObjDB.AddParameter("@VILL_TOT_OBC", VillEntity_Obj._VILL_TOT_OBC);
            ObjDB.AddParameter("@VILL_TOT_ST", VillEntity_Obj._VILL_TOT_ST);
            ObjDB.AddParameter("@VILL_TOT_SC", VillEntity_Obj._VILL_TOT_SC);
            ObjDB.AddParameter("@VILL_TOT_OTH", VillEntity_Obj._VILL_TOT_OTH);

            ObjDB.AddParameter("@VILL_TOT_CNB", VillEntity_Obj._VILL_TOT_CNB);
            ObjDB.AddParameter("@VILL_TOT_SNG", VillEntity_Obj._VILL_TOT_SNG);
            ObjDB.AddParameter("@TOT_OTHR_ANML", VillEntity_Obj._TOT_OTHR_ANML);


            ObjDB.AddParameter("@VILL_LNGMIN1", VillEntity_Obj._VILL_LNGMIN1);
            ObjDB.AddParameter("@VILL_LNGMIN2", VillEntity_Obj._VILL_LNGMIN2);
            ObjDB.AddParameter("@VILL_LNGMIN3", VillEntity_Obj._VILL_LNGMIN3);
            ObjDB.AddParameter("@VILL_LNGMIN4", VillEntity_Obj._VILL_LNGMIN4);

            ObjDB.AddParameter("@VILL_LNGSEC1", VillEntity_Obj._VILL_LNGSEC1);
            ObjDB.AddParameter("@VILL_LNGSEC2", VillEntity_Obj._VILL_LNGSEC2);
            ObjDB.AddParameter("@VILL_LNGSEC3", VillEntity_Obj._VILL_LNGSEC3);
            ObjDB.AddParameter("@VILL_LNGSEC4", VillEntity_Obj._VILL_LNGSEC4);


            ObjDB.AddParameter("@VILL_LONGMIN1", VillEntity_Obj._VILL_LONGMIN1);
            ObjDB.AddParameter("@VILL_LONGMIN2", VillEntity_Obj._VILL_LONGMIN2);
            ObjDB.AddParameter("@VILL_LONGMIN3", VillEntity_Obj._VILL_LONGMIN3);
            ObjDB.AddParameter("@VILL_LONGMIN4", VillEntity_Obj._VILL_LONGMIN4);


            ObjDB.AddParameter("@VILL_LONGSEC1", VillEntity_Obj._VILL_LONGSEC1);
            ObjDB.AddParameter("@VILL_LONGSEC2", VillEntity_Obj._VILL_LONGSEC2);
            ObjDB.AddParameter("@VILL_LONGSEC3", VillEntity_Obj._VILL_LONGSEC3);
            ObjDB.AddParameter("@VILL_LONGSEC4", VillEntity_Obj._VILL_LONGSEC4);

            ObjDB.AddParameter("@VILL_VAL_AGRI", VillEntity_Obj._VILL_VAL_AGRI);
            ObjDB.AddParameter("@VILL_VAL_RES", VillEntity_Obj._VILL_VAL_RES);

            ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["CmnStateUser"]));
            //   ObjDB.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveUserID"]));
            // ObjDB.AddParameter("@CmnDataOperatorUserID", VillEntity_Obj.CmnDataOperatorUserID);
            ObjDB.AddParameter("@CmnStateID", VillEntity_Obj.StateID);
             ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", VillEntity_Obj.CmnDataOperatorTigerReserveID);
            //----june2june
            ObjDB.AddParameter("@DateMeeting", VillEntity_Obj.DateMeeting);
            ObjDB.AddParameter("@NoAdult", VillEntity_Obj.NoAdult);
            ObjDB.AddParameter("@NoTransGender", VillEntity_Obj.NoTransGender);
            ObjDB.AddParameter("@Kmlfileupload", VillEntity_Obj.KMLFile);

            ObjDB.AddParameter("@NoCows", VillEntity_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", VillEntity_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", VillEntity_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", VillEntity_Obj.NoGoat);
            ObjDB.AddParameter("@FileNames", VillEntity_Obj.filenames);
            ObjDB.AddParameter("@CuttOffDate", VillEntity_Obj.CuttOffDate);

            ObjDB.AddParameter("@Latitude", VillEntity_Obj.Latitude);
            ObjDB.AddParameter("@Longitude", VillEntity_Obj.Longitude);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Village");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool AddPreSurveyForm(SurveyFormEntity obj)
    {
        try
        {
            ObjDB.AddParameter("@FromVillID", obj.FromVillID);
            ObjDB.AddParameter("@FromVillNm", obj.FromVillNm);
            ObjDB.AddParameter("@ToVillID", obj.ToVillID);
            ObjDB.AddParameter("@DfoUserID", obj.DfoUserID);
            ObjDB.AddParameter("@TxtDatesurvey", obj.TxtDatesurvey);
            ObjDB.AddParameter("@TxtNamesurveyor", obj.TxtNamesurveyor);
            ObjDB.AddParameter("@TxtDesignationSurveyor", obj.TxtDesignationSurveyor);

            ObjDB.AddParameter("@RdbPanchayatOffice", obj.RdbPanchayatOffice);
            ObjDB.AddParameter("@TxtRdbPanchayatOffice", obj.TxtRdbPanchayatOffice);
            ObjDB.AddParameter("@RdbAnganwadi", obj.RdbAnganwadi);
            ObjDB.AddParameter("@TxtRdbAnganwadi", obj.TxtRdbAnganwadi);
            ObjDB.AddParameter("@RdbAllWeatherRoad", obj.RdbAllWeatherRoad);
            ObjDB.AddParameter("@TxtRdbAllWeatherRoad", obj.TxtRdbAllWeatherRoad);
            ObjDB.AddParameter("@RdbPostOffice", obj.RdbPostOffice);
            ObjDB.AddParameter("@TxtRdbPostOffice", obj.TxtRdbPostOffice);

            ObjDB.AddParameter("@RdbBank", obj.RdbBank);
            ObjDB.AddParameter("@TxtRdbBank", obj.TxtRdbBank);
            ObjDB.AddParameter("@RdbPDSShop", obj.RdbPDSShop);

            ObjDB.AddParameter("@TxtRdbPDSShop", obj.TxtRdbPDSShop);
            ObjDB.AddParameter("@RdbPublicTelephonePCo", obj.RdbPublicTelephonePCo);
            ObjDB.AddParameter("@TxtRdbPublicTelephonePCo", obj.TxtRdbPublicTelephonePCo);
            ObjDB.AddParameter("@RdbMobileSignal", obj.RdbMobileSignal);
            ObjDB.AddParameter("@TxtRdbMobileSignal", obj.TxtRdbMobileSignal);
            ObjDB.AddParameter("@RdbAccessibiliythealthCare", obj.RdbAccessibiliythealthCare);
            ObjDB.AddParameter("@TxtAccessibiliythealthCare", obj.TxtAccessibiliythealthCare);
            ObjDB.AddParameter("@RdbAccessibiliyRoad", obj.RdbAccessibiliyRoad);
            ObjDB.AddParameter("@TxtAccessibiliyRoad", obj.TxtAccessibiliyRoad);
            ObjDB.AddParameter("@RdbAccessbilitySchool", obj.RdbAccessbilitySchool);
            ObjDB.AddParameter("@TxtAccessbilitySchoolPrimary", obj.TxtAccessbilitySchoolPrimary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_Secondary", obj.TxtAccessbilitySchool_Secondary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_HighSchool", obj.TxtAccessbilitySchool_HighSchool);
            ObjDB.AddParameter("@TxtAccessbilitySchool_College", obj.TxtAccessbilitySchool_College);
            ObjDB.AddParameter("@RdbAccessbilityElectrif", obj.RdbAccessbilityElectrif);
            ObjDB.AddParameter("@TxtAccessbilityElectrif_DurationElectricityVillages", obj.TxtAccessbilityElectrif_DurationElectricityVillages);
            ObjDB.AddParameter("@RdbAccessiblityVeterinary", obj.RdbAccessiblityVeterinary);
            ObjDB.AddParameter("@TxtAccessiblityVeterinary", obj.TxtAccessiblityVeterinary);
            ObjDB.AddParameter("@RdbAvenuesEmployment", obj.RdbAvenuesEmployment);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Primary", obj.TxtAvenuesEmployment_Primary);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Secondary", obj.TxtAvenuesEmployment_Secondary);
            ObjDB.AddParameter("@RdbHumanWildlifecon", obj.RdbHumanWildlifecon);
            ObjDB.AddParameter("@TxtRdbHumanWildlifecon", obj.TxtRdbHumanWildlifecon);
            ObjDB.AddParameter("@RdbAccessFireFodNwfps", obj.RdbAccessFireFodNwfps);
            ObjDB.AddParameter("@TXTAccessFireFodNwfps", obj.TXTAccessFireFodNwfps);
            ObjDB.AddParameter("@Action", obj.Action);

            int i = ObjDB.ExecuteNonQuery("SpSavePreSurveyForm");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool AddPreSurveyFormPost(SurveyFormEntity obj)
    {
        try
        {
            ObjDB.AddParameter("@ToVillID", obj.ToVillID);//
            ObjDB.AddParameter("@ToVillNm", obj.ToVillNm);//
            ObjDB.AddParameter("@FromVillID", obj.FromVillID);//
            ObjDB.AddParameter("@DfoUserID", obj.DfoUserID);
            ObjDB.AddParameter("@TxtDatesurvey", obj.TxtDatesurvey);
            ObjDB.AddParameter("@TxtNamesurveyor", obj.TxtNamesurveyor);
            ObjDB.AddParameter("@TxtDesignationSurveyor", obj.TxtDesignationSurveyor);

            ObjDB.AddParameter("@RdbPanchayatOffice", obj.RdbPanchayatOffice);
            ObjDB.AddParameter("@TxtRdbPanchayatOffice", obj.TxtRdbPanchayatOffice);
            ObjDB.AddParameter("@RdbAnganwadi", obj.RdbAnganwadi);
            ObjDB.AddParameter("@TxtRdbAnganwadi", obj.TxtRdbAnganwadi);
            ObjDB.AddParameter("@RdbAllWeatherRoad", obj.RdbAllWeatherRoad);
            ObjDB.AddParameter("@TxtRdbAllWeatherRoad", obj.TxtRdbAllWeatherRoad);
            ObjDB.AddParameter("@RdbPostOffice", obj.RdbPostOffice);
            ObjDB.AddParameter("@TxtRdbPostOffice", obj.TxtRdbPostOffice);

            ObjDB.AddParameter("@RdbBank", obj.RdbBank);
            ObjDB.AddParameter("@TxtRdbBank", obj.TxtRdbBank);
            ObjDB.AddParameter("@RdbPDSShop", obj.RdbPDSShop);

            ObjDB.AddParameter("@TxtRdbPDSShop", obj.TxtRdbPDSShop);
            ObjDB.AddParameter("@RdbPublicTelephonePCo", obj.RdbPublicTelephonePCo);
            ObjDB.AddParameter("@TxtRdbPublicTelephonePCo", obj.TxtRdbPublicTelephonePCo);
            ObjDB.AddParameter("@RdbMobileSignal", obj.RdbMobileSignal);
            ObjDB.AddParameter("@TxtRdbMobileSignal", obj.TxtRdbMobileSignal);
            ObjDB.AddParameter("@RdbAccessibiliythealthCare", obj.RdbAccessibiliythealthCare);
            ObjDB.AddParameter("@TxtAccessibiliythealthCare", obj.TxtAccessibiliythealthCare);
            ObjDB.AddParameter("@RdbAccessibiliyRoad", obj.RdbAccessibiliyRoad);
            ObjDB.AddParameter("@TxtAccessibiliyRoad", obj.TxtAccessibiliyRoad);
            ObjDB.AddParameter("@RdbAccessbilitySchool", obj.RdbAccessbilitySchool);
            ObjDB.AddParameter("@TxtAccessbilitySchoolPrimary", obj.TxtAccessbilitySchoolPrimary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_Secondary", obj.TxtAccessbilitySchool_Secondary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_HighSchool", obj.TxtAccessbilitySchool_HighSchool);
            ObjDB.AddParameter("@TxtAccessbilitySchool_College", obj.TxtAccessbilitySchool_College);
            ObjDB.AddParameter("@RdbAccessbilityElectrif", obj.RdbAccessbilityElectrif);
            ObjDB.AddParameter("@TxtAccessbilityElectrif_DurationElectricityVillages", obj.TxtAccessbilityElectrif_DurationElectricityVillages);
            ObjDB.AddParameter("@RdbAccessiblityVeterinary", obj.RdbAccessiblityVeterinary);
            ObjDB.AddParameter("@TxtAccessiblityVeterinary", obj.TxtAccessiblityVeterinary);
            ObjDB.AddParameter("@RdbAvenuesEmployment", obj.RdbAvenuesEmployment);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Primary", obj.TxtAvenuesEmployment_Primary);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Secondary", obj.TxtAvenuesEmployment_Secondary);
            ObjDB.AddParameter("@RdbHumanWildlifecon", obj.RdbHumanWildlifecon);
            ObjDB.AddParameter("@TxtRdbHumanWildlifecon", obj.TxtRdbHumanWildlifecon);
            ObjDB.AddParameter("@RdbAccessFireFodNwfps", obj.RdbAccessFireFodNwfps);
            ObjDB.AddParameter("@TXTAccessFireFodNwfps", obj.TXTAccessFireFodNwfps);
            ObjDB.AddParameter("@Action", obj.Action);

            int i = ObjDB.ExecuteNonQuery("SpSavePreSurveyFormPost");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool UpdatePreSurveyForm(SurveyFormEntity obj)
    {
        try
        {
            //ObjDB.AddParameter("@FromVillID", obj.FromVillID);
          //  ObjDB.AddParameter("@FromVillNm", obj.FromVillNm);
           // ObjDB.AddParameter("@ToVillID", obj.ToVillID);
          //  ObjDB.AddParameter("@DfoUserID", obj.DfoUserID);
            ObjDB.AddParameter("@TxtDatesurvey", obj.TxtDatesurvey);
            ObjDB.AddParameter("@TxtNamesurveyor", obj.TxtNamesurveyor);
            ObjDB.AddParameter("@TxtDesignationSurveyor", obj.TxtDesignationSurveyor);

            ObjDB.AddParameter("@RdbPanchayatOffice", obj.RdbPanchayatOffice);
            ObjDB.AddParameter("@TxtRdbPanchayatOffice", obj.TxtRdbPanchayatOffice);
            ObjDB.AddParameter("@RdbAnganwadi", obj.RdbAnganwadi);
            ObjDB.AddParameter("@TxtRdbAnganwadi", obj.TxtRdbAnganwadi);
            ObjDB.AddParameter("@RdbAllWeatherRoad", obj.RdbAllWeatherRoad);
            ObjDB.AddParameter("@TxtRdbAllWeatherRoad", obj.TxtRdbAllWeatherRoad);
            ObjDB.AddParameter("@RdbPostOffice", obj.RdbPostOffice);
            ObjDB.AddParameter("@TxtRdbPostOffice", obj.TxtRdbPostOffice);

            ObjDB.AddParameter("@RdbBank", obj.RdbBank);
            ObjDB.AddParameter("@TxtRdbBank", obj.TxtRdbBank);
            ObjDB.AddParameter("@RdbPDSShop", obj.RdbPDSShop);

            ObjDB.AddParameter("@TxtRdbPDSShop", obj.TxtRdbPDSShop);
            ObjDB.AddParameter("@RdbPublicTelephonePCo", obj.RdbPublicTelephonePCo);
            ObjDB.AddParameter("@TxtRdbPublicTelephonePCo", obj.TxtRdbPublicTelephonePCo);
            ObjDB.AddParameter("@RdbMobileSignal", obj.RdbMobileSignal);
            ObjDB.AddParameter("@TxtRdbMobileSignal", obj.TxtRdbMobileSignal);
            ObjDB.AddParameter("@RdbAccessibiliythealthCare", obj.RdbAccessibiliythealthCare);
            ObjDB.AddParameter("@TxtAccessibiliythealthCare", obj.TxtAccessibiliythealthCare);
            ObjDB.AddParameter("@RdbAccessibiliyRoad", obj.RdbAccessibiliyRoad);
            ObjDB.AddParameter("@TxtAccessibiliyRoad", obj.TxtAccessibiliyRoad);
            ObjDB.AddParameter("@RdbAccessbilitySchool", obj.RdbAccessbilitySchool);
            ObjDB.AddParameter("@TxtAccessbilitySchoolPrimary", obj.TxtAccessbilitySchoolPrimary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_Secondary", obj.TxtAccessbilitySchool_Secondary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_HighSchool", obj.TxtAccessbilitySchool_HighSchool);
            ObjDB.AddParameter("@TxtAccessbilitySchool_College", obj.TxtAccessbilitySchool_College);
            ObjDB.AddParameter("@RdbAccessbilityElectrif", obj.RdbAccessbilityElectrif);
            ObjDB.AddParameter("@TxtAccessbilityElectrif_DurationElectricityVillages", obj.TxtAccessbilityElectrif_DurationElectricityVillages);
            ObjDB.AddParameter("@RdbAccessiblityVeterinary", obj.RdbAccessiblityVeterinary);
            ObjDB.AddParameter("@TxtAccessiblityVeterinary", obj.TxtAccessiblityVeterinary);
            ObjDB.AddParameter("@RdbAvenuesEmployment", obj.RdbAvenuesEmployment);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Primary", obj.TxtAvenuesEmployment_Primary);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Secondary", obj.TxtAvenuesEmployment_Secondary);
            ObjDB.AddParameter("@RdbHumanWildlifecon", obj.RdbHumanWildlifecon);
            ObjDB.AddParameter("@TxtRdbHumanWildlifecon", obj.TxtRdbHumanWildlifecon);
            ObjDB.AddParameter("@RdbAccessFireFodNwfps", obj.RdbAccessFireFodNwfps);
            ObjDB.AddParameter("@TXTAccessFireFodNwfps", obj.TXTAccessFireFodNwfps);
            ObjDB.AddParameter("@FromVillID", obj.FromVillID);
            ObjDB.AddParameter("@Action", obj.Action);

            int i = ObjDB.ExecuteNonQuery("SpSavePreSurveyForm");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool UpdatePreSurveyFormPost(SurveyFormEntity obj)
    {
        try
        {
            //ObjDB.AddParameter("@FromVillID", obj.FromVillID);
            //  ObjDB.AddParameter("@FromVillNm", obj.FromVillNm);
            // ObjDB.AddParameter("@ToVillID", obj.ToVillID);
            //  ObjDB.AddParameter("@DfoUserID", obj.DfoUserID);
            ObjDB.AddParameter("@TxtDatesurvey", obj.TxtDatesurvey);
            ObjDB.AddParameter("@TxtNamesurveyor", obj.TxtNamesurveyor);
            ObjDB.AddParameter("@TxtDesignationSurveyor", obj.TxtDesignationSurveyor);

            ObjDB.AddParameter("@RdbPanchayatOffice", obj.RdbPanchayatOffice);
            ObjDB.AddParameter("@TxtRdbPanchayatOffice", obj.TxtRdbPanchayatOffice);
            ObjDB.AddParameter("@RdbAnganwadi", obj.RdbAnganwadi);
            ObjDB.AddParameter("@TxtRdbAnganwadi", obj.TxtRdbAnganwadi);
            ObjDB.AddParameter("@RdbAllWeatherRoad", obj.RdbAllWeatherRoad);
            ObjDB.AddParameter("@TxtRdbAllWeatherRoad", obj.TxtRdbAllWeatherRoad);
            ObjDB.AddParameter("@RdbPostOffice", obj.RdbPostOffice);
            ObjDB.AddParameter("@TxtRdbPostOffice", obj.TxtRdbPostOffice);

            ObjDB.AddParameter("@RdbBank", obj.RdbBank);
            ObjDB.AddParameter("@TxtRdbBank", obj.TxtRdbBank);
            ObjDB.AddParameter("@RdbPDSShop", obj.RdbPDSShop);

            ObjDB.AddParameter("@TxtRdbPDSShop", obj.TxtRdbPDSShop);
            ObjDB.AddParameter("@RdbPublicTelephonePCo", obj.RdbPublicTelephonePCo);
            ObjDB.AddParameter("@TxtRdbPublicTelephonePCo", obj.TxtRdbPublicTelephonePCo);
            ObjDB.AddParameter("@RdbMobileSignal", obj.RdbMobileSignal);
            ObjDB.AddParameter("@TxtRdbMobileSignal", obj.TxtRdbMobileSignal);
            ObjDB.AddParameter("@RdbAccessibiliythealthCare", obj.RdbAccessibiliythealthCare);
            ObjDB.AddParameter("@TxtAccessibiliythealthCare", obj.TxtAccessibiliythealthCare);
            ObjDB.AddParameter("@RdbAccessibiliyRoad", obj.RdbAccessibiliyRoad);
            ObjDB.AddParameter("@TxtAccessibiliyRoad", obj.TxtAccessibiliyRoad);
            ObjDB.AddParameter("@RdbAccessbilitySchool", obj.RdbAccessbilitySchool);
            ObjDB.AddParameter("@TxtAccessbilitySchoolPrimary", obj.TxtAccessbilitySchoolPrimary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_Secondary", obj.TxtAccessbilitySchool_Secondary);
            ObjDB.AddParameter("@TxtAccessbilitySchool_HighSchool", obj.TxtAccessbilitySchool_HighSchool);
            ObjDB.AddParameter("@TxtAccessbilitySchool_College", obj.TxtAccessbilitySchool_College);
            ObjDB.AddParameter("@RdbAccessbilityElectrif", obj.RdbAccessbilityElectrif);
            ObjDB.AddParameter("@TxtAccessbilityElectrif_DurationElectricityVillages", obj.TxtAccessbilityElectrif_DurationElectricityVillages);
            ObjDB.AddParameter("@RdbAccessiblityVeterinary", obj.RdbAccessiblityVeterinary);
            ObjDB.AddParameter("@TxtAccessiblityVeterinary", obj.TxtAccessiblityVeterinary);
            ObjDB.AddParameter("@RdbAvenuesEmployment", obj.RdbAvenuesEmployment);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Primary", obj.TxtAvenuesEmployment_Primary);
            ObjDB.AddParameter("@TxtAvenuesEmployment_Secondary", obj.TxtAvenuesEmployment_Secondary);
            ObjDB.AddParameter("@RdbHumanWildlifecon", obj.RdbHumanWildlifecon);
            ObjDB.AddParameter("@TxtRdbHumanWildlifecon", obj.TxtRdbHumanWildlifecon);
            ObjDB.AddParameter("@RdbAccessFireFodNwfps", obj.RdbAccessFireFodNwfps);
            ObjDB.AddParameter("@TXTAccessFireFodNwfps", obj.TXTAccessFireFodNwfps);
            ObjDB.AddParameter("@ToVillID", obj.ToVillID);
            ObjDB.AddParameter("@Action", obj.Action);

            int i = ObjDB.ExecuteNonQuery("SpSavePreSurveyFormPost");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public DataSet Display_All_VillagesDB(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
        ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);
        ObjDB.AddParameter("@UserID", Vill_Entity.UserID);       
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages");

    }
    public DataSet GetSurveyList(VillageEntity Vill_Entity)
    {//@FromVillageID
        ObjDB.AddParameter("@CmnDataOperatorUserID", Vill_Entity.CmnDataOperatorUserID);
        ObjDB.AddParameter("@FromVillageID", Vill_Entity.FromVillageID);
        return ObjDB.ExecuteDataSet("SpSurveryFormListForDfo");

    }
    public DataSet GetSurveyListTigerReserve(VillageEntity Vill_Entity)
    {//@FromVillageID
        ObjDB.AddParameter("@CmnTigerReserveUserID", Vill_Entity.CmnTigerReserveUserID);
        ObjDB.AddParameter("@FromVillageID", Vill_Entity.FromVillageID);
        return ObjDB.ExecuteDataSet("SpSurveryFormListForTigerReserve");

    }
    public DataSet GetSurveyListNtca(VillageEntity Vill_Entity)
    {//@FromVillageID
       // ObjDB.AddParameter("@CmnTigerReserveUserID", Vill_Entity.CmnTigerReserveUserID);
        ObjDB.AddParameter("@FromVillageID", Vill_Entity.FromVillageID);
        return ObjDB.ExecuteDataSet("SpSurveryFormListForNtca");

    }
    public DataSet GetSurveyListStateUser(VillageEntity Vill_Entity)
    {//@FromVillageID
        ObjDB.AddParameter("@CmnStateUserID", Vill_Entity.CmnStateUserID);
        ObjDB.AddParameter("@FromVillageID", Vill_Entity.FromVillageID);
        return ObjDB.ExecuteDataSet("SpSurveryFormListForStateUser");

    }
    public DataSet CheckPreVillageSurveyFormExistence(string VillId, string Action)
    {//@FromVillageID
        ObjDB.AddParameter("@FromVillID", VillId);
        ObjDB.AddParameter("@Action", Action);
        return ObjDB.ExecuteDataSet("SpCheckVillageExistence");

    }
    public DataSet CheckPreVillageSurveyFormExistencePost(string VillId, string Action)
    {//@FromVillageID
        ObjDB.AddParameter("@ToVillID", VillId);
        ObjDB.AddParameter("@Action", Action);
        return ObjDB.ExecuteDataSet("SpCheckVillageExistencePost");

    }
    public DataSet Display_All_VillagesDB3(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
        ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);
        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Vill_Entity.CmnDataOperatorTigerReserveID);
        ObjDB.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));

        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages3");

    }
    //public DataSet Display_All_VillagesDB2(VillageEntity Vill_Entity)
    //{
    //    ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
    //    ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);
    //    ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Vill_Entity.CmnDataOperatorTigerReserveID);
    //    ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));

    //    return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages3");

    //}
    public DataSet Display_All_VillagesDB2(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
        ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);

        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Vill_Entity.CmnDataOperatorTigerReserveID);
        ObjDB.AddParameter("@CmnStateUserID", Vill_Entity.UserID);

        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages2");

    }
    //public DataSet Display_All_VillagesDB1(VillageEntity Vill_Entity)
    //{
    //    ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
    //    ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);

    //    ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Vill_Entity.CmnDataOperatorTigerReserveID);
    //   // ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));

    //    return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages1");

    //}
    public DataSet Display_All_VillagesDB1(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
        ObjDB.AddParameter("@VILL_CD", Vill_Entity._VILL_CD);
        ObjDB.AddParameter("@statename", Vill_Entity._COMMENT);
        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Vill_Entity.CmnDataOperatorTigerReserveID);
        //  ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));

        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Villages1");

    }
    //Changed By Deepak
    public DataSet Display_All_Villages(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);
        ObjDB.AddParameter("@ReserveUserID", Vill_Entity.CmnTigerReserveUserID);
        ObjDB.AddParameter("@CmnStateID", Vill_Entity.CmnStateID);
        return ObjDB.ExecuteDataSet("Proc_DisplayVillagesDetail");

    }
    public DataSet PopUpDisplay_All_VillagesDB(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@VILL_ID", Vill_Entity._VILL_ID);

        return ObjDB.ExecuteDataSet("PopUpInfoVillages");

    }


    public bool Delete_Village_By_ID(string villageid)
    {
        try
        {
            ObjDB.AddParameter("@VILL_ID", villageid);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_Info_Village");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool UpdateVillageDB(VillageEntity VillEntity_Obj, string stateid, string reserveid, string districtid, string tehsilid, string gpid)
    {
        try
        {
          
            HttpContext.Current.Response.Write("id is" + VillEntity_Obj._VILL_ID);

            //SqlParameter[] param = new SqlParameter[1];
            //param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            //param[0].Direction = ParameterDirection.Output;
            ObjDB.AddParameter("@VILL_ID", VillEntity_Obj._VILL_ID);
            ObjDB.AddParameter("@VILL_NM", VillEntity_Obj._VILL_NM);
            ObjDB.AddParameter("@VILL_POPU", VillEntity_Obj._VILL_POPU);
            ObjDB.AddParameter("@VILL_TOT_LND_AREA", VillEntity_Obj._VILL_TOT_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_AGRI_LND_AREA);
            ObjDB.AddParameter("@VILL_TOT_NON_AGRI_LND_AREA", VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA);
            ObjDB.AddParameter("@VILL_LGL_STAT", VillEntity_Obj._VILL_LGL_STAT);
            ObjDB.AddParameter("@VILL_NO_FM", VillEntity_Obj._VILL_NO_FM);
            ObjDB.AddParameter("@VILL_NO_LIV_STOK", VillEntity_Obj._VILL_NO_LIV_STOK);
            ObjDB.AddParameter("@DT_ID", districtid);
            ObjDB.AddParameter("@VILL_STAT", VillEntity_Obj._VILL_STAT);
            ObjDB.AddParameter("@VILL_TOT_OBC", VillEntity_Obj._VILL_TOT_OBC);
            ObjDB.AddParameter("@VILL_TOT_ST", VillEntity_Obj._VILL_TOT_ST);
            ObjDB.AddParameter("@VILL_TOT_SC", VillEntity_Obj._VILL_TOT_SC);
            ObjDB.AddParameter("@VILL_TOT_OTH", VillEntity_Obj._VILL_TOT_OTH);
            ObjDB.AddParameter("@TH_ID", tehsilid);
            ObjDB.AddParameter("@GP_ID", gpid);
            ObjDB.AddParameter("@ST_ID", stateid);
            ObjDB.AddParameter("@RSRV_ID", reserveid);
            ObjDB.AddParameter("@COMMENTS", VillEntity_Obj._COMMENT);
            ObjDB.AddParameter("@VILL_TOT_CNB", VillEntity_Obj._VILL_TOT_CNB);
            ObjDB.AddParameter("@VILL_TOT_SNG", VillEntity_Obj._VILL_TOT_SNG);
            ObjDB.AddParameter("@TOT_OTHR_ANML", VillEntity_Obj._TOT_OTHR_ANML);
            ObjDB.AddParameter("@VILL_MALE", VillEntity_Obj._VILL_MALE);
            ObjDB.AddParameter("@VILL_FEMALE", VillEntity_Obj._VILL_FEMALE);
            ObjDB.AddParameter("@VILL_OTHER_LND_AREA", VillEntity_Obj._VILL_OTHER_LND_AREA);
            //ObjDB.AddParameter("@VILL_CUT_DT", VillEntity_Obj._VILL_CUT_DT);
            ObjDB.AddParameter("@VILL_SURVEY_DT", VillEntity_Obj._VILL_SURVEY_DT);
            ObjDB.AddParameter("@VILL_LNG1", VillEntity_Obj._VILL_LNG1);
            ObjDB.AddParameter("@VILL_LNG2", VillEntity_Obj._VILL_LNG2);
            ObjDB.AddParameter("@VILL_LNG3", VillEntity_Obj._VILL_LNG3);
            ObjDB.AddParameter("@VILL_LNG4", VillEntity_Obj._VILL_LNG4);
            ObjDB.AddParameter("@VILL_LONG1", VillEntity_Obj._VILL_LONG1);
            ObjDB.AddParameter("@VILL_LONG2", VillEntity_Obj._VILL_LONG2);
            ObjDB.AddParameter("@VILL_LONG3", VillEntity_Obj._VILL_LONG3);
            ObjDB.AddParameter("@VILL_LONG4", VillEntity_Obj._VILL_LONG4);
            ObjDB.AddParameter("@VILL_LNGMIN1", VillEntity_Obj._VILL_LNGMIN1);
            ObjDB.AddParameter("@VILL_LNGMIN2", VillEntity_Obj._VILL_LNGMIN2);
            ObjDB.AddParameter("@VILL_LNGMIN3", VillEntity_Obj._VILL_LNGMIN3);
            ObjDB.AddParameter("@VILL_LNGMIN4", VillEntity_Obj._VILL_LNGMIN4);
            ObjDB.AddParameter("@VILL_LNGSEC1", VillEntity_Obj._VILL_LNGSEC1);
            ObjDB.AddParameter("@VILL_LNGSEC2", VillEntity_Obj._VILL_LNGSEC2);
            ObjDB.AddParameter("@VILL_LNGSEC3", VillEntity_Obj._VILL_LNGSEC3);
            ObjDB.AddParameter("@VILL_LNGSEC4", VillEntity_Obj._VILL_LNGSEC4);
            ObjDB.AddParameter("@VILL_LONGMIN1", VillEntity_Obj._VILL_LONGMIN1);
            ObjDB.AddParameter("@VILL_LONGMIN2", VillEntity_Obj._VILL_LONGMIN2);
            ObjDB.AddParameter("@VILL_LONGMIN3", VillEntity_Obj._VILL_LONGMIN3);
            ObjDB.AddParameter("@VILL_LONGMIN4", VillEntity_Obj._VILL_LONGMIN4);
            ObjDB.AddParameter("@VILL_LONGSEC1", VillEntity_Obj._VILL_LONGSEC1);
            ObjDB.AddParameter("@VILL_LONGSEC2", VillEntity_Obj._VILL_LONGSEC2);
            ObjDB.AddParameter("@VILL_LONGSEC3", VillEntity_Obj._VILL_LONGSEC3);
            ObjDB.AddParameter("@VILL_LONGSEC4", VillEntity_Obj._VILL_LONGSEC4);
            ObjDB.AddParameter("@VILL_CR_BFFR_STS", VillEntity_Obj._VILL_CR_BFFR_STS);
            ObjDB.AddParameter("@VILL_VAL_AGRI", VillEntity_Obj._VILL_VAL_AGRI);
            ObjDB.AddParameter("@VILL_VAL_RES", VillEntity_Obj._VILL_VAL_RES);
            ObjDB.AddParameter("@REC_UP_BY_UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            ObjDB.AddParameter("@DateMeeting", VillEntity_Obj.DateMeeting);
            ObjDB.AddParameter("@NoAdult", VillEntity_Obj.NoAdult);
            ObjDB.AddParameter("@NoTransGender", VillEntity_Obj.NoTransGender);
            ObjDB.AddParameter("@NoCows", VillEntity_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", VillEntity_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", VillEntity_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", VillEntity_Obj.NoGoat);
            ObjDB.AddParameter("@CuttOffDate", VillEntity_Obj.CuttOffDate);
            ObjDB.AddParameter("@UserID", VillEntity_Obj.UserID);
            ObjDB.AddParameter("@Latitude", VillEntity_Obj.Latitude);
            ObjDB.AddParameter("@Longitude", VillEntity_Obj.Longitude);
            var commanMISTableDetailParam = new SqlParameter("@FileNames", VillEntity_Obj.filenames);
            commanMISTableDetailParam.SqlDbType = SqlDbType.Structured;
            ObjDB.Parameters.Add(commanMISTableDetailParam);
            try
            {
                i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Village");
            }
            catch (Exception e6)
            {
                //  HttpContext.Current.Response.Write(e6.Message.ToString());
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e3)
        {
            return false;
            // HttpContext.Current.Response.Write(e3.Message.ToString());
        }
    }
    public bool CheckAndDeleteRelocationSite(VillageEntity VillEntity_Obj)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", VillEntity_Obj._VILL_ID);

            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteRelocationByVillageID");
            }
            catch (Exception e6)
            {
                //  HttpContext.Current.Response.Write(e6.Message.ToString());
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e3)
        {
            return false;
            // HttpContext.Current.Response.Write(e3.Message.ToString());
        }
    }
    public bool AttachmentDelete(VillageEntity VillEntity_Obj)
    {
        try
        {
            ObjDB.AddParameter("@vill_id", VillEntity_Obj._VILL_ID);
            ObjDB.AddParameter("@Action", VillEntity_Obj.Action);
            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteVillage");
            }
            catch (Exception e6)
            {
                //  HttpContext.Current.Response.Write(e6.Message.ToString());
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e3)
        {
            return false;
            // HttpContext.Current.Response.Write(e3.Message.ToString());
        }
    }

    public bool activDeactive(VillageEntity VillEntity_Obj)
    {
        try
        {
            ObjDB.AddParameter("@VILL_ID", VillEntity_Obj.VillageID);

            try
            {
                i = ObjDB.ExecuteNonQuery("spActiveDeaActiveVillage");
            }
            catch (Exception e6)
            {
                //  HttpContext.Current.Response.Write(e6.Message.ToString());
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e3)
        {
            return false;
            // HttpContext.Current.Response.Write(e3.Message.ToString());
        }
    }


    public DataSet Check_Village_Code(string villcode)
    {
        ObjDB.AddParameter("@VILL_CD", villcode);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_Village_Code");


    }

    public DataSet Get_OthersIDs_By_VillId(string villageid)
    {
        ObjDB.AddParameter("@VILL_ID", villageid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Get_OthersIDs_By_VillId");


    }
    public DataSet Fill_VillageCode_And_Name(int userid)
    {
        ObjDB.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name");
    }

    public DataSet Fill_StateVillage(int VillageID)
    {
        ObjDB.AddParameter("@VillageID", VillageID);
        return ObjDB.ExecuteDataSet("sp_BindStateVillage");
    }
     public DataSet Fill_Name(int userid, int id)
    {
        ObjDB.AddParameter("@UserID", userid);
        ObjDB.AddParameter("@VillageID", id);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name");
    }
     public DataSet Fill_Names(int userid, int id)
     {
         ObjDB.AddParameter("@UserID", userid);
         ObjDB.AddParameter("@VillageID", id);
         return ObjDB.ExecuteDataSet("Pre_Tiger_Fill_Village_Name");
     }
    public DataSet GetVillageNotRelocated(int userid)
    {
        ObjDB.AddParameter("@UserID", userid);
        return ObjDB.ExecuteDataSet("spGetVillageNotRelocated");
    }
    public DataSet Fill_VillageCode_And_NameNew(int userid)
    {
        ObjDB.AddParameter("@CmnTigerReserveUserID", userid);
        return ObjDB.ExecuteDataSet("Proc_Get_All_Villages3");
    }
    public DataSet FundStatusBind()
    {
        // ObjDB.AddParameter("@UserID", userid);
        return ObjDB.ExecuteDataSet("SpFundStatus");

    }
    public DataSet StatusIDDs(int statusID)
    {
        ObjDB.AddParameter("@statusID", statusID);
        return ObjDB.ExecuteDataSet("SpFundStatusPending");

    }
    public DataSet GetCuttOffDate(int VillageID)
    {
        ObjDB.AddParameter("@VILL_ID", VillageID);
        return ObjDB.ExecuteDataSet("spGetAllTigerVillage");



    }
    public DataSet Fill_VillageCode_And_Name3(int CmnTigerReserveUserID)
    {
        ObjDB.AddParameter("@CmnTigerReserveUserID", CmnTigerReserveUserID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name3");

    }
    //public DataSet Fill_VillageCode_And_Name2(int CmnStateUserID)
    //{
    //    ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
    //    return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name2");

    //}
    public DataSet Fill_VillageCode_And_Name2(int CmnStateUserID)
    {
        ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name2");

    }
    //Changed by Deepak
    public DataSet Fill_VillageCodes(int CmnStateUserID)
    {
        ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode");

    }
    public DataSet Fill_VillageCode_And_Name1(int CmnStateUserID)
    {
       // ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_VillageCode_And_Name1");
    }
    public DataSet Fill_VillageCode_TigerReserve(int CmnStateUserID)
    {
         ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("Sp_Tiger_Fill_VillageCode_And_Name1");
    }
    public DataSet Fill_VillageCode_AndName(int userid)
    {
        ObjDB.AddParameter("@CmnreserveID", userid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Village");
    }
    
    public DataSet Fill_VillageCode(int CmnStateUserID)
    {
        ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("Proc_Fill_TigerVillage");

    }
    public DataSet VillageRelocationSuperadminByStateID(int CmnStateUserID)
    {
        ObjDB.AddParameter("@stateID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("GetTigerVillageByStateID");

    }
    public DataSet GetAllvillage()
    {
        // ObjDB.AddParameter("@stateID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("GetAllTigerVillage");

    }
    public DataSet GetVillageNotRelocatedSuper(int CmnStateUserID)
    {
        ObjDB.AddParameter("@stateID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("GetTigerVillageByStateID");

    }
    public DataSet Get_Relocation_Village_By_ID(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_RelocationVillage_By_VillId");


    }
    public DataSet Get_CDPAmount_By_Village_ID(string villageid)
    {
        ObjDB.AddParameter("@VILL_ID", villageid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_CDPAmount_By_VillId");


    }

    public bool Delete_BY_CDP_WRK_INFO_ID_From_Original(int CdpPrimaryID)
    {

        try
        {
            ObjDB.AddParameter("@CdpPrimaryID", CdpPrimaryID);
            // ObjDB.AddParameter("@CDP_WRK_INFO_ID", CDP_WRK_INFO_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_BY_CDP_WRK_INFO_ID_From_Original");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }

    }
    public DataSet Get_CDPTempData_By_CDP_WRK_INFO_ID(int CDP_WRK_INFO_ID)
    {
        ObjDB.AddParameter("@CDP_WRK_INFO_ID", CDP_WRK_INFO_ID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_CDP_TEMP");


    }
    public DataSet Get_CDPTempData_By_CDP_WRK_INFO_ID1(int CdpPrimaryID)
    {
        ObjDB.AddParameter("@CdpPrimaryID", CdpPrimaryID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_CDP_TEMP1");


    }
    public DataSet Get_CDPData_By_CDP_WRK_INFO_ID(int CDP_WRK_INFO_ID)
    {
        ObjDB.AddParameter("@CdpPrimaryID", CDP_WRK_INFO_ID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_CDP");
    }
    public DataSet CheckCDP_details(string id)
    {
        ObjDB.AddParameter("@VIIL_ID", id);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckCDP_details");
    }
    public DataSet CheckForLegalForm(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckForLegalForm");
    }

    public DataSet CheckForNGO(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckForNGO");
    }
    public DataSet Proc_DisplayFamilyByVillageSchme(string v_id, string r_id, string sc_id, string TigerReserveName, string Statename)
    {
        ObjDB.AddParameter("@VILL_ID", v_id);
        ObjDB.AddParameter("@RSRV_ID", r_id);
        ObjDB.AddParameter("@SCHM_ID", sc_id);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@StateName", Statename);
        return ObjDB.ExecuteDataSet("proc_DisplayFamilyByVillageScehme");

    }
    public DataSet FillVillageCode(int userid)
    {
        ObjDB.AddParameter("@UserID", userid);
        return ObjDB.ExecuteDataSet("proc_FillVillageCode");
    }
    public DataSet FillVillageCode3(int CmnTigerReserveUserID)
    {
        ObjDB.AddParameter("@CmnTigerReserveUserID", CmnTigerReserveUserID);
        return ObjDB.ExecuteDataSet("proc_FillVillageCode3");
    }
    public DataSet FillVillageCode2(int CmnStateUserID)
    {
        ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("proc_FillVillageCode2");
    }
    public DataSet FillVillageCode1(int CmnStateUserID)
    {
        // ObjDB.AddParameter("@CmnStateUserID", CmnStateUserID);
        return ObjDB.ExecuteDataSet("proc_FillVillageCode1");
    }
    public DataSet Ds_BindTigerReserveName()
    {
        ObjDB.AddParameter("@Userid", HttpContext.Current.Session["User_Id"]);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveAssignReserveList");
    }
    public DataSet BindTigerReserveName(string ID)
    {
        ObjDB.AddParameter("@StateID", ID);
        return ObjDB.ExecuteDataSet("GetTigerReserve");
    }
    //Added By Deepak  
    public DataSet BindTigerReservefile(int State)
    {
        ObjDB.AddParameter("@State", State);
        return ObjDB.ExecuteDataSet("SpGetTigerReserve_forfile");
    }
    public DataSet BindTigerReserves(int State,int stateid)
    {
        ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["User_Id"]);
        ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["ntca_StateID"]);		
        return ObjDB.ExecuteDataSet("Proc_Get_All_Tigers");
    }
    public DataSet BindTigerReserve(int State)
    {
        ObjDB.AddParameter("@SateId", State);
        return ObjDB.ExecuteDataSet("SpGetTigerReserve");
    }
    public DataSet Ds_BindTigerReserveName2()
    {
        ObjDB.AddParameter("@PermissionState", HttpContext.Current.Session["PermissionState"]);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveAssignStateUserList");
    }
    public DataSet Ds_BindTigerReserveNameRPG(int? StateID)
    {
        ObjDB.AddParameter("@PermissionState", StateID);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveAssignStateUserList");
    }
    public DataSet Ds_BindTigerReserveNameRPG1(string StateName)
    {
        ObjDB.AddParameter("@StateName", StateName);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveHomeMain");
    }
    public DataSet Ds_BindTigerReserveName1()
    {
        // ObjDB.AddParameter("@PermissionState", HttpContext.Current.Session["PermissionState"]);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveNTCAList");
    }
    public DataSet Ds_BindTigerReserveName1Modified(string StateName)
    {
        ObjDB.AddParameter("@StateName", StateName);
        return ObjDB.ExecuteDataSet("spGetTigerReserveUsedReviese");
    }
    #region Function for Bindd  Distric
    public DataSet BindDistricPost(int ID)
    {
        ObjDB.AddParameter("@StateID", ID);
        return ObjDB.ExecuteDataSet("sp_GetDistricPost");
    }
    #endregion
    #region Function for Bindd  Village 
   public DataSet BindVillagePost(int ID,int p)
    {
        ObjDB.AddParameter("@TigerReserveID", ID);
        ObjDB.AddParameter("@ValiDate", p);
        return ObjDB.ExecuteDataSet("sp_GetVillagePost");
    }
    #endregion
    #region Function for Tiger Reserver Bind
    public DataSet BindTigerReservePost(int ID)
    {
        ObjDB.AddParameter("@StateID", ID);
        return ObjDB.ExecuteDataSet("sp_GetTigerReservePost");
    }
    #endregion
    public DataSet DsConsoldateBindTigerReserve(string StateID)
    {
        ObjDB.AddParameter("@StateID", StateID);
        return ObjDB.ExecuteDataSet("SpGetTigerReserveOnBasisStateID");
    }
    public DataSet DsConsoldateBindVillageName(string TigerReserveid)
    {
        ObjDB.AddParameter("@TigerReserveid", TigerReserveid);
        return ObjDB.ExecuteDataSet("SpVillageListOnBasisTigerReserveID");
    }

    public DataSet DsPostConsoldateBindVillageName(string TigerReserveid)
    {
        ObjDB.AddParameter("@TigerReserveid", TigerReserveid);
        return ObjDB.ExecuteDataSet("SpPostVillageListOnBasisTigerReserveID");
    }
    public DataSet DsConsoldateBindFamilyHeadName(string VillageID)
    {
        ObjDB.AddParameter("@Villageid", VillageID);
        return ObjDB.ExecuteDataSet("FamilyHeadOnBasisVillageID");
    }
    public DataSet DsConsoldateBindCdpAgencyName(string VillageID)
    {
        ObjDB.AddParameter("@VILL_ID", VillageID);
        return ObjDB.ExecuteDataSet("spCdpAgencyNamereport");
    }
    public DataSet DsConsoldateBindFamilyMemberName(string FMLY_ID)
    {
        ObjDB.AddParameter("@FMLY_ID", FMLY_ID);
        return ObjDB.ExecuteDataSet("FamilyMemberOnBasisVillageID");
    }
    public DataSet Proc_Get_All_Villages()
    {
        return ObjDB.ExecuteDataSet("Proc_Get_All_Villages");

    }

    public DataSet Proc_Display_Legal_Form(string Villageid)
    {
        ObjDB.AddParameter("@VILL_ID", Villageid);
        return ObjDB.ExecuteDataSet("Proc_Display_Legal_Form");

    }
    #region Function for Get Village ID --Deepak 

    public DataSet GetVillageID(VillageEntity objdata)
    {
        try
        {
            ObjDB.AddParameter("@UserID", objdata.UserID);
            ObjDB.AddParameter("@GP_ID", objdata.StateID);
            return ObjDB.ExecuteDataSet("NTCA_GetVillageID");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save Survey Details
    public int SaveSurvey_Details(TigerReserveOB _tigerOb)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@rowcount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ObjDB.AddParameter(param[0]);
            ObjDB.Parameters.Add(new SqlParameter("@SurveyDate", _tigerOb.SurveyDate));
            ObjDB.Parameters.Add(new SqlParameter("@Action", _tigerOb.Action));
            ObjDB.Parameters.Add(new SqlParameter("@SurveyorName", _tigerOb.Surveyor));
            ObjDB.Parameters.Add(new SqlParameter("@DesignationSurveyor", _tigerOb.DesignationSurveyor));
            ObjDB.Parameters.Add(new SqlParameter("@StateID", _tigerOb.StateID));
            ObjDB.Parameters.Add(new SqlParameter("@Dist", _tigerOb.Dist));
            ObjDB.Parameters.Add(new SqlParameter("@TigerReserveid", _tigerOb.TigerReserveid));
            ObjDB.Parameters.Add(new SqlParameter("@VillageID", _tigerOb.VillageID));
            ObjDB.Parameters.Add(new SqlParameter("@latitude", _tigerOb.latitude));
            ObjDB.Parameters.Add(new SqlParameter("@longitude", _tigerOb.longitude));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAnganwadi", _tigerOb.RdbAnganwadi));
            ObjDB.Parameters.Add(new SqlParameter("@Anganwadi", _tigerOb.Anganwadi));
            ObjDB.Parameters.Add(new SqlParameter("@RdbPanchayatOffice", _tigerOb.RdbPanchayatOffice));
            ObjDB.Parameters.Add(new SqlParameter("@PanchayatOffice", _tigerOb.PanchayatOffice));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAllWeatherRoad", _tigerOb.RdbAllWeatherRoad));
            ObjDB.Parameters.Add(new SqlParameter("@AllWeatherRoad", _tigerOb.AllWeatherRoad));
            ObjDB.Parameters.Add(new SqlParameter("@RdbPostOffice", _tigerOb.RdbPostOffice));
            ObjDB.Parameters.Add(new SqlParameter("@PostOffice", _tigerOb.PostOffice));
            ObjDB.Parameters.Add(new SqlParameter("@RdbBank", _tigerOb.RdbBank));
            ObjDB.Parameters.Add(new SqlParameter("@Bank", _tigerOb.Bank));
            ObjDB.Parameters.Add(new SqlParameter("@RdbPDSShop", _tigerOb.RdbPDSShop));
            ObjDB.Parameters.Add(new SqlParameter("@PDSShop", _tigerOb.PDSShop));
            ObjDB.Parameters.Add(new SqlParameter("@RdbPublicTelephonePCo", _tigerOb.RdbPublicTelephonePCo));
            ObjDB.Parameters.Add(new SqlParameter("@PublicTelephonePCo", _tigerOb.PublicTelephonePCo));
            ObjDB.Parameters.Add(new SqlParameter("@RdbMobileSignal", _tigerOb.RdbMobileSignal));
            ObjDB.Parameters.Add(new SqlParameter("@MobileSignal", _tigerOb.MobileSignal));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessibiliythealthCare", _tigerOb.RdbAccessibiliythealthCare));
            ObjDB.Parameters.Add(new SqlParameter("@AccessibiliythealthCare", _tigerOb.AccessibiliythealthCare));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessibiliyRoad", _tigerOb.RdbAccessibiliyRoad));
            ObjDB.Parameters.Add(new SqlParameter("@AccessibiliyRoad", _tigerOb.AccessibiliyRoad));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessbilitySchool", _tigerOb.RdbAccessbilitySchool));
            ObjDB.Parameters.Add(new SqlParameter("@PrimarySchool", _tigerOb.Primary));
            ObjDB.Parameters.Add(new SqlParameter("@SecondarySchool", _tigerOb.Secondary));
            ObjDB.Parameters.Add(new SqlParameter("@HighSchool", _tigerOb.HighSchool));
            ObjDB.Parameters.Add(new SqlParameter("@College", _tigerOb.College));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessbilityElectrif", _tigerOb.RdbAccessbilityElectrif));
            ObjDB.Parameters.Add(new SqlParameter("@AccessbilityElectrif", _tigerOb.AccessbilityElectrif));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessiblityVeterinary", _tigerOb.RdbAccessiblityVeterinary));
            ObjDB.Parameters.Add(new SqlParameter("@AccessiblityVeterinary", _tigerOb.AccessiblityVeterinary));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAvenuesEmployment", _tigerOb.RdbAvenuesEmployment));
            ObjDB.Parameters.Add(new SqlParameter("@EmploymentPrimary", _tigerOb.EmploymentPrimary));
            ObjDB.Parameters.Add(new SqlParameter("@EmploymentSecondary", _tigerOb.EmploymentSecondary));
            ObjDB.Parameters.Add(new SqlParameter("@RdbHumanWildlifecon", _tigerOb.RdbHumanWildlifecon));
            ObjDB.Parameters.Add(new SqlParameter("@HumanWildlifecon", _tigerOb.HumanWildlifecon));
            ObjDB.Parameters.Add(new SqlParameter("@RdbAccessFireFodNwfps", _tigerOb.RdbAccessFireFodNwfps));
            ObjDB.Parameters.Add(new SqlParameter("@AccessFireFodNwfps", _tigerOb.AccessFireFodNwfps));
            ObjDB.Parameters.Add(new SqlParameter("@UserID", _tigerOb.CreatedByUserID));
            ObjDB.Parameters.Add(new SqlParameter("@PostStateID", _tigerOb.PostStateID));
            ObjDB.Parameters.Add(new SqlParameter("@PostReserveID", _tigerOb.PostReserveID));
            ObjDB.Parameters.Add(new SqlParameter("@PostVillageName", _tigerOb.postVillageName));
            ObjDB.Parameters.Add(new SqlParameter("@LegalStatus", _tigerOb.LegalStatus));
            ObjDB.Parameters.Add(new SqlParameter("@id", _tigerOb.EditedUserID));
             ObjDB.ExecuteNonQuery("SaveSuryeDetail");
            int Result = Convert.ToInt16(param[0].Value);
            return Result;

        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            ObjDB.Dispose();
        }
    }
    #endregion
    #region Function for Bindd  Village 
    public DataSet BindVillagesurvey(int ID)
    {
        ObjDB.AddParameter("@TigerReserveID", ID);
        return ObjDB.ExecuteDataSet("BindVillagesurvey");
    }
    #endregion

    #region Function for Get record Post survey Record
    public DataSet GetPostSurveyDetail(TigerReserveOB _tigerOb)
    {
        try
        {
            ObjDB.AddParameter("@VillageID", _tigerOb.VillageID);
            ObjDB.AddParameter("@TigerReserveID", _tigerOb.TigerReserveid);
            ObjDB.AddParameter("@StateID", _tigerOb.sVillageID);
            ObjDB.AddParameter("@UserID", _tigerOb.CreatedByUserID);
            ObjDB.AddParameter("@flag", _tigerOb.flag);
            ObjDB.AddParameter("@TigerReserve", HttpContext.Current.Session["TigerReserveid"]);
            
            return ObjDB.ExecuteDataSet("sp_GetPostSurveyDetail");
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for Post Survey Form Detail
    public DataSet GetPostformrecord(TigerReserveOB _tigerOb)
    {
        try
        {
            ObjDB.AddParameter("@VillageID ", _tigerOb.VillageID);
            return ObjDB.ExecuteDataSet("NTCA_POSTSURVEYFORMDETAIL");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Get record Post survey Record
    public DataSet PostPrivew(TigerReserveOB _tigerOb)
    {
        try
        {
            ObjDB.AddParameter("@VillageID", _tigerOb.VillageID);
            return ObjDB.ExecuteDataSet("sp_GetPostPrivew");
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region founction for Final Submit
    public int finalSubmit(TigerReserveOB _tigerOb)
    {
        try
        {
            ObjDB.AddParameter("@VillageID", _tigerOb.VillageID);
            return ObjDB.ExecuteNonQuery("POST_FINALSUBMIT");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for status Check
    public DataSet CheckfinalStatus(TigerReserveOB _tigerOb)
    {
        try
        {
            ObjDB.AddParameter("@VillageID", _tigerOb.VillageID);
            return ObjDB.ExecuteDataSet("sp_CheckfinalStatus");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region function for Bind TigerReserve
    public DataSet GetTigerReserve(TigerReserveOB obj)
    {
        ObjDB.AddParameter("@StateID", obj.StateID);
        ObjDB.AddParameter("@ReserveID", obj.TigerReserveid);
        return ObjDB.ExecuteDataSet("PostTigerReserve");
    }
    #endregion


    #region function for Bind postgram
    public DataSet GetPostGram(TigerReserveOB obj)
    {
        ObjDB.AddParameter("@distictId", obj.Dist);
        return ObjDB.ExecuteDataSet("postgrampanchayat");
    }
    #endregion

    #region function for change state status
    public bool ChangeStatusByState(VillageEntity VillEntity_Obj)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@rowcount", SqlDbType.Bit);
        param[0].Direction = ParameterDirection.Output;
        ObjDB.AddParameter(param[0]);
        ObjDB.AddParameter("@id", VillEntity_Obj.VillageID);
        ObjDB.AddParameter("@flag", VillEntity_Obj.flag);
        ObjDB.ExecuteNonQuery("ByChangeStatusByState");
        bool Result = Convert.ToBoolean(param[0].Value);
        return Result;
    }
    #endregion

    #region function for change Ntca status
    public bool ChangeStatusByNTCA(VillageEntity VillEntity_Obj)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@rowcount", SqlDbType.Bit);
        param[0].Direction = ParameterDirection.Output;
        ObjDB.AddParameter(param[0]);
        ObjDB.AddParameter("@id", VillEntity_Obj.VillageID);
        ObjDB.AddParameter("@flag", VillEntity_Obj.flag);
        ObjDB.ExecuteNonQuery("ByChangeStatusByNTCA");
        bool Result = Convert.ToBoolean(param[0].Value);
        return Result;
    }
    #endregion

    public DataSet Display_FundAmoutAsPerOptions(VillageEntity Vill_Entity)
    {
        ObjDB.AddParameter("@v_id", Vill_Entity.CmnStateID);
        ObjDB.AddParameter("@option", Vill_Entity.Action);
       // ObjDB.AddParameter("@UserID", Vill_Entity.UserID);
        return ObjDB.ExecuteDataSet("fund_GetAmountUsingOption");

    }
    public DataSet Display_FundDisplayFundDetails()
    {

        return ObjDB.ExecuteDataSet("fund_DisplayAvaliableFunds");

    }
}

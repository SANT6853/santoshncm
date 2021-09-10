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
/// Summary description for FamilyDB
/// </summary>
public class FamilyDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    int i = 0;
    public DataSet GenerateFamilyId()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Generate_FamilyId");
    }
    public DataSet GenerateFamilyCode(string code)
    {
        ObjDB.AddParameter("@reserandvillid", code);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Generate_FamilyCode");
    
    }
    public DataSet CheckDuplicacyFor_Family_Code(string code)
    {
        ObjDB.AddParameter("@FMLY_REG_CD", code);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckDuplicacyFor_Family_Code");
    }
    public DataSet Display_All_Members(string memberid)
    {
        ObjDB.AddParameter("@FMLY_MEMB_ID", memberid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members");
    }
    public DataSet Display_All_Members_From_Original_Table(FamilyMemberOB familyObject)
    {
        try
        {
            
            ObjDB.AddParameter("@FMLY_MEMB_ID", familyObject.MemberID);


            //DataSet ds = ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members_From_Original_Table");
            DataSet ds = ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members_New");
            return ds;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Delete_All_Members(string memberid)
    {
        ObjDB.AddParameter("@FMLY_MEMB_ID", memberid);
        int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_All_Members_Or_By_Id");

    }



    public bool AttachmentDeletePhoto(Family_DetailEntity FMLYMEM_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", FMLYMEM_ENT_Obj.FMLY_MEMB_IDs);
            ObjDB.AddParameter("@Action", FMLYMEM_ENT_Obj.Action);
            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteVillagePhoto");
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
    public bool AttachmentDeletePhoto1(Family_DetailEntity FMLYMEM_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", FMLYMEM_ENT_Obj.FMLY_MEMB_IDs);
            ObjDB.AddParameter("@Action", FMLYMEM_ENT_Obj.Action);
            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteVillagePhoto1");
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
    public bool AttachmentDeleteCardPhoto(Family_DetailEntity FMLYMEM_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", FMLYMEM_ENT_Obj.FMLY_MEMB_IDs);
            ObjDB.AddParameter("@Action", FMLYMEM_ENT_Obj.Action);
            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteVillageCardPhoto");
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
    public bool AttachmentDeleteCardPhoto1(Family_DetailEntity FMLYMEM_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", FMLYMEM_ENT_Obj.FMLY_MEMB_IDs);
            ObjDB.AddParameter("@Action", FMLYMEM_ENT_Obj.Action);
            try
            {
                i = ObjDB.ExecuteNonQuery("spDeleteVillageCardPhoto1");
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
    
    public bool Add_Family_Members(Family_DetailEntity FMLYMEM_ENT_Obj , string fid)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            //ObjDB.AddParameter("@FMLY_ID", fid);
            ObjDB.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            ObjDB.AddParameter("@FMLY_MEMB_NM", FMLYMEM_ENT_Obj._FMLY_MEMB_NM);
            ObjDB.AddParameter("@FMLY_MEMB_REL", FMLYMEM_ENT_Obj._FMLY_MEMB_REL);
            ObjDB.AddParameter("@FMLY_MEMB_AGE", FMLYMEM_ENT_Obj._FMLY_MEMB_AGE);
            ObjDB.AddParameter("@FMLY_MEMB_SEX", FMLYMEM_ENT_Obj._FMLY_MEMB_SEX);
            ObjDB.AddParameter("@FMLY_MEMB_EDU", FMLYMEM_ENT_Obj._FMLY_MEMB_EDU);
            ObjDB.AddParameter("@FMLY_MEMB_ANUL_INCM", FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM);
            ObjDB.AddParameter("@FATHER_NM", FMLYMEM_ENT_Obj._FATHER_NM);
            ObjDB.AddParameter("@FMLY_MEMB_CAST", FMLYMEM_ENT_Obj._FMLY_MEMB_CAST);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO);
            ObjDB.AddParameter("@FMLY_MEMB_CONT_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO);
            ObjDB.AddParameter("@FMLY_MEMB_OCC", FMLYMEM_ENT_Obj._FMLY_MEMB_OCC);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NAME", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME);
            ObjDB.AddParameter("@RANDOM_NO", FMLYMEM_ENT_Obj._RANDOM_NO);
            //6june
            ObjDB.AddParameter("@DOB", FMLYMEM_ENT_Obj.DOB);
            ObjDB.AddParameter("@PenCard", FMLYMEM_ENT_Obj.PenCard);
            ObjDB.AddParameter("@AdhaarCard", FMLYMEM_ENT_Obj.AdhaarCard);
            ObjDB.AddParameter("@Others", FMLYMEM_ENT_Obj.Others);
            ObjDB.AddParameter("@Transgender", FMLYMEM_ENT_Obj.Transgender);
            ObjDB.AddParameter("@NoBeneficiary", FMLYMEM_ENT_Obj.NoBeneficiary);
            ObjDB.AddParameter("@MaritalStatus", FMLYMEM_ENT_Obj.MaritalStatus);
            ObjDB.AddParameter("@BankNameMobile", FMLYMEM_ENT_Obj.BankNameMobile);
            ObjDB.AddParameter("@BankPostAccountNo", FMLYMEM_ENT_Obj.BankPostAccountNo);
            ObjDB.AddParameter("@BankPostOfficeName", FMLYMEM_ENT_Obj.BankPostOfficeName);
            ObjDB.AddParameter("@IFSC", FMLYMEM_ENT_Obj.IFSC);
            ObjDB.AddParameter("@BankPostOfficeAdress", FMLYMEM_ENT_Obj.BankPostOfficeAdress);
            ObjDB.AddParameter("@AadharNo", FMLYMEM_ENT_Obj.AadharNo);

            ObjDB.AddParameter("@Photo", FMLYMEM_ENT_Obj.Photo);
            ObjDB.AddParameter("@IdentityCardPhoto", FMLYMEM_ENT_Obj.IdentityCardPhoto);
			ObjDB.AddParameter("@BenAddress", FMLYMEM_ENT_Obj.BenAddress); //Added By Deepak
            ObjDB.AddParameter("@BenMobile", FMLYMEM_ENT_Obj.BenMobile);
            ObjDB.AddParameter("@IdentityCardPhotoTitle", FMLYMEM_ENT_Obj.IdentityCardPhotoTitle);
            var commanMISTableDetailParam = new SqlParameter("@IdentityCard", FMLYMEM_ENT_Obj.IdentityCard);
            commanMISTableDetailParam.SqlDbType = SqlDbType.Structured;
            ObjDB.Parameters.Add(commanMISTableDetailParam);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Family_Member_new");
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

    public bool Add_Family_Members_From_Original(Family_DetailEntity FMLYMEM_ENT_Obj, string fid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fid);
            ObjDB.AddParameter("@FMLY_MEMB_NM", FMLYMEM_ENT_Obj._FMLY_MEMB_NM);
            ObjDB.AddParameter("@FMLY_MEMB_REL", FMLYMEM_ENT_Obj._FMLY_MEMB_REL);
            ObjDB.AddParameter("@FMLY_MEMB_AGE", FMLYMEM_ENT_Obj._FMLY_MEMB_AGE);
            ObjDB.AddParameter("@FMLY_MEMB_SEX", FMLYMEM_ENT_Obj._FMLY_MEMB_SEX);
            ObjDB.AddParameter("@FMLY_MEMB_EDU", FMLYMEM_ENT_Obj._FMLY_MEMB_EDU);
            ObjDB.AddParameter("@FMLY_MEMB_ANUL_INCM", FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM);
            ObjDB.AddParameter("@FATHER_NM", FMLYMEM_ENT_Obj._FATHER_NM);
            ObjDB.AddParameter("@FMLY_MEMB_CAST", FMLYMEM_ENT_Obj._FMLY_MEMB_CAST);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO);
            ObjDB.AddParameter("@FMLY_MEMB_CONT_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO);
            ObjDB.AddParameter("@FMLY_MEMB_OCC", FMLYMEM_ENT_Obj._FMLY_MEMB_OCC);
            //6june
            ObjDB.AddParameter("@DOB", FMLYMEM_ENT_Obj.DOB);
            ObjDB.AddParameter("@PenCard", FMLYMEM_ENT_Obj.PenCard);
            ObjDB.AddParameter("@AdhaarCard", FMLYMEM_ENT_Obj.AdhaarCard);
            ObjDB.AddParameter("@Others", FMLYMEM_ENT_Obj.Others);
            ObjDB.AddParameter("@Transgender", FMLYMEM_ENT_Obj.Transgender);
            ObjDB.AddParameter("@NoBeneficiary", FMLYMEM_ENT_Obj.NoBeneficiary);
            ObjDB.AddParameter("@MaritalStatus", FMLYMEM_ENT_Obj.MaritalStatus);
            ObjDB.AddParameter("@BankNameMobile", FMLYMEM_ENT_Obj.BankNameMobile);
            ObjDB.AddParameter("@BankPostAccountNo", FMLYMEM_ENT_Obj.BankPostAccountNo);
            ObjDB.AddParameter("@BankPostOfficeName", FMLYMEM_ENT_Obj.BankPostOfficeName);
            ObjDB.AddParameter("@IFSC", FMLYMEM_ENT_Obj.IFSC);
            ObjDB.AddParameter("@BankPostOfficeAdress", FMLYMEM_ENT_Obj.BankPostOfficeAdress);
            ObjDB.AddParameter("@AadharNo", FMLYMEM_ENT_Obj.AadharNo);
            ObjDB.AddParameter("@UserID", HttpContext.Current.Session["User_Id"]);

            ObjDB.AddParameter("@Photo", FMLYMEM_ENT_Obj.Photo);
            ObjDB.AddParameter("@IdentityCardPhoto", FMLYMEM_ENT_Obj.IdentityCardPhoto);
            ObjDB.AddParameter("@IdentityCardPhotoTitle", FMLYMEM_ENT_Obj.IdentityCardPhotoTitle);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Family_Member_From_Original");
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
    

    public int Add_Family(FamilyEntity FMLY_ENT_Obj,string villageid)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@rowcount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ObjDB.AddParameter(param[0]);
            ObjDB.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            ObjDB.AddParameter("@FMLY_REG_CD", FMLY_ENT_Obj._FMLY_REG_CD);
            ObjDB.AddParameter("@FMLY_NO_MEMB", FMLY_ENT_Obj._FMLY_NO_MEMB);
            ObjDB.AddParameter("@FMLY_VALID_ID_NO", FMLY_ENT_Obj._FMLY_VALID_ID_NO);
            ObjDB.AddParameter("@VILL_ID", villageid);
            ObjDB.AddParameter("@SCHM_ID", FMLY_ENT_Obj._SCHM_ID);
            ObjDB.AddParameter("@SURVEY_DT", FMLY_ENT_Obj._SURVEY_DT);
            ObjDB.AddParameter("@FMLY_RESI_LND", FMLY_ENT_Obj._FMLY_RESI_LND);
            ObjDB.AddParameter("@RESI_LND_STS", FMLY_ENT_Obj._RESI_LND_STS);
            ObjDB.AddParameter("@FMLY_WELLS", FMLY_ENT_Obj._FMLY_WELLS);
            ObjDB.AddParameter("@FMLY_TREES", FMLY_ENT_Obj._FMLY_TREES);
            ObjDB.AddParameter("@FMLY_OTHR_ASSETS", FMLY_ENT_Obj._FMLY_OTHR_ASSETS);
            ObjDB.AddParameter("@FMLY_LIVESTOCK", FMLY_ENT_Obj._FMLY_LIVESTOCK);
            ObjDB.AddParameter("@FMLY_COW_BUFF", FMLY_ENT_Obj._FMLY_COW_BUFF);
            ObjDB.AddParameter("@FMLY_SHEEP_GOAT", FMLY_ENT_Obj._FMLY_SHEEP_GOAT);
            ObjDB.AddParameter("@FMLY_OTHER_ANML", FMLY_ENT_Obj._FMLY_OTHER_ANML);
            ObjDB.AddParameter("@FMLY_AGRI_LND", FMLY_ENT_Obj._FMLY_AGRI_LND);
            ObjDB.AddParameter("@COMMENT", FMLY_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@GROUP_NM", FMLY_ENT_Obj._GROUP_NM);
            ObjDB.AddParameter("@FMLY_VALID_ID_NAME", FMLY_ENT_Obj._FMLY_VALID_ID_NAME);
            ObjDB.AddParameter("@RANDOM_NO", FMLY_ENT_Obj._RANDOM_NO);
            ObjDB.AddParameter("@RELOATION_PLACE", FMLY_ENT_Obj._RELOATION_PLACE);
            ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["CmnStateUser"]));
            ObjDB.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveUserID"]));
            ObjDB.AddParameter("@CmnDataOperatorUserID", Convert.ToInt32(HttpContext.Current.Session["CmnDataOperatorUserID"]));
            ObjDB.AddParameter("@CmnStateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
            ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveID"]));
            //5june naren
            ObjDB.AddParameter("@NoCows", FMLY_ENT_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", FMLY_ENT_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", FMLY_ENT_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", FMLY_ENT_Obj.NoGoat);
            ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Family");
            int i = Convert.ToInt16(param[0].Value);
            if (i > 0)
            {
                return i;
            }
            else
            {
                return i;
            }
        }
        catch (Exception e)
        {
            return i;
        }
    }
    public int Add_Family1(FamilyEntity FMLY_ENT_Obj, string villageid)
    {
        try
        {
            SqlParameter[] sql = new SqlParameter[1];
            sql[0] = new SqlParameter("@rowcount", SqlDbType.Int);
            sql[0].Direction = ParameterDirection.Output;
            ObjDB.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            ObjDB.AddParameter("@FMLY_REG_CD", FMLY_ENT_Obj._FMLY_REG_CD);
            ObjDB.AddParameter("@FMLY_NO_MEMB", FMLY_ENT_Obj._FMLY_NO_MEMB);
            ObjDB.AddParameter("@FMLY_VALID_ID_NO", FMLY_ENT_Obj._FMLY_VALID_ID_NO);
            ObjDB.AddParameter("@VILL_ID", villageid);
            ObjDB.AddParameter("@SCHM_ID", FMLY_ENT_Obj._SCHM_ID);
            ObjDB.AddParameter("@Scheme_ID_Other_Details", FMLY_ENT_Obj.OtherOptions);
            ObjDB.AddParameter("@SURVEY_DT", FMLY_ENT_Obj._SURVEY_DT);
            ObjDB.AddParameter("@FMLY_RESI_LND", FMLY_ENT_Obj._FMLY_RESI_LND);
            ObjDB.AddParameter("@RESI_LND_STS", FMLY_ENT_Obj._RESI_LND_STS);
            ObjDB.AddParameter("@FMLY_WELLS", FMLY_ENT_Obj._FMLY_WELLS);
            ObjDB.AddParameter("@FMLY_TREES", FMLY_ENT_Obj._FMLY_TREES);
            ObjDB.AddParameter("@FMLY_OTHR_ASSETS", FMLY_ENT_Obj._FMLY_OTHR_ASSETS);
            ObjDB.AddParameter("@FMLY_LIVESTOCK", FMLY_ENT_Obj._FMLY_LIVESTOCK);
            ObjDB.AddParameter("@FMLY_COW_BUFF", FMLY_ENT_Obj._FMLY_COW_BUFF);
            ObjDB.AddParameter("@FMLY_SHEEP_GOAT", FMLY_ENT_Obj._FMLY_SHEEP_GOAT);
            ObjDB.AddParameter("@FMLY_OTHER_ANML", FMLY_ENT_Obj._FMLY_OTHER_ANML);
            ObjDB.AddParameter("@FMLY_AGRI_LND", FMLY_ENT_Obj._FMLY_AGRI_LND);
            ObjDB.AddParameter("@COMMENT", FMLY_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@GROUP_NM", FMLY_ENT_Obj._GROUP_NM);
            ObjDB.AddParameter("@FMLY_VALID_ID_NAME", FMLY_ENT_Obj._FMLY_VALID_ID_NAME);
            ObjDB.AddParameter("@RANDOM_NO", FMLY_ENT_Obj._RANDOM_NO);
            ObjDB.AddParameter("@RELOATION_PLACE", FMLY_ENT_Obj._RELOATION_PLACE);

          //  ObjDB.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["CmnStateUser"]));
           // ObjDB.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveUserID"]));
           // ObjDB.AddParameter("@CmnDataOperatorUserID", Convert.ToInt32(HttpContext.Current.Session["CmnDataOperatorUserID"]));
          //  ObjDB.AddParameter("@CmnStateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
          //  ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", Convert.ToInt32(HttpContext.Current.Session["CmnTigerReserveID"]));
            //5june naren
            ObjDB.AddParameter("@NoCows", FMLY_ENT_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", FMLY_ENT_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", FMLY_ENT_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", FMLY_ENT_Obj.NoGoat);
            ObjDB.AddParameter(sql[0]);
            ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Family");
            int i = Convert.ToInt16(sql[0].Value);
            if (i > 0)
            {
                return i;
            }
            else
            {
                return i;
            }
        }
        catch (Exception e)
        {
            return i;
        }
    }


    public bool Update_Family_Member(Family_DetailEntity FMLYMEM_ENT_Obj, string mid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", mid);           
            ObjDB.AddParameter("@FMLY_MEMB_NM", FMLYMEM_ENT_Obj._FMLY_MEMB_NM);
            ObjDB.AddParameter("@FMLY_MEMB_REL", FMLYMEM_ENT_Obj._FMLY_MEMB_REL);
            ObjDB.AddParameter("@FMLY_MEMB_AGE", FMLYMEM_ENT_Obj._FMLY_MEMB_AGE);
            ObjDB.AddParameter("@FMLY_MEMB_SEX", FMLYMEM_ENT_Obj._FMLY_MEMB_SEX);
            ObjDB.AddParameter("@FMLY_MEMB_EDU", FMLYMEM_ENT_Obj._FMLY_MEMB_EDU);
            ObjDB.AddParameter("@FMLY_MEMB_ANUL_INCM", FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM);
            ObjDB.AddParameter("@FATHER_NM", FMLYMEM_ENT_Obj._FATHER_NM);
            ObjDB.AddParameter("@FMLY_MEMB_CAST", FMLYMEM_ENT_Obj._FMLY_MEMB_CAST);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO);
            ObjDB.AddParameter("@FMLY_MEMB_CONT_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO);
            ObjDB.AddParameter("@FMLY_MEMB_OCC", FMLYMEM_ENT_Obj._FMLY_MEMB_OCC);
            //6june
            ObjDB.AddParameter("@DOB", FMLYMEM_ENT_Obj.DOB);
            ObjDB.AddParameter("@PenCard", FMLYMEM_ENT_Obj.PenCard);
            ObjDB.AddParameter("@AdhaarCard", FMLYMEM_ENT_Obj.AdhaarCard);
            ObjDB.AddParameter("@Others", FMLYMEM_ENT_Obj.Others);
            ObjDB.AddParameter("@Transgender", FMLYMEM_ENT_Obj.Transgender);
            ObjDB.AddParameter("@NoBeneficiary", FMLYMEM_ENT_Obj.NoBeneficiary);
            ObjDB.AddParameter("@MaritalStatus", FMLYMEM_ENT_Obj.MaritalStatus);
            ObjDB.AddParameter("@BankNameMobile", FMLYMEM_ENT_Obj.BankNameMobile);
            ObjDB.AddParameter("@BankPostAccountNo", FMLYMEM_ENT_Obj.BankPostAccountNo);
            ObjDB.AddParameter("@BankPostOfficeName", FMLYMEM_ENT_Obj.BankPostOfficeName);
            ObjDB.AddParameter("@IFSC", FMLYMEM_ENT_Obj.IFSC);
            ObjDB.AddParameter("@BankPostOfficeAdress", FMLYMEM_ENT_Obj.BankPostOfficeAdress);
            ObjDB.AddParameter("@AadharNo", FMLYMEM_ENT_Obj.AadharNo);

            ObjDB.AddParameter("@Photo", FMLYMEM_ENT_Obj.Photo);
            ObjDB.AddParameter("@IdentityCardPhoto", FMLYMEM_ENT_Obj.IdentityCardPhoto);
            ObjDB.AddParameter("@IdentityCardPhotoTitle", FMLYMEM_ENT_Obj.IdentityCardPhotoTitle);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Family_Member");
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

     public bool Add_Family_Assets(FamilyAsstsEvaluationEntity FMLYASSTEVA_ENT_Obj,string fid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fid);
            ObjDB.AddParameter("@AGRI_LND_VAL", FMLYASSTEVA_ENT_Obj._AGRI_LND_VAL);
            ObjDB.AddParameter("@RES_LND_VAL", FMLYASSTEVA_ENT_Obj._RES_LND_VAL);
            ObjDB.AddParameter("@TREES_VAL", FMLYASSTEVA_ENT_Obj._TREES_VAL);
            ObjDB.AddParameter("@WELLS_VAL", FMLYASSTEVA_ENT_Obj._WELLS_VAL);
            ObjDB.AddParameter("@OTHERS_VAL", FMLYASSTEVA_ENT_Obj._OTHERS_VAL);
           

            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Family_Assets");
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

    public bool Update_Family_Member_For_Original_Table(Family_DetailEntity FMLYMEM_ENT_Obj, string mid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_MEMB_ID", mid);           
            ObjDB.AddParameter("@FMLY_MEMB_NM", FMLYMEM_ENT_Obj._FMLY_MEMB_NM);
            ObjDB.AddParameter("@FMLY_MEMB_REL", FMLYMEM_ENT_Obj._FMLY_MEMB_REL);
            ObjDB.AddParameter("@FMLY_MEMB_AGE", FMLYMEM_ENT_Obj._FMLY_MEMB_AGE);
            ObjDB.AddParameter("@FMLY_MEMB_SEX", FMLYMEM_ENT_Obj._FMLY_MEMB_SEX);
            ObjDB.AddParameter("@FMLY_MEMB_EDU", FMLYMEM_ENT_Obj._FMLY_MEMB_EDU);
            ObjDB.AddParameter("@FMLY_MEMB_ANUL_INCM", FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM);
            ObjDB.AddParameter("@FATHER_NM", FMLYMEM_ENT_Obj._FATHER_NM);
            ObjDB.AddParameter("@FMLY_MEMB_CAST", FMLYMEM_ENT_Obj._FMLY_MEMB_CAST);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO);
            ObjDB.AddParameter("@FMLY_MEMB_CONT_NO", FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO);
            ObjDB.AddParameter("@FMLY_MEMB_OCC", FMLYMEM_ENT_Obj._FMLY_MEMB_OCC);
            ObjDB.AddParameter("@FMLY_MEMB_ID_NAME", FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME);

            //6june
            ObjDB.AddParameter("@DOB", FMLYMEM_ENT_Obj.DOB);
            ObjDB.AddParameter("@PenCard", FMLYMEM_ENT_Obj.PenCard);
            ObjDB.AddParameter("@AdhaarCard", FMLYMEM_ENT_Obj.AdhaarCard);
            ObjDB.AddParameter("@Others", FMLYMEM_ENT_Obj.Others);
            ObjDB.AddParameter("@Transgender", FMLYMEM_ENT_Obj.Transgender);
            ObjDB.AddParameter("@NoBeneficiary", FMLYMEM_ENT_Obj.NoBeneficiary);
            ObjDB.AddParameter("@MaritalStatus", FMLYMEM_ENT_Obj.MaritalStatus);
            ObjDB.AddParameter("@BankNameMobile", FMLYMEM_ENT_Obj.BankNameMobile);
            ObjDB.AddParameter("@BankPostAccountNo", FMLYMEM_ENT_Obj.BankPostAccountNo);
            ObjDB.AddParameter("@BankPostOfficeName", FMLYMEM_ENT_Obj.BankPostOfficeName);
            ObjDB.AddParameter("@IFSC", FMLYMEM_ENT_Obj.IFSC);
            ObjDB.AddParameter("@BankPostOfficeAdress", FMLYMEM_ENT_Obj.BankPostOfficeAdress);
            ObjDB.AddParameter("@AadharNo", FMLYMEM_ENT_Obj.AadharNo);

            ObjDB.AddParameter("@Photo", FMLYMEM_ENT_Obj.Photo);
            ObjDB.AddParameter("@IdentityCardPhoto", FMLYMEM_ENT_Obj.IdentityCardPhoto);
            ObjDB.AddParameter("@IdentityCardPhotoTitle", FMLYMEM_ENT_Obj.IdentityCardPhotoTitle);
			 ObjDB.AddParameter("@BenAddress", FMLYMEM_ENT_Obj.BenAddress);
            ObjDB.AddParameter("@BenMobile", FMLYMEM_ENT_Obj.BenMobile);


            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Family_Member_For_Original_Table");
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
    public DataSet Display_Info_Family(int userid,string villageid)
    {
        ObjDB.AddParameter("@userid", userid);
        ObjDB.AddParameter("@VILL_ID", villageid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Family");
    
    }
    public DataSet Display_Info_FamilyByOption(string villageid,string schemeid, string relocation_status)
    {
        ObjDB.AddParameter("@VILL_ID", villageid);
        ObjDB.AddParameter("@SCHM_ID", schemeid);
        ObjDB.AddParameter("@FMLY_STAT", relocation_status);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption");
    
    }
    public DataSet GetSchemeIdByFamilyID(string  familyid)
    {
        ObjDB.AddParameter("@FMLY_ID", familyid);
       
        return ObjDB.ExecuteDataSet("Proc_Tiger_GetSchemeId_By_FamilyID");
    
    }
    public DataSet Proc_DisplayFamilyById(string villid, string fid, string TigerReserveName)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        return ObjDB.ExecuteDataSet("Proc_DisplayFamilyById");
    
    }
    public DataSet Display_Info_Family_By_FamilyID(string fid)
    {
        ObjDB.AddParameter("@FMLY_ID", fid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Family_By_FamilyID");

    }
    public DataSet GetGroupNameByGroupId(string gid)
    {
        ObjDB.AddParameter("@GRP_ID", gid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_GetGroupNameByGroupId");

    }

    public bool Update_Family(FamilyEntity FMLY_ENT_Obj, string fid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fid);
            ObjDB.AddParameter("@SCHM_ID", FMLY_ENT_Obj._SCHM_ID);
            ObjDB.AddParameter("@Scheme_ID_Other_Details", FMLY_ENT_Obj.OtherOptions);
            ObjDB.AddParameter("@GROUP_NM", FMLY_ENT_Obj._GROUP_NM);
            ObjDB.AddParameter("@FMLY_VALID_ID_NO", FMLY_ENT_Obj._FMLY_VALID_ID_NO);
            ObjDB.AddParameter("@FMLY_STAT", FMLY_ENT_Obj._FMLY_STAT);
            ObjDB.AddParameter("@SURVEY_DT", FMLY_ENT_Obj._SURVEY_DT);
            ObjDB.AddParameter("@FMLY_RESI_LND", FMLY_ENT_Obj._FMLY_RESI_LND);
            ObjDB.AddParameter("@RESI_LND_STS", FMLY_ENT_Obj._RESI_LND_STS);
            ObjDB.AddParameter("@FMLY_WELLS", FMLY_ENT_Obj._FMLY_WELLS);
            ObjDB.AddParameter("@FMLY_TREES", FMLY_ENT_Obj._FMLY_TREES);
            ObjDB.AddParameter("@FMLY_OTHR_ASSETS", FMLY_ENT_Obj._FMLY_OTHR_ASSETS);
            ObjDB.AddParameter("@FMLY_LIVESTOCK", FMLY_ENT_Obj._FMLY_LIVESTOCK);
            ObjDB.AddParameter("@FMLY_COW_BUFF", FMLY_ENT_Obj._FMLY_COW_BUFF);
            ObjDB.AddParameter("@FMLY_SHEEP_GOAT", FMLY_ENT_Obj._FMLY_SHEEP_GOAT);
            ObjDB.AddParameter("@FMLY_OTHER_ANML", FMLY_ENT_Obj._FMLY_OTHER_ANML);
            ObjDB.AddParameter("@FMLY_AGRI_LND", FMLY_ENT_Obj._FMLY_AGRI_LND);
            ObjDB.AddParameter("@COMMENT", FMLY_ENT_Obj._COMMENT);


            ObjDB.AddParameter("@FMLY_VALID_ID_NAME", FMLY_ENT_Obj._FMLY_VALID_ID_NAME);
            ObjDB.AddParameter("@RELOATION_PLACE", FMLY_ENT_Obj._RELOATION_PLACE);
            //5june naren
            ObjDB.AddParameter("@NoCows", FMLY_ENT_Obj.NoCows);
            ObjDB.AddParameter("@NoBuffalo", FMLY_ENT_Obj.NoBuffalo);
            ObjDB.AddParameter("@NoSheep", FMLY_ENT_Obj.NoSheep);
            ObjDB.AddParameter("@NoGoat", FMLY_ENT_Obj.NoGoat);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Family");
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
    public DataSet Display_All_Members_ForEdit(string mid, string familyid)
    {
        ObjDB.AddParameter("@FMLY_MEMB_ID", mid);
          ObjDB.AddParameter("@FMLY_ID", familyid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members_ForEdit");

    }

    public int Delete_All_Members_For_Edit(string memberid)
    {
        ObjDB.AddParameter("@FMLY_MEMB_ID", memberid);
        int i =  ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_All_Members_Or_By_Id_From_Original");
        return i;
        
    }
    public DataSet FillWork()
    {

        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Work");

    }
    public DataSet Get_CDP_ID_For_Work()
    {

        return ObjDB.ExecuteDataSet("Proc_Tiger_Get_CDP_ID_For_Work");

    }
    public bool AddWorkInTemp(AddworkEntity ADDWRKENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@CDP_WRK_ID", ADDWRKENT_Obj._CDP_WRK_ID);
            ObjDB.AddParameter("@GRP_ID", ADDWRKENT_Obj._GRP_ID);
            ObjDB.AddParameter("@CDP_INFO_ID", ADDWRKENT_Obj._CDP_INFO_ID);
            ObjDB.AddParameter("@CDP_ALLTD_AMT", ADDWRKENT_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_AMT_USD", ADDWRKENT_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_AGENCY", ADDWRKENT_Obj._CDP_AGENCY);
            ObjDB.AddParameter("@CDP_SITE_ADDRSS", ADDWRKENT_Obj._CDP_SITE_ADDRSS);
            ObjDB.AddParameter("@COMMENT", ADDWRKENT_Obj._COMMENT);
            
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Work_In_Temp");
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

    public DataSet BindAmountUsedAmountOFCDPAddtime(int? VILL_ID, int? RELOCATION_ID)
    {
        ObjDB.AddParameter("@VILL_ID", VILL_ID);
        ObjDB.AddParameter("@RELOCATION_ID", RELOCATION_ID);
        //BindAmountUsedAmountOFCDPAddtime
        return ObjDB.ExecuteDataSet("GetSumCdpAdd");
    }

    public DataSet Display_All_Work()
    {

        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Work");
    }
    public DataSet Display_All_Work1(int VillId)
    {
        ObjDB.AddParameter("@VillID", VillId);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Work1");
    }


    public bool AddCDPInfo(CDP_Info_Entity INFOEnt_Obj)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);

            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
            ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
            ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);

            //7june
            ObjDB.AddParameter("@AmntAllcteCdpVillRe", INFOEnt_Obj.AmntAllcteCdpVillRe);
            ObjDB.AddParameter("@AmountCentraState", INFOEnt_Obj.AmountCentraState);
            ObjDB.AddParameter("@FileNames", INFOEnt_Obj.FileNames);
            //7june end
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_CDP");
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
    public bool AddDelete(int id)
    {
        try
        {


            ObjDB.AddParameter("@CdpPrimaryID", id);
            //7june end
            int i = ObjDB.ExecuteNonQuery("DelTiger_CDP_Info_Management_Temp");
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

    public bool AddCDPInfo_From_Original(CDP_Info_Entity INFOEnt_Obj)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);

            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
            ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
            ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);

            //7june
            ObjDB.AddParameter("@AmntAllcteCdpVillRe", INFOEnt_Obj.AmntAllcteCdpVillRe);
            ObjDB.AddParameter("@AmountCentraState", INFOEnt_Obj.AmountCentraState);
            ObjDB.AddParameter("@FileNames", INFOEnt_Obj.FileNames);
            ObjDB.AddParameter("@CdpPrimaryID", INFOEnt_Obj.CdpPrimaryID);
            //7june end
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_CDP_Original");
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
    public void Delete_All_work(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_All_work_From_Temp");
        
    }

    public DataSet GetReserveCode(string reserveid)
    {
        ObjDB.AddParameter("@RSRV_ID", reserveid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Reserve_Code_And_Name");
    }

    public DataSet GetVillageCode(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Get_OthersIDs_By_VillId");
    }
    public DataSet Proc_Display_Installment(string fam_id, string scheme_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        ObjDB.AddParameter("@SCHM_ID", scheme_id);
        return ObjDB.ExecuteDataSet("Proc_Display_Installment");
    }
    public DataSet Proc_DisplayFamilyByGroup(string id)
    {
        ObjDB.AddParameter("@FMLY_ID", id);
        return ObjDB.ExecuteDataSet("Proc_DisplayFamilyByGroup");
    }
    public DataSet DisplayInstallment(string instid)
    {
        ObjDB.AddParameter("@INST_ISCM_ID", instid);
        return ObjDB.ExecuteDataSet("Tiger_Proc_Display_Installment_For_View");
    }
    public int delete_instalment(int familyid, int instalmentid)
    {
        ObjDB.AddParameter("@FMLY_ID", familyid);
        ObjDB.AddParameter("@INST_ISCM_ID", instalmentid);
        return ObjDB.ExecuteNonQuery("delete_instalment");
    }
    public DataSet DisplayFD(string fid)
    {
        ObjDB.AddParameter("@FAMILY_ID", fid);
        return ObjDB.ExecuteDataSet("Tiger_Proc_Display_FD_For_View");
    }
    public DataSet Display_IIOptionInstallment(string fam_id, string scheme_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        ObjDB.AddParameter("@SCHM_ID", scheme_id);
        return ObjDB.ExecuteDataSet("Proc_Display_IIOptionInstallment");
    }
    public DataSet Proc_Display_IIInstallment(string fam_id, string scheme_id)
    {

        ObjDB.AddParameter("@FMLY_ID", fam_id);
        ObjDB.AddParameter("@SCHM_ID", scheme_id);
        return ObjDB.ExecuteDataSet("Proc_Display_IIInstallment");

    }
    public DataSet Proc_check_FamilyId(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_check_FamilyId");

    }

    public DataSet Proc_Display_Asset(string f_id)
    {
        ObjDB.AddParameter("@FMLY_ID", f_id);
        return ObjDB.ExecuteDataSet("Proc_Display_Asset");

    }

    public DataSet Proc_DisplayFamilyMemberDetail(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_DisplayFamilyMemberDetail");
    }
    public DataSet Proc_DisplayHeadDetail(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_DisplayHeadDetail");

    }


    public DataSet Proc_Display_Holdername(string fam_id)
    {
        ObjDB.AddParameter("@FAMILY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_Display_Holdername");
    }


    public bool Update_CDPInfo(CDP_Info_Entity INFOEnt_Obj, int cdpwrkid)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);
            ObjDB.AddParameter("@CDP_WRK_INFO_ID", cdpwrkid);
            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
            ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
            ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);
            //7june
            ObjDB.AddParameter("@AmntAllcteCdpVillRe", INFOEnt_Obj.AmntAllcteCdpVillRe);
            ObjDB.AddParameter("@AmountCentraState", INFOEnt_Obj.AmountCentraState);
            ObjDB.AddParameter("@FileNames", INFOEnt_Obj.FileNames);
            //7june end
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_CDP");
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
    public bool Update_CDPInfo1(CDP_Info_Entity INFOEnt_Obj, int cdpwrkid)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);
            ObjDB.AddParameter("@CDP_WRK_INFO_ID", cdpwrkid);
            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
            ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
            ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);
            //7june
            ObjDB.AddParameter("@AmntAllcteCdpVillRe", INFOEnt_Obj.AmntAllcteCdpVillRe);
            ObjDB.AddParameter("@AmountCentraState", INFOEnt_Obj.AmountCentraState);
            ObjDB.AddParameter("@FileNames", INFOEnt_Obj.FileNames);
            ObjDB.AddParameter("@CdpPrimaryID", INFOEnt_Obj.CdpPrimaryID);
            //7june end
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_CDP1");
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

    public bool Update_CDPInfo_Fron_Original(CDP_Info_Entity INFOEnt_Obj, int cdpwrkid)
    {
        try
        {

            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);
            ObjDB.AddParameter("@CDP_WRK_INFO_ID", cdpwrkid);
            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
            ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
            ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
            ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);
            //7june
            ObjDB.AddParameter("@AmntAllcteCdpVillRe", INFOEnt_Obj.AmntAllcteCdpVillRe);
            ObjDB.AddParameter("@AmountCentraState", INFOEnt_Obj.AmountCentraState);
            ObjDB.AddParameter("@FileNames", INFOEnt_Obj.FileNames);
            ObjDB.AddParameter("@CdpPrimaryID", INFOEnt_Obj.CdpPrimaryID);
            //7june endCdpPrimaryID
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_CDPInfo_Fron_Original");
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
    public bool AddWorkIn_CDP_Info(CDP_Info_Entity INFOEnt_Obj)
    {

        try
        {
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);
            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);
            ObjDB.AddParameter("@CDP_STS_LND", INFOEnt_Obj._CDP_STS_LND);
            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);


            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_CDP_INFO");
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

    public bool UpdateWorkIn_CDP_Info(CDP_Info_Entity INFOEnt_Obj)
    {

        try
        {
            ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);
            ObjDB.AddParameter("@VILL_ID", INFOEnt_Obj._CDP_Village_ID);
            ObjDB.AddParameter("@CDP_STS_LND", INFOEnt_Obj._CDP_STS_LND);
            ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", INFOEnt_Obj._CDP_ALLTD_AMT);
            ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);


            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_CDP_INFO");
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

    public DataSet Proc_Display_CDPINFO(string villid, string TigerReserveName)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        return ObjDB.ExecuteDataSet("Proc_Display_CDPINFO");
    }
    public DataSet CdpAgencyDetailsDs(string villid, string TigerReserveName, string CdpAgencyname)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@CdpAgencyname", CdpAgencyname);
        return ObjDB.ExecuteDataSet("CdpAgencyDetails");
    }
    public DataSet NgoListDetails(string villid, string TigerReserveName, string NgoID)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@id", NgoID);
        return ObjDB.ExecuteDataSet("SpngoListDetails");
    }
    public DataSet Proc_Display_CDPINFOCdReport(string villid, string TigerReserveName,string stateName)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@TigerReserveName", TigerReserveName);
        ObjDB.AddParameter("@StateName", stateName);
        return ObjDB.ExecuteDataSet("Proc_Display_CDPINFOConsoldateReport");
    }

    public DataSet Display_All_Work_From_Original(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Work_From_Original");
    }
    public DataSet Get_Data_FromCDP_Info(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Get_Data_FromCDP_Info");
    }


    public bool Delete_Family(string  family_id)
    {

        try
        {

            ObjDB.AddParameter("@FMLY_ID", family_id);


            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_Family");
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
    public void Delete_All_Members_Via_Family_Id_From_Temp(long randnumber)
    {
        ObjDB.AddParameter("@RANDOM_NO", randnumber);
        int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_All_Members_Via_Family_Id_From_Temp");

    }
    public DataSet CheckMemberID(string fmid)
    {
        ObjDB.AddParameter("@FMLY_MEMB_ID", fmid);
       return ObjDB.ExecuteDataSet("Proc_Tiger_CheckMemberID");

    }
    public DataSet CheckDetailsof_FamilyHead(long  random)
    {
        ObjDB.AddParameter("@RANDOM_NO", random);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckDetailsof_FamilyHead");

    }
     public DataSet Display_All_Members_For_Add(string fid)
    {
        ObjDB.AddParameter("@FMLY_ID", fid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members_For_Add");

    }

    public DataSet Display_All_Members_For_Add_new(long random)
    {
        ObjDB.AddParameter("@RANDOM_NO", random);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Members_For_Add_new");

    }
    public bool Update_Family_Assets(FamilyAsstsEvaluationEntity FMLYASSTEVA_ENT_Obj, string fid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fid);
            ObjDB.AddParameter("@AGRI_LND_VAL", FMLYASSTEVA_ENT_Obj._AGRI_LND_VAL);
            ObjDB.AddParameter("@RES_LND_VAL", FMLYASSTEVA_ENT_Obj._RES_LND_VAL);
            ObjDB.AddParameter("@TREES_VAL", FMLYASSTEVA_ENT_Obj._TREES_VAL);
            ObjDB.AddParameter("@WELLS_VAL", FMLYASSTEVA_ENT_Obj._WELLS_VAL);
            ObjDB.AddParameter("@OTHERS_VAL", FMLYASSTEVA_ENT_Obj._OTHERS_VAL);


            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Family_Assets");
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
    public DataTable FillFamilyHeadName(string vid)
    {
        ObjDB.AddParameter("@Villageid", vid);
        return ObjDB.ExecuteDataSet("Proc_FillFamilyHeadName").Tables[0];

    }
    public DataTable BindFamilyHeadConsol(string TigerReserveID, string VILL_ID, string CmnStateID)
    {
        ObjDB.AddParameter("@TigerReserveID", TigerReserveID);
        ObjDB.AddParameter("@VILL_ID", VILL_ID);
        ObjDB.AddParameter("@CmnStateID", CmnStateID);
        return ObjDB.ExecuteDataSet("SpFamilyHeadDetailsConsol").Tables[0];

    }
    public DataTable BindCdpAgencyConsol(string TigerReserveID, string VILL_ID, string CmnStateID)
    {
        ObjDB.AddParameter("@TigerReserveID", TigerReserveID);
        ObjDB.AddParameter("@VILL_ID", VILL_ID);
        ObjDB.AddParameter("@CmnStateID", CmnStateID);
        return ObjDB.ExecuteDataSet("spCdpAgencyNamereport").Tables[0];

    }
    public DataTable BindNOgLIstConsol(string TigerReserveID, string VILL_ID,string stateid)
    {
        ObjDB.AddParameter("@TigerReserveid", TigerReserveID);
        ObjDB.AddParameter("@VillId", VILL_ID);
        ObjDB.AddParameter("@StateID", stateid);
        return ObjDB.ExecuteDataSet("spNgoList").Tables[0];

    }
    /**********  Change By Gaurav*************/
    public DataTable GetFamilyHeadNamenew(string strvid,int userid)
    {
        ObjDB.AddParameter("@VILL_ID", strvid);
        ObjDB.AddParameter("@UserID", userid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption1").Tables[0];

    }


    public DataTable GetFamilyHeadName(string strvid)
    {
        ObjDB.AddParameter("@VILL_ID", strvid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption1").Tables[0];

    }
    /********************&***/
    public DataSet Display_Info_FamilyByOption1(string villageid, string schemeid, string relocation_status, string fid,int userid)
    {
        if (villageid == "0")
        {
            villageid = null;
        }
        ObjDB.AddParameter("@VILL_ID", villageid);//0
        ObjDB.AddParameter("@SCHM_ID", schemeid);
        ObjDB.AddParameter("@FMLY_STAT", relocation_status);
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@userid", userid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption1");

    }
    public DataSet Display_Info_FamilyByOption13(string villageid, string schemeid, string relocation_status, string fid, int? CmnDataOperatorTigerReserveID)
    {
        if(villageid=="0")
        {
            villageid = null;
        }
        if (CmnDataOperatorTigerReserveID == 0)
        {
            CmnDataOperatorTigerReserveID = null;
        }
        ObjDB.AddParameter("@VILL_ID", villageid);
        ObjDB.AddParameter("@SCHM_ID", schemeid);
        ObjDB.AddParameter("@FMLY_STAT", relocation_status);
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@CmnTigerReserveUserID", HttpContext.Current.Session["User_Id"]);
        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", CmnDataOperatorTigerReserveID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption13");

    }
    public DataSet Display_Info_FamilyByOption12(string villageid, string schemeid, string relocation_status, string fid, int? CmnDataOperatorTigerReserveID)
    {
        if (villageid == "0")
        {
            villageid = null;
        }
        if (CmnDataOperatorTigerReserveID==0)
        {
            CmnDataOperatorTigerReserveID=null;
        }
        ObjDB.AddParameter("@VILL_ID", villageid);
        ObjDB.AddParameter("@SCHM_ID", schemeid);
        ObjDB.AddParameter("@FMLY_STAT", relocation_status);
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["User_Id"]);
        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", CmnDataOperatorTigerReserveID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption12");

    }
    public DataSet Display_Info_FamilyByOption11(string villageid, string schemeid, string relocation_status, string fid, int? CmnDataOperatorTigerReserveID, string stateName)
    {
        if (villageid == "0")
        {
            villageid = null;
        }
        if (CmnDataOperatorTigerReserveID == 0)
        {
            CmnDataOperatorTigerReserveID = null;
        }
        ObjDB.AddParameter("@VILL_ID", villageid);
        ObjDB.AddParameter("@stateName", stateName);
        ObjDB.AddParameter("@SCHM_ID", schemeid);
        ObjDB.AddParameter("@FMLY_STAT", relocation_status);
        ObjDB.AddParameter("@FMLY_ID", fid);
       // ObjDB.AddParameter("@CmnStateUserID", HttpContext.Current.Session["User_Id"]);
        ObjDB.AddParameter("@CmnDataOperatorTigerReserveID", CmnDataOperatorTigerReserveID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_FamilyByOption11");

    }
    public DataSet display_instalment_deatil(string fam_id)
    {

        ObjDB.AddParameter("@FMLY_ID", fam_id);

        return ObjDB.ExecuteDataSet("display_instalment_deatil");

    }
    public DataSet display_instalment_amount(string fam_id)
    {

        ObjDB.AddParameter("@FMLY_ID", fam_id);

        return ObjDB.ExecuteDataSet("display_instalment_amount");

    }

}


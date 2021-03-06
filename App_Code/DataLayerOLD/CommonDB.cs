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
using System.Web.Mail;
/// <summary>
/// Summary description for CommonDB
/// </summary>
public class CommonDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public DataSet FillStates_District_ReserveDB(string stateid, string reserveid)
    {
        ObjDB.AddParameter("@ST_ID", stateid);
        ObjDB.AddParameter("@RSRV_ID", reserveid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_States_District_Reserve");
    }
    public DataSet Get_District_and_Reserve_ID_By_State_Id(int stateid, string districtname, string reservename)
    {
        ObjDB.AddParameter("@ST_ID", stateid);
        ObjDB.AddParameter("@DT_NAME", districtname);
        ObjDB.AddParameter("@RSRV_AREA_NM", reservename);

        return ObjDB.ExecuteDataSet("Proc_Tiger_Get_District_and_Reserve_ID_By_State_Id");
    }
    public DataSet getprivillages(string userid)
    {
       
        ObjDB.AddParameter("@USR_LOG_ID", userid);
        return  ObjDB.ExecuteDataSet("Proc_Tiger_Get_Role_Of_User");
        
        
    }
    public DataSet Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(string stateid, string districtid, string reserveid, string tehsilid, string gpid)
    {
        ObjDB.AddParameter("@ST_ID", stateid);
        ObjDB.AddParameter("@DT_ID", districtid);
        ObjDB.AddParameter("@RSRV_ID", reserveid);
        ObjDB.AddParameter("@TH_ID", tehsilid);
        ObjDB.AddParameter("@GP_ID", gpid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs");

    }
    public DataSet GetDistrict(int stateid,int action)
    {
        ObjDB.AddParameter("@StateID", stateid);
        ObjDB.AddParameter("@Action", action);

        return ObjDB.ExecuteDataSet("DistrictTehsilGramPanchyat");

    }
    public DataSet GetVillageBasicDetails(string villID)
    {
        ObjDB.AddParameter("@VILL_ID", villID);       
        return ObjDB.ExecuteDataSet("SpVillageDetailsForSurvey");

    }
    public DataSet GetDistrict1(int stateid, int action)
    {
        ObjDB.AddParameter("@StateID", stateid);
        ObjDB.AddParameter("@Action", action);

        return ObjDB.ExecuteDataSet("DistrictTehsilGramPanchyat");

    }
    public DataSet GetState(int action)
    {
        // ObjDB.AddParameter("@StateID", stateid);
        ObjDB.AddParameter("@Action", action);

        return ObjDB.ExecuteDataSet("DistrictTehsilGramPanchyat");

    }
    public DataSet GetTehsil(int Distid, int action)
    {
        ObjDB.AddParameter("@Distid", Distid);
        ObjDB.AddParameter("@Action", action);

        return ObjDB.ExecuteDataSet("DistrictTehsilGramPanchyat");

    }
    public DataSet ChkVillageID(int villageID)
    {
        ObjDB.AddParameter("@VILL_ID", villageID);

        return ObjDB.ExecuteDataSet("spChkVillageIDExistOrNot");

    }
    public DataSet GetGramPanchyat(int Tehsilid, int action)
    {
        ObjDB.AddParameter("@Tehsilid", Tehsilid);
        ObjDB.AddParameter("@Action", action);

        return ObjDB.ExecuteDataSet("DistrictTehsilGramPanchyat");

    }
    
    public DataSet Fill_Tehsil_Name_By_District_ID(string districtid)
    {
        ObjDB.AddParameter("@DT_ID", districtid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Tehsil_Name_By_District_ID");
    }
    public DataSet Fill_GP_Name_By_Tehsil_ID(string tehsilid)
    {
        ObjDB.AddParameter("@TH_ID", tehsilid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_GP_Name_By_Tehsil_ID");
    }
    public DataSet Fill_Villlage_Name_By_Reserve_ID()
    {
        ObjDB.AddParameter("@UserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Villlage_Name_By_Reserve_ID");
    }
    public DataSet Fill_Data_By_Village_ID(string villageid)
    {
        ObjDB.AddParameter("@VILL_ID", villageid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Data_By_Village_ID");
    }
    public bool SendEmail(string To, string Cc, string Bcc, string Subject, string From, string Msg)// send mail 
    {
        try
        {
            MailMessage objMail = new MailMessage();
            objMail.To = To;
            objMail.Cc = Cc;
            objMail.Bcc = Bcc;
            objMail.Subject = Subject;
            //if (From != string.Empty)
            //{
                objMail.From = From;
            //}
            //else
            //{
            //    objMail.From = "mani.bhushan@netcreativemind.co.in";
            //}
            objMail.BodyFormat = MailFormat.Html;
            objMail.Body = Msg;

            System.Web.Mail.SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SMTPSERVER"].ToString();// server name 

            SmtpMail.Send(objMail);
            return true;
        }
        catch (Exception e3)
        {
            return false;
        }


    }
    public DataSet Fill_Group_Name(string villageid)
    {
        ObjDB.AddParameter("@VILL_ID", villageid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Group_Name");
    }

    public DataSet Fill_Village_By_GP_ID(string gp)
    {
        ObjDB.AddParameter("@GP_ID", gp);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Village_By_GP_ID");
    }
    public DataSet FillOccupations()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_Occupations");
    }

    public DataSet FillRelation()
    {
        return ObjDB.ExecuteDataSet("Proc_Tiger_FillRelation");
    }



    FeedbackEntity FE = new FeedbackEntity();

    public DataSet Proc_Display_Feedback(string f_id)
    {
        ObjDB.AddParameter("@feedback_id", f_id);
        return ObjDB.ExecuteDataSet("Proc_Display_Feedback");

    }
    public bool Proc_DeleteFeedbackById(string f_id)
    {
        try
        {
            ObjDB.AddParameter("@feedback_id", f_id);
            int i = ObjDB.ExecuteNonQuery("Proc_DeleteFeedbackById");
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
    public bool Proc_Insert_Feedback(FeedbackEntity FE)
    {
        try
        {
            ObjDB.AddParameter("@feedback_username", FE._Feedback_Username);
            ObjDB.AddParameter("@feedback_useremail", FE._feedback_useremail);
            ObjDB.AddParameter("@feedback_mobile", FE._feedback_mobile);
            ObjDB.AddParameter("@feedback_teliphone", FE._feedback_teliphone);
            ObjDB.AddParameter("@feedback_Address", FE._feedback_Address);
            ObjDB.AddParameter("@feedback_state", FE._feedback_state);
            ObjDB.AddParameter("@feedback_message", FE._feedback_message);
            int i = ObjDB.ExecuteNonQuery("Proc_Insert_Feedback");
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

    public DataSet FillFamily(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_FillFamily");

    }
    public DataSet FillNGO(string rid)
    {
        ObjDB.AddParameter("@RSRV_ID", rid);
        return ObjDB.ExecuteDataSet("Proc_FillNGO");

    }

    public bool InsertTime(string username, string RandomId)
    {
        try
        {
            ObjDB.AddParameter("@USERNAME", username);
            ObjDB.AddParameter("@RANDOMID", Convert.ToDecimal(RandomId));
            ObjDB.AddParameter("@MAILTIME", DateTime.Now);
            int i = ObjDB.ExecuteNonQuery("InsertDateTime");
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
    public DataSet ChkActiveLinkOfForgotPwd(string strUID,string Log_Id)
    {
        ObjDB.AddParameter("@UserName", strUID);
        ObjDB.AddParameter("@RandomId", Log_Id);
        return ObjDB.ExecuteDataSet("ChkActiveLinkOfForgotPwd");

    }
    public DataSet GetMailTime(string strUID)
    {
        ObjDB.AddParameter("@UserName", strUID);

        return ObjDB.ExecuteDataSet("GetMailTime");

    }

   
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCM.DAL;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for UserDL
/// </summary>
public class UserDL
{
    Project_Variables p_var = new Project_Variables();
    NCMdbAccess ObjNcm = new NCMdbAccess();
    int recordCount = 0;
    public UserDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet Asp_userLogin(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@Username", objuser.UserName);
            ObjNcm.AddParameter("@userType", objuser.UserType);
            return ObjNcm.ExecuteDataSet("Asp_userLogin");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public DataSet Asp_userLogin1(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@Username", objuser.UserName);
            ObjNcm.AddParameter("@userType", objuser.UserType);
            return ObjNcm.ExecuteDataSet("Asp_userLogin");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public DataSet GetMapKeyByStateID(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@id", objuser.StateID);

            return ObjNcm.ExecuteDataSet("GetMapDistrictKey");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int AddNewUser(NtcaUserOB objuser)
    {
        try
        {
            if (objuser.UserID == null)
            {
                SqlParameter[] param = new SqlParameter[1];
                ObjNcm.AddParameter("@Userid", objuser.UserID);
                ObjNcm.AddParameter("@UserName", objuser.UserName);
                ObjNcm.AddParameter("@FirstName", objuser.FirstName);
                ObjNcm.AddParameter("@LastName", objuser.LastName);
                ObjNcm.AddParameter("@Password", objuser.Password);
                ObjNcm.AddParameter("@UserType", objuser.UserType);
                ObjNcm.AddParameter("@EmailID", objuser.EmailID);
                ObjNcm.AddParameter("@Address1", objuser.Address1);
                ObjNcm.AddParameter("@Address2", objuser.Address1);
                ObjNcm.AddParameter("@PermissionState", objuser.State);
                ObjNcm.AddParameter("@pincode", objuser.pincode);
                ObjNcm.AddParameter("@Landline", objuser.Landline);
                ObjNcm.AddParameter("@AreaCode", objuser.AreaCode);
                ObjNcm.AddParameter("@Mobile", objuser.Mobile);
                ObjNcm.AddParameter("@DataOperatorParentUserID", objuser.DataOperatorParentUserID);
                param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
                param[0].Direction = ParameterDirection.Output;
                ObjNcm.Parameters.Add(param[0]);
                ObjNcm.ExecuteNonQuery("AddNewUser");

                recordCount = Convert.ToInt32(param[0].Value);
                return recordCount;
            }
            else
            {
               
                ObjNcm.AddParameter("@Userid", objuser.UserID);
                ObjNcm.AddParameter("@UserName", objuser.UserName);
                ObjNcm.AddParameter("@FirstName", objuser.FirstName);
                ObjNcm.AddParameter("@LastName", objuser.LastName);
                ObjNcm.AddParameter("@Password", objuser.Password);
                ObjNcm.AddParameter("@UserType", objuser.UserType);
                ObjNcm.AddParameter("@EmailID", objuser.EmailID);
                ObjNcm.AddParameter("@Address1", objuser.Address1);
                ObjNcm.AddParameter("@Address2", objuser.Address1);
                ObjNcm.AddParameter("@PermissionState", objuser.State);
                ObjNcm.AddParameter("@pincode", objuser.pincode);
                ObjNcm.AddParameter("@Landline", objuser.Landline);
                ObjNcm.AddParameter("@AreaCode", objuser.AreaCode);
                ObjNcm.AddParameter("@Mobile", objuser.Mobile);
               return ObjNcm.ExecuteNonQuery("AddNewUser");

            }
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateUsersDal(NtcaUserOB objuser)
    {
        try
        {         

                ObjNcm.AddParameter("@Userid", objuser.UserID);
                ObjNcm.AddParameter("@UserName", objuser.UserName);
                ObjNcm.AddParameter("@FirstName", objuser.FirstName);
                ObjNcm.AddParameter("@LastName", objuser.LastName);
                ObjNcm.AddParameter("@Password", objuser.Password);
                ObjNcm.AddParameter("@UserType", objuser.UserType);
                ObjNcm.AddParameter("@EmailID", objuser.EmailID);
                ObjNcm.AddParameter("@Address1", objuser.Address1);
                ObjNcm.AddParameter("@Address2", objuser.Address2);
                ObjNcm.AddParameter("@PermissionState", objuser.State);
                ObjNcm.AddParameter("@pincode", objuser.pincode);
                ObjNcm.AddParameter("@Landline", objuser.Landline);
                ObjNcm.AddParameter("@AreaCode", objuser.AreaCode);
                ObjNcm.AddParameter("@Mobile", objuser.Mobile);
                return ObjNcm.ExecuteNonQuery("UpdateNewUser");

            
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateActiveDeaActiveUsers(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@UserID", objuser.UserID);
            return recordCount= ObjNcm.ExecuteNonQuery("spActiveDeaActiveMstUser");
          
           
           
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateActiveDeaActiveTigerReserve(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@TigerReserveid", objuser.TigerReserveid);
            return recordCount = ObjNcm.ExecuteNonQuery("spActiveDeaActiveTigerReserve");



        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateActiveDeaActiveConvesionScheme(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@ConversionID", objuser.ConversionID);
            return recordCount = ObjNcm.ExecuteNonQuery("spActiveDeaActiveConversationSchem");



        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateActiveDeaActiveTigerReserveFeedback(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@FeedBackFormID", objuser.FeedBackFormID);
            return recordCount = ObjNcm.ExecuteNonQuery("spActiveDeaActiveFeedback");



        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int UpdateProfile(NtcaUserOB objuser)
    {
        try
        {
           
                SqlParameter[] param = new SqlParameter[1];
                ObjNcm.AddParameter("@Userid", objuser.UserID);
                
                ObjNcm.AddParameter("@FirstName", objuser.FirstName);
                ObjNcm.AddParameter("@LastName", objuser.LastName);
               
                ObjNcm.AddParameter("@EmailID", objuser.EmailID);
                ObjNcm.AddParameter("@Address1", objuser.Address1);
                ObjNcm.AddParameter("@Address2", objuser.Address2);
              
                ObjNcm.AddParameter("@pincode", objuser.pincode);
                ObjNcm.AddParameter("@Landline", objuser.Landline);
                ObjNcm.AddParameter("@AreaCode", objuser.AreaCode);
                ObjNcm.AddParameter("@Mobile", objuser.Mobile);
                ObjNcm.AddParameter("@Action", objuser.Action);


                return ObjNcm.ExecuteNonQuery("spUserDetailsAction");
  
            
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int ChangePassword(NtcaUserOB objuser)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[1];
            ObjNcm.AddParameter("@Userid", objuser.UserID);
            ObjNcm.AddParameter("@Password", objuser.Password);
            ObjNcm.AddParameter("@Action", objuser.Action);

            return ObjNcm.ExecuteNonQuery("spUserDetailsAction");


        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }

    public DataSet Get_UserList(NtcaUserOB objuser)
    {
        try
        {
            if (HttpContext.Current.Session["UserType"].ToString() == "3")
            {
                ObjNcm.AddParameter("@State", objuser.StateID);
                ObjNcm.AddParameter("@DataOperatorParentUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));

                return ObjNcm.ExecuteDataSet("spGetUserListDataOperator");
            }
            else
            {
                ObjNcm.AddParameter("@State", objuser.StateID);

                return ObjNcm.ExecuteDataSet("Get_UserList");
            }
            
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public DataSet Get_UserDetials(NtcaUserOB Objuser)
    {
        try
        {

            ObjNcm.AddParameter("@UserID", Objuser.UserID);

            return ObjNcm.ExecuteDataSet("Get_UserDetials");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int Update_User_TigerReserve_Permission(string strTigerReserveid, int Userid)
    {
        try
        {

            ObjNcm.AddParameter("@StrTigerReserve", strTigerReserveid);
            ObjNcm.AddParameter("@Userid", Userid);

            return ObjNcm.ExecuteNonQuery("Update_User_TigerReserve_Permission");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public int DataOperatorPermission(int ParentTigerReserveUserID, int DataOperatorUserID, int TigerReserveID, int Action)
    {
        try
        {

            ObjNcm.AddParameter("@ParentTigerReserveUserID", ParentTigerReserveUserID);
            ObjNcm.AddParameter("@DataOperatorUserID", DataOperatorUserID);
            ObjNcm.AddParameter("@TigerReserveID", TigerReserveID);
            ObjNcm.AddParameter("@Action", Action);

            return ObjNcm.ExecuteNonQuery("spDataOperatonPermission");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    //  new
    public DataSet Asp_forntuserLogin(NtcaUserOB objuser)
    {
        try
        {

            ObjNcm.AddParameter("@Username", objuser.UserName);
            ObjNcm.AddParameter("@userType", objuser.UserType);
            return ObjNcm.ExecuteDataSet("Asp_forntuserLogin");
        }
        catch
        {
            throw;
        }
        finally
        {
            ObjNcm.Dispose();
        }
    }
    public DataSet Proc_Select_USER_DETAIL_BY_Name(UserEntity entity)
    {
        ObjNcm.AddParameter("@UserName", entity.USERNAME);
        return ObjNcm.ExecuteDataSet("ASP_GetMailId_User");

    }
    public bool Proc_Insert_Into_RESETPASSWORD(UserEntity entity)
    {
        try
        {
            ObjNcm.AddParameter("@ActionType", entity.ActionType);
            ObjNcm.AddParameter("@FpUserID", entity.LOG_ID);
            ObjNcm.AddParameter("@FpUsername", entity.USERNAME);
            ObjNcm.AddParameter("@FpRANDOMID", entity.RANDOMID);
            int val = ObjNcm.ExecuteNonQuery("ASP_InsertUpdateDelete_ForgotPassword");
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception)
        {

            return false;
        }
    }
    public bool Proc_Update_User_Password(UserEntity entity)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@recordCount", SqlDbType.Int);
            param[0].Direction = ParameterDirection.Output;
            ObjNcm.AddParameter(param[0]);
            ObjNcm.AddParameter("@UserId", entity.LOG_ID);
            ObjNcm.AddParameter("@Password", entity.PASSWORD);
            ObjNcm.ExecuteNonQuery("ASP_UpdateUserPassword_User");
            int val = Convert.ToInt16(param[0].Value);
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception)
        {

            return false;
        }
    }
    public void Proc_Check_Password(UserEntity entity, ref string check)
    {
        try
        {
            ObjNcm.AddParameter("@FpUserID", entity.LOG_ID);
            ObjNcm.AddParameter("@RANDOMID", entity.RANDOMID);

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@state", SqlDbType.NVarChar, 4000);
            param[0].Direction = ParameterDirection.Output;
            ObjNcm.AddParameter(param[0]);
            ObjNcm.ExecuteDataSet("ASP_Check_Password");
            check = (param[0].Value).ToString();


        }
        catch
        {
            throw;
        }
    }
    public bool Proc_Update_Into_RESETPASSWORD(UserEntity entity)
    {
        try
        {
            ObjNcm.AddParameter("@ActionType", entity.ActionType);
            ObjNcm.AddParameter("@FpUserID", entity.LOG_ID);
            ObjNcm.AddParameter("@FpRANDOMID", entity.RANDOMID);
            int val = ObjNcm.ExecuteNonQuery("ASP_InsertUpdateDelete_ForgotPassword");
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception)
        {

            return false;
        }
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using NCM.DAL;

/// <summary>
/// Summary description for User_managementDB
/// </summary>
public class User_managementDB
{
    // DBOPERATION ObjDB = new DBOPERATION();
    NCMdbAccess ObjDB = new NCMdbAccess();
    User_managementEntity UserEntity_Obj = new User_managementEntity();
    public bool AddUserDB(User_managementEntity objUser_managementEntity, StateEntity StateEntity_Obj, Reserve_Entity RSRV_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@USR_NM", objUser_managementEntity._USR_NM);
            ObjDB.AddParameter("@USR_LOG_ID", objUser_managementEntity._USR_LOG_ID);
            ObjDB.AddParameter("@USR_PWD", objUser_managementEntity._USR_PWD);
            ObjDB.AddParameter("@USR_ROLE", objUser_managementEntity._USR_ROLE);
            ObjDB.AddParameter("@USR_CONTACT", objUser_managementEntity._USR_CONTACT);
            ObjDB.AddParameter("@USR_EMAIL", objUser_managementEntity._USR_EMAIL);
            ObjDB.AddParameter("@USR_ADDRESS", objUser_managementEntity._USR_ADDRESS);
            ObjDB.AddParameter("@ST_ID", StateEntity_Obj._ST_ID);
            ObjDB.AddParameter("@RSRV_ID", RSRV_ENT_Obj._RSRV_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Users");
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



    public DataSet UserPasswordDB(User_managementEntity UserEntity_Obj)
    {
        ObjDB.AddParameter("@USR_LOG_ID", UserEntity_Obj._USR_LOG_ID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Users_Password");
    }
    public DataSet UserPasswordDB_new(User_managementEntity UserEntity_Obj)
    {
        ObjDB.AddParameter("@USR_LOG_ID", UserEntity_Obj._USR_LOG_ID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Users_Password_new");
    }



    public bool Approve_Disapprove_UsersDB(string userid, string appdisapp)
    {
        try
        {
            ObjDB.AddParameter("@USR_ID", userid);
            ObjDB.AddParameter("@APPRV_STATUS", appdisapp);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Approve_Disapprove_Users");
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
    public DataSet Display_All_Users(User_managementEntity USR_ENT_Obj, string userrole)
    {
        ObjDB.AddParameter("@USR_ID", USR_ENT_Obj._USR_ID);
        ObjDB.AddParameter("@USR_LOG_ID", USR_ENT_Obj._USR_LOG_ID);
        ObjDB.AddParameter("@USR_ROLE", userrole);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Users");
    }

    public bool UpdateUserDB(User_managementEntity objUser_managementEntity, string userid, StateEntity StateEntity_Obj, Reserve_Entity RSRV_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@USR_ID", userid);
            ObjDB.AddParameter("@USR_NM", objUser_managementEntity._USR_NM);
            ObjDB.AddParameter("@USR_ROLE", objUser_managementEntity._USR_ROLE);
            ObjDB.AddParameter("@USR_CONTACT", objUser_managementEntity._USR_CONTACT);
            ObjDB.AddParameter("@USR_EMAIL", objUser_managementEntity._USR_EMAIL);
            ObjDB.AddParameter("@USR_ADDRESS", objUser_managementEntity._USR_ADDRESS);
            ObjDB.AddParameter("@ST_ID", StateEntity_Obj._ST_ID);
            ObjDB.AddParameter("@RSRV_ID", RSRV_ENT_Obj._RSRV_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Users");

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
    public bool Delete_User_By_ID(string userid)
    {
        try
        {
            ObjDB.AddParameter("@USR_ID", userid);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_Info_Users");

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
        finally
        {

        }

    }

    public DataSet CheckLoginIDDB(User_managementEntity UserEntity_Obj)
    {
        ObjDB.AddParameter("@USR_LOG_ID", UserEntity_Obj._USR_LOG_ID);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_LoginID_of_Users");
    }
    public DataSet CheckLEmailIDDB(User_managementEntity UserEntity_Obj)
    {
        ObjDB.AddParameter("@USR_EMAIL", UserEntity_Obj._USR_EMAIL);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_EmailID_of_Users");
    }

    public bool UpdatePasswordDB(User_managementEntity UserEntity_Obj, string password, string rand)
    {
        try
        {

            ObjDB.AddParameter("@USR_ID", UserEntity_Obj._USR_ID);
            ObjDB.AddParameter("@USR_PWD", password);
            ObjDB.AddParameter("@Random", rand);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Password_Users");

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
    public DataSet Check_LoginID_Or_EmailID(string id, string emailid)
    {
        ObjDB.AddParameter("@USR_LOG_ID", id);
        ObjDB.AddParameter("@USR_EMAIL", emailid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_LoginID_Or_EmailID");
    }
    public DataSet FillFillIdsOfUsers()
    {

        return ObjDB.ExecuteDataSet("Proc_Tiger_Fill_UserIDs");
    }
    public bool Proc_EditProfile(User_managementEntity UserEntity_Obj)
    {
        try
        {
            ObjDB.AddParameter("@USR_LOG_ID", UserEntity_Obj._USR_ID);
            ObjDB.AddParameter("@USR_NM", UserEntity_Obj._USR_NM);
            ObjDB.AddParameter("@USR_EMAIL", UserEntity_Obj._USR_EMAIL);
            ObjDB.AddParameter("@USR_CONTACT", UserEntity_Obj._USR_CONTACT);
            int i = ObjDB.ExecuteNonQuery("Proc_EditProfile");
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
    public bool UpdatePasswordDBForChangePassword(User_managementEntity UserEntity_Obj,string password)
    {
        try
        {
            ObjDB.AddParameter("@USR_LOG_ID", UserEntity_Obj._USR_LOG_ID);

            ObjDB.AddParameter("@USR_PWD", password);
            int i = ObjDB.ExecuteNonQuery("Proc_UpdatePasswordDBForChangePassword");
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

    
}
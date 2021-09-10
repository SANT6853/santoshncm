using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBL
/// </summary>
public class UserBL
{
    UserDL _UserDL = new UserDL();
    public UserBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet Asp_userLogin(NtcaUserOB objuser)
    {
        return _UserDL.Asp_userLogin(objuser);
    }
    public DataSet Asp_userLogin1(NtcaUserOB objuser)
    {
        return _UserDL.Asp_userLogin1(objuser);
    }
    public DataSet GetMapKeyByStateID(NtcaUserOB objuser)
    {
        return _UserDL.GetMapKeyByStateID(objuser);
    }
    public int AddNewUser(NtcaUserOB objuser)
    {
        return _UserDL.AddNewUser(objuser);
    }
    public int UpdateUsersDal(NtcaUserOB objuser)
    {
        return _UserDL.UpdateUsersDal(objuser);
    }
    public int UpdateActiveDeaActiveUsers(NtcaUserOB objuser)
    {
        return _UserDL.UpdateActiveDeaActiveUsers(objuser);
    }
    public int UpdateActiveDeaActiveTigerReserveFeedback(NtcaUserOB objuser)
    {
        return _UserDL.UpdateActiveDeaActiveTigerReserveFeedback(objuser);
    }
    public int UpdateActiveDeaActiveTigerReserve(NtcaUserOB objuser)
    {
        return _UserDL.UpdateActiveDeaActiveTigerReserve(objuser);
    }
    public int UpdateActiveDeaActiveConvesionScheme(NtcaUserOB objuser)
    {
        return _UserDL.UpdateActiveDeaActiveConvesionScheme(objuser);
    }
    public int UpdateProfile(NtcaUserOB objuser)
    {
        return _UserDL.UpdateProfile(objuser);
    }
    public int ChangePassword(NtcaUserOB objuser)
    {
        return _UserDL.ChangePassword(objuser);
    }
    public DataSet Get_UserList(NtcaUserOB objuser)
    {
        return _UserDL.Get_UserList(objuser);
    }
    public DataSet Get_UserDetials(NtcaUserOB Objuser)
    {
        return _UserDL.Get_UserDetials(Objuser);
    }
    //
    public int Update_User_TigerReserve_Permission(string strTigerReserveid, int Userid)
    {
        return _UserDL.Update_User_TigerReserve_Permission(strTigerReserveid, Userid);
    }
    public int DataOperatorPermission(int ParentTigerReserveUserID, int DataOperatorUserID, int TigerReserveID, int Action)
    {
        return _UserDL.DataOperatorPermission(ParentTigerReserveUserID, DataOperatorUserID, TigerReserveID, Action);
    }
    public DataSet Asp_forntuserLogin(NtcaUserOB objuser)
    {
        return _UserDL.Asp_forntuserLogin(objuser);
    }
    public DataSet Proc_Select_USER_DETAIL_BY_Name(UserEntity entity)
    {
        return _UserDL.Proc_Select_USER_DETAIL_BY_Name(entity);
    }
    public bool Proc_Insert_Into_RESETPASSWORD(UserEntity entity)
    {
        try
        {
            return _UserDL.Proc_Insert_Into_RESETPASSWORD(entity);
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
            return _UserDL.Proc_Update_User_Password(entity);
        }
        catch (Exception)
        {

            return false;
        }
    }
    public void Proc_Check_Password(UserEntity entity, ref string check)
    {
        _UserDL.Proc_Check_Password(entity, ref check);
    }
    public bool Proc_Update_Into_RESETPASSWORD(UserEntity entity)
    {
        try
        {
            return _UserDL.Proc_Update_Into_RESETPASSWORD(entity);

        }
        catch (Exception)
        {

            return false;
        }

    }
}
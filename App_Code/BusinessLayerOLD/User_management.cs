using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for User_management
/// </summary>
public class User_management
{
    User_managementDB user_db = new User_managementDB();
    bool check=false;
	public User_management()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool AddUser(User_managementEntity objUser_managementEntity,StateEntity StateEntity_Obj,Reserve_Entity RSRV_ENT_Obj)
    {


        check = user_db.AddUserDB(objUser_managementEntity, StateEntity_Obj, RSRV_ENT_Obj);// Calling of Data layer function
      if (check == true)
          return true;
      else
          return false;
           
       

    }
     public bool UpdateUser(User_managementEntity objUser_managementEntity, string userid, StateEntity StateEntity_Obj,Reserve_Entity RSRV_ENT_Obj)
    {


        check = user_db.UpdateUserDB(objUser_managementEntity, userid, StateEntity_Obj, RSRV_ENT_Obj);// Calling of Data layer function
        if (check == true)
            return true;
        else
            return false;


    }

    //public bool UpdatePassword(User_managementEntity objUser_managementEntity, string password)
    //{


    //    check = user_db.UpdatePasswordDB(objUser_managementEntity, password);// Calling of Data layer function
    //    if (check == true)
    //        return true;
    //    else
    //        return false;

    //}
}

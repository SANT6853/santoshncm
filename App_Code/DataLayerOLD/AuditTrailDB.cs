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

using NCM.DAL;

/// <summary>
/// Summary description for AuditTrailDB
/// </summary>
public class AuditTrailDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    User_managementEntity UserEntity_Obj = new User_managementEntity();
    public  void AUDIT_TRAIL(string Id, string Action, int MODULE_ID)
    {
       try
        {
            ObjDB.AddParameter("@USR_LOGIN_ID", System.Web.HttpContext.Current.Session["User_Id"]);
            ObjDB.AddParameter("@IP_ADDRESS", System.Web.HttpContext.Current.Request.UserHostAddress);
            ObjDB.AddParameter("@URL", Convert.ToString(HttpContext.Current.Request.Url));
            ObjDB.AddParameter("@ACTION", Convert.ToString(Action));
            ObjDB.AddParameter("@FK_MODULE_ID", MODULE_ID);
            int i = ObjDB.ExecuteNonQuery("PROC_INSERT_AUDIT_TRAIL_MODULE");
            
        }
        catch (Exception e)
        {
           
        }
    }
    public void AUDIT_TRAIL_FOR_Login(string Id, string Action, int MODULE_ID, string attempt)
    {
        try
        {
            ObjDB.AddParameter("@USR_LOGIN_ID", System.Web.HttpContext.Current.Session["LoginID"]);
            ObjDB.AddParameter("@IP_ADDRESS", System.Web.HttpContext.Current.Request.UserHostAddress);
            ObjDB.AddParameter("@URL", Convert.ToString(HttpContext.Current.Request.Url));
            ObjDB.AddParameter("@ACTION", Convert.ToString(Action));
            ObjDB.AddParameter("@FK_MODULE_ID", MODULE_ID);
            ObjDB.AddParameter("@Attempt", MODULE_ID);
            int i = ObjDB.ExecuteNonQuery("PROC_INSERT_AUDIT_TRAIL_MODULE_FOR_LOGIN");

        }
        catch (Exception e)
        {

        }
    }
    //public void AUDIT_TRAIL_FOR_Logout(string Id, string Action, int MODULE_ID)
    //{
    //    try
    //    {
    //        ObjDB.AddParameter("@USR_LOGIN_ID", System.Web.HttpContext.Current.Session["LoginID"]);
    //        ObjDB.AddParameter("@IP_ADDRESS", System.Web.HttpContext.Current.Request.UserHostAddress);
    //        ObjDB.AddParameter("@URL", Convert.ToString(HttpContext.Current.Request.Url));
    //        ObjDB.AddParameter("@ACTION", Convert.ToString(Action));
    //        ObjDB.AddParameter("@FK_MODULE_ID", MODULE_ID);
    //        int i = ObjDB.ExecuteNonQuery("PROC_INSERT_AUDIT_TRAIL_MODULE_FOR_LOGOUT");

    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}

}

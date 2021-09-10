using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using NCM.DAL;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;



public class AuditTrail
{

    Miscelleneous_BL obj_miscell = new Miscelleneous_BL();
	public AuditTrail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string  getlastupdatedate()
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {

            return Convert.ToString(obj.ExecuteScalar("getlastupdatedate"));
        }

    }

    
    #region Audit Trails

    public  void GetAuditTrailLogin(AuditOB entity)
    {

        HttpContext context = HttpContext.Current;



        //entity.SessionID = context.Session.SessionID;

        entity.IPAddress = obj_miscell.IpAddress(); 

        entity.RequestURL = context.Request.Url.ToString();


        using (NCMdbAccess obj = new NCMdbAccess())
        {

            obj.AddParameter("@Admin_Login_id", entity.Admin_Login_id);
            // obj.AddParameter("@SessionID", entity.SessionID);
            obj.AddParameter("@Action", entity.Action);
            obj.AddParameter("@IPAddress", entity.IPAddress);
            obj.AddParameter("@RequestURL", entity.RequestURL);
            obj.AddParameter("@UserName", entity.UserName);
            obj.AddParameter("@Attempt_Success", entity.Attempt_success);
            try
            {
                obj.ExecuteNonQuery("Proc_Insert_AuditTrailLogin");
            }
            catch { }
        }






    }



    public void GetAuditTrail(AuditOB entity)
    {

        HttpContext context = HttpContext.Current;

        // entity.Admin_Login_id = Convert.ToInt32(context.Session["AdminId"]);

        //entity.SessionID = context.Session.SessionID;

        entity.IPAddress = obj_miscell.IpAddress(); ;

        entity.RequestURL = context.Request.Url.ToString();
         
     
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@FK_MODULE_ID", entity.FK_MODULE_ID);
            obj.AddParameter("@Admin_Login_id", entity.Admin_Login_id);
            // obj.AddParameter("@SessionID", entity.SessionID);
            obj.AddParameter("@Action", entity.Action);
            obj.AddParameter("@IPAddress", entity.IPAddress);
            obj.AddParameter("@PageTitle", entity.PageTitle);
            //obj.AddParameter("@Attempt_success", entity.Attempt_success);
            try
            {
             int a=   obj.ExecuteNonQuery("Proc_Insert_AudittrailModule");
            }
            catch { }
        }



    }

    public void GetAuditTrailFront(AuditOB entity)
    {

        HttpContext context = HttpContext.Current;

        // entity.Admin_Login_id = Convert.ToInt32(context.Session["AdminId"]);

        //entity.SessionID = context.Session.SessionID;

        entity.IPAddress = obj_miscell.IpAddress(); 

        entity.RequestURL = context.Request.Url.ToString();

        using (NCMdbAccess obj = new NCMdbAccess())
        {

            obj.AddParameter("@Admin_Username", entity.UserName);
            // obj.AddParameter("@SessionID", entity.SessionID);
            obj.AddParameter("@Action", entity.Action);
            obj.AddParameter("@IPAddress", entity.IPAddress);
            //obj.AddParameter("@RequestURL", entity.RequestURL);
            //obj.AddParameter("@Attempt_success", entity.Attempt_success);
            try
            {
                obj.ExecuteNonQuery("Proc_Insert_AudittrailModuleFront");
            }
            catch { }
        }



    }

    #endregion




    public DataSet DisplayAuditTrail(AuditOB entity)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {

            obj.AddParameter("@flag", entity.Flag);

            obj.AddParameter("@moduleId", entity.MODULE_ID);
           
            try
            {
              return  obj.ExecuteDataSet("DisplayAuditTrail");
            }
            catch {
                throw;
            }
        }



    }

    public DataSet getModules(AuditOB entity)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {

            try
            {
                obj.AddParameter("@flag", entity.Flag);
              return  obj.ExecuteDataSet("DisplayAuditTrail");
            }
            catch {
                throw;
            }
        }



    }


    public int delete(AuditOB entity)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {

            try
            {
                obj.AddParameter("@flag", entity.Flag);
                obj.AddParameter("@Audit_Id", entity.ID);
                return obj.ExecuteNonQuery("DisplayAuditTrail");
            }
            catch
            {
                throw;
            }
        }



    }


    public DataSet GetAuditTrailAll(AuditOB entity)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {

            try
            {               
               
                return obj.ExecuteDataSet("DisplayAuditTrail");
            }
            catch
            {
                throw;
            }
        }



    }

}

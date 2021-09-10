using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class AuditOB
{
	public AuditOB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int ID { get; set; }
    public int Flag { get; set; }
    public int? FK_MODULE_ID { get; set; }
    public int Admin_Login_id { get; set; }
    public string SessionID { get; set; }
    public string Action { get; set; }
    public string IPAddress { get; set; }
    public string RequestURL { get; set; }
    public string Timestamps { get; set; }
    public string login_time { get; set; }
    public string logout_time { get; set; }
    public string UserName { get; set; }
    public bool Attempt_success { get; set; }

    public string MODULE_ID { get; set; }
    public string PageTitle { get; set; }
}

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
/// Summary description for User_managementEntity
/// </summary>
public class User_managementEntity
{
	public User_managementEntity()
	{
        USR_ID = null;
		USR_NM=null;
        USR_LOG_ID=null;
        USR_PWD=null;
        USR_ROLE = null;
        USR_CONTACT= null;
        USR_EMAIL= null;
        USR_ADDRESS = null;


	}

    private string USR_ID;
    public string _USR_ID
    {
        get
        {
            return USR_ID;
        }
        set
        {
            USR_ID = value;
        }
    }
    private string USR_NM;
    public string _USR_NM
    {
        get
        {
            return USR_NM;
        }
        set
        {
            USR_NM = value;
        }
    }

    private string USR_LOG_ID;
    public string _USR_LOG_ID
    {
        get
        {
            return USR_LOG_ID;
        }
        set
        {
            USR_LOG_ID = value;
        }
    }

   

    private string USR_PWD;
    public string _USR_PWD
    {
        get
        {
            return USR_PWD;
        }
        set
        {
            USR_PWD = value;
        }
    }
    private string USR_ROLE;
    public string _USR_ROLE
    {
        get
        {
            return USR_ROLE;
        }
        set
        {
            USR_ROLE = value;
        }
    }
    private string USR_CONTACT;
    public string _USR_CONTACT
    {
        get
        {
            return USR_CONTACT;
        }
        set
        {
            USR_CONTACT = value;
        }
    } private string USR_EMAIL;
    public string _USR_EMAIL
    {
        get
        {
            return USR_EMAIL;
        }
        set
        {
            USR_EMAIL = value;
        }
    } private string USR_ADDRESS;
    public string _USR_ADDRESS
    {
        get
        {
            return USR_ADDRESS;
        }
        set
        {
            USR_ADDRESS = value;
        }
    }
}

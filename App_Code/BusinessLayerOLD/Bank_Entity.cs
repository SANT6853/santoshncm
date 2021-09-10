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
/// Summary description for Bank_Entity
/// </summary>
public class Bank_Entity
{
	public Bank_Entity()
	{
        BANK_ID = null;
        BANK_CD =null;
        BANK_NAME = null;
        BANK_ADDRESS = null;
	}
    private string BANK_ID;
    public string _BANK_ID
    {
        get 
        {
            return BANK_ID;
        }
        set
        {
            BANK_ID = value;
        }
    }

    private string BANK_CD;
    public string _BANK_CD
    {
        get
        {
            return BANK_CD;
        }
        set
        {
            BANK_CD = value;
        }
    }
    private string BANK_NAME;
    public string _BANK_NAME
    {
        get
        {
            return BANK_NAME;
        }
        set
        {
            BANK_NAME = value;
        }
    }
    private string BANK_ADDRESS;
    public string _BANK_ADDRESS
    {
        get
        {
            return BANK_ADDRESS;
        }
        set
        {
            BANK_ADDRESS = value;
        }
    }
    
}

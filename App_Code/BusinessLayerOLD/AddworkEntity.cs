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
/// Summary description for AddworkEntity
/// </summary>
public class AddworkEntity
{
	public AddworkEntity()
	{
        CDP_WRK_INFO_ID = null;
        CDP_WRK_ID = null;
        CDP_INFO_ID = null; 
        GRP_ID = null;
        CDP_ALLTD_AMT = 0;
        CDP_AMT_USD = 0;
        CDP_AGENCY= null;
        CDP_SITE_ADDRSS= null;
        COMMENT = null;
    }
    private string CDP_WRK_INFO_ID;
    public string _CDP_WRK_INFO_ID
    {
        get
        {
            return CDP_WRK_INFO_ID;
        }
        set
        {
            CDP_WRK_INFO_ID = value;
        }
    }
    private string CDP_WRK_ID;
    public string _CDP_WRK_ID
    {
        get
        {
            return CDP_WRK_ID;
        }
        set
        {
            CDP_WRK_ID = value;
        }
    }
    private string GRP_ID;
    public string _GRP_ID
    {
        get
        {
            return GRP_ID;
        }
        set
        {
            GRP_ID = value;
        }
    }
    private double CDP_ALLTD_AMT;
    public double _CDP_ALLTD_AMT
    {
        get
        {
            return CDP_ALLTD_AMT;
        }
        set
        {
            CDP_ALLTD_AMT = value;
        }
    }
    private double CDP_AMT_USD;
    public double _CDP_AMT_USD
    {
        get
        {
            return CDP_AMT_USD;
        }
        set
        {
            CDP_AMT_USD = value;
        }
    }
    private string CDP_AGENCY;
    public string _CDP_AGENCY
    {
        get
        {
            return CDP_AGENCY;
        }
        set
        {
            CDP_AGENCY = value;
        }
    }

    private string CDP_SITE_ADDRSS;
    public string _CDP_SITE_ADDRSS
    {
        get
        {
            return CDP_SITE_ADDRSS;
        }
        set
        {
            CDP_SITE_ADDRSS = value;
        }
    }
    private string COMMENT;
    public string _COMMENT
    {
        get
        {
            return COMMENT;
        }
        set
        {
            COMMENT = value;
        }
    }
    private string CDP_INFO_ID;
    public string _CDP_INFO_ID
    {
        get
        {
            return CDP_INFO_ID;
        }
        set
        {
            CDP_INFO_ID = value;
        }
    }
}

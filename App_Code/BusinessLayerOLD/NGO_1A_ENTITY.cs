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
/// Summary description for NGO_1A_ENTITY
/// </summary>
public class NGO_1A_ENTITY
{

    public NGO_1A_ENTITY()
	{
		NAME = null;
        ADDRESS = null;
        CONTACT_NO = null;
        PERSONS = 0;
        RSRV_ID = null;
        ID = 0;
	}


    private string NAME;
    public string _NAME
    {
        get
        {
            return NAME;
        }
        set
        {
            NAME = value;
        }
    }

    private string ADDRESS;
    public string _ADDRESS
    {
        get
        {
            return ADDRESS;
        }
        set
        {
            ADDRESS = value;
        }
    }
    private string CONTACT_NO;
    public string _CONTACT_NO
    {
        get
        {
            return CONTACT_NO;
        }
        set
        {
            CONTACT_NO = value;
        }
    }
    private int PERSONS;
    public int _PERSONS
    {
        get
        {
            return PERSONS;
        }
        set
        {
            PERSONS = value;
        }
    }
    private string RSRV_ID;
    public string _RSRV_ID
    {
        get
        {
            return RSRV_ID;
        }
        set
        {
            RSRV_ID = value;
        }
    }
    private long ID;
    public long _ID
    {
        get
        {
            return ID;
        }
        set
        {
            ID = value;
        }
    }
}
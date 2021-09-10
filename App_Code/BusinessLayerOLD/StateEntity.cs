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
/// Summary description for StateEntity
/// </summary>
public class StateEntity
{
	public StateEntity()
	{
    ST_ID = 0;
	ST_CD=0;
    ST_NAME = null;
	}
    private int ST_CD;
    public int _ST_CD
    {
        get
        {
            return ST_CD;
        }
        set
        {
            ST_CD = value;
        }
    }
    private int ST_ID;
    public int _ST_ID
    {
        get
        {
            return ST_ID;
        }
        set
        {
            ST_ID = value;
        }
    }
    private string ST_NAME;
    public string _ST_NAME
    {
        get
        {
            return ST_NAME;
        }
        set
        {
            ST_NAME = value;
        }
    }
}

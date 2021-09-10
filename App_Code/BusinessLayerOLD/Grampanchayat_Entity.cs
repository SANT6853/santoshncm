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
/// Summary description for Grampanchayat_Entity
/// </summary>
public class Grampanchayat_Entity
{
	public Grampanchayat_Entity()
	{
		
        GP_ID = 0;
        GP_CD = 0;
        GP_NAME = null;
    }
    private int GP_CD;
    public int _GP_CD
    {
        get
        {
            return GP_CD;
        }
        set
        {
            GP_CD = value;
        }
    }
    private int GP_ID;
    public int _GP_ID
    {
        get
        {
            return GP_ID;
        }
        set
        {
            GP_ID = value;
        }
    }
    private string GP_NAME;
    public string _GP_NAME
    {
        get
        {
            return GP_NAME;
        }
        set
        {
            GP_NAME = value;
        }
    }
}
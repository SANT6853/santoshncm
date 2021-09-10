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
/// Summary description for Tehsil_Entity
/// </summary>
public class Tehsil_Entity
{
	public Tehsil_Entity()
    {
    TH_ID = 0;
	TH_CD=0;
    TH_NAME = null;
    }
    private int TH_CD;
    public int _TH_CD
    {
        get
        {
            return TH_CD;
        }
        set
        {
            TH_CD = value;
        }
    }
    private int TH_ID;
    public int _TH_ID
    {
        get
        {
            return TH_ID;
        }
        set
        {
            TH_ID = value;
        }
    }
    private string TH_NAME;
    public string _TH_NAME
    {
        get
        {
            return TH_NAME;
        }
        set
        {
            TH_NAME = value;
        }
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for uploadfileentity
/// </summary>
public class uploadfileentity
{
    //TigerReserveID
	public uploadfileentity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //stateid

    private Int64 TigerReserveID;
    public Int64 _TigerReserveID
    {
        get
        {
            return TigerReserveID;
        }
        set
        {
            TigerReserveID = value;
        }
    }


    private Int64 stateid;
    public Int64 _stateid
    {
        get
        {
            return stateid;
        }
        set
        {
            stateid = value;
        }
    }

    private Int64 v_id;
    public Int64 _v_id
    {
        get
        {
            return v_id;
        }
        set
        {
            v_id = value;
        }
    }


    private string title;
    public string _title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }
    private string type;
    public string _type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    private string description;
    public string _description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }
    private string filename;
    public string _filename
    {
        get
        {
            return filename;
        }
        set
        {
            filename = value;
        }
    }

    private string year;
    public string _year
    {
        get
        {
            return year;
        }
        set
        {
            year = value;
        }
    }

    private string option;
    public string _option
    {
        get
        {
            return option;
        }
        set
        {
            option = value;
        }
    }

    private string fund;
    public string _fund
    {
        get
        {
            return fund;
        }
        set
        {
            fund = value;
        }
    }
}

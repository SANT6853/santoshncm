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
/// Summary description for Associate_Village
/// </summary>
public class Associate_Village
{
	public Associate_Village()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _villageid;
    public int villageid
    {
        get
        {
            return _villageid;
        }
        set
        {
            _villageid = value;
        }


    }
    private int _ngoid;
    public int ngoid
    {
        get
        {
            return _ngoid;
        }
        set
        {
            _ngoid = value;
        }


    }
    private double _amount;
    public double amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }


    }
    private string _work_done_by_ngo;
    public string work_done_by_ngo
    {
        get
        {
            return _work_done_by_ngo;
        }
        set
        {
            _work_done_by_ngo = value;
        }
    }
    public int? UserID { get; set; }
}

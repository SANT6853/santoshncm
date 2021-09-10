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
/// Summary description for RelocationProgresEntity
/// </summary>
public class RelocationProgresEntity
{
	public RelocationProgresEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string DATE;
    public string _DATE
    {
        get
        {
            return DATE;
        }
        set
        {
            DATE = value;
        }
    }
    private string STATENAME;
    public string _STATENAME
    {
        get
        {
            return STATENAME;
        }
        set
        {
            STATENAME = value;
        }
    }
    private string RESERVNAME;
    public string _RESERVNAME
    {
        get
        {
            return RESERVNAME;
        }
        set
        {
            RESERVNAME = value;
        }
    }
    public int? UserID { get; set; }
    private string REMARKS;
    public string _REMARKS
    {
        get
        {
            return REMARKS;
        }
        set
        {
            REMARKS = value;
        }
    }
    private long VILLAGE;
    public long _VILLAGE
    {
        get
        {
            return VILLAGE;
        }
        set
        {
            VILLAGE = value;
        }
    }
    private long RELOCVILLAGE;
    public long _RELOCVILLAGE
    {
        get
        {
            return RELOCVILLAGE;
        }
        set
        {
            RELOCVILLAGE = value;
        }
    }
    private long REMAININGVILLAGE;
    public long _REMAININGVILLAGE
    {
        get
        {
            return REMAININGVILLAGE;
        }
        set
        {
            REMAININGVILLAGE = value;
        }
    }
    private long FAMILY;
    public long _FAMILY
    {
        get
        {
            return FAMILY;
        }
        set
        {
            FAMILY = value;
        }
    }
    private long RELOCFAMILY;
    public long _RELOCFAMILY
    {
        get
        {
            return RELOCFAMILY;
        }
        set
        {
            RELOCFAMILY = value;
        }
    }
    private long REMAINFAMILY;
    public long _REMAINFAMILY
    {
        get
        {
            return REMAINFAMILY;
        }
        set
        {
            REMAINFAMILY = value;
        }
    }
    private long  MONEYPERFAMILY;
    public  long _MONEYPERFAMILY
    {
        get
        {
            return MONEYPERFAMILY;
        }
        set
        {
            MONEYPERFAMILY = value;
        }
    }
      private long LANDPACKAGE;
    public long _LANDPACKAGE
    {
        get
        {
            return LANDPACKAGE;
        }
        set
        {
            LANDPACKAGE = value;
        }
    }
      private long MONEYANDLAND;
    public long _MONEYANDLAND
    {
        get
        {
            return MONEYANDLAND;
        }
        set
        {
            MONEYANDLAND = value;
        }
    }
      private long RELOCOTHERPCK;
    public long _RELOCOTHERPCK
    {
        get
        {
            return RELOCOTHERPCK;
        }
        set
        {
            RELOCOTHERPCK = value;
        }
    }
    //private long NOOFVILLAGECORE;
    //public long _NOOFVILLAGECORE
    //{
    //    get
    //    {
    //        return NOOFVILLAGECORE;
    //    }
    //    set
    //    {
    //        NOOFVILLAGECORE = value;
    //    }
    //}
    //  private long NOOFFAMILYCORE;
    //public long _NOOFFAMILYCORE
    //{
    //    get
    //    {
    //        return NOOFFAMILYCORE;
    //    }
    //    set
    //    {
    //        NOOFFAMILYCORE = value;
    //    }
    //}
    
}

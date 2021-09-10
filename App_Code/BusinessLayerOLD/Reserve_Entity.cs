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
/// Summary description for Reserve_Entity
/// </summary>
public class Reserve_Entity
{
	public Reserve_Entity()
	{
        RSRV_ID = null;
        RSRV_CD =null;
        RSRV_AREA_NM = null;
        RSRV_NO_Vill = 0;
        RSRV_TOT_LND_AREA = 0.0;
        RSRV_TOT_AGRI_LND_AREA = 0.0;
        RSRV_TOT_NONAGRI_LND_AREA = 0.0;
        RSRV_CAT = null;
        RSRV_POPU = 0;
       
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

    private string RSRV_CD;
    public string _RSRV_CD
    {
        get
        {
            return RSRV_CD;
        }
        set
        {
            RSRV_CD = value;
        }
    }

    private string RSRV_AREA_NM;
    public string _RSRV_AREA_NM
    {
        get
        {
            return RSRV_AREA_NM;
        }
        set
        {
            RSRV_AREA_NM = value;
        }
    }

    private int RSRV_NO_Vill;
    public int _RSRV_NO_Vill
    {
        get
        {
            return RSRV_NO_Vill;
        }
        set
        {
            RSRV_NO_Vill = value;
        }
    }

    private double RSRV_TOT_LND_AREA;
    public double _RSRV_TOT_LND_AREA
    {
        get
        {
            return RSRV_TOT_LND_AREA;
        }
        set
        {
            RSRV_TOT_LND_AREA = value;
        }
    }

    private double RSRV_TOT_AGRI_LND_AREA;
    public double _RSRV_TOT_AGRI_LND_AREA
    {
        get
        {
            return RSRV_TOT_AGRI_LND_AREA;
        }
        set
        {
            RSRV_TOT_AGRI_LND_AREA = value;
        }
    }

    private double RSRV_TOT_NONAGRI_LND_AREA;
    public double _RSRV_TOT_NONAGRI_LND_AREA
    {
        get
        {
            return RSRV_TOT_NONAGRI_LND_AREA;
        }
        set
        {
            RSRV_TOT_NONAGRI_LND_AREA = value;
        }
    }


    private string RSRV_CAT;
    public string _RSRV_CAT
    {
        get
        {
            return RSRV_CAT;
        }
        set
        {
            RSRV_CAT = value;
        }
    }

    private long RSRV_POPU;
    public long _RSRV_POPU
    {
        get
        {
            return RSRV_POPU;
        }
        set
        {
            RSRV_POPU = value;
        }
    }


}

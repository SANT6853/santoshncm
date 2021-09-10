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
/// Summary description for SellerEntity
/// </summary>
public class SellerEntity
{
	public SellerEntity()
	{
        SELR_NM = null;
        SELR_PARNT = null;
        SELR_VILL_NM = null;
        SELR_TH_NM = null;
        SELR_LAND_AREA = 0.0;
        SELR_DT = null;
        SEL_AGRMT_DTL = null;
        FILE_NAME = null;
        SELR_DISTRICT = null;
        SELR_FUL_ADD = null;
        ST_NAME = null;
        GP_NAME = null;
        DISTANCE = 0;




	}
    private string SELR_NM;
    public string  _SELR_NM
    {
        get
        {
            return SELR_NM;
        }
        set
        {
            SELR_NM = value;
        }
    }
    private string SELR_PARNT;
    public string  _SELR_PARNT
    {
        get
        {
            return SELR_PARNT;
        }
        set
        {
            SELR_PARNT = value;
        }
    }
    private string SELR_VILL_NM;
    public string _SELR_VILL_NM
    {
        get
        {
            return SELR_VILL_NM;
        }
        set
        {
            SELR_VILL_NM = value;
        }
    }
    private string SELR_TH_NM;
    public string _SELR_TH_NM
    {
        get
        {
            return SELR_TH_NM;
        }
        set
        {
            SELR_TH_NM = value;
        }
    }
    private string KHASRA_NO;
    public string _KHASRA_NO
    {
        get
        {
            return KHASRA_NO;
        }
        set
        {
            KHASRA_NO = value;
        }
    }
    private double  SELR_LAND_AREA;
    public double _SELR_LAND_AREA
    {
        get
        {
            return SELR_LAND_AREA;
        }
        set
        {
            SELR_LAND_AREA = value;
        }
    }

    private string  SELR_DT;
    public string  _SELR_DT
    {
        get
        {
            return SELR_DT;
        }
        set
        {
            SELR_DT = value;
        }
    }

    private string SEL_AGRMT_DTL;
    public string _SEL_AGRMT_DTL
    {
        get
        {
            return SEL_AGRMT_DTL;
        }
        set
        {
            SEL_AGRMT_DTL = value;
        }
    }

    private string FILE_NAME;
    public string _FILE_NAME
    {
        get
        {
            return FILE_NAME;
        }
        set
        {
            FILE_NAME = value;
        }
    }
    private string SELR_DISTRICT;
    public string _SELR_DISTRICT
    {
        get
        {
            return SELR_DISTRICT;
        }
        set
        {
            SELR_DISTRICT = value;
        }
    }
     private string SELR_FUL_ADD;
    public string _SELR_FUL_ADD
    {
        get
        {
            return SELR_FUL_ADD;
        }
        set
        {
            SELR_FUL_ADD = value;
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
    private decimal DISTANCE;
    public decimal _DISTANCE
    {
        get
        {
            return DISTANCE;
        }
        set
        {
            DISTANCE = value;
        }
    }
} 

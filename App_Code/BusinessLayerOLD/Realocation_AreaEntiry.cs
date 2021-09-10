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
/// Summary description for Realocation_AreaEntiry
/// </summary>
public class Realocation_AreaEntiry
{
	public Realocation_AreaEntiry()
	{
	    RELOC_SITE=null;
        RELOC_SITE_AREA=0.0;
        RELOC_LGL_STAT = null;


        RELOC_AREA_ID= null;
        RELOC_SITE_ADD= null;
        ST_NM = null;
        DT_NM = null;
        TH_NM= null;
        GP_NM= null;
        VILL_NM= null;
        COMMENT = null;
        VILL_ID = null;
        KHASRA_NO = null;

    }
    private string RELOC_SITE;
    public string _RELOC_SITE
    {
        get
        {
            return RELOC_SITE;
        }
        set
        {
            RELOC_SITE = value;
        }
    }

    private double RELOC_SITE_AREA;
    public double _RELOC_SITE_AREA
    {
        get
        {
            return RELOC_SITE_AREA;
        }
        set
        {
            RELOC_SITE_AREA = value;
        }
    }

    private string RELOC_LGL_STAT;
    public string _RELOC_LGL_STAT
    {
        get
        {
            return RELOC_LGL_STAT;
        }
        set
        {
            RELOC_LGL_STAT = value;
        }
    }





     private string RELOC_AREA_ID;
    public string _RELOC_AREA_ID
    {
        get
        {
            return RELOC_AREA_ID;
        }
        set
        {
            RELOC_AREA_ID = value;
        }
    }
     private string RELOC_SITE_ADD;
    public string _RELOC_SITE_ADD
    {
        get
        {
            return RELOC_SITE_ADD;
        }
        set
        {
            RELOC_SITE_ADD = value;
        }
    }
     private string ST_NM;
    public string _ST_NM
    {
        get
        {
            return ST_NM;
        }
        set
        {
            ST_NM = value;
        }
    }
     private string DT_NM;
    public string _DT_NM
    {
        get
        {
            return DT_NM;
        }
        set
        {
            DT_NM = value;
        }
    }
     private string TH_NM;
    public string _TH_NM
    {
        get
        {
            return TH_NM;
        }
        set
        {
            TH_NM = value;
        }
    }
     private string GP_NM;
    public string _GP_NM
    {
        get
        {
            return GP_NM;
        }
        set
        {
            GP_NM = value;
        }
    }
     private string VILL_NM;
    public string _VILL_NM
    {
        get
        {
            return VILL_NM;
        }
        set
        {
            VILL_NM = value;
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
   // public string Longitude { get; set; }
    //public string Latitude { get; set; }
    public string TigerReserveName { get; set; }
    private string VILL_ID;
    public string _VILL_ID
    {
        get
        {
            return VILL_ID;
        }
        set
        {
            VILL_ID = value;
        }
    }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int? Userid { get; set; }
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
}

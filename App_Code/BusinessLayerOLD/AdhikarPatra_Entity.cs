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
/// Summary description for AdhikarPatra_Entity
/// </summary>
public class AdhikarPatra_Entity
{
	public AdhikarPatra_Entity()
	{
        DATE_OF_ISSUE = null;
        REL_VILL_NM = "";
        REL_TH_NM = "";
        REL_DST_NM = "";
        REL_ST_NM = "";
        REL_RES_AREA = 0.0;
        REL_AGR_AREA = 0.0;
        HOLDER_NAME = "";
        REL_GP_NM  = "";
        REL_KHSRA_NO = "";
        REL_ADDRESS = "";
        RELOC_AREA_ID = null;
	}
    private string DATE_OF_ISSUE;
    public string _DATE_OF_ISSUE
    {
        get
        {
            return DATE_OF_ISSUE;
        }
        set
        {
            DATE_OF_ISSUE = value;
        }
    }
    private string REL_VILL_NM;
    public string _REL_VILL_NM
    {
        get
        {
            return REL_VILL_NM;
        }
        set
        {
            REL_VILL_NM = value;
        }
    }
    private string REL_TH_NM;
    public string _REL_TH_NM
    {
        get
        {
            return REL_TH_NM;
        }
        set
        {
            REL_TH_NM = value;
        }
    }
    private string REL_DST_NM;
    public string _REL_DST_NM
    {
        get
        {
            return REL_DST_NM;
        }
        set
        {
            REL_DST_NM = value;
        }
    }
    private string REL_ST_NM;
    public string _REL_ST_NM
    {
        get
        {
            return REL_ST_NM;
        }
        set
        {
            REL_ST_NM = value;
        }
    }
    private double  REL_RES_AREA;
    public double  _REL_RES_AREA
    {
        get
        {
            return REL_RES_AREA;
        }
        set
        {
            REL_RES_AREA = value;
        }
    }
    private double REL_AGR_AREA;
    public double _REL_AGR_AREA
    {
        get
        {
            return REL_AGR_AREA;
        }
        set
        {
            REL_AGR_AREA = value;
        }
    }
    private string  HOLDER_NAME;
    public string  _HOLDER_NAME
    {
        get
        {
            return HOLDER_NAME;
        }
        set
        {
            HOLDER_NAME = value;
        }
    }

    private string  REL_GP_NM;
    public string  _REL_GP_NM
    {
        get
        {
            return REL_GP_NM;
        }
        set
        {
            REL_GP_NM = value;
        }
    }
    private string  REL_KHSRA_NO;
    public string  _REL_KHSRA_NO
    {
        get
        {
            return REL_KHSRA_NO;
        }
        set
        {
            REL_KHSRA_NO = value;
        }
    }

    private string  REL_ADDRESS;
    public string  _REL_ADDRESS
    {
        get
        {
            return REL_ADDRESS;
        }
        set
        {
        REL_ADDRESS = value;
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
}
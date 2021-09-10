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
/// Summary description for SchemeEntity
/// </summary>
public class SchemeEntity
{
	public SchemeEntity()
	{
		SCHM_NM=null;
        SCHM_AVL_AMT=0.0;
        SCHM_CRITA=0;
        SCHM_ST_YEAR=0.0;
        SCHM_DURATION=0.0;
        SCHM_COMP_AREA = null;

	}

    private string SCHM_NM;
    public string _SCHM_NM
    {
        get
        {
            return SCHM_NM;
        }
        set
        {
            SCHM_NM = value;
        }
    }

    private double SCHM_AVL_AMT;
    public double _SCHM_AVL_AMT
    {
        get
        {
            return SCHM_AVL_AMT;
        }
        set
        {
            SCHM_AVL_AMT = value;
        }
    }

    private int SCHM_CRITA;
    public int _SCHM_CRITA
    {
        get
        {
            return SCHM_CRITA;
        }
        set
        {
            SCHM_CRITA = value;
        }
    }

    private double SCHM_ST_YEAR;
    public double _SCHM_ST_YEAR
    {
        get
        {
            return SCHM_ST_YEAR;
        }
        set
        {
            SCHM_ST_YEAR = value;
        }
    }

    private double SCHM_DURATION;
    public double _SCHM_DURATION
    {
        get
        {
            return SCHM_DURATION;
        }
        set
        {
            SCHM_DURATION = value;
        }
    }

    private string SCHM_COMP_AREA;
    public string _SCHM_COMP_AREA

    {
        get
        {
            return SCHM_COMP_AREA;
        }
        set
        {
            SCHM_COMP_AREA = value;
        }
    }
}



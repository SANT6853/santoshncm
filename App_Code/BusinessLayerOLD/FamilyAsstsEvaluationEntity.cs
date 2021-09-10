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
/// Summary description for FamilyAsstsEvaluationEntity
/// </summary>
public class FamilyAsstsEvaluationEntity
{
    //public FamilyAsstsEvaluationEntity()
    //{
    //    FMLY_ASST_ID = null;
    //    AGRI_LND_VAL = 0.0;
    //    RES_LND_VAL = 0.0;
    //    TREES_VAL = 0.0;
    //    WELLS_VAL = 0.0;
    //    OTHERS_VAL = 0.0;

    //}

    private string FMLY_ASST_ID;
    public  string _FMLY_ASST_ID
    {
        get
        {
            return FMLY_ASST_ID;
        }
        set
        {
            FMLY_ASST_ID = value;
        }
    }


    private double AGRI_LND_VAL;
    public  double _AGRI_LND_VAL
    {
        get
        {
            return AGRI_LND_VAL;
        }
        set
        {
            AGRI_LND_VAL = value;
        }
    }

    private double RES_LND_VAL;
    public  double _RES_LND_VAL
    {
        get
        {
            return RES_LND_VAL;
        }
        set
        {
            RES_LND_VAL = value;
        }
    }

    private double TREES_VAL;
    public  double _TREES_VAL
    {
        get
        {
            return TREES_VAL;
        }
        set
        {
            TREES_VAL = value;
        }
    }

    private double WELLS_VAL;
    public double _WELLS_VAL
    {
        get
        {
            return WELLS_VAL;
        }
        set
        {
            WELLS_VAL = value;
        }
    }

    private double OTHERS_VAL;
    public double _OTHERS_VAL
    {
        get
        {
            return OTHERS_VAL;
        }
        set
        {
            OTHERS_VAL = value;
        }
    }
}

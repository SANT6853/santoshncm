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
/// Summary description for FD_DetailEntity
/// </summary>
public class FD_DetailEntity
{
	public FD_DetailEntity()
	{
        FD_ID = null;
        FD_AMT = 0.0 ;
        FD_NO = null;
        FD_DATE_OF_DT = null;
        FD_DATE_MTRTY_DT = null;
        ACC_NO = null;
        FD_HOLD_NM = null;
        OCCUPATION = 0;
        FAMILY_ID = 0;
        BANK_NAME = null;
        BRANCH_NAME = null;
        INST_ISCM_ID = null;
        HOUSE_CONS = false;

	}
    private string BANK_NAME;
    public string _BANK_NAME
    {
        get
        {
            return BANK_NAME;
        }
        set
        {
            BANK_NAME = value;
        }
    }
    private string BRANCH_NAME;
    public string _BRANCH_NAME
    {
        get
        {
            return BRANCH_NAME;
        }
        set
        {
            BRANCH_NAME = value;
        }
    }
    private string FD_ID;
    public string _FD_ID
    {
        get
        {
            return FD_ID;
        }
        set
        {
            FD_ID = value;
        }
    }
    private Int64 FAMILY_ID;
    public Int64 _FAMILY_ID
    {
        get
        {
            return FAMILY_ID;
        }
        set
        {
            FAMILY_ID = value;
        }
    }
    private double   FD_AMT;
    public double  _FD_AMT
    {
        get
        {
            return FD_AMT;
        }
        set
        {
            FD_AMT = value;
        }
    }
    private string  FD_NO;
    public string  _FD_NO
    {
        get
        {
            return FD_NO;
        }
        set
        {
            FD_NO = value;
        }
    }
    private string FD_DATE_OF_DT;
    public string _FD_DATE_OF_DT
    {
        get
        {
            return FD_DATE_OF_DT;
        }
        set
        {
            FD_DATE_OF_DT = value;
        }
    }
    private string FD_DATE_MTRTY_DT;
    public string _FD_DATE_MTRTY_DT
    {
        get
        {
            return FD_DATE_MTRTY_DT;
        }
        set
        {
            FD_DATE_MTRTY_DT = value;
        }
    }
    private string ACC_NO;
    public string _ACC_NO
    {
        get
        {
            return ACC_NO;
        }
        set
        {
            ACC_NO = value;
        }
    }
    private string FD_HOLD_NM;
    public string _FD_HOLD_NM
    {
        get
        {
            return FD_HOLD_NM;
        }
        set
        {
            FD_HOLD_NM = value;
        }
    }
    private int OCCUPATION;
    public int _OCCUPATION
    {
        get
        {
            return OCCUPATION;
        }
        set
        {
            OCCUPATION = value;
        }
    }
    private string INST_ISCM_ID;
    public string _INST_ISCM_ID
    {
        get
        {
            return INST_ISCM_ID;
        }
        set
        {
            INST_ISCM_ID = value;
        }
    }
    private bool HOUSE_CONS;
    public bool _HOUSE_CONS
    {
        get
        {
            return HOUSE_CONS;
        }
        set
        {
            HOUSE_CONS = value;
        }
    }
    
}

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
/// Summary description for Relocation_InstallmentEntity
/// </summary>
public class Relocation_InstallmentEntity
{
	public Relocation_InstallmentEntity()
	{
        //RELOC_INSTL_DT = null;
        //RELOC_INSTL_AMT = 0.0;.
        INST_ISCM_ID = null;
        SCHM_ID = 0;
        FMLY_ID =0;
        INST_ISCM_CHK_NO = null ;
        INST_ISCM_NO = 0;
        INST_ISCM_CHK_DT = null;
        BANK_NAME = null ;
        BRANCH_NAME = null;
        INST_ISCM_AMT = 0.0;
        INST_ISCM_HOLD_NM = null ;
        REC_CRT_DT = null;
        ACCOUNT_NO = null;
        SUB_INST_ISCM_NO = 0.0;
        CHK_BANK_NM = null;
        CHK_BRANCH_NM = null;
        INFRA_AMT = 0;


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
    private double  SUB_INST_ISCM_NO;
    public double  _SUB_INST_ISCM_NO
    {
        get
        {
            return SUB_INST_ISCM_NO;
        }
        set
        {
            SUB_INST_ISCM_NO = value;
        }
    }
    private string  ACCOUNT_NO;
    public string  _ACCOUNT_NO
    {
        get
        {
            return ACCOUNT_NO;
        }
        set
        {
            ACCOUNT_NO = value;
        }
    }
    private Int64 SCHM_ID;
    public Int64 _SCHM_ID
    {
        get
        {
            return Convert .ToInt64(SCHM_ID);
        }
        set
        {
            SCHM_ID = value;
        }
    }
    private Int64 FMLY_ID;
    public Int64 _FMLY_ID
    {
        get
        {
            return Convert.ToInt64(FMLY_ID);
        }
        set
        {
            FMLY_ID = value;
        }
    }
    private string INST_ISCM_CHK_NO;
    public string _INST_ISCM_CHK_NO
    {
        get
        {
            return INST_ISCM_CHK_NO;
        }
        set
        {
            INST_ISCM_CHK_NO = value;
        }
    }
    private int  INST_ISCM_NO;
    public int _INST_ISCM_NO
    {
        get
        {
            return INST_ISCM_NO;
        }
        set
        {
            INST_ISCM_NO = value;
        }
    }
    private string  INST_ISCM_CHK_DT;
    public string   _INST_ISCM_CHK_DT
    {
        get
        {
            return INST_ISCM_CHK_DT;
        }
        set
        {
            INST_ISCM_CHK_DT = value;
        }
    }
    private string  BANK_NAME;
    public string  _BANK_NAME
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
    
    private double  INST_ISCM_AMT;
    public double  _INST_ISCM_AMT
    {
        get
        {
            return INST_ISCM_AMT;
        }
        set
        {
            INST_ISCM_AMT = value;
        }
    }
    private string  INST_ISCM_HOLD_NM;
    public string  _INST_ISCM_HOLD_NM
    {
        get
        {
            return INST_ISCM_HOLD_NM;
        }
        set
        {
            INST_ISCM_HOLD_NM = value;
        }
    }
    private string   REC_CRT_DT;
    public string   _REC_CRT_DT
    {
        get
        {
            return REC_CRT_DT;
        }
        set
        {
            REC_CRT_DT = value;
        }
    }
    //private string RELOC_INSTL_DT;
    //public string _RELOC_INSTL_DT
    //{
    //    get
    //    {
    //        return RELOC_INSTL_DT;
    //    }
    //    set
    //    {
    //        RELOC_INSTL_DT = value;
    //    }
    //}

    //private double RELOC_INSTL_AMT;
    //public double _RELOC_INSTL_AMT
    //{
    //    get
    //    {
    //        return RELOC_INSTL_AMT;
    //    }
    //    set
    //    {
    //        RELOC_INSTL_AMT = value;
    //    }
    //}
    private string CHK_BANK_NM;
    public string _CHK_BANK_NM
    {
        get
        {
            return CHK_BANK_NM;
        }
        set
        {
            CHK_BANK_NM = value;
        }
    } 
    private string CHK_BRANCH_NM;
    public string _CHK_BRANCH_NM
    {
        get
        {
            return CHK_BRANCH_NM;
        }
        set
        {
            CHK_BRANCH_NM = value;
        }
    }
    private decimal INFRA_AMT;
    public decimal _INFRA_AMT
    {
        get
        {
            return INFRA_AMT;
        }
        set
        {
            INFRA_AMT = value;
        }
    }
    
}

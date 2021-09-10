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
/// Summary description for Family_DetailEntity
/// </summary>
public class Family_DetailEntity
{
	public Family_DetailEntity()
	{
        FMLY_MEMB_ID = null;
        FMLY_MEMB_NM = null;
        FMLY_MEMB_REL=0;
        FMLY_MEMB_AGE=0;
        FMLY_MEMB_SEX=0;
        FMLY_MEMB_EDU=null;
        FMLY_MEMB_ANUL_INCM=0.0;
        FMLY_MEMB_OCC = 0;
        FATHER_NM = null;
        FMLY_MEMB_CAST=0;
        FMLY_MEMB_ID_NO = null;
        FMLY_MEMB_CONT_NO = null;
        FMLY_MEMB_ID_NAME = null;
  }

    private string FMLY_MEMB_ID;
    public string _FMLY_MEMB_ID
    {
        get
        {
            return FMLY_MEMB_ID;
        }
        set
        {
            FMLY_MEMB_ID = value;
        }
    }


    private int FMLY_MEMB_REG_CD;
    public int _FMLY_MEMB_REG_CD
    {
        get
        {
            return FMLY_MEMB_REG_CD;
        }
        set
        {
            FMLY_MEMB_REG_CD = value;
        }
    }
    public int? Action { get; set; }
    public int? FMLY_MEMB_IDs { get; set; }
    private string FMLY_MEMB_NM;
    public string _FMLY_MEMB_NM
    {
        get
        {
            return FMLY_MEMB_NM;
        }
        set
        {
            FMLY_MEMB_NM = value;
        }
    }

    private int FMLY_MEMB_REL;
    public int _FMLY_MEMB_REL
    {
        get
        {
            return FMLY_MEMB_REL;
        }
        set
        {
            FMLY_MEMB_REL = value;
        }
    }

    private int FMLY_MEMB_AGE;
    public int _FMLY_MEMB_AGE
    {
        get
        {
            return FMLY_MEMB_AGE;
        }
        set
        {
            FMLY_MEMB_AGE = value;
        }
    }

    private int FMLY_MEMB_SEX;
    public int _FMLY_MEMB_SEX
    {
        get
        {
            return FMLY_MEMB_SEX;
        }
        set
        {
            FMLY_MEMB_SEX = value;
        }
    }

    private string FMLY_MEMB_EDU;
    public string _FMLY_MEMB_EDU
    {
        get
        {
            return FMLY_MEMB_EDU;
        }
        set
        {
            FMLY_MEMB_EDU = value;
        }
    }


    private double FMLY_MEMB_ANUL_INCM;
    public double _FMLY_MEMB_ANUL_INCM
    {
        get
        {
            return FMLY_MEMB_ANUL_INCM;
        }
        set
        {
            FMLY_MEMB_ANUL_INCM = value;
        }
    }

    private int FMLY_MEMB_OCC;
    public int _FMLY_MEMB_OCC
    {
        get
        {
            return FMLY_MEMB_OCC;
        }
        set
        {
            FMLY_MEMB_OCC = value;
        }
    }


    private string FATHER_NM;
    public string _FATHER_NM
    {
        get
        {
            return FATHER_NM;
        }
        set
        {
            FATHER_NM = value;
        }
    }
    private int FMLY_MEMB_CAST;
    public int _FMLY_MEMB_CAST
    {
        get
        {
            return FMLY_MEMB_CAST;
        }
        set
        {
            FMLY_MEMB_CAST = value;
        }
    }
    private string FMLY_MEMB_ID_NO;
    public string _FMLY_MEMB_ID_NO
    {
        get
        {
            return FMLY_MEMB_ID_NO;
        }
        set
        {
            FMLY_MEMB_ID_NO = value;
        }
    }
    private string FMLY_MEMB_CONT_NO;
    public string _FMLY_MEMB_CONT_NO
    {
        get
        {
            return FMLY_MEMB_CONT_NO;
        }
        set
        {
            FMLY_MEMB_CONT_NO = value;
        }
    }
    private string FMLY_MEMB_ID_NAME;
    public string _FMLY_MEMB_ID_NAME
    {
        get
        {
            return FMLY_MEMB_ID_NAME;
        }
        set
        {
            FMLY_MEMB_ID_NAME = value;
        }
    }
    private Int64 RANDOM_NO;
    public Int64 _RANDOM_NO
    {
        get
        {
            return RANDOM_NO;
        }
        set
        {
            RANDOM_NO = value;
        }
    }

    public string DOB { get; set; }
    public string PenCard { get; set; }
    public string AdhaarCard { get; set; }
    public string Others { get; set; }
    public string Transgender { get; set; }
    public string NoBeneficiary { get; set; }
    public string MaritalStatus { get; set; }
    public string BankNameMobile { get; set; }
    public string BankPostAccountNo { get; set; }
    public string BankPostOfficeName { get; set; }
    public string IFSC { get; set; }
    public string BankPostOfficeAdress { get; set; }
    public string AadharNo { get; set; }
    public string Photo { get; set; }
    public string IdentityCardPhoto { get; set; }
    public DataTable IdentityCard { get; set; }
    public string IdentityCardPhotoTitle { get; set; }
	 public string BenAddress { get; set; }
    public string BenMobile { get; set; }
 
   
}

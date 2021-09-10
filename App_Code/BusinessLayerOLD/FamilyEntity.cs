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
/// Summary description for FamilyEntity
/// </summary>
public class FamilyEntity
{
	public FamilyEntity()
	{
        FMLY_ID = null; 
        SURVEY_DT = null;
        FMLY_REG_CD = null;
        FMLY_NO_MEMB = 0;
        FMLY_ANUL_INCM=0.0;
        FMLY_STAT = 0;
        FMLY_VALID_ID_NO = null;
        FMLY_AGRI_LND = 0.0;
        FMLY_RESI_LND = 0.0;
        RESI_LND_STS = 0;
        FMLY_WELLS= 0;
        FMLY_TREES=0;
        FMLY_OTHR_ASSETS = 0;
        FMLY_LIVESTOCK  =0;
        FMLY_COW_BUFF=0;
        FMLY_SHEEP_GOAT=0;
        FMLY_OTHER_ANML=0;
        GROUP_NM = 0;
        SCHM_ID = 0;
        COMMENT = null;
        FMLY_VALID_ID_NAME = null;
        RELOATION_PLACE = null;

    }

    public string OtherOptions { get; set; }
    private string FMLY_ID;
    
    public string _FMLY_ID
    {
        get
        {
            return FMLY_ID;
        }
        set
        {
            FMLY_ID = value;
        }
    }

    private string SURVEY_DT;
    public string _SURVEY_DT
    {
        get
        {
            return SURVEY_DT;
        }
        set
        {
        
            SURVEY_DT = value;
        }
    }




    private string FMLY_REG_CD;
    public string _FMLY_REG_CD
    {
        get
        {
            return FMLY_REG_CD;
        }
        set
        {
            FMLY_REG_CD = value;
        }
    }

    private int FMLY_NO_MEMB;
    public int _FMLY_NO_MEMB
    {
        get
        {
            return FMLY_NO_MEMB;
        }
        set
        {
            FMLY_NO_MEMB = value;
        }
    }

    
    private int FMLY_STAT;
    public int _FMLY_STAT
    {
        get
        {
            return FMLY_STAT;
        }
        set
        {
            FMLY_STAT = value;
        }
    }


    private string FMLY_VALID_ID_NO;
    public string _FMLY_VALID_ID_NO
    {
        get
        {
            return FMLY_VALID_ID_NO;
        }
        set
        {

            FMLY_VALID_ID_NO = value;
        }
    }


    private double FMLY_AGRI_LND;
    public double _FMLY_AGRI_LND
    {
        get
        {
            return FMLY_AGRI_LND;
        }
        set
        {

            FMLY_AGRI_LND = value;
        }
    }
    private double FMLY_RESI_LND;
    public double _FMLY_RESI_LND
    {
        get
        {
            return FMLY_RESI_LND;
        }
        set
        {

            FMLY_RESI_LND = value;
        }
    }

    private int RESI_LND_STS;
    public int _RESI_LND_STS
    {
        get
        {
            return RESI_LND_STS;
        }
        set
        {

            RESI_LND_STS = value;
        }
    }


    private int FMLY_WELLS;
    public int _FMLY_WELLS
    {
        get
        {
            return FMLY_WELLS;
        }
        set
        {

            FMLY_WELLS = value;
        }
    }
    private int FMLY_TREES;
    public int _FMLY_TREES
    {
        get
        {
            return FMLY_TREES;
        }
        set
        {

            FMLY_TREES = value;
        }
    }

    private int FMLY_OTHR_ASSETS;
    public int _FMLY_OTHR_ASSETS
    {
        get
        {
            return FMLY_OTHR_ASSETS;
        }
        set
        {

            FMLY_OTHR_ASSETS = value;
        }
    }
    
    private int FMLY_LIVESTOCK;
    public int _FMLY_LIVESTOCK
    {
        get
        {
            return FMLY_LIVESTOCK;
        }
        set
        {

            FMLY_LIVESTOCK = value;
        }
    }
    private int FMLY_COW_BUFF;
    public int _FMLY_COW_BUFF
    {
        get
        {
            return FMLY_COW_BUFF;
        }
        set
        {

            FMLY_COW_BUFF = value;
        }
    }
    private int FMLY_SHEEP_GOAT;
    public int _FMLY_SHEEP_GOAT
    {
        get
        {
            return FMLY_SHEEP_GOAT;
        }
        set
        {

            FMLY_SHEEP_GOAT = value;
        }
    }
    private int GROUP_NM;
    public int _GROUP_NM
    {
        get
        {
            return GROUP_NM;
        }
        set
        {

            GROUP_NM = value;
        }
    }
    private int SCHM_ID;
    public int _SCHM_ID
    {
        get
        {
            return SCHM_ID;
        }
        set
        {

            SCHM_ID = value;
        }
    }
    private int FMLY_OTHER_ANML;
    public int _FMLY_OTHER_ANML
    {
        get
        {
            return FMLY_OTHER_ANML;
        }
        set
        {

            FMLY_OTHER_ANML = value;
        }
    }



    private double FMLY_ANUL_INCM;
    public double _FMLY_ANUL_INCM
    {
        get
        {
            return FMLY_ANUL_INCM;
        }
        set
        {

            FMLY_ANUL_INCM = value;
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

    private string FMLY_VALID_ID_NAME;
    public string _FMLY_VALID_ID_NAME
    {
        get
        {
            return FMLY_VALID_ID_NAME;
        }
        set
        {
            FMLY_VALID_ID_NAME = value;
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
    public int? NoCows { get; set; }
    public int? NoBuffalo { get; set; }
    public int? NoSheep { get; set; }
    public int? NoGoat { get; set; }


    private string RELOATION_PLACE;
    public string _RELOATION_PLACE
    {
        get
        {
            return RELOATION_PLACE;
        }
        set
        {
            RELOATION_PLACE = value;
        }
    }
     
 } 
 
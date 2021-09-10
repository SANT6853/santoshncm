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
/// Summary description for VillageEntity
/// </summary>
public class VillageEntity
{
    public VillageEntity()
    {
        VILL_ID = null;
        VILL_CD = null;
        VILL_NM = null;
        VILL_POPU = 0;
        VILL_TOT_LND_AREA = 0;
        VILL_TOT_AGRI_LND_AREA = 0;
        VILL_TOT_NON_AGRI_LND_AREA = 0;
        VILL_LGL_STAT = null;
        VILL_NO_FM = 0;
        VILL_NO_LIV_STOK = 0;
        VILL_TOT_OBC = 0;
        VILL_TOT_ST = 0;
        VILL_TOT_SC = 0;
        VILL_TOT_OTH = 0;
        VILL_STAT = null;
        ST_VILL_CD = null;
        VILL_MALE = 0;
        VILL_FEMALE = 0;
        VILL_OTHER_LND_AREA = 0;
        VILL_CUT_DT = System.DateTime.Now; ;
        VILL_SURVEY_DT = System.DateTime.Now;
        COMMENT = null;
        VILL_CR_BFFR_STS = 0;
        VILL_LNG1 = 0;
        VILL_LNG2 = 0;
        VILL_LNG3 = 0;
        VILL_LNG4 = 0;
        VILL_LONG1 = 0;
        VILL_LONG2 = 0;
        VILL_LONG3 = 0;
        VILL_LONG4 = 0;
        VILL_TOT_CNB = 0;
        VILL_TOT_SNG = 0;
        TOT_OTHR_ANML = 0;
        VILL_LNGMIN1 = 0;
        VILL_LNGMIN2 = 0;
        VILL_LNGMIN3 = 0;
        VILL_LNGMIN4 = 0;
        VILL_LONGMIN1 = 0;
        VILL_LONGMIN2 = 0;
        VILL_LONGMIN3 = 0;
        VILL_LONGMIN4 = 0;
        VILL_LNGSEC1 = 0;
        VILL_LNGSEC2 = 0;
        VILL_LNGSEC3 = 0;
        VILL_LNGSEC4 = 0;
        VILL_LONGSEC1 = 0;
        VILL_LONGSEC2 = 0;
        VILL_LONGSEC3 = 0;
        VILL_LONGSEC4 = 0;
        VILL_VAL_AGRI = 0;
        VILL_VAL_RES = 0;

    }
    public string KMLFile { get; set; }
    public int? VillageID { get; set; }
    public int? Action { get; set; }
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
 private string VILL_CD;
    public string _VILL_CD
    {
        get
        {
            return VILL_CD;
        }
        set
        {
            VILL_CD = value;
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
    public DateTime? CuttOffDate { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string FileName { get; set; }
    public DataTable filenames { get; set; }
 private long VILL_POPU;
    public long _VILL_POPU
    {
        get
        {
            return VILL_POPU;
        }
        set
        {
            VILL_POPU = value;
        }
    }

 private decimal VILL_TOT_LND_AREA;
    public decimal _VILL_TOT_LND_AREA
    {
        get
        {
            return VILL_TOT_LND_AREA;
        }
        set
        {
            VILL_TOT_LND_AREA = value;
        }
    }

    private decimal VILL_TOT_AGRI_LND_AREA;
    public decimal _VILL_TOT_AGRI_LND_AREA
    {
        get
        {
            return VILL_TOT_AGRI_LND_AREA;
        }
        set
        {
            VILL_TOT_AGRI_LND_AREA = value;
        }
    }

    private decimal VILL_TOT_NON_AGRI_LND_AREA;
    public decimal _VILL_TOT_NON_AGRI_LND_AREA
    {
        get
        {
            return VILL_TOT_NON_AGRI_LND_AREA;
        }
        set
        {
            VILL_TOT_NON_AGRI_LND_AREA = value;
        }
    }

    public int? StateID { get; set; }
 private string VILL_LGL_STAT;
    public string _VILL_LGL_STAT
    {
        get
        {
            return VILL_LGL_STAT;
        }
        set
        {
            VILL_LGL_STAT = value;
        }
    }

 private long VILL_NO_FM;
    public long _VILL_NO_FM
    {
        get
        {
            return VILL_NO_FM;
        }
        set
        {
            VILL_NO_FM = value;
        }
    }

 private int VILL_NO_LIV_STOK;
    public int _VILL_NO_LIV_STOK
    {
        get
        {
            return VILL_NO_LIV_STOK;
        }
        set
        {
            VILL_NO_LIV_STOK = value;
        }
    }

 private int VILL_TOT_OBC;
    public int _VILL_TOT_OBC
    {
        get
        {
            return VILL_TOT_OBC;
        }
        set
        {
            VILL_TOT_OBC = value;
        }
    }

 private int VILL_TOT_ST;
    public int _VILL_TOT_ST
    {
        get
        {
            return VILL_TOT_ST;
        }
        set
        {
            VILL_TOT_ST = value;
        }
    }

 private int VILL_TOT_SC;
    public int _VILL_TOT_SC
    {
        get
        {
            return VILL_TOT_SC;
        }
        set
        {
            VILL_TOT_SC = value;
        }
    }

 private int VILL_TOT_OTH;
    public int _VILL_TOT_OTH
    {
        get
        {
            return VILL_TOT_OTH;
        }
        set
        {
            VILL_TOT_OTH = value;
        }
    }

 private string VILL_STAT;
    public string _VILL_STAT
    {
        get
        {
            return VILL_STAT;
        }
        set
        {
            VILL_STAT = value;
        }
    }

    private string ST_VILL_CD;
    public string _ST_VILL_CD
    {
        get
        {
            return ST_VILL_CD;
        }
        set
        {
            ST_VILL_CD = value;
        }
    }
    private int VILL_MALE;
    public int _VILL_MALE
    {
        get
        {
            return VILL_MALE;
        }
        set
        {
            VILL_MALE = value;
        }
    }

    private int VILL_FEMALE;
    public int _VILL_FEMALE
    {
        get
        {
            return VILL_FEMALE;
        }
        set
        {
            VILL_FEMALE = value;
        }
    }

     private decimal VILL_OTHER_LND_AREA;
    public decimal _VILL_OTHER_LND_AREA
    {
        get
        {
            return VILL_OTHER_LND_AREA;
        }
        set
        {
            VILL_OTHER_LND_AREA = value;
        }
    }
      private DateTime VILL_CUT_DT;
    public DateTime _VILL_CUT_DT
            {
                get
                {
                    return VILL_CUT_DT;
                }
                set
                {
                    VILL_CUT_DT = value;
                }
            }
    private DateTime VILL_SURVEY_DT;
    public DateTime _VILL_SURVEY_DT
            {
                get
                {
                    return VILL_SURVEY_DT;
                }
                set
                {
                    VILL_SURVEY_DT = value;
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


    private int VILL_CR_BFFR_STS;
    public int _VILL_CR_BFFR_STS
            {
                get
                {
                    return VILL_CR_BFFR_STS;
                }
                set
                {
                    VILL_CR_BFFR_STS = value;
                }
            }


    private decimal VILL_LNG1;
    public decimal _VILL_LNG1
            {
                get
                {
                    return VILL_LNG1;
                }
                set
                {
                    VILL_LNG1 = value;
                }
            }
    private decimal VILL_LNG2;
    public decimal _VILL_LNG2
            {
                get
                {
                    return VILL_LNG2;
                }
                set
                {
                    VILL_LNG2 = value;
                }
            }
    private decimal VILL_LNG3;
    public decimal _VILL_LNG3
            {
                get
                {
                    return VILL_LNG3;
                }
                set
                {
                    VILL_LNG3 = value;
                }
            }
    private decimal VILL_LNG4;
    public decimal _VILL_LNG4
            {
                get
                {
                    return VILL_LNG4;
                }
                set
                {
                    VILL_LNG4 = value;
                }
            }
    private decimal VILL_LONG1;
    public decimal _VILL_LONG1
            {
                get
                {
                    return VILL_LONG1;
                }
                set
                {
                    VILL_LONG1 = value;
                }
            }private decimal VILL_LONG2;
    public decimal _VILL_LONG2
            {
                get
                {
                    return VILL_LONG2;
                }
                set
                {
                    VILL_LONG2 = value;
                }
            }private decimal VILL_LONG3;
    public decimal _VILL_LONG3
            {
                get
                {
                    return VILL_LONG3;
                }
                set
                {
                    VILL_LONG3 = value;
                }
            }
    
    
    private decimal VILL_LONG4;
            public decimal _VILL_LONG4
            {
                get
                {
                    return VILL_LONG4;
                }
                set
                {
                    VILL_LONG4 = value;
                }
            }

     private int VILL_TOT_CNB;
            public int _VILL_TOT_CNB
            {
                get
                {
                    return VILL_TOT_CNB;
                }
                set
                {
                    VILL_TOT_CNB = value;
                }
            }
    private int VILL_TOT_SNG;
            public int _VILL_TOT_SNG
            {
                get
                {
                    return VILL_TOT_SNG;
                }
                set
                {
                    VILL_TOT_SNG = value;
                }
            }
    
    private int TOT_OTHR_ANML;
            public int _TOT_OTHR_ANML
            {
                get
                {
                    return TOT_OTHR_ANML;
                }
                set
                {
                    TOT_OTHR_ANML = value;
                }
            }

     private int VILL_LNGMIN1;
            public int _VILL_LNGMIN1
            {
                get
                {
                    return VILL_LNGMIN1;
                }
                set
                {
                    VILL_LNGMIN1 = value;
                }
            }
            private int VILL_LNGMIN2;
            public int _VILL_LNGMIN2
            {
                get
                {
                    return VILL_LNGMIN2;
                }
                set
                {
                    VILL_LNGMIN2 = value;
                }
            }
            private int VILL_LNGMIN3;
            public int _VILL_LNGMIN3
            {
                get
                {
                    return VILL_LNGMIN3;
                }
                set
                {
                    VILL_LNGMIN3 = value;
                }
            }
            private int VILL_LNGMIN4;
            public int _VILL_LNGMIN4
            {
                get
                {
                    return VILL_LNGMIN4;
                }
                set
                {
                    VILL_LNGMIN4 = value;
                }
            }

    private int VILL_LONGMIN1;
    public int _VILL_LONGMIN1
            {
                get
                {
                    return VILL_LONGMIN1;
                }
                set
                {
                    VILL_LONGMIN1 = value;
                }

            }
            private int VILL_LONGMIN2;
            public int _VILL_LONGMIN2
            {
                get
                {
                    return VILL_LONGMIN2;
                }
                set
                {
                    VILL_LONGMIN2 = value;
                }
            }
            private int VILL_LONGMIN3;
            public int _VILL_LONGMIN3
            {
                get
                {
                    return VILL_LONGMIN3;
                }
                set
                {
                    VILL_LONGMIN3 = value;
                }
            }
            private int VILL_LONGMIN4;
            public int _VILL_LONGMIN4
            {
                get
                {
                    return VILL_LONGMIN4;
                }
                set
                {
                    VILL_LONGMIN4 = value;
                }
            }
    private int VILL_LNGSEC1;
    public int _VILL_LNGSEC1
            {
                get
                {
                    return VILL_LNGSEC1;
                }
                set
                {
                    VILL_LNGSEC1 = value;
                }
            }
            private int VILL_LNGSEC2;
            public int _VILL_LNGSEC2
            {
                get
                {
                    return VILL_LNGSEC2;
                }
                set
                {
                    VILL_LNGSEC2 = value;
                }
            }
            private int VILL_LNGSEC3;
            public int _VILL_LNGSEC3
            {
                get
                {
                    return VILL_LNGSEC3;
                }
                set
                {
                    VILL_LNGSEC3 = value;
                }
            }
            private int VILL_LNGSEC4;
            public int _VILL_LNGSEC4
            {
                get
                {
                    return VILL_LNGSEC4;
                }
                set
                {
                    VILL_LNGSEC4 = value;
                }
            }
    private int VILL_LONGSEC1;
    public int _VILL_LONGSEC1
            {
                get
                {
                    return VILL_LONGSEC1;
                }
                set
                {
                    VILL_LONGSEC1 = value;
                }
            }
            private int VILL_LONGSEC2;
            public int _VILL_LONGSEC2
            {
                get
                {
                    return VILL_LONGSEC2;
                }
                set
                {
                    VILL_LONGSEC2 = value;
                }
            }
            private int VILL_LONGSEC3;
            public int _VILL_LONGSEC3
            {
                get
                {
                    return VILL_LONGSEC3;
                }
                set
                {
                    VILL_LONGSEC3 = value;
                }
            }
            private int VILL_LONGSEC4;
            public int _VILL_LONGSEC4
            {
                get
                {
                    return VILL_LONGSEC4;
                }
                set
                {
                    VILL_LONGSEC4 = value;
                }
            }
        private decimal VILL_VAL_AGRI;
    public decimal _VILL_VAL_AGRI
            {
                get
                {
                    return VILL_VAL_AGRI;
                }
                set
                {
                    VILL_VAL_AGRI = value;
                }
            }   
    private decimal VILL_VAL_RES;
    public decimal _VILL_VAL_RES
            {
                get
                {
                    return VILL_VAL_RES;
                }
                set
                {
                    VILL_VAL_RES = value;
                }
            }
    public int? UserID { get; set; }
    //09may2018
    public int? CmnStateUserID { get; set; }
    public int? CmnTigerReserveUserID { get; set; }
    public string FromVillageID { get; set; }
    public int? CmnDataOperatorUserID { get; set; }
    public int? CmnStateID { get; set; }
    public int? CmnDataOperatorTigerReserveID { get; set; }
    public int? CmnVerifyID { get; set; }
    public DateTime? CmnVerifyUpdateDate { get; set; }
    //2june
    public DateTime? DateMeeting { get; set; }
    public int? NoAdult { get; set; }
    public int? NoTransGender { get; set; }
    public int? NoCows { get; set; }
    public int? NoBuffalo { get; set; }
    public int? NoSheep { get; set; }
    public int? NoGoat { get; set; }
    public int flag { get; set; }
   // public int? FileNames { get; set; }
} 

 
             
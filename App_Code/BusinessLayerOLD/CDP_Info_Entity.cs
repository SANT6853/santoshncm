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
/// Summary description for CDP_Info_Entity
/// </summary>
public class CDP_Info_Entity
{
    public CDP_Info_Entity()
    {
        CDP_INFO_ID = null;
        SCHM_ID = null;
        GRP_ID = null;
        CDP_STS_LND = null;
        CDP_ALLTD_AMT = 0;
        CDP_AMT_USD = 0;
        CDP_WORK = "";
        CDP_EXECUTION_AGENCY = "";
        COMMENT = "";
        CDP_RELOCATION_ID = 0;
        CDP_Village_ID = 0;

    }
    public double? AmntAllcteCdpVillRe { get; set; }
    public double? AmountCentraState { get; set; }
    public string FileNames { get; set; }
    public int MyProperty { get; set; }
    public int CdpPrimaryID { get; set; }
    private int  CDP_RELOCATION_ID;
    public int  _CDP_RELOCATION_ID
    {
        get
        {
            return CDP_RELOCATION_ID;
        }
        set
        {
            CDP_RELOCATION_ID = value;
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
    private string CDP_EXECUTION_AGENCY;
    public string _CDP_EXECUTION_AGENCY
    {
        get
        {
            return CDP_EXECUTION_AGENCY;
        }
        set
        {
            CDP_EXECUTION_AGENCY = value;
        }
    }
    private string CDP_WORK;
    public string _CDP_WORK
    {
        get
        {
            return CDP_WORK;
        }
        set
        {
            CDP_WORK = value;
        }
    }
    private string CDP_INFO_ID;
    public string _CDP_INFO_ID
    {
        get
        {
            return CDP_INFO_ID;
        }
        set
        {
            CDP_INFO_ID = value;
        }
    }
    private string SCHM_ID;
    public string _SCHM_ID
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
    private string GRP_ID;
    public string _GRP_ID
    {
        get
        {
            return GRP_ID;
        }
        set
        {
            GRP_ID = value;
        }
    }
    private double CDP_ALLTD_AMT;
    public double _CDP_ALLTD_AMT
    {
        get
        {
            return CDP_ALLTD_AMT;
        }
        set
        {
            CDP_ALLTD_AMT = value;
        }
    }
    private double CDP_AMT_USD;
    public double _CDP_AMT_USD
    {
        get
        {
            return CDP_AMT_USD;
        }
        set
        {
            CDP_AMT_USD = value;
        }
    }
    private string CDP_STS_LND;
    public string _CDP_STS_LND
    {
        get
        {
            return CDP_STS_LND;
        }
        set
        {
            CDP_STS_LND = value;
        }
    }

    private int CDP_Village_ID;
    public int _CDP_Village_ID
    {
        get
        {
            return CDP_Village_ID;
        }
        set
        {
            CDP_Village_ID = value;
        }
    }
}
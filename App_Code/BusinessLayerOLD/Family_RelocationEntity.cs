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
/// Summary description for Family_RelocationEntity
/// </summary>
public class Family_RelocationEntity
{
	public Family_RelocationEntity()
	{
	RELOC_INSTLMNT=0.0;
    TOT_RELOC_COMPN_AMT = 0.0;
    }

    private double RELOC_INSTLMNT;
    public double _RELOC_INSTLMNT
    {
        get
        {
            return RELOC_INSTLMNT;
        }
        set
        {
            RELOC_INSTLMNT = value;
        }
    }

    private double TOT_RELOC_COMPN_AMT;
    public double _TOT_RELOC_COMPN_AMT
    {
        get
        {
            return TOT_RELOC_COMPN_AMT;
        }
        set
        {
            TOT_RELOC_COMPN_AMT = value;
        }
    }

}

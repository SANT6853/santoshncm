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
/// Summary description for Animal_RelocationEntity
/// </summary>
public class Animal_RelocationEntity
{
	public Animal_RelocationEntity()
	{
        ANML_TOT = 0;
	}
    private int ANML_TOT;
    public int _ANML_TOT
    {
        get
        {
            return ANML_TOT;

        }
        set
        {
            ANML_TOT = value;
        }
    }
}

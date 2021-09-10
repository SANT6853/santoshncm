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
/// Summary description for Animal_MasterEntity
/// </summary>
public class Animal_MasterEntity
{
	public Animal_MasterEntity()
    {
        ANML_NM = null;
	}
    private string ANML_NM;
    public string _ANML_NM
    {
        get
        {
            return ANML_NM;

        }
        set
        {
            ANML_NM = value;
        }
    }
}

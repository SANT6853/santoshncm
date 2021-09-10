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
/// Summary description for GroupEntity
/// </summary>
public class GroupEntity
{
	public GroupEntity()
	{
		GRP_ID= null;
        GRP_NM= null;
        VILL_ID= null;
        FMLY_ID= null;
        SCHM_ID = null;
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
    private string GRP_NM;
    public string _GRP_NM
    {
        get
        {
            return GRP_NM;
        }
        set
        {
            GRP_NM = value;
        }
    }
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

}

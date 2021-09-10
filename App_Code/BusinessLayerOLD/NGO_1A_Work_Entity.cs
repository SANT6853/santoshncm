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
/// Summary description for NGO_1A_Work_Entity
/// </summary>
public class NGO_1A_Work_Entity
{
    public NGO_1A_Work_Entity()
    {
        NGO_ID = 0;
        FMLY_ID = 0;
        DESCRIPTION = null;
        WORK_ID = 0;
        REMARK = null;
        ID = 0;
        VILL_ID = 0;
	}


    private string DESCRIPTION;
    public string _DESCRIPTION
    {
        get
        {
            return DESCRIPTION;
        }
        set
        {
            DESCRIPTION = value;
        }
    }

   
    private string REMARK;
    public string _REMARK
    {
        get
        {
            return REMARK;
        }
        set
        {
            REMARK = value;
        }
    }
    private long NGO_ID;
    public long _NGO_ID
    {
        get
        {
            return NGO_ID;
        }
        set
        {
            NGO_ID = value;
        }
    }
    private long FMLY_ID;
    public long _FMLY_ID
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
    private long ID;
    public long _ID
    {
        get
        {
            return ID;
        }
        set
        {
            ID = value;
        }
    }
    private int WORK_ID;
    public int _WORK_ID
    {
        get
        {
            return WORK_ID;
        }
        set
        {
            WORK_ID = value;
        }
    }
    private int VILL_ID;
    public int _VILL_ID
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
}
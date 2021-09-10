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
/// Summary description for DistrictEntity
/// </summary>
public class DistrictEntity
{
	public DistrictEntity()
    {
        DT_ID = 0;
        DT_CD = null;
        DT_NAME = null;
        STDT_CD = 0;

     }
    private int DT_ID;
    public int _DT_ID
     {
         get
         {
             return DT_ID;
         }
         set
         {
             DT_ID = value;

         }
     }

    private string DT_CD;
    public string _DT_CD
    {
        get
        {
            return DT_CD;
        }
        set
        {
            DT_CD = value;

        }
    }

     private string DT_NAME;
     public string _DT_NAME
     {
         get
         {
             return DT_NAME;
         }
         set
         {
             DT_NAME = value;
         }
     }

    private int STDT_CD;
    public int _STDT_CD
     {
         get
         {
             return STDT_CD;
         }
         set
         {
             STDT_CD = value;
         }
     }
}

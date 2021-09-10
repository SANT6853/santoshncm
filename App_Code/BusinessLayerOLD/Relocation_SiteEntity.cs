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
/// Summary description for Relocation_SiteEntity
/// </summary>
public class Relocation_SiteEntity
{
	public Relocation_SiteEntity()
	{
        RELOC_SITE_LAND_AREA = 0.0;
	}
    private double RELOC_SITE_LAND_AREA;
    public double _RELOC_SITE_LAND_AREA
    {
        get
        {
            return RELOC_SITE_LAND_AREA;

        }
        set
        {
            RELOC_SITE_LAND_AREA = value;
        }
    }
}

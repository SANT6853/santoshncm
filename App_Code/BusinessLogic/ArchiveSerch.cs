using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ArchiveSerch
/// </summary>
public class ArchiveSerch
{
	public ArchiveSerch()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int? moduleid { get; set; }
    public int status { get; set; }
    public DateTime? startdate { get; set; }
    public DateTime? enddate { get; set; }
    public int? depid { get; set; }
    public int? categaryid { get; set; }
    public string Tenderrefno { get; set; }
    public int? langid { get; set; }
	 public int? mediaType { get; set; }
    public int? Id { get; set; }


}

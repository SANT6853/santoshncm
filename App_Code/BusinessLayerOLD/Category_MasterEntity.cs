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
/// Summary description for Category_MasterEntity
/// </summary>
public class Category_MasterEntity
{
	public Category_MasterEntity()
	{
        CAT_NM = null;
	} 
    
    private string CAT_NM;
    public string _CAT_NM
    {
        get
        {
            return CAT_NM;
        }
        set
        {
            CAT_NM = value;
        }
    }
   
}

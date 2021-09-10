using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public class miscellaneous
{
    #region Default Constructor

    public miscellaneous()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #endregion

    #region  Function to limit string length characters

    public static string FixCharacters(object Desc, int length)
    {

        StringBuilder stDetails = new StringBuilder();
        stDetails.Insert(0, Desc.ToString());

        if (stDetails.Length > length)
            return stDetails.ToString().Substring(0, length) + "...";
        else return stDetails.ToString();
    }


    #endregion

}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Validations
/// </summary>
public class Validations
{
    public bool Check_Decimal(string value)
    {
        if (!Regex.IsMatch(value, @"[0-9]+(\.[0-9][0-9]?)?"))
        {
            return false;
        }

        decimal value1;
        if (!decimal.TryParse(value, out value1))
        {
            return false;
        }
        return true;
    }
    public bool Check_String(string value)
    {
        if (!Regex.IsMatch(value, "^[a-zA-Z ]+$"))
        {
            return false;
        }

     
        return true;
    }
    public bool Check_Numbers(string value)
    {
        if (!Regex.IsMatch(value, "^[0-9]+$"))
        {
            return false;
        }


        return true;
    }
    public bool Check_Email(string value)
    {
        if (!Regex.IsMatch(value, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            return true;
        }
            return false;
    }
    public bool Check_Date(string value)
    {
        if (!Regex.IsMatch(value, @"^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$"))
        {
            return false;
        }


        return true;
    }
}



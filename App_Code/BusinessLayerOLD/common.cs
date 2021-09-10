using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Text;
using System.IO;

/// <summary>
/// Summary description for common
/// </summary>
public class common
{
    public static int j;



    public List<string> FillDropDownList(DataSet ds, int index, string col)
    {

        List<string> Li = new List<string>();
        for (int i = 0; i < ds.Tables[index].Rows.Count; i++)
        {
            Li.Add(ds.Tables[index].Rows[i][col].ToString());
        }
        return Li;

    }
    public List<string> FillDropDownListProcessManagement(DataSet ds, int index, string col,string colVillCode)
    {

        List<string> Li = new List<string>();
        for (int i = 0; i < ds.Tables[index].Rows.Count; i++)
        {
            Li.Add("VILLAGE NAME: "+ds.Tables[index].Rows[i][col].ToString().ToUpper() + "  [VILLAG CODE: " + ds.Tables[index].Rows[i][colVillCode].ToString().ToUpper() + " ]");
        }
        return Li;

    }
    public static object insertDate(string s)
    {
        // Insert Date in yyyy.MM.dd format in database

        string strdate = null;
        string[] words = s.Split('/');

        string dd = null;
        string MM = null;
        string yyyy = null;
        dd = words[0];
        MM = words[1];
        yyyy = words[2];
        strdate = yyyy + "/" + MM + "/" + dd;
        return strdate;
    }
    public static string splittimefromdate(string textboxvalue)
    {
        string[] firstsplist = textboxvalue.Split(' ');
        string date = firstsplist[0].ToString();
        string[] secondsplit = date.Split('/');
        string mm = secondsplit[0].ToString();
        if (Convert.ToInt32(mm) < 10)
        {
            mm = '0' + mm;
        }
        string dd = secondsplit[1].ToString();
        if (Convert.ToInt32(dd) < 10)
        {
            dd = '0' + dd;
        }
        string yyyy = secondsplit[2].ToString();


        return (dd + '/' + mm + '/' + yyyy);
    }

    public string fordate()
    {
        string date = "", date1 = "", date2 = "";
        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        if (day < 10)
        {
            date1 = "0" + day.ToString();
        }
        else
        {
            date1 = day.ToString();
        }

        if (month < 10)
        {
            date2 = "0" + month.ToString();
        }
        else
        {
            date2 = month.ToString();
        }
        date = date1 + '/' + date2 + '/' + DateTime.Now.Year.ToString();
        return date;
    }


    public string getUniqueFileName(string filname, string filepath, string fileNameWithoutExt, string ext)
    {

        int DotPosition = filname.IndexOf(".");

        string NewFileName = filname;

        int Counter = 0;

        // int FullPath = 0;

        if ((System.IO.File.Exists(filepath + "/" + NewFileName)))
        {

            while (((System.IO.File.Exists(filepath + "/" + NewFileName))))
            {

                Counter = Counter + 1;

                NewFileName = fileNameWithoutExt + "(" + Counter + ")";

                NewFileName = NewFileName + ext;

            }

        }

        else
        {

            NewFileName = fileNameWithoutExt + ext;

        }

        return NewFileName;

    }
    public static string RemoveUnnecessaryHtmlTagHtml(string html)
    {
        string acceptable = "b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|h6|head|hr|link|p|table|tbody|tr|td|tfoot|th|thead|title|id|style|class|span|div|p|a|img|blockquote|center|col|font";
        string stringPattern = "</?(?(?=" + acceptable + ")notag|[a-zA-Z0-9]+)(?:\\s[a-zA-Z0-9\\-]+=?(?:([\",']?).*?\\1?)?)*\\s*/?>";
        return Regex.Replace(html, stringPattern, "");
    }
}